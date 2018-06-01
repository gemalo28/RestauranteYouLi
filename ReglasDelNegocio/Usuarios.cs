using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReglasDelNegocio
{
    public class Usuarios
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public Usuarios(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarUsuario(int nIdUsuario, string sNombre, string sContrasena)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarUsuarios(int nIdUsuario)
        {
            DataTable dtProductos = new DataTable();


            return dtProductos;
        }

        public Boolean BorrarUsuario(int nIdUsuario)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarUsuario(int nIdUsuario, string sNombre, string sContrasena)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
