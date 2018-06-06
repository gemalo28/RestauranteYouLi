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
    public partial class DlgModificarProducto : Form
    {
        MySqlConnection xConnection;
        Productos xProd;
        int nIdProdcuto;
        public DlgModificarProducto(MySqlConnection xConnection,int nIdProdcuto = 0)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.nIdProdcuto = nIdProdcuto;
            this.xProd = new Productos(xConnection);
            if (nIdProdcuto != 0)
            {
                DataTable dt = xProd.ConsultarProductos(nIdProdcuto);
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text.Length > 0 || tbDescripcion.Text.Length > 0 || tbPrecio.Text.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmación", MessageBoxButtons.YesNo);
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
        private bool bAgregarOModificar()
        {
            bool bAllOk = false;
            
                if (nIdProdcuto != 0)
                {
                bAllOk = xProd.ActualizarProducto(nIdProdcuto,tbNombre.Text,tbDescripcion.Text,Convert.ToDouble(tbPrecio.Text));
                }
                else
                {
                    bAllOk = xProd.AgregarProducto(tbNombre.Text, tbDescripcion.Text, Convert.ToDouble(tbPrecio.Text));
                }
            
            return bAllOk;
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text.Length > 0 && tbPrecio.Text.Length > 0)
            {
                if (bAgregarOModificar())
                {
                    MessageBox.Show("Se Agregó correctamente el producto '"+tbNombre.Text+"'");
                    limpiar();

                } 
            }
            else
            {
                MessageBox.Show("¡Nombre y/o precio incorrecto!");
            }
            
        }
        public void limpiar()
        {
            tbNombre.Clear();
            tbPrecio.Clear();
            tbDescripcion.Clear();
        }
    }
}

