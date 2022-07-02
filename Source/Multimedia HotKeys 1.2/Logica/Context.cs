using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Context
    {
        Datos.Context datosContext = new Datos.Context();

        public bool CreateDb()
        {
            return datosContext.CreateDb();
        }

        public bool VerifyDbExists()
        {
            string pathDb = System.Environment.CurrentDirectory + "\\Database.db";
            if (File.Exists(pathDb))
                return true;// If the db exists we return true
            else
                return false;// If the database does not exist we return false
        }

        public int VerifyDb(List<Modelo.HotKey> hotKeysList)
        {
            return datosContext.VerifyDb(hotKeysList);
        }

    }
}
