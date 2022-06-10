using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class HotKey
    {
        Modelo.DatabaseContext db = new Modelo.DatabaseContext();

        public void CreateDb()
        {
            // If 'Database.db' does not exist we must create it and load the default values
            db.Database.EnsureCreatedAsync();
            List<Modelo.HotKey> hkList = new List<Modelo.HotKey>();
            hkList.AddRange(new List<Modelo.HotKey>
            {
                new Modelo.HotKey("Mute", "Ctrl", "D1"),
                new Modelo.HotKey("Volume down", "Ctrl", "D2"),
                new Modelo.HotKey("Volume up", "Ctrl", "D3"),
                new Modelo.HotKey("Stop", "Ctrl", "D4"),
                new Modelo.HotKey("Prev", "Ctrl", "D5"),
                new Modelo.HotKey("Play/Pause", "Ctrl", "D6"),
                new Modelo.HotKey("Next", "Ctrl", "D7")
            });
            db.AddRange(hkList);
            db.SaveChanges();
        }

        public List<Modelo.HotKey> Read()
        {
            var listHotKeys = (from hk in db.HotKeys
                               select hk).ToList();
            return listHotKeys;
        }

        public Modelo.HotKey ReadByName(string hotKeyName)
        {
            Modelo.HotKey hkSelected = (from hk in db.HotKeys
                                        where (hk.Name == hotKeyName)
                                        select hk).First();
            return hkSelected;
        }

        public Modelo.HotKey ReadByKeysPressed(string modifierPressed, string keyPressed)
        {
            Modelo.HotKey hkPressed = (from hk in db.HotKeys
                                       where (hk.Modifier == modifierPressed) && (hk.Key == keyPressed)
                                       select hk).First();
            return hkPressed;
        }

        public void Update(Modelo.HotKey hotKeyToUpdate)
        {
            var hotKey = (from hk in db.HotKeys
                          where (hk.Name == hotKeyToUpdate.Name)
                          select hk).First();
            hotKey.Modifier = hotKeyToUpdate.Modifier;
            hotKey.Key = hotKeyToUpdate.Key;
            db.SaveChanges();
        }

        public int VerifyDb(List<Modelo.HotKey> hotKeysList)
        {
            var verifyModifiers = (from hk in hotKeysList
                                   where
                                   (
                                    (hk.Modifier == "Ctrl") || (hk.Modifier == "Alt") &&
                                    (hk.Name == "Mute") || (hk.Name == "Volume down") ||
                                    (hk.Name == "Volume up") || (hk.Name == "Stop") ||
                                    (hk.Name == "Prev") || (hk.Name == "Play/Pause") ||
                                    (hk.Name == "Next")
                                   )
                                   select hk.Modifier);
            return verifyModifiers.Count();
        }
    }
}
