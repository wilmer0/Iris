namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    partial class ventana_consulta_compra_pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_consulta_compra_pagos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPagoCOlumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meotodopagodetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoPagagoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metodoPagoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.empleadoText = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.empleadoIdText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeroCompraText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.CompraIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 528);
            this.panel1.Size = new System.Drawing.Size(918, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(777, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(942, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(389, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.idPagoCOlumn,
            this.fechaColumn,
            this.EmpleadoColumn,
            this.meotodopagodetalle,
            this.codigoCompraColumn,
            this.montoPagagoColumn});
            this.dataGridView1.Location = new System.Drawing.Point(16, 232);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(914, 284);
            this.dataGridView1.TabIndex = 110;
            // 
            // idPagoCOlumn
            // 
            this.idPagoCOlumn.FillWeight = 20.24034F;
            this.idPagoCOlumn.HeaderText = "ID Pago";
            this.idPagoCOlumn.Name = "idPagoCOlumn";
            this.idPagoCOlumn.ReadOnly = true;
            // 
            // fechaColumn
            // 
            this.fechaColumn.FillWeight = 26.98712F;
            this.fechaColumn.HeaderText = "Fecha";
            this.fechaColumn.Name = "fechaColumn";
            this.fechaColumn.ReadOnly = true;
            // 
            // EmpleadoColumn
            // 
            this.EmpleadoColumn.FillWeight = 67.4678F;
            this.EmpleadoColumn.HeaderText = "Empleado";
            this.EmpleadoColumn.Name = "EmpleadoColumn";
            this.EmpleadoColumn.ReadOnly = true;
            // 
            // meotodopagodetalle
            // 
            this.meotodopagodetalle.FillWeight = 67.4678F;
            this.meotodopagodetalle.HeaderText = "Metodo Pago";
            this.meotodopagodetalle.Name = "meotodopagodetalle";
            this.meotodopagodetalle.ReadOnly = true;
            // 
            // codigoCompraColumn
            // 
            this.codigoCompraColumn.FillWeight = 32.7239F;
            this.codigoCompraColumn.HeaderText = "ID Compra";
            this.codigoCompraColumn.Name = "codigoCompraColumn";
            this.codigoCompraColumn.ReadOnly = true;
            // 
            // montoPagagoColumn
            // 
            this.montoPagagoColumn.FillWeight = 38.60244F;
            this.montoPagagoColumn.HeaderText = "Monto Pagado";
            this.montoPagagoColumn.Name = "montoPagagoColumn";
            this.montoPagagoColumn.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 114;
            this.label2.Text = "Suplidor";
            // 
            // suplidorText
            // 
            this.suplidorText.BackColor = System.Drawing.Color.White;
            this.suplidorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorText.Location = new System.Drawing.Point(130, 50);
            this.suplidorText.MaxLength = 200;
            this.suplidorText.Name = "suplidorText";
            this.suplidorText.ReadOnly = true;
            this.suplidorText.Size = new System.Drawing.Size(236, 26);
            this.suplidorText.TabIndex = 113;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(319, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 112;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(130, 13);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(183, 26);
            this.suplidorIdText.TabIndex = 111;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metodoPagoComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.empleadoText);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.empleadoIdText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numeroCompraText);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.CompraIdText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.suplidorText);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Location = new System.Drawing.Point(16, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 198);
            this.groupBox1.TabIndex = 119;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // metodoPagoComboBox
            // 
            this.metodoPagoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metodoPagoComboBox.FormattingEnabled = true;
            this.metodoPagoComboBox.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito",
            "Cheque"});
            this.metodoPagoComboBox.Location = new System.Drawing.Point(130, 166);
            this.metodoPagoComboBox.Name = "metodoPagoComboBox";
            this.metodoPagoComboBox.Size = new System.Drawing.Size(236, 21);
            this.metodoPagoComboBox.TabIndex = 131;
            this.metodoPagoComboBox.Tag = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(420, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 130;
            this.label6.Text = "Empleado";
            // 
            // empleadoText
            // 
            this.empleadoText.BackColor = System.Drawing.Color.White;
            this.empleadoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empleadoText.Location = new System.Drawing.Point(515, 50);
            this.empleadoText.MaxLength = 200;
            this.empleadoText.Name = "empleadoText";
            this.empleadoText.ReadOnly = true;
            this.empleadoText.Size = new System.Drawing.Size(236, 26);
            this.empleadoText.TabIndex = 129;
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(704, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 128;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // empleadoIdText
            // 
            this.empleadoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.empleadoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empleadoIdText.Location = new System.Drawing.Point(515, 13);
            this.empleadoIdText.Name = "empleadoIdText";
            this.empleadoIdText.Size = new System.Drawing.Size(183, 26);
            this.empleadoIdText.TabIndex = 127;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 126;
            this.label5.Text = "Metodo pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 122;
            this.label4.Text = "Compra";
            // 
            // numeroCompraText
            // 
            this.numeroCompraText.BackColor = System.Drawing.Color.White;
            this.numeroCompraText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCompraText.Location = new System.Drawing.Point(130, 125);
            this.numeroCompraText.MaxLength = 200;
            this.numeroCompraText.Name = "numeroCompraText";
            this.numeroCompraText.ReadOnly = true;
            this.numeroCompraText.Size = new System.Drawing.Size(236, 26);
            this.numeroCompraText.TabIndex = 121;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(319, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 120;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CompraIdText
            // 
            this.CompraIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.CompraIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompraIdText.Location = new System.Drawing.Point(130, 88);
            this.CompraIdText.Name = "CompraIdText";
            this.CompraIdText.Size = new System.Drawing.Size(183, 26);
            this.CompraIdText.TabIndex = 119;
            // 
            // ventana_consulta_compra_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 594);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ventana_consulta_compra_pagos";
            this.Text = "ventana_consulta_compra_pagos";
            this.Load += new System.EventHandler(this.ventana_consulta_compra_pagos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox suplidorText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox suplidorIdText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numeroCompraText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox CompraIdText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox empleadoText;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox empleadoIdText;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPagoCOlumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meotodopagodetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCompraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoPagagoColumn;
        private System.Windows.Forms.ComboBox metodoPagoComboBox;
    }
}