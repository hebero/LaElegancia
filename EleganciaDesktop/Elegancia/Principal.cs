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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void existenciaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void existenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listadoDeSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sucursales Sucursales = new Sucursales();

            Sucursales.MdiParent = this;
            Sucursales.Show();
        }

        private void existenciaPorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExistenciaNombre ExistenciaNombre = new ExistenciaNombre();

            ExistenciaNombre.MdiParent = this;
            ExistenciaNombre.Show();
        }

        private void existenciaPorSKUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Existencia = new Form1();

            Existencia.MdiParent = this;
            Existencia.Show();
        }
    }
}
