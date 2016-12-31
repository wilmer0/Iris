using System.Windows.Forms;

namespace IrisContabilidad.modulo_nomina
{
    partial class ventana_empleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_empleado));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pasaporteText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.rutaImagenText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.empresaIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.imagen_empleado = new System.Windows.Forms.Panel();
            this.situacionText = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.situacionIdText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nominaTipoText = new System.Windows.Forms.TextBox();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.grupoUsuarioText = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.grupoUsuarioIdText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.fechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cargoText = new System.Windows.Forms.TextBox();
            this.departamentoText = new System.Windows.Forms.TextBox();
            this.sucursalText = new System.Windows.Forms.TextBox();
            this.identificacionText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sueldoText = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.nominaTipoIdText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.sucursalIdText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.departamentoIdText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.cargoIdText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.claveText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.usuarioText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.permisoText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secuenciacolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button15 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 571);
            this.panel1.Size = new System.Drawing.Size(927, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(786, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(951, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(388, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(927, 538);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.pasaporteText);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.rutaImagenText);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.imagen_empleado);
            this.tabPage1.Controls.Add(this.situacionText);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.situacionIdText);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.nominaTipoText);
            this.tabPage1.Controls.Add(this.activoCheck);
            this.tabPage1.Controls.Add(this.grupoUsuarioText);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.grupoUsuarioIdText);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.fechaIngreso);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.cargoText);
            this.tabPage1.Controls.Add(this.departamentoText);
            this.tabPage1.Controls.Add(this.sucursalText);
            this.tabPage1.Controls.Add(this.identificacionText);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.sueldoText);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.nominaTipoIdText);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.sucursalIdText);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.departamentoIdText);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.cargoIdText);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.claveText);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nombreText);
            this.tabPage1.Controls.Add(this.usuarioText);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empleado";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pasaporteText
            // 
            this.pasaporteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pasaporteText.Location = new System.Drawing.Point(112, 150);
            this.pasaporteText.MaxLength = 30;
            this.pasaporteText.Name = "pasaporteText";
            this.pasaporteText.Size = new System.Drawing.Size(253, 26);
            this.pasaporteText.TabIndex = 67;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(15, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 20);
            this.label16.TabIndex = 66;
            this.label16.Text = "Pasaporte";
            // 
            // button11
            // 
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(651, 373);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(47, 37);
            this.button11.TabIndex = 65;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // rutaImagenText
            // 
            this.rutaImagenText.BackColor = System.Drawing.Color.SkyBlue;
            this.rutaImagenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutaImagenText.Location = new System.Drawing.Point(509, 380);
            this.rutaImagenText.Name = "rutaImagenText";
            this.rutaImagenText.Size = new System.Drawing.Size(141, 26);
            this.rutaImagenText.TabIndex = 64;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(462, 383);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 20);
            this.label14.TabIndex = 63;
            this.label14.Text = "foto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.empresaIdText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 66);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // empresaIdText
            // 
            this.empresaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.empresaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresaIdText.Location = new System.Drawing.Point(106, 23);
            this.empresaIdText.Name = "empresaIdText";
            this.empresaIdText.Size = new System.Drawing.Size(141, 26);
            this.empresaIdText.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Empleado";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(253, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 23;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // imagen_empleado
            // 
            this.imagen_empleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagen_empleado.Location = new System.Drawing.Point(725, 81);
            this.imagen_empleado.Name = "imagen_empleado";
            this.imagen_empleado.Size = new System.Drawing.Size(185, 171);
            this.imagen_empleado.TabIndex = 61;
            // 
            // situacionText
            // 
            this.situacionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situacionText.Location = new System.Drawing.Point(509, 342);
            this.situacionText.MaxLength = 30;
            this.situacionText.Name = "situacionText";
            this.situacionText.ReadOnly = true;
            this.situacionText.Size = new System.Drawing.Size(194, 26);
            this.situacionText.TabIndex = 60;
            // 
            // button10
            // 
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(651, 303);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 37);
            this.button10.TabIndex = 59;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // situacionIdText
            // 
            this.situacionIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.situacionIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situacionIdText.Location = new System.Drawing.Point(509, 310);
            this.situacionIdText.Name = "situacionIdText";
            this.situacionIdText.Size = new System.Drawing.Size(141, 26);
            this.situacionIdText.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(419, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 57;
            this.label13.Text = "Situación";
            // 
            // nominaTipoText
            // 
            this.nominaTipoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nominaTipoText.Location = new System.Drawing.Point(509, 231);
            this.nominaTipoText.MaxLength = 30;
            this.nominaTipoText.Name = "nominaTipoText";
            this.nominaTipoText.ReadOnly = true;
            this.nominaTipoText.Size = new System.Drawing.Size(194, 26);
            this.nominaTipoText.TabIndex = 56;
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(504, 455);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 55;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            // 
            // grupoUsuarioText
            // 
            this.grupoUsuarioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoUsuarioText.Location = new System.Drawing.Point(509, 147);
            this.grupoUsuarioText.MaxLength = 30;
            this.grupoUsuarioText.Name = "grupoUsuarioText";
            this.grupoUsuarioText.ReadOnly = true;
            this.grupoUsuarioText.Size = new System.Drawing.Size(194, 26);
            this.grupoUsuarioText.TabIndex = 54;
            // 
            // button9
            // 
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(651, 108);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 37);
            this.button9.TabIndex = 53;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // grupoUsuarioIdText
            // 
            this.grupoUsuarioIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.grupoUsuarioIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoUsuarioIdText.Location = new System.Drawing.Point(509, 115);
            this.grupoUsuarioIdText.Name = "grupoUsuarioIdText";
            this.grupoUsuarioIdText.Size = new System.Drawing.Size(141, 26);
            this.grupoUsuarioIdText.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(385, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 20);
            this.label12.TabIndex = 51;
            this.label12.Text = "Grup. usuario";
            // 
            // fechaIngreso
            // 
            this.fechaIngreso.Location = new System.Drawing.Point(509, 81);
            this.fechaIngreso.Name = "fechaIngreso";
            this.fechaIngreso.Size = new System.Drawing.Size(200, 20);
            this.fechaIngreso.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(380, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 20);
            this.label11.TabIndex = 49;
            this.label11.Text = "Fecha ingreso";
            // 
            // cargoText
            // 
            this.cargoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargoText.Location = new System.Drawing.Point(112, 450);
            this.cargoText.MaxLength = 30;
            this.cargoText.Name = "cargoText";
            this.cargoText.ReadOnly = true;
            this.cargoText.Size = new System.Drawing.Size(253, 26);
            this.cargoText.TabIndex = 48;
            // 
            // departamentoText
            // 
            this.departamentoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departamentoText.Location = new System.Drawing.Point(112, 377);
            this.departamentoText.MaxLength = 30;
            this.departamentoText.Name = "departamentoText";
            this.departamentoText.ReadOnly = true;
            this.departamentoText.Size = new System.Drawing.Size(253, 26);
            this.departamentoText.TabIndex = 47;
            // 
            // sucursalText
            // 
            this.sucursalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalText.Location = new System.Drawing.Point(112, 304);
            this.sucursalText.MaxLength = 30;
            this.sucursalText.Name = "sucursalText";
            this.sucursalText.ReadOnly = true;
            this.sucursalText.Size = new System.Drawing.Size(253, 26);
            this.sucursalText.TabIndex = 46;
            // 
            // identificacionText
            // 
            this.identificacionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.identificacionText.Location = new System.Drawing.Point(112, 115);
            this.identificacionText.MaxLength = 30;
            this.identificacionText.Name = "identificacionText";
            this.identificacionText.Size = new System.Drawing.Size(253, 26);
            this.identificacionText.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Identif.";
            // 
            // sueldoText
            // 
            this.sueldoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sueldoText.Location = new System.Drawing.Point(509, 272);
            this.sueldoText.MaxLength = 30;
            this.sueldoText.Name = "sueldoText";
            this.sueldoText.Size = new System.Drawing.Size(194, 26);
            this.sueldoText.TabIndex = 43;
            this.sueldoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(651, 192);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 37);
            this.button8.TabIndex = 42;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // nominaTipoIdText
            // 
            this.nominaTipoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.nominaTipoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nominaTipoIdText.Location = new System.Drawing.Point(509, 199);
            this.nominaTipoIdText.Name = "nominaTipoIdText";
            this.nominaTipoIdText.Size = new System.Drawing.Size(141, 26);
            this.nominaTipoIdText.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(397, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "Tipo nomina";
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(259, 265);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 39;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // sucursalIdText
            // 
            this.sucursalIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.sucursalIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalIdText.Location = new System.Drawing.Point(112, 272);
            this.sucursalIdText.Name = "sucursalIdText";
            this.sucursalIdText.Size = new System.Drawing.Size(141, 26);
            this.sucursalIdText.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Sucursal";
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(259, 338);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 36;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // departamentoIdText
            // 
            this.departamentoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.departamentoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departamentoIdText.Location = new System.Drawing.Point(112, 345);
            this.departamentoIdText.Name = "departamentoIdText";
            this.departamentoIdText.Size = new System.Drawing.Size(141, 26);
            this.departamentoIdText.TabIndex = 35;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(259, 411);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 34;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cargoIdText
            // 
            this.cargoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cargoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargoIdText.Location = new System.Drawing.Point(112, 418);
            this.cargoIdText.Name = "cargoIdText";
            this.cargoIdText.Size = new System.Drawing.Size(141, 26);
            this.cargoIdText.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(438, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Sueldo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Cargo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Dpto.";
            // 
            // claveText
            // 
            this.claveText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveText.Location = new System.Drawing.Point(112, 228);
            this.claveText.MaxLength = 30;
            this.claveText.Name = "claveText";
            this.claveText.PasswordChar = '*';
            this.claveText.Size = new System.Drawing.Size(253, 26);
            this.claveText.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Usuario";
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(112, 79);
            this.nombreText.MaxLength = 30;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(253, 26);
            this.nombreText.TabIndex = 11;
            // 
            // usuarioText
            // 
            this.usuarioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioText.Location = new System.Drawing.Point(112, 188);
            this.usuarioText.MaxLength = 30;
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new System.Drawing.Size(253, 26);
            this.usuarioText.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombre";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(919, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Permisos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Controls.Add(this.button13);
            this.groupBox3.Controls.Add(this.permisoText);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Location = new System.Drawing.Point(9, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(904, 91);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button14
            // 
            this.button14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button14.BackgroundImage")));
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(834, 23);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(64, 58);
            this.button14.TabIndex = 26;
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button13.BackgroundImage")));
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(763, 23);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(65, 58);
            this.button13.TabIndex = 25;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // permisoText
            // 
            this.permisoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permisoText.Location = new System.Drawing.Point(90, 55);
            this.permisoText.MaxLength = 30;
            this.permisoText.Name = "permisoText";
            this.permisoText.Size = new System.Drawing.Size(335, 26);
            this.permisoText.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.SkyBlue;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(90, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(282, 26);
            this.textBox2.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 9;
            this.label15.Text = "Permiso";
            // 
            // button12
            // 
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(378, 16);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(47, 37);
            this.button12.TabIndex = 23;
            this.button12.UseVisualStyleBackColor = true;
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
            this.secuenciacolumn});
            this.dataGridView1.Location = new System.Drawing.Point(9, 103);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(904, 403);
            this.dataGridView1.TabIndex = 25;
            // 
            // codigoColumn
            // 
            this.codigoColumn.FillWeight = 20F;
            this.codigoColumn.HeaderText = "Id";
            this.codigoColumn.Name = "codigoColumn";
            this.codigoColumn.ReadOnly = true;
            // 
            // secuenciacolumn
            // 
            this.secuenciacolumn.HeaderText = "Nombre";
            this.secuenciacolumn.Name = "secuenciacolumn";
            this.secuenciacolumn.ReadOnly = true;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Tomato;
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.Location = new System.Drawing.Point(725, 258);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(185, 37);
            this.button15.TabIndex = 68;
            this.button15.Text = "Eliminar Foto";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // ventana_empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 637);
            this.Controls.Add(this.tabControl1);
            this.Name = "ventana_empleado";
            this.Text = "ventana_empleado";
            this.Load += new System.EventHandler(this.ventana_empleado_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox nombreText;
        public System.Windows.Forms.TextBox usuarioText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox empresaIdText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox claveText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox cargoIdText;
        public System.Windows.Forms.TextBox sueldoText;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox nominaTipoIdText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox sucursalIdText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox departamentoIdText;
        public System.Windows.Forms.TextBox identificacionText;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox sucursalText;
        public System.Windows.Forms.TextBox departamentoText;
        public System.Windows.Forms.TextBox cargoText;
        private System.Windows.Forms.DateTimePicker fechaIngreso;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox grupoUsuarioText;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox grupoUsuarioIdText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox activoCheck;
        public System.Windows.Forms.TextBox situacionText;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox situacionIdText;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox nominaTipoText;
        private System.Windows.Forms.Panel imagen_empleado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button12;
        public System.Windows.Forms.TextBox permisoText;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secuenciacolumn;
        public System.Windows.Forms.TextBox pasaporteText;
        private System.Windows.Forms.Label label16;
        private TextBox rutaImagenText;
        private Button button15;
    }
}