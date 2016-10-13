using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elegancia
{
    public partial class ExistenciaNombre : Form
    {
        public ExistenciaNombre()
        {
            InitializeComponent();
        }

        private void lblArticulo_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            if  (Nombre == null)
            {
                MessageBox.Show("El sku es numérico.", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    EleganciaService.Productos xListado = new EleganciaService.Productos();
                    dataGridView1.DataSource = xListado.ExistenciaNombre(textBox1.Text).Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Alerta", MessageBoxButtons.OK);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EleganciaService.Productos Test = new EleganciaService.Productos();
            try
            {
                string test = Test.HelloWorld();
                if (test != null)
                {
                    lblTest.Text = "Conexión correcta.";
                }
                else
                {
                    lblTest.Text = "Conexión no disponible.";
                }
            }
            catch (Exception ex)
            {
                lblTest.Text = "Error: " + ex.Message;
            }
        }
    }
}
