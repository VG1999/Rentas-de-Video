using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Usuarios
{
    public partial class IngresoUsuarios : Form
    {
        int iUsuario = 1;
        public IngresoUsuarios()
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
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
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
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
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
            try
            {
                IPHostEntry host_ip;
                string sLocalIP = "?";
                host_ip = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host_ip.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        sLocalIP = ip.ToString();
                    }
                }

            
                string cadena = "INSERT INTO control_usuario (usuario,contrasenia, rol,estado) VALUES ('" + txtUsuario.Text + "', '" + txtPassword.Text + "','" + txtRol.Text + "',1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "USUARIOS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void borraDatos()
        {
            txtPassword.Text = string.Empty;
            txtRol.Text = string.Empty;
            txtUsuario.Text = string.Empty;
        }

        private bool validarTextbox()
        {
            if (txtUsuario.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = string.Empty;
                txtUsuario.Focus();
                return false;
            }
            if (txtRol.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Rol", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRol.Text = string.Empty;
                txtRol.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Contraseña", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
                return false;
            }
            else if (!Regex.Match(txtUsuario.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo usuario invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = string.Empty;
                txtUsuario.Focus();
                return false;
            }
            else if (!Regex.Match(txtRol.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo rol invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRol.Text = string.Empty;
                txtRol.Focus();
                return false;
            }
            else if (!Regex.Match(txtPassword.Text, @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$").Success)
            {
                MessageBox.Show("Datos del campo contraseña invalido. ", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarUsuario();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borraDatos();
            }

        }

        private void txtRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
            txtRol.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtRol.Text);
            txtRol.SelectionStart = txtRol.Text.Length;
        }
    }

    
}
