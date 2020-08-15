/*
 Formulario que controla el ingreso de datos a la BD en la tabla video
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
using System.Text.RegularExpressions;
using System.Net;

namespace RentaDeVideos.Mantenimientos.Videos
{
    public partial class IngresoVideos: Form
    {
        Conexion cn = new Conexion();
        //Toma valor de id del usuario logueado
        int iUsuario = Users.id_usario;
        public IngresoVideos()
        {
            
            InitializeComponent();
            inicializarCategoria();
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
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
        private void btnVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Video fic = new FormularioIngreso_Video();
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
            ActualizarEliminarVideos aec = new ActualizarEliminarVideos();
            aec.Show();
            this.Hide();
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVideos bc = new BuscarVideos();
            bc.Show();
            this.Hide();
        }
        //Valida precio, solo ingrese numeros
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32&&cCaracter!=46)
            {
                e.Handled = true;
            }
        }
        //Ingreso de anio solo numeros
        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32 && cCaracter != 44)
            {
                e.Handled = true;
            }
        }
        //Carga datos a los combobox 
        private void inicializarCategoria()
        {
            try
            {
                string sSQL = "SELECT id_categoria FROM categoria_video WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCategoria.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbCategoria.Items.Add(registro["id_categoria"].ToString());
                }
                cmbCategoria.SelectedIndex.Equals(0);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string cadena = "INSERT INTO video (id_categoria,titulo, duracion,formato, anio,precio,cantidad, estado) VALUES ('" + cmbCategoria.SelectedItem.ToString() + "','" + txtTitulo.Text + "','" + txtDuracion.Text + "','" + txtFormato.Text + "','" + txtAnio.Text + "','" + txtPrecio.Text + "','"+txtCantidad.Text+"',1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "VIDEOS";
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
            txtAnio.Text = "";
            cmbCategoria.SelectedIndex = 0;
            txtDuracion.Text = "";
            txtFormato.Text = "";
            txtPrecio.Text = "";
            txtTitulo.Text = "";
            txtCantidad.Text = "";
            
        }
        //Validacion de componentes, a ingresar
        private bool validarTextbox()
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Ingrese Año", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnio.Text = "";
                txtAnio.Focus();
                return false;
            }
            if (cmbCategoria.SelectedIndex==0)
            {
                MessageBox.Show("Ingrese Categoria", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoria.SelectedIndex = 0;
                return false;
            }
            if (txtDuracion.Text == "")
            {
                MessageBox.Show("Ingrese Duracion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuracion.Text = "";
                txtDuracion.Focus();
                return false;
            }
            if (txtFormato.Text == "")
            {
                MessageBox.Show("Ingrese Formato", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormato.Text = "";
                txtFormato.Focus();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese Precio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return false;
            }
            if (txtTitulo.Text == "")
            {
                MessageBox.Show("Ingrese Titulo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Text = "";
                txtTitulo.Focus();
                return false;
            }
            if (!Regex.Match(txtTitulo.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo Titulo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Text = "";
                txtTitulo.Focus();
                return false;
            }
            if (!Regex.Match(txtAnio.Text, @"^([0-9]{4})$").Success)
            {
                MessageBox.Show("Datos del campo año invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnio.Text = "";
                txtAnio.Focus();
                return false;
            }
            if (!Regex.Match(txtDuracion.Text, @"^[0-9]{1,2}:[0-5][0-9][m|h]$").Success)
            {
                MessageBox.Show("Datos del campo duracion invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuracion.Text = "";
                txtDuracion.Focus();
                return false;
            }
            if (!Regex.Match(txtPrecio.Text, @"^[0-9]+[.][0-9]{2}$").Success)
            {
                MessageBox.Show("Datos del campo precio invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return false;
            }
            if (!Regex.Match(txtCantidad.Text, @"^[0-9]\d{0,7}$").Success)
            {
                MessageBox.Show("Datos del campo cantidad invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Text = "";
                txtCantidad.Focus();
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
                txtTitulo.Focus();
             }
        }
        //Ingreso de cantidad, solo numeros
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }
    }
}
