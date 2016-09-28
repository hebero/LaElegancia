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
                    lblAlerta.Visible = true;
                    lblAlerta.CssClass = "alert alert-success";
                    lblAlerta.Text = "Se ha realizado la tarea correctamente.";
                }
                catch (Exception ex)
                {
                    lblAlerta.Visible = true;
                    lblAlerta.CssClass = "alert alert-warning";
                    lblAlerta.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblAlerta.Visible = true;
                lblAlerta.CssClass = "alert alert-danger";
                lblAlerta.Text = "El SKU del producto debe ser númerico.";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //Label1.Text = "asdfasjfkñaslf";
        //}

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{

        //}

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CrearProducto();
        }

        //protected void chkEditar_CheckedChanged(object sender, EventArgs e)
        //{

        //}
    }
}