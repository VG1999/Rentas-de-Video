using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Empleados
{
    public partial class ActualizarEliminarEmpleados : Form
    {
        int iUsuario = 1;

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
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
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
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
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
                string cadena = "SELECT id_empleado, id_cargo, id_usuario, dpi, nit, nombre, apellido, correo, telefono, direccion FROM empleado WHERE estado=1";

                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                if (sCadena == string.Empty)
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_empleado"].Value.ToString());
                }
                if (iID != 0)
                {
                    IPHostEntry host_ip;
                    string sLocalIP = "?";
                    host_ip = Dns.GetHostEntry(Dns.GetHostName());

                    foreach (IPAddress ip in host_ip.AddressList)
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {
                            sLocalIP = ip.ToString();
                        }
                    }
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

                        OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                        llenarBitacora.CommandType = CommandType.StoredProcedure;
                        llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                        llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "EMPLEADOS";
                        llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "ACTUALIZAR";
                        llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                        llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                        llenarBitacora.ExecuteNonQuery();
                        llenarBitacora.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry host_ip;
                string sLocalIP = "?";
                host_ip = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host_ip.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        sLocalIP = ip.ToString();
                    }
                }

                string cadena = "UPDATE empleado SET estado=0  WHERE id_empleado='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "EMPLEADOS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "ELIMINAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
