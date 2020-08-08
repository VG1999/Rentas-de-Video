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
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class IngresoEmpleados : Form
    {
        public IngresoEmpleados()
        {
            InitializeComponent();
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
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text);
            txtNombre.SelectionStart = txtNombre.Text.Length;
        }


        private void validarNombre()
        {

            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Llenar Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtNombre.Text, "^([A-Z]{1}[a-z]+[ ]?){1,2}$"))
            {
                MessageBox.Show("Verificar Nombre Mayusculas seguido de minusculas", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void validarTelefono()
        {

            if (String.IsNullOrEmpty(this.txtTelefono.Text))
            {
                MessageBox.Show("Llenar Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtTelefono.Text, "^[0-9]{8}$"))
            {
                MessageBox.Show("Verificar Telefono, llenar con 8 digitos", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void validarCargo()
        {
            if (String.IsNullOrEmpty(this.txtCargo.Text))
            {
                MessageBox.Show("Llenar Cargo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void validarNIT()
        {

            if (String.IsNullOrEmpty(this.txtNIT.Text))
            {
                MessageBox.Show("Llenar NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtNIT.Text, "^[0-9]{6}[-][0-9A-z]{1}$"))
            {
                MessageBox.Show("Verificar NIT formato XXXXXX-X", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void validarCorreo()
        {

            if (String.IsNullOrEmpty(this.txtCorreo.Text))
            {
                MessageBox.Show("Llenar Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtCorreo.Text, "^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$"))
            {
                MessageBox.Show("Verificar correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void validaApellido()
        {

            if (String.IsNullOrEmpty(this.txtApellidos.Text))
            {
                MessageBox.Show("Llenar Apellido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtApellidos.Text, "^([A-Z]{1}[a-z]+[ ]?){1,2}$"))
            {
                MessageBox.Show("Verificar Apellido Mayusculas seguido de minusculas", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        private void validaDPI()
        {
            if (String.IsNullOrEmpty(this.txtDPI.Text))
            {
                MessageBox.Show("Llenar DPI", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtDPI.Text, "(^[0-9]{4}[ ]?[0-9]{5}[ ]?[0-9]{4})$"))
            {
                MessageBox.Show("formato DPI xxxx xxxxx xxxx", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validaDireccion()
        {

            if (String.IsNullOrEmpty(this.txtDireccion.Text))
            {
                MessageBox.Show("Llenar Direccion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validarUsuarios()
        {

            if (String.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Llenar ID USUARIO", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validarNombre();
            validarTelefono();
            validarCargo();
            validarNIT();
            validarCorreo();
            validaApellido();
            validaDPI();
            validaDireccion();
            validarUsuarios();
            

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            txtApellidos.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellidos.Text);
            txtApellidos.SelectionStart = txtApellidos.Text.Length;
        }

        }

}
