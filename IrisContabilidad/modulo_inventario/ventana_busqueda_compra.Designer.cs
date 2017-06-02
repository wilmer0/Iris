using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_inventario
{
    partial class ventana_busqueda_compra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tipoCompraRadionButton = new System.Windows.Forms.RadioButton();
            this.ncfRadionButton = new System.Windows.Forms.RadioButton();
            this.suplidorRadioButton = new System.Windows.Forms.RadioButton();
            this.todoRadioButton = new System.Windows.Forms.RadioButton();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVenceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suplidorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncfColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadocolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroCompraRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 555);
            this.panel1.Size = new System.Drawing.Size(924, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(783, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(948, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(392, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numeroCompraRadioButton);
            this.groupBox1.Controls.Add(this.tipoCompraRadionButton);
            this.groupBox1.Controls.Add(this.ncfRadionButton);
            this.groupBox1.Controls.Add(this.suplidorRadioButton);
            this.groupBox1.Controls.Add(this.todoRadioButton);
            this.groupBox1.Controls.Add(this.nombreText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 108);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // tipoCompraRadionButton
            // 
            this.tipoCompraRadionButton.AutoSize = true;
            this.tipoCompraRadionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tipoCompraRadionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoCompraRadionButton.Location = new System.Drawing.Point(486, 64);
            this.tipoCompraRadionButton.Name = "tipoCompraRadionButton";
            this.tipoCompraRadionButton.Size = new System.Drawing.Size(117, 22);
            this.tipoCompraRadionButton.TabIndex = 24;
            this.tipoCompraRadionButton.TabStop = true;
            this.tipoCompraRadionButton.Text = "tipo compra";
            this.tipoCompraRadionButton.UseVisualStyleBackColor = true;
            // 
            // ncfRadionButton
            // 
            this.ncfRadionButton.AutoSize = true;
            this.ncfRadionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ncfRadionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncfRadionButton.Location = new System.Drawing.Point(397, 64);
            this.ncfRadionButton.Name = "ncfRadionButton";
            this.ncfRadionButton.Size = new System.Drawing.Size(62, 22);
            this.ncfRadionButton.TabIndex = 23;
            this.ncfRadionButton.TabStop = true;
            this.ncfRadionButton.Text = "NCF";
            this.ncfRadionButton.UseVisualStyleBackColor = true;
            // 
            // suplidorRadioButton
            // 
            this.suplidorRadioButton.AutoSize = true;
            this.suplidorRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.suplidorRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorRadioButton.Location = new System.Drawing.Point(283, 64);
            this.suplidorRadioButton.Name = "suplidorRadioButton";
            this.suplidorRadioButton.Size = new System.Drawing.Size(90, 22);
            this.suplidorRadioButton.TabIndex = 22;
            this.suplidorRadioButton.TabStop = true;
            this.suplidorRadioButton.Text = "suplidor";
            this.suplidorRadioButton.UseVisualStyleBackColor = true;
            // 
            // todoRadioButton
            // 
            this.todoRadioButton.AutoSize = true;
            this.todoRadioButton.Checked = true;
            this.todoRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.todoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todoRadioButton.Location = new System.Drawing.Point(84, 64);
            this.todoRadioButton.Name = "todoRadioButton";
            this.todoRadioButton.Size = new System.Drawing.Size(69, 22);
            this.todoRadioButton.TabIndex = 21;
            this.todoRadioButton.TabStop = true;
            this.todoRadioButton.Text = "Todo";
            this.todoRadioButton.UseVisualStyleBackColor = true;
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(81, 19);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(396, 26);
            this.nombreText.TabIndex = 20;
            this.nombreText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreText_KeyDown);
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
            this.fechaColumn,
            this.fechaVenceColumn,
            this.suplidorColumn,
            this.ncfColumn,
            this.tipocompraColumn,
            this.empleadocolumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 143);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(921, 397);
            this.dataGridView1.TabIndex = 30;
            // 
            // codigoColumn
            // 
            this.codigoColumn.FillWeight = 30F;
            this.codigoColumn.HeaderText = "Id";
            this.codigoColumn.Name = "codigoColumn";
            this.codigoColumn.ReadOnly = true;
            // 
            // fechaColumn
            // 
            this.fechaColumn.FillWeight = 70F;
            this.fechaColumn.HeaderText = "Fecha";
            this.fechaColumn.Name = "fechaColumn";
            this.fechaColumn.ReadOnly = true;
            // 
            // fechaVenceColumn
            // 
            this.fechaVenceColumn.FillWeight = 70F;
            this.fechaVenceColumn.HeaderText = "Vencimiento";
            this.fechaVenceColumn.Name = "fechaVenceColumn";
            this.fechaVenceColumn.ReadOnly = true;
            // 
            // suplidorColumn
            // 
            this.suplidorColumn.HeaderText = "Suplidor";
            this.suplidorColumn.Name = "suplidorColumn";
            this.suplidorColumn.ReadOnly = true;
            // 
            // ncfColumn
            // 
            this.ncfColumn.HeaderText = "NCF";
            this.ncfColumn.Name = "ncfColumn";
            this.ncfColumn.ReadOnly = true;
            // 
            // tipocompraColumn
            // 
            this.tipocompraColumn.HeaderText = "Tipo Compra";
            this.tipocompraColumn.Name = "tipocompraColumn";
            this.tipocompraColumn.ReadOnly = true;
            // 
            // empleadocolumn
            // 
            this.empleadocolumn.HeaderText = "Empleado";
            this.empleadocolumn.Name = "empleadocolumn";
            this.empleadocolumn.ReadOnly = true;
            // 
            // numeroCompraRadioButton
            // 
            this.numeroCompraRadioButton.AutoSize = true;
            this.numeroCompraRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.numeroCompraRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCompraRadioButton.Location = new System.Drawing.Point(170, 64);
            this.numeroCompraRadioButton.Name = "numeroCompraRadioButton";
            this.numeroCompraRadioButton.Size = new System.Drawing.Size(101, 22);
            this.numeroCompraRadioButton.TabIndex = 25;
            this.numeroCompraRadioButton.TabStop = true;
            this.numeroCompraRadioButton.Text = "# Compra";
            this.numeroCompraRadioButton.UseVisualStyleBackColor = true;
            // 
            // ventana_busqueda_compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ventana_busqueda_compra";
            this.Text = "ventana_busqueda_compra";
            this.Load += new System.EventHandler(this.ventana_busqueda_compra_Load);
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

        private GroupBox groupBox1;
        private RadioButton tipoCompraRadionButton;
        private RadioButton ncfRadionButton;
        private RadioButton todoRadioButton;
        private TextBox nombreText;
        private Label label3;
        private DataGridView dataGridView1;
        private RadioButton suplidorRadioButton;
        private DataGridViewTextBoxColumn codigoColumn;
        private DataGridViewTextBoxColumn fechaColumn;
        private DataGridViewTextBoxColumn fechaVenceColumn;
        private DataGridViewTextBoxColumn suplidorColumn;
        private DataGridViewTextBoxColumn ncfColumn;
        private DataGridViewTextBoxColumn tipocompraColumn;
        private DataGridViewTextBoxColumn empleadocolumn;
        private RadioButton numeroCompraRadioButton;
    }
}