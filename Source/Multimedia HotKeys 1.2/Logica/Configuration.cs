using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Configuration
    {
        Datos.Configuration datosConfiguration = new Datos.Configuration();

        public Modelo.Configuration GetConfiguration()
        {
            return datosConfiguration.GetConfiguration();
        }

        public void UpdateMinimizeOnStartUp(bool minimizeOnStartUp)
        {
            datosConfiguration.UpdateMinimizeOnStartUp(minimizeOnStartUp);
        }
    }
}
