using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ReglasDelNegocio
{
    public class Bitacora
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";
        public Bitacora(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public bool AgregarBitacora(int nIdReceta, int nCantidad)
        {
            bool bAllOk = false;

            try
            {
                for(int i = 0; i < nCantidad; i++)
                {
                    string sSQlqry = "CALL ActualizarInventario(" + nIdReceta + ")";

                    MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }                

                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }

            return bAllOk;
        }

        public DataTable ConsultarDetalle()
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select b.id_ingrediente, i.nombre, (count(*) * b.cantidad) as Cantidad " +
                                 "from detalle_bitacora b " +
                                 "join inventario i on i.id_ingrediente = b.id_ingrediente " +
                                 "join bitacora_rec br on br.id_detalle_bit = br.id_detalle_bit " +
                                 "where date(br.fecha) = date(Now()) " +
                                 "group by b.id_ingrediente ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch(Exception ex)
            {
                sLastError = ex.ToString();
            }


            return dtDetalle;
        }

        public DataTable ConsultarDetalle(DateTime dtFechaIn, DateTime dtFechaFin)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select b.id_ingrediente, i.nombre, (count(*) * b.cantidad) as Cantidad " +
                                 "from detalle_bitacora b " +
                                 "join inventario i on i.id_ingrediente = b.id_ingrediente " +
                                 "join bitacora_rec br on br.id_detalle_bit = br.id_detalle_bit " +
                                 "where date(br.fecha) between '" + dtFechaIn.ToString("yyyy-MM-dd") + "' and '" + dtFechaFin.ToString("yyyy-MM-dd") + "' " +
                                 "group by b.id_ingrediente ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
            }


            return dtDetalle;
        }

        public DataTable ConsultarDetalle(int nIdDetalle)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select d.id_ingrediente, r.nombre as receta, i.nombre, d.cantidad " +
                                 "from detalle_bitacora d " +
                                 "join inventario i on i.id_ingrediente = d.id_ingrediente " +
                                 "join bitacora_rec b on b.id_detalle_bit = d.id_detalle_bit " +
                                 "join recetas r on r.id_receta = b.id_receta " +
                                 "where d.id_detalle_bit = " + nIdDetalle + "; ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
            }


            return dtDetalle;
        }

        public DataTable ConsultarBitacora(DateTime dtFechaIn, DateTime dtFechaFin)
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select b.id_detalle_bit, b.id_receta, r.nombre, date(b.fecha), count(*) as Cantidad " +
                                 "from bitacora_rec b " +                                 
                                 "join recetas r on r.id_receta = b.id_receta " +
                                 "where date(b.fecha) between '" + dtFechaIn.ToString("yyyy-MM-dd") + "' and '" + dtFechaFin.ToString("yyyy-MM-dd") + "' " +
                                 "group by date(b.fecha), r.nombre;";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
            }


            return dtDetalle;
        }

        public DataTable ConsultarBitacora()
        {
            DataTable dtDetalle = new DataTable();

            try
            {
                string sSQlqry = "select b.id_detalle_bit, b.id_receta, r.nombre, date(b.fecha), count(*) as Cantidad " +
                                 "from bitacora_rec b " +                                 
                                 "join recetas r on r.id_receta = b.id_receta " +
                                 "where date(b.fecha) = date(Now()) " +
                                 "group by date(b.fecha), r.nombre;";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtDetalle);
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
            }


            return dtDetalle;
        }
    }
}
