using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class NuevaMercaderia : System.Web.UI.Page
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
                txtVencimiento.Text = DateTime.Now.ToShortDateString();
                string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
                DropDownSucursal.DataSource = xSucursales.CargarLista(Conexion);
                DropDownSucursal.DataTextField = "Nombre";
                DropDownSucursal.DataValueField = "IdBodega";
                DropDownSucursal.DataBind();

                string UltimaBoleta = (xBoleta.UltimaBoelta()+1).ToString();
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
            DateTime Fecha = new DateTime();
            string Conexion = Properties.Settings.Default.Conexion;
            //Variables a convertir
            try
            {
                decimal Precio = 0; int Cantidad = 0; int Sku = 0; int Daniado = 0;
                Precio = decimal.Parse(txtPrecio.Text);
                Cantidad = int.Parse(txtCantidad.Text);
                Sku = int.Parse(txtSku.Text);
                Daniado = int.Parse(txtDaniado.Text);
                Fecha = DateTime.Parse(txtVencimiento.Text);
                gvProductos.DataSource = xProducto.NuevoDetalle(Valores.IdBoleta, Sku, Cantidad, Daniado, Precio, Fecha, Conexion);
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