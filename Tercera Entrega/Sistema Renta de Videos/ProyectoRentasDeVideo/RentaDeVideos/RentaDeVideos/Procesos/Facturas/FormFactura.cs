using RentaDeVideos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Procesos.Facturas
{
    public partial class FormFactura : Form
    {
        



        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;

        public FormFactura()
        {
            InitializeComponent();
            try
            {
                //CargarDatos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void CargarDatos()
        {
            string cadena = "SELECT id_video, titulo, precio FROM video WHERE estado=1";

            datos = new OdbcDataAdapter(cadena, cn.conexion());
            dt = new DataTable();

            datos.Fill(dt);
            dtgDetalle.DataSource = dt;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                OdbcCommand datos;
                String consultaSQL;
                consultaSQL = "SELECT nombre, apellido, nit FROM cliente WHERE nombre='" + txtBuscar.Text + "' AND estado=1";
                datos = new OdbcCommand(consultaSQL, cn.conexion());
                OdbcDataReader resultadoSQL = datos.ExecuteReader(CommandBehavior.CloseConnection);

                while (resultadoSQL.Read())
                {
                    txtNombre.Text = txtNombre.Text + resultadoSQL.GetString(0);
                    txtApellido.Text = txtApellido.Text + resultadoSQL.GetString(1);
                    txtNit.Text = txtNit.Text + resultadoSQL.GetString(2);
                }

                if (cboBuscar.Text == "NOMBRE")
                {


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ejecutar SQL" + System.Environment.NewLine + System.Environment.NewLine + ex.GetType().ToString() + System.Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void dtgDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if(dtgDetalle.Rows[e.RowIndex].Cells["cmbVideo"].Value!=null)
                {
                    if (dtgDetalle.Rows[e.RowIndex].Cells["txtCantidad"].Value != null)
                    {
                        int idVideo;
                        idVideo = int.Parse(dtgDetalle.Rows[e.RowIndex].Cells["cmbVideo"].Value.ToString());
                        string sSQL = "SELECT precio FROM video WHERE id_video =" + idVideo;
                        OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                        OdbcDataReader registro = comando.ExecuteReader();

                        while (registro.Read())
                        {
                            dtgDetalle.Rows[e.RowIndex].Cells["txtPrecio"].Value = registro["precio"];
                        }


                        Double dPrecio, dSubTotal;
                        int iCantidad;
                        dPrecio = double.Parse(dtgDetalle.Rows[e.RowIndex].Cells["txtPrecio"].Value.ToString());
                        iCantidad = int.Parse(dtgDetalle.Rows[e.RowIndex].Cells["txtCantidad"].Value.ToString());
                        dSubTotal = dPrecio * iCantidad;
                        dtgDetalle.Rows[e.RowIndex].Cells["txtTot"].Value = dSubTotal;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar factura de detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // int valor1 = 1;
            // int rowEscribir = dtgDetalle.Rows.Count + valor1;
            //dtgDetalle.Rows.Add(1);
            //dtgDetalle.Rows[1].Cells[1].Value = Clm1;
            //Clm1.tex
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos = new OdbcDataAdapter("SELECT  titulo, precio FROM video WHERE titulo='" + txtBuscar_Deta.Text + "' AND estado=1", cn.conexion());
            dt = new DataTable();
            datos.Fill(dt);
            dtgDetalle.DataSource = dt;
        
        }
    }
}
