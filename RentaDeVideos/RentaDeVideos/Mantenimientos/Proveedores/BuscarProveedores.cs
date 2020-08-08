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

namespace RentaDeVideos.Mantenimientos.Proveedores
{
    public partial class BuscarProveedores : Form
    {
        public BuscarProveedores()
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Proveedor fp = new FormularioIngreso_Proveedor();
            fp.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoProveedores ip = new IngresoProveedores();
            ip.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarProveedores aep = new ActualizarEliminarProveedores();
            aep.Show();
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
            string cadena = "SELECT * FROM proveedor";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbColumna.Text == "ID")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE id_proveedor='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Razon Social")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE rason_social='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Representante Legal")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE representante_legal='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "NIT")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE nit='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Telefono")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE telefono='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Correo")
            {
                datos = new OdbcDataAdapter("SELECT id_proveedor, razon_social, representante_legal, nit, telefono, correo FROM proveedor WHERE correo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
        }
    }
}
