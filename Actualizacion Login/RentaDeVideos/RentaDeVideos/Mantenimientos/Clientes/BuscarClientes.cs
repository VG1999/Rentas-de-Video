using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RentaDeVideos.Clases;
using System.Data.Odbc;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class BuscarClientes : Form
    {
        public BuscarClientes()
        {
            InitializeComponent();
            CargarDatos();
        }

        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fig = new FormularioIngreso_Cliente();
            fig.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoClientes ic = new IngresoClientes();
            ic.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            FormularioInicioMenu fim = new FormularioInicioMenu();
            fim.Show();
            this.Hide();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void CargarDatos()
        {
            string cadena = "SELECT * FROM cliente";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbColumna.Text == "ID")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE id_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "ID Membresia")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE id_membresia_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "DPI")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE dpi_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "NIT")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE nit_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Nombre")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE nombre_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Apellido")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE apellido_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Correo")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE correo_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Telefono")
            {
                datos = new OdbcDataAdapter("SELECT * FROM cliente WHERE telefono_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
        }
    }
}
