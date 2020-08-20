using RentaDeVideos.Mantenimientos.Login;
using RentaDeVideos.Procesos.Compras;
using RentaDeVideos.Procesos.ControlDevoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
