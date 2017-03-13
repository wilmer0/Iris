namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    partial class ventana_reporte_pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_reporte_pagos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBoxSoloComprasPagadas = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fechaFinalVentaText = new System.Windows.Forms.MaskedTextBox();
            this.fechaInicialVentaText = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxIncluirRangoFechaVenta = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tipoVentaComboBox = new System.Windows.Forms.ComboBox();
            this.ventaLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ventaIdText = new System.Windows.Forms.TextBox();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.clienteIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 536);
            this.panel1.Size = new System.Drawing.Size(1122, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(981, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1146, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(491, 5);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(16, 235);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1113, 286);
            this.dataGridView1.TabIndex = 108;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "ID Cliente";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cliente";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "ID Venta";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Tipo Venta";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 80F;
            this.Column4.HeaderText = "NCF";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Monto Factura";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Monto Cobrado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Monto Pendiente";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.checkBoxSoloComprasPagadas);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tipoVentaComboBox);
            this.groupBox1.Controls.Add(this.ventaLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.ventaIdText);
            this.groupBox1.Controls.Add(this.clienteLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.clienteIdText);
            this.groupBox1.Location = new System.Drawing.Point(16, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1116, 202);
            this.groupBox1.TabIndex = 107;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 20);
            this.label8.TabIndex = 99;
            this.label8.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(359, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 98;
            this.label7.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 97;
            this.label1.Text = "X";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(972, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(138, 41);
            this.button6.TabIndex = 96;
            this.button6.Text = "Imprimir";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // checkBoxSoloComprasPagadas
            // 
            this.checkBoxSoloComprasPagadas.AutoSize = true;
            this.checkBoxSoloComprasPagadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSoloComprasPagadas.Location = new System.Drawing.Point(915, 19);
            this.checkBoxSoloComprasPagadas.Name = "checkBoxSoloComprasPagadas";
            this.checkBoxSoloComprasPagadas.Size = new System.Drawing.Size(195, 21);
            this.checkBoxSoloComprasPagadas.TabIndex = 91;
            this.checkBoxSoloComprasPagadas.Text = "Solo Compras Pagadas";
            this.checkBoxSoloComprasPagadas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fechaFinalVentaText);
            this.groupBox2.Controls.Add(this.fechaInicialVentaText);
            this.groupBox2.Controls.Add(this.checkBoxIncluirRangoFechaVenta);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(395, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 108);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha Compras";
            // 
            // fechaFinalVentaText
            // 
            this.fechaFinalVentaText.Location = new System.Drawing.Point(387, 63);
            this.fechaFinalVentaText.Mask = "00/00/0000";
            this.fechaFinalVentaText.Name = "fechaFinalVentaText";
            this.fechaFinalVentaText.Size = new System.Drawing.Size(100, 20);
            this.fechaFinalVentaText.TabIndex = 92;
            this.fechaFinalVentaText.ValidatingType = typeof(System.DateTime);
            // 
            // fechaInicialVentaText
            // 
            this.fechaInicialVentaText.Location = new System.Drawing.Point(152, 63);
            this.fechaInicialVentaText.Mask = "00/00/0000";
            this.fechaInicialVentaText.Name = "fechaInicialVentaText";
            this.fechaInicialVentaText.Size = new System.Drawing.Size(100, 20);
            this.fechaInicialVentaText.TabIndex = 91;
            this.fechaInicialVentaText.ValidatingType = typeof(System.DateTime);
            // 
            // checkBoxIncluirRangoFechaVenta
            // 
            this.checkBoxIncluirRangoFechaVenta.AutoSize = true;
            this.checkBoxIncluirRangoFechaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncluirRangoFechaVenta.Location = new System.Drawing.Point(18, 27);
            this.checkBoxIncluirRangoFechaVenta.Name = "checkBoxIncluirRangoFechaVenta";
            this.checkBoxIncluirRangoFechaVenta.Size = new System.Drawing.Size(163, 21);
            this.checkBoxIncluirRangoFechaVenta.TabIndex = 90;
            this.checkBoxIncluirRangoFechaVenta.Text = "Incluir rango fecha";
            this.checkBoxIncluirRangoFechaVenta.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 86;
            this.label5.Text = "Fecha inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(283, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 87;
            this.label6.Text = "Fecha final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "Tipo compra";
            // 
            // tipoVentaComboBox
            // 
            this.tipoVentaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoVentaComboBox.FormattingEnabled = true;
            this.tipoVentaComboBox.Items.AddRange(new object[] {
            "",
            "CONTADO",
            "COTIZACION",
            "CREDITO",
            "PEDIDO"});
            this.tipoVentaComboBox.Location = new System.Drawing.Point(117, 164);
            this.tipoVentaComboBox.Name = "tipoVentaComboBox";
            this.tipoVentaComboBox.Size = new System.Drawing.Size(236, 21);
            this.tipoVentaComboBox.TabIndex = 84;
            this.tipoVentaComboBox.Tag = "";
            // 
            // ventaLabel
            // 
            this.ventaLabel.AutoSize = true;
            this.ventaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaLabel.Location = new System.Drawing.Point(114, 129);
            this.ventaLabel.Name = "ventaLabel";
            this.ventaLabel.Size = new System.Drawing.Size(44, 20);
            this.ventaLabel.TabIndex = 83;
            this.ventaLabel.Text = "NCF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "Compra";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(306, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 81;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ventaIdText
            // 
            this.ventaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.ventaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaIdText.Location = new System.Drawing.Point(117, 89);
            this.ventaIdText.Name = "ventaIdText";
            this.ventaIdText.Size = new System.Drawing.Size(183, 26);
            this.ventaIdText.TabIndex = 80;
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteLabel.Location = new System.Drawing.Point(114, 57);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(127, 20);
            this.clienteLabel.TabIndex = 79;
            this.clienteLabel.Text = "nombre cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Suplidor";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(306, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 74;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // clienteIdText
            // 
            this.clienteIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.clienteIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteIdText.Location = new System.Drawing.Point(117, 17);
            this.clienteIdText.Name = "clienteIdText";
            this.clienteIdText.Size = new System.Drawing.Size(183, 26);
            this.clienteIdText.TabIndex = 71;
            // 
            // ventana_reporte_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 602);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_reporte_pagos";
            this.Text = "ventana_reporte_pagos";
            this.Load += new System.EventHandler(this.ventana_reporte_pagos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBoxSoloComprasPagadas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox fechaFinalVentaText;
        private System.Windows.Forms.MaskedTextBox fechaInicialVentaText;
        private System.Windows.Forms.CheckBox checkBoxIncluirRangoFechaVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tipoVentaComboBox;
        private System.Windows.Forms.Label ventaLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox ventaIdText;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox clienteIdText;


    }
}