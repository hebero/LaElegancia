using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class ReporteBoletas : System.Web.UI.Page
    {
        public void Limpiar()
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";
            lblMensaje.Visible = false;

        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            Limpiar();
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
        }
        public void CargarReporte() 
        {
            Reportes xReporte = new Reportes();
            ReportDataSource rds = new ReportDataSource();
            string Conexion = Properties.Settings.Default.Conexion;
            int Numero=0;
            try
            {
                
               
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rpEntradasYSalidasMercaderia.rdlc");
                rds.Name = "DataSetEntradasYSalidasMercaderia";
                if (chkOpcion.Checked)
                {
                    rds.Value = xReporte.BoletasDetalle(Char.Parse(ddTipoBoleta.SelectedValue.ToString()), Conexion);
                }
                else
                {
                    Numero = int.Parse(txtNumero.Text);
                    rds.Value = xReporte.BoletasDetalle(Numero, Conexion);
                }

                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.ShowRefreshButton = true;
                Mensaje("Reporte generado correctamente", "success", "");
            }
            catch (Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
            
        }

        protected void chkOpcion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOpcion.Checked)
            {
                ddTipoBoleta.Enabled = true;
                txtNumero.Enabled = false;
            }
            else
            {
                ddTipoBoleta.Enabled = false;
                txtNumero.Enabled = true;
            }
        }
    }
}