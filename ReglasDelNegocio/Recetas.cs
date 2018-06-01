using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReglasDelNegocio
{
    public class Recetas
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public Recetas(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarReceta(string sNombre)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarReceta(int nIdReceta)
        {
            DataTable dtReceta = new DataTable();


            return dtReceta;
        }

        public Boolean BorrarReceta(int nIdReceta)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarReceta(int nIdReceta, string sNombre)
        {
            bool bAllOk = false;

            return bAllOk;
        }


    }
}
