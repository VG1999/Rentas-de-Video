﻿/*
 Formulario Principal de programa, direcciona a otros formularios
 */
using RentaDeVideos.Clases;
using RentaDeVideos.Procesos.ControlDevoluciones;
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
            ReporteClientes repclientes = new ReporteClientes();
            repclientes.Show();
        }
        //ir a bitacora
        private void informeBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesBitacora bitacora = new ReportesBitacora();
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

        private void informeRentaPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRentaporCategoria rentaporcat = new ReporteRentaporCategoria();
            rentaporcat.Show();
        }

        private void informeRentaPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVideoRentadoCliente rentaporcliente = new ReporteVideoRentadoCliente();
            rentaporcliente.Show();
        }

        private void informeRentaPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRentaPorFecha rentafecha = new ReporteRentaPorFecha();
            rentafecha.Show();
        }

        private void reporteDeGananciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteDeGanancias ganancias = new ReporteDeGanancias();
            ganancias.Show();
        }

        private void reporteDeRentasPorUltimaVisitaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteRentaVisitaCliente visita = new ReporteRentaVisitaCliente();
            visita.Show();
        }

        private void reportesDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesDeFactura factura = new ReportesDeFactura();
            factura.Show();
        }

        private void historialDePagoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesHistorialPago historial = new ReportesHistorialPago();
            historial.Show();
        }

        private void ingresoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ControlDevolucion devolucion = new ControlDevolucion();
            devolucion.Show();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudasProyecto/AyudasRentas.chm", "Login.html");
        }
    }
}
