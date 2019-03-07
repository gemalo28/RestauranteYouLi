//namespace Restaurante
//{
//    partial class DlgAgregarOrdenes
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAgregarOrdenes));
//            this.tbProp = new System.Windows.Forms.TextBox();
//            this.tbDesc = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.btnCancelar = new System.Windows.Forms.Button();
//            this.btnGuardar = new System.Windows.Forms.Button();
//            this.btnNuevo = new System.Windows.Forms.Button();
//            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // tbProp
//            // 
//            this.tbProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tbProp.Location = new System.Drawing.Point(12, 120);
//            this.tbProp.Name = "tbProp";
//            this.tbProp.Size = new System.Drawing.Size(191, 29);
//            this.tbProp.TabIndex = 0;
//            // 
//            // tbDesc
//            // 
//            this.tbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tbDesc.Location = new System.Drawing.Point(12, 204);
//            this.tbDesc.Multiline = true;
//            this.tbDesc.Name = "tbDesc";
//            this.tbDesc.Size = new System.Drawing.Size(293, 138);
//            this.tbDesc.TabIndex = 1;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(12, 93);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(124, 24);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "Propiertario:";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(8, 167);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(127, 24);
//            this.label2.TabIndex = 3;
//            this.label2.Text = "Descripción:";
//            // 
//            // btnCancelar
//            // 
//            this.btnCancelar.BackColor = System.Drawing.Color.LightYellow;
//            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnCancelar.Location = new System.Drawing.Point(16, 382);
//            this.btnCancelar.Name = "btnCancelar";
//            this.btnCancelar.Size = new System.Drawing.Size(128, 39);
//            this.btnCancelar.TabIndex = 4;
//            this.btnCancelar.Text = "CANCELAR";
//            this.btnCancelar.UseVisualStyleBackColor = false;
//            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // btnGuardar
//            // 
//            this.btnGuardar.BackColor = System.Drawing.Color.LightYellow;
//            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnGuardar.Location = new System.Drawing.Point(187, 382);
//            this.btnGuardar.Name = "btnGuardar";
//            this.btnGuardar.Size = new System.Drawing.Size(118, 39);
//            this.btnGuardar.TabIndex = 5;
//            this.btnGuardar.Text = "GUARDAR";
//            this.btnGuardar.UseVisualStyleBackColor = false;
//            this.btnGuardar.Click += new System.EventHandler(this.button2_Click);
//            // 
//            // btnNuevo
//            // 
//            this.btnNuevo.BackColor = System.Drawing.Color.LightYellow;
//            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnNuevo.Location = new System.Drawing.Point(209, 120);
//            this.btnNuevo.Name = "btnNuevo";
//            this.btnNuevo.Size = new System.Drawing.Size(96, 32);
//            this.btnNuevo.TabIndex = 7;
//            this.btnNuevo.Text = "NUEVO";
//            this.btnNuevo.UseVisualStyleBackColor = false;
//            this.btnNuevo.Click += new System.EventHandler(this.button3_Click);
//            // 
//            // Column6
//            // 
//            this.Column6.HeaderText = "Flag_pagado";
//            this.Column6.Name = "Column6";
//            this.Column6.ReadOnly = true;
//            this.Column6.Visible = false;
//            // 
//            // Column5
//            // 
//            this.Column5.FillWeight = 50F;
//            this.Column5.HeaderText = "Total";
//            this.Column5.Name = "Column5";
//            this.Column5.ReadOnly = true;
//            // 
//            // Column4
//            // 
//            this.Column4.HeaderText = "Descripcion";
//            this.Column4.Name = "Column4";
//            this.Column4.ReadOnly = true;
//            // 
//            // Column3
//            // 
//            this.Column3.HeaderText = "Fecha";
//            this.Column3.Name = "Column3";
//            this.Column3.ReadOnly = true;
//            // 
//            // Column2
//            // 
//            this.Column2.HeaderText = "Propietario";
//            this.Column2.Name = "Column2";
//            this.Column2.ReadOnly = true;
//            // 
//            // Column1
//            // 
//            this.Column1.HeaderText = "id_orden";
//            this.Column1.Name = "Column1";
//            this.Column1.ReadOnly = true;
//            this.Column1.Visible = false;
//            // 
//            // dgvOrdenes
//            // 
//            this.dgvOrdenes.AllowUserToAddRows = false;
//            this.dgvOrdenes.AllowUserToDeleteRows = false;
//            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvOrdenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
//            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
//            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
//            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
//            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
//            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
//            this.dgvOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
//            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.Column1,
//            this.Column2,
//            this.Column3,
//            this.Column4,
//            this.Column5,
//            this.Column6});
//            this.dgvOrdenes.EnableHeadersVisualStyles = false;
//            this.dgvOrdenes.Location = new System.Drawing.Point(327, 12);
//            this.dgvOrdenes.Name = "dgvOrdenes";
//            this.dgvOrdenes.ReadOnly = true;
//            this.dgvOrdenes.RowHeadersVisible = false;
//            this.dgvOrdenes.Size = new System.Drawing.Size(562, 409);
//            this.dgvOrdenes.TabIndex = 8;
//            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);
//            // 
//            // DlgAgregarOrdenes
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
//            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
//            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//            this.ClientSize = new System.Drawing.Size(901, 430);
//            this.Controls.Add(this.dgvOrdenes);
//            this.Controls.Add(this.btnNuevo);
//            this.Controls.Add(this.btnGuardar);
//            this.Controls.Add(this.btnCancelar);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.tbDesc);
//            this.Controls.Add(this.tbProp);
//            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "DlgAgregarOrdenes";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Ordenes";
//            this.Load += new System.EventHandler(this.DlgAgregarOrdenes_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.TextBox tbProp;
//        private System.Windows.Forms.TextBox tbDesc;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Button btnCancelar;
//        private System.Windows.Forms.Button btnGuardar;
//        private System.Windows.Forms.Button btnNuevo;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
//        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
//        private System.Windows.Forms.DataGridView dgvOrdenes;
//    }
//}

namespace Restaurante
{
    partial class DlgAgregarOrdenes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAgregarOrdenes));
            this.tbProp = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProp
            // 
            this.tbProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProp.ForeColor = System.Drawing.Color.Red;
            this.tbProp.Location = new System.Drawing.Point(12, 132);
            this.tbProp.Name = "tbProp";
            this.tbProp.Size = new System.Drawing.Size(191, 29);
            this.tbProp.TabIndex = 0;
            // 
            // tbDesc
            // 
            this.tbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDesc.ForeColor = System.Drawing.Color.Red;
            this.tbDesc.Location = new System.Drawing.Point(12, 204);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(293, 138);
            this.tbDesc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Propietario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightYellow;
            this.btnEliminar.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(177, 379);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(128, 39);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightYellow;
            this.btnGuardar.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(12, 379);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(118, 39);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.LightYellow;
            this.btnNuevo.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(209, 132);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(96, 32);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenes.EnableHeadersVisualStyles = false;
            this.dgvOrdenes.Location = new System.Drawing.Point(327, 46);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenes.Size = new System.Drawing.Size(562, 375);
            this.dgvOrdenes.TabIndex = 8;
            this.dgvOrdenes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellClick);
            this.dgvOrdenes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenes_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id_orden";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Propietario";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Descripcion";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Flag_pagado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(779, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 27);
            this.label5.TabIndex = 23;
            this.label5.Text = "ORDENES";
            // 
            // DlgAgregarOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(901, 430);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbProp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgAgregarOrdenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenes";
            this.Load += new System.EventHandler(this.DlgAgregarOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProp;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label5;
    }
}