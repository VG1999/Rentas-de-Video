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
using System.Text.RegularExpressions;
using RentaDeVideos.Clases;
using System.Data.Odbc;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class IngresoClientes : Form
    {
        public IngresoClientes()
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fic = new FormularioIngreso_Cliente();
            fic.Show();
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
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();
            bc.Show();
            this.Hide();
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblApellidos_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMembresia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }
        void insertarClientes()
        {
            string cadena = "INSERT INTO cliente (id_membresia_cliente, dpi_cliente, nit_cliente, nombre_cliente, apellido_cliente, telefono_cliente, correo_cliente, estado) VALUES ('" + txtMembresia.Text +"','"+txtDPI.Text+"','"+txtNIT.Text+"','"+ txtNombre.Text+"','"+txtApellidos.Text+"','"+txtTelefono.Text+"','"+txtCorreo.Text+"', 1);";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == ""||txtApellidos.Text==""||txtCorreo.Text==""||txtDPI.Text==""||txtMembresia.Text==""||txtNIT.Text==""||txtTelefono.Text=="")
            {
                MessageBox.Show("Por favor llene los campos requeridos", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VaciarText();
                txtNombre.Focus();
                return;
            }
            else if(!Regex.Match(txtNombre.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo nombre invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VaciarText();
                txtNombre.Focus();
                return;
            }
            else if (!Regex.Match(txtApellidos.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo apellido invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VaciarText();
                txtApellidos.Focus();
                return;
            }
            else if (!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VaciarText();
                txtTelefono.Focus();
                return;
            }
            else
            {
                insertarClientes();
                VaciarText();
            }
        }
        void VaciarText()
        {
            txtMembresia.Text = "";
            txtDPI.Text = "";
            txtNIT.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }
    }
}
