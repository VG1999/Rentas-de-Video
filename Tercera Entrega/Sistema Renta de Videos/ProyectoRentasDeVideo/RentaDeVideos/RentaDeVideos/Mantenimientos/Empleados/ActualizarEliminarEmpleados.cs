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
            string cadena = "SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE estado=1";

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
            try
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
                        string cadena = "UPDATE empleado SET id_cargo='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cargo"].Value.ToString()) + "', id_usuario='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_usuario"].Value.ToString()) +
                            "',dpi='" + dgridVista.Rows[e.RowIndex].Cells["dpi"].Value.ToString() + "', nit='" + dgridVista.Rows[e.RowIndex].Cells["nit"].Value.ToString() +
                            "', nombre='" + dgridVista.Rows[e.RowIndex].Cells["nombre"].Value.ToString() + "', apellido='" + dgridVista.Rows[e.RowIndex].Cells["apellido"].Value.ToString() +
                            "', correo='" + dgridVista.Rows[e.RowIndex].Cells["correo"].Value.ToString() + "', telefono='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["telefono"].Value.ToString())
                            + "', direccion='" + dgridVista.Rows[e.RowIndex].Cells["direccion"].Value.ToString() + "' WHERE id_empleado='" + iID + "';";
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
                string cadena = "UPDATE empleado SET estado=0  WHERE id_empleado='" + iIDEliminar + "';";
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
    }
}
