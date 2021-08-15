using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace Club_de_Lectura
{
    public class ConexionBD
    {
        public OdbcConnection conexion { get; set; }

        public ConexionBD()
        {
            System.Configuration.Configuration webConfig;
            webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Club_de_Lectura");
            System.Configuration.ConnectionStringSettings OSC;
            OSC = webConfig.ConnectionStrings.ConnectionStrings["BDClub"];

            conexion = new OdbcConnection(OSC.ToString());
            conexion.Open();
        }
    }
}