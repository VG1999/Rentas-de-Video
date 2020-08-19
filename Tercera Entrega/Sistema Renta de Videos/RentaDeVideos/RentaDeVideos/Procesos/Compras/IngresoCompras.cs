/*
 Formulario de ingreso de compras
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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Compras
{
    public partial class IngresoCompras : Form
    {
        Conexion cn = new Conexion();

        //Valor de id del usuario logueado
        int iUsuario = Users.id_usario;

        public IngresoCompras()
        {
            InitializeComponent();
            cargarVideos();
            cargarProveedores();
        }
        //Carga datos al combobox video, dentro del grid
       private void cargarVideos()
        {
            try
            {
                string sSQL = "SELECT id_video FROM video WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

               
                while (registro.Read())
                {
                    cmbVideo.Items.Add(registro["id_video"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //carga datos al combobox proveedores
        private void cargarProveedores()
        {
            try
            {
                string sSQL = "SELECT id_proveedor FROM proveedor WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
                while (registro.Read())
                {
                    cmbProveedor.Items.Add(registro["id_proveedor"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Inserta el nit del proveedor en el textbox si el usuario selecciona un id proveedor
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbProveedor.SelectedIndex >= 0)
                {
                    string sSQL = "SELECT nit FROM proveedor WHERE estado=1 AND id_proveedor="+int.Parse(cmbProveedor.SelectedItem.ToString());
                    OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = comando.ExecuteReader();

                    while (registro.Read())
                    {
                        txtNIT.Text = registro["nit"].ToString();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar NIT", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int iIDVideo;
        int iCantidad;
        double dPrecio;
        double dSubTotal;
        double dTotal;
        //Muestra el calculo de subtotal, y muestra el precio de producto selecccionado
        private void dgridDetalleFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgridDetalleFactura.Rows[e.RowIndex].Cells["cmbVideo"].Value!=null)
                {
                    if (dgridDetalleFactura.Rows[e.RowIndex].Cells["txtCantidad"].Value != null)
                    {
                        iIDVideo = int.Parse(dgridDetalleFactura.Rows[e.RowIndex].Cells["cmbVideo"].Value.ToString());
                        string sSQL = "SELECT precio FROM video WHERE id_video="+iIDVideo;
                        OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                        OdbcDataReader registro = comando.ExecuteReader();


                        while (registro.Read())
                        {
                            dgridDetalleFactura.Rows[e.RowIndex].Cells["txtPrecio"].Value = registro["precio"];
                        }

                        dPrecio = double.Parse(dgridDetalleFactura.Rows[e.RowIndex].Cells["txtPrecio"].Value.ToString());
                        iCantidad = int.Parse(dgridDetalleFactura.Rows[e.RowIndex].Cells["txtCantidad"].Value.ToString());
                        dSubTotal = dPrecio * iCantidad;
                        dgridDetalleFactura.Rows[e.RowIndex].Cells["txtSubtotal"].Value = dSubTotal;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar compra detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //Suma colmna subtotal para sacar el total
        private double SumarColumnas()
        {
            try
            {
                foreach (DataGridViewRow row in dgridDetalleFactura.Rows)
                {
                    if (row.Cells["txtSubtotal"].Value != null)
                        dTotal += (double)row.Cells["txtSubtotal"].Value;
                }
                lblTotal.Text = dTotal.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al totales compras", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dTotal;
        }
        //Registrar compra
        private bool RegistrarCompra()
        {
            int iCodLinea = 0, iVideo, iCantidad, iCantidadAnterior;
            double dPrecio, dSubtotal;

            OdbcConnection conexion = cn.conexion();

         //   conexion.Open();

            OdbcCommand comando = conexion.CreateCommand();
            OdbcTransaction transaccion;

            transaccion = conexion.BeginTransaction();

            comando.Connection = conexion;
            comando.Transaction = transaccion;

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
                
                //Inserta en encabezado de compra
                comando.CommandText = "INSERT INTO encabezado_compra (id_compra, id_proveedor, fecha_compra, total_compra, estado) VALUES ('" + txtIDFactura.Text + "','" + cmbProveedor.SelectedItem.ToString() + "','" + txtFecha.Text + "','" + SumarColumnas().ToString() + "', 1);";
                comando.ExecuteNonQuery();

                int iFilas = dgridDetalleFactura.Rows.Count;
                Console.WriteLine(iFilas);
                //Linea por linea del grid inserta a detalle compra
                while (iCodLinea < (iFilas - 1))
                {
                    iVideo = int.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["cmbVideo"].Value.ToString());
                    iCantidad = int.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtCantidad"].Value.ToString());
                    dPrecio = double.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtPrecio"].Value.ToString());
                    dSubtotal = double.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtSubtotal"].Value.ToString());
                    string sSQL = "SELECT cantidad FROM video WHERE estado=1 AND id_video=" + iVideo + ";";
                    ++iCodLinea;
                    comando.CommandText = "INSERT INTO detalle_compra (id_compra, cod_linea, id_video, cantidad, precio_unitario, subtotal, estado) VALUES ('" + txtIDFactura.Text + "','" + iCodLinea + "','" + iVideo + "','" + iCantidad + "','" + dPrecio + "','" + dSubtotal + "', 1);";
                    comando.ExecuteNonQuery();

               
                    OdbcCommand actualizar = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = actualizar.ExecuteReader();

                    while (registro.Read())
                    {
                        iCantidadAnterior = int.Parse(registro["cantidad"].ToString());
                        comando.CommandText = "UPDATE video SET cantidad=" + (iCantidad+iCantidadAnterior) + " WHERE id_video=" + iVideo+";";
                        comando.ExecuteNonQuery();
                    }
                }
                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "COMPRAS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();

                transaccion.Commit();
                Console.WriteLine("Transaccion Exitosa");

                llenarBitacora.Connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                Console.WriteLine(ex.Message);
                Console.WriteLine("Trasaccion Fallida");
                MessageBox.Show("Error al ingresar compras", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarComponentes();
                return false;
            }
        }
        //Valida componentes, excepto del grid
        private bool validarComponentes()
        {
            int iValor = dgridDetalleFactura.Rows.Count;
            if (cmbProveedor.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Proveedores", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProveedor.SelectedItem = null;
                return false;
            }
            if (txtFecha.Text == "")
            {
                MessageBox.Show("Ingrese Fecha", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFecha.Text = "";
                txtFecha.Focus();
                return false;
            }
            if (txtIDFactura.Text == "")
            {
                MessageBox.Show("Ingrese ID Factura", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDFactura.Text = "";
                txtIDFactura.Focus();
                return false;
            }
            if (!Regex.Match(txtFecha.Text, @"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$").Success)
            {
                MessageBox.Show("Datos del campo fecha invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFecha.Text = "";
                txtFecha.Focus();
                return false;
            }
            return true;
        }
        //Limpia componetes incluyendo grid
        private void LimpiarComponentes()
        {
            cmbProveedor.SelectedItem = null;
            txtNIT.Text = "";
            txtFecha.Text = "";
            txtIDFactura.Text = "";
            foreach (DataGridViewRow row in dgridDetalleFactura.Rows)
            {
                row.Cells["cmbVideo"].Value = null;
                row.Cells["txtCantidad"].Value = null;
                row.Cells["txtPrecio"].Value = null;
                row.Cells["txtSubtotal"].Value = null;
            }
            dgridDetalleFactura.Rows.Clear();
        }
        //Boton de guardar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarComponentes() == true && RegistrarCompra() == true)
            {
                LimpiarComponentes();
                MessageBox.Show("Datos Guardados Correctamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudieron ingresar los datos, intente nuevamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Solo numeros
        private void txtIDFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
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
    }
}
