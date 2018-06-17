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
            llenarNotas( xNotas.ConsultarNota());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date)
            {
                llenarNotas(xNotas.ConsultarNota(dateTimePicker1.Value, dateTimePicker2.Value));
            }
            else
            {
                MessageBox.Show("Favor de verificar las fechas seleccionadas...");
            }
        }
        //select id_nota as ID, propietario as Propietario, date(fecha) as Fecha, descripcion as Descripcion, total as Total
        public void llenarNotas(DataTable dtOrdenes)
        {
          //  if (dgvVentas.Rows.Count >0)
            {
                dgvVentas.Rows.Clear();


            }
            foreach (DataRow row in dtOrdenes.Rows)
            {
                dgvVentas.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }

        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvVentas_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DlgDetalleVenta dlgDetalle = new DlgDetalleVenta(xConnection, dgvVentas.Rows[e.RowIndex]);
                dlgDetalle.ShowDialog();
            }
        }
    }
}
;