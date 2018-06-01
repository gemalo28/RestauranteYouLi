using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Inventario
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public Inventario(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarInventario(int nIdIngrediente, string sNombre, int nCantidad)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarInventario(int nIdIngrediente)
        {
            DataTable dtInventario = new DataTable();


            return dtInventario;
        }

        public DataTable ConsultarInventario()
        {
            DataTable dtInventario = new DataTable();


            return dtInventario;
        }

        public Boolean BorrarInventario(int nIdIngrediente)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarInventario(int nIdIngrediente, string sNombre, int nCantidad)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
