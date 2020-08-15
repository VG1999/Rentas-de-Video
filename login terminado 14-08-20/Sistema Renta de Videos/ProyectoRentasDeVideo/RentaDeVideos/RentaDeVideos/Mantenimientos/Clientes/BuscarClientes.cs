using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class BuscarClientes : Form
    {
        public BuscarClientes()
        {
            InitializeComponent();
            try
            {
                CargarDatos();
            }
            catch (Exception)
            {

                throw;
            }

        }

        Conexion cn = new Conexion();        // se llama a la clase donde se encuentra la conexion de la bd 
        OdbcDataAdapter datos; // una operación de relleno para seleccionar registros del origen de datos
        DataTable dt;  // nos permite representar una determinada tabla en memoria, de modo que podamos interactuar con ella.

        // propiedad para arrastrar el formulario de busqueda de clientes 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // medidas que se le dara al slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //nos permite regresar al formulario principal del mantenimiento de clientes 
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fig = new FormularioIngreso_Cliente();// hacemos un llamado al formulario 
            fig.Show();//mostramos el formulario 
            this.Hide();// ocultamos de la vista el formulario anterior 
        }

        //Nos da la vista en donde se llevara acabo el registro por cliente 
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoClientes ic = new IngresoClientes(); //llamamos al formulario 
            ic.Show();// mostramos el formulario 
            this.Hide();// ocultamos el formulario anterior 
        }

        // nos da la vista a la actualizacion e eliminacion de los datos de clientes 
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarClientes aec = new ActualizarEliminarClientes();
            aec.Show();
            this.Hide();
        }

        //le notifica al usuario que ya esta dentro del formulario busqueda 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // mensaje de aviso al usuario 
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // nos regresa al formulario principal del sistema 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// llamamos al formulario 
            this.Dispose();// ocultamos el formulario anterior 
        }
        // nos permite minimizar el formulario 
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;// instruccion para minimizar la ventana 
        }
        
        // el metodo picSalir nos permite cerrar la venta actual 
        private void picSalir_Click(object sender, EventArgs e)
        {
            // se le da un aviso al usuario si quiere completar los cambios 
            DialogResult drResultadoMensaje;// instruccion para validar la respuesta del usario 
            // mensaje de alerta al usuario 
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)// validacion de ka respuesta del usario 
            {
                this.Dispose(); // ocultamos el formulario actual 
            }
        }

        // posiciones hacia donde puedo arrastrar el formulario 
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //cargamos los datos al sistema
        void CargarDatos()
        {
            //realizamos la consulta hacia la tabla de cliente en la BD 
            string cadena = "SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE estado=1";
            // hacemos la conexion a la BD 
            datos = new OdbcDataAdapter(cadena, cn.conexion());
            //creamos la tabla para manejar todos los datos 
            dt = new DataTable();
            //llenamos lq datatable con dichos datos 
            datos.Fill(dt);
            //asigamos los datos a la datagrid 
            dgridDatos.DataSource = dt;
        }

        //el metodo txtBuscar nos permitira realizar la busqueda por columna y segun lo ingresado por el usuario 
        //utilizamos if para realizar todos las validaciones 
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")// seleccionamos el campo id 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE id_cliente='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();//creamos una tabla para el data grid y haci manejar  los datos 
                    datos.Fill(dt);// llenamos la DataTable 
                    dgridDatos.DataSource = dt;// asignamos los valores a la datagrid 
                }
                else if (cmbColumna.Text == "ID Membresia")// seleccionamos el campo del id membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE id_membresia='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y haci manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los valores a la datagrid 
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "DPI")// seleccionamos el campo del DPI membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE dpi='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y haci manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los valores a la datagrid 
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "NIT")// seleccionamos el campo del NIT membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE nit='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y haci manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los valores a la datagrid 
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "NOMBRE")// seleccionamos el campo del nombre membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y haci manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los datos a la datagrid 
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "APELLIDO")// seleccionamos el campo del apellido membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE apellido='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y haci manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los datos a la datagrid
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "CORREO")// seleccionamos el campo de correo  membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE correo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y hacia manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los datos a la datagrid
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "TELEFONO")// seleccionamos el campo de telefono  membresia 
                {
                    // realizamos la consulta hacia la BD
                    datos = new OdbcDataAdapter("SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE telefono='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    //creamos una tabla para el data grid y hacia manejar  los datos 
                    dt = new DataTable();
                    // llenamos la DataTable 
                    datos.Fill(dt);
                    // asignamos los datos a la datagrid
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception) // utilizamos try y catch para la excepciones de dicho metodo 
            {

                throw;
            }

        }
    }
}
