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
        // Dll needed to send the keystroke
        [DllImport("user32.dll")]
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

        // ghk = Global HotKey
        private List<Modelo.GlobalHotKey> ghkList = new List<Modelo.GlobalHotKey>();

        // hk = HotKeys => hotKeysList contain all hk from db
        List<Modelo.HotKey> hotKeysList = new List<Modelo.HotKey>();

        public frmMain()
        {
            InitializeComponent();

            // If 'Database.db' does not exist we must create it and load the default values
            VerifyDbExists();
            // Get the hotkeys saved on the DB
            ReadDB();
            if (VerifyDb() != 7)
            {
                MessageBox.Show($"Corrupt database. Try to remove Database.db from the Multimedia HotKeys directory and restart the application.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                Environment.Exit(-1);
            }
            else
            {
                // Select the first element of the combobox
                cbSelectDefaultIndex();
                // We try to found duplicated values on hotKeyList
                FoundDuplicatedValue();
                // Assign the saved hotkeys to the corresponding keys and register them
                AssignGlobalHotKeys();
                // Register the ghkList
                foreach (var ghk in ghkList)
                    ghkRegister(ghk);
            }
        }

        public void VerifyDbExists()
        {
            string pathDb = System.Environment.CurrentDirectory + "\\Database.db";
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            if (!File.Exists(pathDb))
            {                
                logicaHotKey.CreateDb();
            }
        }

        public int VerifyDb()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            return logicaHotKey.VerifyDb(hotKeysList);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ntfiMain.Visible = true;
                ntfiMain.ShowBalloonTip(100);
                Hide();
            }
        }

        private void ntfiMain_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntfiMain.Visible = false;
        }

        private void tsmItemConfiguration_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            ntfiMain.Visible = false;
        }

        private void tsmItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbHotKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            hkUpdateCombination();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApp();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        // Methods

        public void cbSelectDefaultIndex()
        {
            cbHotKeys.SelectedIndex = 0;
            cbModifier.SelectedIndex = 0;
            cbKey.SelectedIndex = 0;
        }

        private void hkUpdateCombination()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            Modelo.HotKey hkSelected = logicaHotKey.ReadByName(cbHotKeys.Text);
            tbHotkeys.Text = logicaHotKey.ReplacehkPressedText(hkSelected);
        }

        public void ReadDB()
        {
            // Clear listHotKeys
            hotKeysList.Clear();
            // Reads the keys assigned in the db
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            foreach (var hotKey in logicaHotKey.Read())
            {
                hotKeysList.Add(hotKey);
            }
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
            {
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AssignGlobalHotKeys()
        {
            ghkList.Clear();// Clear ghkList
            foreach (var hotKey in hotKeysList)
            {
                Logica.HotKey logicaHotKey = new Logica.HotKey();
                if (logicaHotKey.VerifyKeyPressed(hotKey.Key))
                {
                    AddGlobalHotKeys(hotKey);
                }
                else
                {
                    MessageBox.Show($"Hotkey {hotKey.Name} has assigned key {hotKey.Key} which is not an allowed value.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddGlobalHotKeys(Modelo.HotKey hotKey)
        {
            Keys keyPressed = new Keys();
            Enum.TryParse(hotKey.Key, out keyPressed);// This convert the hotkey from db to Keys => (the value in the db is equivalent to Keys.ToString)                        
            int intKeyPressed = (int)keyPressed;// We convert to integer so as not to need later Windows.System.Forms

            if (hotKey.Modifier == "Alt")
            {
                ghkList.Add(new Modelo.GlobalHotKey(Modelo.GlobalHotKey.Constants.ALT, intKeyPressed, this.Handle, hotKey.Name));
            }
            else // (hotKeys.Modifier == "Ctrl")
            {
                ghkList.Add(new Modelo.GlobalHotKey(Modelo.GlobalHotKey.Constants.CTRL, intKeyPressed, this.Handle, hotKey.Name));
            }
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
                string modifierPressed = "";
                // Convert the pressed key to string
                string keyPressed = (GetKey(m.LParam)).ToString();

                // We check if the pressed modifier is ALT or CTRL
                int modifier = (int)m.LParam & 0xFFFF;
                if (modifier == Modelo.GlobalHotKey.Constants.ALT)
                    modifierPressed = "Alt"; // Modificador = ALT
                if (modifier == Modelo.GlobalHotKey.Constants.CTRL)
                    modifierPressed = "Ctrl";// Modificador = CTRL

                // Save the hotkey pressed
                Logica.HotKey logicaHotKey = new Logica.HotKey();
                Modelo.HotKey hkPressed = logicaHotKey.ReadByKeysPressed(modifierPressed, keyPressed);

                FilterhkPressed(hkPressed.Name);
            }
            base.WndProc(ref m);
        }

        private void FilterhkPressed(string hkPressed)
        {
            // Execute the corresponding method
            switch (hkPressed)
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
            // We use that to get the key pressed
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        private void Save()
        {
            Logica.HotKey logicaHotKey = new Logica.HotKey();
            // We create a Modelo.HotKey to store the data to Save
            Modelo.HotKey hkToUpdate = new Modelo.HotKey(cbHotKeys.Text, cbModifier.Text, cbKey.Text);
            // cbKeys must be saved as keys                    

            logicaHotKey.Update(hkToUpdate); //We send the values to update
            MessageBox.Show("Hot key updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // We only register and unregister the updated hk
            foreach (var ghk in ghkList)
            {
                if (ghk.Name == hkToUpdate.Name)
                {
                    ghkUnregister(ghk);
                }
            }

            // Update the hkList
            ReadDB();
            // We update tbHotKeys
            tbHotkeys.Text = cbModifier.Text + " + " + cbKey.Text;
            // We try to found duplicated values on hotKeyList
            FoundDuplicatedValue();
            // Remove the old hk assigned
            DeleteGlobalHotKeys(hkToUpdate);
            // Add the new hk assigned
            AddGlobalHotKeys(hkToUpdate);

            foreach (var ghk in ghkList)
            {
                if (ghk.Name == hkToUpdate.Name)
                {
                    ghkRegister(ghk);
                }
            }
        }

        private void ghkRegister(Modelo.GlobalHotKey ghk)
        {
            // Register the hotkey
            if (!ghk.Register())
                MessageBox.Show($"Hotkey {ghk.Name} failed to register", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ghkUnregister(Modelo.GlobalHotKey ghk)
        {
            if (!ghk.Unregister())
                MessageBox.Show($"Hotkey {ghk.Name} failed to unregister!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ExitApp()
        {
            if (ghkList.Count != 0)
            {
                foreach (var ghk in ghkList)
                    ghkUnregister(ghk);
            }
            Application.Exit();
        }
    }
}
