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
    public partial class DlgAgregarInventario : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Inventario xInv;
        public DlgAgregarInventario(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            this.xInv = new Inventario(xConnection);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(bValidarVacio())
            {
                if (xInv.AgregarInventario(tbNombre.Text, Convert.ToInt32(tbCantidad.Text)))
                {
                    MessageBox.Show("Se agregó ingrediente!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(xInv.sLastError);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
