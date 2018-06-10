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
    public partial class DlgModificarReceta : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Recetas xReceta;
        private DetalleReceta xDetalleRec;
        private int nIdReceta;

        public DlgModificarReceta(MySqlConnection xConnection, int nIdReceta = 0, bool bModify = false)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.xReceta = new Recetas(xConnection);
            this.xDetalleRec = new DetalleReceta(xConnection);
            this.nIdReceta = nIdReceta;

            if(nIdReceta > 0)
            {
                ConsultarReceta();
            }

            if(bModify)
            {
                tbNombre.ReadOnly = true;
                btnAgregar.Visible = false;
                btnConfirmar.Visible = false;
                dgvIngredientes.Columns[3].ReadOnly = true;
            }
        }

        private void DlgModificarReceta_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DlgAgregarIngrediente dlgAgregar = new DlgAgregarIngrediente(xConnection);
            dlgAgregar.ShowDialog();

            if(dlgAgregar.nIdIngrediente > 0)
            {
                if(validarDuplicado(dlgAgregar.nIdIngrediente))
                {
                    dgvIngredientes.Rows.Add(0, dlgAgregar.nIdIngrediente, dlgAgregar.sNombre, 0);
                }
                
            }
        }

        private bool validarDuplicado(int nIdIngrediente)
        {
            bool bAllOk = true;

            for(int i = 0; i < dgvIngredientes.Rows.Count; i++)
            {
                if(nIdIngrediente == Convert.ToInt32(dgvIngredientes.Rows[i].Cells[0].Value))
                {
                    MessageBox.Show("Ingrediente ya existe en receta...");
                    bAllOk = false;
                    break;
                }
            }

            return bAllOk;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {           
            if(tbNombre.Text.Length > 0 && dgvIngredientes.Rows.Count > 0)
            {
                DataTable dtIngredientes = dgvToDataTable();
                if(nIdReceta > 0)
                {
                    if(xDetalleRec.ActualizarDetalle(tbNombre.Text.ToUpper(), nIdReceta, dtIngredientes))
                    {
                        MessageBox.Show("¡Receta actualizada!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(xDetalleRec.sLastError);
                    }
                }
                else
                {
                    if (xDetalleRec.AgregarDetalle(tbNombre.Text.ToUpper(), dtIngredientes))
                    {
                        MessageBox.Show("¡Receta agregada!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(xDetalleRec.sLastError);
                    }
                }              
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos...");
            }
            
        }

        private DataTable dgvToDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id_detalle");
            dt.Columns.Add("id_ingrediente");
            dt.Columns.Add("nombre");
            dt.Columns.Add("cantidad");
            foreach(DataGridViewRow row in dgvIngredientes.Rows)
            {
                dt.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value);
            }

            return dt;
        }

        private void ConsultarReceta()
        {
            DataTable dtReceta = xReceta.ConsultarReceta(nIdReceta);
            DataTable dtIngredientes = xDetalleRec.ConsultarDetalle(nIdReceta);

            tbNombre.Text = dtReceta.Rows[0][1].ToString();

            foreach(DataRow row in dtIngredientes.Rows)
            {
                dgvIngredientes.Rows.Add(1, row[0].ToString(), row[1].ToString(), row[2].ToString());
            }
        }

        private void dgvIngredientes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            dgvIngredientes.Rows[e.Row.Index].Visible = false;
            dgvIngredientes.Rows[e.Row.Index].Cells[0].Value =-1;
            e.Cancel = true;
        }
    }
}
