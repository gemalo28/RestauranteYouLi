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
        private Ordenes xOrdenes;
        public Main(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
             xOrdenes = new Ordenes(this.xConnection);
            
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

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            DlgRecetas dlgRecetas = new DlgRecetas(xConnection);
            dlgRecetas.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            DlgProductos dlgProd = new DlgProductos(xConnection);
            dlgProd.ShowDialog();
        }

        private void btnCtrlVentas_Click(object sender, EventArgs e)
        {
            DlgControlDeVentas dlgCtrl = new DlgControlDeVentas(xConnection);
            dlgCtrl.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = xOrdenes.ConsultarOrdenes();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = xOrdenes.ConsultarOrdenes(tbNombre.Text);
        }

        private void lbPropietario_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbPropietario.Text = dgvOrdenes.Rows[e.RowIndex].Cells[1].Value.ToString();
            lbfecha.Text = dgvOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbDescripcion.Text = dgvOrdenes.Rows[e.RowIndex].Cells[3].Value.ToString();
            btnTotal.Text = "$"+ dgvOrdenes.Rows[e.RowIndex].Cells[4].Value.ToString()+"";
            btnParcial.Text = "$00.0";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvOrdenes_DataSourceChanged(object sender, EventArgs e)
        {
            dgvOrdenes.Columns[0].Visible = false;
            dgvOrdenes.Columns[2].Visible = false;
            dgvOrdenes.Columns[5].Visible = false;
        }
    }
}
