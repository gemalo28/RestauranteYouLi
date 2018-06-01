using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ReglasDelNegocio;

namespace Restaurante
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MySqlConnection xConnection = new MySqlConnection();
            Generales xGen = new Generales();

            if (xGen.ConectarDB("Server=localhost;Database=YouLi;Uid=root;Pwd=ml336013;", ref xConnection))
            {
                Application.Run(new Main(xConnection));

                if(!xGen.DesconectarDB(ref xConnection))
                {
                    MessageBox.Show(xGen.sLastError);
                }
            }
            else
            {
                MessageBox.Show(xGen.sLastError);
            }
            
        }
    }
}
