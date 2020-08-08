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

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class BuscarEmpleados : Form
    {
        public BuscarEmpleados()
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Empleado fic = new FormularioIngreso_Empleado();
            fic.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoEmpleados ic = new IngresoEmpleados();
            ic.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarEmpleados aec = new ActualizarEliminarEmpleados();
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
            string cadena = "SELECT * FROM empleado";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbColumna.Text == "ID")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE id_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "ID Cargo")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE id_cargo_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "ID Usuario")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE id_usuario_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "DPI")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE dpi_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "NIT")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE nit_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Nombre")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE nombre_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Apellido")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE apellido_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Correo")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE corre_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Telefono")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE telefono_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Direccion")
            {
                datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE direccion_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
        }
    }
}
