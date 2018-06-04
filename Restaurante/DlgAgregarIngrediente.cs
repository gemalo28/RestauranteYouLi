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
    public partial class DlgAgregarIngrediente : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Inventario xInv;
        public int nIdIngrediente = 0;
        public string sNombre = "";

        public DlgAgregarIngrediente(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.xInv = new Inventario(xConnection);
        }

        private void DlgAgregarIngrediente_Load(object sender, EventArgs e)
        {
            dgvInventario.DataSource = xInv.ConsultarInventario();
            tbNombreIng.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbNombreIng.Text.Length > 0)
            {
                dgvInventario.DataSource = xInv.ConsultarInventario(tbNombreIng.Text);
                tbNombreIng.Clear();
                tbNombreIng.Select();
            }
            else
            {
                DlgAgregarIngrediente_Load(sender, e);
            }
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            sNombre = dgvInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
            nIdIngrediente = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells[0].Value);
            this.Close();
        }

        private void dgvInventario_DataSourceChanged(object sender, EventArgs e)
        {
            dgvInventario.Columns[0].Visible = false;
        }

        private void tbNombreIng_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnBuscar_Click(sender, e);
            }
        }
    }
}
