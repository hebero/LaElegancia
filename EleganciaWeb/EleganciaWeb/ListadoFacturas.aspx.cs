using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class ListadoFacturas : System.Web.UI.Page
    {
        public void Limpiar()
        {
            lblMensaje.CssClass = "";
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
            FacturasDb Lista = new FacturasDb();
            string Conexion = Properties.Settings.Default.Conexion;
            ddSerie.DataSource = Lista.ListaSerie(Conexion);
            ddSerie.DataTextField = "Serie";
            ddSerie.DataValueField = "Serie";
            ddSerie.DataBind();
            ddSerie.Items.Insert(0, "Sleccione serie");

        }
        public void CrearFactura()
        {

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
            CrearFactura();
        }
    }
}