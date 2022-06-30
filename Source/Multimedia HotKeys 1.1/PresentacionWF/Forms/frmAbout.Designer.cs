namespace PresentacionWF.Forms
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.imlAbout = new System.Windows.Forms.ImageList(this.components);
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.btnCSharp = new System.Windows.Forms.Button();
            this.btnSQLite = new System.Windows.Forms.Button();
            this.btnOpenSource = new System.Windows.Forms.Button();
            this.btnLinkedIn = new System.Windows.Forms.Button();
            this.btnGitHub = new System.Windows.Forms.Button();
            this.btnSourceForge = new System.Windows.Forms.Button();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblDeveloped = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pbxGastosApp = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ttipShowInfo = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGastosApp)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTop.Controls.Add(this.btnHide);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(577, 22);
            this.pnlTop.TabIndex = 9;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.White;
            this.btnHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHide.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHide.ImageKey = "Back.png";
            this.btnHide.ImageList = this.imlAbout;
            this.btnHide.Location = new System.Drawing.Point(1, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(69, 22);
            this.btnHide.TabIndex = 16;
            this.btnHide.Text = "Hide";
            this.btnHide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.BtnHideClick);
            // 
            // imlAbout
            // 
            this.imlAbout.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlAbout.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlAbout.ImageStream")));
            this.imlAbout.TransparentColor = System.Drawing.Color.Transparent;
            this.imlAbout.Images.SetKeyName(0, "Back.png");
            this.imlAbout.Images.SetKeyName(1, "GastosApp.png");
            this.imlAbout.Images.SetKeyName(2, "C#_logo.png");
            this.imlAbout.Images.SetKeyName(3, "SQLite.png");
            this.imlAbout.Images.SetKeyName(4, "GitHub.png");
            this.imlAbout.Images.SetKeyName(5, "LinkedIn.png");
            this.imlAbout.Images.SetKeyName(6, "SourceForge.png");
            // 
            // rtbInfo
            // 
            this.rtbInfo.BackColor = System.Drawing.Color.White;
            this.rtbInfo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rtbInfo.Location = new System.Drawing.Point(19, 161);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbInfo.Size = new System.Drawing.Size(159, 131);
            this.rtbInfo.TabIndex = 31;
            this.rtbInfo.Text = "Thank you very much for using this application.\nIf you have any questions, do not" +
    " hesitate to contact me.\n";
            // 
            // btnCSharp
            // 
            this.btnCSharp.BackColor = System.Drawing.Color.White;
            this.btnCSharp.BackgroundImage = global::PresentacionWF.Properties.Resources.C__logo;
            this.btnCSharp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCSharp.Location = new System.Drawing.Point(342, 217);
            this.btnCSharp.Name = "btnCSharp";
            this.btnCSharp.Size = new System.Drawing.Size(75, 75);
            this.btnCSharp.TabIndex = 30;
            this.ttipShowInfo.SetToolTip(this.btnCSharp, "Language used: C#. Visit their website.");
            this.btnCSharp.UseVisualStyleBackColor = false;
            this.btnCSharp.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // btnSQLite
            // 
            this.btnSQLite.BackColor = System.Drawing.Color.White;
            this.btnSQLite.BackgroundImage = global::PresentacionWF.Properties.Resources.SQLite;
            this.btnSQLite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSQLite.Location = new System.Drawing.Point(423, 217);
            this.btnSQLite.Name = "btnSQLite";
            this.btnSQLite.Size = new System.Drawing.Size(75, 75);
            this.btnSQLite.TabIndex = 29;
            this.ttipShowInfo.SetToolTip(this.btnSQLite, "Database engine used: SQLite. Visit their website.");
            this.btnSQLite.UseVisualStyleBackColor = false;
            this.btnSQLite.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // btnOpenSource
            // 
            this.btnOpenSource.BackColor = System.Drawing.Color.White;
            this.btnOpenSource.BackgroundImage = global::PresentacionWF.Properties.Resources.OpenSource;
            this.btnOpenSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenSource.Location = new System.Drawing.Point(261, 217);
            this.btnOpenSource.Name = "btnOpenSource";
            this.btnOpenSource.Size = new System.Drawing.Size(75, 75);
            this.btnOpenSource.TabIndex = 28;
            this.ttipShowInfo.SetToolTip(this.btnOpenSource, "Free and open-source software.");
            this.btnOpenSource.UseVisualStyleBackColor = false;
            this.btnOpenSource.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // btnLinkedIn
            // 
            this.btnLinkedIn.BackColor = System.Drawing.Color.White;
            this.btnLinkedIn.BackgroundImage = global::PresentacionWF.Properties.Resources.LinkedIn;
            this.btnLinkedIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLinkedIn.Location = new System.Drawing.Point(423, 136);
            this.btnLinkedIn.Name = "btnLinkedIn";
            this.btnLinkedIn.Size = new System.Drawing.Size(75, 75);
            this.btnLinkedIn.TabIndex = 27;
            this.ttipShowInfo.SetToolTip(this.btnLinkedIn, "Visit LinkedIn profile.");
            this.btnLinkedIn.UseVisualStyleBackColor = false;
            this.btnLinkedIn.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // btnGitHub
            // 
            this.btnGitHub.BackColor = System.Drawing.Color.White;
            this.btnGitHub.BackgroundImage = global::PresentacionWF.Properties.Resources.GitHub;
            this.btnGitHub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGitHub.Location = new System.Drawing.Point(342, 136);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(75, 75);
            this.btnGitHub.TabIndex = 26;
            this.ttipShowInfo.SetToolTip(this.btnGitHub, "Visit my GitHub profile.");
            this.btnGitHub.UseVisualStyleBackColor = false;
            this.btnGitHub.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // btnSourceForge
            // 
            this.btnSourceForge.BackColor = System.Drawing.Color.White;
            this.btnSourceForge.BackgroundImage = global::PresentacionWF.Properties.Resources.SourceForge;
            this.btnSourceForge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSourceForge.ImageKey = "(ninguna)";
            this.btnSourceForge.Location = new System.Drawing.Point(261, 136);
            this.btnSourceForge.Name = "btnSourceForge";
            this.btnSourceForge.Size = new System.Drawing.Size(75, 75);
            this.btnSourceForge.TabIndex = 25;
            this.ttipShowInfo.SetToolTip(this.btnSourceForge, "Visit my SourceForge profile.");
            this.btnSourceForge.UseVisualStyleBackColor = false;
            this.btnSourceForge.Click += new System.EventHandler(this.BtnClickFilter);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContact.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblContact.Location = new System.Drawing.Point(261, 111);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(247, 16);
            this.lblContact.TabIndex = 24;
            this.lblContact.Text = "Contact: dan.alb.flo@gmail.com";
            // 
            // lblDeveloped
            // 
            this.lblDeveloped.AutoSize = true;
            this.lblDeveloped.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDeveloped.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDeveloped.Location = new System.Drawing.Point(261, 89);
            this.lblDeveloped.Name = "lblDeveloped";
            this.lblDeveloped.Size = new System.Drawing.Size(223, 16);
            this.lblDeveloped.TabIndex = 23;
            this.lblDeveloped.Text = "Developed by: Daniel Flores";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVersion.Location = new System.Drawing.Point(261, 67);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(142, 22);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = "Version: 1.1";
            // 
            // pbxGastosApp
            // 
            this.pbxGastosApp.BackgroundImage = global::PresentacionWF.Properties.Resources.MultimediaHotkeys;
            this.pbxGastosApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxGastosApp.Location = new System.Drawing.Point(14, 27);
            this.pbxGastosApp.Name = "pbxGastosApp";
            this.pbxGastosApp.Size = new System.Drawing.Size(164, 128);
            this.pbxGastosApp.TabIndex = 21;
            this.pbxGastosApp.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(184, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 40);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Multimedia Hotkeys";
            // 
            // ttipShowInfo
            // 
            this.ttipShowInfo.BackColor = System.Drawing.Color.White;
            this.ttipShowInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttipShowInfo.ToolTipTitle = "Info";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(577, 318);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btnCSharp);
            this.Controls.Add(this.btnSQLite);
            this.Controls.Add(this.btnOpenSource);
            this.Controls.Add(this.btnLinkedIn);
            this.Controls.Add(this.btnGitHub);
            this.Controls.Add(this.btnSourceForge);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblDeveloped);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.pbxGastosApp);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(577, 318);
            this.MinimumSize = new System.Drawing.Size(577, 318);
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAboutFormClosed);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGastosApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlTop;
        private Button btnHide;
        private RichTextBox rtbInfo;
        private Button btnCSharp;
        private Button btnSQLite;
        private Button btnOpenSource;
        private Button btnLinkedIn;
        private Button btnGitHub;
        private Button btnSourceForge;
        private Label lblContact;
        private Label lblDeveloped;
        private Label lblVersion;
        private PictureBox pbxGastosApp;
        private ImageList imlAbout;
        private Label lblTitle;
        private ToolTip ttipShowInfo;
    }
}