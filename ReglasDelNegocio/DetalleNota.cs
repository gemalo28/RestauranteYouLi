using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class DetalleNota
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public DetalleNota(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarDetalle(int nIdNota, int nIdDetalle, int nIdProducto, double dPrecio)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarDetalle(int nIdNota, int nIdDetalle)
        {
            DataTable dtDetalle = new DataTable();


            return dtDetalle;
        }

        public Boolean BorrarDetalle(int nIdNota, int nIdDetalle)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarDetalle(int nIdNota, int nIdDetalle, int nIdProducto, double dPrecio)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
