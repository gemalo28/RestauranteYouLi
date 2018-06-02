using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace ReglasDelNegocio
{
    public class DetalleOrden
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";
        public DetalleOrden(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarDetalle(int nIdOrden, int nIdProducto)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "Insert into detalle_orden(id_orden, id_producto) " +
                                 "values(" + nIdOrden + "," + nIdProducto + ")";
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

        public DataTable ConsultarDetalle(int nIdOrden)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select * from detalle_orden where id_orden = " + nIdOrden;
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
                string sSQlqry = "delete from detalle_orden " +
                                 "where id_detalleOrden = " + nIdDetalle;
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

        //public Boolean ActualizarDetalle(int nIdOrden, int nIdDetalle, int nIdProducto)
        //{
        //    bool bAllOk = false;

        //    try
        //    {
        //        string sSQlqry = "update detalle_orden set ";
        //        MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
        //        command.ExecuteNonQuery();
        //        command.Dispose();
        //        bAllOk = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        sLastError = "Error >>> " + ex.ToString();
        //    }

        //    return bAllOk;
        //}

    }
}
