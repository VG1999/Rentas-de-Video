namespace RentaDeVideos
{
    partial class ReportesDeFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesDeFactura));
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.picMinimizar = new System.Windows.Forms.PictureBox();
            this.ReporteFacturas1 = new RentaDeVideos.ReporteFacturas();
            this.pnlBarra.SuspendLayout();
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
            this.pnlBarra.Size = new System.Drawing.Size(1149, 55);
            this.pnlBarra.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 55);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.ReporteFacturas1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1149, 553);
            this.crystalReportViewer1.TabIndex = 3;
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSalir.Image = ((System.Drawing.Image)(resources.GetObject("picSalir.Image")));
            this.picSalir.Location = new System.Drawing.Point(1113, 12);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(24, 24);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSalir.TabIndex = 8;
            this.picSalir.TabStop = false;
            // 
            // picMinimizar
            // 
            this.picMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("picMinimizar.Image")));
            this.picMinimizar.Location = new System.Drawing.Point(1067, 12);
            this.picMinimizar.Name = "picMinimizar";
            this.picMinimizar.Size = new System.Drawing.Size(24, 24);
            this.picMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMinimizar.TabIndex = 7;
            this.picMinimizar.TabStop = false;
            // 
            // ReportesDeFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 608);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.pnlBarra);
            this.Name = "ReportesDeFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesDeFactura";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.PictureBox picSalir;
        private System.Windows.Forms.PictureBox picMinimizar;
        private ReporteFacturas ReporteFacturas1;
    }
}