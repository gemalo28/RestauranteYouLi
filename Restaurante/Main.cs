using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using ReglasDelNegocio;

namespace Restaurante
{
    public partial class Main : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        public Main(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            
        }
    }
}
