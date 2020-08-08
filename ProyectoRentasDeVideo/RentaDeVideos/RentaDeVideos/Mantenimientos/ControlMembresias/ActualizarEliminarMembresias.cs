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

namespace RentaDeVideos.Mantenimientos.ControlMembresias
{
    public partial class ActualizarEliminarMembresias : Form
    {
        public ActualizarEliminarMembresias()
        {
            InitializeComponent();
            CargarDatos();
        }

        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

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

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Membresia form = new FormularioIngreso_Membresia();
            form.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoMembresias icv = new IngresoMembresias();
            icv.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarMembresias bcv = new BuscarMembresias();
            bcv.Show();
            this.Hide();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            FormularioInicioMenu fim = new FormularioInicioMenu();
            fim.Show();
            this.Hide();
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        void CargarDatos()
        {
            string cadena = "SELECT id_membresia, descripcion_membresia, puntos_membresia, descuento_membresia FROM membresia WHERE estado_membresia=1";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
        }
        string sCadena;
        int iID;
        int iIDEliminar;
        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sCadena = dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString();
            if (sCadena == "")
            {
                iID = 0;
            }else
            {
                iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString());
            }
            if (iID != 0)
            {
                if (dgridVista.CurrentRow != null)
                {
                    string cadena = "UPDATE membresia SET descripcion_membresia='" + dgridVista.Rows[e.RowIndex].Cells["descripcion_membresia"].Value.ToString() + "',puntos_membresia='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["puntos_membresia"].Value.ToString()) + "', descuento_membresia='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["descuento_membresia"].Value.ToString()) + "' WHERE id_membresia='" + iID + "';";
                    datos = new OdbcDataAdapter(cadena, cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridVista.DataSource = dt;
                    CargarDatos();
                }
            }
            
        }

        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void cmsDelete_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            string cadena = "UPDATE membresia SET estado_membresia=0  WHERE id_membresia='" + iIDEliminar + "';";
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
            CargarDatos();
        }
    }
}
