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
    public partial class Main : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Ordenes xOrdenes;
        private Productos xProd;
        private DetalleOrden xDetProd;
        int nIdSelected = 0;
        public Main(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
             xOrdenes = new Ordenes(this.xConnection);
             xProd = new Productos(this.xConnection);
             xDetProd = new DetalleOrden(this.xConnection);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DlgInventario dlgInventario = new DlgInventario(xConnection);
            this.Hide();
            dlgInventario.ShowDialog();
            this.Show();
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            DlgRecetas dlgRecetas = new DlgRecetas(xConnection);
            dlgRecetas.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            DlgProductos dlgProd = new DlgProductos(xConnection);
            dlgProd.ShowDialog();
            Main_Load(sender, e);
        }

        private void btnCtrlVentas_Click(object sender, EventArgs e)
        {
            DlgControlDeVentas dlgCtrl = new DlgControlDeVentas(xConnection);
            dlgCtrl.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            //if (dgvDetalles.DataSource != null)
            //{
            //    dgvDetalles.Columns[0].Visible = false;
            //    dgvDetalles.Columns[1].Visible = false;
            //    dgvDetalles.Columns[2].Visible = false;
            //}

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbPropietario.Text = dgvOrdenes.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbfecha.Text = dgvOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbDescripcion.Text = dgvOrdenes.Rows[e.RowIndex].Cells[3].Value.ToString();
                btnTotal.Text = "$" + dgvOrdenes.Rows[e.RowIndex].Cells[4].Value.ToString() + "";
                btnParcial.Text = "$00.0";
                nIdSelected = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells[0].Value.ToString());

                // dgvDetalles.DataSource = xDetProd.ConsultarDetalle(nIdSelected);
                llenarDetalle();
            }
            catch (Exception)
            {
                Reset();
                //MessageBox.Show("No se pudo consular orden");
                MessageBox.Show(xDetProd.sLastError);
            }

        }

        private void dgvOrdenes_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.Columns.Count > 0)
            {
                dgvOrdenes.Columns[0].Visible = false;
                dgvOrdenes.Columns[2].Visible = false;
                dgvOrdenes.Columns[5].Visible = false;
                
            }
            else
            {
                MessageBox.Show(xOrdenes.sLastError);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DlgAgregarOrdenes dlgOrdenes = new DlgAgregarOrdenes(xConnection);
            dlgOrdenes.ShowDialog();
            Main_Load(sender, e);
            tbNombre.Focus();
        }

        private void btnAgregarReceta_Click(object sender, EventArgs e)
        {
            DlgRecetas dlgRecetas = new DlgRecetas(xConnection, true);
            dlgRecetas.ShowDialog();
        }
        public void Reset()
        {
            lbPropietario.Text = "";
            lbfecha.Text = "";
            tbDescripcion.Text = "";
            tbDescripcion.Text = "";
            nIdSelected = 0;
            btnTotal.Text = "$00.00";
            btnParcial.Text = "$00.00";
            dgvDetalles.Rows.Clear();
            dgvOrdenes.DataSource = xOrdenes.ConsultarOrdenes();
            dgvProductos.DataSource = xProd.ConsultarProductos();
        }

        private void dgvProductos_DataSourceChanged(object sender, EventArgs e)
        {
            dgvProductos.Columns[0].Visible = false;
            dgvProductos.Columns[2].Visible = false;
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //AQUI
            if (nIdSelected >0)
            {
                if (xDetProd.AgregarDetalle(Convert.ToInt32(nIdSelected),Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString())))
                {
                    //dgvDetalles.DataSource = xDetProd.ConsultarDetalle(nIdSelected);
                    llenarDetalle();
                }
                else
                {
                    //MessageBox.Show("No se pudo agregar producto a la orden");
                    MessageBox.Show(xDetProd.sLastError);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden, Por favor!");
            }
        }

        private void dgvDetalles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (xDetProd.BorrarDetalle(Convert.ToInt32(dgvDetalles.Rows[e.RowIndex].Cells[0].Value.ToString())))
            {
                llenarDetalle();
            }
            else
            {
                //MessageBox.Show("No se pudo eliminar el producto de la orden");
                MessageBox.Show(xDetProd.sLastError);
            }
        }

        private void llenarDetalle()
        {
            DataTable dtDetalle = xDetProd.ConsultarDetalle(nIdSelected);
            dgvDetalles.Rows.Clear();

            foreach(DataRow row in dtDetalle.Rows)
            {
                dgvDetalles.Rows.Add(row[0].ToString(), row[2].ToString(), true, row[3].ToString(), row[4].ToString());
            }

            dgvOrdenes.DataSource = xOrdenes.ConsultarOrdenes();
            
            btnTotal.Text = "$" + xOrdenes.getTotal(nIdSelected);
        }
    }
}
