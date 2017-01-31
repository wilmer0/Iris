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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPrductoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroComprobanteFiscalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLimiteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoPendienteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAbonoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoCompraComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 594);
            this.panel1.Size = new System.Drawing.Size(1043, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(902, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1067, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(451, 5);
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
            this.groupBox1.Size = new System.Drawing.Size(1040, 97);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
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
            this.numerCompraColumn,
            this.fechaColumn,
            this.empleadoColumn,
            this.TipoCompraColumn,
            this.numeroComprobanteFiscalColumn,
            this.FechaLimiteColumn,
            this.MontoPendienteColumn,
            this.MontoAbonoColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 194);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 394);
            this.dataGridView1.TabIndex = 88;
            // 
            // idPrductoColumn
            // 
            this.idPrductoColumn.FillWeight = 50F;
            this.idPrductoColumn.HeaderText = "ID";
            this.idPrductoColumn.Name = "idPrductoColumn";
            this.idPrductoColumn.ReadOnly = true;
            // 
            // numerCompraColumn
            // 
            this.numerCompraColumn.FillWeight = 70F;
            this.numerCompraColumn.HeaderText = "# Compra";
            this.numerCompraColumn.Name = "numerCompraColumn";
            this.numerCompraColumn.ReadOnly = true;
            // 
            // fechaColumn
            // 
            this.fechaColumn.FillWeight = 70F;
            this.fechaColumn.HeaderText = "Fecha";
            this.fechaColumn.Name = "fechaColumn";
            this.fechaColumn.ReadOnly = true;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.MontoPendienteColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.MontoPendienteColumn.HeaderText = "Pendiente";
            this.MontoPendienteColumn.Name = "MontoPendienteColumn";
            this.MontoPendienteColumn.ReadOnly = true;
            // 
            // MontoAbonoColumn
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.MontoAbonoColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.MontoAbonoColumn.HeaderText = "Abonar";
            this.MontoAbonoColumn.Name = "MontoAbonoColumn";
            this.MontoAbonoColumn.ReadOnly = true;
            // 
            // button19
            // 
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(988, 130);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(64, 58);
            this.button19.TabIndex = 103;
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(917, 130);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 58);
            this.button20.TabIndex = 102;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "Metodo pago";
            // 
            // tipoCompraComboBox
            // 
            this.tipoCompraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoCompraComboBox.FormattingEnabled = true;
            this.tipoCompraComboBox.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito",
            "Cheque"});
            this.tipoCompraComboBox.Location = new System.Drawing.Point(139, 150);
            this.tipoCompraComboBox.Name = "tipoCompraComboBox";
            this.tipoCompraComboBox.Size = new System.Drawing.Size(189, 21);
            this.tipoCompraComboBox.TabIndex = 104;
            this.tipoCompraComboBox.Tag = "";
            // 
            // ventana_compra_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 660);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipoCompraComboBox);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_compra_pagos";
            this.Text = "ventana_compra_pagos";
            this.Load += new System.EventHandler(this.ventana_compra_pagos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.button20, 0);
            this.Controls.SetChildIndex(this.button19, 0);
            this.Controls.SetChildIndex(this.tipoCompraComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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
        private System.Windows.Forms.ComboBox tipoCompraComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrductoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerCompraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCompraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroComprobanteFiscalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLimiteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoPendienteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoAbonoColumn;
    }
}