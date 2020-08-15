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
    public partial class BuscarVideos : Form
    {
        public BuscarVideos()
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
            ActualizarEliminarVideos aec = new ActualizarEliminarVideos();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE estado=1";

                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE id_video='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "ID CATEGORIA")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE id_categoria='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Titulo")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE titulo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Duracion")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE duracion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Formato")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE formato='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Año")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE anio='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Precio")
                {
                    datos = new OdbcDataAdapter("SELECT id_video, id_categoria, titulo, duracion, formato, anio, precio, cantidad FROM video WHERE precio='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al buscar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
