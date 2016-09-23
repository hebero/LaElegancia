using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class CancelarFactura : System.Web.UI.Page
    {
        public void Cargador()
        {
            FacturasDb Lista = new FacturasDb();
            string Conexion = Properties.Settings.Default.Conexion;
            ddSerie.DataSource = Lista.ListaSerie(Conexion);
            ddSerie.DataTextField = "Serie";
            ddSerie.DataValueField = "Serie";
            ddSerie.DataBind();
            ddSerie.Items.Insert(0, "Sleccione serie");
            
        }
        public void CargarEncabezado()
        {
            FacturasDb Encabezado = new FacturasDb();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string Conexion = Properties.Settings.Default.Conexion;
            try
            {
                string Serie = ddSerie.SelectedValue.ToString();
                int Numero = int.Parse(txtNumero.Text);
                dt = Encabezado.CargarEncabezado(Serie, Numero, Conexion);
                string nombre = dt.Rows[1][0].ToString();
                txtSurcursal.Text = nombre;
            }
            catch(Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.CssClass = "alert alert-warning";
                lblMensaje.Text = "Error: " + ex.Message;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargador();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEncabezado();
        }
    }
}