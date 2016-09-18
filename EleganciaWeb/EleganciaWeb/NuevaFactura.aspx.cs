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
        public static int IdCliente
        {
            get;
            set;
        }
        public static int IdFactura
        {
            get;
            set;
        }
    }

    public partial class NuevaFactura : System.Web.UI.Page
    {
        public void AgregarCliente()
        {
            int NoCliente = 0;
            string Nit, Nombre;
            try
            {
                string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
                ClienteDb xCliente = new ClienteDb();
                Nit = txtNit.Text;
                Nombre = txtNombreCliente.Text;
                NoCliente = xCliente.NuevoCliente(Nit, Nombre, Conexion);
                Valores.IdCliente = NoCliente;
                txtSku.Text = Valores.IdCliente.ToString();
            }
            catch(Exception ex)
            {
                lblAlerta.Visible = true;
                lblAlerta.CssClass = "alert alert-danger";
                lblAlerta.Text = "Error:" + ex.Message;     //borrar en produccion
            }
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
                lblAlerta.Visible = true;
                lblAlerta.CssClass = "alert alert-danger";
                lblAlerta.Text = "Error:" + ex.Message;       //borrar en produccion
            }


        }
        public void AgregarEncabezado()
        {
            int Sucursal;
            DateTime Fecha = new DateTime();
            int NoFactura = 0;
            FacturasDb xFactura = new FacturasDb();
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;
            try
            {
                if(Valores.IdCliente == 0)
                {
                    lblAlerta.Visible = true;
                    lblAlerta.CssClass = "alert alert-danger";
                    lblAlerta.Text = "Datos incompletos 1";
                }
                else
                {
                    
                    Sucursal = int.Parse(DropDownSucursal.SelectedValue);
                    Fecha = DateTime.Parse(txtDate.Text);

                    NoFactura = xFactura.NuevoEncabezado(Valores.IdCliente, Sucursal,Fecha, Conexion);
                    Valores.IdFactura = NoFactura;
                    txtCantidad.Text = Valores.IdFactura.ToString();
                }
            }
            catch(Exception ex)
            {
                lblAlerta.Visible = true;
                lblAlerta.CssClass = "alert alert-danger";
                lblAlerta.Text = "Error:" + ex.Message;
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
            AgregarCliente();
        }

        protected void btnSucursal_Click(object sender, EventArgs e)
        {
            AgregarEncabezado();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        protected void txtSku_TextChanged(object sender, EventArgs e)
        {

        }
    }


}