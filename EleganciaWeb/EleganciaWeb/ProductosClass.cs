using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Text;

namespace EleganciaWeb
{
    public class ProductosClass
    {
        public void NuevoProducto(int Sku, string Nombre, string SqlConexion)
        {
            //StringBuilder Command = new StringBuilder();
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(SqlConexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewProducto";
                        cmd.Parameters.AddWithValue("@SKU", SqlDbType.Int).Value = Sku;
                        cmd.Parameters.AddWithValue("@Nombre", SqlDbType.Int).Value = Nombre;
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
        public void EditProducto(int IdProducto,int Sku, string Nombre, string SqlConexion)
        {
            //StringBuilder Command = new StringBuilder();
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(SqlConexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paEditProducto";
                        cmd.Parameters.AddWithValue("@IdProducto", SqlDbType.Int).Value = IdProducto;
                        cmd.Parameters.AddWithValue("@SKU", SqlDbType.Int).Value = Sku;
                        cmd.Parameters.AddWithValue("@Nombre", SqlDbType.Int).Value = Nombre;
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