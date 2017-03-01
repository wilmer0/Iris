namespace IrisContabilidad.modulo_inventario
{
    partial class ventana_producto_lista_precio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_producto_lista_precio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.productoIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.productoLabel = new System.Windows.Forms.Label();
            this.secuenciacolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rncColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 558);
            this.panel1.Size = new System.Drawing.Size(900, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(759, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(924, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(380, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.productoIdText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(897, 59);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            // 
            // productoIdText
            // 
            this.productoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.productoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoIdText.Location = new System.Drawing.Point(121, 19);
            this.productoIdText.Name = "productoIdText";
            this.productoIdText.Size = new System.Drawing.Size(155, 26);
            this.productoIdText.TabIndex = 25;
            this.productoIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productoIdText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Producto";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(280, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 26;
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 153);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(897, 399);
            this.dataGridView1.TabIndex = 98;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(843, 92);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 55);
            this.button5.TabIndex = 27;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // productoLabel
            // 
            this.productoLabel.AutoSize = true;
            this.productoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoLabel.Location = new System.Drawing.Point(129, 92);
            this.productoLabel.Name = "productoLabel";
            this.productoLabel.Size = new System.Drawing.Size(80, 20);
            this.productoLabel.TabIndex = 27;
            this.productoLabel.Text = "producto";
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
            // Column1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "Precio 1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.Format = "N2";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Precio 2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle8.Format = "N2";
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "Precio 3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle9.Format = "N2";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column4.HeaderText = "Precio 4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle10.Format = "N2";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column5.HeaderText = "Precio 5";
            this.Column5.Name = "Column5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(772, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 99;
            this.label1.Text = "Buscar";
            // 
            // ventana_producto_lista_precio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 624);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productoLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ventana_producto_lista_precio";
            this.Text = "ventana_producto_lista_precio";
            this.Load += new System.EventHandler(this.ventana_producto_lista_precio_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.productoLabel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox productoIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label productoLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn secuenciacolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rncColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label1;
    }
}