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
using RentaDeVideos.Clases;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace RentaDeVideos.Mantenimientos.Proveedores
{
    public partial class IngresoProveedores : Form
    {
        public IngresoProveedores()
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Proveedor fp = new FormularioIngreso_Proveedor();
            fp.Show();
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
            ActualizarEliminarProveedores aep = new ActualizarEliminarProveedores();
            aep.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProveedores bp = new BuscarProveedores();
            this.Hide();
            bp.Show();
        }

        private void txtRepresentante_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        void insertarProveedores()
        {
            string cadena = "INSERT INTO proveedor (razon_social, representante_legal, nit, telefono, correo, estado) VALUES ('" + txtRazon.Text + "','" + txtRepresentante.Text + "','" + txtNIT.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "',1);";
            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        void borraDatos()
        {
            txtTelefono.Text = "";
            txtRepresentante.Text = "";
            txtRazon.Text = "";
            txtNIT.Text = "";
            txtCorreo.Text = "";
        }

        private bool validarTextbox()
        {
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Ingrese Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();
                return false;
            }
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Ingrese Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            if (txtNIT.Text == "")
            {
                MessageBox.Show("Ingrese NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            if (txtRazon.Text == "")
            {
                MessageBox.Show("Ingrese Razon Social", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRazon.Text = "";
                txtRazon.Focus();
                return false;
            }
            if (txtRepresentante.Text == "")
            {
                MessageBox.Show("Ingrese Representante", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepresentante.Text = "";
                txtRepresentante.Focus();
                return false;
            }
            
            if (!Regex.Match(txtRepresentante.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo representante invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepresentante.Text = "";
                txtRepresentante.Focus();
                return false;
            }
            if (!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();
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
                    insertarProveedores();
                    MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    borraDatos();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
