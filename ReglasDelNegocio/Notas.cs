using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Notas
    {
        private MySqlConnection xConnection = new MySqlConnection();

        public Notas(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarNota(int nIdNota, int nMesa, DateTime Fecha, double dTotal, int nIdFactura)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public DataTable ConsultarNota(int nIdNota)
        {
            DataTable dtNotas = new DataTable();


            return dtNotas;
        }

        public DataTable ConsultarNota(DateTime Fecha)
        {
            DataTable dtNotas = new DataTable();


            return dtNotas;
        }

        public Boolean BorrarNota(int nIdNota)
        {
            bool bAllOk = false;

            return bAllOk;
        }

        public Boolean ActualizarNota(int nIdNota, int nMesa, DateTime Fecha, double dTotal, int nIdFactura)
        {
            bool bAllOk = false;

            return bAllOk;
        }
    }
}
