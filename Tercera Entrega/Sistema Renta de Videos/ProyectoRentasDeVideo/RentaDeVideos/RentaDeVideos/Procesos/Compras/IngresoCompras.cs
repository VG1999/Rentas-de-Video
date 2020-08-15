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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Compras
{
    public partial class IngresoCompras : Form
    {
        Conexion cn = new Conexion();
        int iUsuario = 1;

        public IngresoCompras()
        {
            InitializeComponent();
            cargarVideos();
            cargarProveedores();
        }
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

        private void RegistrarCompra()
        {
            int iCodLinea = 0, iVideo, iCantidad;
            double dPrecio, dSubtotal;
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

                string cadena = "INSERT INTO encabezado_compra (id_compra, id_proveedor, fecha_compra, total_compra, estado) VALUES ('" + txtIDFactura.Text + "','" + cmbProveedor.SelectedItem.ToString() + "','" + txtFecha.Text + "','" + SumarColumnas().ToString() + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                int iFilas = dgridDetalleFactura.Rows.Count;
                Console.WriteLine(iFilas);
                while (iCodLinea < (iFilas - 1))
                {
                    iVideo = int.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["cmbVideo"].Value.ToString());
                    iCantidad = int.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtCantidad"].Value.ToString());
                    dPrecio = double.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtPrecio"].Value.ToString());
                    dSubtotal = double.Parse(dgridDetalleFactura.Rows[iCodLinea].Cells["txtSubtotal"].Value.ToString());
                    ++iCodLinea;
                    string sComando = "INSERT INTO detalle_compra (id_compra, cod_linea, id_video, cantidad, precio_unitario, subtotal, estado) VALUES ('" + txtIDFactura.Text + "','" + iCodLinea + "','" + iVideo + "','" + iCantidad + "','" + dPrecio + "','" + dSubtotal + "', 1);";
                    OdbcCommand insertar = new OdbcCommand(sComando, cn.conexion());
                    insertar.ExecuteNonQuery();
                }

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "COMPRAS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al ingresar compras", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validarComponentes()
        {
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
                return false;
            }
            if (txtIDFactura.Text == "")
            {
                MessageBox.Show("Ingrese ID Factura", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDFactura.Text = "";
                return false;
            }
            
            return true;
        }

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
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarComponentes() == true)
            {
                RegistrarCompra();
                LimpiarComponentes();
                MessageBox.Show("Datos Guardados Correctamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtIDFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
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

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
