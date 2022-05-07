namespace Converter
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogIDX = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogStatic = new System.Windows.Forms.OpenFileDialog();
			this.StartButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.XLenght = new System.Windows.Forms.TextBox();
			this.YLenght = new System.Windows.Forms.TextBox();
			this.MapFile = new System.Windows.Forms.TextBox();
			this.IDXFile = new System.Windows.Forms.TextBox();
			this.Worker = new System.ComponentModel.BackgroundWorker();
			this.CellprogressBar = new System.Windows.Forms.ProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.NumericVersionUop = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.OnlyOsiStatics = new System.Windows.Forms.CheckBox();
			this.MapID = new System.Windows.Forms.NumericUpDown();
			this.about_btn = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ArtPanel = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.ArtIDXTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.StaticFile = new System.Windows.Forms.TextBox();
			this.status = new System.Windows.Forms.StatusStrip();
			this.display = new System.Windows.Forms.ToolStripStatusLabel();
			this.BlockprogressBar = new System.Windows.Forms.ProgressBar();
			this.ArtIdx = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericVersionUop)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MapID)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.ArtPanel.SuspendLayout();
			this.status.SuspendLayout();
			this.SuspendLayout();
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.FileName = "map4.mul";
			this.OpenFileDialog.Filter = "MUL files|*.mul";
			this.OpenFileDialog.RestoreDirectory = true;
			this.OpenFileDialog.Title = "Open Mul Map File";
			this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
			// 
			// openFileDialogIDX
			// 
			this.openFileDialogIDX.FileName = "staidx4.mul";
			this.openFileDialogIDX.Filter = "MUL files|*.mul";
			this.openFileDialogIDX.RestoreDirectory = true;
			this.openFileDialogIDX.Title = "Open Mul IDX File";
			this.openFileDialogIDX.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogIDX_FileOk);
			// 
			// openFileDialogStatic
			// 
			this.openFileDialogStatic.FileName = "statics4.mul";
			this.openFileDialogStatic.Filter = "MUL files|*.mul";
			this.openFileDialogStatic.RestoreDirectory = true;
			this.openFileDialogStatic.Title = "Open Mul Static File";
			this.openFileDialogStatic.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogStatic_FileOk);
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(8, 156);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(105, 20);
			this.StartButton.TabIndex = 14;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(481, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(22, 21);
			this.button1.TabIndex = 15;
			this.button1.Text = "..";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(481, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(22, 20);
			this.button2.TabIndex = 16;
			this.button2.Text = "..";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(481, 62);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(22, 20);
			this.button3.TabIndex = 17;
			this.button3.Text = "..";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "MapID:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "X Length";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Y Length";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 13);
			this.label7.TabIndex = 24;
			this.label7.Text = "MapMul";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 44);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 13);
			this.label8.TabIndex = 25;
			this.label8.Text = "StaticIDX";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 65);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 26;
			this.label9.Text = "Statics";
			// 
			// XLenght
			// 
			this.XLenght.Location = new System.Drawing.Point(60, 17);
			this.XLenght.Name = "XLenght";
			this.XLenght.Size = new System.Drawing.Size(59, 20);
			this.XLenght.TabIndex = 29;
			// 
			// YLenght
			// 
			this.YLenght.Location = new System.Drawing.Point(60, 41);
			this.YLenght.Name = "YLenght";
			this.YLenght.Size = new System.Drawing.Size(59, 20);
			this.YLenght.TabIndex = 30;
			// 
			// MapFile
			// 
			this.MapFile.Location = new System.Drawing.Point(65, 19);
			this.MapFile.Name = "MapFile";
			this.MapFile.ReadOnly = true;
			this.MapFile.Size = new System.Drawing.Size(410, 20);
			this.MapFile.TabIndex = 31;
			// 
			// IDXFile
			// 
			this.IDXFile.Location = new System.Drawing.Point(65, 41);
			this.IDXFile.Name = "IDXFile";
			this.IDXFile.ReadOnly = true;
			this.IDXFile.Size = new System.Drawing.Size(410, 20);
			this.IDXFile.TabIndex = 32;
			// 
			// Worker
			// 
			this.Worker.WorkerReportsProgress = true;
			this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
			this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
			this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
			// 
			// CellprogressBar
			// 
			this.CellprogressBar.Location = new System.Drawing.Point(164, 168);
			this.CellprogressBar.Name = "CellprogressBar";
			this.CellprogressBar.Size = new System.Drawing.Size(509, 10);
			this.CellprogressBar.TabIndex = 33;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.NumericVersionUop);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.OnlyOsiStatics);
			this.groupBox1.Controls.Add(this.MapID);
			this.groupBox1.Controls.Add(this.about_btn);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.StartButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(147, 182);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(83, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 40;
			this.label1.Text = "Uop:";
			// 
			// NumericVersionUop
			// 
			this.NumericVersionUop.InterceptArrowKeys = false;
			this.NumericVersionUop.Location = new System.Drawing.Point(113, 15);
			this.NumericVersionUop.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.NumericVersionUop.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.NumericVersionUop.Name = "NumericVersionUop";
			this.NumericVersionUop.Size = new System.Drawing.Size(28, 20);
			this.NumericVersionUop.TabIndex = 39;
			this.NumericVersionUop.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.XLenght);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.YLenght);
			this.groupBox3.Location = new System.Drawing.Point(8, 41);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(131, 89);
			this.groupBox3.TabIndex = 38;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Custom Map";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(60, 64);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(59, 20);
			this.button4.TabIndex = 31;
			this.button4.Text = "Default";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// OnlyOsiStatics
			// 
			this.OnlyOsiStatics.AutoSize = true;
			this.OnlyOsiStatics.Location = new System.Drawing.Point(8, 136);
			this.OnlyOsiStatics.Name = "OnlyOsiStatics";
			this.OnlyOsiStatics.Size = new System.Drawing.Size(100, 17);
			this.OnlyOsiStatics.TabIndex = 32;
			this.OnlyOsiStatics.Text = "Only Osi Statics";
			this.OnlyOsiStatics.UseVisualStyleBackColor = true;
			this.OnlyOsiStatics.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// MapID
			// 
			this.MapID.Location = new System.Drawing.Point(51, 15);
			this.MapID.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.MapID.Name = "MapID";
			this.MapID.Size = new System.Drawing.Size(29, 20);
			this.MapID.TabIndex = 38;
			// 
			// about_btn
			// 
			this.about_btn.Location = new System.Drawing.Point(119, 156);
			this.about_btn.Name = "about_btn";
			this.about_btn.Size = new System.Drawing.Size(22, 20);
			this.about_btn.TabIndex = 31;
			this.about_btn.Text = "?";
			this.about_btn.UseVisualStyleBackColor = true;
			this.about_btn.Click += new System.EventHandler(this.about_btn_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ArtPanel);
			this.groupBox2.Controls.Add(this.StaticFile);
			this.groupBox2.Controls.Add(this.IDXFile);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.MapFile);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new System.Drawing.Point(165, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(509, 150);
			this.groupBox2.TabIndex = 35;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Path";
			// 
			// ArtPanel
			// 
			this.ArtPanel.Controls.Add(this.button5);
			this.ArtPanel.Controls.Add(this.ArtIDXTextBox);
			this.ArtPanel.Controls.Add(this.label2);
			this.ArtPanel.Enabled = false;
			this.ArtPanel.Location = new System.Drawing.Point(6, 95);
			this.ArtPanel.Name = "ArtPanel";
			this.ArtPanel.Size = new System.Drawing.Size(494, 49);
			this.ArtPanel.TabIndex = 37;
			this.ArtPanel.TabStop = false;
			this.ArtPanel.Text = "Osi Arts";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(459, 19);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(22, 20);
			this.button5.TabIndex = 5;
			this.button5.Text = "..";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// ArtIDXTextBox
			// 
			this.ArtIDXTextBox.Location = new System.Drawing.Point(64, 19);
			this.ArtIDXTextBox.Name = "ArtIDXTextBox";
			this.ArtIDXTextBox.ReadOnly = true;
			this.ArtIDXTextBox.Size = new System.Drawing.Size(389, 20);
			this.ArtIDXTextBox.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Artidx.mul";
			// 
			// StaticFile
			// 
			this.StaticFile.Location = new System.Drawing.Point(65, 62);
			this.StaticFile.Name = "StaticFile";
			this.StaticFile.ReadOnly = true;
			this.StaticFile.Size = new System.Drawing.Size(410, 20);
			this.StaticFile.TabIndex = 36;
			// 
			// status
			// 
			this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.display});
			this.status.Location = new System.Drawing.Point(0, 197);
			this.status.Name = "status";
			this.status.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.status.Size = new System.Drawing.Size(685, 22);
			this.status.TabIndex = 36;
			this.status.Text = "statusStrip1";
			// 
			// display
			// 
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(118, 17);
			this.display.Text = "toolStripStatusLabel1";
			// 
			// BlockprogressBar
			// 
			this.BlockprogressBar.Location = new System.Drawing.Point(164, 184);
			this.BlockprogressBar.Name = "BlockprogressBar";
			this.BlockprogressBar.Size = new System.Drawing.Size(510, 10);
			this.BlockprogressBar.TabIndex = 37;
			// 
			// ArtIdx
			// 
			this.ArtIdx.FileName = "artidx.mul";
			this.ArtIdx.Filter = "MUL files|*.mul";
			this.ArtIdx.RestoreDirectory = true;
			this.ArtIdx.FileOk += new System.ComponentModel.CancelEventHandler(this.ArtIdx_FileOk);
			// 
			// Main_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(685, 219);
			this.Controls.Add(this.BlockprogressBar);
			this.Controls.Add(this.status);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.CellprogressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main_Form";
			this.Opacity = 0.95;
			this.Text = "Mul 2 Uop v2.8";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericVersionUop)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MapID)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ArtPanel.ResumeLayout(false);
			this.ArtPanel.PerformLayout();
			this.status.ResumeLayout(false);
			this.status.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogIDX;
        private System.Windows.Forms.OpenFileDialog openFileDialogStatic;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox XLenght;
        private System.Windows.Forms.TextBox YLenght;
        private System.Windows.Forms.TextBox MapFile;
        private System.Windows.Forms.TextBox IDXFile;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ProgressBar CellprogressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox StaticFile;
        private System.Windows.Forms.Button about_btn;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel display;
        private System.Windows.Forms.ProgressBar BlockprogressBar;
        private System.Windows.Forms.GroupBox ArtPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox ArtIDXTextBox;
        private System.Windows.Forms.CheckBox OnlyOsiStatics;
        private System.Windows.Forms.NumericUpDown MapID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog ArtIdx;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumericVersionUop;
    }
}

