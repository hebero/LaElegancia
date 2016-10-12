using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EleganciaDesktop.EleganciaWebServices;

namespace EleganciaDesktop
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EleganciaDesktop.EleganciaWebServices.Productos xProducto = new Productos();
            DataSet Lista = new DataSet();
            Lista = xProducto.Existencia(int.Parse(textBox1.Text));
            dataGridView1.DataSource =Lista;
        }
    }
}
