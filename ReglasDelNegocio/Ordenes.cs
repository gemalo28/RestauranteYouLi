using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Ordenes
    {
        public MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";

        public Ordenes(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarOrden(string sPropietario, string sDescripcion, double dTotal)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "Insert into detalle_nota(propiertario, descripcion, total) " +
                                 "values(" + sPropietario + "," + sDescripcion + "," + dTotal + ")";
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

        public DataTable ConsultarOrdenes(string sNomPropietario ="")
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select id_orden,propietario as PROPIETARIO,FECHA,DESCRIPCION AS DESCRIPCION,TOTAL AS TOTAL,FLAG_PAGADO from ordenes where flag_pagado = 0 and propietario like '%"+sNomPropietario+"%'";
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

        public Boolean BorrarOrden(int nIdOrden)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from ordenes " +
                                 "where id_orden = " + nIdOrden;
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

        public Boolean ActualizarOrden(int nIdOrden, string sPropietario, string sDescripcion, double dTotal, int nFlagPagado)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update ordenes set propietario = " + sPropietario + ",descripcion = " + sDescripcion + ",total = " + dTotal + ", flag_pagado = " + nFlagPagado +
                                 "where id_orden = " + nIdOrden;
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
