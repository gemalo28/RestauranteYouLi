using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Bitacora
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";
        public Bitacora(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public bool AgregarBitacora(int nIdReceta, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                for(int i = 0; i < nCantidad; i++)
                {
                    string sSQlqry = "CALL ActualizarInventario(" + nIdReceta + ")";

                    MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }                

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }
    }
}
