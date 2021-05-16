using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SaludCloudV2.Models
{
    public static class Conexion
    {
        public static SqlConnection GetConexion()
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-G76MC6P ; database=SaludCloud ; integrated security = true");
            con.Open();
            return con;
        }

    }
}