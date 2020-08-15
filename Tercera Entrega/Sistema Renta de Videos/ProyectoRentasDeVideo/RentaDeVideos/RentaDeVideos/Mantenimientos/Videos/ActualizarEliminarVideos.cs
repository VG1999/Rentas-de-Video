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

namespace RentaDeVideos.Mantenimientos.Videos
{
    public partial class ActualizarEliminarVideos : Form
    {
        public ActualizarEliminarVideos()
        {
            InitializeComponent();
            try
            {
                CargarDatos();
            }
            catch (Exception)
            {

                throw;
            }
            
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

        private void btnVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Video fic = new FormularioIngreso_Video();
            fic.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoVideos ic = new IngresoVideos();
            ic.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarVideos bc = new BuscarVideos();
            bc.Show();
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
            string cadena = "SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio FROM video WHERE estado=1";

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
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_video"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["id_video"].Value.ToString();
                if (sCadena == "")
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_video"].Value.ToString());
                }
                if (iID != 0)
                {
                    if (dgridVista.CurrentRow != null)
                    {
                        string cadena = "UPDATE video SET id_categoria='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_categoria"].Value.ToString()) + "', titulo='" + dgridVista.Rows[e.RowIndex].Cells["titulo"].Value.ToString() +
                            "',duracion='" + dgridVista.Rows[e.RowIndex].Cells["duracion"].Value.ToString() + "', formato='" + dgridVista.Rows[e.RowIndex].Cells["formato"].Value.ToString() +
                            "', anio='" + dgridVista.Rows[e.RowIndex].Cells["anio"].Value.ToString() + "', precio='" + double.Parse(dgridVista.Rows[e.RowIndex].Cells["precio"].Value.ToString()) + "' WHERE id_video='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string cadena = "UPDATE video SET estado=0  WHERE id_video='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void dgridVista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
