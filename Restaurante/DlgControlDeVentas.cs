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
    public partial class DlgControlDeVentas : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Notas xNotas;

        public DlgControlDeVentas(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xNotas = new Notas(xConnection);
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        
        }

        private void DlgControlDeVentas_Load(object sender, EventArgs e)
        {
            dgvVentas.DataSource = xNotas.ConsultarNota();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                dgvVentas.DataSource = xNotas.ConsultarNota(dateTimePicker1.Value, dateTimePicker2.Value);
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
    }
}
;