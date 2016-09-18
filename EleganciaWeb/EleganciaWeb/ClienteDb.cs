using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EleganciaWeb
{
    public class ClienteDb
    {
        public int NuevoCliente(string Nit, string Nombre, string SqlConexion)
        {
            int IdCliente = 0;
            SqlConnection cn; SqlCommand cmd; SqlParameter ClienteId;
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
                        ClienteId = cmd.Parameters.Add("IdCliente", SqlDbType.Int);
                        ClienteId.Direction = ParameterDirection.ReturnValue;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        IdCliente = (int)ClienteId.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IdCliente;
        }
    }
}
