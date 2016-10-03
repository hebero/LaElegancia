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
        public void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
        }
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            Limpiar();
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
        }
        public void AgregarSucursal()
        {

            SucursalesDb xSucursal = new SucursalesDb();
            string Conexion = Properties.Settings.Default.Conexion;
            string Nombre, Direccion;
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    Mensaje("Los campos Nombre y Dirección, no pueden ir en blanco.", "danger", "");
                }
                else
                {
                    Nombre = txtNombre.Text;
                    Direccion = txtDireccion.Text;
                    int Municipio = int.Parse(ddMunicipio.SelectedValue.ToString());
                    xSucursal.NuevaSucursal(Nombre, Municipio, Direccion, Conexion);
                    Mensaje("Sucursal agregada correctamente.", "success", "");
                }

            }
            catch(Exception ex)
            {
                Mensaje("Error:", "danger", ex.Message);
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
                Mensaje("Error:", "danger", ex.Message);
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
                Mensaje("Error:", "danger", ex.Message);
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