using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EleganciaWeb
{
    public class BoletasDb
    {
        public int UltimaBoelta()
        {
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
            int IdBoleta = 0;
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT MAX(Idboleta) FROM Boleta";
                        cn.Open();
                        IdBoleta = int.Parse(cmd.ExecuteScalar().ToString());
                        cn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return IdBoleta;
        }
        public int NuevoEncabezado(int Bodega, DateTime Fecha, string Descripcion, string Conexion)
        {
            int IdBoleta = 0;
            SqlConnection cn; SqlCommand cmd;
            SqlParameter Boleta;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewEncabezadoBoleta";
                        cmd.Parameters.AddWithValue("@IdBodega", SqlDbType.Int).Value = Bodega;
                        cmd.Parameters.AddWithValue("@FechaBoleta", SqlDbType.DateTime).Value = Fecha;
                        cmd.Parameters.AddWithValue("@TipoBoleta", SqlDbType.Char).Value = 'E';
                        cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.VarChar).Value = Descripcion;
                        Boleta = new SqlParameter();
                        Boleta = cmd.Parameters.Add("@IdBoleta", SqlDbType.Int);
                        Boleta.Direction = ParameterDirection.ReturnValue;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        IdBoleta = (int)Boleta.Value;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IdBoleta;
        }
    }
}