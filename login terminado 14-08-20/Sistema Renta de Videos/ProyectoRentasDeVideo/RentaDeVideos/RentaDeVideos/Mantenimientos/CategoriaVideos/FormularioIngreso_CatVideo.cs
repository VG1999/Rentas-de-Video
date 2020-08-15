using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class FormularioIngreso_CatVideo : Form
    {
        public FormularioIngreso_CatVideo()
        {
            InitializeComponent();
        }
        
        //propiedad que permite arrastar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private int contadorImagen = 1;// variable que se utilizara para el slide como contador 

        // metodo para el slide del formulario 
        private void CargarImagenes()
        {
            if (contadorImagen == 5)
            {
                contadorImagen = 1;
            }
            picSlider.ImageLocation = string.Format(@"ImagenesCategoria\{0}.jpg", contadorImagen);
            contadorImagen++;
        }

        //medidas que se le asignaran al slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;

        }

        //nos permite salir del mantenimiento categorias videos 
        private void picSalir_Click(object sender, EventArgs e)
        {
            //aviso al usario para completar la accion
            DialogResult drResultadoMensaje; // instruccion para la notificacion 
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);// mensaje de alerta
            if (drResultadoMensaje == DialogResult.Yes) // se valida la accion por el usario 
            {
                this.Dispose(); // de ser si el formulario se cierra
            }
        }

        // minimiza el formulario
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;// instruccion para minimizar
        }

        //posiciones hacia donde podemos mover el formulario o arrastrarlo
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //nos muestra el formulario para el ingreso de datos de la categoria de videos 
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCatVideos icv = new IngresoCatVideos();// llamamos al formulario
            icv.Show();//se muestra el formulario
            this.Hide();// oculta el formulario del usuario 
        }

        // da aviso al usario que ya se encuentra dentro de la venta seleccionada 
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            //mensaje de alerta al usuario 
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //nos devuelve al menu principal del sistema 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// llamamos al formulario
            this.Dispose();//ocultamos el formulario anterior del usuario 
        }

        // Permite ingresar al formulario para actualizar y eliminar la categoria de videos 
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCatVideos aecv = new ActualizarEliminarCatVideos();// hacemos el llamado al formulario 
            aecv.Show();// mostramos el formulario 
            this.Hide();// ocultamos el formulario del usuario 
        }

        // nos permite ingresar a la venta de busqueda 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCatVideos bcv = new BuscarCatVideos();// hacemos un llamado al formulario 
            bcv.Show();// mostramos el formulario 
            this.Hide();// ocultamos el formulario 
        }

        // cargamos las imagenes del slide llamamos al metodo que contiene el slide 
        private void timerVideo_Tick(object sender, EventArgs e)
        {
            CargarImagenes();// metodo del slide 
        }
    }
}
