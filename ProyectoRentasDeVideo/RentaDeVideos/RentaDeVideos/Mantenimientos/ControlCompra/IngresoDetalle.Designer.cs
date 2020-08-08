namespace RentaDeVideos.Mantenimientos.ControlCompra
{
    partial class IngresoDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoDetalle));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.gboxEncabezado = new System.Windows.Forms.GroupBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gboxDetalle = new System.Windows.Forms.GroupBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFormMenu = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.picBotonMenuSlide = new System.Windows.Forms.PictureBox();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAct_Eliminar = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlContenido.SuspendLayout();
            this.gboxEncabezado.SuspendLayout();
            this.gboxDetalle.SuspendLayout();
            this.pnlFormMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBotonMenuSlide)).BeginInit();
            this.pnlSlideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.gboxEncabezado);
            this.pnlContenido.Controls.Add(this.gboxDetalle);
            this.pnlContenido.Controls.Add(this.btnGuardar);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(188, 41);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(787, 447);
            this.pnlContenido.TabIndex = 5;
            this.pnlContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenido_Paint);
            // 
            // gboxEncabezado
            // 
            this.gboxEncabezado.Controls.Add(this.txtFecha);
            this.gboxEncabezado.Controls.Add(this.lblFecha);
            this.gboxEncabezado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gboxEncabezado.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxEncabezado.Location = new System.Drawing.Point(37, 32);
            this.gboxEncabezado.Margin = new System.Windows.Forms.Padding(2);
            this.gboxEncabezado.Name = "gboxEncabezado";
            this.gboxEncabezado.Padding = new System.Windows.Forms.Padding(2);
            this.gboxEncabezado.Size = new System.Drawing.Size(720, 117);
            this.gboxEncabezado.TabIndex = 16;
            this.gboxEncabezado.TabStop = false;
            this.gboxEncabezado.Text = "Compra Encabezado";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(159, 50);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(2);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(176, 27);
            this.txtFecha.TabIndex = 15;
            this.txtFecha.TextChanged += new System.EventHandler(this.txtFecha_TextChanged);
            this.txtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFecha_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(20, 53);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(128, 21);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha Compra";
            // 
            // gboxDetalle
            // 
            this.gboxDetalle.Controls.Add(this.txtDescripcion);
            this.gboxDetalle.Controls.Add(this.lblDescripcion);
            this.gboxDetalle.Controls.Add(this.lblPrecio);
            this.gboxDetalle.Controls.Add(this.txtNombre);
            this.gboxDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gboxDetalle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxDetalle.Location = new System.Drawing.Point(37, 185);
            this.gboxDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.gboxDetalle.Name = "gboxDetalle";
            this.gboxDetalle.Padding = new System.Windows.Forms.Padding(2);
            this.gboxDetalle.Size = new System.Drawing.Size(720, 105);
            this.gboxDetalle.TabIndex = 11;
            this.gboxDetalle.TabStop = false;
            this.gboxDetalle.Text = "Detalle de Compra";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(514, 37);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(176, 27);
            this.txtDescripcion.TabIndex = 10;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(389, 37);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 21);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(37, 37);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 21);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(127, 37);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(176, 27);
            this.txtNombre.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(315, 349);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 58);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Datos";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlFormMenu
            // 
            this.pnlFormMenu.Controls.Add(this.picSalir);
            this.pnlFormMenu.Controls.Add(this.picMinimizar);
            this.pnlFormMenu.Controls.Add(this.picBotonMenuSlide);
            this.pnlFormMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormMenu.Location = new System.Drawing.Point(188, 0);
            this.pnlFormMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFormMenu.Name = "pnlFormMenu";
            this.pnlFormMenu.Size = new System.Drawing.Size(787, 41);
            this.pnlFormMenu.TabIndex = 6;
            this.pnlFormMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlFormMenu_MouseDown);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(759, 8);
            this.picSalir.Margin = new System.Windows.Forms.Padding(2);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(24, 24);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSalir.TabIndex = 2;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // picMinimizar
            // 
            this.picMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picMinimizar.Image")));
            this.picMinimizar.Location = new System.Drawing.Point(725, 8);
            this.picMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 1;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // picBotonMenuSlide
            // 
            this.picBotonMenuSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBotonMenuSlide.Image = ((System.Drawing.Image)(resources.GetObject("picBotonMenuSlide.Image")));
            this.picBotonMenuSlide.Location = new System.Drawing.Point(4, 8);
            this.picBotonMenuSlide.Margin = new System.Windows.Forms.Padding(2);
            this.picBotonMenuSlide.Name = "picBotonMenuSlide";
            this.picBotonMenuSlide.Size = new System.Drawing.Size(26, 28);
            this.picBotonMenuSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBotonMenuSlide.TabIndex = 0;
            this.picBotonMenuSlide.TabStop = false;
            this.picBotonMenuSlide.Click += new System.EventHandler(this.picBotonMenuSlide_Click);
            // 
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.pnlSlideMenu.Controls.Add(this.btnDetalles);
            this.pnlSlideMenu.Controls.Add(this.btnBuscar);
            this.pnlSlideMenu.Controls.Add(this.btnAct_Eliminar);
            this.pnlSlideMenu.Controls.Add(this.btnIngreso);
            this.pnlSlideMenu.Controls.Add(this.btnVolverMenu);
            this.pnlSlideMenu.Controls.Add(this.picLogo);
            this.pnlSlideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSlideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSlideMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(188, 488);
            this.pnlSlideMenu.TabIndex = 4;
            // 
            // btnDetalles
            // 
            this.btnDetalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalles.FlatAppearance.BorderSize = 0;
            this.btnDetalles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalles.Image")));
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalles.Location = new System.Drawing.Point(0, 127);
            this.btnDetalles.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(188, 49);
            this.btnDetalles.TabIndex = 4;
            this.btnDetalles.Text = "Compras";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(0, 304);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(188, 49);
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
            this.btnAct_Eliminar.Location = new System.Drawing.Point(0, 234);
            this.btnAct_Eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAct_Eliminar.Name = "btnAct_Eliminar";
            this.btnAct_Eliminar.Size = new System.Drawing.Size(188, 65);
            this.btnAct_Eliminar.TabIndex = 2;
            this.btnAct_Eliminar.Text = "Actualizar y Eliminar";
            this.btnAct_Eliminar.UseVisualStyleBackColor = true;
            this.btnAct_Eliminar.Click += new System.EventHandler(this.btnAct_Eliminar_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngreso.FlatAppearance.BorderSize = 0;
            this.btnIngreso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnIngreso.Image")));
            this.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.Location = new System.Drawing.Point(0, 180);
            this.btnIngreso.Margin = new System.Windows.Forms.Padding(2);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(188, 49);
            this.btnIngreso.TabIndex = 1;
            this.btnIngreso.Text = "Ingresar";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolverMenu.FlatAppearance.BorderSize = 0;
            this.btnVolverMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverMenu.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnVolverMenu.Image")));
            this.btnVolverMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolverMenu.Location = new System.Drawing.Point(0, 453);
            this.btnVolverMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(188, 32);
            this.btnVolverMenu.TabIndex = 0;
            this.btnVolverMenu.Text = "Volver";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(9, 22);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(166, 72);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // IngresoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 488);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlFormMenu);
            this.Controls.Add(this.pnlSlideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IngresoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresoClientes";
            this.pnlContenido.ResumeLayout(false);
            this.gboxEncabezado.ResumeLayout(false);
            this.gboxEncabezado.PerformLayout();
            this.gboxDetalle.ResumeLayout(false);
            this.gboxDetalle.PerformLayout();
            this.pnlFormMenu.ResumeLayout(false);
            this.pnlFormMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBotonMenuSlide)).EndInit();
            this.pnlSlideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlFormMenu;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
        private System.Windows.Forms.PictureBox picBotonMenuSlide;
        private System.Windows.Forms.Panel pnlSlideMenu;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAct_Eliminar;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gboxEncabezado;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox gboxDetalle;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtNombre;
    }
}