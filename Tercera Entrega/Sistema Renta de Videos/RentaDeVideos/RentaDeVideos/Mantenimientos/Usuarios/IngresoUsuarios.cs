/*
 Formulario que controla el ingreso de datos a la BD en la tabla usuario
 */
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
using System.Net;
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.Usuarios
{
    public partial class IngresoUsuarios: Form
    {
        //Toma valor de id del usuario logueado
        int iUsuario = Users.id_usario;
        public IngresoUsuarios()
        {
            InitializeComponent();
            cmbRol.SelectedIndex = 0;
        }

        Conexion cn=new Conexion();
        //Permite el arrastre del formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Salida del formulario con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Minimizar formulario
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Menu lateral se desplaza
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }
        //Arratre del formulario por medio de panel superior
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Ir a formulario principal
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Usuario fu = new FormularioIngreso_Usuario();
            fu.Show();
            this.Hide();
        }
        //Mensaje de advertencia cuando el usuario trate de abrir formulario actual
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
        //Salida sin validacion
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Ir a formulario Actualizacion y Eliminacion
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarUsuarios aeu = new ActualizarEliminarUsuarios();
            aeu.Show();
            this.Hide();
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            this.Hide();
            bu.Show();
        }
        //Insercion de datos a tabla y a bitacora
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

                string cadena = "INSERT INTO control_usuario (usuario,contrasenia, rol,estado) VALUES ('" + txtUsuario.Text + "','" + txtPassword.Text + "','" + cmbRol.SelectedItem.ToString() + "',1);";
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
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        //Limpia componetes, posterior al guardado
        void borraDatos()
        {
            txtPassword.Text = "";
            cmbRol.SelectedIndex = 0;
            txtUsuario.Text = "";
        }
        //Validacion de componentes, a ingresar
        private bool validarTextbox()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return false;
            }
            if (cmbRol.SelectedIndex==0)
            {
                MessageBox.Show("Ingrese Rol", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRol.SelectedItem = 0;
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
            else if (!Regex.Match(txtPassword.Text, @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$").Success)
            {
                MessageBox.Show("Datos del campo contraseña invalido. ", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            return true;

        }
        //Guardar datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarUsuario();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borraDatos();
            }

        }
    }
}
