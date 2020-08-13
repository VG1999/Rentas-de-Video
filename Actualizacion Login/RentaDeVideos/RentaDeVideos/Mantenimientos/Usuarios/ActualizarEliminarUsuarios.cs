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

namespace RentaDeVideos.Mantenimientos.Usuarios
{
    public partial class ActualizarEliminarUsuarios : Form
    {
        public ActualizarEliminarUsuarios()
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Usuario fu = new FormularioIngreso_Usuario();
            fu.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoUsuarios iu = new IngresoUsuarios();
            iu.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios bu = new BuscarUsuarios();
            this.Hide();
            bu.Show();
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
            string cadena = "SELECT id_usuario, contraseña_usuario, rol_usuario FROM control_usuario WHERE estado=1";
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
        }
        string sCadena;
        int iID;
        int iIDEliminar;

        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_usuario"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sCadena = dgridVista.Rows[e.RowIndex].Cells["id_usuario"].Value.ToString();
            if (sCadena == "")
            {
                iID = 0;
            }
            else
            {
                iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_usuario"].Value.ToString());
            }
            if (iID != 0)
            {
                if (dgridVista.CurrentRow != null)
                {
                    string cadena = "UPDATE control_usuario SET contraseña_usuario='" + dgridVista.Rows[e.RowIndex].Cells["contraseña_usuario"].Value.ToString() + "', rol_usuario='" + dgridVista.Rows[e.RowIndex].Cells["rol_usuario"].Value.ToString() + "' WHERE id_usuario='" + iID + "';";
                    datos = new OdbcDataAdapter(cadena, cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridVista.DataSource = dt;
                    CargarDatos();
                }
            }
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            string cadena = "UPDATE control_usuario SET estado=0  WHERE id_usuario='" + iIDEliminar + "';";
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
            CargarDatos();
        }
    }
}
