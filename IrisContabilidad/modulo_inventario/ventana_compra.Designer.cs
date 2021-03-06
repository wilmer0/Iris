﻿using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_inventario
{
    partial class ventana_compra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_compra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.botonImprimir = new System.Windows.Forms.Button();
            this.fechaFinalText = new System.Windows.Forms.MaskedTextBox();
            this.fechaInicialText = new System.Windows.Forms.MaskedTextBox();
            this.suplidorInformalCheck = new System.Windows.Forms.CheckBox();
            this.detalleText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoCompraComboBox = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.numeroFacturaText = new System.Windows.Forms.TextBox();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.numerocComprobanteFiscalText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPrductoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itebisColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.productoIdText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.productoText = new System.Windows.Forms.TextBox();
            this.unidadComboText = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cantidadText = new System.Windows.Forms.TextBox();
            this.precioText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.importeText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.descuentoText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.totalItebisText = new System.Windows.Forms.TextBox();
            this.totalCompraText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 587);
            this.panel1.Size = new System.Drawing.Size(1001, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(860, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1025, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(430, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.fechaFinalText);
            this.groupBox1.Controls.Add(this.fechaInicialText);
            this.groupBox1.Controls.Add(this.suplidorInformalCheck);
            this.groupBox1.Controls.Add(this.detalleText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tipoCompraComboBox);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.numeroFacturaText);
            this.groupBox1.Controls.Add(this.suplidorText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Controls.Add(this.numerocComprobanteFiscalText);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 213);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.botonImprimir);
            this.groupBox3.Location = new System.Drawing.Point(660, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 79);
            this.groupBox3.TabIndex = 105;
            this.groupBox3.TabStop = false;
            // 
            // botonImprimir
            // 
            this.botonImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("botonImprimir.BackgroundImage")));
            this.botonImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.botonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonImprimir.Location = new System.Drawing.Point(241, 7);
            this.botonImprimir.Name = "botonImprimir";
            this.botonImprimir.Size = new System.Drawing.Size(88, 68);
            this.botonImprimir.TabIndex = 104;
            this.botonImprimir.UseVisualStyleBackColor = true;
            this.botonImprimir.Click += new System.EventHandler(this.botonImprimir_Click);
            // 
            // fechaFinalText
            // 
            this.fechaFinalText.Location = new System.Drawing.Point(529, 60);
            this.fechaFinalText.Mask = "00/00/0000";
            this.fechaFinalText.Name = "fechaFinalText";
            this.fechaFinalText.Size = new System.Drawing.Size(125, 20);
            this.fechaFinalText.TabIndex = 89;
            this.fechaFinalText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fechaFinalText_KeyDown);
            // 
            // fechaInicialText
            // 
            this.fechaInicialText.Location = new System.Drawing.Point(529, 19);
            this.fechaInicialText.Mask = "00/00/0000";
            this.fechaInicialText.Name = "fechaInicialText";
            this.fechaInicialText.Size = new System.Drawing.Size(125, 20);
            this.fechaInicialText.TabIndex = 88;
            this.fechaInicialText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fechaInicialText_KeyDown);
            // 
            // suplidorInformalCheck
            // 
            this.suplidorInformalCheck.AutoSize = true;
            this.suplidorInformalCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suplidorInformalCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorInformalCheck.Location = new System.Drawing.Point(529, 179);
            this.suplidorInformalCheck.Name = "suplidorInformalCheck";
            this.suplidorInformalCheck.Size = new System.Drawing.Size(147, 21);
            this.suplidorInformalCheck.TabIndex = 87;
            this.suplidorInformalCheck.Text = "Suplidor informal";
            this.suplidorInformalCheck.UseVisualStyleBackColor = true;
            this.suplidorInformalCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorInformalCheck_KeyDown);
            // 
            // detalleText
            // 
            this.detalleText.Location = new System.Drawing.Point(529, 99);
            this.detalleText.MaxLength = 500;
            this.detalleText.Multiline = true;
            this.detalleText.Name = "detalleText";
            this.detalleText.Size = new System.Drawing.Size(406, 66);
            this.detalleText.TabIndex = 86;
            this.detalleText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detalleText_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(456, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "Detalle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(403, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 84;
            this.label5.Text = "Fecha credito";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(463, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "Tipo compra";
            // 
            // tipoCompraComboBox
            // 
            this.tipoCompraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoCompraComboBox.FormattingEnabled = true;
            this.tipoCompraComboBox.Location = new System.Drawing.Point(122, 182);
            this.tipoCompraComboBox.Name = "tipoCompraComboBox";
            this.tipoCompraComboBox.Size = new System.Drawing.Size(236, 21);
            this.tipoCompraComboBox.TabIndex = 79;
            this.tipoCompraComboBox.Tag = "";
            this.tipoCompraComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoCompraComboBox_KeyDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(41, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(75, 20);
            this.linkLabel1.TabIndex = 78;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Suplidor";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // numeroFacturaText
            // 
            this.numeroFacturaText.BackColor = System.Drawing.Color.White;
            this.numeroFacturaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroFacturaText.Location = new System.Drawing.Point(122, 93);
            this.numeroFacturaText.MaxLength = 30;
            this.numeroFacturaText.Name = "numeroFacturaText";
            this.numeroFacturaText.Size = new System.Drawing.Size(236, 26);
            this.numeroFacturaText.TabIndex = 72;
            this.numeroFacturaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroFacturaText_KeyDown);
            // 
            // suplidorText
            // 
            this.suplidorText.BackColor = System.Drawing.Color.White;
            this.suplidorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorText.Location = new System.Drawing.Point(122, 54);
            this.suplidorText.MaxLength = 200;
            this.suplidorText.Name = "suplidorText";
            this.suplidorText.ReadOnly = true;
            this.suplidorText.Size = new System.Drawing.Size(236, 26);
            this.suplidorText.TabIndex = 77;
            this.suplidorText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Factura";
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(311, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 74;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 76;
            this.label3.Text = "NCF";
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(122, 17);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(183, 26);
            this.suplidorIdText.TabIndex = 71;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
            // 
            // numerocComprobanteFiscalText
            // 
            this.numerocComprobanteFiscalText.BackColor = System.Drawing.Color.White;
            this.numerocComprobanteFiscalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numerocComprobanteFiscalText.Location = new System.Drawing.Point(122, 138);
            this.numerocComprobanteFiscalText.MaxLength = 19;
            this.numerocComprobanteFiscalText.Name = "numerocComprobanteFiscalText";
            this.numerocComprobanteFiscalText.Size = new System.Drawing.Size(236, 26);
            this.numerocComprobanteFiscalText.TabIndex = 75;
            this.numerocComprobanteFiscalText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numerocComprobanteFiscalText_KeyDown);
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
            this.ProductoColumn,
            this.idUnidadColumn,
            this.unidadColumn,
            this.cantidadColumn,
            this.precioColumn,
            this.itebisColumn,
            this.descuentoColumn,
            this.importeColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 339);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1001, 214);
            this.dataGridView1.TabIndex = 87;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idPrductoColumn
            // 
            this.idPrductoColumn.FillWeight = 50F;
            this.idPrductoColumn.HeaderText = "ID";
            this.idPrductoColumn.Name = "idPrductoColumn";
            this.idPrductoColumn.ReadOnly = true;
            // 
            // ProductoColumn
            // 
            this.ProductoColumn.HeaderText = "Producto";
            this.ProductoColumn.Name = "ProductoColumn";
            this.ProductoColumn.ReadOnly = true;
            // 
            // idUnidadColumn
            // 
            this.idUnidadColumn.FillWeight = 50F;
            this.idUnidadColumn.HeaderText = "ID";
            this.idUnidadColumn.Name = "idUnidadColumn";
            this.idUnidadColumn.ReadOnly = true;
            // 
            // unidadColumn
            // 
            this.unidadColumn.HeaderText = "Unidad";
            this.unidadColumn.Name = "unidadColumn";
            this.unidadColumn.ReadOnly = true;
            // 
            // cantidadColumn
            // 
            this.cantidadColumn.HeaderText = "Cantidad";
            this.cantidadColumn.Name = "cantidadColumn";
            this.cantidadColumn.ReadOnly = true;
            // 
            // precioColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.precioColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.precioColumn.HeaderText = "Precio";
            this.precioColumn.Name = "precioColumn";
            this.precioColumn.ReadOnly = true;
            // 
            // itebisColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.itebisColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.itebisColumn.HeaderText = "Itbis";
            this.itebisColumn.Name = "itebisColumn";
            this.itebisColumn.ReadOnly = true;
            // 
            // descuentoColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.descuentoColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.descuentoColumn.HeaderText = "Descuento";
            this.descuentoColumn.Name = "descuentoColumn";
            this.descuentoColumn.ReadOnly = true;
            // 
            // importeColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.importeColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.importeColumn.HeaderText = "Importe";
            this.importeColumn.Name = "importeColumn";
            this.importeColumn.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 88;
            this.label7.Text = "Producto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(256, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 89;
            this.label8.Text = "Unidad";
            // 
            // productoIdText
            // 
            this.productoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.productoIdText.Location = new System.Drawing.Point(84, 15);
            this.productoIdText.Name = "productoIdText";
            this.productoIdText.Size = new System.Drawing.Size(125, 20);
            this.productoIdText.TabIndex = 90;
            this.productoIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productoIdText_KeyDown);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(215, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 30);
            this.button4.TabIndex = 88;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // productoText
            // 
            this.productoText.Location = new System.Drawing.Point(6, 41);
            this.productoText.Name = "productoText";
            this.productoText.ReadOnly = true;
            this.productoText.Size = new System.Drawing.Size(242, 20);
            this.productoText.TabIndex = 91;
            // 
            // unidadComboText
            // 
            this.unidadComboText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unidadComboText.FormattingEnabled = true;
            this.unidadComboText.Location = new System.Drawing.Point(258, 38);
            this.unidadComboText.Name = "unidadComboText";
            this.unidadComboText.Size = new System.Drawing.Size(122, 21);
            this.unidadComboText.TabIndex = 88;
            this.unidadComboText.Tag = "";
            this.unidadComboText.TextChanged += new System.EventHandler(this.unidadComboText_TextChanged_1);
            this.unidadComboText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unidadComboText_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(384, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 92;
            this.label9.Text = "Cantidad";
            // 
            // cantidadText
            // 
            this.cantidadText.Location = new System.Drawing.Point(386, 38);
            this.cantidadText.Name = "cantidadText";
            this.cantidadText.Size = new System.Drawing.Size(108, 20);
            this.cantidadText.TabIndex = 93;
            this.cantidadText.TextChanged += new System.EventHandler(this.cantidadText_TextChanged);
            this.cantidadText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadText_KeyDown);
            this.cantidadText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadText_KeyPress);
            // 
            // precioText
            // 
            this.precioText.Location = new System.Drawing.Point(501, 38);
            this.precioText.Name = "precioText";
            this.precioText.Size = new System.Drawing.Size(108, 20);
            this.precioText.TabIndex = 95;
            this.precioText.TextChanged += new System.EventHandler(this.precioText_TextChanged);
            this.precioText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.precioText_KeyDown);
            this.precioText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.precioText_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(499, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 94;
            this.label10.Text = "Precio";
            // 
            // importeText
            // 
            this.importeText.Location = new System.Drawing.Point(731, 38);
            this.importeText.Name = "importeText";
            this.importeText.ReadOnly = true;
            this.importeText.Size = new System.Drawing.Size(108, 20);
            this.importeText.TabIndex = 97;
            this.importeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(729, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 17);
            this.label11.TabIndex = 96;
            this.label11.Text = "Importe";
            // 
            // descuentoText
            // 
            this.descuentoText.Location = new System.Drawing.Point(616, 38);
            this.descuentoText.MaxLength = 5;
            this.descuentoText.Name = "descuentoText";
            this.descuentoText.Size = new System.Drawing.Size(108, 20);
            this.descuentoText.TabIndex = 99;
            this.descuentoText.Text = "0.00";
            this.descuentoText.TextChanged += new System.EventHandler(this.descuentoText_TextChanged);
            this.descuentoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.descuentoText_KeyDown);
            this.descuentoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descuentoText_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(614, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 17);
            this.label12.TabIndex = 98;
            this.label12.Text = "Descuento(%)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.descuentoText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.importeText);
            this.groupBox2.Controls.Add(this.productoIdText);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.productoText);
            this.groupBox2.Controls.Add(this.precioText);
            this.groupBox2.Controls.Add(this.unidadComboText);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cantidadText);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1001, 97);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(946, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 17);
            this.label16.TabIndex = 103;
            this.label16.Text = "(F2)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(871, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 102;
            this.label15.Text = "(F1)";
            // 
            // button19
            // 
            this.button19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button19.BackgroundImage")));
            this.button19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(931, 30);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(64, 58);
            this.button19.TabIndex = 101;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button20.BackgroundImage")));
            this.button20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(860, 30);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 58);
            this.button20.TabIndex = 100;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(569, 559);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.TabIndex = 88;
            this.label13.Text = "Itebis";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(808, 559);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 101;
            this.label14.Text = "Total";
            // 
            // totalItebisText
            // 
            this.totalItebisText.BackColor = System.Drawing.Color.SkyBlue;
            this.totalItebisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalItebisText.Location = new System.Drawing.Point(629, 556);
            this.totalItebisText.MaxLength = 200;
            this.totalItebisText.Name = "totalItebisText";
            this.totalItebisText.ReadOnly = true;
            this.totalItebisText.Size = new System.Drawing.Size(149, 26);
            this.totalItebisText.TabIndex = 88;
            this.totalItebisText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalCompraText
            // 
            this.totalCompraText.BackColor = System.Drawing.Color.SkyBlue;
            this.totalCompraText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCompraText.Location = new System.Drawing.Point(863, 556);
            this.totalCompraText.MaxLength = 200;
            this.totalCompraText.Name = "totalCompraText";
            this.totalCompraText.ReadOnly = true;
            this.totalCompraText.Size = new System.Drawing.Size(150, 26);
            this.totalCompraText.TabIndex = 102;
            this.totalCompraText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ventana_compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 653);
            this.Controls.Add(this.totalCompraText);
            this.Controls.Add(this.totalItebisText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ventana_compra";
            this.Text = "ventana_compra";
            this.Load += new System.EventHandler(this.ventana_compra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ventana_compra_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.totalItebisText, 0);
            this.Controls.SetChildIndex(this.totalCompraText, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private LinkLabel linkLabel1;
        private TextBox suplidorText;
        private Button button5;
        private TextBox numerocComprobanteFiscalText;
        private Label label3;
        private TextBox suplidorIdText;
        private TextBox numeroFacturaText;
        private Label label2;
        private Label label1;
        private ComboBox tipoCompraComboBox;
        private Label label5;
        private Label label4;
        private TextBox detalleText;
        private Label label6;
        private DataGridView dataGridView1;
        private CheckBox suplidorInformalCheck;
        private Label label7;
        private Label label8;
        private TextBox productoIdText;
        private Button button4;
        private TextBox productoText;
        private ComboBox unidadComboText;
        private Label label9;
        private TextBox cantidadText;
        private TextBox precioText;
        private Label label10;
        private TextBox importeText;
        private Label label11;
        private TextBox descuentoText;
        private Label label12;
        private GroupBox groupBox2;
        private Button button19;
        private Button button20;
        private Label label13;
        private Label label14;
        private TextBox totalItebisText;
        private TextBox totalCompraText;
        private Label label16;
        private Label label15;
        private MaskedTextBox fechaFinalText;
        private MaskedTextBox fechaInicialText;
        private DataGridViewTextBoxColumn idPrductoColumn;
        private DataGridViewTextBoxColumn ProductoColumn;
        private DataGridViewTextBoxColumn idUnidadColumn;
        private DataGridViewTextBoxColumn unidadColumn;
        private DataGridViewTextBoxColumn cantidadColumn;
        private DataGridViewTextBoxColumn precioColumn;
        private DataGridViewTextBoxColumn itebisColumn;
        private DataGridViewTextBoxColumn descuentoColumn;
        private DataGridViewTextBoxColumn importeColumn;
        private Button botonImprimir;
        private GroupBox groupBox3;
    }
}