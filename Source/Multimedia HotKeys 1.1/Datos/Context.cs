using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Context
    {
        Modelo.DatabaseContext db = new Modelo.DatabaseContext();

        public bool CreateDb()
        {
            bool createState = true;
            try
            {
                // If 'Database.db' does not exist we must create it and load the default values
                db.Database.EnsureCreatedAsync();
                List<Modelo.HotKey> hkList = new List<Modelo.HotKey>();
                hkList.AddRange(new List<Modelo.HotKey>
            {
                new Modelo.HotKey("Mute", "D1"),
                new Modelo.HotKey("Volume down", "D2"),
                new Modelo.HotKey("Volume up", "D3"),
                new Modelo.HotKey("Stop", "D4"),
                new Modelo.HotKey("Prev", "D5"),
                new Modelo.HotKey("Play/Pause", "D6"),
                new Modelo.HotKey("Next", "D7")
            });
                db.AddRange(hkList);
                Modelo.Configuration Configuration = new Modelo.Configuration() { minimizeOnStartUp = false };
                db.Add(Configuration);
                db.SaveChanges();
            }
            catch (Exception)
            {
                createState = false;// If we cant created the db we return false and shutdown the app
            }
            return createState;            
        }

        public int VerifyDb(List<Modelo.HotKey> hotKeysList)
        {
            var verifyModifiers = (from hk in hotKeysList
                                   where
                                   (
                                    (hk.Name == "Mute") || (hk.Name == "Volume down") ||
                                    (hk.Name == "Volume up") || (hk.Name == "Stop") ||
                                    (hk.Name == "Prev") || (hk.Name == "Play/Pause") ||
                                    (hk.Name == "Next")
                                   )
                                   select hk);
            return verifyModifiers.Count();
        }
    }
}
