using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class IngresoCatVideos : Form
    {
        int iUsuario = 1;
        public IngresoCatVideos()
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

        //me permite ocultar la ventana del usario y me devulve un mensaje de alerta verificando si la accion es correcta
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        //Permite minimizar la ventana
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // nos da las medidas que va tomar el slide del formulario 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //me da las posiciones exacta hacia donde puedo mover o arrastrar mi formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Me permite abrir la venta al ingreso de la categoria de video 
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_CatVideo form = new FormularioIngreso_CatVideo(); // hace el llamado del formulario
            form.Show(); // muestra el formulario
            this.Hide(); // oculta el formulario anterior
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);// da un mensaje de alerta por si vulve a presionar la misma opcion en la ventana
        }

        // me devuelve al menu principal 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();//hace un llamado al formulario
            this.Dispose();//oculta el formulario anterior
        }


        // me permite ingresar a la ventana eliminar categoria de videos
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCatVideos aecv = new ActualizarEliminarCatVideos(); // hace un llamado al formulario
            aecv.Show();//muestra el formulario
            this.Hide();//oculta el formulario
        }


        // me permite ingresar a la ventana buscar categoria de videos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCatVideos bcv = new BuscarCatVideos();// hace un llamado al formulario
            bcv.Show();//muestra el formulario
            this.Hide();//oculta el formulario
        }

        void insertarCategorias()
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // valida el Texbox y  asi poder enviar el mensaje que los dato han sido ingresados correctamente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Llene el campo nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = string.Empty;
                txtNombre.Focus();
            }
            else
            { // ya validados los campos se realiza toda la insercion a la BD con el metodo insertarCategorias ()
                insertarCategorias();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);//notificacion al usario
                txtNombre.Text = string.Empty;// vacia el campo txtNombre
            }
        }
    }
}
