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
        public void NuevaSucursal(string Nombre, int Municipio ,string Direccion, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using(cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewBodega";
                        cmd.Parameters.AddWithValue("@Nombre", SqlDbType.Char).Value = Nombre;
                        cmd.Parameters.AddWithValue("@Municipio", SqlDbType.Int).Value = Municipio;
                        cmd.Parameters.AddWithValue("@Direccion", SqlDbType.Char).Value = Direccion;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}