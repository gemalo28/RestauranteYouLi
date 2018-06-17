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
    public partial class DlgReportesProductos : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Productos xProductos;
        public DlgReportesProductos(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.xProductos = new Productos(xConnection);
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void DlgReportesProductos_Load(object sender, EventArgs e)
        {
            llenarReporte(xProductos.ConsultarProductos(DateTime.Today));
        }

        private void llenarReporte(DataTable dtReporte)
        {
            double dTotal = 0;
            dgvVentas.Rows.Clear();

            if(dtReporte.Rows.Count > 0)
            {
                foreach(DataRow row in dtReporte.Rows)
                {
                    dgvVentas.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
                    dTotal += Convert.ToDouble(row[5]);
                }

                lblTotal.Text = "$" + dTotal;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                llenarReporte(xProductos.ConsultarProductos(dateTimePicker1.Value, dateTimePicker2.Value));
            }
            else
            {
                MessageBox.Show("Favor de verificar las fechas seleccionadas...");
            }
        }
    }
}
