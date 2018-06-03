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
    public partial class DlgModificarInventario : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Inventario xInv;
        private int nIdIngrediente;
        private int nPrevIndex = -1;
        public DlgModificarInventario(MySqlConnection xConnection, int nIdIngrediente = 0)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.xInv = new Inventario(xConnection);
            this.nIdIngrediente = nIdIngrediente;

            cbxUnidad.Items.Add("Kg");
            cbxUnidad.Items.Add("g");
            cbxUnidad.SelectedIndex = 0;

            if(nIdIngrediente > 0)
            {
                cbxUnidad.SelectedIndex = 1;
                ConsultarIngrediente();                
            }


        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(bValidarVacio()) //valida tb's vacios
            {
                Double dCantidad = Convert.ToDouble(tbCantidad.Text);
                if(cbxUnidad.SelectedIndex == 0)
                {
                    dCantidad *= 1000;
                }

                if(nIdIngrediente == 0) //valida si es actualizacion u insercion
                {
                    //se convierte nombre a mayusculas para prevenir ingredientes duplicados
                    if (xInv.AgregarInventario(tbNombre.Text.ToUpper(), (int)dCantidad))
                    {
                        MessageBox.Show("Se agregó ingrediente!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(xInv.sLastError);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea actualizar este ingrediente?","Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //se convierte nombre a mayusculas para prevenir ingredientes duplicados
                        if (xInv.ActualizarInventario(nIdIngrediente, tbNombre.Text.ToUpper(), (int)dCantidad))
                        {
                            MessageBox.Show("Ingrediente actualizado!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(xInv.sLastError);
                        }
                    }                    
                }
                
            }
        }

        private bool bValidarVacio()
        {
            if(tbNombre.Text.Length > 0 && tbCantidad.Text.Length > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos...");
                return false;
            }
        }
        
        private void ConsultarIngrediente()
        {
            DataTable dtIngrediente = xInv.ConsultarInventario(nIdIngrediente);

            tbNombre.Text = dtIngrediente.Rows[0]["nombre"].ToString();
            tbCantidad.Text = dtIngrediente.Rows[0]["cantidad"].ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            double dValor = 0;

            //valida que tbCantidad no este vacio y que no se seleccione el mismo indice
            if (tbCantidad.Text.Length > 0 && cbxUnidad.SelectedIndex != nPrevIndex) 
            {
                if (cbxUnidad.SelectedIndex == 0)
                {
                    dValor = Convert.ToDouble(tbCantidad.Text) / 1000;
                }
                else if (cbxUnidad.SelectedIndex == 1)
                {
                    dValor = Convert.ToDouble(tbCantidad.Text) * 1000;
                }
                tbCantidad.Text = dValor.ToString();
                nPrevIndex = cbxUnidad.SelectedIndex;
            }
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
