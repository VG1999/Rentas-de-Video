/*
 Formulario principal, con slider de imagenes
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

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class FormularioIngreso_CatVideo : Form
    {
        public FormularioIngreso_CatVideo()
        {
            InitializeComponent();
        }
        //Permite arrastrar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Inicializar contador a 1
        private int contadorImagen = 1;
        //Sldier de imagenes, en este caso con 4 imagenes, en una carpeta
        private void CargarImagenes()
        {
            if (contadorImagen == 5)
            {
                contadorImagen = 1;
            }
            picSlider.ImageLocation = string.Format(@"ImagenesCategoria\{0}.jpg", contadorImagen);
            contadorImagen++;
        }
        //Desplaza el menu lateral
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width=40;
            }
            else
               pnlSlideMenu.Width=188;
            
        }
        //Salir con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Arratrar formulario por medio de panel
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Ir al formulario de ingreso de datos
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCatVideos icv = new IngresoCatVideos();
            icv.Show();
            this.Hide();
        }
        //Mensaje de advertencia si el usuario trata de abrir el formulario actual
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Salir sin validacion
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Ir a formulario de Actualizacion y Eliminacion
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCatVideos aecv = new ActualizarEliminarCatVideos();
            aecv.Show();
            this.Hide();
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCatVideos bcv = new BuscarCatVideos();
            bcv.Show();
            this.Hide();
        }
        //Controlar Slider
        private void timerVideo_Tick(object sender, EventArgs e)
        {
            CargarImagenes();
        }
    }
}
