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
    public partial class DlgReporteInventario : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Bitacora xBitacora;

        public DlgReporteInventario(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xBitacora = new Bitacora(xConnection);
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void DlgReporteInventario_Load(object sender, EventArgs e)
        {
            llenarRecetas(xBitacora.ConsultarBitacora());
            llenarIngredientes(xBitacora.ConsultarDetalle());
        }

        private void llenarRecetas(DataTable dtRecetas)
        {
            dgvRecetas.Rows.Clear();

            foreach (DataRow row in dtRecetas.Rows)
            {
                dgvRecetas.Rows.Add(row[0], row[1], row[2], Convert.ToDateTime(row[3]).ToString("dd/MM/yyyy"), row[4]);
            }
        }

        private void llenarIngredientes(DataTable dtRecetas)
        {
            dgvIngredientes.Rows.Clear();

            foreach (DataRow row in dtRecetas.Rows)
            {
                dgvIngredientes.Rows.Add(row[0], row[1], row[2]);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                llenarRecetas(xBitacora.ConsultarBitacora(dateTimePicker1.Value, dateTimePicker2.Value));
                llenarIngredientes(xBitacora.ConsultarDetalle(dateTimePicker1.Value, dateTimePicker2.Value));
            }
            else
            {
                MessageBox.Show("Favor de verificar las fechas seleccionadas...");
            }
        }

        private void dgvRecetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int nIdDetalle = Convert.ToInt32(dgvRecetas.Rows[e.RowIndex].Cells[0].Value);
                DlgModificarReceta dlgModificar = new DlgModificarReceta(xConnection, 0, true, nIdDetalle);
                dlgModificar.ShowDialog();
            }
        }
    }
}
