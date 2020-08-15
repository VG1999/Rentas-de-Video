namespace RentaDeVideos.Reportes.FormulariosReportes
{
    partial class formularioReporteClientes
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
            this.pnlPantalla = new System.Windows.Forms.Panel();
            this.btnMostrarInforme = new System.Windows.Forms.Button();
            this.rptClientes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlPantalla.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPantalla
            // 
            this.pnlPantalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.pnlPantalla.Controls.Add(this.btnMostrarInforme);
            this.pnlPantalla.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPantalla.Location = new System.Drawing.Point(0, 0);
            this.pnlPantalla.Name = "pnlPantalla";
            this.pnlPantalla.Size = new System.Drawing.Size(1045, 101);
            this.pnlPantalla.TabIndex = 0;
            // 
            // btnMostrarInforme
            // 
            this.btnMostrarInforme.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarInforme.Location = new System.Drawing.Point(751, 26);
            this.btnMostrarInforme.Name = "btnMostrarInforme";
            this.btnMostrarInforme.Size = new System.Drawing.Size(251, 46);
            this.btnMostrarInforme.TabIndex = 0;
            this.btnMostrarInforme.Text = "Mostrar Informe";
            this.btnMostrarInforme.UseVisualStyleBackColor = true;
            this.btnMostrarInforme.Click += new System.EventHandler(this.btnMostrarInforme_Click);
            // 
            // rptClientes
            // 
            this.rptClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptClientes.Location = new System.Drawing.Point(0, 101);
            this.rptClientes.Name = "rptClientes";
            this.rptClientes.Size = new System.Drawing.Size(1045, 630);
            this.rptClientes.TabIndex = 1;
            // 
            // formularioReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 731);
            this.Controls.Add(this.rptClientes);
            this.Controls.Add(this.pnlPantalla);
            this.Name = "formularioReporteClientes";
            this.Text = "formularioReporteClientes";
            this.Load += new System.EventHandler(this.formularioReporteClientes_Load);
            this.pnlPantalla.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPantalla;
        private System.Windows.Forms.Button btnMostrarInforme;
        private Microsoft.Reporting.WinForms.ReportViewer rptClientes;
    }
}