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
        private DetalleNota xDetNota;
        int nIdSelected = 0;
        double dTotal = 0;
        public Main(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
             xOrdenes = new Ordenes(this.xConnection);
             xProd = new Productos(this.xConnection);
             xDetProd = new DetalleOrden(this.xConnection);
             xDetNota = new DetalleNota(this.xConnection);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DlgInventario dlgInventario = new DlgInventario(xConnection);

            dlgInventario.ShowDialog();

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
            if (e.RowIndex>=0)
            {
                lbPropietario.Text = dgvOrdenes.Rows[e.RowIndex].Cells[1].Value.ToString();
                lbfecha.Text = dgvOrdenes.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbDescripcion.Text = dgvOrdenes.Rows[e.RowIndex].Cells[3].Value.ToString();
                btnTotal.Text = "$" + dgvOrdenes.Rows[e.RowIndex].Cells[4].Value.ToString() + "";
                nIdSelected = Convert.ToInt32(dgvOrdenes.Rows[e.RowIndex].Cells[0].Value.ToString());

                // dgvDetalles.DataSource = xDetProd.ConsultarDetalle(nIdSelected);
                llenarDetalle();
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
            dgvDetalles.Rows.Clear();
            llenarProductos(xProd.ConsultarProductos());
            llenarOrdenes(xOrdenes.ConsultarOrdenes());
            dTotal = 0;
        }

        private void dgvProductos_DataSourceChanged(object sender, EventArgs e)
        {
            dgvProductos.Columns[0].Visible = false;
            dgvProductos.Columns[2].Visible = false;
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //AQUI

        }

        private void dgvDetalles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void llenarDetalle()
        {
            DataTable dtDetalle = xDetProd.ConsultarDetalle(nIdSelected);
            dgvDetalles.Rows.Clear();

            foreach(DataRow row in dtDetalle.Rows)
            {
                dgvDetalles.Rows.Add(row[0].ToString(), row[2].ToString(), true, row[3].ToString(), row[4].ToString(), "-");
            }

            llenarOrdenes(xOrdenes.ConsultarOrdenes());
            
            btnTotal.Text = "$" + xOrdenes.getTotal(nIdSelected);
        }
        public void llenarProductos(DataTable dtProductos)
        {
            
            dgvProductos.Rows.Clear();

            foreach (DataRow row in dtProductos.Rows)
            {
                dgvProductos.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(),"+");
            }

        }
        //"select id_orden,propietario as PROPIETARIO,FECHA as FECHA,DESCRIPCION AS DESCRIPCION,TOTAL AS TOTAL,FLAG_PAGADO from ordenes where flag_pagado = 0 and propietario like '%"+sNomPropietario+"%'";

        public void llenarOrdenes(DataTable dtOrdenes)
        {
            dgvOrdenes.Rows.Clear();

            foreach (DataRow row in dtOrdenes.Rows)
            {
                dgvOrdenes.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
            }
        }
        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (nIdSelected > 0 )
            {    
                DataTable dtDetalles = dgvToDataTable();

                if (dTotal > 0)
                {
                    DlgResumenNota dlgResumen = new DlgResumenNota(lbPropietario.Text, dtDetalles);
                    dlgResumen.ShowDialog();

                    if(dlgResumen.bConfirmar)
                    {
                        if (xDetNota.AgregarDetalle(lbPropietario.Text, tbDescripcion.Text, nIdSelected, dTotal, dtDetalles))
                        {
                            if (imprimirTicket(xDetNota.getLastNota(), Convert.ToDecimal(dlgResumen.dTotal), Convert.ToDecimal(dlgResumen.dEfectivo), Convert.ToDecimal(dlgResumen.dCambio), dtDetalles))
                            {
                                MessageBox.Show("Nota pagada");

                                if (xOrdenes.ordenPendiente(nIdSelected))
                                {
                                    Reset();
                                }
                                else
                                {
                                    llenarDetalle();
                                }
                            }   
                        }
                        else
                        {
                            MessageBox.Show(xDetNota.sLastError);
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("Favor de elegir productos a pagar...");
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar una orden...");
            }
        }

        private DataTable dgvToDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id_detalle");
            dt.Columns.Add("id_orden");
            dt.Columns.Add("id_producto");
            dt.Columns.Add("nombre");
            dt.Columns.Add("precio");
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if(Convert.ToBoolean(row.Cells[2].Value))
                {
                    dt.Rows.Add(row.Cells[0].Value, nIdSelected, row.Cells[1].Value, row.Cells[3].Value, row.Cells[4].Value);
                    dTotal += Convert.ToDouble(row.Cells[4].Value);
                }                
            }

            return dt;
        }

        public bool imprimirTicket(int nIdNota, decimal dTotal, decimal dEfectivo, decimal dCambio,  DataTable dtProductos)
        {
            bool bAllOk = false;

            try
            {
                Ticket ticket = new Ticket();
                
                ticket.AbreCajon();

                ticket.TextoCentro("RESTAURANTE YOU LI");
                ticket.TextoCentro("EXPEDIDO EN: GUASAVE, SIN.");
                ticket.TextoCentro("DIRECCION: GUASAVE, SIN.");
                ticket.TextoCentro("TEL: 6871234567");
                ticket.TextoCentro("RFC: YL1234556789");
                ticket.TextoCentro("EMAIL: VENTAS@YOULI.COM");
                ticket.TextoIzq("");
                ticket.TextoExtremo("Caja #1", "Ticket #" + nIdNota);
                ticket.lineasAst();

                //ticket.TextoIzq("");
                //ticket.TextoIzq("ATENDIO: ");
                //ticket.TextoIzq("CLIENTE: ");
                ticket.TextoIzq("");
                ticket.TextoExtremo("FECHA: "+ DateTime.Now.ToString("dd/MM/yyyy"), "HORA: " + DateTime.Now.ToLongTimeString());
                ticket.lineasAst();

                ticket.EncabezadoVenta();
                ticket.lineasAst();

                foreach(DataRow row in dtProductos.Rows)
                {
                    ticket.AgregaArticulo(row[3].ToString(), 1, Convert.ToDecimal(row[4]), Convert.ToDecimal(row[4]));
                }

                ticket.AgregarTotales("          SUBTOTAL......$", dTotal);
                ticket.AgregarTotales("          IVA...........$", 10.04M);
                ticket.AgregarTotales("          TOTAL.........$", dTotal);
                ticket.TextoIzq("");
                ticket.AgregarTotales("          EFECTIVO......$", dEfectivo);
                ticket.AgregarTotales("          CAMBIO........$", dCambio);

                ticket.TextoIzq("");
                ticket.TextoIzq("PRODUCTOS VENDIDOS: " + dtProductos.Rows.Count);
                ticket.TextoIzq("");
                ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
                ticket.CortaTicket();
                ticket.Imprimirticket("EPSON TM-U220 Receipt");
                // ticket.Imprimirticket("Microsoft XPS Document Writer");
                bAllOk = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return bAllOk;
        }

        private void tbNomProd_TextChanged(object sender, EventArgs e)
        {
            llenarProductos(xProd.ConsultarProductos(tbNomProd.Text.ToString()));
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {

            llenarOrdenes(xOrdenes.ConsultarOrdenes(tbNombre.Text.ToString()));
        }

        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (dgvDetalles.Rows[e.RowIndex].Cells[e.ColumnIndex] == dgvDetalles.Rows[e.RowIndex].Cells[5])
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

            }

        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                if (dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex] == dgvProductos.Rows[e.RowIndex].Cells[4])
                {
                    if (nIdSelected > 0)
                    {
                        if (xDetProd.AgregarDetalle(Convert.ToInt32(nIdSelected), Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value.ToString())))
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
            }

            else
            {
            }
        }
    }
}
