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

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class IngresoEmpleados : Form
    {
        Conexion cn = new Conexion();

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
            Application.Exit();
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
            FormularioInicioMenu fim = new FormularioInicioMenu();
            fim.Show();
            this.Hide();
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

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

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
            txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text);
            txtNombre.SelectionStart = txtNombre.Text.Length;
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
            txtApellidos.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidos.Text);
            txtApellidos.SelectionStart = txtApellidos.Text.Length;
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
            catch (Exception)
            {

                throw;
            }
           
        }

        void insertarEmpleados()
        {
            string cadena = "INSERT INTO empleado (id_cargo,id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion, estado) VALUES ('" + cmbCargo.SelectedItem.ToString() + "','" +cmbUsuario.SelectedItem.ToString()+"','"+ txtDPI.Text + "','" + txtNIT.Text + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtCorreo.Text + "','" + txtTelefono.Text + "','"+txtDireccion.Text+"', 1);";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
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
             else if (txtDPI.Text == "")
            {
                MessageBox.Show("Ingrese DPI", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = "";
                txtDPI.Focus();
                return false;
            }
            else if (!Regex.Match(txtNIT.Text, @"^[0-9]{6}[-][0-9A-z]{1}$").Success)
            {
                MessageBox.Show("Datos del campo NIT invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            else if (!Regex.Match(txtCorreo.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$").Success)
            {
                MessageBox.Show("Datos del campo correo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            return true;
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (validarTextbox() == true)
                {
                    insertarEmpleados();
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    borraDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
         }
    }
}
