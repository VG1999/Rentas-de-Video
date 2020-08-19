/*
 Formulario que controla el ingreso de datos a la BD en la tabla estado video
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
using System.Net;
using System.Data.Odbc;
using RentaDeVideos.Clases;
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.EstadosVideos
{
    public partial class IngresoEstado: Form
    {
        Conexion cn = new Conexion();
        //Toma valor de id del usuario logueado
        int iUsuario = Users.id_usario;

        public IngresoEstado()
        {
            InitializeComponent();
        }
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
        private void btnEstados_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Estado fic = new FormularioIngreso_Estado();
            fic.Show();
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
            ActualizarEliminarEstado aec = new ActualizarEliminarEstado();
            aec.Show();
            this.Hide();
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEstado bc = new BuscarEstado();
            bc.Show();
            this.Hide();
        }
        //Solo ingreso de numeros
        private void txtMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32 && cCaracter != 46)
            {
                e.Handled = true;
            }
        }
        //Insercion de datos a tabla y a bitacora
        void insertarVideos()
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

                string cadena = "INSERT INTO video_estado (multa_unitaria, descripcion, estado) VALUES ('" + txtMulta.Text + "','" + txtEstado.Text + "',1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "VIDEOS_ESTADO";
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
            txtMulta.Text = "";
            txtEstado.Text = "";

        }
        //Validacion de componentes, a ingresar
        private bool validarTextbox()
        {
            if (txtEstado.Text == "")
            {
                MessageBox.Show("Ingrese Estado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEstado.Text = "";
                txtEstado.Focus();
                return false;
            }
            if (txtMulta.Text == "")
            {
                MessageBox.Show("Ingrese Multa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMulta.Text = "";
                return false;
            }
            if (!Regex.Match(txtMulta.Text, @"^[0-9]+[.][0-9]{2}$").Success)
            {
                MessageBox.Show("Datos del campo precio invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMulta.Text = "";
                txtMulta.Focus();
                return false;
            }
            return true;

        }
        //Guardar datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarVideos();
                borraDatos();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEstado.Focus();
            }
        }
    }
}
