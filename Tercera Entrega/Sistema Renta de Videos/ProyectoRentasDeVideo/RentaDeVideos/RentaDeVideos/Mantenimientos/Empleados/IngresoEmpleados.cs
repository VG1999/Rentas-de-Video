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

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class IngresoEmpleados : Form
    {
        Conexion cn = new Conexion();
        int iUsuario = 1;

        public IngresoEmpleados()
        {
            InitializeComponent();
            inicializarCargo_Usuario();


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Empleado fic = new FormularioIngreso_Empleado();
            fic.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarEmpleados aec = new ActualizarEliminarEmpleados();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleados bc = new BuscarEmpleados();
            bc.Show();
            this.Hide();
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8&&cCaracter!=32)
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void inicializarCargo_Usuario()
        {
            try
            {
                /*Combobox Cargo*/
                string sSQL = "SELECT id_cargo FROM cargo WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCargo.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbCargo.Items.Add(registro["id_cargo"].ToString());
                }
                cmbCargo.SelectedIndex.Equals(0);

                /*Combobox Usuario*/
                string sSQL_1 = "SELECT id_usuario FROM control_usuario WHERE estado=1";
                OdbcCommand comando_1 = new OdbcCommand(sSQL_1, cn.conexion());
                OdbcDataReader registro_1 = comando_1.ExecuteReader();

                cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbUsuario.SelectedIndex = 0;
                while (registro_1.Read())
                {
                    cmbUsuario.Items.Add(registro_1["id_usuario"].ToString());
                }
                cmbUsuario.SelectedIndex.Equals(0);
            }
            catch (Exception  ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al datos al combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        void insertarEmpleados()
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
                string cadena = "INSERT INTO empleado (id_cargo,id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion, estado) VALUES ('" + cmbCargo.SelectedItem.ToString() + "','" + cmbUsuario.SelectedItem.ToString() + "','" + txtDPI.Text + "','" + txtNIT.Text + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtCorreo.Text + "','" + txtTelefono.Text + "','" + txtDireccion.Text + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "EMPLEADOS";
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
        void borraDatos()
        {
            cmbCargo.SelectedIndex = 0;
            cmbUsuario.SelectedIndex = 0;
            txtDPI.Text = "";
            txtNIT.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        private bool validarTextbox()
        {
            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Ingrese Apellido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = "";
                txtApellidos.Focus();
                return false;
            }
            if (cmbCargo.SelectedIndex==0)
            {
                MessageBox.Show("Ingrese Cargo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCargo.SelectedIndex = 0;
                return false;
            }
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Ingrese Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Ingrese Direccion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Text = "";
                txtDireccion.Focus();
                return false;
            }
            if (txtDPI.Text == "")
            {
                MessageBox.Show("Ingrese DPI", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = "";
                txtDPI.Focus();
                return false;
            }
            if (txtNIT.Text == "")
            {
                MessageBox.Show("Ingrese NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Ingrese Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();
                return false;
            }
            if (cmbUsuario.SelectedIndex==0)
            {
                MessageBox.Show("Ingrese Usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUsuario.SelectedIndex = 0;
                return false;
            }
            if (!Regex.Match(txtNombre.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo nombre invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            if (!Regex.Match(txtApellidos.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo apellido invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = "";
                txtApellidos.Focus();
                return false;
            }
            if (!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();

                return true;
            }
            if (!Regex.Match(txtNIT.Text, @"^[0-9]{6}[-][0-9A-z]{1}$").Success)
            {
                MessageBox.Show("Datos del campo NIT invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            if (!Regex.Match(txtCorreo.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$").Success)
            {
                MessageBox.Show("Datos del campo correo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            if (!Regex.Match(txtDPI.Text, @"(^[0-9]{4}[ ][0-9]{5}[ ][0-9]{4})$").Success)
            {
                MessageBox.Show("Datos del campo DPI invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = "";
                txtDPI.Focus();
                return false;
            }
            return true;
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarEmpleados();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borraDatos();
            }
        }
    }
}
