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

        public Boolean AgregarDetalle(string sPropietario, string sDescripcion, int nIdOrden, double dTotal, DataTable dtProductos)
        {
            bool bAllOk = false;
            MySqlTransaction transaction = null;
            int nIdNota = 0;
            try
            {
                transaction = xConnection.BeginTransaction();
                Notas xNotas = new Notas(xConnection);

                if(xNotas.AgregarNota(sPropietario, sDescripcion, dTotal, nIdOrden, ref nIdNota, ref transaction))
                {
                   foreach(DataRow row in dtProductos.Rows)
                    {
                        string sSQlqry = "Insert into detalle_nota(id_nota, id_producto) " +
                                         "values(" + nIdNota + "," + row[2] + "); " +
                                         "Update detalle_orden set flag_pagado = 1 where id_detalleOrden = " + row[0] + ";";
                        MySqlCommand command = new MySqlCommand(sSQlqry, xConnection, transaction);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    transaction.Commit();
                    bAllOk = true;
                }
                else
                {
                    throw new Exception(xNotas.sLastError);
                }
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
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

        public int getLastNota()
        {
            int nIdNota = 0;

            try
            {
                string sSQlqry = "select id_nota " +
                                 "from notas " +
                                 "order by id_nota desc limit 1";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    nIdNota = Convert.ToInt32(reader[0]);
                }
                reader.Dispose();
                command.Dispose();
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return nIdNota;
        }
    }
}
