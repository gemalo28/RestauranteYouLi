using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReglasDelNegocio
{
    public class DetalleReceta
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public DetalleReceta(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarDetalle(int nIdReceta, int nIdIngrediente, int nCantidad)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarDetalle(int nIdReceta)
        {
            DataTable dtDetalle = new DataTable();


            return dtDetalle;
        }

        public Boolean BorrarDetalle(int nIdReceta, int nIdIngrediente)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarDetalle(int nIdReceta, int nIdIngrediente, int nCantidad)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
