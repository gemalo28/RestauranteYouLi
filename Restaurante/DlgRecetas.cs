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
    public partial class DlgRecetas : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Recetas xRecetas;


        public DlgRecetas(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xRecetas = new Recetas(xConnection);
        }

        private void DlgRecetas_Load(object sender, EventArgs e)
        {
            dgvRecetas.DataSource = xRecetas.ConsultarReceta();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgModificarReceta dlgModificar = new DlgModificarReceta(xConnection);
            dlgModificar.ShowDialog();
            DlgRecetas_Load(sender, e);
        }

        private void dgvRecetas_DataSourceChanged(object sender, EventArgs e)
        {
            dgvRecetas.Columns[0].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text.Length > 0)
            {
                dgvRecetas.DataSource = xRecetas.ConsultarReceta(tbNombre.Text);
                tbNombre.Clear();
                tbNombre.Select();
            }
            else
            {
                DlgRecetas_Load(sender, e);
            }
        }

        private void tbNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void dgvRecetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DlgModificarReceta dlgModificar = new DlgModificarReceta(xConnection, Convert.ToInt32(dgvRecetas.Rows[e.RowIndex].Cells[0].Value));
            dlgModificar.ShowDialog();
            DlgRecetas_Load(sender, e);
        }

        private void dgvRecetas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea borrar esta receta?", "Confirmación", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AdminConfirmation dgAdmin = new AdminConfirmation(xConnection);
                dgAdmin.ShowDialog();

                if (dgAdmin.bValido)
                {
                    if (xRecetas.BorrarReceta(Convert.ToInt32(dgvRecetas.Rows[e.Row.Index].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Receta eliminada con éxito...");
                    }
                    else
                    {
                        e.Cancel = true;
                        MessageBox.Show(xRecetas.sLastError);
                    }
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("¡Sólo el administrador puede eliminar recetas!");
                }
            }
        }
    }
}
