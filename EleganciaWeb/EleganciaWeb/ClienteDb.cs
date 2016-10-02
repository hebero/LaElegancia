using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EleganciaWeb
{
    public class ClienteDb
    {
        public void NuevoCliente(string Nit, string Nombre, string NombreSeg, string ApellidoPrim, string ApellidoSeg, string Direccion, int Municipio, string SqlConexion)
        {
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(SqlConexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewCliente";
                        cmd.Parameters.AddWithValue("@Nit", SqlDbType.VarChar).Value = Nit;
                        cmd.Parameters.AddWithValue("@Nombre", SqlDbType.VarChar).Value = Nombre;
                        cmd.Parameters.AddWithValue("@NombreSeg", SqlDbType.VarChar).Value = NombreSeg;
                        cmd.Parameters.AddWithValue("@ApellidoPrim", SqlDbType.VarChar).Value = ApellidoPrim;
                        cmd.Parameters.AddWithValue("@ApellidoSeg", SqlDbType.VarChar).Value = ApellidoSeg;
                        cmd.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Direccion;
                        cmd.Parameters.AddWithValue("@Municipio", SqlDbType.Int).Value = Municipio;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return;
        }
    }
}
