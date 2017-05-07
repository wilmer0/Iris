using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    partial class ventana_cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_cliente));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.direccion2Text = new System.Windows.Forms.TextBox();
            this.direccion1Text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.clienteContadoCheck = new System.Windows.Forms.CheckBox();
            this.tipoNcfText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tipoNcfIdText = new System.Windows.Forms.TextBox();
            this.abrirCreditoCheck = new System.Windows.Forms.CheckBox();
            this.creditoText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.categoriaText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.telefono2Text = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.categoriaIdText = new System.Windows.Forms.TextBox();
            this.telefono1Text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rncText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cedulaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 597);
            this.panel1.Size = new System.Drawing.Size(948, 54);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(807, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(972, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(404, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(954, 564);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.direccion2Text);
            this.tabPage1.Controls.Add(this.direccion1Text);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.activoCheck);
            this.tabPage1.Controls.Add(this.clienteContadoCheck);
            this.tabPage1.Controls.Add(this.tipoNcfText);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.tipoNcfIdText);
            this.tabPage1.Controls.Add(this.abrirCreditoCheck);
            this.tabPage1.Controls.Add(this.creditoText);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.categoriaText);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.telefono2Text);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.categoriaIdText);
            this.tabPage1.Controls.Add(this.telefono1Text);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.rncText);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cedulaText);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.nombreText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(946, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cliente";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // direccion2Text
            // 
            this.direccion2Text.BackColor = System.Drawing.Color.White;
            this.direccion2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion2Text.Location = new System.Drawing.Point(476, 275);
            this.direccion2Text.MaxLength = 30;
            this.direccion2Text.Multiline = true;
            this.direccion2Text.Name = "direccion2Text";
            this.direccion2Text.Size = new System.Drawing.Size(421, 67);
            this.direccion2Text.TabIndex = 65;
            this.direccion2Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.direccion2Text_KeyDown);
            // 
            // direccion1Text
            // 
            this.direccion1Text.BackColor = System.Drawing.Color.White;
            this.direccion1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion1Text.Location = new System.Drawing.Point(476, 176);
            this.direccion1Text.MaxLength = 30;
            this.direccion1Text.Multiline = true;
            this.direccion1Text.Name = "direccion1Text";
            this.direccion1Text.Size = new System.Drawing.Size(421, 76);
            this.direccion1Text.TabIndex = 64;
            this.direccion1Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.direccion1Text_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(371, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 63;
            this.label11.Text = "Dirección 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(376, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 20);
            this.label10.TabIndex = 62;
            this.label10.Text = "Dirección1";
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(476, 422);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 61;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // clienteContadoCheck
            // 
            this.clienteContadoCheck.AutoSize = true;
            this.clienteContadoCheck.Checked = true;
            this.clienteContadoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clienteContadoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clienteContadoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteContadoCheck.Location = new System.Drawing.Point(476, 375);
            this.clienteContadoCheck.Name = "clienteContadoCheck";
            this.clienteContadoCheck.Size = new System.Drawing.Size(155, 21);
            this.clienteContadoCheck.TabIndex = 60;
            this.clienteContadoCheck.Text = "Cliente al contado";
            this.clienteContadoCheck.UseVisualStyleBackColor = true;
            this.clienteContadoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clienteContadoCheck_KeyDown);
            // 
            // tipoNcfText
            // 
            this.tipoNcfText.BackColor = System.Drawing.Color.White;
            this.tipoNcfText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoNcfText.Location = new System.Drawing.Point(476, 129);
            this.tipoNcfText.MaxLength = 30;
            this.tipoNcfText.Name = "tipoNcfText";
            this.tipoNcfText.ReadOnly = true;
            this.tipoNcfText.Size = new System.Drawing.Size(236, 26);
            this.tipoNcfText.TabIndex = 59;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(665, 86);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 58;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(397, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "Tipo ncf";
            // 
            // tipoNcfIdText
            // 
            this.tipoNcfIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoNcfIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoNcfIdText.Location = new System.Drawing.Point(476, 90);
            this.tipoNcfIdText.Name = "tipoNcfIdText";
            this.tipoNcfIdText.Size = new System.Drawing.Size(183, 26);
            this.tipoNcfIdText.TabIndex = 56;
            this.tipoNcfIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoNcfIdText_KeyDown);
            this.tipoNcfIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoNcfIdText_KeyPress);
            // 
            // abrirCreditoCheck
            // 
            this.abrirCreditoCheck.AutoSize = true;
            this.abrirCreditoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abrirCreditoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirCreditoCheck.Location = new System.Drawing.Point(115, 402);
            this.abrirCreditoCheck.Name = "abrirCreditoCheck";
            this.abrirCreditoCheck.Size = new System.Drawing.Size(203, 21);
            this.abrirCreditoCheck.TabIndex = 55;
            this.abrirCreditoCheck.Text = "Puede comprar a credito";
            this.abrirCreditoCheck.UseVisualStyleBackColor = true;
            this.abrirCreditoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.abrirCreditoCheck_KeyDown);
            // 
            // creditoText
            // 
            this.creditoText.BackColor = System.Drawing.Color.White;
            this.creditoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditoText.Location = new System.Drawing.Point(115, 439);
            this.creditoText.MaxLength = 30;
            this.creditoText.Name = "creditoText";
            this.creditoText.Size = new System.Drawing.Size(236, 26);
            this.creditoText.TabIndex = 38;
            this.creditoText.Text = "0.00";
            this.creditoText.TextChanged += new System.EventHandler(this.creditoText_TextChanged);
            this.creditoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.creditoText_KeyDown);
            this.creditoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.creditoText_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 441);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Credito";
            // 
            // categoriaText
            // 
            this.categoriaText.BackColor = System.Drawing.Color.White;
            this.categoriaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaText.Location = new System.Drawing.Point(115, 355);
            this.categoriaText.MaxLength = 30;
            this.categoriaText.Name = "categoriaText";
            this.categoriaText.ReadOnly = true;
            this.categoriaText.Size = new System.Drawing.Size(236, 26);
            this.categoriaText.TabIndex = 37;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(304, 312);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 27;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // telefono2Text
            // 
            this.telefono2Text.BackColor = System.Drawing.Color.White;
            this.telefono2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono2Text.Location = new System.Drawing.Point(115, 273);
            this.telefono2Text.MaxLength = 30;
            this.telefono2Text.Name = "telefono2Text";
            this.telefono2Text.Size = new System.Drawing.Size(236, 26);
            this.telefono2Text.TabIndex = 35;
            this.telefono2Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono2Text_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Categoria";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Tel2";
            // 
            // categoriaIdText
            // 
            this.categoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.categoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaIdText.Location = new System.Drawing.Point(115, 316);
            this.categoriaIdText.Name = "categoriaIdText";
            this.categoriaIdText.Size = new System.Drawing.Size(183, 26);
            this.categoriaIdText.TabIndex = 25;
            this.categoriaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoriaIdText_KeyDown);
            // 
            // telefono1Text
            // 
            this.telefono1Text.BackColor = System.Drawing.Color.White;
            this.telefono1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono1Text.Location = new System.Drawing.Point(115, 226);
            this.telefono1Text.MaxLength = 30;
            this.telefono1Text.Name = "telefono1Text";
            this.telefono1Text.Size = new System.Drawing.Size(236, 26);
            this.telefono1Text.TabIndex = 33;
            this.telefono1Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono1Text_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Tel1";
            // 
            // rncText
            // 
            this.rncText.BackColor = System.Drawing.Color.White;
            this.rncText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rncText.Location = new System.Drawing.Point(115, 179);
            this.rncText.MaxLength = 9;
            this.rncText.Name = "rncText";
            this.rncText.Size = new System.Drawing.Size(236, 26);
            this.rncText.TabIndex = 31;
            this.rncText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rncText_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Rnc";
            // 
            // cedulaText
            // 
            this.cedulaText.BackColor = System.Drawing.Color.White;
            this.cedulaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cedulaText.Location = new System.Drawing.Point(115, 136);
            this.cedulaText.MaxLength = 11;
            this.cedulaText.Name = "cedulaText";
            this.cedulaText.Size = new System.Drawing.Size(236, 26);
            this.cedulaText.TabIndex = 29;
            this.cedulaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cedulaText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "cedula";
            // 
            // nombreText
            // 
            this.nombreText.BackColor = System.Drawing.Color.White;
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(115, 92);
            this.nombreText.MaxLength = 30;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(236, 26);
            this.nombreText.TabIndex = 27;
            this.nombreText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clienteIdText);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 61);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(341, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 24;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // clienteIdText
            // 
            this.clienteIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.clienteIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clienteIdText.Location = new System.Drawing.Point(152, 19);
            this.clienteIdText.Name = "clienteIdText";
            this.clienteIdText.Size = new System.Drawing.Size(183, 26);
            this.clienteIdText.TabIndex = 0;
            this.clienteIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clienteIdText_KeyDown);
            this.clienteIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.clienteIdText_KeyPress);
            // 
            // ventana_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 663);
            this.Controls.Add(this.tabControl1);
            this.Name = "ventana_cliente";
            this.Text = "ventana_cliente";
            this.Load += new System.EventHandler(this.ventana_cliente_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Button button4;
        private Label label1;
        private TextBox clienteIdText;
        private TextBox rncText;
        private Label label4;
        private TextBox cedulaText;
        private Label label3;
        private TextBox nombreText;
        private Label label2;
        private TextBox telefono2Text;
        private Label label6;
        private TextBox telefono1Text;
        private Label label5;
        private TextBox categoriaText;
        private Button button5;
        private Label label7;
        private TextBox categoriaIdText;
        private TextBox creditoText;
        private Label label8;
        private CheckBox abrirCreditoCheck;
        private TextBox tipoNcfText;
        private Button button6;
        private Label label9;
        private TextBox tipoNcfIdText;
        private CheckBox clienteContadoCheck;
        private CheckBox activoCheck;
        private TextBox direccion2Text;
        private TextBox direccion1Text;
        private Label label11;
        private Label label10;
    }
}