using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EleganciaWeb
{
    public class DireccionDb
    {
        public DataTable Departamentos(string Conexion)
        {
            DataTable Departamentos = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Departamento";
                        cmd.Connection = cn;
                        cn.Open();
                        Departamentos.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Departamentos;
        }

        public DataTable Municipios(int Departamento,string Conexion)
        {
            DataTable Municipios = new DataTable();
            SqlConnection cn; SqlCommand cmd;
            StringBuilder comando = new StringBuilder();
            comando.Append(" SELECT IdMunicipio, Municipio FROM vMunicipio  ");
            comando.AppendFormat(" WHERE IdDepartamento = {0}", Departamento);
            try
            {
                using (cn = new SqlConnection(Conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = comando.ToString();
                        cmd.Connection = cn;
                        cn.Open();
                        Municipios.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Municipios;
        }
    }
}