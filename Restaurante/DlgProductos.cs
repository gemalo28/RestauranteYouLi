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
    public partial class DlgProductos : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Productos xProd;
        public DlgProductos(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xProd = new Productos(xConnection);
        }
    

        private void DlgProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = xProd.ConsultarProductos();
            tbNombreProd.Select(); 
        }

        private void dgvProductos_DataSourceChanged(object sender, EventArgs e)
        {
            dgvProductos.Columns[0].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbNombreProd.Text.Length > 0)
            {
                dgvProductos.DataSource = xProd.ConsultarProductos(Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value));
                tbNombreProd.Clear();
                tbNombreProd.Select();
            }
            else
            {
                dgvProductos.DataSource = xProd.ConsultarProductos();
            }
        }
    }
}
