using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Web.Configuration;

namespace EleganciaWebService
{
    /// <summary>
    /// Descripción breve de Productos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Productos : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public DataSet Existencia(int Sku)
        {
            string Conexion = Properties.Settings.Default.Conexion;
            ProductosDb xListado = new ProductosDb();
            DataSet Listado = new DataSet();
            try
            {
                Listado = xListado.Existencia(Sku, Conexion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Listado;
        }
    }
}
