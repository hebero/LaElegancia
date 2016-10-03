using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


namespace EleganciaWeb
{
    public static class Valores
    {
        public static int IdFactura
        {
            get;
            set;
        }
    }

    public partial class NuevaFactura : System.Web.UI.Page
    {
        public void LimpiarMensaje()
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";
            lblMensaje.Visible = false;
        }
        public void Limpiar()
        {
            txtSku.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            LimpiarMensaje();
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
        }
        public void CargarDatos()
        {
            SucursalesDb xSucursales = new SucursalesDb();
            FacturasDb xFactura = new FacturasDb();
            DataTable dt = new DataTable();
            try
            {
                txtDate.Text = DateTime.Now.ToShortDateString();

                string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
                dt = xSucursales.CargarLista(Conexion);
                DropDownSucursal.DataSource = dt;
                DropDownSucursal.DataTextField = "Nombre";
                DropDownSucursal.DataValueField = "IdBodega";
                DropDownSucursal.DataBind();

                string SerieFactura = xFactura.UltimaSerie(Conexion);
                int NumeroFactura = (xFactura.UltimoNumero("B", Conexion)) + 1;
                lblNoFactura.Text = SerieFactura + "-" + NumeroFactura;
            }
            catch (Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }


        }
        public void AgregarEncabezado()
        {
            string Nit;

            int Sucursal;
            DateTime Fecha = new DateTime();
            int NoFactura = 0;
            FacturasDb xFactura = new FacturasDb();
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
            try
            {
                Nit = txtNit.Text;
                Sucursal = int.Parse(DropDownSucursal.SelectedValue);
                Fecha = DateTime.Parse(txtDate.Text);

                NoFactura = xFactura.NuevoEncabezado(Nit, Sucursal,Fecha, Conexion);
                Valores.IdFactura = NoFactura;
            }
            catch(Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }
        }

        public void AgregarProducto()
        {
            //Instancias nuevas
            FacturasDb xFactura = new FacturasDb();
            //Conexion
            string Conexion = Properties.Settings.Default.Conexion;
            //Variables a convertir
            decimal Precio = 0; int Cantidad = 0; int Sku = 0;

            try
            {
                Precio = decimal.Parse(txtPrecio.Text);
                Cantidad = int.Parse(txtCantidad.Text);
                Sku = int.Parse(txtSku.Text);
                gvProductos.DataSource = xFactura.NuevoDetalle(Valores.IdFactura, Sku, Cantidad, Precio, Conexion);
                gvProductos.DataBind();
                //Limpiar();
            }
            catch(Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatos();
            }
            
        }

        protected void btnCliente_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSucursal_Click(object sender, EventArgs e)
        {
            AgregarEncabezado();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        protected void txtSku_TextChanged(object sender, EventArgs e)
        {

        }
    }


}