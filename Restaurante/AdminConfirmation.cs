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
    public partial class AdminConfirmation : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Usuarios xUser;
        public bool bValido = false;

        public AdminConfirmation(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;
            xUser = new Usuarios(xConnection);
        }

        private void cbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            tbContraseña.UseSystemPasswordChar = !tbContraseña.UseSystemPasswordChar;
        }

        private void tbContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (xUser.ValidarPassword("Admin", tbContraseña.Text))
                {
                    bValido = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("¡Contraseña incorrecta!");
                }
            }
        }
    }
}
