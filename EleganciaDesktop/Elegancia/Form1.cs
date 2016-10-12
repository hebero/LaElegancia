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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bSku = false;
            int sku = 0;
            bSku = int.TryParse(textBox1.Text, out sku);
            if (bSku == false)
            {
                MessageBox.Show("El sku es numérico.", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    EleganciaWebService.Productos xListado = new EleganciaWebService.Productos();
                    dataGridView1.DataSource = xListado.Existencia(int.Parse(textBox1.Text)).Tables[0];
                }
                catch(Exception  ex)
                {
                    MessageBox.Show("Error: "+ ex.Message, "Alerta", MessageBoxButtons.OK);
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EleganciaWebService.Productos Test = new EleganciaWebService.Productos();
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
            catch(Exception ex)
            {
                lblTest.Text = "Error: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
