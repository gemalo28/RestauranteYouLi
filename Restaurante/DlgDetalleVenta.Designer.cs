namespace Restaurante
{
    partial class DlgDetalleVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbIdNota = new System.Windows.Forms.TextBox();
            this.tbPropietario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDetalleNo = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Nota";
            // 
            // tbIdNota
            // 
            this.tbIdNota.Location = new System.Drawing.Point(13, 30);
            this.tbIdNota.Name = "tbIdNota";
            this.tbIdNota.ReadOnly = true;
            this.tbIdNota.Size = new System.Drawing.Size(100, 20);
            this.tbIdNota.TabIndex = 1;
            // 
            // tbPropietario
            // 
            this.tbPropietario.Location = new System.Drawing.Point(119, 30);
            this.tbPropietario.Name = "tbPropietario";
            this.tbPropietario.ReadOnly = true;
            this.tbPropietario.Size = new System.Drawing.Size(100, 20);
            this.tbPropietario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Propietario";
            // 
            // tbFecha
            // 
            this.tbFecha.Location = new System.Drawing.Point(225, 30);
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.ReadOnly = true;
            this.tbFecha.Size = new System.Drawing.Size(100, 20);
            this.tbFecha.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(437, 30);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(70, 20);
            this.tbTotal.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total";
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(13, 84);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.ReadOnly = true;
            this.tbDescripcion.Size = new System.Drawing.Size(206, 197);
            this.tbDescripcion.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descripción";
            // 
            // dgvDetalleNo
            // 
            this.dgvDetalleNo.AllowUserToAddRows = false;
            this.dgvDetalleNo.AllowUserToDeleteRows = false;
            this.dgvDetalleNo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleNo.Location = new System.Drawing.Point(228, 84);
            this.dgvDetalleNo.Name = "dgvDetalleNo";
            this.dgvDetalleNo.ReadOnly = true;
            this.dgvDetalleNo.Size = new System.Drawing.Size(279, 197);
            this.dgvDetalleNo.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Productos";
            // 
            // DlgDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 303);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvDetalleNo);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPropietario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIdNota);
            this.Controls.Add(this.label1);
            this.Name = "DlgDetalleVenta";
            this.Text = "Detalle Venta";
            this.Load += new System.EventHandler(this.DlgDetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIdNota;
        private System.Windows.Forms.TextBox tbPropietario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDetalleNo;
        private System.Windows.Forms.Label label7;
    }
}