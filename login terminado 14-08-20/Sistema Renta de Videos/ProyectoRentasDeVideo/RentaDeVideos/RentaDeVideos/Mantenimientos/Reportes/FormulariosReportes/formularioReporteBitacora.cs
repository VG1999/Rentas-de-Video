using Microsoft.Reporting.WinForms;
using RentaDeVideos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Reportes.FormulariosReportes
{
    public partial class formularioReporteBitacora : Form
    {
        Conexion cn;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public formularioReporteBitacora()
        {
            InitializeComponent();
            cn = new Conexion();
        }

        private void formularioReporteBitacora_Load(object sender, EventArgs e)
        {

            this.rptBitacora.RefreshReport();
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string sConsulta = " select b.id_usuario, u.usuario, b.tabla, b.actividad, b.fecha, b.host_ip from bitacora b inner join control_usuario u on b.id_usuario=u.id_usuario;";
            OdbcDataAdapter data_adapter = new OdbcDataAdapter(sConsulta, cn.conexion());
            DataSet data_set_bitacora = new DataSet();
            data_adapter.Fill(data_set_bitacora);

            ReportDataSource fuente;
            fuente = new ReportDataSource("dataSet_Bitacora", data_set_bitacora.Tables[0]);

            rptBitacora.LocalReport.DataSources.Clear();
            rptBitacora.LocalReport.DataSources.Add(fuente);
            rptBitacora.LocalReport.ReportEmbeddedResource = "RentaDeVideos.Reportes.ReportesDiseño.reporteBitacora.rdlc";
            rptBitacora.LocalReport.Refresh();
            rptBitacora.Refresh();
            rptBitacora.RefreshReport();
        }
    }
}
