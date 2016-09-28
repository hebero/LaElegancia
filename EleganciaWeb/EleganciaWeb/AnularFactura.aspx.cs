using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EleganciaWeb
{
    public partial class AnularFactura : System.Web.UI.Page
    {
        public void Limpiar()
        {
            lblFecha.Text = "--";
            lblNit.Text = "--";
            lblCliente.Text = "--";
            lblSucursal.Text = "--";
            lblMensaje.Visible = false;

        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
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
        public void CargarEncabezado()
        {
            FacturasDb Encabezado = new FacturasDb();
            DataTable dt = new DataTable();
            string Conexion = Properties.Settings.Default.Conexion;
            try
            {
                string Serie = ddSerie.SelectedValue.ToString();
                int Numero = int.Parse(txtNumero.Text);
                dt.Merge(Encabezado.CargarEncabezado(Serie, Numero, Conexion));
                Limpiar();
                if (dt.Rows.Count > 0)
                {
                    string Sucursal = dt.Rows[0][0].ToString();
                    string Cliente = dt.Rows[0][1].ToString();
                    string Nit = dt.Rows[0][2].ToString();
                    string Fecha = dt.Rows[0][5].ToString();
                    lblSucursal.Text = Sucursal;
                    lblCliente.Text = Cliente;
                    lblFecha.Text = Fecha;
                    lblNit.Text = Nit;
                    btnPreAnular.Visible = true;
                }
                else
                {
                    Mensaje("No existe la factura seleccionada. ", "warning", " ");
                }
            }
            catch (Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }

        }
        public void AnularFac()
        {
            FacturasDb xAnular = new FacturasDb();
            string Conexion = Properties.Settings.Default.Conexion;
            try
            {
                string Serie = (ddSerie.SelectedValue.ToString());
                int Numero = int.Parse(txtNumero.Text);
                bool Completado = xAnular.CancelarFacturas(Serie, Numero, Conexion);
                if (Completado == true)
                {
                    Mensaje("Factura fue anulada exitosamente.", "success", "");
                }
                else
                {
                    Mensaje("La factura no se ha podido anular.", "danger", "");
                }
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
                Cargador();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEncabezado();
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            AnularFac();
        }
    }
}