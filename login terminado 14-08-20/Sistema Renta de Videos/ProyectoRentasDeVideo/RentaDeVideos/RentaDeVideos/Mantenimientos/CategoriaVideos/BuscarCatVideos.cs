using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class BuscarCatVideos : Form
    {
        public BuscarCatVideos()
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

        Conexion cn = new Conexion();// se llama a la clase donde se encuentra la conexion de la bd 
        OdbcDataAdapter datos;// realiza una operación de relleno para seleccionar registros del origen de datos y colocarlos en DataSet.
        DataTable dt;// nos permite representar una determinada tabla en memoria, de modo que podamos interactuar con ella.

        //propiedad que nos permite arrastar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //medidas que va a tomar el slide en el form
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //nos permite regresar al formulario ingreso de categorias de video 
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_CatVideo form = new FormularioIngreso_CatVideo();// hace un llamado 
            form.Show();// nos muestra el formulario
            this.Hide();// oculta el formulario anterior
        }

        // nos muestra la ventana al ingreso de categorias de video
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCatVideos icv = new IngresoCatVideos();// hacemos el llamado al formulario
            icv.Show();//nos muestra el formulario
            this.Hide();//oculta el formulario en el que nos encontramos
        }

        // Permite el ingreso a la venta de actualizar y eliminar la categoria de videos 
       private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCatVideos aecv = new ActualizarEliminarCatVideos();// hacemos el llamado al formulario
            aecv.Show();//nos muestra el formulario
            this.Hide();// oculta el formulario donde nos encontremos 
        }

        //nos indica que estamos dentro de la ventana buscar categorias de video
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // alerta al usario
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // nos regresa al formulario principal o menu principal del sistema 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal(); // hace el llamado al formulario
            this.Dispose();//esconde el formulario del usuario
        }

        //permite minimizar la ventana del formulario
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//instruccion para minimizar 
        }

        //nos permite salir de la venta seleccionada 
        private void picSalir_Click(object sender, EventArgs e)
        {
            // le da un aviso al usuario si quiere seguir adelante con la accion 
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        // nos da las medidas o posiciones hacia donde podemos mover o arrastar el formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //carga los datos a la data grid 
        void CargarDatos()
        {
            string cadena = "SELECT id_categoria, nombre FROM categoria_video WHERE estado=1";// realiza la consulta a la BD 

            datos = new OdbcDataAdapter(cadena, cn.conexion()); // se realiza la conexio a la BD
            dt = new DataTable();// se crea la tabla que se usara para llenar el datagrid con los datos obtenidos 
            datos.Fill(dt); // se llena respectiva datatable
            dgridDatos.DataSource = dt; // se asignan todos los valores al datagrid 
        }

        // El metodo nos permite realizar la busqueda por medio del combox y textbox 
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")// se selecciona el la columna ID 
                {
                    // se realiza la consulta hacia la BD 
                    datos = new OdbcDataAdapter("SELECT id_categoria, nombre FROM categoria_video WHERE id_categoria='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();// se crea la la tabla con datatable para manejar todos los datos obtenidos
                    datos.Fill(dt);// se llena los datos en la datatable 
                    dgridDatos.DataSource = dt;// por ultimo asignamos dichos datos a la datagrid 
                }
                else if (cmbColumna.Text == "Nombre")// seleccionamos la columna Nombre 
                {// se realiza la consulta hacia la BD 
                    datos = new OdbcDataAdapter("SELECT id_categoria, nombre FROM categoria_video WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();// se crea la la tabla con datatable para manejar todos los datos
                    datos.Fill(dt);// se llena los datos en la datatable 
                    dgridDatos.DataSource = dt;// por ultimo asignamos dichos datos a la datagrid 
                }
            }
            catch (Exception) // se utilizo try catch para la excepciones 
            {

                throw;
            }

        }
    }
}
