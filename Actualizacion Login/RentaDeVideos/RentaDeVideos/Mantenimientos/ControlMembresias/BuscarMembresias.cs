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

namespace RentaDeVideos.Mantenimientos.ControlMembresias
{
    public partial class BuscarMembresias : Form
    {
        public BuscarMembresias()
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

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Membresia form = new FormularioIngreso_Membresia();
            form.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoMembresias icv = new IngresoMembresias();
            icv.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarMembresias aecv = new ActualizarEliminarMembresias();
            aecv.Show();
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
            string cadena = "SELECT * FROM membresia";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbColumna.Text == "ID")
            {
                datos = new OdbcDataAdapter("SELECT id_membresia, descripcion_membresia, puntos_membresia, descuento_membresia FROM membresia WHERE id_membresia='" + txtBuscar.Text + "' AND estado_membresia=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Descripcion")
            {
                datos = new OdbcDataAdapter("SELECT id_membresia, descripcion_membresia, puntos_membresia, descuento_membresia FROM membresia WHERE descripcion_membresia='" + txtBuscar.Text + "' AND estado_membresia=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Puntos")
            {
                datos = new OdbcDataAdapter("SELECT id_membresia, descripcion_membresia, puntos_membresia, descuento_membresia FROM membresia WHERE puntos_membresia='" + txtBuscar.Text + "' AND estado_membresia=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Descuento")
            {
                datos = new OdbcDataAdapter("SELECT id_membresia, descripcion_membresia, puntos_membresia, descuento_membresia FROM membresia WHERE descuento_membresia='" + txtBuscar.Text + "' AND estado_membresia=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
        }
    }
}
