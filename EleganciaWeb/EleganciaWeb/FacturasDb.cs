using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EleganciaWeb
{
    public class FacturasDb
    {
        public string UltimaSerie(string Conexion)
        {
            SqlConnection cn; SqlCommand cmd; string Serie = "";
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT TOP 1 Serie FROM Serie ORDER BY Serie DESC";
                        cmd.Connection = cn;
                        cn.Open();
                        Serie = cmd.ExecuteScalar().ToString();
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Serie;
        }
        public int UltimoNumero(string Serie, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd; int NumeroFactura = 0; string Numero;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT MAX(Numero) FROM NumeroFactura ");
            Comando.Append(" INNER JOIN Serie ON Serie.Serie ");
            Comando.AppendFormat(" = '{0}'", Serie);

            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        Numero = cmd.ExecuteScalar().ToString();
                        cn.Close();
                        NumeroFactura = int.Parse(Numero);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NumeroFactura;
        }
        public int  NuevoEncabezado(int Cliente, int Bodega, DateTime Fecha, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd; int IdFactura=0; SqlParameter NoFactura;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewFacturaEncabezado";
                        cmd.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = Cliente;
                        cmd.Parameters.AddWithValue("@IdBodega", SqlDbType.Int).Value = Bodega;
                        cmd.Parameters.AddWithValue("@FechaEncabezado", SqlDbType.DateTime).Value = Fecha;
                        NoFactura = cmd.Parameters.Add("IdFactura", SqlDbType.Int);
                        NoFactura.Direction = ParameterDirection.ReturnValue;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        IdFactura = (int)NoFactura.Value;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return IdFactura;
        }
        //public DataTable 
    }
}