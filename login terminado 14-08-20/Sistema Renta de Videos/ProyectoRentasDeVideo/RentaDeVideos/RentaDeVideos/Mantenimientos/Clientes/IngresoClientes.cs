using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class IngresoClientes : Form
    {
        int iUsuario = 1;
        public IngresoClientes()
        {
            InitializeComponent();
            inicializarMembresia();
        }

        // hacemos la conexion a la base de datos
        Conexion cn = new Conexion();

        //Permite arrastrar el formulario en la pantalla 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // nos permite salir del formulari enviando un mensaje de alerta al usario 
        //// da un mensaje de alerta al usario por si quiere completar dichos cambios
        // // de ser asi se desaparece el formulario actual 
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }


        //permite minimizar la ventana
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // instruccion para minimizar 
        }

        // medidas que va obtener el slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //posiciones hacia donde puedo arrastrar mi formulario 
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Nos da la vista hacia el formulario principal del ingreso de cliente 
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fic = new FormularioIngreso_Cliente();// hacemos la llamada al formulario 
            fic.Show();// mostramos dicho formulario 
            this.Hide();// ocultamos el formulario 
        }

        /* Notifica al usuario de que se encuentra en el formulario seleccionado */
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /*Permite al usuario regresar al menu principal del sistema
        * ocultando el formulario anterior   */
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        /*Permite al usuario ingresar la actualizacion y eliminacion de los datos 
      * ocultando el formulario anterior   */
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }


        /*Permite al usuario ingresar a la busqueda de los datos  
         * ocultando el formulario anterior */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();
            bc.Show();
            this.Hide();
        }

        // Se bloquea las teclas numericas para captar solo letas  
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32) // posee un tamaño de 8 a 32 caracteres 
            {
                e.Handled = true; //devuelve un valor verdadero 
            }
        }

        // Se bloquea la teclas numericas para  captar solo letas
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32) // posee un tamaño de 8 a 32 caracteres 
            {
                e.Handled = true; //devuelve un valor verdadero 
            }
        }


        // Se bloquea la teclas del abecedario  para  captar solo digitos numericos   
          private void txtDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32) // posee un tamaño de 8 a 32 caracteres
            {
                e.Handled = true;//devuelve un valor verdadero 
            }
        }

          // Se bloquea la teclas del abecedario  para  captar solo digitos numericos   
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)// posee un tamaño de 8 a 32 caracteres
            {
                e.Handled = true;//devuelve un valor verdadero 
            }
        }

        // Se bloquea la teclas numericas para  captar solo
        private void txtMembresia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)// posee un tamaño de 8 a 32 caracteres
            {
                e.Handled = true;//devuelve un valor verdadero 
            }
        }

        private void inicializarMembresia()
        {
            try
            {
                string sSQL = "SELECT id_membresia FROM membresia WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbMembresia.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMembresia.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbMembresia.Items.Add(registro["id_membresia"].ToString());
                }
                cmbMembresia.SelectedIndex.Equals(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al datos al combobox", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void insertarClientes()
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
                string cadena = "INSERT INTO cliente (id_membresia, dpi, nit, nombre, apellido, telefono, correo, estado) VALUES ('" + cmbMembresia.SelectedItem.ToString() + "','" + txtDPI.Text + "','" + txtNIT.Text + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CLIENTES";
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

        // borra todos los datos del texboxt cuando ya se ha hecho el ingreso de los datos 
        void borraDatos()
        {
            cmbMembresia.SelectedIndex = 0;
            txtDPI.Text = string.Empty;
            txtNIT.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
        
        /* el metodo validar Textbox es de tipo booleano y se utiliza para validar cada texbtox por si se encuentra vacio o esta con la informacion correcta */
        private bool validarTextbox()
        {
            /* 1. se valida el txtApellidos de que no este vacio 
             * 2. Si esta vacio envia una notificacion para que llene los datos 
             * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
             */
            if (txtApellidos.Text == string.Empty) 
            {
                MessageBox.Show("Ingrese Apellido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = string.Empty;
                txtApellidos.Focus();
                return false;
            }
            /* 1. se valida el cmbMembresia de que no este vacio 
            * 2. Si esta vacio envia una notificacion para que se llenen los datos 
             */
            else if (cmbMembresia.SelectedIndex == 0)
            {
                MessageBox.Show("Ingrese Membresia", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMembresia.SelectedIndex = 0;
                return false;
            }
            /* 1. se valida el txtCorreo de que no este vacio 
           * 2. Si esta vacio envia una notificacion para que llene los datos 
           * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
           */
            else if (txtCorreo.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = string.Empty;
                txtCorreo.Focus();
                return false;
            }

            /* 1. se valida el txtDPI de que no este vacio 
            * 2. Si esta vacio envia una notificacion para que llene los datos 
            * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
            */
            else if (txtDPI.Text == string.Empty)
            {
                MessageBox.Show("Ingrese DPI", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = string.Empty;
                txtDPI.Focus();
                return false;
            }

            /* 1. se valida el txtNIT de que no este vacio 
            * 2. Si esta vacio envia una notificacion para que llene los datos 
            * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
            */
            else if (txtNIT.Text == string.Empty)
            {
                MessageBox.Show("Ingrese NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = string.Empty;
                txtNIT.Focus();
                return false;
            }

            /* 1. se valida el txtNombre de que no este vacio 
           * 2. Si esta vacio envia una notificacion para que llene los datos 
           * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
           */
            else if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = string.Empty;
                txtNombre.Focus();
                return false;
            }

            /* 1. se valida el txtTelefono de que no este vacio 
          * 2. Si esta vacio envia una notificacion para que llene los datos 
          * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
          */
            else if (txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = string.Empty;
                txtTelefono.Focus();
                return false;
            }

            /* 1. se valida el txtNombre este escrito segun la expresion regular 
          * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
          * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
          * 4. El fomato de llenado es (se debe de iniciar con con mayusculas seguido de minusculas)
          * 5. si el campo no esta bien escrito vacia el textbox
          */
            else if (!Regex.Match(txtNombre.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo nombre invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = string.Empty;
                txtNombre.Focus();
                return false;
            }

            /* 1. se valida el txtApellidos este escrito segun la expresion regular 
           * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
           * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
           * 4. El fomato de llenado es (se debe de iniciar con con mayusculas seguido de minusculas)
           * 5. si el campo no esta bien escrito vacia el textbox
           */
            else if (!Regex.Match(txtApellidos.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo apellido invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = string.Empty;
                txtApellidos.Focus();
                return false;
            }

            /* 1. se valida el txtTelefono este escrito segun la expresion regular 
          * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
          * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
          * 4. El fomato de llenado es (solo se pueden llenar datos numericos ejemplo 4835XXXX, solo permite 8 digitos )
          * 5. si el campo no esta bien escrito vacia el textbox
          */
            else if (!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = string.Empty;
                txtTelefono.Focus();
                return false;
            }

            /* 1. se valida el txtNIT este escrito segun la expresion regular 
          * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
          * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
          * 4. El fomato de llenado es (solo se pueden llenar datos numericos ejemplo 435000-X, solo permite 6 digitos )
          * 5. si el campo no esta bien escrito vacia el textbox
          */
            else if (!Regex.Match(txtNIT.Text, @"^[0-9]{6}[-][0-9A-z]{1}$").Success)
            {
                MessageBox.Show("Datos del campo NIT invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = string.Empty;
                txtNIT.Focus();
                return false;
            }

            /* 1. se valida el txtDPI este escrito segun la expresion regular 
         * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
         * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
         * 4. El fomato de llenado es (solo se pueden llenar datos numericos ejemplo 3006 78910 XXXX, permite 13 digitos y llevan espacio de por medio)
         *    el usario debe de dejar los espacio y primero debe de seguir un orde 4 digitos espacio 5 ditos espacio 4 digitos 
         * 5. si el campo no esta bien escrito vacia el textbox
         */
            else if (!Regex.Match(txtDPI.Text, @"(^[0-9]{4}[ ][0-9]{5}[ ][0-9]{4})$").Success)
            {
                MessageBox.Show("Datos del campo DPI invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = string.Empty;
                txtDPI.Focus();
                return false;
            }


            /* 1. se valida el txtCorreo este escrito segun la expresion regular 
         * 2. Si esta  no esta bien escrita se envia una notificacion de que se ha escrito mal 
         * 3. recibe una entrada de formulario que ha recibido el foco y  se activa cuando el usuario hace clic
         * 4. El fomato de llenado es (puede utlizar nuemero y letras seguidos de una @ ejemplo: ejemplo10@gmail.com)
         *    si el usuario no ingresa la @ no le permitira ingresar los datos, al igual que el punto es obligatorio 
         * 5. si el campo no esta bien escrito vacia el textbox
         */
            else if (!Regex.Match(txtCorreo.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$").Success)
            {
                MessageBox.Show("Datos del campo correo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = string.Empty;
                txtCorreo.Focus();
                return false;
            }
            return true;

        }

        /* se manda a llamar el metodo validar texboxt al boton de guardar y asi ingresar los datos a la BD */
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true) // retorna un valor verdadero para completar la validacion 
            {
                insertarClientes();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information); // se envia la notificacion al usuario de que los campo han sigo ingresados correctamente 
                borraDatos(); // se vacian todos los textbox
            }
        }
    }
}
