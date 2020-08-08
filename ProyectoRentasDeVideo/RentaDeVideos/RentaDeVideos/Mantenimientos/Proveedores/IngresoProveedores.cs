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


namespace RentaDeVideos.Mantenimientos.Proveedores
{
    public partial class IngresoProveedores : Form
    {
        public IngresoProveedores()
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Proveedor fp = new FormularioIngreso_Proveedor();
            fp.Show();
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

        private void validarNombre()
        {

            if (String.IsNullOrEmpty(this.txtRazon.Text))
            {
                MessageBox.Show("Llenar Razon Social", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtRazon.Text, "^([A-Z]{1}[a-z]+[ ]?){1,2}$"))
            {
                MessageBox.Show("Verificar el nombre de la Razon social, Mayusculas seguido de minusculas", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }



    }
}
