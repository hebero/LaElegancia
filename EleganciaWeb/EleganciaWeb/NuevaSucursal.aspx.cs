using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class NuevaSucursal : System.Web.UI.Page
    {
        public void AgregarSucursal()
        {
            SucursalesDb xSucursal = new SucursalesDb();
            string Conexion = Properties.Settings.Default.Conexion;
            try
            {
                xSucursal.NuevaSucursal(txtNombre.Text, txtDireccion.Text, Conexion);
                lblAlert.Visible = true;
                lblAlert.CssClass = "alert alert-success";
                lblAlert.Text = "Sucursal agregada correctamente.";
                txtNombre.Text = "";
                txtDireccion.Text = "";
            }
            catch(Exception ex)
            {
                lblAlert.Visible = true;
                lblAlert.CssClass = "alert alert-danger";
                lblAlert.Text = "Error: " + ex.Message;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarSucursal();
        }
    }
}