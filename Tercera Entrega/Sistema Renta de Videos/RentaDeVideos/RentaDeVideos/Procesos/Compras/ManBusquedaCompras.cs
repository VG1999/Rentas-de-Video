/*
 Formulario de busqueda de compras
 */
using RentaDeVideos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Compras
{
    public partial class ManBusquedaCompras : Form
    {
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        public ManBusquedaCompras()
        {
            InitializeComponent();
            CargarDatos();
        }
        //Carga datos al grid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_compra, id_proveedor, fecha_compra, total_compra FROM encabezado_compra WHERE estado=1";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Busqueda mediante combobox que contiene las columas y el textbox de ingreso de campo a buscar
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT id_compra, id_proveedor, fecha_compra, total_compra FROM encabezado_compra WHERE id_compra='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "ID PROVEEDOR")
                {
                    datos = new OdbcDataAdapter("SELECT id_compra, id_proveedor, fecha_compra, total_compra FROM encabezado_compra WHERE id_proveedor='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "FECHA")
                {
                    datos = new OdbcDataAdapter("SELECT id_compra, id_proveedor, fecha_compra, total_compra FROM encabezado_compra WHERE fecha_compra='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "TOTAL")
                {
                    datos = new OdbcDataAdapter("SELECT id_compra, id_proveedor, fecha_compra, total_compra FROM encabezado_compra WHERE total_compra='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al buscar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Mensaje de advertencia si trata de acceder a formulario actual
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ir a formulario de mantenimientos
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MantenimientoCompras eliminar = new MantenimientoCompras();
            eliminar.Show();
            this.Dispose();
        }
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Sali con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
