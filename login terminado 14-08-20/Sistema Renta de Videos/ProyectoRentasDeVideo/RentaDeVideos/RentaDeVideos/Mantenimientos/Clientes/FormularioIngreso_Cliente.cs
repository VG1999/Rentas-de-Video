using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class FormularioIngreso_Cliente : Form
    {
        public FormularioIngreso_Cliente()
        {
            InitializeComponent();
        }

        //Permite arrastrar el formulario en la pantalla 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private int contadorImagen = 1;

        // metodo para el slide 
        private void CargarImagenes()
        {
            if (contadorImagen == 5)
            {
                contadorImagen = 1;
            }
            picSlider.ImageLocation = string.Format(@"ImagenesCliente\{0}.jpg", contadorImagen);
            contadorImagen++;
        }
        // medidas que va obtener el slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;

        }

        // nos permite salir de la ventana actual 
        private void picSalir_Click(object sender, EventArgs e)
        {
            // da un mensaje de alerta al usario por si quiere completar dichos cambios
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose(); // de ser asi se desaparece el formulario actual 
            }
        }

        // Minimiza dicha venta 
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;// instruccion para minimizar el formulario 
        }

        //posiciones hacia donde puedo arrastrar mi formulario 
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Nos da la vista hacia el ingreso de cliente 
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoClientes ig = new IngresoClientes();// hacemos la llamada al formulario 
            ig.Show();// mostramos dicho formulario 
            this.Hide();// ocultamos el formulario 
        }

        /* Notifica al usuario de que se encuentra en el formulario seleccionado */
        private void btnClientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /*Permite al usuario regresar al menu principal del sistema
         * ocultando el formulario anterior   */
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        /*Permite al usuario ingresar la actualizacion y eliminacion de los datos 
      * ocultando el formulario anterior   */
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }

        /*Permite al usuario ingresar a la busqueda de los datos  
         * ocultando el formulario anterior */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();
            bc.Show();
            this.Hide();
        }

        /*cargamos los imagenes del slide */
        private void timerClientes_Tick(object sender, EventArgs e)
        {
            CargarImagenes();
        }
    }
}
