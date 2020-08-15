namespace RentaDeVideos.Procesos.Facturas
{
    partial class MantenimientoFacturas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoFacturas));
            this.dgridVista = new System.Windows.Forms.DataGridView();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAct_Eliminar = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarDatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgridVista)).BeginInit();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            this.pnlSlideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.cmsDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgridVista
            // 
            this.dgridVista.AllowUserToAddRows = false;
            this.dgridVista.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgridVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridVista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridVista.Location = new System.Drawing.Point(250, 48);
            this.dgridVista.Name = "dgridVista";
            this.dgridVista.RowTemplate.Height = 24;
            this.dgridVista.Size = new System.Drawing.Size(1088, 526);
            this.dgridVista.TabIndex = 7;
            this.dgridVista.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgridVista_CellMouseUp);
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBarra.Controls.Add(this.picSalir);
            this.pnlBarra.Controls.Add(this.picMinimizar);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(250, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1088, 48);
            this.pnlBarra.TabIndex = 9;
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(1041, 12);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(24, 24);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSalir.TabIndex = 4;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // picMinimizar
            // 
            this.picMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picMinimizar.Image")));
            this.picMinimizar.Location = new System.Drawing.Point(995, 12);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 3;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.pnlSlideMenu.Controls.Add(this.btnBuscar);
            this.pnlSlideMenu.Controls.Add(this.btnAct_Eliminar);
            this.pnlSlideMenu.Controls.Add(this.picLogo);
            this.pnlSlideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSlideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(250, 574);
            this.pnlSlideMenu.TabIndex = 8;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(-3, 278);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(250, 60);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAct_Eliminar
            // 
            this.btnAct_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAct_Eliminar.FlatAppearance.BorderSize = 0;
            this.btnAct_Eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAct_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAct_Eliminar.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAct_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnAct_Eliminar.Image")));
            this.btnAct_Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAct_Eliminar.Location = new System.Drawing.Point(-3, 179);
            this.btnAct_Eliminar.Name = "btnAct_Eliminar";
            this.btnAct_Eliminar.Size = new System.Drawing.Size(250, 80);
            this.btnAct_Eliminar.TabIndex = 2;
            this.btnAct_Eliminar.Text = "Eliminar";
            this.btnAct_Eliminar.UseVisualStyleBackColor = true;
            this.btnAct_Eliminar.Click += new System.EventHandler(this.btnAct_Eliminar_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 27);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(222, 88);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // cmsDelete
            // 
            this.cmsDelete.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarDatoToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(170, 28);
            this.cmsDelete.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // eliminarDatoToolStripMenuItem
            // 
            this.eliminarDatoToolStripMenuItem.Name = "eliminarDatoToolStripMenuItem";
            this.eliminarDatoToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.eliminarDatoToolStripMenuItem.Text = "Eliminar Dato";
            // 
            // MantenimientoFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 574);
            this.Controls.Add(this.dgridVista);
            this.Controls.Add(this.pnlBarra);
            this.Controls.Add(this.pnlSlideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MantenimientoFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MantenimientoFacturas";
            ((System.ComponentModel.ISupportInitialize)(this.dgridVista)).EndInit();
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.pnlSlideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.cmsDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridVista;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
        private System.Windows.Forms.Panel pnlSlideMenu;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAct_Eliminar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.ContextMenuStrip cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem eliminarDatoToolStripMenuItem;
    }
}