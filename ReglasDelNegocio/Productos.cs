using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Productos
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";

        public Productos(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarProducto(string sNombre, string sDescripcion, double dPrecio)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into productos(nombre, descripcion, precio) " +
                                 "values(" + sNombre + "," + sDescripcion + "," + dPrecio + ")";
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

        public DataTable ConsultarProductos(int nIdProducto)
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select id_producto, nombre, descripcion, precio from productos " +
                                 "where id_producto = " + nIdProducto;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtProductos;
        }

        public DataTable ConsultarProductos()
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select nombre, descripcion, precio from productos ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtProductos;
        }

        public Boolean BorrarProducto(int nIdProducto)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from productos where id_producto = " + nIdProducto;
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

        public Boolean ActualizarProducto(int nIdProducto, string sNombre, string sDescripcion, double dPrecio)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update productos set nombre = " + sNombre + ", descripcion = " + sDescripcion + ", precio = " + dPrecio +
                                 "where id_producto = " + nIdProducto;
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
