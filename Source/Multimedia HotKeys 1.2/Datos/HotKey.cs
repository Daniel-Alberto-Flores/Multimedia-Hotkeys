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

        public Modelo.HotKey ReadByKeysPressed(string keyPressed)
        {
            Modelo.HotKey hkPressed = (from hk in db.HotKeys
                                       where (hk.Key == keyPressed)
                                       select hk).First();
            return hkPressed;
        }

        public void Update(Modelo.HotKey hotKeyToUpdate)
        {
            var hotKey = (from hk in db.HotKeys
                          where (hk.Name == hotKeyToUpdate.Name)
                          select hk).First();
            hotKey.Key = hotKeyToUpdate.Key;
            db.SaveChanges();
        }
    }
}
