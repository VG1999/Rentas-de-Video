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

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class ActualizarEliminarClientes : Form
    {
        public ActualizarEliminarClientes()
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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fig = new FormularioIngreso_Cliente();
            fig.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoClientes ic = new IngresoClientes();
            ic.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();
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
            string cadena = "SELECT id_cliente, id_membresia_cliente, dpi_cliente, nit_cliente, nombre_cliente, apellido_cliente, telefono_cliente, correo_cliente FROM cliente WHERE estado=1";

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
            sCadena = dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
            if (sCadena == "")
            {
                iID = 0;
            }
            else
            {
                iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());
            }
            if (iID != 0)
            {
                if (dgridVista.CurrentRow != null)
                {
                    string cadena = "UPDATE cliente SET id_membresia_cliente='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia_cliente"].Value.ToString()) + 
                        "',dpi_cliente='" + dgridVista.Rows[e.RowIndex].Cells["dpi_cliente"].Value.ToString()+ "', nit_cliente='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["nit_cliente"].Value.ToString())+
                        "', nombre_cliente='" + dgridVista.Rows[e.RowIndex].Cells["nombre_cliente"].Value.ToString() +"', apellido_cliente='"+dgridVista.Rows[e.RowIndex].Cells["apellido_cliente"].Value.ToString() +
                        "', telefono_cliente='"+ int.Parse(dgridVista.Rows[e.RowIndex].Cells["telefono_cliente"].Value.ToString()) + "', correo_cliente='" + dgridVista.Rows[e.RowIndex].Cells["correo_cliente"].Value.ToString() + "' WHERE id_cliente='" + iID + "';";
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
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            string cadena = "UPDATE cliente SET estado=0  WHERE id_cliente='" + iIDEliminar + "';";
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
            CargarDatos();
        }
    }
}
