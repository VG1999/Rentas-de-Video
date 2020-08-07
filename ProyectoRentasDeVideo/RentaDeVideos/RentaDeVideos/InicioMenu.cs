using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos
{
    public partial class FormularioInicioMenu : Form
    {
        public FormularioInicioMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mantenimientos.Clientes.FormularioIngreso_Cliente form = new Mantenimientos.Clientes.FormularioIngreso_Cliente();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mantenimientos.Proveedores.FormularioIngreso_Proveedor prov = new Mantenimientos.Proveedores.FormularioIngreso_Proveedor();
            prov.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mantenimientos.Usuarios.FormularioIngreso_Usuario user = new Mantenimientos.Usuarios.FormularioIngreso_Usuario();
            user.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mantenimientos.Cargos.FormularioIngreso_Cargo cargo = new Mantenimientos.Cargos.FormularioIngreso_Cargo();
            cargo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mantenimientos.Empleados.FormularioIngreso_Empleado emp = new Mantenimientos.Empleados.FormularioIngreso_Empleado();
            emp.Show();
            this.Hide();
        }
    }
}
