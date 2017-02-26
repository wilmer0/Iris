namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    partial class ventana_venta_devolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_venta_devolucion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.categoriaIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.secuenciacolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rncColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labl1 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.tipoVentaLabel = new System.Windows.Forms.Label();
            this.ncfLabel = new System.Windows.Forms.Label();
            this.cantidadDevolverText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 593);
            this.panel1.Size = new System.Drawing.Size(911, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(770, 5);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(935, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(385, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.categoriaIdText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(908, 59);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            // 
            // categoriaIdText
            // 
            this.categoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.categoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaIdText.Location = new System.Drawing.Point(121, 19);
            this.categoriaIdText.Name = "categoriaIdText";
            this.categoriaIdText.Size = new System.Drawing.Size(155, 26);
            this.categoriaIdText.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Venta";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(280, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 23;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.secuenciacolumn,
            this.cedulaColumn,
            this.rncColumn,
            this.categoriaColumn,
            this.telefonoColumn,
            this.activoColumn,
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(16, 166);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(904, 421);
            this.dataGridView1.TabIndex = 87;
            // 
            // secuenciacolumn
            // 
            this.secuenciacolumn.FillWeight = 30F;
            this.secuenciacolumn.HeaderText = "ID";
            this.secuenciacolumn.Name = "secuenciacolumn";
            this.secuenciacolumn.ReadOnly = true;
            // 
            // cedulaColumn
            // 
            this.cedulaColumn.HeaderText = "Producto";
            this.cedulaColumn.Name = "cedulaColumn";
            this.cedulaColumn.ReadOnly = true;
            // 
            // rncColumn
            // 
            this.rncColumn.FillWeight = 30F;
            this.rncColumn.HeaderText = "ID";
            this.rncColumn.Name = "rncColumn";
            this.rncColumn.ReadOnly = true;
            // 
            // categoriaColumn
            // 
            this.categoriaColumn.HeaderText = "Unidad";
            this.categoriaColumn.Name = "categoriaColumn";
            this.categoriaColumn.ReadOnly = true;
            // 
            // telefonoColumn
            // 
            this.telefonoColumn.FillWeight = 50F;
            this.telefonoColumn.HeaderText = "Cantidad";
            this.telefonoColumn.Name = "telefonoColumn";
            this.telefonoColumn.ReadOnly = true;
            // 
            // activoColumn
            // 
            this.activoColumn.FillWeight = 50F;
            this.activoColumn.HeaderText = "Precio";
            this.activoColumn.Name = "activoColumn";
            this.activoColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 40F;
            this.Column2.HeaderText = "Devolver";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // labl1
            // 
            this.labl1.AutoSize = true;
            this.labl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl1.Location = new System.Drawing.Point(12, 89);
            this.labl1.Name = "labl1";
            this.labl1.Size = new System.Drawing.Size(75, 20);
            this.labl1.TabIndex = 88;
            this.labl1.Text = "Cliente.:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(34, 110);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 20);
            this.lbl3.TabIndex = 90;
            this.lbl3.Text = "Tipo.:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(33, 132);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(54, 20);
            this.lbl4.TabIndex = 92;
            this.lbl4.Text = "NCF.:";
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteLabel.Location = new System.Drawing.Point(84, 89);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(14, 20);
            this.clienteLabel.TabIndex = 93;
            this.clienteLabel.Text = ".";
            // 
            // tipoVentaLabel
            // 
            this.tipoVentaLabel.AutoSize = true;
            this.tipoVentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoVentaLabel.Location = new System.Drawing.Point(84, 110);
            this.tipoVentaLabel.Name = "tipoVentaLabel";
            this.tipoVentaLabel.Size = new System.Drawing.Size(14, 20);
            this.tipoVentaLabel.TabIndex = 94;
            this.tipoVentaLabel.Text = ".";
            // 
            // ncfLabel
            // 
            this.ncfLabel.AutoSize = true;
            this.ncfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncfLabel.Location = new System.Drawing.Point(84, 132);
            this.ncfLabel.Name = "ncfLabel";
            this.ncfLabel.Size = new System.Drawing.Size(14, 20);
            this.ncfLabel.TabIndex = 95;
            this.ncfLabel.Text = ".";
            // 
            // cantidadDevolverText
            // 
            this.cantidadDevolverText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadDevolverText.Location = new System.Drawing.Point(589, 134);
            this.cantidadDevolverText.Name = "cantidadDevolverText";
            this.cantidadDevolverText.Size = new System.Drawing.Size(176, 26);
            this.cantidadDevolverText.TabIndex = 109;
            this.cantidadDevolverText.Text = "0.00";
            this.cantidadDevolverText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadDevolverText_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 108;
            this.label3.Text = "Cantidad devolver";
            // 
            // button19
            // 
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(856, 102);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(64, 58);
            this.button19.TabIndex = 111;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(785, 102);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 58);
            this.button20.TabIndex = 110;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // ventana_venta_devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 659);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.cantidadDevolverText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ncfLabel);
            this.Controls.Add(this.tipoVentaLabel);
            this.Controls.Add(this.clienteLabel);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.labl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_venta_devolucion";
            this.Text = "ventana_venta_devolucion";
            this.Load += new System.EventHandler(this.ventana_venta_devolucion_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.labl1, 0);
            this.Controls.SetChildIndex(this.lbl3, 0);
            this.Controls.SetChildIndex(this.lbl4, 0);
            this.Controls.SetChildIndex(this.clienteLabel, 0);
            this.Controls.SetChildIndex(this.tipoVentaLabel, 0);
            this.Controls.SetChildIndex(this.ncfLabel, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cantidadDevolverText, 0);
            this.Controls.SetChildIndex(this.button20, 0);
            this.Controls.SetChildIndex(this.button19, 0);
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
        private System.Windows.Forms.TextBox categoriaIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labl1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.Label tipoVentaLabel;
        private System.Windows.Forms.Label ncfLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn secuenciacolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rncColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox cantidadDevolverText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
    }
}