namespace RentaDeVideos.Procesos.Facturas
{
    partial class IngresoFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoFactura));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtNoFactura = new System.Windows.Forms.TextBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.pnlContenedorGrid = new System.Windows.Forms.Panel();
            this.dgridDatosFactura = new System.Windows.Forms.DataGridView();
            this.gboxDatosFactura = new System.Windows.Forms.GroupBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblIDEmpleado = new System.Windows.Forms.Label();
            this.gboxDatosCliente = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.lblNIT = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblIDCliente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbVideo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbBonoDesc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtSubtotalBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEtiqueta = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.pnlBarra.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlContenedorGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridDatosFactura)).BeginInit();
            this.gboxDatosFactura.SuspendLayout();
            this.gboxDatosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
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
            this.pnlBarra.Size = new System.Drawing.Size(1127, 70);
            this.pnlBarra.TabIndex = 0;
            // 
            // pnlContenido
            // 
            this.pnlContenido.AutoScroll = true;
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.lblEtiqueta);
            this.pnlContenido.Controls.Add(this.lblTotal);
            this.pnlContenido.Controls.Add(this.btnRegistrar);
            this.pnlContenido.Controls.Add(this.txtSerie);
            this.pnlContenido.Controls.Add(this.lblSerie);
            this.pnlContenido.Controls.Add(this.txtNoFactura);
            this.pnlContenido.Controls.Add(this.lblFactura);
            this.pnlContenido.Controls.Add(this.pnlContenedorGrid);
            this.pnlContenido.Controls.Add(this.gboxDatosFactura);
            this.pnlContenido.Controls.Add(this.gboxDatosCliente);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 70);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1127, 1032);
            this.pnlContenido.TabIndex = 1;
            // 
            // txtSerie
            // 
            this.txtSerie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSerie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(784, 20);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(169, 32);
            this.txtSerie.TabIndex = 16;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(669, 23);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(94, 23);
            this.lblSerie.TabIndex = 15;
            this.lblSerie.Text = "No. Serie";
            // 
            // txtNoFactura
            // 
            this.txtNoFactura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNoFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoFactura.Location = new System.Drawing.Point(202, 20);
            this.txtNoFactura.Name = "txtNoFactura";
            this.txtNoFactura.Size = new System.Drawing.Size(169, 32);
            this.txtNoFactura.TabIndex = 14;
            this.txtNoFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoFactura_KeyPress);
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(52, 23);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(125, 23);
            this.lblFactura.TabIndex = 13;
            this.lblFactura.Text = "No. Factura";
            // 
            // pnlContenedorGrid
            // 
            this.pnlContenedorGrid.Controls.Add(this.dgridDatosFactura);
            this.pnlContenedorGrid.Location = new System.Drawing.Point(43, 432);
            this.pnlContenedorGrid.Name = "pnlContenedorGrid";
            this.pnlContenedorGrid.Size = new System.Drawing.Size(1037, 343);
            this.pnlContenedorGrid.TabIndex = 12;
            // 
            // dgridDatosFactura
            // 
            this.dgridDatosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridDatosFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbVideo,
            this.txtCantidad,
            this.cmbBonoDesc,
            this.txtSubtotalBD,
            this.txtSubtotal});
            this.dgridDatosFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridDatosFactura.Location = new System.Drawing.Point(0, 0);
            this.dgridDatosFactura.Name = "dgridDatosFactura";
            this.dgridDatosFactura.RowTemplate.Height = 24;
            this.dgridDatosFactura.Size = new System.Drawing.Size(1037, 343);
            this.dgridDatosFactura.TabIndex = 0;
            this.dgridDatosFactura.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridDatosFactura_CellEndEdit);
            // 
            // gboxDatosFactura
            // 
            this.gboxDatosFactura.BackColor = System.Drawing.Color.White;
            this.gboxDatosFactura.Controls.Add(this.cmbTipoDoc);
            this.gboxDatosFactura.Controls.Add(this.lblTipoDoc);
            this.gboxDatosFactura.Controls.Add(this.cmbFormaPago);
            this.gboxDatosFactura.Controls.Add(this.lblFormaPago);
            this.gboxDatosFactura.Controls.Add(this.txtFecha);
            this.gboxDatosFactura.Controls.Add(this.lblFecha);
            this.gboxDatosFactura.Controls.Add(this.cmbEmpleado);
            this.gboxDatosFactura.Controls.Add(this.lblIDEmpleado);
            this.gboxDatosFactura.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxDatosFactura.Location = new System.Drawing.Point(43, 230);
            this.gboxDatosFactura.Name = "gboxDatosFactura";
            this.gboxDatosFactura.Size = new System.Drawing.Size(1037, 166);
            this.gboxDatosFactura.TabIndex = 11;
            this.gboxDatosFactura.TabStop = false;
            this.gboxDatosFactura.Text = "Datos Factura";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbTipoDoc.Location = new System.Drawing.Point(706, 102);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(169, 31);
            this.cmbTipoDoc.TabIndex = 11;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(546, 105);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(133, 23);
            this.lblTipoDoc.TabIndex = 10;
            this.lblTipoDoc.Text = "Tipo de Doc.";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbFormaPago.Location = new System.Drawing.Point(232, 97);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(169, 31);
            this.cmbFormaPago.TabIndex = 9;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.Location = new System.Drawing.Point(38, 105);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(163, 23);
            this.lblFormaPago.TabIndex = 8;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(706, 39);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(169, 32);
            this.txtFecha.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(546, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(72, 23);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(232, 31);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(169, 31);
            this.cmbEmpleado.TabIndex = 5;
            // 
            // lblIDEmpleado
            // 
            this.lblIDEmpleado.AutoSize = true;
            this.lblIDEmpleado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDEmpleado.Location = new System.Drawing.Point(38, 39);
            this.lblIDEmpleado.Name = "lblIDEmpleado";
            this.lblIDEmpleado.Size = new System.Drawing.Size(139, 23);
            this.lblIDEmpleado.TabIndex = 4;
            this.lblIDEmpleado.Text = "ID Empleado";
            // 
            // gboxDatosCliente
            // 
            this.gboxDatosCliente.BackColor = System.Drawing.Color.White;
            this.gboxDatosCliente.Controls.Add(this.txtDireccion);
            this.gboxDatosCliente.Controls.Add(this.lblDireccion);
            this.gboxDatosCliente.Controls.Add(this.txtNIT);
            this.gboxDatosCliente.Controls.Add(this.lblNIT);
            this.gboxDatosCliente.Controls.Add(this.txtApellidos);
            this.gboxDatosCliente.Controls.Add(this.lblApellidos);
            this.gboxDatosCliente.Controls.Add(this.txtNombreCliente);
            this.gboxDatosCliente.Controls.Add(this.lblIDCliente);
            this.gboxDatosCliente.Controls.Add(this.lblNombre);
            this.gboxDatosCliente.Controls.Add(this.cmbCliente);
            this.gboxDatosCliente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxDatosCliente.Location = new System.Drawing.Point(43, 61);
            this.gboxDatosCliente.Name = "gboxDatosCliente";
            this.gboxDatosCliente.Size = new System.Drawing.Size(1037, 163);
            this.gboxDatosCliente.TabIndex = 10;
            this.gboxDatosCliente.TabStop = false;
            this.gboxDatosCliente.Text = "Datos de Cliente";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(470, 106);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(392, 32);
            this.txtDireccion.TabIndex = 15;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(357, 106);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(101, 23);
            this.lblDireccion.TabIndex = 14;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtNIT
            // 
            this.txtNIT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNIT.Enabled = false;
            this.txtNIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIT.Location = new System.Drawing.Point(143, 106);
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(169, 32);
            this.txtNIT.TabIndex = 13;
            // 
            // lblNIT
            // 
            this.lblNIT.AutoSize = true;
            this.lblNIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.Location = new System.Drawing.Point(30, 106);
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Size = new System.Drawing.Size(38, 23);
            this.lblNIT.TabIndex = 12;
            this.lblNIT.Text = "NIT";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtApellidos.Enabled = false;
            this.txtApellidos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(815, 33);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(169, 32);
            this.txtApellidos.TabIndex = 11;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidos.Location = new System.Drawing.Point(702, 33);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(100, 23);
            this.lblApellidos.TabIndex = 10;
            this.lblApellidos.Text = "Apellidos";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(470, 36);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(169, 32);
            this.txtNombreCliente.TabIndex = 9;
            // 
            // lblIDCliente
            // 
            this.lblIDCliente.AutoSize = true;
            this.lblIDCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDCliente.Location = new System.Drawing.Point(23, 36);
            this.lblIDCliente.Name = "lblIDCliente";
            this.lblIDCliente.Size = new System.Drawing.Size(105, 23);
            this.lblIDCliente.TabIndex = 6;
            this.lblIDCliente.Text = "ID Cliente";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(357, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(90, 23);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(143, 36);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(169, 31);
            this.cmbCliente.TabIndex = 7;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // cmbVideo
            // 
            this.cmbVideo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbVideo.HeaderText = "id_video";
            this.cmbVideo.Name = "cmbVideo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtCantidad.HeaderText = "cantidad";
            this.txtCantidad.Name = "txtCantidad";
            // 
            // cmbBonoDesc
            // 
            this.cmbBonoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbBonoDesc.HeaderText = "Bono/Desc";
            this.cmbBonoDesc.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbBonoDesc.Name = "cmbBonoDesc";
            // 
            // txtSubtotalBD
            // 
            this.txtSubtotalBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtSubtotalBD.HeaderText = "Subtotal_BD";
            this.txtSubtotalBD.Name = "txtSubtotalBD";
            this.txtSubtotalBD.ReadOnly = true;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtSubtotal.HeaderText = "Subtotal";
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            // 
            // lblEtiqueta
            // 
            this.lblEtiqueta.AutoSize = true;
            this.lblEtiqueta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtiqueta.Location = new System.Drawing.Point(104, 867);
            this.lblEtiqueta.Name = "lblEtiqueta";
            this.lblEtiqueta.Size = new System.Drawing.Size(62, 23);
            this.lblEtiqueta.TabIndex = 19;
            this.lblEtiqueta.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(173, 867);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(21, 23);
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "0";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(851, 846);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(176, 65);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar Factura";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(1078, 24);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(24, 24);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSalir.TabIndex = 6;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // picMinimizar
            // 
            this.picMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picMinimizar.Image")));
            this.picMinimizar.Location = new System.Drawing.Point(1032, 24);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 5;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // IngresoFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1127, 1102);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngresoFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresoFactura";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.pnlContenedorGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridDatosFactura)).EndInit();
            this.gboxDatosFactura.ResumeLayout(false);
            this.gboxDatosFactura.PerformLayout();
            this.gboxDatosCliente.ResumeLayout(false);
            this.gboxDatosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Panel pnlContenedorGrid;
        private System.Windows.Forms.GroupBox gboxDatosFactura;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblIDEmpleado;
        private System.Windows.Forms.GroupBox gboxDatosCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblIDCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtNoFactura;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.DataGridView dgridDatosFactura;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbVideo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbBonoDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSubtotalBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSubtotal;
        private System.Windows.Forms.Label lblEtiqueta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
    }
}