namespace Elegancia
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.existenciaDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existenciaPorSKUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existenciaPorNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeSucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.existenciaDeProductosToolStripMenuItem,
            this.existenciaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // existenciaDeProductosToolStripMenuItem
            // 
            this.existenciaDeProductosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.existenciaPorSKUToolStripMenuItem,
            this.existenciaPorNombreToolStripMenuItem});
            this.existenciaDeProductosToolStripMenuItem.Name = "existenciaDeProductosToolStripMenuItem";
            this.existenciaDeProductosToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.existenciaDeProductosToolStripMenuItem.Text = "Existencia";
            this.existenciaDeProductosToolStripMenuItem.Click += new System.EventHandler(this.existenciaDeProductosToolStripMenuItem_Click);
            // 
            // existenciaPorSKUToolStripMenuItem
            // 
            this.existenciaPorSKUToolStripMenuItem.Name = "existenciaPorSKUToolStripMenuItem";
            this.existenciaPorSKUToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.existenciaPorSKUToolStripMenuItem.Text = "Existencia por SKU";
            this.existenciaPorSKUToolStripMenuItem.Click += new System.EventHandler(this.existenciaPorSKUToolStripMenuItem_Click);
            // 
            // existenciaPorNombreToolStripMenuItem
            // 
            this.existenciaPorNombreToolStripMenuItem.Name = "existenciaPorNombreToolStripMenuItem";
            this.existenciaPorNombreToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.existenciaPorNombreToolStripMenuItem.Text = "Existencia por Nombre";
            this.existenciaPorNombreToolStripMenuItem.Click += new System.EventHandler(this.existenciaPorNombreToolStripMenuItem_Click);
            // 
            // existenciaToolStripMenuItem
            // 
            this.existenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeSucursalesToolStripMenuItem});
            this.existenciaToolStripMenuItem.Name = "existenciaToolStripMenuItem";
            this.existenciaToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.existenciaToolStripMenuItem.Text = "Sucursales";
            this.existenciaToolStripMenuItem.Click += new System.EventHandler(this.existenciaToolStripMenuItem_Click);
            // 
            // listadoDeSucursalesToolStripMenuItem
            // 
            this.listadoDeSucursalesToolStripMenuItem.Name = "listadoDeSucursalesToolStripMenuItem";
            this.listadoDeSucursalesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.listadoDeSucursalesToolStripMenuItem.Text = "Listado de Sucursales";
            this.listadoDeSucursalesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeSucursalesToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 519);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem existenciaDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existenciaPorSKUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existenciaPorNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeSucursalesToolStripMenuItem;
    }
}