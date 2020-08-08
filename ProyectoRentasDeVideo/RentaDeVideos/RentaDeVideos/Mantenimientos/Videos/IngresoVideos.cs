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

namespace RentaDeVideos.Mantenimientos.Videos
{
    public partial class IngresoVideos: Form
    {
        public IngresoVideos()
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

        private void btnVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Video fic = new FormularioIngreso_Video();
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
            ActualizarEliminarVideos aec = new ActualizarEliminarVideos();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVideos bc = new BuscarVideos();
            bc.Show();
            this.Hide();
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter)&&cCaracter!=8)
            {
                e.Handled = true;
            }
        }

        private void txtCopia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32&&cCaracter!=46)
            {
                e.Handled = true;
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32 && cCaracter != 44)
            {
                e.Handled = true;
            }
        }


        private void validarPrecio()
        {

            if (String.IsNullOrEmpty(this.txtPrecio.Text))
            {
                MessageBox.Show("Llenar precio ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validarTitulo()
        {

            if (String.IsNullOrEmpty(this.txtTitulo.Text))
            {
                MessageBox.Show("Llenar Titulo ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validarDuracion()
        {

            if (String.IsNullOrEmpty(this.txtDuracion.Text))
            {
                MessageBox.Show("Llenar Duracion ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validarCopia()
        {

            if (String.IsNullOrEmpty(this.txtCopia.Text))
            {
                MessageBox.Show("Llenar Copia ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void validarCategoria()
        {

            if (String.IsNullOrEmpty(this.txtCategoria.Text))
            {
                MessageBox.Show("Llenar Categoria ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void validarAnio()
        {

            if (String.IsNullOrEmpty(this.txtAnio.Text))
            {
                MessageBox.Show("Llenar Anio ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtAnio.Text, "^([0-9]{4}$"))
            {
                MessageBox.Show("Verificar fecha, formato XXXX" , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void validarFormato()
        {

            if (String.IsNullOrEmpty(this.txtFormato.Text))
            {
                MessageBox.Show("Llenar Formato ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    



        private void txtDuracion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
