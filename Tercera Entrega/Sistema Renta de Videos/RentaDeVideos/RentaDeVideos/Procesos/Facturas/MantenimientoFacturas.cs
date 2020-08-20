/*
 Mantenimiento facturas
 */
using RentaDeVideos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Facturas
{
    public partial class MantenimientoFacturas : Form
    {
        int iUsuario = Users.id_usario;//id usuario logueado
        int iIDEliminar;

        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        //Variables que se inicializan y permiten arrastrar y movilizar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public MantenimientoFacturas()
        {
            InitializeComponent();
            CargarDatos();
        }
        //Cargar datos a grid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc FROM encabezado_factura WHERE estado=1";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Eliminar datos, bitacora
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

                string sActualizarDetalle = "UPDATE detalle_factura SET estado=0  WHERE id_encabezado_factura='" + iIDEliminar + "';";//Estado =0 de detalle primero, para evitar problemas
                OdbcCommand consulta = new OdbcCommand(sActualizarDetalle, cn.conexion());
                consulta.ExecuteNonQuery();
                string sCadena = "UPDATE encabezado_factura SET estado=0  WHERE id_encabezado_factura='" + iIDEliminar + "';";//Estado=0 encabezado
                datos = new OdbcDataAdapter(sCadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "FACTURAS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "ELIMINAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Mostrar eliminar registro dentro de grid
        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_encabezado_factura"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }
        //Salir con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Mensaje de advertencia si abre formulario actual
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ManBusquedaFactura busqueda = new ManBusquedaFactura();
            this.Dispose();
            busqueda.Show();
        }
        //Movilizar formulario por medio de panel superior
        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
