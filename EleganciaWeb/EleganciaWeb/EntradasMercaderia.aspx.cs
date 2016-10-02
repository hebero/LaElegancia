using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class EntradasMercaderia : System.Web.UI.Page
    {
        public void Limpiar()
        {
            lblMensaje.Text = "";
            lblMensaje.Visible = false;

        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            Limpiar();
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
        }
        public void Cargador()
        {
            SucursalesDb Lista = new SucursalesDb();
            CultureInfo Provider = CultureInfo.InvariantCulture;
            try
            {
                //string FechaInit, FechaFin;
                //FechaInit = DateTime.Now.AddDays(-31).ToUniversalTime().ToString("yyyy-mm-dd");
                //txtFechaIni.Text = FechaInit; 
                /*DateTime.ParseExact(FechaInit, "0:dd-MM-yyyy",Provider).ToString();*/
                txtFechaIni.Text = DateTime.Now.AddDays(-31).ToShortDateString();
                txtFechaFin.Text = DateTime.Now.ToShortDateString();
                string Conexion = Properties.Settings.Default.Conexion;
                ddSucursales.DataSource = Lista.CargarLista(Conexion);
                ddSucursales.DataTextField = "Nombre";
                ddSucursales.DataValueField = "IdBodega";
                ddSucursales.DataBind();
            }
            catch(Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }

        }
        public void Reporte()
        {
            Reportes xReporte = new Reportes();
            //Parametros indicados
            string Conexion = Properties.Settings.Default.Conexion;
            string FechaInicial, FechaFinal;
            int Sucursal;
            //Sucursal Seleccionada
            Sucursal = int.Parse(ddSucursales.SelectedValue);
            //Convertir las entradas a un formato de tiempo reconocible para SQL Sever
            FechaInicial = DateTime.Parse(txtFechaIni.Text).ToString("u");
            FechaFinal = DateTime.Parse(txtFechaFin.Text).ToString("u");
            //Creacion del reporte
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReporteEntradas.rdlc");
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetReporteEntradas";
            rds.Value = xReporte.EntradaMercaderia(Sucursal, FechaInicial, FechaFinal, Conexion);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.ShowRefreshButton = true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargador();
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