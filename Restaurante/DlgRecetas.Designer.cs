﻿namespace Restaurante
{
    partial class DlgRecetas
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvRecetas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(258, 27);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(12, 30);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(159, 20);
            this.tbNombre.TabIndex = 7;
            this.tbNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbNombre_KeyUp);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(177, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvRecetas
            // 
            this.dgvRecetas.AllowUserToAddRows = false;
            this.dgvRecetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecetas.Location = new System.Drawing.Point(11, 59);
            this.dgvRecetas.Name = "dgvRecetas";
            this.dgvRecetas.ReadOnly = true;
            this.dgvRecetas.Size = new System.Drawing.Size(305, 299);
            this.dgvRecetas.TabIndex = 5;
            this.dgvRecetas.DataSourceChanged += new System.EventHandler(this.dgvRecetas_DataSourceChanged);
            this.dgvRecetas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecetas_CellDoubleClick);
            this.dgvRecetas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRecetas_UserDeletingRow);
            // 
            // DlgRecetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 374);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvRecetas);
            this.Name = "DlgRecetas";
            this.Text = "Recetas";
            this.Load += new System.EventHandler(this.DlgRecetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvRecetas;
    }
}