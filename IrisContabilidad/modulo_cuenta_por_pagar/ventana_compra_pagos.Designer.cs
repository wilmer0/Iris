namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    partial class ventana_compra_pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_compra_pagos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.metodoPagoComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.montoAbonoText = new System.Windows.Forms.TextBox();
            this.totalPendienteText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.totalAbonadoText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.montoDescuentoText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idPrductoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasVencimientoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroComprobanteFiscalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLimiteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoPendienteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAbonoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metoopagoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDescontadoText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 594);
            this.panel1.Size = new System.Drawing.Size(1089, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(948, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1113, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(474, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.suplidorText);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 97);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Suplidor";
            // 
            // suplidorText
            // 
            this.suplidorText.BackColor = System.Drawing.Color.White;
            this.suplidorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorText.Location = new System.Drawing.Point(96, 54);
            this.suplidorText.MaxLength = 200;
            this.suplidorText.Name = "suplidorText";
            this.suplidorText.ReadOnly = true;
            this.suplidorText.Size = new System.Drawing.Size(236, 26);
            this.suplidorText.TabIndex = 77;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(285, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 74;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(96, 17);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(183, 26);
            this.suplidorIdText.TabIndex = 71;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
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
            this.idPrductoColumn,
            this.fechaColumn,
            this.diasVencimientoColumn,
            this.empleadoColumn,
            this.TipoCompraColumn,
            this.numeroComprobanteFiscalColumn,
            this.FechaLimiteColumn,
            this.MontoPendienteColumn,
            this.MontoAbonoColumn,
            this.Column1,
            this.metoopagoColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1087, 338);
            this.dataGridView1.TabIndex = 88;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // button19
            // 
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(1034, 130);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(64, 58);
            this.button19.TabIndex = 103;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(963, 130);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 58);
            this.button20.TabIndex = 102;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            this.button20.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button20_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "Metodo pago";
            // 
            // metodoPagoComboBox
            // 
            this.metodoPagoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.metodoPagoComboBox.FormattingEnabled = true;
            this.metodoPagoComboBox.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito",
            "Cheque"});
            this.metodoPagoComboBox.Location = new System.Drawing.Point(132, 167);
            this.metodoPagoComboBox.Name = "metodoPagoComboBox";
            this.metodoPagoComboBox.Size = new System.Drawing.Size(189, 21);
            this.metodoPagoComboBox.TabIndex = 104;
            this.metodoPagoComboBox.Tag = "";
            this.metodoPagoComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metodoPagoComboBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 106;
            this.label3.Text = "Monto pago";
            // 
            // montoAbonoText
            // 
            this.montoAbonoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoAbonoText.Location = new System.Drawing.Point(462, 160);
            this.montoAbonoText.Name = "montoAbonoText";
            this.montoAbonoText.Size = new System.Drawing.Size(154, 26);
            this.montoAbonoText.TabIndex = 107;
            this.montoAbonoText.Text = "0.00";
            this.montoAbonoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoAbonoText_KeyDown);
            this.montoAbonoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoAbonoText_KeyPress);
            // 
            // totalPendienteText
            // 
            this.totalPendienteText.BackColor = System.Drawing.Color.SkyBlue;
            this.totalPendienteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPendienteText.Location = new System.Drawing.Point(245, 538);
            this.totalPendienteText.MaxLength = 200;
            this.totalPendienteText.Name = "totalPendienteText";
            this.totalPendienteText.ReadOnly = true;
            this.totalPendienteText.Size = new System.Drawing.Size(193, 38);
            this.totalPendienteText.TabIndex = 109;
            this.totalPendienteText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(104, 545);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 20);
            this.label14.TabIndex = 108;
            this.label14.Text = "Total pendiente";
            // 
            // totalAbonadoText
            // 
            this.totalAbonadoText.BackColor = System.Drawing.Color.SkyBlue;
            this.totalAbonadoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAbonadoText.Location = new System.Drawing.Point(905, 538);
            this.totalAbonadoText.MaxLength = 200;
            this.totalAbonadoText.Name = "totalAbonadoText";
            this.totalAbonadoText.ReadOnly = true;
            this.totalAbonadoText.Size = new System.Drawing.Size(193, 38);
            this.totalAbonadoText.TabIndex = 111;
            this.totalAbonadoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(775, 545);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 110;
            this.label4.Text = "Total abonado";
            // 
            // montoDescuentoText
            // 
            this.montoDescuentoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoDescuentoText.Location = new System.Drawing.Point(760, 160);
            this.montoDescuentoText.Name = "montoDescuentoText";
            this.montoDescuentoText.Size = new System.Drawing.Size(154, 26);
            this.montoDescuentoText.TabIndex = 115;
            this.montoDescuentoText.Text = "0.00";
            this.montoDescuentoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoDescuentoText_KeyDown);
            this.montoDescuentoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoDescuentoText_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(658, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 114;
            this.label5.Text = "Descuento";
            // 
            // idPrductoColumn
            // 
            this.idPrductoColumn.FillWeight = 50F;
            this.idPrductoColumn.HeaderText = "ID";
            this.idPrductoColumn.Name = "idPrductoColumn";
            this.idPrductoColumn.ReadOnly = true;
            // 
            // fechaColumn
            // 
            this.fechaColumn.FillWeight = 70F;
            this.fechaColumn.HeaderText = "Fecha";
            this.fechaColumn.Name = "fechaColumn";
            this.fechaColumn.ReadOnly = true;
            // 
            // diasVencimientoColumn
            // 
            this.diasVencimientoColumn.FillWeight = 70F;
            this.diasVencimientoColumn.HeaderText = "Dias ven.";
            this.diasVencimientoColumn.Name = "diasVencimientoColumn";
            this.diasVencimientoColumn.ReadOnly = true;
            // 
            // empleadoColumn
            // 
            this.empleadoColumn.FillWeight = 120F;
            this.empleadoColumn.HeaderText = "Empleado";
            this.empleadoColumn.Name = "empleadoColumn";
            this.empleadoColumn.ReadOnly = true;
            // 
            // TipoCompraColumn
            // 
            this.TipoCompraColumn.FillWeight = 80F;
            this.TipoCompraColumn.HeaderText = "Tipo compra";
            this.TipoCompraColumn.Name = "TipoCompraColumn";
            this.TipoCompraColumn.ReadOnly = true;
            // 
            // numeroComprobanteFiscalColumn
            // 
            this.numeroComprobanteFiscalColumn.FillWeight = 120F;
            this.numeroComprobanteFiscalColumn.HeaderText = "NCF";
            this.numeroComprobanteFiscalColumn.Name = "numeroComprobanteFiscalColumn";
            this.numeroComprobanteFiscalColumn.ReadOnly = true;
            // 
            // FechaLimiteColumn
            // 
            this.FechaLimiteColumn.FillWeight = 70F;
            this.FechaLimiteColumn.HeaderText = "Fecha limite";
            this.FechaLimiteColumn.Name = "FechaLimiteColumn";
            this.FechaLimiteColumn.ReadOnly = true;
            // 
            // MontoPendienteColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.MontoPendienteColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.MontoPendienteColumn.FillWeight = 80F;
            this.MontoPendienteColumn.HeaderText = "Pendiente";
            this.MontoPendienteColumn.Name = "MontoPendienteColumn";
            this.MontoPendienteColumn.ReadOnly = true;
            // 
            // MontoAbonoColumn
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.MontoAbonoColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.MontoAbonoColumn.FillWeight = 80F;
            this.MontoAbonoColumn.HeaderText = "Abonar";
            this.MontoAbonoColumn.Name = "MontoAbonoColumn";
            this.MontoAbonoColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "Descuento";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // metoopagoColumn
            // 
            this.metoopagoColumn.FillWeight = 80F;
            this.metoopagoColumn.HeaderText = "Metodo pago";
            this.metoopagoColumn.Name = "metoopagoColumn";
            this.metoopagoColumn.ReadOnly = true;
            // 
            // totalDescontadoText
            // 
            this.totalDescontadoText.BackColor = System.Drawing.Color.SkyBlue;
            this.totalDescontadoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDescontadoText.Location = new System.Drawing.Point(588, 538);
            this.totalDescontadoText.MaxLength = 200;
            this.totalDescontadoText.Name = "totalDescontadoText";
            this.totalDescontadoText.ReadOnly = true;
            this.totalDescontadoText.Size = new System.Drawing.Size(181, 38);
            this.totalDescontadoText.TabIndex = 117;
            this.totalDescontadoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(444, 545);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 116;
            this.label6.Text = "Total descuento";
            // 
            // ventana_compra_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 660);
            this.Controls.Add(this.totalDescontadoText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.montoDescuentoText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalAbonadoText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalPendienteText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.montoAbonoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metodoPagoComboBox);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_compra_pagos";
            this.Text = "ventana_compra_pagos";
            this.Load += new System.EventHandler(this.ventana_compra_pagos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ventana_compra_pagos_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.button20, 0);
            this.Controls.SetChildIndex(this.button19, 0);
            this.Controls.SetChildIndex(this.metodoPagoComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.montoAbonoText, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.totalPendienteText, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.totalAbonadoText, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.montoDescuentoText, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.totalDescontadoText, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox suplidorText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox suplidorIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox metodoPagoComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox montoAbonoText;
        private System.Windows.Forms.TextBox totalPendienteText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox totalAbonadoText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox montoDescuentoText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrductoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasVencimientoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCompraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroComprobanteFiscalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLimiteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoPendienteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAbonoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn metoopagoColumn;
        private System.Windows.Forms.TextBox totalDescontadoText;
        private System.Windows.Forms.Label label6;
    }
}