using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class DlgResumenNota : Form
    {
        public bool bConfirmar = false;
        private DataTable dtProductos;
        public double dTotal = 0;
        public string sPropietario = "";
        public double dCambio = 0;
        public double dEfectivo = 0;

        public DlgResumenNota(string sPropietario, DataTable dtProductos)
        {
            InitializeComponent();
            this.dtProductos = dtProductos;
            this.sPropietario = sPropietario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(tbEfectivo.Text.Length > 0)
            {

                dEfectivo = Convert.ToDouble(tbEfectivo.Text);
                if (dEfectivo>=dTotal)
                {
                    dCambio = dEfectivo - dTotal;
                    bConfirmar = true;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Falta efectivo!");
                }
                

                
                
                
            }
            else
            {
                MessageBox.Show("Favor de introducir cantidad de efectivo...");
            }
            
        }
        //            dt.Columns.Add("id_detalle");
      //  dt.Columns.Add("id_orden");
        // dt.Columns.Add("id_producto");

         //   dt.Columns.Add("nombre");
           // dt.Columns.Add("precio");
        private void DlgResumenNota_Load(object sender, EventArgs e)
        {
            tbPropietario.Text = sPropietario;
            if(dtProductos.Rows.Count > 0)
            {
                foreach(DataRow row in dtProductos.Rows)
                {
                    dgvProductos.Rows.Add(row[3], row[4]);
                    dTotal += Convert.ToDouble(row[4]);
                }
            }
            lblTotal.Text = "$" + dTotal.ToString();
        }

        private void tbEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
