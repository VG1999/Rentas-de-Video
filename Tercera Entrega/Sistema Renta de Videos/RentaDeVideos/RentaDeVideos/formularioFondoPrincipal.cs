/*
 Formulario Principal de programa, direcciona a otros formularios
 */
using RentaDeVideos.Clases;
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
        private string rol;
        public formularioFondoPrincipal()
        {
            InitializeComponent();

            lblNombre.Text = Users.usuario;
            rol = Users.rol;

            lblCodUser.Text = Users.id_usario.ToString();


            if (rol == "Administrador")
            {
                this.msMenuBarra.Visible = true;


            }
            else if (rol == "Empleado")
            {
                this.mantenimientoEmpleadosToolStripMenuItem.Visible = false;
                this.empleadosToolStripMenuItem.Visible = false;
                this.mantenamientoUsuariosToolStripMenuItem.Visible = false;
                this.proveedoresToolStripMenuItem.Visible = false;
                this.clientesToolStripMenuItem.Visible = false;
                this.comprasToolStripMenuItem.Visible = false;
                this.bitacoraToolStripMenuItem.Visible = false;
                this.informeClientesToolStripMenuItem.Visible = false;
            }
        }

        public void usarioNombre(string sNombre)
        {
            lblNombre.Text = sNombre;
        }

        //Salir con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje= MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //ir a categoria
        private void categoriaVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.CategoriaVideos.FormularioIngreso_CatVideo categoria = new Mantenimientos.CategoriaVideos.FormularioIngreso_CatVideo();
            categoria.Show();
        }
        //ir a videos
        private void videosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Videos.FormularioIngreso_Video video = new Mantenimientos.Videos.FormularioIngreso_Video();
            video.Show();
        }
        //ir a cargos
        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Cargos.FormularioIngreso_Cargo cargo = new Mantenimientos.Cargos.FormularioIngreso_Cargo();
            cargo.Show();
        }
        //ir a empleados
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Empleados.FormularioIngreso_Empleado empleado = new Mantenimientos.Empleados.FormularioIngreso_Empleado();
            empleado.Show();
        }
        //ir a membresia
        private void membresiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.ControlMembresias.FormularioIngreso_Membresia membresia = new Mantenimientos.ControlMembresias.FormularioIngreso_Membresia();
            membresia.Show();
        }
        //ir a clientes
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Clientes.FormularioIngreso_Cliente cliente = new Mantenimientos.Clientes.FormularioIngreso_Cliente();
            cliente.Show();
        }
        //ir a proveedores
        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mantenimientos.Proveedores.FormularioIngreso_Proveedor proveedor = new Mantenimientos.Proveedores.FormularioIngreso_Proveedor();
            proveedor.Show();
        }
        //ir a usaurios
        private void controlUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.Usuarios.FormularioIngreso_Usuario usuario = new Mantenimientos.Usuarios.FormularioIngreso_Usuario();
            usuario.Show();
        }
        //ir a informe clientes
        private void informeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Reportes.FormulariosReportes.formularioReporteClientes reporte_cliente = new Reportes.FormulariosReportes.formularioReporteClientes();
           // reporte_cliente.Show();
        }
        //ir a bitacora
        private void informeBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes.FormulariosReportes.formularioReporteBitacora bitacora = new Reportes.FormulariosReportes.formularioReporteBitacora();
            bitacora.Show();
        }
        //ir a estado video
        private void estadoVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimientos.EstadosVideos.FormularioIngreso_Estado video_estado = new Mantenimientos.EstadosVideos.FormularioIngreso_Estado();
            video_estado.Show();
        }
        //ir a facturas 
        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.Facturas.IngresoFactura factura = new Procesos.Facturas.IngresoFactura();
            factura.Show();
        }
        //ir a facturas mantenimiento
        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesos.Facturas.MantenimientoFacturas manfacturas = new Procesos.Facturas.MantenimientoFacturas();
            manfacturas.Show();
        }
        //ir a compras
        private void ingresoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Procesos.Compras.IngresoCompras compras = new Procesos.Compras.IngresoCompras();
            compras.Show();
        }
        //ir a compras mantenimiento
        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Procesos.Compras.MantenimientoCompras mancompras = new Procesos.Compras.MantenimientoCompras();
            mancompras.Show();
        }
    }
}
