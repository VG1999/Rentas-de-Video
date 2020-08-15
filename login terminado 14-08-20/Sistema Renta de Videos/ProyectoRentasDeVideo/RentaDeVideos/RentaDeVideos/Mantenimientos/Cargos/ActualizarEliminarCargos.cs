using RentaDeVideos.Clases;
using System;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RentaDeVideos.Mantenimientos.Cargos
{
    public partial class ActualizarEliminarCargos : Form
    {
        int iUsuario = 1;

        public ActualizarEliminarCargos()
        {
            InitializeComponent();
            CargarDatos();

        }

        //Se llama a la conexion de la BD
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        //Permite arrastar el fomulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Medidas que va ocupar en este caso el slide 
        private void picBotonMenuSlide_Click(object sender, EventArgs e)
        {
            if (pnlSlideMenu.Width == 188)
            {
                pnlSlideMenu.Width = 40;
            }
            else
                pnlSlideMenu.Width = 188;
        }

        //permite minimizar la venta actual
        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Permite salir pero se envia un mensaje para validar si la accion es correcta
        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmemte desea salir?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//mensaje de alerta
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose(); // se cierra la venta
            }
        }

        //Nos permite ingresar a la venta ingreso del cargo
        private void btnCargos_Click(object sender, EventArgs e)
        {
            FormularioIngreso_Cargo fic = new FormularioIngreso_Cargo(); // hace una llamada al formulario
            fic.Show();// muestra el formulario
            this.Hide();//oculta el fomulario
        }

        //Nos permite ingresar a la venta principal del manteminimiento cargo
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCargos ic = new IngresoCargos();//hace una llamada al formulario
            ic.Show();//muestra el formulario
            this.Hide();//oculta el formulario
        }

        //Le notifica al usuario que ya esta dentro de la ventana que selecciono anteriormente
        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//mensaje de alerta
        }

        //permite ingresar a la venta para de busqueda del cargo 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCargos bc = new BuscarCargos();//hace un llamado al formulario
            bc.Show();//muestra el formulario
            this.Hide();//oculta la venta actual
        }

        //permite regresa a la venta del menu principal
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            formularioFondoPrincipal fim = new formularioFondoPrincipal();//hace un llamado al formulario
            this.Dispose();//oculta la ventana anterior
        }

        //Da las posiciones hacia donde podemos arrastrar el formulario actual
        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //carga todos los datos de la tabla cargo a la datagrid
        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT id_cargo, nombre, descripcion FROM cargo WHERE estado=1";//realiza la consulta hacia la bd
                datos = new OdbcDataAdapter(cadena, cn.conexion());// se realiza la conexion a la BD 
                dt = new DataTable(); // se genera una variable tipo DataTable o mas bien se crea un tabla para llenar el data grid
                datos.Fill(dt);// le damos las indicaciones para llenar el data grid
                dgridVista.DataSource = dt;//por ultimo le asignamos dichos datos a la data grid
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);//mensaje de error si ocurre algo en el proceso
            }
        }

        string sCadena;
        int iID;
        int iIDEliminar;

        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cargo"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["id_cargo"].Value.ToString();
                if (sCadena == string.Empty)
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["id_cargo"].Value.ToString());
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
                        string cadena = "UPDATE cargo SET nombre='" + dgridVista.Rows[e.RowIndex].Cells["nombre"].Value.ToString() + "', descripcion='" + dgridVista.Rows[e.RowIndex].Cells["descripcion"].Value.ToString() + "' WHERE id_cargo='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();

                        OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                        llenarBitacora.CommandType = CommandType.StoredProcedure;
                        llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                        llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CARGOS";
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

                string cadena = "UPDATE cargo SET estado=0  WHERE id_cargo='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();

                OdbcCommand llenarBitacora = new OdbcCommand("{call insertar_Bitacora(?,?,?,?,?)}", cn.conexion());
                llenarBitacora.CommandType = CommandType.StoredProcedure;
                llenarBitacora.Parameters.Add("id_cliente", OdbcType.Text).Value = iUsuario;
                llenarBitacora.Parameters.Add("tabla", OdbcType.Text).Value = "CARGOS";
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
