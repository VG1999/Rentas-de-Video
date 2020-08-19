/*
 Busqueda de factura
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

namespace RentaDeVideos.Procesos.Facturas
{
    public partial class ManBusquedaFactura : Form
    {
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        public ManBusquedaFactura()
        {
            InitializeComponent();
            CargarDatos();
        }
        //Carga datos a grid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE estado=1";
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
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Salir con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Busqueda con combobox y textbox
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE id_encabezado_factura='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "ID CLIENTE")
                {
                    datos = new OdbcDataAdapter("SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE id_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "NO SERIE")
                {
                    datos = new OdbcDataAdapter("SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE no_serie='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "FECHA")
                {
                    datos = new OdbcDataAdapter("SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE fecha='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
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
        //Ir a eliminar
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MantenimientoFacturas eliminar = new MantenimientoFacturas();
            eliminar.Show();
            this.Dispose();
        }
        //Mensaje de advertencia si el usuario abre formulario actual
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
