/*
 Formulario Princupal que contiene el Slider, se agrego como un componente visual y agradable al usuario
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

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class FormularioIngreso_Cargo : Form
    {
        public FormularioIngreso_Cargo()
        {
            InitializeComponent();
        }
        //Permite arrastrar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Inicializa la variable contador en 1, las imagenes deben estar nombradas con numeros partiendo desde 1
        private int contadorImagen = 1;

        private void CargarImagenes()
        {
            //Las imagenes, en este caso, tienen un maximo de 4
            if (contadorImagen == 5)
            {
                contadorImagen = 1;
            }
            //La carpeta de imagenes, esta dentro del proyecto
            picSlider.ImageLocation = string.Format(@"ImagenesCargo\{0}.jpg", contadorImagen);
            contadorImagen++;//Aumenta la variable contador
        }
        //Desplaza menu lateral al darle click
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width=40;
            }
            else
               pnlSlideMenu.Width=188;
            
        }
        
        //Salida de formulario con validacion
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
        //Permite el arrastre del formulario desde el panel superior
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Direcciona al formulario ingreso
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCargos fic = new IngresoCargos();
            fic.Show();
            this.Hide();
        }
        //Mensaje de atencion si el usuario trata de ingresar al formulario actual de nuevo
        private void btnCargos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Salida del formulario sin validacion
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Direcciona al formulario Actualizar y Eliminar
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos();
            aec.Show();
            this.Hide();
        }
        //Direcciona al formulario Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCargos bc = new BuscarCargos();
            bc.Show();
            this.Hide();
        }
        //Controla el Slider de imagenes
        private void timerCargo_Tick(object sender, EventArgs e)
        {
            CargarImagenes();
        }
    }
}
