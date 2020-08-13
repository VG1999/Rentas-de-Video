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
using System.Data.Odbc;
using RentaDeVideos.Clases;

namespace RentaDeVideos.Mantenimientos.ControlMembresias
{
    public partial class IngresoMembresias: Form
    {
        public IngresoMembresias()
        {
            InitializeComponent();
        }

        Conexion cn = new Conexion();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Membresia form = new FormularioIngreso_Membresia();
            form.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            FormularioInicioMenu fim = new FormularioInicioMenu();
            fim.Show();
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
            BuscarMembresias bcv = new BuscarMembresias();
            bcv.Show();
            this.Hide();
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescuentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        void borraDatos()
        {
            txtDescuentos.Text = "";
            txtDescripcion.Text = "";
            txtPuntos.Text = "";
        }

        private bool validarTextbox()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Ingrese Descripcion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Text = "";
                txtDescripcion.Focus();
                return false;
            }
            return true;

        }

        void insertarMembresias()
        {
            string cadena = "INSERT INTO membresia (descripcion, puntos, descuento, estado) VALUES ('" + txtDescripcion.Text + "','" + txtPuntos.Text + "','" + txtDescuentos.Text + "',1);";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarTextbox() == true)
                {
                    insertarMembresias();
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    borraDatos();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
