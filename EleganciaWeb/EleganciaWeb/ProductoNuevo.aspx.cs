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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = "asdfasjfkñaslf";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductosClass xProducto = new ProductosClass();
            int SKU = 0; string Nombre; bool bSKU = false;
            string Conexion = EleganciaWeb.Properties.Settings.Default.Conexion;

            bSKU = int.TryParse(txtSKU.Text, out SKU);

            Nombre = txtNombre.Text;
            if(bSKU == true)
            {
                try
                {
                    xProducto.NuevoProducto(SKU, Nombre, Conexion);
                }
                catch(Exception ex)
                {
                    lblAlerta.Visible = true;
                    lblAlerta.CssClass = "alert alert-warning";
                    lblAlerta.Text = "La acción se ha realizado correctamente." + ex.Message;
                }
            }
            else
            {
                lblAlerta.Visible = true;
                lblAlerta.CssClass = "alert alert-danger";
                lblAlerta.Text = "El SKU del producto debe ser númerico.";
            }
        }

        //protected void chkEditar_CheckedChanged(object sender, EventArgs e)
        //{
            
        //}
    }
}