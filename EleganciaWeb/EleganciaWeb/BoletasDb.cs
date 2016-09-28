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
                        cmd.CommandText = "SELECT ISNULL(MAX(IdBoleta),0) FROM Boleta";
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
            catch(SqlException ex)
            {
                throw ex;
            }
            return IdBoleta;
        }
        public DataTable NuevoDetalle(int Boleta, int Producto, int Cantidad,int Daniado, decimal Precio, DateTime Fecha, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd, cmd2;
            DataTable dt = new DataTable();
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paDetalleBoleta";
                        cmd.Parameters.AddWithValue("@IdBoleta", SqlDbType.Int).Value = Boleta;
                        cmd.Parameters.AddWithValue("@Sku", SqlDbType.Int).Value = Producto;
                        cmd.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = Cantidad;
                        cmd.Parameters.AddWithValue("@Daniado", SqlDbType.Int).Value = Daniado;
                        cmd.Parameters.AddWithValue("@FechaVencimiento", SqlDbType.DateTime).Value = Fecha;
                        cmd.Parameters.AddWithValue("@PrecioRef", SqlDbType.Decimal).Value = Precio;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        using (cmd2 = cn.CreateCommand())
                        {
                            cmd2.CommandType = CommandType.Text;
                            string comando = "SELECT Producto, Cantidad, Dañado, Precio, [Fecha de Vencimiento] FROM vDetalleBoleta WHERE IdBoleta =  " + Boleta;
                            cmd2.CommandText = comando;
                            cn.Open();
                            dt.Load(cmd2.ExecuteReader());
                            cn.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return dt;
        }
    }

}