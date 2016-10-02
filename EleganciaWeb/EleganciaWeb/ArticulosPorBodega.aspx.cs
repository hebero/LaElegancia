using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Reporting.WebForms;

namespace EleganciaWeb
{
    public partial class ArticulosPorBodega : System.Web.UI.Page
    {
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + ": " + ErrorOpcional;
        }
        public void Cargador()
        {
            SucursalesDb xSucursales = new SucursalesDb();
            BoletasDb xBoleta = new BoletasDb();
            try
            {
                string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
                ddSucursales.DataSource = xSucursales.CargarLista(Conexion);
                ddSucursales.DataTextField = "Nombre";
                ddSucursales.DataValueField = "IdBodega";
                ddSucursales.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje("Error", "danger", ex.Message);
            }

        }
        private DataTable Datos(int Bodega)
        {
            DataTable TablaRpt;
            SqlConnection cn; SqlCommand cmd;
            string conexion = Properties.Settings.Default.Conexion;
            StringBuilder Comando = new StringBuilder();
            Comando.Append("SELECT p.Sku, p.Nombre, i.Disponible, i.Daniado, i.PrecioVenta, b.Nombre AS Bodega FROM Inventario i, Bodega b, Producto p ");
            Comando.Append(" WHERE b.IdBodega = i.IdBodega AND p.IdProducto = i.IdProducto ");
            Comando.AppendFormat(" AND b.IdBodega = {0} ", Bodega);
            TablaRpt = new DataTable();
            try
            {
                using (cn = new SqlConnection(conexion))
                {
                    using (cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = Comando.ToString();
                        cn.Open();
                        TablaRpt.Load(cmd.ExecuteReader());
                        cn.Close();
                    }
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            return TablaRpt;
        }
        public void Reporte()
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteExistenciaSucursal.rdlc");
            DataTable td = new DataTable();
            ReportDataSource rds = new ReportDataSource();
            td = Datos(int.Parse(ddSucursales.SelectedValue.ToString()));
            rds.Name = "DataSetExistenciaSucursal";
            rds.Value = td;
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.ShowRefreshButton = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargador();
                Reporte();
            }

        }

        protected void ddSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Reporte();
        }
    }
}