﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using RentaDeVideos.Clases;
using System.Data.Odbc;
using System.Net;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class IngresoClientes : Form
    {
        int iUsuario = 1;
        public IngresoClientes()
        {
            InitializeComponent();
            inicializarMembresia();
        }

        Conexion cn = new Conexion();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

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

        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fic = new FormularioIngreso_Cliente();
            fic.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();
            bc.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsLetter(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtDPI_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8 && cCaracter != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMembresia_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cCaracter = e.KeyChar;
            if (!char.IsDigit(cCaracter) && cCaracter != 8)
            {
                e.Handled = true;
            }
        }

        private void inicializarMembresia()
        {
            try
            {
                string sSQL = "SELECT id_membresia FROM membresia WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();

                cmbMembresia.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMembresia.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbMembresia.Items.Add(registro["id_membresia"].ToString());
                }
                cmbMembresia.SelectedIndex.Equals(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al datos al combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        void insertarClientes()
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
                string cadena = "INSERT INTO cliente (id_membresia, dpi, nit, nombre, apellido, telefono, correo, direccion, estado) VALUES ('" + cmbMembresia.SelectedItem.ToString() + "','" + txtDPI.Text + "','" + txtNIT.Text + "','" + txtNombre.Text + "','" + txtApellidos.Text + "','" + txtTelefono.Text + "','" + txtCorreo.Text + "','" + txtDireccion.Text+ "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CLIENTES";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "INSERTAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void borraDatos()
        {
            cmbMembresia.SelectedIndex = 0;
            txtDPI.Text = "";
            txtNIT.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        private bool validarTextbox()
        {
            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Ingrese Apellido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = "";
                txtApellidos.Focus();
                return false;
            }
            else if (cmbMembresia.SelectedIndex == 0)
            {
                MessageBox.Show("Ingrese Membresia", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMembresia.SelectedIndex = 0;
                return false;
            }
            else if (txtCorreo.Text == "")
            {
                MessageBox.Show("Ingrese Correo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            else if (txtDPI.Text == "")
            {
                MessageBox.Show("Ingrese DPI", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = "";
                txtDPI.Focus();
                return false;
            }
            else if (txtNIT.Text == "")
            {
                MessageBox.Show("Ingrese NIT", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            else if(txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese Nombre", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            else if(txtTelefono.Text == "")
            {
                MessageBox.Show("Ingrese Telefono", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();
                return false;
            }
            else if (txtDireccion.Text == "")
            {
                MessageBox.Show("Ingrese Direccion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Text = "";
                txtDireccion.Focus();
                return false;
            }
            else if(!Regex.Match(txtNombre.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo nombre invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Text = "";
                txtNombre.Focus();
                return false;
            }
            else if(!Regex.Match(txtApellidos.Text, @"^[A-Za-z]+([\ A-Za-z]+)*$").Success)
            {
                MessageBox.Show("Datos del campo apellido invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Text = "";
                txtApellidos.Focus();
                return false;
            }
            else if(!Regex.Match(txtTelefono.Text, @"^[0-9]\d{7}$").Success)
            {
                MessageBox.Show("Datos del campo telefono invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Text = "";
                txtTelefono.Focus();
                return false;
            }
            else if (!Regex.Match(txtNIT.Text, @"^[0-9]{6}[-][0-9A-z]{1}$").Success)
            {
                MessageBox.Show("Datos del campo NIT invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNIT.Text = "";
                txtNIT.Focus();
                return false;
            }
            else if (!Regex.Match(txtDPI.Text, @"(^[0-9]{4}[ ][0-9]{5}[ ][0-9]{4})$").Success)
            {
                MessageBox.Show("Datos del campo DPI invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDPI.Text = "";
                txtDPI.Focus();
                return false;
            }
            else if (!Regex.Match(txtCorreo.Text, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+.([a-zA-Z]{2,4})+$").Success)
            {
                MessageBox.Show("Datos del campo correo invalido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Text = "";
                txtCorreo.Focus();
                return false;
            }
            return true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextbox() == true)
            {
                insertarClientes();
                MessageBox.Show("Datos Correctamente Guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                borraDatos();
            }
        }
    }
}
