using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Productos
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public Productos(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarProducto(int nIdProducto, string sNombre, string sDescripcion, double dPrecio)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarProductos(int nIdProducto)
        {
            DataTable dtProductos = new DataTable();


            return dtProductos;
        }

        public Boolean BorrarProducto(int nIdProducto)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarProducto(int nIdProducto, string sNombre, string sDescripcion, double dPrecio)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
