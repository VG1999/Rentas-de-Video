/*
 Formulario que contiene la opcion de busque de cargo
 */
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

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class BuscarCargos : Form
    {
        public BuscarCargos()
        {
            InitializeComponent();
            CargarDatos();

        }

        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;
        //Variables que permiten arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Permite que el menu lateral se desplace
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //Direcciona al formulario principal
        private void btnCargos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cargo fic = new FormularioIngreso_Cargo();
            fic.Show();
            this.Hide();
        }
        //Direcciona al formulario de ingreso
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCargos ic = new IngresoCargos();
            ic.Show();
            this.Hide();
        }
        //Direcciona al formulario Actualizacion y Eliminacion
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos();
            aec.Show();
            this.Hide();
        }
        //Mensaje de advertencia si el usuario busca acceder de nuevo al formulario actual
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //Salida sin validacion
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();
            this.Dispose();
        }
        //Minimiza formulario
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Salida del formulario con validacion
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        //Permite que el formulario se arratre por medio del panel superior
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Muestra los datos de la tabla en el grid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_cargo, nombre, descripcion FROM cargo WHERE estado=1";//Estado =1 se refiere al que el registro esta activo o permitido

                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //Busca el dato ingresado en el textbox
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Se busca de acuerdo a las columnas, el contenido de los registros
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE id_cargo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Nombre")
                {
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Descripcion")
                {
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE descripcion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al buscar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
