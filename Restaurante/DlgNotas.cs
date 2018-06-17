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
    public partial class DlgNotas : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Notas xNotas;

        public DlgNotas(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xNotas = new Notas(xConnection);
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void DlgNotas_Load(object sender, EventArgs e)
        {
            llenarReporte(xNotas.ConsultarNota());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                llenarReporte(xNotas.ConsultarNota(dateTimePicker1.Value, dateTimePicker2.Value));
            }
            else
            {
                MessageBox.Show("Favor de verificar las fechas seleccionadas...");
            }
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DlgDetalleVenta dlgDetalle = new DlgDetalleVenta(xConnection, dgvVentas.Rows[e.RowIndex]);
            dlgDetalle.ShowDialog();
        }

        private void llenarReporte(DataTable dtReporte)
        {
            double dTotal = 0;
            dgvVentas.Rows.Clear();

            if (dtReporte.Rows.Count > 0)
            {
                foreach (DataRow row in dtReporte.Rows)
                {
                    dgvVentas.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
                    dTotal += Convert.ToDouble(row[4]);
                }

                lblTotal.Text = "$" + dTotal;
            }
        }
    }
}
