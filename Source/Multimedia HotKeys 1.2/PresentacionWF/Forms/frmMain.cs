using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace PresentacionWF.Forms
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]// Dll needed to send the keystroke
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        // Represents the value corresponding to the virtual keystroke
        public const int keyEventfExtendedKey = 1;
        public const int vkVolumeMute = 0xAD;
        public const int vkVolumeDown = 0xAE;
        public const int vkVolumeUp = 0xAF;
        public const int vkMediaStop = 0xB2;
        public const int vkMediaPrev = 0xB1;
        public const int vkMediaPlayPause = 0xB3;
        public const int vkMediaNext = 0xB0;
        
        List<Modelo.GlobalHotKey> ghkList = new List<Modelo.GlobalHotKey>();// ghk = Global HotKey
        List<Modelo.HotKey> hotKeysList = new List<Modelo.HotKey>();// hk = HotKeys => hotKeysList contain all hk from db
        Modelo.Configuration Configurations = new Modelo.Configuration();
        int verifyClose = 0;

        public frmMain()
        {
            InitializeComponent();            
            VerifyDbExists();// If 'Database.db' does not exist we must create it and load the default values         
            ReadDB();// Get the hotkeys saved on the DB
            if (VerifyDb() != 7)
            {
                MessageBox.Show($"Corrupt database. Try to remove Database.db from the Multimedia HotKeys directory and restart the application.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                Environment.Exit(-1);
            }
            else
            {
                GetConfiguration();// We get the configurations values
                SetConfiguration();// We set the configurations values
                CbSelectDefaultIndex();// Select the first element of the combobox
                FoundDuplicatedValue();// We try to found duplicated values on hotKeyList
                AssignGlobalHotKeys();// Assign the saved hotkeys to the corresponding keys and register them
                GhkRegisterList();// We register all ghk
                MinimizeOnStartUp();
            }
        }

        private void CbHotKeysSelectedIndexChanged(object sender, EventArgs e)
        {
            HkUpdateCombination();
        }

        private void FrmMainResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ntfiMain.Visible = true;
                ntfiMain.ShowBalloonTip(100);
                this.Hide();
            }
        }

        private void NtfiMainDoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntfiMain.Visible = false;
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            Save();
        }

        private void TsmItemConfigurationClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntfiMain.Visible = false;
        }

        private void TsmItemAboutClick(object sender, EventArgs e)
        {
            GhkUnregisterList();
            verifyClose = 1;
            ntfiMain.Visible = false;
            this.Hide();
            frmAbout frmAbout = new frmAbout();
            frmAbout.Show();
        }

        private void TsmItemExitClick(object sender, EventArgs e)
        {
            Exit();
        }        

        private void FrmMainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (verifyClose == 0)
                Exit();                       
        }

        // Methods

        public void VerifyDbExists()
        {
            Logica.Context logicaContext = new Logica.Context();
            if (!logicaContext.VerifyDbExists())
            {
                if (logicaContext.CreateDb())
                {
                    MessageBox.Show("Database created.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The database could not be created. Restart the app.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
        }

        public int VerifyDb()
        {
            Logica.Context logicaContext = new Logica.Context();
            return logicaContext.VerifyDb(hotKeysList);
        }

        private void GetConfiguration()
        {
            Logica.Configuration logicaConfiguration = new Logica.Configuration();
            Configurations = logicaConfiguration.GetConfiguration();
        }

        private void SetConfiguration()
        {
            if (Configurations.minimizeOnStartUp)
                cxbMinimizeOnStartUp.Checked = true;
            else
                cxbMinimizeOnStartUp.Checked = false;
        }

        public void CbSelectDefaultIndex()
        {
            cbHotKeys.SelectedIndex = 0;
            cbKey.SelectedIndex = 0;
        }

        private void HkUpdateCombination()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            Modelo.HotKey hkSelected = logicaHotKey.ReadByName(cbHotKeys.Text);
            tbHotkeys.Text = logicaHotKey.ReplacehkPressedText(hkSelected);
        }

        public void ReadDB()
        {            
            hotKeysList.Clear();// Clear listHotKeys            
            Logica.HotKey logicaHotKey = new Logica.HotKey();// Reads the keys assigned in the db
            foreach (var hotKey in logicaHotKey.Read())
                hotKeysList.Add(hotKey);
        }

        private void FoundDuplicatedValue()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            string hkDuplicatedNames = logicaHotKey.FoundDuplicatedValues(hotKeysList);
            string message = $"Found same combination of keys for different hotkeys.\n" +
                             $"\n" +
                             $"Hotkeys duplicated: {hkDuplicatedNames}\n" +
                             $"\n" +
                             $"Some of these hotkeys may not work properly. Modify duplicate values.";
            if (hkDuplicatedNames != "")
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AssignGlobalHotKeys()
        {
            ghkList.Clear();// Clear ghkList
            foreach (var hotKey in hotKeysList)
            {
                Logica.HotKey logicaHotKey = new Logica.HotKey();
                if (logicaHotKey.VerifyKeyPressed(hotKey.Key))
                    AddGlobalHotKeys(hotKey);
                else
                    MessageBox.Show($"Hotkey {hotKey.Name} has assigned key {hotKey.Key} which is not an allowed value.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddGlobalHotKeys(Modelo.HotKey hotKey)
        {
            Keys keyPressed = new Keys();
            Enum.TryParse(hotKey.Key, out keyPressed);// This convert the hotkey from db to Keys => (the value in the db is equivalent to Keys.ToString)                        
            int intKeyPressed = (int)keyPressed;// We convert to integer so as not to need later Windows.System.Forms
            ghkList.Add(new Modelo.GlobalHotKey(Modelo.GlobalHotKey.Constants.CTRL + Modelo.GlobalHotKey.Constants.ALT, intKeyPressed, this.Handle, hotKey.Name));
        }

        private void DeleteGlobalHotKeys(Modelo.HotKey hotKey)
        {
            var ghkToDelete = ghkList.Where(ghk => ghk.Name == hotKey.Name).First();
            ghkList.Remove(ghkToDelete);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Modelo.GlobalHotKey.Constants.WM_HOTKEY_MSG_ID)
            {
                Logica.HotKey logicaHotKey = new Logica.HotKey();
                string keyPressed = (GetKey(m.LParam)).ToString();// Convert the pressed key to string
                Modelo.HotKey hkPressed = logicaHotKey.ReadByKeysPressed(keyPressed);// Save the hotkey pressed
                FilterhkPressed(hkPressed.Name);
            }
            base.WndProc(ref m);
        }

        private void FilterhkPressed(string hkPressed)
        {            
            switch (hkPressed)// Execute the corresponding method
            {
                case "Mute":
                    keybd_event(vkVolumeMute, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Volume down":
                    keybd_event(vkVolumeDown, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Volume up":
                    keybd_event(vkVolumeUp, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Stop":
                    keybd_event(vkMediaStop, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Prev":
                    keybd_event(vkMediaPrev, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Play/Pause":
                    keybd_event(vkMediaPlayPause, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
                case "Next":
                    keybd_event(vkMediaNext, 0, keyEventfExtendedKey, IntPtr.Zero);
                    break;
            }
        }

        private Keys GetKey(IntPtr LParam)
        {            
            return (Keys)((LParam.ToInt32()) >> 16);// We use that to get the key pressed
        }

        private void Save()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            Logica.Configuration logicaConfiguration = new Logica.Configuration();
            // We create a Modelo.HotKey to store the data to Save
            Modelo.HotKey hkToUpdate = new Modelo.HotKey(cbHotKeys.Text, cbKey.Text);// cbKeys must be saved as keys
            logicaHotKey.Update(hkToUpdate); //We send the values to update            
            logicaConfiguration.UpdateMinimizeOnStartUp(cxbMinimizeOnStartUp.Checked);// We update the value of configuration minimizeOnStartUp
            MessageBox.Show("Hot key updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            foreach (var ghk in ghkList)// We only register and unregister the updated hk
            {
                if (ghk.Name == hkToUpdate.Name)
                    GhkUnregister(ghk);
            }
            ReadDB();// Update the hkList            
            tbHotkeys.Text = "CTRL + ALT + " + cbKey.Text;// We update tbHotKeys            
            FoundDuplicatedValue();// We try to found duplicated values on hotKeyList            
            DeleteGlobalHotKeys(hkToUpdate);// Remove the old hk assigned            
            AddGlobalHotKeys(hkToUpdate);// Add the new hk assigned
            foreach (var ghk in ghkList)
            {
                if (ghk.Name == hkToUpdate.Name)
                    GhkRegister(ghk);
            }
        }

        public void MinimizeOnStartUp()
        {
            if (Configurations.minimizeOnStartUp)
                WindowState = FormWindowState.Minimized;
        }

        private void GhkRegister(Modelo.GlobalHotKey ghk)
        {            
            if (!ghk.Register())// Register the hotkey
                MessageBox.Show($"Hotkey {ghk.Name} failed to register", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void GhkUnregister(Modelo.GlobalHotKey ghk)
        {
            if (!ghk.Unregister())
                MessageBox.Show($"Hotkey {ghk.Name} failed to unregister!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }        

        private void GhkRegisterList()
        {
            foreach (Modelo.GlobalHotKey ghk in ghkList)// We register the ghkList only the first time frmMain is opened
                GhkRegister(ghk);
        }

        private void GhkUnregisterList()
        {
            foreach (Modelo.GlobalHotKey ghk in ghkList)
                GhkUnregister(ghk);
        }

        private void Exit()
        {
            verifyClose = 1;            
            GhkUnregisterList();
            Application.Exit();
        }        
    }
}