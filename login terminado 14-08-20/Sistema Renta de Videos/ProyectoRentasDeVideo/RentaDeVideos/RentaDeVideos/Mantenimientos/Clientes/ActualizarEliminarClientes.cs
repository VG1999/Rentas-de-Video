using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Clientes
{
    public partial class ActualizarEliminarClientes : Form
    {
        int iUsuario = 1;

        public ActualizarEliminarClientes()
        {
            InitializeComponent();
            CargarDatos();
        }

        Conexion cn = new Conexion(); // hacemos la conexion a la base de datos 
        OdbcDataAdapter datos; // una operación de relleno para seleccionar registros del origen de datos
        DataTable dt; // nos permite representar una determinada tabla en memoria, de modo que podamos interactuar con ella.

        // propiedad para poder arrastat el formulario 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //metodo para el slide y sus medidas 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //permite minimizar la ventana
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // instruccion para minimizar 
        }

        // nos permite salir del formulari enviando un mensaje de alerta al usario 
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;// instruccion que valida la alerta 
            // mensaje de alerta al usario
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)// validamos la respuesta del usuario 
            {
                this.Dispose();// si la respuesta es si la venta se oculta del usuario 
            }
        }

        // nos muestra el formulario principal del mantenimiento  clientes 
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cliente fig = new FormularioIngreso_Cliente();// llamamos al formulario 
            fig.Show();// mostramos el formulario 
            this.Hide();// ocultamos el formulario anterior 
        }

        //nos muestra el formulario para el ingreso de datos del cliente
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoClientes ic = new IngresoClientes();// llamamos a dicho formulario 
            ic.Show();// mostramos el formulario 
            this.Hide();// ocultamos el formulario de la vista del usuario 
        }

        // da un aviso al usario de que ya se encuentra dentro del formulario por si vuelve a presionar la misma intruccion 
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            // mensaje de alerta al usuario 
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //da la vista para la busqueda de dats 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes bc = new BuscarClientes();// llamamos al formulario de buscar clientes 
            bc.Show();//mostramos el formulario 
            this.Hide();//ocultamos de la vista del usuario el formulario anterior 
        }

        //permite regresar al menu principal del sistema 
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();// llamos al formulario principal
            this.Dispose();// ocultamos el formulario anterior 
        }
        
        //posiciones a donde podemos mover el formulario 
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //cargamos los datos a la BD 
        void CargarDatos()
        {
            try
            {
                //Realizamos la consulta hacia la BD de la tabla clientes 
                string cadena = "SELECT id_cliente, id_membresia, dpi, nit, nombre, apellido, telefono, correo FROM cliente WHERE estado=1";

                datos = new OdbcDataAdapter(cadena, cn.conexion());// hacemoa la conexion a la BD 
                dt = new DataTable();// creamos la tabla para manejar todos los datos 
                datos.Fill(dt);// llenamos dicha tabla con los datos obtenidos 
                dgridVista.DataSource = dt;// asignamos dicho datos a la datagrid 
            }
            catch (Exception ex)
            {
                //mensaje de error alertando si hubiese ocurrido un problema en el proceso
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        string sCadena;
        int iID;
        int iIDEliminar;

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
                if (sCadena == string.Empty)
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());
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
                        string cadena = "UPDATE cliente SET id_membresia='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_membresia"].Value.ToString()) +
                            "',dpi='" + dgridVista.Rows[e.RowIndex].Cells["dpi"].Value.ToString() + "', nit='" + dgridVista.Rows[e.RowIndex].Cells["nit"].Value.ToString() +
                            "', nombre='" + dgridVista.Rows[e.RowIndex].Cells["nombre"].Value.ToString() + "', apellido='" + dgridVista.Rows[e.RowIndex].Cells["apellido"].Value.ToString() +
                            "', telefono='" + int.Parse(dgridVista.Rows[e.RowIndex].Cells["telefono"].Value.ToString()) + "', correo='" + dgridVista.Rows[e.RowIndex].Cells["correo"].Value.ToString() + "' WHERE id_cliente='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();

                        OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                        llenarBitacora.CommandType = CommandType.StoredProcedure;
                        llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                        llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CLIENTES";
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
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

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

                string cadena = "UPDATE cliente SET estado=0  WHERE id_cliente='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CLIENTES";
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
    }
}
