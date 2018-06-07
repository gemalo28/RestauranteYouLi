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
    public partial class DlgDetalleVenta : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private DetalleNota xDetalleNo;
        //private int nIdNota;
        //private int nIdDetalle;
        private DataGridViewRow row;

        public DlgDetalleVenta(MySqlConnection xConnection, DataGridViewRow row)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xDetalleNo = new DetalleNota(xConnection);
            //this.nIdNota = nIdNota;
            //this.nIdDetalle = nIdDetalle;
            this.row = row;
        }

        private void DlgDetalleVenta_Load(object sender, EventArgs e)
        {
            DataTable dtDetalle = new DataTable();

            dtDetalle = xDetalleNo.ConsultarDetalle(Convert.ToInt32(row.Cells[0].Value));

            if(dtDetalle.Rows.Count > 0)
            {
                dgvDetalleNo.DataSource = dtDetalle;
                tbIdNota.Text = row.Cells[0].Value.ToString();
                tbPropietario.Text = row.Cells[1].Value.ToString();
                tbFecha.Text = Convert.ToDateTime(row.Cells[2].Value).ToString("dd/MM/yyyy");
                tbDescripcion.Text = row.Cells[3].Value.ToString();
                tbTotal.Text = row.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show(xDetalleNo.sLastError);
                this.Close();
            }
        }
    }
}
