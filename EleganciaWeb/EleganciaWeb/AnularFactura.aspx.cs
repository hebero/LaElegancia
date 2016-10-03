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
    public partial class AnularFactura : System.Web.UI.Page
    {
        public void LimpiarMensaje()
        {
            lblMensaje.CssClass = "";
            lblMensaje.Text = "";
            lblMensaje.Visible = false;
        }
        public void Limpiar()
        {
            lblFecha.Text = "--";
            lblNit.Text = "--";
            lblCliente.Text = "--";
            lblSucursal.Text = "--";
            lblEstado.Text = "--";
        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            LimpiarMensaje();
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
                    StringBuilder Cliente = new StringBuilder();
                    Cliente.AppendFormat(dt.Rows[0][1].ToString() + " ");
                    Cliente.AppendFormat(dt.Rows[0][7].ToString());
                    string Sucursal = dt.Rows[0][0].ToString();
                    string Nit = dt.Rows[0][2].ToString();
                    string Fecha = dt.Rows[0][5].ToString();
                    string Estado = dt.Rows[0][6].ToString();
                    lblSucursal.Text = Sucursal;
                    lblCliente.Text = Cliente.ToString();
                    lblFecha.Text = Fecha;
                    lblNit.Text = Nit;
                    switch (Estado)
                    {
                        case "C":
                            lblEstado.Text = "Cancelada";
                            break;
                        case "A":
                            lblEstado.Text = "Activa";
                            break;
                        case "N":
                            lblEstado.Text = "Anulada";
                            break;
                    }
                    Mensaje("Factura cargada.", "success", "");
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
                bool Completado = xAnular.AnularFacturas(Serie, Numero, Conexion);
                if (Completado == true)
                {
                    Mensaje("Factura fue anulada exitosamente.", "success", "");
                    btnPreAnular.Visible = false;
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