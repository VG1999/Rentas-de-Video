using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaDeVideos.Clases
{
    // En la clase control se manejan se devuelven los datos  a formLogin

    class Control {

        // ctrl resive los parametros de la clase modelo para verificar el usario y la password

        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo(); // llamado a la clase modelo que contiene la consulta para obtener los datos de la tabla contro_usuario
            string respuesta = "";// guarda el mensaje dependiendo del caso que genere las validaciones en los if
            ControlUsuario datosUsuario = null; // manda a llamar los procedimientos get y set donde se creo una variable por cada campo de la tabla

            if ((usuario == "USUARIO") || (password == "CONTRASEÑA")) // aqui se valida el usuario y la contraseña
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);  // aqui se envian obtiene y ser retornan todos los datos

                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";  // validacion para verificar si el usuario se encuentra dentro de la base de datos
                }
                else
                {
                   
                    if (datosUsuario.Password !=password)
                    {
                        respuesta = "El usuario y/o contraseña no coinciden"; // validacion para verificar si el password es correcto 
                    }
                    else
                    {
                        Users.id_usario = datosUsuario.Id_usario; // Se guardan los datos a la clase publica Users y asi capturar los datos
                        Users.usuario = datosUsuario.Usuario;    // para poder generar datos cuando se verifican los roles en el FormularioFondoPrincipal
                        Users.rol = datosUsuario.Rol;
                        Users.estado = datosUsuario.Estado;
                        Users.password = datosUsuario.Password;
                    }
                }
            }
            return respuesta;
        }


     
    }

    
}
