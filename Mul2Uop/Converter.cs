using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text;
using System.ComponentModel;


namespace Converter
{
    public class ConvertMap
	{
		#region New Format
		int m_Version;
		#endregion

		string m_mapmulname;
        string m_idxname;
        string m_staticsname;
        byte m_MapID;
        int m_XLength;
        int m_YLength;
        Int16 m_CellID;
        int m_YFixedLength;
        int m_XFixedLength;
        string m_dir;

        public ConvertMap(string mapmulname, string idxname, string m_staticsname, byte mapID, int Xlength, int Ylength,BackgroundWorker worker, int Version)
		{
			#region New Format
			this.m_Version = Version;
			#endregion
			this.m_mapmulname = mapmulname;
            this.m_idxname = idxname;
            this.m_staticsname = m_staticsname;
            this.m_MapID = mapID;
            this.m_XLength = Xlength;
            this.m_YLength = Ylength;
            string folder = String.Format("facet{0}//", mapID.ToString());
            this.m_dir = String.Format("{1}build//sectors//facet_0{0}", mapID.ToString(), folder);
            Directory.CreateDirectory(m_dir);

            BinaryReader reader = new BinaryReader(binreadstream);
            for (int i = 0; i < binreadstream.Length / 5; i++)
            {
                Int16 mlgraphic = reader.ReadInt16();
                byte type = (byte)binreadstream.ReadByte();
                Int16 krgraphic = reader.ReadInt16();
                if (!m_ml2kr.ContainsKey(mlgraphic))
                    m_ml2kr.Add(mlgraphic, new KRGraphicandType(type, krgraphic));


            }
            m_YFixedLength = FindFixed64lengthY(m_YLength);
            m_XFixedLength = FindFixed64lengthX(m_XLength);

			#region Version 4 - KR Format
			if (m_Version >= 5)
			{
				//There is a small uncompressed file also in SA facets
			}
			else
			{
				FileStream writestream = File.Create(String.Format("{2}build//sectors//{1}", m_MapID.ToString(), "Index_0", folder));
				BinaryWriter writer = new BinaryWriter(writestream);
				writer.Write((Int32)m_YLength);
				writer.Write((Int32)m_XLength);
				writer.Close();
				writestream.Close();
			}
			#endregion

			/*for (m_CellID = 0; m_CellID < ((m_YFixedLength / 64) * (m_XFixedLength / 64)); m_CellID++)
            {
                worker.ReportProgress(((m_CellID * 100) / ((m_YFixedLength / 64) * (m_XFixedLength / 64))) , false);
                MakeCell(m_CellID, worker);
            }*/
            for (m_CellID = 0; m_CellID < ((m_YFixedLength / 64) * (m_XFixedLength / 64)); m_CellID++)
            {
                int progress = (m_CellID * 100) / ((m_YFixedLength / 64) * (m_XFixedLength / 64));

                float xf = (m_XFixedLength / 64);
                float yf = (m_YFixedLength / 64);
                float decim = (m_CellID * 100) / (yf * xf);
                int newprogress = (int)((decim - progress) * 100);

                if ((progress >= 0 && progress <= 100) && (newprogress >= 0 && newprogress <= 100))
                {
                    worker.ReportProgress(progress, false);
                    worker.ReportProgress(newprogress, true);
                }
                else
                {
                    MessageBox.Show("Cell Out of Max Progress!!");
                }

                MakeCell(m_CellID, worker);
            }
        }
        #region Utils
        private static byte[] m_Buffer = new byte[100];
		Dictionary<int, KRGraphicandType> m_ml2kr = new Dictionary<int, KRGraphicandType>();
		FileStream binreadstream = File.OpenRead("ML2KR.bin");
		private long m_currentpostion = 0;

        private static byte[] ReversedintToDWord(Int16 value)
        {
            byte[] dword = new byte[4];
            dword[1] = (byte)(value >> 8);
            dword[0] = (byte)value;
            return dword;
        }
        private static byte[] IntToDWordReversed(Int16 value)
        {
            byte[] dword = new byte[2];
            dword[1] = (byte)(value >> 8);
            dword[0] = (byte)value;
            return dword;
        }
        private int FindFixed64lengthX(int Length)
        {
            switch (m_MapID)
            {
                case 0: return 7168;
                case 1: return 7168;
                case 2: return 2304;
                case 3: return 2560;
                case 4: return 1472;
            }
            return 0;
        }
        private int FindFixed64lengthY(int Length)
        {
            switch (m_MapID)
            {
                case 0: return 4096;
                case 1: return 4096;
                case 2: return 1600;
                case 3: return 2048;
                case 4: return 1472;
            }
            return 0;
        }

		/// <summary>
		/// Writes Single LandTile Or Delimiter
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="relativedirection"></param>
		/// <param name="m_bufferposition"></param>
		/// <param name="isdelimiter"></param>
		/// <returns></returns>
		private int ReadOneTile(BinaryReader reader, byte relativedirection, int m_bufferposition, bool isdelimiter)
		{
			short m_graphic = reader.ReadInt16();

			//Types
			if (!isdelimiter)
				m_Buffer[m_bufferposition++] = 0x00;

			m_Buffer[m_bufferposition++] = 0x00;

			if (isdelimiter)
				m_Buffer[m_bufferposition++] = relativedirection;

			//Z
			m_Buffer[m_bufferposition++] = reader.ReadByte();

			//Graphic
			if (m_Version >= 5)
			{
				#region Version 5 - SA Format
				if (isdelimiter)
				{
					m_Buffer[m_bufferposition++] = IntToDWordReversed(m_graphic)[0];//KRGraphic
					m_Buffer[m_bufferposition++] = IntToDWordReversed(m_graphic)[1];
					m_Buffer[m_bufferposition++] = 0;//KRUnk
				}
				#endregion
			}
			else
			{
				#region Version 4 - KR Format
				KRGraphicandType ml2kr = new KRGraphicandType(0, 0);
				m_ml2kr.TryGetValue(m_graphic, out ml2kr);

				if (ml2kr != null)
				{
					//KRGraphic
					m_Buffer[m_bufferposition++] = IntToDWordReversed(ml2kr.KRGraphic)[0];
					m_Buffer[m_bufferposition++] = IntToDWordReversed(ml2kr.KRGraphic)[1];
					//KRType
					if (isdelimiter)
					{
						m_Buffer[m_bufferposition++] = 0;
					}
					else
						m_Buffer[m_bufferposition++] = ml2kr.Type;

				}
				else
					m_Buffer[m_bufferposition++] = m_Buffer[m_bufferposition++] = m_Buffer[m_bufferposition++] = 0x00;
				#endregion
			}

			if (isdelimiter)
				reader.BaseStream.Seek(m_currentpostion, SeekOrigin.Begin);
			else
			{
				m_Buffer[m_bufferposition++] = IntToDWordReversed(m_graphic)[0];
				m_Buffer[m_bufferposition++] = IntToDWordReversed(m_graphic)[1];
			}

			return m_bufferposition;
		}
        #endregion

        public void MakeCell(Int16 CellID, BackgroundWorker worker)
        {
            m_CellID = CellID;

            int m_startStatic = -1;
            int m_lenghtStatic = -1;
            long m_MapPosition64 = 0;

			using (FileStream writestream = File.Create(String.Format("{0}//{1}.bin", m_dir, m_CellID.ToString("D8"))))
			{
				FileStream stream = File.OpenRead(m_mapmulname);
				FileStream streamIDX = File.OpenRead(m_idxname);
				FileStream streamStatic = File.OpenRead(m_staticsname);

				BinaryWriter writer = new BinaryWriter(writestream);

				BinaryReader reader = new BinaryReader(stream);
				BinaryReader readerIDX = new BinaryReader(streamIDX);
				BinaryReader static_reader = new BinaryReader(streamStatic);

				//MapID
				writer.BaseStream.WriteByte(m_MapID);

				stream.Seek((196 * 8) * (m_CellID % (m_YFixedLength / 64)) + ((m_CellID - (m_CellID % (m_YFixedLength / 64))) / (m_YFixedLength / 64)) * m_YLength * 196, SeekOrigin.Begin);

				worker.ReportProgress(0, true);
				//Current Block
				int max = (4096 * m_CellID + 4096);
				for (int i = 4096 * m_CellID; i < max; i++)
				{

					// KR X and Y 64x64 Cells 
					int Y = (i % 64);
					int X = (i / 64) % 64;
					// ML X and Y 8x8 Cells
					int Y8 = Y % 8;
					int X8 = X % 8;
					// Real X and Y
					int RealX = (m_CellID / (m_YFixedLength / 64)) * 64 + (i - 4096 * m_CellID) / 64;
					int RealY = (((m_CellID % (m_YFixedLength / 64)) * 64) + i % 64);

					if (i % 512 == 0 && i != 4096 * m_CellID)
						m_MapPosition64 = m_MapPosition64 - 8 * 3 + (m_YLength / 8) * 196;

					if (Y % 64 == 0 && X != 0)
					{
						m_MapPosition64 = m_MapPosition64 + 3;
						stream.Seek(m_MapPosition64, SeekOrigin.Begin);
					}
					if (i % 64 == 0)
					{
						m_MapPosition64 = stream.Position;
					}
					if (i % 8 == 0)
						stream.Seek(4, SeekOrigin.Current);


					if (RealY >= m_YLength)
					{
						for (int i2 = 0; i2 < 8; i2++)
							writer.BaseStream.WriteByte(0x00);
						continue;
					}
					if (RealX >= m_XLength)
					{
						for (int i2 = 0; i2 < 8; i2++)
							writer.BaseStream.WriteByte(0x00);
						continue;
					}
					/*
					* IDX 
					* 
					* DWORD is the Start position (0xFFFFFFFF if no static objects exist for this block)
					* DWORD is the Length of the data segment
					* DWORD is of unknown use 
					* 
					* STATICS
					* 
					* UWORD for the Color/Object ID (add 16384 to offset it for RADARCOL.MUL)
					* UBYTE X Offset in block (0..7)
					* UBYTE Y Offset in block (0..7)
					* BYTE Altitude (-128..127 units above/below sea level, like MAP0)
					* UWORD Unknown 
					* 
					* 
					* MAP
					* 
					* 768x512 matrix of blocks. 8x8 matrix of cells. 
					* Blocks are loaded top-to-bottom then left-to-right. 
					* Cells are loaded from blocks left-to-right then top-to-bottom.
					* There's 512 blocks down, by 768 blocks across.
					* 
					* XBlock = Int(XPos/8)
					* YBlock = Int(YPos/8)
					* Block Number = (XBlock * 512) + YBlock 
					* 
					* MAP0 (37,748,736 bytes)
					* 393,216 [Block]s sequentially, Block = 196 bytes
					* DWORD header, unknown content
					* 64 Cells
					* 
					* UWORD cell graphic (which can be looked up in RADARCOL).
					* BYTE Altitude (-128..127 units above/below sea level).
					* 
					*/
					#region Static Part
					stream.Seek(-((X8 * 3 + Y8 * 8 * 3) + 4), SeekOrigin.Current);
					//Kons

					// In OSI 01 00 00 00 --> 67 e1 00 00
					// in Custom non-sense o_O

					//streamIDX.Seek(reader.ReadInt32() * 12, SeekOrigin.Begin);
					//int map_header;

					//for test
					stream.Seek(+4, SeekOrigin.Current);



					int Cell8ID = (RealY / 8) + (RealX / 8) * (m_YLength / 8);
					streamIDX.Seek(Cell8ID * 12, SeekOrigin.Begin);  //IDX

					m_startStatic = readerIDX.ReadInt32();
					m_lenghtStatic = readerIDX.ReadInt32();
					readerIDX.ReadInt32();

					stream.Seek((X8 * 3 + Y8 * 8 * 3), SeekOrigin.Current);
					#endregion Static Part

					#region LandTile
					ReadOneTile(reader, 0, 0, false);
					if (i == 4096 * m_CellID)
					{
						m_Buffer[0] = ReversedintToDWord(m_CellID)[0];
						m_Buffer[1] = ReversedintToDWord(m_CellID)[1];
					}
					#region Version - SA KR mod
					if (m_Version >= 5)
						writer.BaseStream.Write(m_Buffer, 0, 5);
					else
						writer.BaseStream.Write(m_Buffer, 0, 8);
					#endregion
					#endregion LandTile

					#region Delimiter

					m_currentpostion = stream.Position;
					int m_bufferposition = 0;

					if (X == 0 && RealX != 0)
					{
						stream.Seek(-((m_YLength / 8) * 196 - 6 * 3), SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 0, m_bufferposition, true);
					}
					if ((Y == 0 && X == 0) && (RealX != 0 && RealY != 0))
					{
						stream.Seek(-((m_YLength / 8) * 196 - 6 * 3 + 8 * 3 + 4), SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 1, m_bufferposition, true);
					}
					if (Y == 0 && RealY != 0)
					{
						stream.Seek(-(9 * 3 + 4), SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 2, m_bufferposition, true);
					}
					if (X == 63)
					{
						stream.Seek(((m_YLength / 8) * 196) - 8 * 3, SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 3, m_bufferposition, true);
					}
					if (X == 63 && Y == 63 && RealY != (m_YFixedLength - 1))
					{
						stream.Seek(((m_YLength / 8) * 196) + 4, SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 4, m_bufferposition, true);
					}
					if (Y == 63 && RealY != m_YFixedLength - 1)
					{
						stream.Seek(25, SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 5, m_bufferposition, true);
					}
					if (Y == 63 && X == 0 && RealX != 0 && RealY != (m_YFixedLength - 1))
					{
						stream.Seek(-((m_YLength / 8) * 196) + 15 * 3 + 4, SeekOrigin.Current);
						m_bufferposition = ReadOneTile(reader, 6, m_bufferposition, true);
					}
					if (X == 63 && Y == 0 && RealY != 0)
					{
						stream.Seek(m_currentpostion + (((m_YLength / 8)) * 196) - 8 * 3, SeekOrigin.Begin);
						m_bufferposition = ReadOneTile(reader, 7, m_bufferposition, true);
					}

					m_Buffer[0] = (byte)(m_bufferposition / 6);
					if (m_bufferposition > 0)
						writer.BaseStream.Write(m_Buffer, 0, m_bufferposition);
					#endregion Delimiter

					#region Static Part
					if (m_startStatic != -1)
					{
						Int16[] m_ItemIDArray = new Int16[100];
						byte[] m_ZArray = new byte[100];
						Int16[] m_Color = new Int16[100];
						int m_index = 0;

						streamStatic.Seek(m_startStatic, SeekOrigin.Begin);
						for (int i2 = 0; i2 < m_lenghtStatic / 7; i2++)
						{
							Int16 m_ItemID = static_reader.ReadInt16();
							int m_x = static_reader.ReadByte();
							int m_y = static_reader.ReadByte();
							byte m_z = static_reader.ReadByte();
							Int16 m_mlColor = static_reader.ReadInt16();

							if (Main_Form.CheckForBadStatic(m_ItemID))
								continue;
							if (m_x == (X % 64) % 8 && m_y == (Y % 64) % 8)
							{
								m_ItemIDArray[m_index] = m_ItemID;
								m_ZArray[m_index] = m_z;
								m_Color[m_index] = m_mlColor;
								m_index = m_index + 1;
							}

						}
						if (m_index > 0)
						{
							writer.BaseStream.WriteByte(0);
							writer.BaseStream.WriteByte((byte)m_index);
						}

						for (int i3 = 0; i3 < m_index; i3++)
						{
							if (i3 != 0)
							{
								writer.BaseStream.WriteByte(0);
								writer.BaseStream.WriteByte(0);
							}
							writer.BaseStream.Write(ReversedintToDWord(m_ItemIDArray[i3]), 0, 2);
							writer.BaseStream.WriteByte(0x00); //unk 1
							writer.BaseStream.WriteByte(0x00); //unk 2
							writer.BaseStream.WriteByte(m_ZArray[i3]);
							writer.BaseStream.Write(ReversedintToDWord(m_Color[i3]), 0, 2); //Color 2bytes

						}
					}
					#endregion Static Part

					//Move Pointer Y+1
					stream.Seek(7 * 3, SeekOrigin.Current);
				}
				//EOF

				m_Buffer[0] = m_Buffer[1] = 0x00;
				writer.BaseStream.Write(m_Buffer, 0, 2);

			}
        }

    }
    public class KRGraphicandType
    {
        Int16 m_krgraphic = 0;
        byte m_type = 0;

        public KRGraphicandType(byte type, Int16 krgraphic)
        {
            this.m_krgraphic = krgraphic;
            this.m_type = type;
        }
        public byte Type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        public Int16 KRGraphic
        {
            get { return m_krgraphic; }
            set { m_krgraphic = value; }
        }

    }
}