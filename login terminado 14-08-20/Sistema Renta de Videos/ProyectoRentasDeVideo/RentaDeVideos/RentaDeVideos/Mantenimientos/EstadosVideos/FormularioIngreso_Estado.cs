using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.EstadosVideos
{
    public partial class FormularioIngreso_Estado : Form
    {
        public FormularioIngreso_Estado()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;

        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoEstado fic = new IngresoEstado();
            fic.Show();
            this.Hide();
        }

        private void btnListas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarEstado aec = new ActualizarEliminarEstado();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEstado bc = new BuscarEstado();
            bc.Show();
            this.Hide();
        }
    }
}
