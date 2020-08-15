using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.CategoriaVideos
{
    public partial class ActualizarEliminarCatVideos : Form
    {
        int iUsuario = 1;

        public ActualizarEliminarCatVideos()
        {
            InitializeComponent();
            CargarDatos();

        }

        // se llama a la clase donde se encuentra la conexion de la bd 
        Conexion cn = new Conexion();
        OdbcDataAdapter datos; //  una operación de relleno para seleccionar registros del origen de datos y colocarlos en DataSet.
        DataTable dt; // nos permite representar una determinada tabla en memoria, de modo que podamos interactuar con ella.

        // nos permirte arrastar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //medidas que va a tomar el slide en el formulario 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //nos permite minimizar la ventana actual
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;// instruccion para minimizar 
        }

        // permite salir del formulario 
        private void picSalir_Click(object sender, EventArgs e)
        {
            // se le hace el aviso al usario si desea salir o no 
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        // nos  permite entrar al formulario de ingreso de las categorias de video
        private void btnCatVideos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_CatVideo form = new FormularioIngreso_CatVideo();// se hace le llamdo al formulario
            form.Show();// se muestra el formulario
            this.Hide();// se oculta el formulario
        }

        // nos permite ingresar al ingreso de los cargos 
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCatVideos icv = new IngresoCatVideos();// se hace el llamado al formulario
            icv.Show();// se muestra el formulario
            this.Hide();// se oculta el formulario 
        }

        // Nos indica que ya estamos dentro del formulario seleccionado
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//mensaje de alerta 
        }

        // nos ingresa a la venta de busqueda 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCatVideos bcv = new BuscarCatVideos();// hacemos el llamado al formulario
            bcv.Show();//nos muestra el formulario
            this.Hide();// nos oculta el formulario anterio
        }

        //nos devuelve al formulario principal del sistem
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// hace el llamado al formulario
            this.Dispose();// cierra el formulario anterior
        }

        //nos da las medidas de hacia donde podemos mover el formulario
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // cargamos todos los datos a la base 
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_categoria, nombre FROM categoria_video WHERE estado=1";// hacemos la consulta de mysql a la bd

                datos = new OdbcDataAdapter(cadena, cn.conexion());// relizamos la conexion a la bd
                dt = new DataTable();// creamos la tabla que nos permiira llenar el datagrid
                datos.Fill(dt);// llenamos el dataTable
                dgridVista.DataSource = dt; // por ultimos asignamos los datos al datagrid 
            }
            catch (Exception ex)
            {
                //enviamos una alerta si en caso hubiese ocurrido un error en el proceso 
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        string sCadena;
        int iID;
        int iIDEliminar;

        private void cmsDelete_Click(object sender, EventArgs e)
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

                string cadena = "UPDATE categoria_video SET estado=0  WHERE id_categoria='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CATEGORIA_VIDEOS";
                llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "ELIMINAR";
                llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                llenarBitacora.ExecuteNonQuery();
                llenarBitacora.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["id_categoria"].Value.ToString();
                if (sCadena == string.Empty)
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_categoria"].Value.ToString());
                }
                if (iID != 0)
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

                    if (dgridVista.CurrentRow != null)
                    {
                        string cadena = "UPDATE categoria_video SET nombre='" + dgridVista.Rows[e.RowIndex].Cells["nombre"].Value.ToString() + "' WHERE id_categoria='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();

                        OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                        llenarBitacora.CommandType = CommandType.StoredProcedure;
                        llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                        llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CATEGORIA_VIDEOS";
                        llenarBitacora.Parameters.Add("actividad", OdbcType.Text).Value = "ACTUALIZAR";
                        llenarBitacora.Parameters.Add("fecha", OdbcType.DateTime).Value = DateTime.Now;
                        llenarBitacora.Parameters.Add("host_ip", OdbcType.Text).Value = sLocalIP;
                        llenarBitacora.ExecuteNonQuery();
                        llenarBitacora.Connection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_categoria"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }
    }
}
