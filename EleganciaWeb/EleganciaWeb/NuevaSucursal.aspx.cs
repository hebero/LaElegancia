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
            int Municipio = int.Parse(ddMunicipio.SelectedValue.ToString());
            try
            {

                xSucursal.NuevaSucursal(txtNombre.Text, Municipio, txtDireccion.Text, Conexion);
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
        public void Cargador()
        {
            string Conexion = Properties.Settings.Default.Conexion;
            DireccionDb xDireccion = new DireccionDb();
            try
            {
                ddDepartamento.DataSource = xDireccion.Departamentos(Conexion);
                ddDepartamento.DataTextField = "Departamento";
                ddDepartamento.DataValueField = "IdDepartamento";
                ddDepartamento.DataBind();
            }
            catch(Exception ex)
            {
                lblAlert.Text = ex.Message;
            }
        }

        public void AgregarMunicipio(int Departamento)
        {
            string Conexion = Properties.Settings.Default.Conexion;
            DireccionDb xDireccion = new DireccionDb();
            try
            {
                ddMunicipio.DataSource = xDireccion.Municipios(Departamento,Conexion);
                ddMunicipio.DataTextField = "Municipio";
                ddMunicipio.DataValueField = "IdMunicipio";
                ddMunicipio.DataBind();
            }
            catch (Exception ex)
            {
                lblAlert.Text = ex.Message;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargador();
                AgregarMunicipio(int.Parse(ddDepartamento.SelectedValue));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarSucursal();
        }

        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AgregarMunicipio(int.Parse(ddDepartamento.SelectedValue));
        }
    }
}