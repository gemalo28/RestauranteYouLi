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
        private MySqlConnection  xConnection = new MySqlConnection();
        private Productos xProd;

        public DlgProductos(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xProd = new Productos(xConnection);
        }

        private void DlgProductoscs_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = xProd.ConsultarProductos();
            tbBuscar.Select();
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbBuscar.Text.Length >0)
            {
                dgvProductos.DataSource= xProd.ConsultarProductos(tbBuscar.Text);
            }
            else
            {
                dgvProductos.DataSource = xProd.ConsultarProductos();
            }
            tbBuscar.Select();
        }

        private void tbBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar_Click(sender,e);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            DlgModificarProducto DlgModProducto = new DlgModificarProducto(this.xConnection);
            DlgModProducto.ShowDialog();
            DlgProductoscs_Load(sender, e);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DlgModificarProducto dlgModProd = new DlgModificarProducto(xConnection, Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString()));
            dlgModProd.ShowDialog();
            DlgProductoscs_Load(sender, e);
        }

        private void dgvProductos_DataSourceChanged(object sender, EventArgs e)
        {
            dgvProductos.Columns[0].Visible = false;
        }
    }
}
