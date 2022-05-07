using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Converter
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        #region Form
        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists("Settings.bin"))
            {
                using (FileStream settingsstream = new System.IO.FileStream("Settings.bin", System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (BinaryReader settingsreader = new BinaryReader(settingsstream))
                    {
                        OpenFileDialog.FileName = settingsreader.ReadString();
                        openFileDialogIDX.FileName = settingsreader.ReadString();
                        openFileDialogStatic.FileName = settingsreader.ReadString();
                        XLenght.Text = settingsreader.ReadString();
                        YLenght.Text = settingsreader.ReadString();
                        MapID.Text = settingsreader.ReadString();
                        OnlyOsiStatics.Checked = settingsreader.ReadBoolean();
                        ArtIdx.FileName = settingsreader.ReadString();
                    }
                }
            }
            MapFile.Text = OpenFileDialog.FileName;
            IDXFile.Text = openFileDialogIDX.FileName;
            StaticFile.Text = openFileDialogStatic.FileName;
            ArtIDXTextBox.Text = ArtIdx.FileName;

            display.Text = "Welcome, select path to begin.";
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (FileStream settingsstream = new System.IO.FileStream("Settings.bin", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                using (BinaryWriter settingswriter = new BinaryWriter(settingsstream))
                {
                    settingswriter.Write(OpenFileDialog.FileName);
                    settingswriter.Write(openFileDialogIDX.FileName);
                    settingswriter.Write(openFileDialogStatic.FileName);
                    settingswriter.Write(XLenght.Text);
                    settingswriter.Write(YLenght.Text);
                    settingswriter.Write(MapID.Text);
                    settingswriter.Write(OnlyOsiStatics.Checked);
                    settingswriter.Write(ArtIdx.FileName);
                }
            }
        }
        #endregion

        public static List<Int32> BadStaticList;
        public static bool StaticCheckEnabled = false;
        public static int maxnumber = 0;
        public static bool CheckForBadStatic(int number)
        {
            if (StaticCheckEnabled && BadStaticList.Contains(number) && number<=maxnumber)
                return true;
            return false;
        }
        private void StartButton_Click(object sender, EventArgs e)
        {

            //Disabled buttons.
            StartButton.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
			button4.Enabled = false;

            BlockprogressBar.Maximum = 100;
            CellprogressBar.Maximum = 100;

            //disabling settings
            MapID.Enabled = false;
            XLenght.Enabled = false;
            YLenght.Enabled = false;

			OnlyOsiStatics.Enabled = false;
			NumericVersionUop.Enabled = false;

            Worker.WorkerReportsProgress = true;
            Worker.RunWorkerAsync();
        }

        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialogIDX.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialogStatic.ShowDialog();
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            MapFile.Text = OpenFileDialog.FileName;
        }
        private void openFileDialogIDX_FileOk(object sender, CancelEventArgs e)
        {
            IDXFile.Text = openFileDialogIDX.FileName;
        }
        private void openFileDialogStatic_FileOk(object sender, CancelEventArgs e)
        {
            StaticFile.Text = openFileDialogStatic.FileName;
        }
        private void about_btn_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ArtIdx.ShowDialog();
        }
        #endregion

        #region Worker
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!File.Exists("ML2KR.bin"))
            {
				MessageBox.Show("Can`t find ML2KR.bin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
            }
            if (StaticCheckEnabled)
            {
                display.Text = "Loading Static Dictionary..";
                BadStaticList = new List<Int32>();
                if (File.Exists(ArtIdx.FileName))
                {
                    using (FileStream artidxstream = new System.IO.FileStream(ArtIdx.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (BinaryReader artidxreader = new BinaryReader(artidxstream))
                        {
                            maxnumber = Convert.ToInt32(artidxstream.Length / 12);
                            for (int i = 0; i < artidxstream.Length / 12; i++)
                            {
                                BlockprogressBar.Value=(int)(i*100/(artidxstream.Length / 12));
                                int Lookup = artidxreader.ReadInt32();
                                artidxstream.Seek(8, SeekOrigin.Current);
                                if (Lookup == -1)
                                    BadStaticList.Add(i);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("art.mul not exist!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!File.Exists(OpenFileDialog.FileName) | !File.Exists(openFileDialogIDX.FileName) | !File.Exists(openFileDialogStatic.FileName))
            {
                MessageBox.Show("Some file(s) not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            display.Text = "Working..";

            new ConvertMap(OpenFileDialog.FileName, openFileDialogIDX.FileName, openFileDialogStatic.FileName, Convert.ToByte(MapID.Value), Convert.ToInt32(XLenght.Text), Convert.ToInt32(YLenght.Text),Worker,(int)NumericVersionUop.Value);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {  
            if (e.UserState is bool)
            {
                bool whichbar = (bool)e.UserState;
                if (whichbar == true)
                {
                    if( e.ProgressPercentage != 0 )
                        BlockprogressBar.Value = e.ProgressPercentage;
                }
                else
                    CellprogressBar.Value = e.ProgressPercentage;
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartButton.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
			button4.Enabled = true;
            //Cleaning bars
            CellprogressBar.Value = 0;
            BlockprogressBar.Value = 0;
            //Eabling settings
            MapID.Enabled = true;
            XLenght.Enabled = true;
            YLenght.Enabled = true;

			OnlyOsiStatics.Enabled = true;
			NumericVersionUop.Enabled = true;

            display.Text = "Facet folder done!";
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StaticCheckEnabled = OnlyOsiStatics.Checked;
            if (OnlyOsiStatics.Checked == true)
                ArtPanel.Enabled = true;
            else
                ArtPanel.Enabled = false;
        }

        private void MapID_TextChanged(object sender, EventArgs e)
        {

        }
        private void ArtIdx_FileOk(object sender, CancelEventArgs e)
        {
            ArtIDXTextBox.Text = ArtIdx.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt16(MapID.Value))
            {
                case 0: XLenght.Text = (7168).ToString();break;
                case 1: XLenght.Text = (7168).ToString();break;
                case 2: XLenght.Text = (2304).ToString();break;
                case 3: XLenght.Text = (2560).ToString();break;
                case 4: XLenght.Text = (1448).ToString();break;
            }
            switch (Convert.ToInt16(MapID.Value))
            {
                case 0: YLenght.Text = (4096).ToString(); break;
                case 1: YLenght.Text = (4096).ToString(); break;
                case 2: YLenght.Text = (1600).ToString(); break;
                case 3: YLenght.Text = (2048).ToString(); break;
                case 4: YLenght.Text = (1448).ToString(); break;
            }
        }
    }
}