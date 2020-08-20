/*
 Este codigo es necesario para el exitoso ingreso de datos en la tabla cargos, ademas cuenta con validaciones de ingreso de campos
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

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class IngresoCargos: Form
    {
        //Esta variable toma el valor de ID del usuario logueado
        int iUsuario = Users.id_usario;
        public IngresoCargos()
        {
            InitializeComponent();
        }

        Conexion cn = new Conexion();
        //Variables que se inicializan y permiten arrastrar y movilizar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        //Boton para salir del formulario pero se asegura con un mensaje que el usuario de verdad desee salir de el
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Boton de Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Permite que la barra lateral del menu se desplaze
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }
        //Toma las variables que permiten es deplazamiento, y el usuario cuando de click sobre la barra superior (panel) podra arrastrar el formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Permite direccionar hacia el formulario principal de cargos
        private void btnCargos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cargo fic = new FormularioIngreso_Cargo();
            fic.Show();
            this.Hide();
        }
        //Valida con un mensaje si el usuario trata de acceder al mismo formulario
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
        //Regresa y cierra formulario sin preguntar
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Direcciona al formulario de ACtualizacion y Eliminacion
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos();
            aec.Show();
            this.Hide();
        }
        
        //Direcciona al formulario Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCargos bc = new BuscarCargos();
            bc.Show();
            this.Hide();
        }
        //Valida que en el textbox Nombre no ingrese mas que letras, permite el backspace y el desplazamiento
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }
        //Se ingresa a la tabla y se ingresa bitacora
        private bool insertarCargos()
        {
            try
            {
                //Obtiene IP del HOST
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
                string cadena = "INSERT INTO cargo (nombre, descripcion, estado) VALUES ('" + txtNombre.Text + "','" + txtDescripcion.Text + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CARGOS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BorrarTextbox();
                return false;
            }
            
        }
        //Se validan los textos antes de guardar
        private bool validarTextbox()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("Llene la Descripcion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcion.Text = "";
                txtDescripcion.Focus();
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Llene el Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            if (txtNombre.Text == "" && txtDescripcion.Text == "")
            {
                MessageBox.Show("Llene los campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BorrarTextbox();
                return false;
            }
            return true;

        }
        //Se limpian los componentes despues de guardar
        void BorrarTextbox()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
        //Boton que permite guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true&&insertarCargos()==true)
            {
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BorrarTextbox();
            }
            else
            {
                MessageBox.Show("Datos No se pudieron guardar intentelo de nuevo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
