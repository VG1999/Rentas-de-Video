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

namespace RentaDeVideos.Mantenimientos.ControlCompra
{
    public partial class IngresoDetalle: Form
    {
        public IngresoDetalle()
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

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Detalle fic = new FormularioIngreso_Detalle();
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
            ActualizarEliminarDetalle aec = new ActualizarEliminarDetalle();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDetalle bc = new BuscarDetalle();
            bc.Show();
            this.Hide();
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }


        private void validarFecha()
        {

            if (String.IsNullOrEmpty(this.txtFecha.Text))
            {
                MessageBox.Show("Llenar Fecha", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!Regex.IsMatch(this.txtFecha.Text, "^([A-Z]{1}[a-z]+[ ]?){1,2}$"))
            {
                MessageBox.Show("Verificar fecha, formato 00-00-00 / 00-00-0000", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void validarDescripcion()
        {

            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Llenar Descripcion ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        private void validarPrecio()
        {

            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Llenar precio ", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            validarDescripcion();
            validarPrecio();
            validarFecha();
        }
    }
}
