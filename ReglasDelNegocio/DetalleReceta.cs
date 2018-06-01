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
        public string sLastError = "";

        public DetalleReceta(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarDetalle(int nIdReceta, int nIdIngrediente, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into detalle_receta(id_receta, id_ingrediente, cantidad) " +
                                 "values (" + nIdReceta + "," + nIdIngrediente + ", " + nCantidad + ")";
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

        public DataTable ConsultarDetalle(int nIdReceta)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }


            return dtDetalle;
        }

        public Boolean BorrarDetalle(int nIdReceta, int nIdIngrediente)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from detalle_receta where id_receta =" + nIdReceta + " and id_ingrediente = " + nIdIngrediente;
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

        public Boolean ActualizarDetalle(int nIdReceta, int nIdIngrediente, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update detalle_receta set cantidad = " + nCantidad + " where id_receta = " + nIdReceta + " and id_ingrediente =" + nIdIngrediente;
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
