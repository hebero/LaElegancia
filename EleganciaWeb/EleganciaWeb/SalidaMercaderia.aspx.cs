using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class SalidaMercaderia : System.Web.UI.Page
    {
        public static class Valores
        {
            public static int IdBoleta
            {
                get;
                set;
            }
        }
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
                txtDate.Text = DateTime.Now.ToShortDateString();
                string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
                DropDownSucursal.DataSource = xSucursales.CargarLista(Conexion);
                DropDownSucursal.DataTextField = "Nombre";
                DropDownSucursal.DataValueField = "IdBodega";
                DropDownSucursal.DataBind();

                string UltimaBoleta = (xBoleta.UltimaBoelta() + 1).ToString();
                lblBoleta.Text = UltimaBoleta;
            }
            catch (Exception ex)
            {
                Mensaje("Error", "danger", ex.Message);
            }

        }
        public void AgregarBoleta()
        {
            string Descripcion = " ";
            Descripcion = txtDescripcion.Text;
            int Sucursal;
            DateTime Fecha = new DateTime();
            int NoBoleta = 0;
            BoletasDb xBoleta = new BoletasDb();
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
            try
            {
                Sucursal = int.Parse(DropDownSucursal.SelectedValue);
                Fecha = DateTime.Parse(txtDate.Text);

                NoBoleta = xBoleta.NuevoEncabezado(Sucursal, Fecha, Descripcion, Conexion);
                Valores.IdBoleta = NoBoleta;
                txtCantidad.Text = Valores.IdBoleta.ToString(); //quitar en produccion
            }
            catch (Exception ex)
            {
                Mensaje("Error", "danger", ex.Message);
            }
        }
        public void AgregarProducto()
        {
            BoletasDb xProducto = new BoletasDb();
            string Conexion = Properties.Settings.Default.Conexion;
            //Variables a convertir
            try
            {
                int Cantidad = 0; int Sku = 0;
                Cantidad = int.Parse(txtCantidad.Text);
                Sku = int.Parse(txtSku.Text);
                gvProductos.DataSource = xProducto.NuevaSalida(Valores.IdBoleta, Sku, Cantidad, Conexion);
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje("Error ", "danger", ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargador();
            }
        }

        protected void btnSucursal_Click(object sender, EventArgs e)
        {
            AgregarBoleta();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }
    }
}