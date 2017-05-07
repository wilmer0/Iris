using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    partial class ventana_suplidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_suplidor));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.direccionText = new System.Windows.Forms.TextBox();
            this.tipoGastoText = new System.Windows.Forms.TextBox();
            this.tipoGastoIdText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.faxText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.telefono2Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.telefono1Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ciudadText = new System.Windows.Forms.TextBox();
            this.rncText = new System.Windows.Forms.TextBox();
            this.limiteCreditoText = new System.Windows.Forms.TextBox();
            this.ciudadIdText = new System.Windows.Forms.TextBox();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 547);
            this.panel1.Size = new System.Drawing.Size(926, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(785, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(950, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(393, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.direccionText);
            this.tabPage1.Controls.Add(this.tipoGastoText);
            this.tabPage1.Controls.Add(this.tipoGastoIdText);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.faxText);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.telefono2Text);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.telefono1Text);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ciudadText);
            this.tabPage1.Controls.Add(this.rncText);
            this.tabPage1.Controls.Add(this.limiteCreditoText);
            this.tabPage1.Controls.Add(this.ciudadIdText);
            this.tabPage1.Controls.Add(this.nombreText);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.activoCheck);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(919, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Suplidor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(447, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 74;
            this.label8.Text = "Dirección";
            // 
            // direccionText
            // 
            this.direccionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionText.Location = new System.Drawing.Point(451, 105);
            this.direccionText.MaxLength = 500;
            this.direccionText.Multiline = true;
            this.direccionText.Name = "direccionText";
            this.direccionText.Size = new System.Drawing.Size(459, 165);
            this.direccionText.TabIndex = 73;
            this.direccionText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.direccionText_KeyDown);
            // 
            // tipoGastoText
            // 
            this.tipoGastoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGastoText.Location = new System.Drawing.Point(143, 441);
            this.tipoGastoText.MaxLength = 30;
            this.tipoGastoText.Name = "tipoGastoText";
            this.tipoGastoText.ReadOnly = true;
            this.tipoGastoText.Size = new System.Drawing.Size(194, 26);
            this.tipoGastoText.TabIndex = 72;
            // 
            // tipoGastoIdText
            // 
            this.tipoGastoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoGastoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGastoIdText.Location = new System.Drawing.Point(143, 409);
            this.tipoGastoIdText.Name = "tipoGastoIdText";
            this.tipoGastoIdText.Size = new System.Drawing.Size(141, 26);
            this.tipoGastoIdText.TabIndex = 70;
            this.tipoGastoIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoGastoIdText_KeyDown);
            this.tipoGastoIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoGastoIdText_KeyPress);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(286, 402);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 71;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 69;
            this.label7.Text = "Gasto";
            // 
            // faxText
            // 
            this.faxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faxText.Location = new System.Drawing.Point(144, 237);
            this.faxText.MaxLength = 10;
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(253, 26);
            this.faxText.TabIndex = 68;
            this.faxText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.faxText_KeyDown);
            this.faxText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.faxText_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "Fax";
            // 
            // telefono2Text
            // 
            this.telefono2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono2Text.Location = new System.Drawing.Point(144, 195);
            this.telefono2Text.MaxLength = 10;
            this.telefono2Text.Name = "telefono2Text";
            this.telefono2Text.Size = new System.Drawing.Size(253, 26);
            this.telefono2Text.TabIndex = 66;
            this.telefono2Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono2Text_KeyDown);
            this.telefono2Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefono2Text_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(95, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 65;
            this.label4.Text = "Tel2";
            // 
            // telefono1Text
            // 
            this.telefono1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono1Text.Location = new System.Drawing.Point(144, 154);
            this.telefono1Text.MaxLength = 10;
            this.telefono1Text.Name = "telefono1Text";
            this.telefono1Text.Size = new System.Drawing.Size(253, 26);
            this.telefono1Text.TabIndex = 64;
            this.telefono1Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono1Text_KeyDown);
            this.telefono1Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefono1Text_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Tel1";
            // 
            // ciudadText
            // 
            this.ciudadText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciudadText.Location = new System.Drawing.Point(143, 360);
            this.ciudadText.MaxLength = 30;
            this.ciudadText.Name = "ciudadText";
            this.ciudadText.ReadOnly = true;
            this.ciudadText.Size = new System.Drawing.Size(194, 26);
            this.ciudadText.TabIndex = 56;
            // 
            // rncText
            // 
            this.rncText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rncText.Location = new System.Drawing.Point(144, 118);
            this.rncText.MaxLength = 11;
            this.rncText.Name = "rncText";
            this.rncText.Size = new System.Drawing.Size(253, 26);
            this.rncText.TabIndex = 45;
            this.rncText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rncText_KeyDown);
            this.rncText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rncText_KeyPress);
            // 
            // limiteCreditoText
            // 
            this.limiteCreditoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limiteCreditoText.Location = new System.Drawing.Point(144, 284);
            this.limiteCreditoText.MaxLength = 15;
            this.limiteCreditoText.Name = "limiteCreditoText";
            this.limiteCreditoText.Size = new System.Drawing.Size(253, 26);
            this.limiteCreditoText.TabIndex = 43;
            this.limiteCreditoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.limiteCreditoText_KeyDown);
            this.limiteCreditoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sueldoText_KeyPress);
            // 
            // ciudadIdText
            // 
            this.ciudadIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.ciudadIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciudadIdText.Location = new System.Drawing.Point(143, 328);
            this.ciudadIdText.Name = "ciudadIdText";
            this.ciudadIdText.Size = new System.Drawing.Size(141, 26);
            this.ciudadIdText.TabIndex = 41;
            this.ciudadIdText.TextChanged += new System.EventHandler(this.ciudadIdText_TextChanged);
            this.ciudadIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ciudadIdText_KeyDown);
            this.ciudadIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ciudadIdText_KeyPress);
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(144, 79);
            this.nombreText.MaxLength = 30;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(253, 26);
            this.nombreText.TabIndex = 11;
            this.nombreText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreText_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 66);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(138, 19);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(155, 26);
            this.suplidorIdText.TabIndex = 18;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Suplidor";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(299, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 23;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(451, 286);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 55;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(97, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Rnc";
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(286, 321);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 37);
            this.button8.TabIndex = 42;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "Ciudad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Limite credito";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(927, 512);
            this.tabControl1.TabIndex = 10;
            // 
            // ventana_suplidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 613);
            this.Controls.Add(this.tabControl1);
            this.Name = "ventana_suplidor";
            this.Text = "ventana_suplidor";
            this.Load += new System.EventHandler(this.ventana_suplidor_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabPage tabPage1;
        public TextBox ciudadText;
        public TextBox rncText;
        public TextBox limiteCreditoText;
        private TextBox ciudadIdText;
        public TextBox nombreText;
        private GroupBox groupBox1;
        private TextBox suplidorIdText;
        private Label label2;
        private Button button4;
        private CheckBox activoCheck;
        private Label label10;
        private Button button8;
        private Label label9;
        private Label label6;
        private Label label3;
        private TabControl tabControl1;
        public TextBox telefono2Text;
        private Label label4;
        public TextBox telefono1Text;
        private Label label1;
        public TextBox faxText;
        private Label label5;
        public TextBox tipoGastoText;
        private TextBox tipoGastoIdText;
        private Button button5;
        private Label label7;
        private Label label8;
        public TextBox direccionText;

    }
}