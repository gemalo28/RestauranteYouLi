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
        public string sLastError = "";

        public DetalleNota(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarDetalle(int nIdNota, int nIdProducto)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "Insert into detalle_nota(id_nota, id_producto) " +
                                 "values(" + nIdNota + "," + nIdProducto + ")";
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

        public DataTable ConsultarDetalle(int nIdNota)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select pr.nombre as Nombre, pr.descripcion as Descripcion, pr.precio as Precio " +
                                 "from detalle_nota dn " +
                                 "join productos pr on pr.id_producto = dn.id_producto " +
                                 "where dn.id_nota = " + nIdNota;
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

        public Boolean BorrarDetalle(int nIdDetalle)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from detalle_nota " +
                                 "where id_detalleNota = " + nIdDetalle;
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

        public Boolean ActualizarDetalle(int nIdNota, int nIdDetalle, int nIdProducto, double dPrecio)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "";
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
