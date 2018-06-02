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
    public partial class DlgInventario : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Inventario xQuery;

        public DlgInventario(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xQuery = new Inventario(xConnection);
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            ReglasDelNegocio.Inventario xQuery = new ReglasDelNegocio.Inventario(xConnection);
            dgvInventario.DataSource = xQuery.ConsultarInventario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {           
            if (tbNombreIng.Text.Length > 0)
            {
                dgvInventario.DataSource = xQuery.ConsultarInventario(tbNombreIng.Text);
            }
            else
            {                
                dgvInventario.DataSource = xQuery.ConsultarInventario();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgAgregarInventario dlgAgregar = new DlgAgregarInventario(xConnection);
            dlgAgregar.ShowDialog();
            Inventario_Load(sender, e);
        }
    }
}
