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
    public partial class DlgControlDeVentas : Form
    {
        private MySqlConnection xConnection = new MySqlConnection();
        private Notas xNotas;

        public DlgControlDeVentas(MySqlConnection xConnection)
        {
            InitializeComponent();
            this.xConnection = xConnection;        
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            DlgNotas dlgNotas = new DlgNotas(xConnection);
            dlgNotas.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            DlgReportesProductos dlgReportes = new DlgReportesProductos(xConnection);
            dlgReportes.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            DlgReporteInventario dlgInventario = new DlgReporteInventario(xConnection);
            dlgInventario.ShowDialog();
        }
    }
}
;
