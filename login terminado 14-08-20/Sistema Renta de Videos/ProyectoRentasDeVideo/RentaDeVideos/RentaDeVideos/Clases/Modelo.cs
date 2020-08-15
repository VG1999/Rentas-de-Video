using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Clases
{
    //En la clase modelo esta encargada de obtener la infomacion de la tabla control_usarios en la base de datos
    class Modelo 
    {

        Conexion cn = new Conexion();
        public ControlUsuario porUsuario(string sUsuario)
        {
            // se realiza la consulta a Mysql para obtener todos los datos
            string sql = "SELECT id_usuario,usuario, contrasenia ,rol,estado FROM control_usuario where  usuario = '" + sUsuario + "'";
            OdbcCommand comando = new OdbcCommand(sql, cn.conexion()); // se realiza la conexion a la bd
            comando.Parameters.AddWithValue("@usuario", sUsuario); // se envia como parametro el usuario recibo
            OdbcDataReader reader = comando.ExecuteReader(); // reader para recorrer todoa la tabla

            ControlUsuario usr = null; // se manda a llamar la clase ControlUsuario para generar todos los get y set 

            while (reader.Read())
            {
                usr = new ControlUsuario();

                usr.Id_usario = int.Parse(reader["id_usuario"].ToString()); // en este fragmento de codigo me permite almacenar todos los campos mientras que estan siendo leidos
                usr.Password = reader["contrasenia"].ToString(); // estos datos se retornan a la variables de la clase ControlUsuario que posee metodos get y set
                usr.Usuario = reader["usuario"].ToString();
                usr.Rol = reader["rol"].ToString();
                usr.Estado = int.Parse(reader["estado"].ToString());
               
            }
            return usr;
        }
    }
}
