namespace IrisContabilidad.modulo_facturacion
{
    partial class ventana_busqueda_nota_credito_cxc
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioMonto = new System.Windows.Forms.RadioButton();
            this.radioConcepto = new System.Windows.Forms.RadioButton();
            this.radioCajero = new System.Windows.Forms.RadioButton();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cajerocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioNCFVenta = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 404);
            this.panel1.Size = new System.Drawing.Size(754, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(613, 5);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(778, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(307, 5);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNCFVenta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioMonto);
            this.groupBox1.Controls.Add(this.radioConcepto);
            this.groupBox1.Controls.Add(this.radioCajero);
            this.groupBox1.Controls.Add(this.radioTodos);
            this.groupBox1.Controls.Add(this.nombreText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 87);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Cambiar(F2)";
            // 
            // radioMonto
            // 
            this.radioMonto.AutoSize = true;
            this.radioMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMonto.Location = new System.Drawing.Point(366, 51);
            this.radioMonto.Name = "radioMonto";
            this.radioMonto.Size = new System.Drawing.Size(70, 21);
            this.radioMonto.TabIndex = 24;
            this.radioMonto.Text = "Monto";
            this.radioMonto.UseVisualStyleBackColor = true;
            // 
            // radioConcepto
            // 
            this.radioConcepto.AutoSize = true;
            this.radioConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioConcepto.Location = new System.Drawing.Point(258, 51);
            this.radioConcepto.Name = "radioConcepto";
            this.radioConcepto.Size = new System.Drawing.Size(94, 21);
            this.radioConcepto.TabIndex = 23;
            this.radioConcepto.Text = "Concepto";
            this.radioConcepto.UseVisualStyleBackColor = true;
            // 
            // radioCajero
            // 
            this.radioCajero.AutoSize = true;
            this.radioCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCajero.Location = new System.Drawing.Point(171, 51);
            this.radioCajero.Name = "radioCajero";
            this.radioCajero.Size = new System.Drawing.Size(76, 21);
            this.radioCajero.TabIndex = 22;
            this.radioCajero.Text = "Cliente";
            this.radioCajero.UseVisualStyleBackColor = true;
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.Checked = true;
            this.radioTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTodos.Location = new System.Drawing.Point(81, 51);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(71, 21);
            this.radioTodos.TabIndex = 21;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "Todos";
            this.radioTodos.UseVisualStyleBackColor = true;
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(81, 19);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(396, 26);
            this.nombreText.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Buscar";
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
            this.codigoColumn,
            this.FechaColumn,
            this.conceptoColumn,
            this.Cajerocolumn,
            this.MontoColumn});
            this.dataGridView1.Location = new System.Drawing.Point(15, 131);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 255);
            this.dataGridView1.TabIndex = 30;
            // 
            // codigoColumn
            // 
            this.codigoColumn.FillWeight = 20F;
            this.codigoColumn.HeaderText = "Id";
            this.codigoColumn.Name = "codigoColumn";
            this.codigoColumn.ReadOnly = true;
            // 
            // FechaColumn
            // 
            this.FechaColumn.HeaderText = "Fecha";
            this.FechaColumn.Name = "FechaColumn";
            this.FechaColumn.ReadOnly = true;
            // 
            // conceptoColumn
            // 
            this.conceptoColumn.HeaderText = "Concepto";
            this.conceptoColumn.Name = "conceptoColumn";
            this.conceptoColumn.ReadOnly = true;
            // 
            // Cajerocolumn
            // 
            this.Cajerocolumn.HeaderText = "Cajero";
            this.Cajerocolumn.Name = "Cajerocolumn";
            this.Cajerocolumn.ReadOnly = true;
            // 
            // MontoColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.MontoColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.MontoColumn.HeaderText = "Monto";
            this.MontoColumn.Name = "MontoColumn";
            this.MontoColumn.ReadOnly = true;
            // 
            // radioNCFVenta
            // 
            this.radioNCFVenta.AutoSize = true;
            this.radioNCFVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNCFVenta.Location = new System.Drawing.Point(454, 51);
            this.radioNCFVenta.Name = "radioNCFVenta";
            this.radioNCFVenta.Size = new System.Drawing.Size(97, 21);
            this.radioNCFVenta.TabIndex = 26;
            this.radioNCFVenta.Text = "Ncf Venta";
            this.radioNCFVenta.UseVisualStyleBackColor = true;
            // 
            // ventana_busqueda_nota_credito_cxc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ventana_busqueda_nota_credito_cxc";
            this.Text = "ventana_busqueda_nota_credito_cxc";
            this.Load += new System.EventHandler(this.ventana_busqueda_nota_credito_cxc_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioMonto;
        private System.Windows.Forms.RadioButton radioConcepto;
        private System.Windows.Forms.RadioButton radioCajero;
        private System.Windows.Forms.RadioButton radioTodos;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajerocolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoColumn;
        private System.Windows.Forms.RadioButton radioNCFVenta;
    }
}