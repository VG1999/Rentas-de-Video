using RentaDeVideos.Clases;
using System;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
    
        //Se genera la conexion a la BD (se llama a la clase que tiene los metodos para la conexion de la BD)
        Conexion cn = new Conexion();

        // Me permite arrastar el fomulario por toda la pantalla
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Cuando el se ingrese el usuario las letras del textbox cambiaran a color negro
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = string.Empty;
                txtUsuario.ForeColor = Color.Black;
            }
        }

      //Cuando no haya nada ingresedo las letras del textbox cambiaran a color blanco
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.White;
            }
        }

        // fin del todo proceso de validacion de usuario aqui me veficara si todos los datos son correctos segun la respuesta que se decir
        // asi se abrira el formularioFondoPrincipal 
        public void ingreso()
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;

            try
            {
                Clases.Control ctrl = new Clases.Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    formularioFondoPrincipal frm = new formularioFondoPrincipal ();
                    frm.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        //Cuando el se ingrese el password las letras del textbox cambiaran a color negro
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = string.Empty;
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }


        //Cuando no haya nada ingresedo las letras del textbox cambiaran a color blanco
        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == string.Empty)
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        //Me da las medidas exactas para poder arrastar el formulario
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormLogin_Click(object sender, EventArgs e)
        {

        }

        //Me permite minimizar la ventana
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Me permite cerrar pero antes realiza una pregunta al usuario para verificar si realmente quiere salir
        private void picCerrar_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // se hace el llamdo a la funcion ingresar al boton de ingreso
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ingreso();
        }
    }
}
