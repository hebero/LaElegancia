using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace EleganciaWebService
{
    public class ProductosDb
    {
        public DataSet Existencia(int Sku,string Conexion)
        {
            DataSet Listado = new DataSet("Existencia");
            DataTable ListadoTabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder comando = new StringBuilder();
            comando.Append("SELECT Sku, Sucursal, Articulo, Existencia, Disponible, Daniado FROM vExistenciaBodega ");
            comando.AppendFormat(" WHERE Sku = {0} ", Sku);
            try
            {
                using(cn = new SqlConnection(Conexion))
                {
                    using(cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = comando.ToString();
                        cn.Open();
                        ListadoTabla.Load(cmd.ExecuteReader());
                        cn.Close();
                        Listado.Tables.Add(ListadoTabla);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return Listado;
        }
        public DataSet ExistenciaNombre(string Nombre, string Conexion)
        {
            DataSet Listado = new DataSet("Existencia");
            DataTable ListadoTabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder comando = new StringBuilder();
            comando.Append("SELECT Sku, Sucursal, Articulo, Existencia, Disponible, Daniado FROM vExistenciaBodega ");
            comando.AppendFormat(" WHERE Articulo LIKE '{0}%' ", Nombre);
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = comando.ToString();
                        cn.Open();
                        ListadoTabla.Load(cmd.ExecuteReader());
                        cn.Close();
                        Listado.Tables.Add(ListadoTabla);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Listado;
        }
        public DataSet Sucursales(string Conexion)
        {
            DataSet Listado = new DataSet("Existencia");
            DataTable ListadoTabla = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder comando = new StringBuilder();
            comando.Append("SELECT vSucursales.Nombre, CONCAT(vSucursales.Departamento+ ', ', vSucursales.Municipio+', ', vSucursales.Direccion) AS Direccion FROM vSucursales");
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = comando.ToString();
                        cn.Open();
                        ListadoTabla.Load(cmd.ExecuteReader());
                        cn.Close();
                        Listado.Tables.Add(ListadoTabla);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Listado;
        }
    }
}