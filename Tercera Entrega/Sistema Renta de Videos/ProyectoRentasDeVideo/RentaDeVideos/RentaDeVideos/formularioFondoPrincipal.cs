using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos
{
    public partial class formularioFondoPrincipal : Form
    {
        public formularioFondoPrincipal()
        {
            InitializeComponent();
        }

     

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje= MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void categoriaVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.CategoriaVideos.FormularioIngreso_CatVideo categoria = new Mantenimientos.CategoriaVideos.FormularioIngreso_CatVideo();
            categoria.Show();
        }

        private void videosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Videos.FormularioIngreso_Video video = new Mantenimientos.Videos.FormularioIngreso_Video();
            video.Show();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Cargos.FormularioIngreso_Cargo cargo = new Mantenimientos.Cargos.FormularioIngreso_Cargo();
            cargo.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Empleados.FormularioIngreso_Empleado empleado = new Mantenimientos.Empleados.FormularioIngreso_Empleado();
            empleado.Show();
        }

        private void membresiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.ControlMembresias.FormularioIngreso_Membresia membresia = new Mantenimientos.ControlMembresias.FormularioIngreso_Membresia();
            membresia.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Clientes.FormularioIngreso_Cliente cliente = new Mantenimientos.Clientes.FormularioIngreso_Cliente();
            cliente.Show();
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mantenimientos.Proveedores.FormularioIngreso_Proveedor proveedor = new Mantenimientos.Proveedores.FormularioIngreso_Proveedor();
            proveedor.Show();
        }

        private void controlUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Usuarios.FormularioIngreso_Usuario usuario = new Mantenimientos.Usuarios.FormularioIngreso_Usuario();
            usuario.Show();
        }

        private void informeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.FormulariosReportes.formularioReporteClientes reporte_cliente = new Reportes.FormulariosReportes.formularioReporteClientes();
            reporte_cliente.Show();
        }

        private void informeBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.FormulariosReportes.formularioReporteBitacora bitacora = new Reportes.FormulariosReportes.formularioReporteBitacora();
            bitacora.Show();
        }
    }
}
