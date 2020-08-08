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
using System.Data.Odbc;
using RentaDeVideos.Clases;
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.Videos
{
    public partial class IngresoVideos: Form
    {
        public IngresoVideos()
        {
            InitializeComponent();
        }
        Conexion cn = new Conexion();

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

        void insertarVideos()
        {
            string cadena = "INSERT INTO video (id_categoria_video,titulo_video, duracion_video,formato_video, estado_video, anio_video,precio) VALUES ('" + txtCategoria.Text + "','" + txtTitulo.Text + "','" + txtDuracion.Text+ "','" + txtFormato.Text + "',1,'" + txtAnio.Text+ "','"+txtPrecio.Text+"');";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }

        void borraDatos()
        {
            txtAnio.Text = "";
            txtCategoria.Text = "";
            txtDuracion.Text = "";
            txtFormato.Text = "";
            txtPrecio.Text = "";
            txtTitulo.Text = "";
            
        }

        private bool validarTextbox()
        {
            if (txtAnio.Text == "")
            {
                MessageBox.Show("Ingrese Año", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            if (txtCategoria.Text == "")
            {
                MessageBox.Show("Ingrese Categoria", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            if (txtDuracion.Text == "")
            {
                MessageBox.Show("Ingrese Duracion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            if (txtFormato.Text == "")
            {
                MessageBox.Show("Ingrese Formato", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese Precio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            if (txtTitulo.Text == "")
            {
                MessageBox.Show("Ingrese Titulo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                borraDatos();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarVideos();
                borraDatos();
            }
            
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
