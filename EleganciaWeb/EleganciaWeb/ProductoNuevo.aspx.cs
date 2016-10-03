using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class ProductoNuevo : System.Web.UI.Page
    {
        public void LimpiarMensaje()
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";
            lblMensaje.Visible = false;
        }
        public void Limpiar()
        {
            txtNombre.Text = "";
            txtSKU.Text = "";
        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            Limpiar();
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
        }
        public void CrearProducto()
        {
            ProductosClass xProducto = new ProductosClass();
            int SKU = 0; string Nombre; bool bSKU = false;
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;

            bSKU = int.TryParse(txtSKU.Text, out SKU);

            Nombre = txtNombre.Text;
            if (bSKU == true)
            {
                try
                {
                    xProducto.NuevoProducto(SKU, Nombre, Conexion);
                    Mensaje("Artículo agregado correctamente.", "success", "");
                }
                catch (Exception ex)
                {
                    Mensaje("Error: ", "danger", ex.Message);
                }
            }
            else
            {
                Mensaje("El SKU del producto debe ser númerico.", "success", "");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CrearProducto();
        }

    }
}