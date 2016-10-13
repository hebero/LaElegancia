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
    public partial class Sucursales : Form
    {
        public Sucursales()
        {
            InitializeComponent();
        }

        private void Sucursales_Load(object sender, EventArgs e)
        {
            try
            {
                EleganciaService.Productos Listado = new EleganciaService.Productos();
                dataGridView1.DataSource = Listado.Sucursales().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                EleganciaService.Productos Listado = new EleganciaService.Productos();
                dataGridView1.DataSource = Listado.Sucursales().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void button2_Click(object sender, EventArgs e)
        {
            EleganciaService.Productos Test = new EleganciaService.Productos();
            try
            {
                string test = Test.HelloWorld();
                if (test != null)
                {
                    MessageBox.Show("Conexión correcta.", "Conexión", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Conexión no disponible.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
