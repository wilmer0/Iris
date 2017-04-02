namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    partial class ventana_anular_cobros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_anular_cobros));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clienteText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.clienteIdText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPrductoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meotodocobrodetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoventacolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anularCobroColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.motivoAnularText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 546);
            this.panel1.Size = new System.Drawing.Size(917, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(776, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(941, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(388, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.clienteText);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.clienteIdText);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 88);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "Cliente";
            // 
            // clienteText
            // 
            this.clienteText.BackColor = System.Drawing.Color.White;
            this.clienteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteText.Location = new System.Drawing.Point(96, 54);
            this.clienteText.MaxLength = 200;
            this.clienteText.Name = "clienteText";
            this.clienteText.ReadOnly = true;
            this.clienteText.Size = new System.Drawing.Size(236, 26);
            this.clienteText.TabIndex = 77;
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
            // clienteIdText
            // 
            this.clienteIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.clienteIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteIdText.Location = new System.Drawing.Point(96, 17);
            this.clienteIdText.Name = "clienteIdText";
            this.clienteIdText.Size = new System.Drawing.Size(183, 26);
            this.clienteIdText.TabIndex = 71;
            this.clienteIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clienteIdText_KeyDown);
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
            this.EmpleadoColumn,
            this.meotodocobrodetalle,
            this.Column1,
            this.Column2,
            this.codigoventacolumn,
            this.anularCobroColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 206);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(914, 331);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // idPrductoColumn
            // 
            this.idPrductoColumn.FillWeight = 30F;
            this.idPrductoColumn.HeaderText = "ID";
            this.idPrductoColumn.Name = "idPrductoColumn";
            this.idPrductoColumn.ReadOnly = true;
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
            // meotodocobrodetalle
            // 
            this.meotodocobrodetalle.FillWeight = 70F;
            this.meotodocobrodetalle.HeaderText = "Metodo Cobro";
            this.meotodocobrodetalle.Name = "meotodocobrodetalle";
            this.meotodocobrodetalle.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "Monto Cobro";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "Monto Descuento";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // codigoventacolumn
            // 
            this.codigoventacolumn.FillWeight = 60F;
            this.codigoventacolumn.HeaderText = "ID Venta";
            this.codigoventacolumn.Name = "codigoventacolumn";
            this.codigoventacolumn.ReadOnly = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 105;
            this.label1.Text = "Motivo anular";
            // 
            // motivoAnularText
            // 
            this.motivoAnularText.Location = new System.Drawing.Point(12, 141);
            this.motivoAnularText.MaxLength = 500;
            this.motivoAnularText.Multiline = true;
            this.motivoAnularText.Name = "motivoAnularText";
            this.motivoAnularText.Size = new System.Drawing.Size(432, 59);
            this.motivoAnularText.TabIndex = 106;
            // 
            // ventana_anular_cobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 612);
            this.Controls.Add(this.motivoAnularText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_anular_cobros";
            this.Text = "ventana_anular_cobros";
            this.Load += new System.EventHandler(this.ventana_anular_cobros_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.motivoAnularText, 0);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clienteText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox clienteIdText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox motivoAnularText;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPrductoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meotodocobrodetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoventacolumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anularCobroColumn;
    }
}