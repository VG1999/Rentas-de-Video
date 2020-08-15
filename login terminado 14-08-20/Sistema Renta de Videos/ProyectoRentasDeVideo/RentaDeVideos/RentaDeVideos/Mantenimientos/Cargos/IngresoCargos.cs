using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class IngresoCargos : Form
    {
        int iUsuario = 1;
        public IngresoCargos()
        {
            InitializeComponent();
        }

        //Se genera la conexion a la BD (se llama a la clase que tiene los metodos para la conexion de la BD)
        Conexion cn = new Conexion();

        //instrucnciones para po
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Me permite cerrar pero antes realiza una pregunta al usuario para verificar si realmente quiere salir
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }


        //Me permite minimizar la ventana
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //posiciones o medidas que va tomar el slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }


        //Me da las medidas exactas para poder arrastar el formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Permite abrir la ventana para el ingreso de los cargos
        private void btnCargos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cargo fic = new FormularioIngreso_Cargo(); //se llama al formulario
            fic.Show(); // se muestra el formulario
            this.Hide();// se esconde el formulario anterior
        }

        //Indica al usuario que ya esta dentro de la venta seleccionada 
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // da un mensaje de alerta por si vulve a presionar la misma opcion en la ventana
        }

        //Devuelve al menu principal del sistema 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal(); // me devulve al menu principal
            this.Dispose(); // oculta el fomulario
        }

        // me permite ingresar a la ventana eliminar cargos
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos(); // hace el llamado del formulario
            aec.Show();// muestra el formulario
            this.Hide(); // oculta el fomulario anterior
        }

        // me permite ingresar a la ventana buscar cargos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCargos bc = new BuscarCargos();
            bc.Show(); // hace el llamado del formulario
            this.Hide();// oculta el fomulario anterior
        }

        //bloquea el la tecla si al ingresar numeros solo cadena de letras
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar; // se crea la variable que permitara bloquear la tecla numerica
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32) // valida si es una cadena de letras 
            {
                e.Handled = true; // devuelve el valor verdadero afimando que se ha ingresado solo lo que se valido 
            }
        }

        void insertarCargos()
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // valida cada textbox en el fomulario
        private bool validarTextbox()
        {
            // Se verifica si el campo descripcion no esta vacio de ser asi manda una alerta al usuario
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Llene la Descripcion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);//mensaje de alerta
                txtDescripcion.Text = string.Empty;// verifica si el textbox esta vacio
                txtDescripcion.Focus(); //Obtiene un valor que indica si el control tiene el foco de entrada
                return false;
            }
            // Se verifica si el cargo no esta vacio de ser asi manda una alerta al usuario
            if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Llene el Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = string.Empty;
                txtNombre.Focus();
                return false;
            }
            // Se verifica si la descripcion  y cargo no esten vacios de ser asi manda una alerta al usuario
            if (txtNombre.Text == string.Empty && txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Llene los campos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BorrarTextbox(); //borra todo el texto
                return false;
            }
            return true;

        }
         //borrar datos del los textbox al guardar 
        void BorrarTextbox()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        // se mandan a llamar el metodo validarTexbox se la un valor verdadero y asi poder enviar el mensaje que los dato han sido ingresados correctamente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarCargos();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);//mensaje o notificacion de aviso para los datos guardados
                BorrarTextbox();
            }
        }
    }
}
