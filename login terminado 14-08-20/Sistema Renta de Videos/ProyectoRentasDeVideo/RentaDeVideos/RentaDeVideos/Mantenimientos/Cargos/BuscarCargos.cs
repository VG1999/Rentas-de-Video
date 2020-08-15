using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class BuscarCargos : Form
    {
        public BuscarCargos()
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

        //Se llama la conexion a la base de datos para poder realizar la consulta a Mysql
        Conexion cn = new Conexion();
        //variables que permitiran cargar los datos a la datagrid
        OdbcDataAdapter datos;
        DataTable dt;

        //Permite arrastrar el fomulario 
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

        //permite ingresar a al formulario para el ingreso del cargo
        private void btnCargos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cargo fic = new FormularioIngreso_Cargo();// se hace el llamado al formulario
            fic.Show();//se muestra el formulario
            this.Hide();// se oculta el formulario actual
        }

        //Permite regresar al formulario principal del mantenimiento cargos
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCargos ic = new IngresoCargos();// se hace el llamado al formulario
            ic.Show();// se muestra el fomulario
            this.Hide();// se oculta el formulario
        }

        //permite ingresar a al formulario para eliminar y actualizar datos 
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            ActualizarEliminarCargos aec = new ActualizarEliminarCargos();// se hace el llamado 
            aec.Show();// se muestra el form
            this.Hide();// se oculta la form actual
        }

        //no permite saber que ya estamos en la ventana buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//mensaje de alerta
        }

        //Nos regresa al menu principal del sistema en general
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// hace un llamado al formulario
            this.Dispose();// cierra la venta actual
        }

        //permite visualizar la venta actual
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //permite salir de la venta mostrando un mensaje de alerta al usuario
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//mensaje de alerta
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();//cierra el form
            }
        }

        //Nos da las posiciones hacia donde podemos arrastrar el form
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //carga los datos a la datagrid 
        void CargarDatos()
        {
            string cadena = "SELECT id_cargo, nombre, descripcion FROM cargo WHERE estado=1";//hacemos la sentencia hacia la VD

            datos = new OdbcDataAdapter(cadena, cn.conexion());// se realiza la conexion a la BD 
            dt = new DataTable();// se crea una tabla con DataTable para el data grid
            datos.Fill(dt);// llevamos los datos a la tabla creada anteriormente
            dgridDatos.DataSource = dt;// se asignan los datos  a la datagrid 
        }

        //verifica por segun deseemos buscar a si se mostrara en la datagrid
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // realiza la busqueda por id del cargo
                if (cmbColumna.Text == "ID") //Nos indica la Columna que deseemos buscar
                {
                    //obtienes los dato de la BD y los busca de acuerdo al txtbox
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE id_cargo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;// devuelve los datos a la datagrid
                }
                // realiza la busqueda por nombre 
                else if (cmbColumna.Text == "Nombre")//Nos indica la Columna que deseemos buscar
                {
                    //obtienes los dato de la BD y los busca de acuerdo al txtbox
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;// devuelve los datos a la datagrid
                }
                // realiza la busqueda segun la descripcion
                else if (cmbColumna.Text == "Descripcion")//Nos indica la Columna que deseemos buscar
                {
                    //obtienes los dato de la BD y los busca de acuerdo al txtbox
                    datos = new OdbcDataAdapter("SELECT id_cargo, nombre, descripcion FROM cargo WHERE descripcion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;// devuelve los datos a la datagrid
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
