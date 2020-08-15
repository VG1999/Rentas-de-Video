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
        Conexion cn = new Conexion();
        public IngresoVideos()
        {
            
            InitializeComponent();
            inicializarCategoria();
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

        private void inicializarCategoria()
        {
            try
            {
                string sSQL = "SELECT id_categoria FROM categoria_video WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCategoria.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbCategoria.Items.Add(registro["id_categoria"].ToString());
                }
                cmbCategoria.SelectedIndex.Equals(0);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        void insertarVideos()
        {
            string cadena = "INSERT INTO video (id_categoria,titulo, duracion,formato, anio,precio, estado) VALUES ('" + cmbCategoria.SelectedItem.ToString() + "','" + txtTitulo.Text + "','" + txtDuracion.Text+ "','" + txtFormato.Text + "','" + txtAnio.Text+ "','"+txtPrecio.Text+"',1);";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
           
        }

        void borraDatos()
        {
            txtAnio.Text = "";
            cmbCategoria.SelectedIndex = 0;
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
                txtAnio.Text = "";
                txtAnio.Focus();
                return false;
            }
            if (cmbCategoria.SelectedIndex==0)
            {
                MessageBox.Show("Ingrese Categoria", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategoria.SelectedIndex = 0;
                return false;
            }
            if (txtDuracion.Text == "")
            {
                MessageBox.Show("Ingrese Duracion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDuracion.Text = "";
                txtDuracion.Focus();
                return false;
            }
            if (txtFormato.Text == "")
            {
                MessageBox.Show("Ingrese Formato", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormato.Text = "";
                txtFormato.Focus();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese Precio", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Text = "";
                txtPrecio.Focus();
                return false;
            }
            if (txtTitulo.Text == "")
            {
                MessageBox.Show("Ingrese Titulo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Text = "";
                txtTitulo.Focus();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarTextbox() == true)
                {
                    insertarVideos();
                    borraDatos();
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTitulo.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
