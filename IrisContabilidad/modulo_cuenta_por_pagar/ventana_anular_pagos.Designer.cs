namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    partial class ventana_anular_pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_anular_pagos));
            this.motivoAnularText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPagoCOlumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meotodopagodetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anularCobroColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 609);
            this.panel1.Size = new System.Drawing.Size(919, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(778, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(943, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(389, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // motivoAnularText
            // 
            this.motivoAnularText.Location = new System.Drawing.Point(14, 141);
            this.motivoAnularText.MaxLength = 500;
            this.motivoAnularText.Multiline = true;
            this.motivoAnularText.Name = "motivoAnularText";
            this.motivoAnularText.Size = new System.Drawing.Size(432, 59);
            this.motivoAnularText.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "Motivo anular";
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
            this.anularCobroColumn});
            this.dataGridView1.Location = new System.Drawing.Point(14, 206);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(914, 386);
            this.dataGridView1.TabIndex = 109;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // idPagoCOlumn
            // 
            this.idPagoCOlumn.FillWeight = 30F;
            this.idPagoCOlumn.HeaderText = "ID Pago";
            this.idPagoCOlumn.Name = "idPagoCOlumn";
            this.idPagoCOlumn.ReadOnly = true;
            // 
            // fechaColumn
            // 
            this.fechaColumn.FillWeight = 40F;
            this.fechaColumn.HeaderText = "Fecha";
            this.fechaColumn.Name = "fechaColumn";
            this.fechaColumn.ReadOnly = true;
            // 
            // EmpleadoColumn
            // 
            this.EmpleadoColumn.HeaderText = "Empleado";
            this.EmpleadoColumn.Name = "EmpleadoColumn";
            this.EmpleadoColumn.ReadOnly = true;
            // 
            // meotodopagodetalle
            // 
            this.meotodopagodetalle.HeaderText = "Metodo Pago";
            this.meotodopagodetalle.Name = "meotodopagodetalle";
            this.meotodopagodetalle.ReadOnly = true;
            // 
            // codigoCompraColumn
            // 
            this.codigoCompraColumn.FillWeight = 60F;
            this.codigoCompraColumn.HeaderText = "ID Compra";
            this.codigoCompraColumn.Name = "codigoCompraColumn";
            this.codigoCompraColumn.ReadOnly = true;
            // 
            // anularCobroColumn
            // 
            this.anularCobroColumn.FalseValue = "";
            this.anularCobroColumn.FillWeight = 25F;
            this.anularCobroColumn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.anularCobroColumn.HeaderText = "Anular";
            this.anularCobroColumn.Name = "anularCobroColumn";
            this.anularCobroColumn.ReadOnly = true;
            this.anularCobroColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.anularCobroColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.anularCobroColumn.ToolTipText = "seleccionar si desea anular este cobro";
            this.anularCobroColumn.TrueValue = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.suplidorText);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Location = new System.Drawing.Point(14, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 88);
            this.groupBox1.TabIndex = 107;
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
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clienteIdText_KeyDown);
            // 
            // ventana_anular_pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 675);
            this.Controls.Add(this.motivoAnularText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_anular_pagos";
            this.Text = "ventana_anular_pagos";
            this.Load += new System.EventHandler(this.ventana_anular_pagos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.motivoAnularText, 0);
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

        private System.Windows.Forms.TextBox motivoAnularText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox suplidorText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox suplidorIdText;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPagoCOlumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meotodopagodetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCompraColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anularCobroColumn;
    }
}