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
using System.Data.Odbc;
using RentaDeVideos.Clases;

namespace RentaDeVideos.Mantenimientos.Usuarios
{
    public partial class BuscarUsuarios : Form
    {
        public BuscarUsuarios()
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Usuario fu = new FormularioIngreso_Usuario();
            fu.Show();
            this.Hide();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoUsuarios iu = new IngresoUsuarios();
            iu.Show();
            this.Hide();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarUsuarios aeu = new ActualizarEliminarUsuarios();
            aeu.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            FormularioInicioMenu fim = new FormularioInicioMenu();
            fim.Show();
            this.Hide();
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        void CargarDatos()
        {
            string cadena = "SELECT * FROM control_usuario";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dgridDatos.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbColumna.Text == "Usuario")
            {
                datos = new OdbcDataAdapter("SELECT id_usuario, usuario, contraseña_usuario, rol_usuario FROM control_usuario WHERE usuario='" + txtBuscar.Text+"' AND estado=1",cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Contraseña")
            {
                datos = new OdbcDataAdapter("SELECT id_usuario, usuario, contraseña_usuario, rol_usuario FROM control_usuario WHERE contraseña_usuario='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "Rol")
            {
                datos = new OdbcDataAdapter("SELECT id_usuario, usuario, contraseña_usuario, rol_usuario FROM control_usuario WHERE rol_usuario='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            else if (cmbColumna.Text == "ID")
            {
                datos = new OdbcDataAdapter("SELECT id_usuario, usuario, contraseña_usuario, rol_usuario FROM control_usuario WHERE id_usuario='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
        }
    }
}
