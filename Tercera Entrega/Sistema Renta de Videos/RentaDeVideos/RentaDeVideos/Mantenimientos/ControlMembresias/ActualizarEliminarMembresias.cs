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
using System.Net;

namespace RentaDeVideos.Mantenimientos.ControlMembresias
{
    public partial class ActualizarEliminarMembresias : Form
    {
        //Obtiene ID de usuario logueado
        int iUsuario = Users.id_usario;

        public ActualizarEliminarMembresias()
        {
            InitializeComponent();
            CargarDatos();

        }

        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;
        //Permite arrastre de formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //Desplaza menu lateral
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }
        //Minimizar
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Salida con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Ir a formulario principal
        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Membresia form = new FormularioIngreso_Membresia();
            form.Show();
            this.Hide();
        }
        //Ir a formulario de ingreso de datos
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoMembresias icv = new IngresoMembresias();
            icv.Show();
            this.Hide();
        }
        //Mensaje de advertencia si usuario trata de abrir formulario actual
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Ir a formulario de busqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarMembresias bcv = new BuscarMembresias();
            bcv.Show();
            this.Hide();
        }
        //Salida sin validacion
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Arratre por medio de panel superior
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Cargar datos al grid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_membresia, descripcion, puntos, descuento FROM membresia WHERE estado=1";

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
        string sCadena;
        int iID;
        int iIDEliminar;
        //Actualiza desde grid y bitacora actualizada
        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString();
                if (sCadena == "")
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString());
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
                        string cadena = "UPDATE membresia SET descripcion='" + dgridVista.Rows[e.RowIndex].Cells["descripcion"].Value.ToString() + "',puntos='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["puntos"].Value.ToString()) + "', descuento='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["descuento"].Value.ToString()) + "' WHERE id_membresia='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();

                        OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                        llenarBitacora.CommandType = CommandType.StoredProcedure;
                        llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                        llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "MEMBRESIAS";
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
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        //Mensaje de Elinar Registro dentro del grid, click derecho en la fila
        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }
        //Elimina datos poniendo estado = 0 y actualiza bitacora
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

                string cadena = "UPDATE membresia SET estado=0  WHERE id_membresia='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "MEMBREISAS";
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
    }
}
