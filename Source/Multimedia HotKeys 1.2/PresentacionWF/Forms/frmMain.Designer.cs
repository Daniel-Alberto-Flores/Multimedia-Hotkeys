namespace PresentacionWF.Forms
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblKeys = new System.Windows.Forms.Label();
            this.lblHotKeys = new System.Windows.Forms.Label();
            this.lblNewKey = new System.Windows.Forms.Label();
            this.cbHotKeys = new System.Windows.Forms.ComboBox();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.tbHotkeys = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imglMain = new System.Windows.Forms.ImageList(this.components);
            this.ntfiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmstripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmItemConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cxbMinimizeOnStartUp = new System.Windows.Forms.CheckBox();
            this.ttipShowInfo = new System.Windows.Forms.ToolTip(this.components);
            this.cmstripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKeys
            // 
            this.lblKeys.AutoSize = true;
            this.lblKeys.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKeys.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblKeys.Location = new System.Drawing.Point(30, 13);
            this.lblKeys.Name = "lblKeys";
            this.lblKeys.Size = new System.Drawing.Size(115, 17);
            this.lblKeys.TabIndex = 0;
            this.lblKeys.Text = "Assigned keys:";
            // 
            // lblHotKeys
            // 
            this.lblHotKeys.AutoSize = true;
            this.lblHotKeys.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHotKeys.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHotKeys.Location = new System.Drawing.Point(13, 40);
            this.lblHotKeys.Name = "lblHotKeys";
            this.lblHotKeys.Size = new System.Drawing.Size(130, 17);
            this.lblHotKeys.TabIndex = 1;
            this.lblHotKeys.Text = "Hotkey assigned:";
            // 
            // lblNewKey
            // 
            this.lblNewKey.AutoSize = true;
            this.lblNewKey.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNewKey.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNewKey.Location = new System.Drawing.Point(30, 67);
            this.lblNewKey.Name = "lblNewKey";
            this.lblNewKey.Size = new System.Drawing.Size(216, 17);
            this.lblNewKey.TabIndex = 2;
            this.lblNewKey.Text = "Select the new key to assign:";
            // 
            // cbHotKeys
            // 
            this.cbHotKeys.DropDownHeight = 100;
            this.cbHotKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHotKeys.FormattingEnabled = true;
            this.cbHotKeys.IntegralHeight = false;
            this.cbHotKeys.Items.AddRange(new object[] {
            "Mute",
            "Volume down",
            "Volume up",
            "Stop",
            "Prev",
            "Play/Pause",
            "Next"});
            this.cbHotKeys.Location = new System.Drawing.Point(161, 12);
            this.cbHotKeys.Name = "cbHotKeys";
            this.cbHotKeys.Size = new System.Drawing.Size(121, 21);
            this.cbHotKeys.TabIndex = 3;
            this.cbHotKeys.SelectedIndexChanged += new System.EventHandler(this.CbHotKeysSelectedIndexChanged);
            // 
            // cbKey
            // 
            this.cbKey.DropDownHeight = 80;
            this.cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey.FormattingEnabled = true;
            this.cbKey.IntegralHeight = false;
            this.cbKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "-",
            "+"});
            this.cbKey.Location = new System.Drawing.Point(161, 87);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(88, 21);
            this.cbKey.TabIndex = 4;
            // 
            // tbHotkeys
            // 
            this.tbHotkeys.Enabled = false;
            this.tbHotkeys.Location = new System.Drawing.Point(161, 39);
            this.tbHotkeys.Name = "tbHotkeys";
            this.tbHotkeys.ReadOnly = true;
            this.tbHotkeys.Size = new System.Drawing.Size(121, 21);
            this.tbHotkeys.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageKey = "Save.png";
            this.btnSave.ImageList = this.imglMain;
            this.btnSave.Location = new System.Drawing.Point(216, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttipShowInfo.SetToolTip(this.btnSave, "Save");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // imglMain
            // 
            this.imglMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imglMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglMain.ImageStream")));
            this.imglMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglMain.Images.SetKeyName(0, "Save.png");
            // 
            // ntfiMain
            // 
            this.ntfiMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfiMain.BalloonTipText = "Multimedia Hotkeys minimized";
            this.ntfiMain.BalloonTipTitle = "Multimedia Hotkeys";
            this.ntfiMain.ContextMenuStrip = this.cmstripMain;
            this.ntfiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfiMain.Icon")));
            this.ntfiMain.Text = "Multimedia Hotkey";
            this.ntfiMain.DoubleClick += new System.EventHandler(this.NtfiMainDoubleClick);
            // 
            // cmstripMain
            // 
            this.cmstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmItemConfiguration,
            this.tsmItemAbout,
            this.tsmItemExit});
            this.cmstripMain.Name = "cmstripMain";
            this.cmstripMain.Size = new System.Drawing.Size(149, 70);
            // 
            // tsmItemConfiguration
            // 
            this.tsmItemConfiguration.Name = "tsmItemConfiguration";
            this.tsmItemConfiguration.Size = new System.Drawing.Size(148, 22);
            this.tsmItemConfiguration.Text = "Configuration";
            this.tsmItemConfiguration.Click += new System.EventHandler(this.TsmItemConfigurationClick);
            // 
            // tsmItemAbout
            // 
            this.tsmItemAbout.Name = "tsmItemAbout";
            this.tsmItemAbout.Size = new System.Drawing.Size(148, 22);
            this.tsmItemAbout.Text = "About";
            this.tsmItemAbout.Click += new System.EventHandler(this.TsmItemAboutClick);
            // 
            // tsmItemExit
            // 
            this.tsmItemExit.Name = "tsmItemExit";
            this.tsmItemExit.Size = new System.Drawing.Size(148, 22);
            this.tsmItemExit.Text = "Exit";
            this.tsmItemExit.Click += new System.EventHandler(this.TsmItemExitClick);
            // 
            // cxbMinimizeOnStartUp
            // 
            this.cxbMinimizeOnStartUp.AutoSize = true;
            this.cxbMinimizeOnStartUp.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cxbMinimizeOnStartUp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cxbMinimizeOnStartUp.Location = new System.Drawing.Point(12, 117);
            this.cxbMinimizeOnStartUp.Name = "cxbMinimizeOnStartUp";
            this.cxbMinimizeOnStartUp.Size = new System.Drawing.Size(165, 21);
            this.cxbMinimizeOnStartUp.TabIndex = 10;
            this.cxbMinimizeOnStartUp.Text = "Minimize on startup";
            this.ttipShowInfo.SetToolTip(this.cxbMinimizeOnStartUp, "You must click save if you have modified this value.");
            this.cxbMinimizeOnStartUp.UseVisualStyleBackColor = true;
            // 
            // ttipShowInfo
            // 
            this.ttipShowInfo.BackColor = System.Drawing.Color.White;
            this.ttipShowInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttipShowInfo.ToolTipTitle = "Info";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(290, 145);
            this.Controls.Add(this.cxbMinimizeOnStartUp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbHotkeys);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.cbHotKeys);
            this.Controls.Add(this.lblNewKey);
            this.Controls.Add(this.lblHotKeys);
            this.Controls.Add(this.lblKeys);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(306, 184);
            this.MinimumSize = new System.Drawing.Size(306, 184);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainFormClosing);
            this.Resize += new System.EventHandler(this.FrmMainResize);
            this.cmstripMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblKeys;
        private Label lblHotKeys;
        private Label lblNewKey;
        private ComboBox cbHotKeys;
        private ComboBox cbKey;
        private TextBox tbHotkeys;
        private Button btnSave;
        public NotifyIcon ntfiMain;
        private ContextMenuStrip cmstripMain;
        private ImageList imglMain;
        private ToolStripMenuItem tsmItemConfiguration;
        private ToolStripMenuItem tsmItemExit;
        private CheckBox cxbMinimizeOnStartUp;
        private ToolTip ttipShowInfo;
        private ToolStripMenuItem tsmItemAbout;
    }
}