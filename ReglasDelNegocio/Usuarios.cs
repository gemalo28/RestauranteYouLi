using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReglasDelNegocio
{
    public class Usuarios
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public string sLastError = "";

        public Usuarios(MySqlConnection xConnection)
        {
            this.xConnection = xConnection;
        }

        public DataTable ConsultarUsuarios(int nIdUsuario)
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
            }
            catch(Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }
            

            return dtProductos;
        }

        //public Boolean BorrarUsuario(int nIdUsuario)
        //{
        //    bool bAllOk = false;
        //    try
        //    {
        //        string sSQlqry = "";
        //        MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
        //        command.ExecuteNonQuery();
        //        command.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        sLastError = "Error >>> " + ex.ToString();
        //    }

        //    return bAllOk;
        //}

        public Boolean ActualizarUsuario(string sUsuario, string sContrasena)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update usuarios set contraseña = "+sContrasena;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception ex)
            {
                sLastError = "Error >>> " + ex.ToString();
            }


            return bAllOk;
        }

        //public Boolean AgregarUsuario(int nIdUsuario, string sNombre, string sContrasena)
        //{
        //    bool bAllOk = false;
        //    try
        //    {
        //        string sSQlqry = "insert into usuarios";
        //        MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
        //        command.ExecuteNonQuery();
        //        command.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        sLastError = "Error >>> " + ex.ToString();
        //    }

        //    return bAllOk;
        //}
    }
}
