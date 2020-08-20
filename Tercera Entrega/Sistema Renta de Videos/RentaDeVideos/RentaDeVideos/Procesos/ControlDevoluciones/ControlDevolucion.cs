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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.ControlDevoluciones
{
    public partial class ControlDevolucion : Form
    {
        Conexion cn = new Conexion();

        //Variables que se inicializan y permiten arrastrar y movilizar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        //Valor de id del usuario logueado
        int iUsuario = Users.id_usario;

        public ControlDevolucion()
        {
            InitializeComponent();
            cargarEstado();
            cargarFactura();
        }

        //Carga datos al combobox factura
        private void cargarFactura()
        {
            try
            {
                string sSQL = "SELECT id_encabezado_factura FROM encabezado_factura WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbFactura.Items.Clear();
                while (registro.Read())
                {
                    cmbFactura.Items.Add(registro["id_encabezado_factura"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Carga datos al combobox estado
        private void cargarEstado()
        {
            try
            {
                string sSQL = "SELECT id_video_estado FROM video_estado WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbEstado.Items.Clear();
                while (registro.Read())
                {
                    cmbEstado.Items.Add(registro["id_video_estado"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Salida con validacion
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
        //Se toma la multa asiganada al estado del video
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbEstado.SelectedIndex >= 0)
                {
                    string sSQL = "SELECT multa_unitaria FROM video_estado WHERE estado=1 AND id_video_estado=" + int.Parse(cmbEstado.SelectedItem.ToString());
                    OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = comando.ExecuteReader();

                    while (registro.Read())
                    {
                        txtMulta.Text = registro["multa_unitaria"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar Multa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Se toma los valores de factura para mostrarlos en pantalla, de acuerdo al ingreso del ID Factura
        private void cmbFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbFactura.SelectedIndex >= 0)
                {
                    string sSQL = "SELECT c.nombre as nombre, c.nit as nit, ef.fecha as fecha, v.titulo as titulo FROM encabezado_factura ef inner join detalle_factura df on ef.id_encabezado_factura = df.id_encabezado_factura inner join video v on df.id_video = v.id_video inner join cliente c on ef.id_cliente = c.id_cliente WHERE ef.estado=1 AND df.estado=1 AND ef.id_encabezado_factura=" + int.Parse(cmbFactura.SelectedItem.ToString())+";";
                    OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = comando.ExecuteReader();


                    cmbVideos.Items.Clear();
                    while (registro.Read())
                    {
                        dpFechaFac.Value = DateTime.Parse(registro["fecha"].ToString());
                        txtNIT.Text = registro["nit"].ToString();
                        txtNombre.Text = registro["nombre"].ToString();
                        cmbVideos.Items.Add(registro["titulo"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos de factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Bitacora e ingresos e datos
        private bool IngresarDatos()
        {
            int iCantidadAnterior, iCantidad = 0;
            OdbcConnection conexion = cn.conexion();

            OdbcCommand comando = conexion.CreateCommand();
            OdbcTransaction transaccion;

            transaccion = conexion.BeginTransaction();

            comando.Connection = conexion;
            comando.Transaction = transaccion;

            try{
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

                DateTime dtFechaFacturacion = dpFechaFac.Value;
                DateTime dtFechaDevolucion = dpFechaDev.Value;

                //Inserta en encabezado de compra
                comando.CommandText = "INSERT INTO control_recibido (id_factura_encabezado, fecha_emision, fecha_recibido, id_video_estado, estado) VALUES (?,?,?,?,?);";
                comando.Parameters.Add("id_factura_encabezado", OdbcType.Int).Value = int.Parse(cmbFactura.SelectedItem.ToString());
                comando.Parameters.Add("fecha_emision", OdbcType.DateTime).Value = dtFechaFacturacion;
                comando.Parameters.Add("fecha_recibido", OdbcType.DateTime).Value = dtFechaDevolucion;
                comando.Parameters.Add("id_video_estado", OdbcType.Int).Value = int.Parse(cmbEstado.SelectedItem.ToString());
                comando.Parameters.Add("estado", OdbcType.Int).Value = 1;
                comando.ExecuteNonQuery();

                string sSQL = "select v.cantidad as video, df.cantidad as cantidad from encabezado_factura ef inner join detalle_factura df on ef.id_encabezado_factura=df.id_encabezado_factura inner join video v on df.id_video=v.id_video WHERE ef.estado=1 AND df.estado=1 AND v.titulo='" + cmbVideos.SelectedItem + "' AND df.id_encabezado_factura=" + cmbFactura.SelectedItem.ToString() + ";";
                OdbcCommand actualizar = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = actualizar.ExecuteReader();

                while (registro.Read())
                {
                    iCantidad = int.Parse(registro["cantidad"].ToString());
                    Console.WriteLine(iCantidad);
                    iCantidadAnterior = int.Parse(registro["video"].ToString());
                    comando.CommandText = "UPDATE video SET cantidad=" + (iCantidad + iCantidadAnterior) + " WHERE titulo='" + cmbVideos.SelectedItem + "';";
                    comando.ExecuteNonQuery();
                }
                comando.CommandText = "UPDATE detalle_factura d INNER JOIN video v ON (d.id_video=v.id_video)SET d.estado=0 WHERE id_encabezado_factura=" + cmbFactura.SelectedItem.ToString() + " AND v.titulo='" + cmbVideos.SelectedItem+"';";
                comando.ExecuteNonQuery();
                
                
                /*OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = 1;//iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CONTROL_RECIBIDO";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();*/
                transaccion.Commit();
                Console.WriteLine("Transaccion Exitosa");
                // llenarBitacora.Connection.Close();

                return true;

            }
            catch (Exception ex){
                transaccion.Rollback();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Trasaccion Fallida");
                MessageBox.Show("Error transaccion devolucion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarComponentes();
                return false;
            }
        }
        private bool ActualizarFactura()
        {
            OdbcConnection conexion = cn.conexion();

            OdbcCommand comando = conexion.CreateCommand();
            OdbcTransaction transaccion;

            transaccion = conexion.BeginTransaction();

            comando.Connection = conexion;
            comando.Transaction = transaccion;
            try
            {
                string sConsulta = "select id_video from detalle_factura where id_encabezado_factura='" + cmbFactura.SelectedItem + "' AND estado=1;";
                OdbcCommand validar = new OdbcCommand(sConsulta, cn.conexion());
                OdbcDataReader campo = validar.ExecuteReader();
                Console.WriteLine(cmbFactura.SelectedItem.ToString());
                Console.WriteLine("antes del if");
                if (!campo.Read())
                {
                    Console.WriteLine("dentro del if");

                    comando.CommandText = "UPDATE encabezado_factura SET estado=0 WHERE id_encabezado_factura=" + cmbFactura.SelectedItem.ToString() + ";";
                    comando.ExecuteNonQuery();
                }
                Console.WriteLine("despues del while");

                cargarFactura();
                transaccion.Commit();
                Console.WriteLine("Actualizacion Exitosa");

                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Actualizacion Fallida");
                MessageBox.Show("Error actualizar factura", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarComponentes();
                return false;
            }
        }
        //Valida componentes
        private bool validarComponentes()
        {
            if (cmbFactura.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Factura", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFactura.SelectedItem = null;
                return false;
            }
            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Estado Video", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEstado.SelectedItem = null;
                return false;
            }
            if (cmbVideos.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Video Adquirido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVideos.SelectedItem = null;
                return false;
            }
            return true;
        }

        //Limpia componetes 
        private void LimpiarComponentes()
        {
            cmbEstado.SelectedItem = null;
            // cmbFactura.SelectedItem = null;
            // cmbVideos.SelectedItem = null;
            cmbFactura.Items.Clear();
            cmbVideos.Items.Clear();
            txtNIT.Text = "";
            txtMulta.Text = "";
            txtNombre.Text = "";
            dpFechaDev.Value = DateTime.Now;
            dpFechaFac.Value = DateTime.Now;
        }
        //Boton de ingresar datos
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarComponentes() == true && IngresarDatos() == true)
            {
                ActualizarFactura();
                LimpiarComponentes();
                MessageBox.Show("Datos Guardados Correctamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarFactura();
            }
            else
            {
                MessageBox.Show("No se pudieron ingresar los datos, intente nuevamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Arratre de formulario por panel superior
        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
