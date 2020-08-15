using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaDeVideos.Clases
{
    // la Clase ContorlUsuario me retornara cada uno de los datos obtenidos de la base de datos se creo una variable por cada campo de la tabla contro_usuario
    class ControlUsuario
    {
        int  estado, id_usario;
        string usuario, password, rol;

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int Id_usario
        {
            get
            {
                return id_usario;
            }

            set
            {
                id_usario = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
    }
}