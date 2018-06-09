using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReglasDelNegocio;
using MySql.Data.MySqlClient;

namespace Restaurante
{
    public partial class DlgAgregarOrdenes : Form
    {
        MySqlConnection xConnection;
        private Ordenes xOrdenes;
        public int nidOrd = 0;
        public DlgAgregarOrdenes(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xOrdenes = new Ordenes(xConnection);
            nidOrd = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbProp.Text.Length>0)
            {
                if (nidOrd ==0)
                {


                    if (xOrdenes.AgregarOrden(tbProp.Text, tbDesc.Text))
                    {
                        MessageBox.Show("Segregó corecamente la orden "+tbProp.Text);
                        limpiar();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("no se puedo agregar la orden");
                        tbProp.Focus();
                    }
                }
                else
                {
                    DialogResult dR = MessageBox.Show("¿Estas seguro que deseas actualizar los datos de la orden?","Confirmación",MessageBoxButtons.YesNo);
                    if (dR==DialogResult.Yes)
                    {
                        if (xOrdenes.ActualizarOrden(nidOrd, tbProp.Text, tbDesc.Text))
                        {
                            MessageBox.Show("Se actualizaron corectamente los datos de la orden");
                            limpiar();
                            DlgAgregarOrdenes_Load(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la orden");
                            tbProp.Focus();
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Propietario incorrecto");
                tbProp.Focus();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbProp.Text.Length >0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea cerrar?", "Confirmación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void DlgAgregarOrdenes_Load(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = xOrdenes.ConsultarOrdenes();
        }

        private void dgvOrdenes_DataSourceChanged(object sender, EventArgs e)
        {
            dgvOrdenes.Columns[0].Visible = false;
            dgvOrdenes.Columns[5].Visible = false;

        }
        public void limpiar()
        {
            tbProp.Clear();
            tbDesc.Clear();
            nidOrd = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            limpiar();
            tbProp.Focus();
        }

        private void dgvOrdenes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                nidOrd = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells[0].Value.ToString());
                tbProp.Text = dgvOrdenes.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbDesc.Text = dgvOrdenes.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

              
            }


        }
    }
}
