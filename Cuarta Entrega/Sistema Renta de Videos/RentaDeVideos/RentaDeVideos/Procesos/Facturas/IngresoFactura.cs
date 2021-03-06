﻿/*
 Formulario de ingreso de factura
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Facturas
{
    public partial class IngresoFactura : Form
    {
        Conexion cn = new Conexion();
        //ID de usurio logueado
        int iUsuario = Users.id_usario;

        //Variables que se inicializan y permiten arrastrar y movilizar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public IngresoFactura()
        {
            InitializeComponent();
            cargarClientes();
            cargarEmpleados();
            cargarVideos();
           
        }
        //Carga datos al combobox video, del grid
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
        //Carga datos a combobx clientes
        private void cargarClientes()
        {
            try
            {
                string sSQL = "SELECT id_cliente FROM cliente WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
                while (registro.Read())
                {
                    cmbCliente.Items.Add(registro["id_cliente"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //carga datos a combobox empleados
        private void cargarEmpleados()
        {
            try
            {
                string sSQL = "SELECT id_empleado FROM empleado WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
                while (registro.Read())
                {
                    cmbEmpleado.Items.Add(registro["id_empleado"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Toma datos y los muestra en textbox, de acuerdo al id seleccionado
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbCliente.SelectedIndex >= 0)
                {
                    string sSQL = "SELECT nombre, apellido, nit, direccion FROM cliente WHERE estado=1 AND id_cliente=" + int.Parse(cmbCliente.SelectedItem.ToString());
                    OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = comando.ExecuteReader();

                    while (registro.Read())
                    {
                        txtNombreCliente.Text = registro["nombre"].ToString();
                        txtApellidos.Text = registro["apellido"].ToString();
                        txtNIT.Text = registro["nit"].ToString();
                        txtDireccion.Text = registro["direccion"].ToString();
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
        //Calculo de bon/desc, subtotal, subtotal/desc,
        //No muestra precio pero si se toma de la tabla para el respectivo calculo
        private void dgridDatosFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dBono = 5.25;
            double dDesc = 0.10;
            double dPivote = 0;
            try
            {
                if (dgridDatosFactura.Rows[e.RowIndex].Cells["cmbVideo"].Value != null)
                {
                    if (dgridDatosFactura.Rows[e.RowIndex].Cells["txtCantidad"].Value != null)
                    {
                        if (dgridDatosFactura.Rows[e.RowIndex].Cells["cmbBonoDesc"].Value != null)
                        {
                            iIDVideo = int.Parse(dgridDatosFactura.Rows[e.RowIndex].Cells["cmbVideo"].Value.ToString());
                            string sSQL = "SELECT precio FROM video WHERE id_video=" + iIDVideo;
                            OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                            OdbcDataReader registro = comando.ExecuteReader();

                            iCantidad = int.Parse(dgridDatosFactura.Rows[e.RowIndex].Cells["txtCantidad"].Value.ToString());

                            while (registro.Read())
                            {
                                dPrecio = double.Parse(registro["precio"].ToString());
                            }
                            if (dgridDatosFactura.Rows[e.RowIndex].Cells["cmbBonoDesc"].Value.ToString() == "0")
                            {
                                dgridDatosFactura.Rows[e.RowIndex].Cells["txtSubtotalBD"].Value = dBono;
                                dSubTotal = (dPrecio * iCantidad) + dBono;
                            }
                            else
                            {
                                dgridDatosFactura.Rows[e.RowIndex].Cells["txtSubtotalBD"].Value = dDesc;
                                dPivote = (dPivote * iCantidad) * dDesc;
                                dSubTotal = (dPrecio * iCantidad) - dPivote;
                            }

                            dgridDatosFactura.Rows[e.RowIndex].Cells["txtSubtotal"].Value = dSubTotal;
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar factura detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //suma columna de subtotal
        private double SumarColumnas()
        {
            try
            {
                foreach (DataGridViewRow row in dgridDatosFactura.Rows)
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
        //Ingresa datos a factura
        private bool RegistrarFactura()
        {
            int iCodLinea = 0, iVideo, iCantidad, iBonoDesc, iCantidadAnterior;
            double dSubtotalBD, dSubtotal;

            OdbcConnection conexion = cn.conexion();

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
                DateTime dtFechaIngreso = dpFecha.Value;
                //inserta encabezado primero
                comando.CommandText = "INSERT INTO encabezado_factura (id_encabezado_factura, id_cliente, id_empleado, no_serie, fecha, forma_pago, total_factura, tipo_doc, estado) VALUES (?,?,?,?,?,?,?,?,?);";
                comando.Parameters.Add("id_encabezado_factura", OdbcType.Int).Value = int.Parse(txtNoFactura.Text);
                comando.Parameters.Add("id_cliente", OdbcType.Int).Value = int.Parse(cmbCliente.SelectedItem.ToString());
                comando.Parameters.Add("id_empleado", OdbcType.Int).Value = int.Parse(cmbEmpleado.SelectedItem.ToString());
                comando.Parameters.Add("no_serie", OdbcType.Text).Value = txtSerie.Text;
                comando.Parameters.Add("fecha", OdbcType.DateTime).Value = dtFechaIngreso;
                comando.Parameters.Add("forma_pago", OdbcType.Int).Value = int.Parse(cmbFormaPago.SelectedItem.ToString());
                comando.Parameters.Add("total_factura", OdbcType.Double).Value = SumarColumnas();
                comando.Parameters.Add("tipo_doc", OdbcType.Int).Value = int.Parse(cmbTipoDoc.SelectedItem.ToString());
                comando.Parameters.Add("estado", OdbcType.Int).Value = 1;
                comando.ExecuteNonQuery();


                int iFilas = dgridDatosFactura.Rows.Count;
                Console.WriteLine(iFilas);
                //Linea por linea inserta detalle
                while (iCodLinea < (iFilas - 1))
                {
                    iVideo = int.Parse(dgridDatosFactura.Rows[iCodLinea].Cells["cmbVideo"].Value.ToString());
                    iCantidad = int.Parse(dgridDatosFactura.Rows[iCodLinea].Cells["txtCantidad"].Value.ToString());
                    dSubtotalBD = double.Parse(dgridDatosFactura.Rows[iCodLinea].Cells["txtSubtotalBD"].Value.ToString());
                    iBonoDesc = int.Parse(dgridDatosFactura.Rows[iCodLinea].Cells["cmbBonoDesc"].Value.ToString());
                    dSubtotal = double.Parse(dgridDatosFactura.Rows[iCodLinea].Cells["txtSubtotal"].Value.ToString());
                    string sSQL = "SELECT cantidad FROM video WHERE estado=1 AND id_video=" + iVideo + ";";
                    ++iCodLinea;
                    comando.CommandText = "INSERT INTO detalle_factura (id_encabezado_factura, cod_linea, id_video, cantidad, bon_desc, subtotal_bon_desc, subtotal, estado) VALUES ('" + txtNoFactura.Text + "','" + iCodLinea + "','" + iVideo + "','" + iCantidad +"','"+iBonoDesc +"','" + dSubtotalBD + "','" + dSubtotal + "', 1);";
                    comando.ExecuteNonQuery();

                    OdbcCommand actualizar = new OdbcCommand(sSQL, cn.conexion());
                    OdbcDataReader registro = actualizar.ExecuteReader();

                    while (registro.Read())
                    {
                        iCantidadAnterior = int.Parse(registro["cantidad"].ToString());
                        if (iCantidad <= iCantidadAnterior)
                        {
                            comando.CommandText = "UPDATE video SET cantidad=" + (iCantidadAnterior-iCantidad) + " WHERE id_video=" + iVideo + ";";
                            comando.ExecuteNonQuery();

                        }
                        else
                        {
                            MessageBox.Show("Error No hay existencias suficientes", "Error en transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine("Cantidad insuficiente, cantidad a rentar: " + iCantidad + " la cantidad de existencias "+iCantidadAnterior);
                            LimpiarComponentes();
                            return false;
                        }
                    }
                }

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "FACTURAS";
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
                MessageBox.Show("Error al transaccion facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarComponentes();
                return false;
            }
        }
        //valida componentes externos a grid
        private bool validarComponentes()
        {
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Clientes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCliente.SelectedItem = null;
                return false;
            }
            if (cmbEmpleado.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Empleados", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEmpleado.SelectedItem = null;
                return false;
            }
            if (cmbFormaPago.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Forma Pago", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFormaPago.SelectedItem = null;
                return false;
            }
            if (cmbTipoDoc.SelectedItem == null)
            {
                MessageBox.Show("Ingrese Tipo Documento", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTipoDoc.SelectedItem = null;
                return false;
            }
            if (txtNoFactura.Text == "")
            {
                MessageBox.Show("Ingrese Factura", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNoFactura.Text = "";
                return false;
            }
            if (txtSerie.Text == "")
            {
                MessageBox.Show("Ingrese No. Serie", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerie.Text = "";
                return false;
            }
            return true;
        }
        //limpia componentes y grid
        private void LimpiarComponentes()
        {
            cmbCliente.SelectedItem = null;
            cmbEmpleado.SelectedItem = null;
            cmbFormaPago.SelectedItem = null;
            cmbTipoDoc.SelectedItem = null;
            txtNIT.Text = "";
            txtNoFactura.Text = "";
            txtSerie.Text = "";
            txtDireccion.Text = "";
            txtApellidos.Text = "";
            txtNombreCliente.Text = "";
            dpFecha.Value = DateTime.Now;
            foreach (DataGridViewRow row in dgridDatosFactura.Rows)
            {
                row.Cells["cmbVideo"].Value = null;
                row.Cells["txtCantidad"].Value = null;
                row.Cells["txtSubtotalBD"].Value = null;
                row.Cells["cmbBonoDesc"].Value = null;
                row.Cells["txtSubtotal"].Value = null;
            }
            dgridDatosFactura.Rows.Clear();
        }
        //Boton de guardar datos
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarComponentes() == true && RegistrarFactura()==true)
            {
                LimpiarComponentes();
                MessageBox.Show("Datos Guardados Correctamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudieron ingresar los datos, intente nuevamente", "Datos Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Factura solo numeros
        private void txtNoFactura_KeyPress(object sender, KeyPressEventArgs e)
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
        //Movilizar formulario por medio de panel superior
        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
