/*
 Formulario que controla el ingreso de datos a la BD en la tabla categoria
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
using RentaDeVideos.Clases;
using System.Data.Odbc;
using System.Net;

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class IngresoCatVideos: Form
    {
        //Toma valor de id del usuario logueado
        int iUsuario = Users.id_usario;
        public IngresoCatVideos()
        {
            InitializeComponent();
        }

        Conexion cn = new Conexion();
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
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_CatVideo form = new FormularioIngreso_CatVideo();
            form.Show();
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
            ActualizarEliminarCatVideos aecv = new ActualizarEliminarCatVideos();
            aecv.Show();
            this.Hide();
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCatVideos bcv = new BuscarCatVideos();
            bcv.Show();
            this.Hide();
        }
        //Insercion de datos a tabla y a bitacora
        private bool insertarCategorias()
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
                string cadena = "INSERT INTO categoria_video (nombre, estado) VALUES ('" + txtNombre.Text + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CATEGORIA_VIDEOS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
                return true;
            }
            catch (Exception  ex)
            {
                Console.WriteLine(ex.Message);
                txtNombre.Text = "";
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            
        }
        //Guardar datos, validar y limpiar componentes
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Llene el campo nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
            }
            else
            {
                if (insertarCategorias() == true)
                {
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = "";
                }
                else
                {
                    MessageBox.Show("Datos No se pudieron guardar intentelo de nuevo", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = "";
                    txtNombre.Focus();
                }

            }
        }
    }
}
