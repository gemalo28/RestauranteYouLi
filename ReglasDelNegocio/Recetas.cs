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
        public string sLastError = "";

        public Recetas(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarReceta(string sNombre)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into recetas(nombre)" +
                                 "values (" + sNombre + ")";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public DataTable ConsultarReceta(int nIdReceta)
        {
            DataTable dtReceta = new DataTable();

            try
            {
                string sSQlqry = "select ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtReceta);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }


            return dtReceta;
        }

        public Boolean BorrarReceta(int nIdReceta)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from recetas where id_receta = " + nIdReceta;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public Boolean ActualizarReceta(int nIdReceta, string sNombre)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update receta set nombre = " + sNombre +
                                 " where id_receta = " + nIdReceta;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch(Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }


    }
}
