using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Generales
    {
        public string sLastError = "";
        public Boolean ConectarDB(ref MySqlConnection xConnection)
        {
            bool bAllOk = false;

            try
            {
                xConnection.Open();
                bAllOk = true;
            }
            catch(Exception ex)
            {
                sLastError = "error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public Boolean DesconectarDB( ref MySqlConnection xConnection)
        {
            bool bAllOk = false;

            try
            {
                xConnection.Close();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "error >>> " + ex.ToString();
            }

            return bAllOk;
        }
    }
}
