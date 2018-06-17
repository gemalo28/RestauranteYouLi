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
        private Inventario xInv;

        public DlgInventario(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xInv = new Inventario(xConnection);            
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            llenarInventario(xInv.ConsultarInventario());
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
                Inventario_Load(sender, e);
            }
        }
        public void llenarInventario(DataTable dtOrdenes)
        {

            dgvInventario.Rows.Clear();

            foreach (DataRow row in dtOrdenes.Rows)
            {
                dgvInventario.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgModificarInventario dlgAgregar = new DlgModificarInventario(xConnection);
            dlgAgregar.ShowDialog();
            Inventario_Load(sender, e);
        }

        private void dgvInventario_DataSourceChanged(object sender, EventArgs e)
        {
            dgvInventario.Columns[0].Visible = false;
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DlgModificarInventario dlgActualizar = new DlgModificarInventario(xConnection, Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells[0].Value.ToString()));
            dlgActualizar.ShowDialog();
            Inventario_Load(sender, e);            
        }

        private void tbNombreIng_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void dgvInventario_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea borrar este ingrediente?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AdminConfirmation dgAdmin = new AdminConfirmation(xConnection);
                dgAdmin.ShowDialog();

                if(dgAdmin.bValido)
                {
                    if(xInv.BorrarInventario(Convert.ToInt32(dgvInventario.Rows[e.Row.Index].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Ingrediente eliminado con éxito...");
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show(xInv.sLastError);
                    }
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("¡Sólo el administrador puede eliminar ingredientes del inventario!");
                }
            }
        }

        private void tbNombreIng_TextChanged(object sender, EventArgs e)
        {
            if (tbNombreIng.Text.Length > 0)
            {
                llenarInventario( xInv.ConsultarInventario(tbNombreIng.Text));

                tbNombreIng.Select();
            }
            else
            {
                llenarInventario(xInv.ConsultarInventario());
            }
        }
    }
}
