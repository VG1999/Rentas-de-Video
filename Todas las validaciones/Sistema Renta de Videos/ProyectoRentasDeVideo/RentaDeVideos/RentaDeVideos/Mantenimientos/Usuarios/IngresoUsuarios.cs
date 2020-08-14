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
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.Usuarios
{
    public partial class IngresoUsuarios: Form
    {
        public IngresoUsuarios()
        {
            InitializeComponent();
        }

        Conexion cn=new Conexion();

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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Usuario fu = new FormularioIngreso_Usuario();
            fu.Show();
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
            ActualizarEliminarUsuarios aeu = new ActualizarEliminarUsuarios();
            aeu.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            this.Hide();
            bu.Show();
        }

        void insertarUsuario()
        {
           string cadena = "INSERT INTO control_usuario (usuario,contrasenia, rol,estado) VALUES ('"+txtUsuario.Text+"', MD5('"+txtPassword.Text+"'),'"+txtRol.Text+"',1);";
           OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
           consulta.ExecuteNonQuery();
        }
        void borraDatos()
        {
            txtPassword.Text = "";
            txtRol.Text = "";
            txtUsuario.Text = "";
        }

        private bool validarTextbox()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return false;
            }
            if (txtRol.Text == "")
            {
                MessageBox.Show("Ingrese Rol", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRol.Text = "";
                txtRol.Focus();
                return false;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese Contraseña", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            else if (!Regex.Match(txtUsuario.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo usuario invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return false;
            }
            else if (!Regex.Match(txtRol.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo rol invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRol.Text = "";
                txtRol.Focus();
                return false;
            }
            else if (!Regex.Match(txtPassword.Text, @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$").Success)
            {
                MessageBox.Show("Datos del campo contraseña invalido. ", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarTextbox() == true)
                {
                    insertarUsuario();
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    borraDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void txtRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter)&& cCaracter != 8)
            {
                e.Handled = true;
            }
            txtRol.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtRol.Text);
            txtRol.SelectionStart = txtRol.Text.Length;
        }
    }
}
