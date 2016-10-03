using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EleganciaWeb
{
    public class Reportes
    {
        public DataTable EntradaMercaderia(int Sucursal, string FechaInicial, string FechaFinal, string Conexion)
        {
            DataTable Tabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder Comando = new StringBuilder();
            Comando.Append(" SELECT * FROM vBoletasEntrada  ");
            Comando.AppendFormat(" Where IdBodega = {0} AND  ", Sucursal);
            Comando.Append(" FechaBoleta BETWEEN ");
            Comando.AppendFormat(" (CAST('{0}' AS DATE)) AND ", FechaInicial);
            Comando.AppendFormat(" (CAST('{0}' AS DATE)) ", FechaFinal);
            try
            {
                using(cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        Tabla.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return Tabla;
        }
        //Métodos sobrecargados
        public DataTable BoletasDetalle(char Tipo, string Conexion)
        {
            DataTable Tabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT * FROM vBoletasDetalle ");
            Comando.AppendFormat(" WHERE vBoletasDetalle.TipoBoleta = '{0}' ", Tipo);
            using(cn = new SqlConnection(Conexion))
            {
                using(cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = Comando.ToString();
                    cn.Open();
                    Tabla.Load(cmd.ExecuteReader());
                    cn.Close();

                }
            }
            return Tabla;
        }
        public DataTable BoletasDetalle(int Numero, string Conexion)
        {
            DataTable Tabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT * FROM vBoletasDetalle ");
            Comando.AppendFormat(" WHERE vBoletasDetalle.IdBoleta = {0} ", Numero);
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        Tabla.Load(cmd.ExecuteReader());
                        cn.Close();

                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return Tabla;
        }
        public DataTable Factura(string Serie, int Numero, string Conexion)
        {
            DataTable Factura = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT * FROM vFacturaDetalle ");
            Comando.AppendFormat(" WHERE vFacturaDetalle.Serie = '{0}' ", Serie);
            Comando.AppendFormat(" AND vFacturaDetalle.Numero = {0} ", Numero);
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        Factura.Load(cmd.ExecuteReader());
                        cn.Close();

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Factura;
        }
    }

}