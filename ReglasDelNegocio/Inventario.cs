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
        public string sLastError = "";

        public Inventario(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarInventario(string sNombre, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into inventario(nombre, cantidad) " +
                                 "values(" + sNombre + "," + nCantidad + ")";
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

        public DataTable ConsultarInventario(int nIdIngrediente)
        {
            DataTable dtInventario = new DataTable();

            try
            {
                string sSQlqry = "";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtInventario);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtInventario;
        }

        public DataTable ConsultarInventario()
        {
            DataTable dtInventario = new DataTable();

            try
            {
                string sSQlqry = "";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtInventario);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }


            return dtInventario;
        }

        public Boolean BorrarInventario(int nIdIngrediente)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from inventario where id_ingrediente =" + nIdIngrediente;
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

        public Boolean ActualizarInventario(int nIdIngrediente, string sNombre, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update inventario set nombre = " + sNombre + ", cantidad = " + nCantidad + " where id_ingrediente = " + nIdIngrediente;
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
    }
}
