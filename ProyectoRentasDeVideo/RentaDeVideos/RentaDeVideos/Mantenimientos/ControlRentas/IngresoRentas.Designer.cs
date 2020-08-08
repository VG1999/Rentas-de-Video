namespace RentaDeVideos.Mantenimientos.ControlRentas
{
    partial class IngresoRentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoRentas));
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gboxEncabezado = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlFormMenu = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.picBotonMenuSlide = new System.Windows.Forms.PictureBox();
            this.pnlSlideMenu = new System.Windows.Forms.Panel();
            this.btnRentas = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAct_Eliminar = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gboxEncabezado.SuspendLayout();
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
            this.pnlContenido.Controls.Add(this.dataGridView1);
            this.pnlContenido.Controls.Add(this.gboxEncabezado);
            this.pnlContenido.Controls.Add(this.btnGuardar);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(250, 50);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1050, 550);
            this.pnlContenido.TabIndex = 5;
            this.pnlContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenido_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(975, 260);
            this.dataGridView1.TabIndex = 7;
            // 
            // gboxEncabezado
            // 
            this.gboxEncabezado.Controls.Add(this.txtCliente);
            this.gboxEncabezado.Controls.Add(this.txtEmpleado);
            this.gboxEncabezado.Controls.Add(this.lblEmpleado);
            this.gboxEncabezado.Controls.Add(this.lblCliente);
            this.gboxEncabezado.Location = new System.Drawing.Point(41, 19);
            this.gboxEncabezado.Name = "gboxEncabezado";
            this.gboxEncabezado.Size = new System.Drawing.Size(975, 169);
            this.gboxEncabezado.TabIndex = 6;
            this.gboxEncabezado.TabStop = false;
            this.gboxEncabezado.Text = "Encabezado";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(262, 39);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(233, 32);
            this.txtCliente.TabIndex = 3;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpleado.Location = new System.Drawing.Point(262, 108);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(233, 32);
            this.txtEmpleado.TabIndex = 5;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleado.Location = new System.Drawing.Point(43, 111);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(139, 23);
            this.lblEmpleado.TabIndex = 4;
            this.lblEmpleado.Text = "ID Empleado";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(43, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(105, 23);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "ID Cliente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(421, 478);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 60);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar Datos";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // pnlFormMenu
            // 
            this.pnlFormMenu.Controls.Add(this.picSalir);
            this.pnlFormMenu.Controls.Add(this.picMinimizar);
            this.pnlFormMenu.Controls.Add(this.picBotonMenuSlide);
            this.pnlFormMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormMenu.Location = new System.Drawing.Point(250, 0);
            this.pnlFormMenu.Name = "pnlFormMenu";
            this.pnlFormMenu.Size = new System.Drawing.Size(1050, 50);
            this.pnlFormMenu.TabIndex = 6;
            this.pnlFormMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlFormMenu_MouseDown);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(1014, 10);
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
            this.picMinimizar.Location = new System.Drawing.Point(968, 10);
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
            this.picBotonMenuSlide.Location = new System.Drawing.Point(6, 10);
            this.picBotonMenuSlide.Name = "picBotonMenuSlide";
            this.picBotonMenuSlide.Size = new System.Drawing.Size(35, 35);
            this.picBotonMenuSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBotonMenuSlide.TabIndex = 0;
            this.picBotonMenuSlide.TabStop = false;
            this.picBotonMenuSlide.Click += new System.EventHandler(this.picBotonMenuSlide_Click);
            // 
            // pnlSlideMenu
            // 
            this.pnlSlideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.pnlSlideMenu.Controls.Add(this.btnRentas);
            this.pnlSlideMenu.Controls.Add(this.btnBuscar);
            this.pnlSlideMenu.Controls.Add(this.btnAct_Eliminar);
            this.pnlSlideMenu.Controls.Add(this.btnIngreso);
            this.pnlSlideMenu.Controls.Add(this.btnVolverMenu);
            this.pnlSlideMenu.Controls.Add(this.picLogo);
            this.pnlSlideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSlideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSlideMenu.Name = "pnlSlideMenu";
            this.pnlSlideMenu.Size = new System.Drawing.Size(250, 600);
            this.pnlSlideMenu.TabIndex = 4;
            // 
            // btnRentas
            // 
            this.btnRentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRentas.FlatAppearance.BorderSize = 0;
            this.btnRentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentas.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentas.Image = ((System.Drawing.Image)(resources.GetObject("btnRentas.Image")));
            this.btnRentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentas.Location = new System.Drawing.Point(0, 156);
            this.btnRentas.Name = "btnRentas";
            this.btnRentas.Size = new System.Drawing.Size(250, 60);
            this.btnRentas.TabIndex = 4;
            this.btnRentas.Text = "Rentas";
            this.btnRentas.UseVisualStyleBackColor = true;
            this.btnRentas.Click += new System.EventHandler(this.btnRentas_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(0, 374);
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
            this.btnAct_Eliminar.Location = new System.Drawing.Point(0, 288);
            this.btnAct_Eliminar.Name = "btnAct_Eliminar";
            this.btnAct_Eliminar.Size = new System.Drawing.Size(250, 80);
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
            this.btnIngreso.Location = new System.Drawing.Point(0, 222);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(250, 60);
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
            this.btnVolverMenu.Location = new System.Drawing.Point(0, 557);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(250, 40);
            this.btnVolverMenu.TabIndex = 0;
            this.btnVolverMenu.Text = "Volver";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
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
            // IngresoRentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 600);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlFormMenu);
            this.Controls.Add(this.pnlSlideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngresoRentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresoClientes";
            this.pnlContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gboxEncabezado.ResumeLayout(false);
            this.gboxEncabezado.PerformLayout();
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
        private System.Windows.Forms.Button btnRentas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAct_Eliminar;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gboxEncabezado;
    }
}