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

        public Boolean AgregarDetalle(string sNombre, DataTable dtIngredientes)
        {
            bool bAllOk = false;
            MySqlTransaction transaction = null;
            int nIdReceta = 0;
            try
            {
                transaction = xConnection.BeginTransaction();
                Recetas xReceta = new Recetas(xConnection);

                if (xReceta.AgregarReceta(sNombre.ToUpper(), ref nIdReceta, ref transaction))
                {
                    foreach (DataRow row in dtIngredientes.Rows)
                    {
                        string sSQlqry = "insert into detalle_receta(id_receta, id_ingrediente, cantidad) " +
                                     "values (" + nIdReceta + "," + row[1].ToString() + ", " + row[3].ToString() + ")";
                        MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    transaction.Commit();
                    bAllOk = true;
                }
                else
                {
                    transaction.Rollback();
                    sLastError = xReceta.sLastError;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public Boolean AgregarDetalle(int nIdReceta, int nIdIngrediente, int nCantidad, ref MySqlTransaction transaction)
        {
            bool bAllOk = false;
            try
            {
                string sSQlqry = "insert into detalle_receta(id_receta, id_ingrediente, cantidad) " +
                                 "values (" + nIdReceta + "," + nIdIngrediente + ", " + nCantidad + ")";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
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
                string sSQlqry = "select det.id_ingrediente, ing.nombre, det.cantidad "+
                                 "from detalle_receta det " +
                                 "join inventario ing on ing.id_ingrediente = det.id_ingrediente " +
                                 "where id_receta = " + nIdReceta;
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

        public Boolean BorrarDetalle(int nIdReceta, int nIdIngrediente,ref MySqlTransaction transaction)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from detalle_receta where id_receta =" + nIdReceta + " and id_ingrediente = " + nIdIngrediente;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
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

        public Boolean BorrarDetalle(int nIdReceta, ref MySqlTransaction transaction)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "delete from detalle_receta where id_receta =" + nIdReceta;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
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

        public Boolean ActualizarDetalle(string sNombre, int nIdReceta, DataTable dtIngredientes)
        {
            bool bAllOk = false;
            MySqlTransaction transaction;
            transaction = xConnection.BeginTransaction();
            Recetas xReceta = new Recetas(xConnection);

            try
            {         
                if(xReceta.ActualizarReceta(nIdReceta, sNombre, ref transaction))
                {
                    foreach(DataRow row in dtIngredientes.Rows)
                    {
                        if(Convert.ToInt32(row[0]) == 1)
                        {
                            string sSQlqry = "update detalle_receta set cantidad = " + row[3].ToString() + " where id_receta = " + nIdReceta + " and id_ingrediente =" + row[1].ToString();
                            MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                            command.ExecuteNonQuery();
                            command.Dispose();
                        }
                        else if(Convert.ToInt32(row[0]) == 0)
                        {
                            if(!AgregarDetalle(nIdReceta, Convert.ToInt32(row[1]), Convert.ToInt32(row[3].ToString()), ref transaction))
                            {
                                throw new Exception(sLastError);
                            }
                        }              
                        else if(Convert.ToInt32(row[0]) == -1)
                        {
                            if(!BorrarDetalle(nIdReceta, Convert.ToInt32(row[1]), ref transaction))
                            {
                                throw new Exception(sLastError);
                            }
                        }
                    }

                    transaction.Commit();
                    bAllOk = true;
                }
                else
                {                   
                    throw new Exception(xReceta.sLastError);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }
    }
}
