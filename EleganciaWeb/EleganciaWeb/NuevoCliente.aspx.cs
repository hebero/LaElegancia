using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EleganciaWeb
{
    public partial class NuevoCliente : System.Web.UI.Page
    {
        public void Mensaje(string Mensaje, string Nivel, string ErrorOpcional)
        {
            lblMensaje.Visible = true;
            lblMensaje.CssClass = "alert alert-" + Nivel;
            lblMensaje.Text = Mensaje + " " + ErrorOpcional;
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
            catch (Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
            }
        }
        public void AgregarMunicipio(int Departamento)
        {
            string Conexion = Properties.Settings.Default.Conexion;
            DireccionDb xDireccion = new DireccionDb();
            try
            {
                ddMunicipio.DataSource = xDireccion.Municipios(Departamento, Conexion);
                ddMunicipio.DataTextField = "Municipio";
                ddMunicipio.DataValueField = "IdMunicipio";
                ddMunicipio.DataBind();
            }
            catch (Exception ex)
            {
                Mensaje("Error: ", "danger", ex.Message);
                
            }

        }
        public void AgregarCliente()
        {
            string Nombre, NombreSeg, Apellido, ApellidoSeg, Direccion, Nit;
            string Conexion = Properties.Settings.Default.Conexion;
            int Municipio = 0;
            ClienteDb xCliente = new ClienteDb();
            try
            {
                Nit = txtNit.Text;
                Nombre = txtNombre.Text;
                NombreSeg = txtNombre2.Text;
                Apellido = txtApellido1.Text;
                ApellidoSeg = txtApellido2.Text;
                Direccion = txtDireccion.Text;
                Municipio = int.Parse(ddMunicipio.SelectedValue.ToString());
                xCliente.NuevoCliente(Nit, Nombre, NombreSeg, Apellido, ApellidoSeg, Direccion, Municipio, Conexion);
                Mensaje("Cliente añadido exitosamente", "success", "");
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
                Cargador();
                AgregarMunicipio(int.Parse(ddDepartamento.SelectedValue));
            }
        }

        protected void ddDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AgregarMunicipio(int.Parse(ddDepartamento.SelectedValue));
        }

        protected void ddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }
    }
}