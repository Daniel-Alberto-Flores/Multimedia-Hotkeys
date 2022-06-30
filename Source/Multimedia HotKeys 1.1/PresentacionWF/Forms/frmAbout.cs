using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionWF.Forms
{
    public partial class frmAbout : Form
    {
        int verifyClose = 0;

        public frmAbout()
        {
            InitializeComponent();
        }

        private void BtnHideClick(object sender, EventArgs e)
        {
            Exit();
        }

        private void FrmAboutFormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        // Methods

        private void BtnClickFilter(object sender, EventArgs e)
        {
            string Link = "";
            Button btnPressed = (Button)sender;
            switch (btnPressed.Name)
            {
                case "btnSourceForge":
                    Link = "https://sourceforge.net/projects/multimedia-hotkeys/";
                    break;
                case "btnGitHub":
                    Link = "https://github.com/daniel-alberto-flores";
                    break;
                case "btnLinkedIn":
                    Link = "https://www.linkedin.com/in/daniel-flores-45417517a/";
                    break;
                case "btnOpenSource":
                    Link = "https://es.wikipedia.org/wiki/C%C3%B3digo_abierto";
                    break;
                case "btnCSharp":
                    Link = "https://docs.microsoft.com/en-us/dotnet/csharp/";
                    break;
                case "btnSQLite":
                    Link = "https://www.sqlite.org/index.html";
                    break;
            }
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = Link;
            proc.Start();
        }

        private void Exit()
        {
            this.Hide();
        }        
    }
}
