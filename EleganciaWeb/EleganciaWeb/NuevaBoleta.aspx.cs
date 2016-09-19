using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class NuevaBoleta : System.Web.UI.Page
    {
        public static class Valores
        {
            public static int IdBoleta
            {
                get;
                set;
            }
            public static int IdProducto
            {
                get;
                set;
            }

        }
        public void CargarDatos()
        {
            SucursalesDb CargarSucursales = new SucursalesDb();
            BoletasDb xBoleta = new BoletasDb();
            string Conexion = Properties.Settings.Default.Conexion;
            txtDate.Text = DateTime.Now.ToShortDateString();
            try
            {
                lblBoleta.Text = "Boleta número: " + xBoleta.UltimaBoelta();

                ddSucursal.DataSource = CargarSucursales.CargarLista(Conexion);
                ddSucursal.DataTextField = "Nombre";
                ddSucursal.DataValueField = "IdBodega";
                ddSucursal.DataBind();
            }
            catch(Exception ex)
            {
                lblAlert.Visible = true;
                lblAlert.CssClass = "alert alert-danger";
                lblAlert.Text = "Error :" + ex.Message;   
            }

        }

        public void NuevoEncabezado()
        {
            int Sucursal = 0;
            DateTime Fecha = new DateTime();
            int NoBoleta = 0;
            string Descripcion = "", Conexion = Properties.Settings.Default.Conexion;
            //Instanciando
            BoletasDb xBoleta = new BoletasDb();
            try
            {
                //Dando valores a variables
                Sucursal = int.Parse(ddSucursal.SelectedValue);
                Fecha = DateTime.Parse(txtDate.Text);
                Descripcion = txtDescripcion.Text;

                NoBoleta = xBoleta.NuevoEncabezado(Sucursal, Fecha, Descripcion, Conexion);
                Valores.IdBoleta = NoBoleta;
            }
            catch(Exception ex)
            {
                lblAlert.Visible = true;
                lblAlert.CssClass = "alert alert-danger";
                lblAlert.Text = "Error :" + ex.Message;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatos();
            }
        }

        protected void btnCrearBoleta_Click(object sender, EventArgs e)
        {
            NuevoEncabezado();
        }
    }
}