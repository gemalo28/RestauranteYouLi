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
        private bool bModify = false;
        public DlgRecetas(MySqlConnection xConnection, bool bModify = false)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xRecetas = new Recetas(xConnection);
            this.bModify = bModify;

            if(bModify)
            {
                tbCantidad.Visible = true;
                btnAceptar.Visible = true;
                btnAgregar.Visible = false;
                bModify = true;
                label2.Visible = true;
            }
        }

        private void DlgRecetas_Load(object sender, EventArgs e)
        {
            llenarRecetas (xRecetas.ConsultarReceta());
        }
        public void llenarRecetas(DataTable dtRecetas)
        {

            dgvRecetas.Rows.Clear();

            foreach (DataRow row in dtRecetas.Rows)
            {
                dgvRecetas.Rows.Add(row[0].ToString(), row[1].ToString());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgModificarReceta dlgModificar = new DlgModificarReceta(xConnection);
            dlgModificar.ShowDialog();
            llenarRecetas(xRecetas.ConsultarReceta());
        }

        private void dgvRecetas_DataSourceChanged(object sender, EventArgs e)
        {
            dgvRecetas.Columns[0].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

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
            DlgModificarReceta dlgModificar = new DlgModificarReceta(xConnection, Convert.ToInt32(dgvRecetas.Rows[e.RowIndex].Cells[0].Value), bModify);
            dlgModificar.ShowDialog();
            if (!bModify)
            {
                llenarRecetas(xRecetas.ConsultarReceta());
            }
        }

        //private void dgvRecetas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea borrar esta receta?", "Confirmación", MessageBoxButtons.YesNo);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        AdminConfirmation dgAdmin = new AdminConfirmation(xConnection);
        //        dgAdmin.ShowDialog();

        //        if (dgAdmin.bValido)
        //        {
        //            if (xRecetas.BorrarReceta(Convert.ToInt32(dgvRecetas.Rows[e.Row.Index].Cells[0].Value.ToString())))
        //            {
        //                MessageBox.Show("Receta eliminada con éxito...");
        //            }
        //            else
        //            {
        //                e.Cancel = true;
        //                MessageBox.Show(xRecetas.sLastError);
        //            }
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //            MessageBox.Show("¡Sólo el administrador puede eliminar recetas!");
        //        }
        //    }
        //}

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(tbCantidad.Text.Length > 0 && dgvRecetas.SelectedCells.Count == 1 )
            {
                try
                {
                    Bitacora xBit = new Bitacora(xConnection);
                    int nRowIndex = dgvRecetas.SelectedCells[0].RowIndex;

                    if (xBit.AgregarBitacora(Convert.ToInt32(dgvRecetas.Rows[nRowIndex].Cells[0].Value), Convert.ToInt32(tbCantidad.Text)))
                    {
                        MessageBox.Show("¡Receta registrada!");
                        tbCantidad.Clear();
                        tbCantidad.Select();
                    }
                    else
                    {
                        MessageBox.Show(xBit.sLastError);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Ingrese cantidad correcta, por favor!");
                }

            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos...");
            }
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            if (tbNombre.Text.Length > 0)
            {
                llenarRecetas(xRecetas.ConsultarReceta(tbNombre.Text));
                tbNombre.Select();
            }
            else
            {
                llenarRecetas(xRecetas.ConsultarReceta());
            }
        }
    }
}
