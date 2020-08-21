namespace RentaDeVideos.Procesos.ControlDevoluciones
{
    partial class ControlDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlDevolucion));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.gboxDatosDev = new System.Windows.Forms.GroupBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.lblFecDev = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMulta = new System.Windows.Forms.Label();
            this.gboxDatosFac = new System.Windows.Forms.GroupBox();
            this.cmbVideos = new System.Windows.Forms.ComboBox();
            this.cmbFactura = new System.Windows.Forms.ComboBox();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.lblFecFac = new System.Windows.Forms.Label();
            this.lblNIT = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.dpFechaFac = new System.Windows.Forms.DateTimePicker();
            this.dpFechaDev = new System.Windows.Forms.DateTimePicker();
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).BeginInit();
            this.pnlCuerpo.SuspendLayout();
            this.gboxDatosDev.SuspendLayout();
            this.gboxDatosFac.SuspendLayout();
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
            this.pnlBarra.Size = new System.Drawing.Size(1076, 64);
            this.pnlBarra.TabIndex = 1;
            this.pnlBarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBarra_MouseDown);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(1027, 24);
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
            this.picMinimizar.Location = new System.Drawing.Point(981, 24);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 5;
            this.picMinimizar.TabStop = false;
            this.picMinimizar.Click += new System.EventHandler(this.picMinimizar_Click);
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.btnRegistrar);
            this.pnlCuerpo.Controls.Add(this.gboxDatosDev);
            this.pnlCuerpo.Controls.Add(this.gboxDatosFac);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 64);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Size = new System.Drawing.Size(1076, 492);
            this.pnlCuerpo.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(835, 318);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(216, 89);
            this.btnRegistrar.TabIndex = 10;
            this.btnRegistrar.Text = "Registrar Devolución";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // gboxDatosDev
            // 
            this.gboxDatosDev.Controls.Add(this.dpFechaDev);
            this.gboxDatosDev.Controls.Add(this.cmbEstado);
            this.gboxDatosDev.Controls.Add(this.txtMulta);
            this.gboxDatosDev.Controls.Add(this.lblFecDev);
            this.gboxDatosDev.Controls.Add(this.lblEstado);
            this.gboxDatosDev.Controls.Add(this.lblMulta);
            this.gboxDatosDev.Location = new System.Drawing.Point(35, 267);
            this.gboxDatosDev.Name = "gboxDatosDev";
            this.gboxDatosDev.Size = new System.Drawing.Size(765, 181);
            this.gboxDatosDev.TabIndex = 9;
            this.gboxDatosDev.TabStop = false;
            this.gboxDatosDev.Text = "Datos de Devolución";
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(223, 126);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(205, 31);
            this.cmbEstado.TabIndex = 12;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // txtMulta
            // 
            this.txtMulta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMulta.Enabled = false;
            this.txtMulta.Location = new System.Drawing.Point(571, 125);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.Size = new System.Drawing.Size(175, 32);
            this.txtMulta.TabIndex = 9;
            // 
            // lblFecDev
            // 
            this.lblFecDev.AutoSize = true;
            this.lblFecDev.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecDev.Location = new System.Drawing.Point(17, 51);
            this.lblFecDev.Name = "lblFecDev";
            this.lblFecDev.Size = new System.Drawing.Size(190, 23);
            this.lblFecDev.TabIndex = 5;
            this.lblFecDev.Text = "Fecha Devolucion";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(17, 129);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(141, 23);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado Video";
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulta.Location = new System.Drawing.Point(474, 129);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(65, 23);
            this.lblMulta.TabIndex = 7;
            this.lblMulta.Text = "Multa";
            // 
            // gboxDatosFac
            // 
            this.gboxDatosFac.Controls.Add(this.dpFechaFac);
            this.gboxDatosFac.Controls.Add(this.cmbVideos);
            this.gboxDatosFac.Controls.Add(this.cmbFactura);
            this.gboxDatosFac.Controls.Add(this.txtNIT);
            this.gboxDatosFac.Controls.Add(this.txtNombre);
            this.gboxDatosFac.Controls.Add(this.lblFactura);
            this.gboxDatosFac.Controls.Add(this.lblFecFac);
            this.gboxDatosFac.Controls.Add(this.lblNIT);
            this.gboxDatosFac.Controls.Add(this.lblCliente);
            this.gboxDatosFac.Controls.Add(this.lblVideo);
            this.gboxDatosFac.Location = new System.Drawing.Point(35, 25);
            this.gboxDatosFac.Name = "gboxDatosFac";
            this.gboxDatosFac.Size = new System.Drawing.Size(971, 204);
            this.gboxDatosFac.TabIndex = 8;
            this.gboxDatosFac.TabStop = false;
            this.gboxDatosFac.Text = "Datos de Facturacion";
            // 
            // cmbVideos
            // 
            this.cmbVideos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideos.FormattingEnabled = true;
            this.cmbVideos.Location = new System.Drawing.Point(752, 115);
            this.cmbVideos.Name = "cmbVideos";
            this.cmbVideos.Size = new System.Drawing.Size(193, 31);
            this.cmbVideos.TabIndex = 12;
            // 
            // cmbFactura
            // 
            this.cmbFactura.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFactura.FormattingEnabled = true;
            this.cmbFactura.Location = new System.Drawing.Point(165, 39);
            this.cmbFactura.Name = "cmbFactura";
            this.cmbFactura.Size = new System.Drawing.Size(205, 31);
            this.cmbFactura.TabIndex = 11;
            this.cmbFactura.SelectedIndexChanged += new System.EventHandler(this.cmbFactura_SelectedIndexChanged);
            // 
            // txtNIT
            // 
            this.txtNIT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNIT.Enabled = false;
            this.txtNIT.Location = new System.Drawing.Point(364, 114);
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(175, 32);
            this.txtNIT.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(113, 114);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(175, 32);
            this.txtNombre.TabIndex = 6;
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(17, 41);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(125, 23);
            this.lblFactura.TabIndex = 0;
            this.lblFactura.Text = "No. Factura";
            // 
            // lblFecFac
            // 
            this.lblFecFac.AutoSize = true;
            this.lblFecFac.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecFac.Location = new System.Drawing.Point(408, 47);
            this.lblFecFac.Name = "lblFecFac";
            this.lblFecFac.Size = new System.Drawing.Size(195, 23);
            this.lblFecFac.TabIndex = 4;
            this.lblFecFac.Text = "Fecha Facturación";
            // 
            // lblNIT
            // 
            this.lblNIT.AutoSize = true;
            this.lblNIT.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.Location = new System.Drawing.Point(310, 114);
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Size = new System.Drawing.Size(38, 23);
            this.lblNIT.TabIndex = 2;
            this.lblNIT.Text = "NIT";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(17, 114);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(90, 23);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Nombre";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideo.Location = new System.Drawing.Point(567, 117);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(168, 23);
            this.lblVideo.TabIndex = 3;
            this.lblVideo.Text = "Video Adquirido";
            // 
            // dpFechaFac
            // 
            this.dpFechaFac.Enabled = false;
            this.dpFechaFac.Location = new System.Drawing.Point(621, 47);
            this.dpFechaFac.Name = "dpFechaFac";
            this.dpFechaFac.Size = new System.Drawing.Size(291, 32);
            this.dpFechaFac.TabIndex = 13;
            this.dpFechaFac.Value = new System.DateTime(2020, 8, 19, 18, 14, 59, 0);
            // 
            // dpFechaDev
            // 
            this.dpFechaDev.Location = new System.Drawing.Point(223, 51);
            this.dpFechaDev.Name = "dpFechaDev";
            this.dpFechaDev.Size = new System.Drawing.Size(205, 32);
            this.dpFechaDev.TabIndex = 13;
            // 
            // ControlDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 556);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlDevolucion";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.pnlCuerpo.ResumeLayout(false);
            this.gboxDatosDev.ResumeLayout(false);
            this.gboxDatosDev.PerformLayout();
            this.gboxDatosFac.ResumeLayout(false);
            this.gboxDatosFac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox gboxDatosDev;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.Label lblFecDev;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.GroupBox gboxDatosFac;
        private System.Windows.Forms.ComboBox cmbFactura;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Label lblFecFac;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbVideos;
        private System.Windows.Forms.Label lblVideo;
        private System.Windows.Forms.DateTimePicker dpFechaFac;
        private System.Windows.Forms.DateTimePicker dpFechaDev;
    }
}