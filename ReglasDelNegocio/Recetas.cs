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

        public Boolean AgregarReceta(string sNombre, ref int nIdReceta, ref MySqlTransaction transaction)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into recetas(nombre)" +
                                 "values ('" + sNombre + "'); " +
                                 "select LAST_INSERT_ID();";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
                MySqlDataReader reader;
                reader = command.ExecuteReader();                

                while(reader.Read())
                {
                    nIdReceta = Convert.ToInt32(reader[0]);
                }

                reader.Dispose();
                command.Dispose();

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public DataTable ConsultarReceta()
        {
            DataTable dtReceta = new DataTable();

            try
            {
                string sSQlqry = "select id_receta, nombre as 'Nombre' from recetas;";
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

        public DataTable ConsultarReceta(int nIdReceta)
        {
            DataTable dtReceta = new DataTable();

            try
            {
                string sSQlqry = "select id_receta, nombre as 'Nombre' from recetas where id_receta = " + nIdReceta;
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

        public DataTable ConsultarReceta(string sNombre)
        {
            DataTable dtReceta = new DataTable();

            try
            {
                string sSQlqry = "select id_receta, nombre as 'Nombre' from recetas where nombre like '%" + sNombre +"%'";
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
            MySqlTransaction transaction;
            transaction = xConnection.BeginTransaction();
            DetalleReceta xDetalleRec = new DetalleReceta(xConnection);
            try
            {
                if(xDetalleRec.BorrarDetalle(nIdReceta, ref transaction))
                {
                    string sSQlqry = "delete from recetas where id_receta = " + nIdReceta;
                    MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    transaction.Commit();
                    bAllOk = true;
                }
                else
                {
                    throw new Exception(xDetalleRec.sLastError);
                }                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public Boolean ActualizarReceta(int nIdReceta, string sNombre, ref MySqlTransaction transaction)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update recetas set nombre = '" + sNombre +
                                 "' where id_receta = " + nIdReceta;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
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

        public int GetLastID(ref MySqlTransaction transaction)
        {
            int nIdReceta = 0;

            try
            {
                string sSqlQry = "select id_receta from recetas order by id_receta desc limit 1";
                MySqlCommand command = new MySqlCommand(sSqlQry, xConnection, transaction);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    nIdReceta = Convert.ToInt32(reader[0]);
                }
                reader.Dispose();
                command.Dispose();
            }
            catch(MySqlException ex)
            {
                sLastError = ex.ToString();
            }

            return nIdReceta = 0;
        }
    }
}
