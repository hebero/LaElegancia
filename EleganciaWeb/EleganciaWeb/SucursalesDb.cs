using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EleganciaWeb
{
    public class SucursalesDb
    {
        public DataTable CargarLista(string Conexion)
        {
            SqlConnection cn; SqlCommand cmd; DataTable dt;
            using (cn = new SqlConnection(Conexion))
            {
                using(cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IdBodega, Nombre FROM Bodega";
                    cmd.Connection = cn;
                    dt = new DataTable();
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                    cn.Close();
                }
            }
            return dt;
        }
    }
}