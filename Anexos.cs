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
		
		public Boolean AgregarCliente(string sNombre, string sTelefono,string sDireccion,string sAnexo)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into clientes(nombre, num_telefono, direccion, anexo) " +
                                 "values('" + sNombre + "','" + sTelefono + "'," + sDireccion + "','"+ sAnexo + "')";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error al agregar cliente >>> " + ex.ToString();
            }

            return bAllOk;
        }
		public DataTable ConsultarClientes(string sCadena )
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select id_cliente, nombre as NOMBRE, num_telefono as TELEFONO, direccion as DIRECCION, anexo as ANEXO from clientes " +
                                 "where nombre like '%" + sCadena+"%' OR direccion like '%"+sCadena+"%' OR num_telefono like '%"+sCadena+"'%'";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
                
            }
            catch (Exception ex)
            {
                sLastError = "Error al consultar clientes >>> " + ex.ToString();
            }

            return dtProductos;
        }
		public DataTable ConsultarClientes()
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select id_cliente, nombre AS NOMBRE, direccion AS DIRECCION, anexo AS ANEXO from clientes ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
            }
            catch (Exception ex)
            {
                sLastError = "Error al consultar clientes >>> " + ex.ToString();
            }
            return dtProductos;
        }
		public Boolean Actualizarcliente(int nIdCliente, string sNombre, string sTelefono,string sDireccion,string sAnexo)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update clientes set nombre = '" + sNombre + "', num_telefono = '" + sTelefono + "', direccion = " + sDireccion +"', anexo = " + sAnexo +
                                 " where id_cliente = " + nIdCliente;
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
		//---------->empleados
		//---------->empleados
		//---------->empleados
		//---------->empleados
		//---------->empleados
		//---------->empleados
		//---------->empleados
		public Boolean AgregarEmpelado(string sNombre, string sTelefono,string sDireccion,string sAnexo)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "insert into empleados(nombre, num_telefono, direccion, anexo) " +
                                 "values('" + sNombre + "','" + sTelefono + "'," + sDireccion + "','"+ sAnexo + "')";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error al agregar empelado >>> " + ex.ToString();
            }

            return bAllOk;
        }
		public DataTable ConsultarEmpelado(string sCadena, string id_pusto =1)
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select id_empleado, nombre as NOMBRE, num_telefono as TELEFONO, direccion as DIRECCION, anexo as ANEXO from empelados " +
                                 "where (nombre like '%" + sCadena+"%' OR direccion like '%"+sCadena+"%' OR num_telefono like '%"+sCadena+"'%') AND id_puesto = "+sAnexo;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
                
            }
            catch (Exception ex)
            {
                sLastError = "Error al consultar empelado >>> " + ex.ToString();
            }

            return dtProductos;
        }
		public DataTable ConsultarEmpelado()
        {
            DataTable dtProductos = new DataTable();

            try
            {
                string sSQlqry = "select id_empelado, nombre AS NOMBRE, direccion AS DIRECCION, anexo AS ANEXO from empelados ";
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(dtProductos);
            }
            catch (Exception ex)
            {
                sLastError = "Error al consultar empleados >>> " + ex.ToString();
            }
            return dtProductos;
        }
		public Boolean Actualizarcliente(int nIdEmpleado, string sNombre, string sTelefono,string sDireccion,string sAnexo)
        {
            bool bAllOk = false;

            try
            {
                string sSQlqry = "update empelados set nombre = '" + sNombre + "', num_telefono = '" + sTelefono + "', direccion = " + sDireccion +"', anexo = " + sAnexo +
                                 " where id_empleado = " + nIdEmpleado;
                MySqlCommand command = new MySqlCommand(sSQlqry, xConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = "Error al actualziar empleado >>> " + ex.ToString();
            }

            return bAllOk;
        }
	}
	
}