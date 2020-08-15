using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Proveedores
{
    public partial class IngresoProveedores : Form
    {
        int iUsuario = 1;
        public IngresoProveedores()
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Proveedor fp = new FormularioIngreso_Proveedor();
            fp.Show();
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
            ActualizarEliminarProveedores aep = new ActualizarEliminarProveedores();
            aep.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedores bp = new BuscarProveedores();
            this.Hide();
            bp.Show();
        }

        private void txtRepresentante_KeyPress(object sender, KeyPressEventArgs e)
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

        void insertarProveedores()
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

                string cadena = "INSERT INTO proveedor (razon_social, representante_legal, nit, telefono, correo, estado) VALUES ('" + txtRazon.Text + "','" + txtRepresentante.Text + "','" + txtNIT.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "',1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "PROVEEDORES";
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
            txtTelefono.Text = string.Empty;
            txtRepresentante.Text = string.Empty;
            txtRazon.Text = string.Empty;
            txtNIT.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        private bool validarTextbox()
        {
            if (txtTelefono.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = string.Empty;
                txtTelefono.Focus();
                return false;
            }
            if (txtCorreo.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = string.Empty;
                txtCorreo.Focus();
                return false;
            }
            if (txtNIT.Text == string.Empty)
            {
                MessageBox.Show("Ingrese NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = string.Empty;
                txtNIT.Focus();
                return false;
            }
            if (txtRazon.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Razon Social", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazon.Text = string.Empty;
                txtRazon.Focus();
                return false;
            }
            if (txtRepresentante.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Representante", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepresentante.Text = string.Empty;
                txtRepresentante.Focus();
                return false;
            }
            if (!Regex.Match(txtRazon.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo representante invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazon.Text = string.Empty;
                txtRazon.Focus();
                return false;
            }
            if (!Regex.Match(txtRepresentante.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo representante invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepresentante.Text = string.Empty;
                txtRepresentante.Focus();
                return false;
            }
            if (!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = string.Empty;
                txtTelefono.Focus();
                return false;
            }
            if (!Regex.Match(txtCorreo.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$").Success)
            {
                MessageBox.Show("Datos del campo correo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = string.Empty;
                txtCorreo.Focus();
                return false;
            }
            else if (!Regex.Match(txtNIT.Text, @"^[0-9]{6}[-][0-9A-z]{1}$").Success)
            {
                MessageBox.Show("Datos del campo NIT invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = string.Empty;
                txtNIT.Focus();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarProveedores();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borraDatos();
            }

        }
    }
}
