using RentaDeVideos.Clases;
using RentaDeVideos.Mantenimientos.Clientes;
using System;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace RentaDeVideos.Mantenimientos.Login
{

    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        Conexion cn = new Conexion();
      

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        void ingresar()
        {
            try
            {
               
                string sql = "SELECT id_usuario,usuario,contrasenia,rol,estado FROM control_usuario where  usuario = '" + txtNombre.Text + "'and contrasenia =  '" + txtContrasenia.Text + "'";
                OdbcCommand comando = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader reader = comando.ExecuteReader();
                if (reader.Read())

                {
                FormularioInicioMenu form = new FormularioInicioMenu();
                form.Show();
                this.Hide();
            }

                else
                {
                MessageBox.Show("Usuario o contraseña incorrectas");
            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
           }
        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "USUARIO")
            {
                txtNombre.Text = string.Empty;
                txtNombre.ForeColor = Color.Black;
            }


        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                txtNombre.Text = "USUARIO";
                txtNombre.ForeColor = Color.White;
            }
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "CONTRASEÑA")
            {
                txtContrasenia.Text = string.Empty;
                txtContrasenia.ForeColor = Color.Black;
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == string.Empty)
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
            if (MessageBox.Show("Desea salir de la aplicacion", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // Permite que no se cierre el form 
            }

        }
    }
}
