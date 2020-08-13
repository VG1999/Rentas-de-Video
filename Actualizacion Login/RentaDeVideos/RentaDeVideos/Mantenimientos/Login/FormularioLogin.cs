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


namespace RentaDeVideos.Mantenimientos.Login
{

    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        Conexion cn = new Conexion();
        bool cambios = false;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FormularioInicioMenu form = new FormularioInicioMenu();
            form.Show();
            this.Hide();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           // string cadena = "select *from control_usuario where usuario "="''");
         //   OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
           // consulta.ExecuteNonQuery();
        }
    

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if(txtNombre.Text == "USUARIO")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.Black;
            }


        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "USUARIO";
                txtNombre.ForeColor = Color.White;
            }
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "CONTRASEÑA")
            {
                txtContrasenia.Text = "";
                txtContrasenia.ForeColor = Color.Black;
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "CONTRASEÑA";
                txtContrasenia.ForeColor = Color.White;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           if( MessageBox.Show("Desea salir de la aplicacion","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                e.Cancel = true; // Permite que no se cierre el form 
            }
            
        }
    }
}
