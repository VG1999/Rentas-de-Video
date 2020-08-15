using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RentaDeVideos.Clases;
using System.Data.Odbc;

namespace RentaDeVideos.Reportes.FormulariosReportes
{
    public partial class formularioReporteClientes : Form
    {
        Conexion cn;
        public formularioReporteClientes()
        {
            InitializeComponent();
            cn= new Conexion();
        }

        private void formularioReporteClientes_Load(object sender, EventArgs e)
        {

            this.rptClientes.RefreshReport();
        }

        private void btnMostrarInforme_Click(object sender, EventArgs e)
        {
            string sConsulta = "select cl.id_cliente, cl.nombre, cl.apellido, cl.nit, cl.correo, cl.telefono, me.descripcion from cliente cl inner join membresia me on cl.id_membresia = me.id_membresia where cl.estado = 1";
            OdbcDataAdapter data_adapter = new OdbcDataAdapter(sConsulta, cn.conexion());
            DataSet data_set_cliente = new DataSet();
            data_adapter.Fill(data_set_cliente);

            ReportDataSource fuente;
            fuente = new ReportDataSource("dataSet_Cliente", data_set_cliente.Tables[0]);

            rptClientes.LocalReport.DataSources.Clear();
            rptClientes.LocalReport.DataSources.Add(fuente);
            rptClientes.LocalReport.ReportEmbeddedResource = "RentaDeVideos.Reportes.ReportesDiseño.reporteCliente.rdlc";
            rptClientes.LocalReport.Refresh();
            rptClientes.Refresh();
            rptClientes.RefreshReport();

        }
    }
}
