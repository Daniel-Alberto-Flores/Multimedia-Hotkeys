using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Modelo
{
    public class GlobalHotKey
    {
        public static class Constants
        {
            // Modifiers
            public const int ALT = 0x0001;
            public const int CTRL = 0x0002;

            // Windows message id for hotkey
            public const int WM_HOTKEY_MSG_ID = 0x0312;
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int Modifier;
        private int Key;
        private IntPtr hWnd;
        private int Id;
        public string Name;

        public GlobalHotKey(int modifier, int key, IntPtr form, string name)
        {
            this.Modifier = modifier;
            this.Key = key;
            this.hWnd = form;
            this.Name = name;
            Id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Modifier ^ Key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, Id, Modifier, Key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, Id);
        }
    }
}

