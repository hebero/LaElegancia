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
                        cmd.CommandText = "SELECT TOP 1 Serie FROM FacSerieNumero ORDER BY Serie DESC";
                        cmd.Connection = cn;
                        cn.Open();
                        Serie = cmd.ExecuteScalar().ToString();
                        cn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Serie;
        }
        public int UltimoNumero(string Serie, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd; int NumeroFactura = 0; string Numero;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT MAX(Numero) FROM FacSerieNumero ");
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
            catch (SqlException ex)
            {
                throw ex;
            }
            return NumeroFactura;
        }
        public int  NuevoEncabezado(string Nit, int Bodega, DateTime Fecha, string Conexion)
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
                        cmd.Parameters.AddWithValue("@Nit", SqlDbType.VarChar).Value = Nit;
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
            catch(SqlException ex)
            {
                throw ex;
            }
            return IdFactura;
        }
        public DataTable NuevoDetalle(int Factura, int Producto, int Cantidad, decimal Precio, string Conexion)
        {
            SqlConnection cn; SqlCommand cmd, cmd2;
            DataTable dt = new DataTable();
            try
            {
                using(cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paNewFacturaDetalle";
                        cmd.Parameters.AddWithValue("@IdFactura", SqlDbType.Int).Value = Factura;
                        cmd.Parameters.AddWithValue("@Sku", SqlDbType.Int).Value = Producto;
                        cmd.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = Cantidad;
                        cmd.Parameters.AddWithValue("@Precio", SqlDbType.Int).Value = Precio;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        using(cmd2 = cn.CreateCommand())
                        {
                            cmd2.CommandType = CommandType.Text;
                            string comando = "SELECT Nombre, Cantidad, Precio FROM vDetalleFactura WHERE IdFactura = " + Factura;
                            cmd2.CommandText = comando;
                            cn.Open();
                            dt.Load(cmd2.ExecuteReader());
                            cn.Close();
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }

            return dt;
        }
        public DataTable ListaSerie(string Conexion)
        {
            DataTable Lista = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT Serie FROM FacSerieNumero";
                        cn.Open();
                        Lista.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Lista;
        }
        public DataTable CargarEncabezado(string Serie, int Numero, string Conexion)
        {
            DataTable Encabezado = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder Comando = new StringBuilder();
            Comando.Append(" SELECT * FROM vEncabezadoFactura ");
            Comando.AppendFormat(" WHERE Estado = 'A' AND Serie = '{0}' ", Serie);
            Comando.AppendFormat(" AND Numero = {0} ", Numero);


            try
            {
                using(cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        Encabezado.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return Encabezado;
        }
        public bool CancelarFacturas(string Serie, int Numero, string Conexion)
        {
            bool Completado = false;
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paFacturaCancelada";
                        cmd.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = Serie;
                        cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = Numero;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        Completado = true;
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return Completado;
        }
        public bool AnularFacturas(string Serie, int Numero, string Conexion)
        {
            bool Completado = false;
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "paFacturaAnulada";
                        cmd.Parameters.AddWithValue("@Serie", SqlDbType.VarChar).Value = Serie;
                        cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = Numero;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        Completado = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Completado;
        }
    }

}