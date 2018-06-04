using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DlgInventario dlgInventario = new DlgInventario(xConnection);
            this.Hide();
            dlgInventario.ShowDialog();
            this.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DlgProductos dlgProductos = new DlgProductos(xConnection);
            this.Hide();
            dlgProductos.ShowDialog();
            this.Show();
        }
    }
}
