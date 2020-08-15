using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class FormularioIngreso_Cargo : Form
    {
        public FormularioIngreso_Cargo()
        {
            InitializeComponent();
        }

        //Permite arrastar el form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private int contadorImagen = 1;

       //carga las imagenes al slide en el form 
        private void CargarImagenes()
        {
            if (contadorImagen == 5)
            {
                contadorImagen = 1;
            }
            picSlider.ImageLocation = string.Format(@"ImagenesCargo\{0}.jpg", contadorImagen);
            contadorImagen++;
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
        //permite salir de la venta mostrando un mensaje de alerta al usuario
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//mensaje de alerta
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();//cierra el formulario
            }
        }
        // permite minimizar de la venta ]

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //da las posiciones hacia donde podemos arrastrar el formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //no permite el ingreso a la ventana principal de cargos
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCargos fic = new IngresoCargos();//hace la la llamada al formulario
            fic.Show();//muestra el formulario
            this.Hide();//oculta el formulario
        }

        //nos indica que ya estamos dentro del venta seleccinada 
        private void btnCargos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//mensaje de alerta
        }

        //nos devuelve a la pagina principal del sistema
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// hace la llamada al formulario
            this.Dispose();// cierra el formulario anterior
        }
        
        //nos da el ingreso a la venta actualizar y eliminar el ingreso del cargo
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos();// hace la llamada al formulario
            aec.Show();// muestra el el formulario
            this.Hide();// oculta el formulario
        }

        // nos envia a la venta quer posee los metodos de busqueda del datos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCargos bc = new BuscarCargos();// hace la llamada al formulario
            bc.Show();//muestra el formulario
            this.Hide();//oculta el formulario anterior
        }

        //llama al metodo de los slides para realizar los efectos correspondientes
        private void timerCargo_Tick(object sender, EventArgs e)
        {
            CargarImagenes();
        }
    }
}
