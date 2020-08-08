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

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class ActualizarEliminarEmpleados : Form
    {
        public ActualizarEliminarEmpleados()
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

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Empleado fic = new FormularioIngreso_Empleado();
            fic.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoEmpleados ic = new IngresoEmpleados();
            ic.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleados bc = new BuscarEmpleados();
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
            string cadena = "SELECT id_empleado, id_cargo_empleado, id_usuario_empleado, dpi_empleado, nit_empleado, nombre_empleado, apellido_empleado, corre_empleado, telefono_empleado, direccion_empleado FROM empleado WHERE estado=1";

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
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sCadena = dgridVista.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString();
            if (sCadena == "")
            {
                iID = 0;
            }
            else
            {
                iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString());
            }
            if (iID != 0)
            {
                if (dgridVista.CurrentRow != null)
                {
                    string cadena = "UPDATE empleado SET id_cargo_empleado='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cargo_empleado"].Value.ToString()) + "', id_usuario_empleado='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_usuario_empleado"].Value.ToString()) +
                        "',dpi_empleado='" + dgridVista.Rows[e.RowIndex].Cells["dpi_empleado"].Value.ToString() + "', nit_empleado='" + dgridVista.Rows[e.RowIndex].Cells["nit_empleado"].Value.ToString() +
                        "', nombre_empleado='" + dgridVista.Rows[e.RowIndex].Cells["nombre_empleado"].Value.ToString() + "', apellido_empleado='" + dgridVista.Rows[e.RowIndex].Cells["apellido_empleado"].Value.ToString() +
                        "', corre_empleado='" +dgridVista.Rows[e.RowIndex].Cells["corre_empleado"].Value.ToString() + "', telefono_empleado='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["telefono_empleado"].Value.ToString()) 
                        + "', direccion_empleado='" + dgridVista.Rows[e.RowIndex].Cells["direccion_empleado"].Value.ToString() + "' WHERE id_empleado='" + iID + "';";
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
            string cadena = "UPDATE empleado SET estado=0  WHERE id_empleado='" + iIDEliminar + "';";
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridVista.DataSource = dt;
            CargarDatos();
        }
    }
}
