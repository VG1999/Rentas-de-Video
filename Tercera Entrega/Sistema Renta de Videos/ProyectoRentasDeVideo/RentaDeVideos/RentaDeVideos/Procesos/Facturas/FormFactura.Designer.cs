namespace RentaDeVideos.Procesos.Facturas
{
    partial class FormFactura
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
            this.pnlcentral = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTitulo_Total = new System.Windows.Forms.Label();
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblId_Enca = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDetalle_F = new System.Windows.Forms.Panel();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSub_Total = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblId_detalle = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBuscar_Deta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgDetalle = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblSeleccionar = new System.Windows.Forms.Label();
            this.cboBuscar = new System.Windows.Forms.ComboBox();
            this.pnlencabezado = new System.Windows.Forms.Panel();
            this.txtId_Empleado = new System.Windows.Forms.TextBox();
            this.lblId_Epleado = new System.Windows.Forms.Label();
            this.txtId_Cliente = new System.Windows.Forms.TextBox();
            this.lblId_Cliente = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cboTipo_P = new System.Windows.Forms.ComboBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo_P = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNit = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbVideo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlcentral.SuspendLayout();
            this.pnlFecha.SuspendLayout();
            this.pnlDetalle_F.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).BeginInit();
            this.pnlencabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlcentral
            // 
            this.pnlcentral.BackColor = System.Drawing.Color.White;
            this.pnlcentral.Controls.Add(this.btnBuscar);
            this.pnlcentral.Controls.Add(this.txtTotal);
            this.pnlcentral.Controls.Add(this.lblTitulo_Total);
            this.pnlcentral.Controls.Add(this.pnlFecha);
            this.pnlcentral.Controls.Add(this.comboBox1);
            this.pnlcentral.Controls.Add(this.label1);
            this.pnlcentral.Controls.Add(this.pnlDetalle_F);
            this.pnlcentral.Controls.Add(this.txtBuscar);
            this.pnlcentral.Controls.Add(this.lblBuscar);
            this.pnlcentral.Controls.Add(this.lblSeleccionar);
            this.pnlcentral.Controls.Add(this.cboBuscar);
            this.pnlcentral.Controls.Add(this.pnlencabezado);
            this.pnlcentral.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlcentral.Location = new System.Drawing.Point(0, 1);
            this.pnlcentral.Name = "pnlcentral";
            this.pnlcentral.Size = new System.Drawing.Size(966, 655);
            this.pnlcentral.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(277, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 38);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "buton";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(815, 620);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(140, 28);
            this.txtTotal.TabIndex = 10;
            // 
            // lblTitulo_Total
            // 
            this.lblTitulo_Total.AutoSize = true;
            this.lblTitulo_Total.Location = new System.Drawing.Point(750, 623);
            this.lblTitulo_Total.Name = "lblTitulo_Total";
            this.lblTitulo_Total.Size = new System.Drawing.Size(51, 19);
            this.lblTitulo_Total.TabIndex = 9;
            this.lblTitulo_Total.Text = "Total:";
            // 
            // pnlFecha
            // 
            this.pnlFecha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFecha.Controls.Add(this.textBox1);
            this.pnlFecha.Controls.Add(this.lblId_Enca);
            this.pnlFecha.Controls.Add(this.txtFecha);
            this.pnlFecha.Controls.Add(this.txtSerie);
            this.pnlFecha.Controls.Add(this.lblSerie);
            this.pnlFecha.Controls.Add(this.lblFecha);
            this.pnlFecha.Location = new System.Drawing.Point(358, 52);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(596, 63);
            this.pnlFecha.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(474, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 19;
            // 
            // lblId_Enca
            // 
            this.lblId_Enca.AutoSize = true;
            this.lblId_Enca.Location = new System.Drawing.Point(440, 25);
            this.lblId_Enca.Name = "lblId_Enca";
            this.lblId_Enca.Size = new System.Drawing.Size(26, 19);
            this.lblId_Enca.TabIndex = 18;
            this.lblId_Enca.Text = "ID";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(74, 21);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(189, 28);
            this.txtFecha.TabIndex = 17;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(323, 21);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(111, 28);
            this.txtSerie.TabIndex = 16;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(270, 24);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(54, 19);
            this.lblSerie.TabIndex = 14;
            this.lblSerie.Text = "Serie:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(9, 24);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(65, 19);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1.Location = new System.Drawing.Point(785, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 27);
            this.comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo Documento:";
            // 
            // pnlDetalle_F
            // 
            this.pnlDetalle_F.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDetalle_F.Controls.Add(this.lblDescuento);
            this.pnlDetalle_F.Controls.Add(this.txtDescuento);
            this.pnlDetalle_F.Controls.Add(this.lblSubtotal);
            this.pnlDetalle_F.Controls.Add(this.txtSub_Total);
            this.pnlDetalle_F.Controls.Add(this.textBox2);
            this.pnlDetalle_F.Controls.Add(this.lblId_detalle);
            this.pnlDetalle_F.Controls.Add(this.button1);
            this.pnlDetalle_F.Controls.Add(this.txtBuscar_Deta);
            this.pnlDetalle_F.Controls.Add(this.label2);
            this.pnlDetalle_F.Controls.Add(this.dtgDetalle);
            this.pnlDetalle_F.Location = new System.Drawing.Point(12, 287);
            this.pnlDetalle_F.Name = "pnlDetalle_F";
            this.pnlDetalle_F.Size = new System.Drawing.Size(943, 327);
            this.pnlDetalle_F.TabIndex = 5;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(692, 287);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(97, 19);
            this.lblDescuento.TabIndex = 12;
            this.lblDescuento.Text = "Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(800, 284);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(140, 28);
            this.txtDescuento.TabIndex = 13;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(711, 244);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(76, 19);
            this.lblSubtotal.TabIndex = 12;
            this.lblSubtotal.Text = "SubTotal";
            // 
            // txtSub_Total
            // 
            this.txtSub_Total.Location = new System.Drawing.Point(800, 241);
            this.txtSub_Total.Name = "txtSub_Total";
            this.txtSub_Total.Size = new System.Drawing.Size(140, 28);
            this.txtSub_Total.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(41, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(92, 28);
            this.textBox2.TabIndex = 6;
            // 
            // lblId_detalle
            // 
            this.lblId_detalle.AutoSize = true;
            this.lblId_detalle.Location = new System.Drawing.Point(9, 26);
            this.lblId_detalle.Name = "lblId_detalle";
            this.lblId_detalle.Size = new System.Drawing.Size(26, 19);
            this.lblId_detalle.TabIndex = 5;
            this.lblId_detalle.Text = "ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBuscar_Deta
            // 
            this.txtBuscar_Deta.Location = new System.Drawing.Point(220, 23);
            this.txtBuscar_Deta.Name = "txtBuscar_Deta";
            this.txtBuscar_Deta.Size = new System.Drawing.Size(204, 28);
            this.txtBuscar_Deta.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar";
            // 
            // dtgDetalle
            // 
            this.dtgDetalle.AllowUserToOrderColumns = true;
            this.dtgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbVideo,
            this.txtCantidad,
            this.txtPrecio,
            this.txtTot});
            this.dtgDetalle.Location = new System.Drawing.Point(10, 72);
            this.dtgDetalle.Name = "dtgDetalle";
            this.dtgDetalle.RowTemplate.Height = 24;
            this.dtgDetalle.Size = new System.Drawing.Size(930, 150);
            this.dtgDetalle.TabIndex = 0;
            this.dtgDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDetalle_CellContentClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(140, 42);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(212, 28);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(54, 46);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(69, 19);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lblSeleccionar
            // 
            this.lblSeleccionar.AutoSize = true;
            this.lblSeleccionar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionar.Location = new System.Drawing.Point(11, 8);
            this.lblSeleccionar.Name = "lblSeleccionar";
            this.lblSeleccionar.Size = new System.Drawing.Size(112, 19);
            this.lblSeleccionar.TabIndex = 2;
            this.lblSeleccionar.Text = "Seleccionar:";
            // 
            // cboBuscar
            // 
            this.cboBuscar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscar.FormattingEnabled = true;
            this.cboBuscar.Items.AddRange(new object[] {
            "NOMBRE",
            "DPI"});
            this.cboBuscar.Location = new System.Drawing.Point(140, 8);
            this.cboBuscar.Name = "cboBuscar";
            this.cboBuscar.Size = new System.Drawing.Size(212, 29);
            this.cboBuscar.TabIndex = 1;
            // 
            // pnlencabezado
            // 
            this.pnlencabezado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlencabezado.Controls.Add(this.txtId_Empleado);
            this.pnlencabezado.Controls.Add(this.lblId_Epleado);
            this.pnlencabezado.Controls.Add(this.txtId_Cliente);
            this.pnlencabezado.Controls.Add(this.lblId_Cliente);
            this.pnlencabezado.Controls.Add(this.txtDireccion);
            this.pnlencabezado.Controls.Add(this.cboTipo_P);
            this.pnlencabezado.Controls.Add(this.txtNit);
            this.pnlencabezado.Controls.Add(this.txtApellido);
            this.pnlencabezado.Controls.Add(this.txtNombre);
            this.pnlencabezado.Controls.Add(this.lblTipo_P);
            this.pnlencabezado.Controls.Add(this.lblDireccion);
            this.pnlencabezado.Controls.Add(this.lblNit);
            this.pnlencabezado.Controls.Add(this.lblApellido);
            this.pnlencabezado.Controls.Add(this.lblNombre);
            this.pnlencabezado.Location = new System.Drawing.Point(12, 121);
            this.pnlencabezado.Name = "pnlencabezado";
            this.pnlencabezado.Size = new System.Drawing.Size(942, 160);
            this.pnlencabezado.TabIndex = 0;
            // 
            // txtId_Empleado
            // 
            this.txtId_Empleado.Location = new System.Drawing.Point(399, 120);
            this.txtId_Empleado.Name = "txtId_Empleado";
            this.txtId_Empleado.Size = new System.Drawing.Size(100, 28);
            this.txtId_Empleado.TabIndex = 16;
            // 
            // lblId_Epleado
            // 
            this.lblId_Epleado.AutoSize = true;
            this.lblId_Epleado.Location = new System.Drawing.Point(274, 123);
            this.lblId_Epleado.Name = "lblId_Epleado";
            this.lblId_Epleado.Size = new System.Drawing.Size(119, 19);
            this.lblId_Epleado.TabIndex = 15;
            this.lblId_Epleado.Text = "ID_Empleado";
            // 
            // txtId_Cliente
            // 
            this.txtId_Cliente.Location = new System.Drawing.Point(105, 113);
            this.txtId_Cliente.Name = "txtId_Cliente";
            this.txtId_Cliente.Size = new System.Drawing.Size(142, 28);
            this.txtId_Cliente.TabIndex = 14;
            // 
            // lblId_Cliente
            // 
            this.lblId_Cliente.AutoSize = true;
            this.lblId_Cliente.Location = new System.Drawing.Point(12, 116);
            this.lblId_Cliente.Name = "lblId_Cliente";
            this.lblId_Cliente.Size = new System.Drawing.Size(92, 19);
            this.lblId_Cliente.TabIndex = 13;
            this.lblId_Cliente.Text = "ID_Cliente";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(105, 72);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(531, 28);
            this.txtDireccion.TabIndex = 12;
            // 
            // cboTipo_P
            // 
            this.cboTipo_P.FormattingEnabled = true;
            this.cboTipo_P.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cboTipo_P.Location = new System.Drawing.Point(745, 73);
            this.cboTipo_P.Name = "cboTipo_P";
            this.cboTipo_P.Size = new System.Drawing.Size(168, 27);
            this.cboTipo_P.TabIndex = 11;
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(745, 24);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(168, 28);
            this.txtNit.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(440, 21);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(258, 28);
            this.txtApellido.TabIndex = 9;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(105, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(249, 28);
            this.txtNombre.TabIndex = 8;
            // 
            // lblTipo_P
            // 
            this.lblTipo_P.AutoSize = true;
            this.lblTipo_P.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo_P.Location = new System.Drawing.Point(642, 76);
            this.lblTipo_P.Name = "lblTipo_P";
            this.lblTipo_P.Size = new System.Drawing.Size(95, 19);
            this.lblTipo_P.TabIndex = 6;
            this.lblTipo_P.Text = "Tipo Pago:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(9, 76);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(93, 19);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNit.Location = new System.Drawing.Point(704, 30);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(35, 19);
            this.lblNit.TabIndex = 4;
            this.lblNit.Text = "Nit:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(360, 24);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(83, 19);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 21);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(81, 19);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // cmbVideo
            // 
            this.cmbVideo.HeaderText = "ID_Video";
            this.cmbVideo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbVideo.Name = "cmbVideo";
            // 
            // txtCantidad
            // 
            this.txtCantidad.HeaderText = "Cantidad";
            this.txtCantidad.Name = "txtCantidad";
            // 
            // txtPrecio
            // 
            this.txtPrecio.HeaderText = "Precio";
            this.txtPrecio.Name = "txtPrecio";
            // 
            // txtTot
            // 
            this.txtTot.HeaderText = "Total";
            this.txtTot.Name = "txtTot";
            // 
            // FormFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 653);
            this.Controls.Add(this.pnlcentral);
            this.Name = "FormFactura";
            this.Text = "FormFactura";
            this.pnlcentral.ResumeLayout(false);
            this.pnlcentral.PerformLayout();
            this.pnlFecha.ResumeLayout(false);
            this.pnlFecha.PerformLayout();
            this.pnlDetalle_F.ResumeLayout(false);
            this.pnlDetalle_F.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDetalle)).EndInit();
            this.pnlencabezado.ResumeLayout(false);
            this.pnlencabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlcentral;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlencabezado;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cboTipo_P;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo_P;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNit;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel pnlDetalle_F;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTitulo_Total;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dtgDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBuscar_Deta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblId_Enca;
        private System.Windows.Forms.Label lblSeleccionar;
        private System.Windows.Forms.ComboBox cboBuscar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblId_detalle;
        private System.Windows.Forms.TextBox txtId_Empleado;
        private System.Windows.Forms.Label lblId_Epleado;
        private System.Windows.Forms.TextBox txtId_Cliente;
        private System.Windows.Forms.Label lblId_Cliente;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSub_Total;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbVideo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTot;
    }
}