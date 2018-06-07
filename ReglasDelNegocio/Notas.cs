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
        public string sLastError = "";

        public Notas(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public Boolean AgregarNota(string sPropietario, string sDescripcion, double dTotal, int nIdOrden, int nIdFactura)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into notas(propietario, descripcion, total, id_ordenm id_factura) " +
                                 "values (" + sPropietario + ", " + sDescripcion + "," + dTotal + ", " + nIdOrden + ", " + nIdFactura + ")";
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

        public Boolean AgregarNota(string sPropietario, string sDescripcion, double dTotal, int nIdOrden)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into notas(propietario, descripcion, total, id_orden) " +
                                 "values (" + sPropietario + ", " + sDescripcion + "," + dTotal + ", " + nIdOrden + ")";
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

        public DataTable ConsultarNota(int nIdNota)
        {
            DataTable dtNotas = new DataTable();

            try
            {
                string sSQlqry = "";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtNotas);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtNotas;
        }

        public DataTable ConsultarNota()
        {
            DataTable dtNotas = new DataTable();

            try
            {
                string sSQlqry = "select id_nota as ID, propietario as Propietario, date(fecha) as Fecha, descripcion as Descripcion, total as Total " +
                                 "from notas " +
                                 "where date(fecha) = date(now())";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtNotas);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtNotas;
        }

        public DataTable ConsultarNota(DateTime dtFechaIn, DateTime dtFechaFin)
        {
            DataTable dtNotas = new DataTable();

            try
            {
                string sSQlqry = "select id_nota as ID, propietario as Propietario, date(fecha) as Fecha, descripcion as Descripcion, total as Total " +
                                 "from notas " +
                                 "where date(fecha) between '" + dtFechaIn.ToString("yyyy-MM-dd") + "' and '" + dtFechaFin.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtNotas);
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return dtNotas;
        }

        public Boolean BorrarNota(int nIdNota)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from notas where id_nota = " + nIdNota;
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

        public Boolean ActualizarNota(int nIdNota, string sDescripcion, double dTotal, int nIdOrden, int nIdFactura)
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
