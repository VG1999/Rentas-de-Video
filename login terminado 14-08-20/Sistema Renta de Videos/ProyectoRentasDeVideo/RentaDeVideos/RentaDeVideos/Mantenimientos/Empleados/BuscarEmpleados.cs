using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class BuscarEmpleados : Form
    {
        public BuscarEmpleados()
        {
            InitializeComponent();
            try
            {
                CargarDatos();
            }
            catch (Exception)
            {

                throw;
            }

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
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void CargarDatos()
        {
            string cadena = "SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE estado=1";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE id_empleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "ID Cargo")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE id_cargo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "ID Usuario")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE id_usuario='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "DPI")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE dpi='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "NIT")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE nit='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Nombre")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Apellido")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE apellido='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Correo")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE correo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Telefono")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE telefono='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Direccion")
                {
                    datos = new OdbcDataAdapter("SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE direccion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
