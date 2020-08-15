namespace RentaDeVideos.Procesos.Compras
{
    partial class IngresoCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoCompras));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.txtIDFactura = new System.Windows.Forms.TextBox();
            this.lblIDFactura = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pnlContenedorGrid = new System.Windows.Forms.Panel();
            this.dgridDetalleFactura = new System.Windows.Forms.DataGridView();
            this.cmbVideo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEncabezadoCompra = new System.Windows.Forms.Panel();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.lblNIT = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            this.pnlCuerpo.SuspendLayout();
            this.pnlContenedorGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridDetalleFactura)).BeginInit();
            this.pnlEncabezadoCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.pnlBarra.Controls.Add(this.picSalir);
            this.pnlBarra.Controls.Add(this.picMinimizar);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1005, 50);
            this.pnlBarra.TabIndex = 0;
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(957, 12);
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
            this.picMinimizar.Location = new System.Drawing.Point(911, 12);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 3;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.lblEtiqueta);
            this.pnlCuerpo.Controls.Add(this.txtIDFactura);
            this.pnlCuerpo.Controls.Add(this.lblIDFactura);
            this.pnlCuerpo.Controls.Add(this.lblTotal);
            this.pnlCuerpo.Controls.Add(this.btnRegistrar);
            this.pnlCuerpo.Controls.Add(this.pnlContenedorGrid);
            this.pnlCuerpo.Controls.Add(this.pnlEncabezadoCompra);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 50);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1005, 793);
            this.pnlCuerpo.TabIndex = 1;
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiqueta.Location = new System.Drawing.Point(36, 727);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(62, 23);
            this.lblEtiqueta.TabIndex = 7;
            this.lblEtiqueta.Text = "Total:";
            // 
            // txtIDFactura
            // 
            this.txtIDFactura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIDFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDFactura.Location = new System.Drawing.Point(195, 11);
            this.txtIDFactura.Name = "txtIDFactura";
            this.txtIDFactura.Size = new System.Drawing.Size(118, 32);
            this.txtIDFactura.TabIndex = 6;
            this.txtIDFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDFactura_KeyPress);
            // 
            // lblIDFactura
            // 
            this.lblIDFactura.AutoSize = true;
            this.lblIDFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFactura.Location = new System.Drawing.Point(26, 14);
            this.lblIDFactura.Name = "lblIDFactura";
            this.lblIDFactura.Size = new System.Drawing.Size(125, 23);
            this.lblIDFactura.TabIndex = 4;
            this.lblIDFactura.Text = "No. Factura";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(105, 727);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(21, 23);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(783, 706);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(176, 65);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar Compra";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pnlContenedorGrid
            // 
            this.pnlContenedorGrid.Controls.Add(this.dgridDetalleFactura);
            this.pnlContenedorGrid.Location = new System.Drawing.Point(30, 220);
            this.pnlContenedorGrid.Name = "pnlContenedorGrid";
            this.pnlContenedorGrid.Size = new System.Drawing.Size(929, 461);
            this.pnlContenedorGrid.TabIndex = 1;
            // 
            // dgridDetalleFactura
            // 
            this.dgridDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbVideo,
            this.txtCantidad,
            this.txtPrecio,
            this.txtSubtotal});
            this.dgridDetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridDetalleFactura.Location = new System.Drawing.Point(0, 0);
            this.dgridDetalleFactura.Name = "dgridDetalleFactura";
            this.dgridDetalleFactura.RowTemplate.Height = 24;
            this.dgridDetalleFactura.Size = new System.Drawing.Size(929, 461);
            this.dgridDetalleFactura.TabIndex = 0;
            this.dgridDetalleFactura.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridDetalleFactura_CellEndEdit);
            // 
            // cmbVideo
            // 
            this.cmbVideo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbVideo.HeaderText = "ID Video";
            this.cmbVideo.Name = "cmbVideo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtCantidad.HeaderText = "Cantidad";
            this.txtCantidad.Name = "txtCantidad";
            // 
            // txtPrecio
            // 
            this.txtPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtPrecio.HeaderText = "Precio Unitario";
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtSubtotal.HeaderText = "Subtotal";
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            // 
            // pnlEncabezadoCompra
            // 
            this.pnlEncabezadoCompra.BackColor = System.Drawing.Color.White;
            this.pnlEncabezadoCompra.Controls.Add(this.txtNIT);
            this.pnlEncabezadoCompra.Controls.Add(this.lblNIT);
            this.pnlEncabezadoCompra.Controls.Add(this.txtFecha);
            this.pnlEncabezadoCompra.Controls.Add(this.lblFecha);
            this.pnlEncabezadoCompra.Controls.Add(this.cmbProveedor);
            this.pnlEncabezadoCompra.Controls.Add(this.lblProveedor);
            this.pnlEncabezadoCompra.Location = new System.Drawing.Point(30, 50);
            this.pnlEncabezadoCompra.Name = "pnlEncabezadoCompra";
            this.pnlEncabezadoCompra.Size = new System.Drawing.Size(929, 144);
            this.pnlEncabezadoCompra.TabIndex = 0;
            // 
            // txtNIT
            // 
            this.txtNIT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNIT.Enabled = false;
            this.txtNIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIT.Location = new System.Drawing.Point(669, 29);
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(234, 32);
            this.txtNIT.TabIndex = 5;
            // 
            // lblNIT
            // 
            this.lblNIT.AutoSize = true;
            this.lblNIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.Location = new System.Drawing.Point(494, 31);
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Size = new System.Drawing.Size(147, 23);
            this.lblNIT.TabIndex = 4;
            this.lblNIT.Text = "NIT Proveedor";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(230, 89);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(234, 32);
            this.txtFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(23, 98);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(160, 23);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha Compra";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbProveedor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(230, 29);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(234, 31);
            this.cmbProveedor.TabIndex = 1;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(23, 29);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(113, 23);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Proveedor";
            // 
            // IngresoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 843);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngresoCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresoCompras";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlContenedorGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridDetalleFactura)).EndInit();
            this.pnlEncabezadoCompra.ResumeLayout(false);
            this.pnlEncabezadoCompra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Panel pnlContenedorGrid;
        private System.Windows.Forms.DataGridView dgridDetalleFactura;
        private System.Windows.Forms.Panel pnlEncabezadoCompra;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbVideo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSubtotal;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIDFactura;
        private System.Windows.Forms.TextBox txtIDFactura;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
        private System.Windows.Forms.Label lblEtiqueta;
    }
}