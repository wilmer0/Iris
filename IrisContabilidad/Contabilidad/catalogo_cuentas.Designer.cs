namespace puntoVenta.Contabilidad
{
    partial class catalogo_cuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(catalogo_cuentas));
            this.cuentaAcumulativaRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cuentaMovimientoRadioButton = new System.Windows.Forms.RadioButton();
            this.cuentaPadreRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.creditoRadioButton = new System.Windows.Forms.RadioButton();
            this.debitoRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.codigoCuentaText = new System.Windows.Forms.TextBox();
            this.nombreCuentaPadreText = new System.Windows.Forms.TextBox();
            this.numeroCuentaPadreText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.numeroCuentaAcumulativaText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.descripcionText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numeroCuentaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 515);
            this.panel1.Size = new System.Drawing.Size(928, 54);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(395, 5);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1220, 289);
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.Text = ".";
            // 
            // usuarioText
            // 
            this.usuarioText.Location = new System.Drawing.Point(1239, 289);
            this.usuarioText.Size = new System.Drawing.Size(29, 24);
            // 
            // claveText
            // 
            this.claveText.Location = new System.Drawing.Point(1239, 235);
            this.claveText.Size = new System.Drawing.Size(33, 24);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1187, 240);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(13, 495);
            this.linkLabel1.Size = new System.Drawing.Size(50, 17);
            this.linkLabel1.Text = "como?";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-5, 0);
            this.panel2.Size = new System.Drawing.Size(962, 44);
            // 
            // cuentaAcumulativaRadioButton
            // 
            this.cuentaAcumulativaRadioButton.AutoSize = true;
            this.cuentaAcumulativaRadioButton.Checked = true;
            this.cuentaAcumulativaRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaAcumulativaRadioButton.Location = new System.Drawing.Point(9, 28);
            this.cuentaAcumulativaRadioButton.Name = "cuentaAcumulativaRadioButton";
            this.cuentaAcumulativaRadioButton.Size = new System.Drawing.Size(166, 21);
            this.cuentaAcumulativaRadioButton.TabIndex = 8;
            this.cuentaAcumulativaRadioButton.TabStop = true;
            this.cuentaAcumulativaRadioButton.Text = "cuenta acumulativa";
            this.cuentaAcumulativaRadioButton.UseVisualStyleBackColor = true;
            this.cuentaAcumulativaRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cuentaMovimientoRadioButton);
            this.groupBox1.Controls.Add(this.cuentaPadreRadioButton);
            this.groupBox1.Controls.Add(this.cuentaAcumulativaRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(20, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 65);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Cuenta";
            // 
            // cuentaMovimientoRadioButton
            // 
            this.cuentaMovimientoRadioButton.AutoSize = true;
            this.cuentaMovimientoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaMovimientoRadioButton.Location = new System.Drawing.Point(343, 28);
            this.cuentaMovimientoRadioButton.Name = "cuentaMovimientoRadioButton";
            this.cuentaMovimientoRadioButton.Size = new System.Drawing.Size(161, 21);
            this.cuentaMovimientoRadioButton.TabIndex = 10;
            this.cuentaMovimientoRadioButton.Text = "cuenta movimiento";
            this.cuentaMovimientoRadioButton.UseVisualStyleBackColor = true;
            this.cuentaMovimientoRadioButton.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // cuentaPadreRadioButton
            // 
            this.cuentaPadreRadioButton.AutoSize = true;
            this.cuentaPadreRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreRadioButton.Location = new System.Drawing.Point(203, 28);
            this.cuentaPadreRadioButton.Name = "cuentaPadreRadioButton";
            this.cuentaPadreRadioButton.Size = new System.Drawing.Size(122, 21);
            this.cuentaPadreRadioButton.TabIndex = 9;
            this.cuentaPadreRadioButton.Text = "cuenta padre";
            this.cuentaPadreRadioButton.UseVisualStyleBackColor = true;
            this.cuentaPadreRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.creditoRadioButton);
            this.groupBox2.Controls.Add(this.debitoRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(20, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 68);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origen Cuenta";
            // 
            // creditoRadioButton
            // 
            this.creditoRadioButton.AutoSize = true;
            this.creditoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditoRadioButton.Location = new System.Drawing.Point(139, 28);
            this.creditoRadioButton.Name = "creditoRadioButton";
            this.creditoRadioButton.Size = new System.Drawing.Size(76, 21);
            this.creditoRadioButton.TabIndex = 9;
            this.creditoRadioButton.Text = "credito";
            this.creditoRadioButton.UseVisualStyleBackColor = true;
            // 
            // debitoRadioButton
            // 
            this.debitoRadioButton.AutoSize = true;
            this.debitoRadioButton.Checked = true;
            this.debitoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debitoRadioButton.Location = new System.Drawing.Point(6, 28);
            this.debitoRadioButton.Name = "debitoRadioButton";
            this.debitoRadioButton.Size = new System.Drawing.Size(71, 21);
            this.debitoRadioButton.TabIndex = 8;
            this.debitoRadioButton.TabStop = true;
            this.debitoRadioButton.Text = "debito";
            this.debitoRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.codigoCuentaText);
            this.groupBox3.Controls.Add(this.nombreCuentaPadreText);
            this.groupBox3.Controls.Add(this.numeroCuentaPadreText);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.numeroCuentaAcumulativaText);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.descripcionText);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numeroCuentaText);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(20, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(920, 216);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cuenta";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // codigoCuentaText
            // 
            this.codigoCuentaText.Location = new System.Drawing.Point(164, 57);
            this.codigoCuentaText.MaxLength = 50;
            this.codigoCuentaText.Name = "codigoCuentaText";
            this.codigoCuentaText.ReadOnly = true;
            this.codigoCuentaText.Size = new System.Drawing.Size(51, 20);
            this.codigoCuentaText.TabIndex = 21;
            // 
            // nombreCuentaPadreText
            // 
            this.nombreCuentaPadreText.Location = new System.Drawing.Point(648, 44);
            this.nombreCuentaPadreText.MaxLength = 50;
            this.nombreCuentaPadreText.Name = "nombreCuentaPadreText";
            this.nombreCuentaPadreText.ReadOnly = true;
            this.nombreCuentaPadreText.Size = new System.Drawing.Size(266, 20);
            this.nombreCuentaPadreText.TabIndex = 20;
            // 
            // numeroCuentaPadreText
            // 
            this.numeroCuentaPadreText.Location = new System.Drawing.Point(648, 18);
            this.numeroCuentaPadreText.MaxLength = 50;
            this.numeroCuentaPadreText.Name = "numeroCuentaPadreText";
            this.numeroCuentaPadreText.ReadOnly = true;
            this.numeroCuentaPadreText.Size = new System.Drawing.Size(266, 20);
            this.numeroCuentaPadreText.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(538, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "cuenta padre";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(437, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 30);
            this.button4.TabIndex = 12;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // numeroCuentaAcumulativaText
            // 
            this.numeroCuentaAcumulativaText.Location = new System.Drawing.Point(165, 19);
            this.numeroCuentaAcumulativaText.MaxLength = 50;
            this.numeroCuentaAcumulativaText.Name = "numeroCuentaAcumulativaText";
            this.numeroCuentaAcumulativaText.ReadOnly = true;
            this.numeroCuentaAcumulativaText.Size = new System.Drawing.Size(266, 20);
            this.numeroCuentaAcumulativaText.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "cuenta acumulativa";
            // 
            // descripcionText
            // 
            this.descripcionText.Location = new System.Drawing.Point(165, 96);
            this.descripcionText.MaxLength = 200;
            this.descripcionText.Multiline = true;
            this.descripcionText.Name = "descripcionText";
            this.descripcionText.Size = new System.Drawing.Size(266, 114);
            this.descripcionText.TabIndex = 15;
            this.descripcionText.TextChanged += new System.EventHandler(this.descripcionText_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "descripción";
            // 
            // numeroCuentaText
            // 
            this.numeroCuentaText.Location = new System.Drawing.Point(221, 57);
            this.numeroCuentaText.MaxLength = 50;
            this.numeroCuentaText.Name = "numeroCuentaText";
            this.numeroCuentaText.Size = new System.Drawing.Size(209, 20);
            this.numeroCuentaText.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "número cuenta";
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(26, 458);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(70, 21);
            this.activoCheck.TabIndex = 12;
            this.activoCheck.Text = "activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            // 
            // catalogo_cuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 581);
            this.Controls.Add(this.activoCheck);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "catalogo_cuentas";
            this.Text = "catalogo_cuentas";
            this.Load += new System.EventHandler(this.catalogo_cuentas_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.usuarioText, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.claveText, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.activoCheck, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton cuentaAcumulativaRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cuentaPadreRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton creditoRadioButton;
        private System.Windows.Forms.RadioButton debitoRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox numeroCuentaText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descripcionText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton cuentaMovimientoRadioButton;
        private System.Windows.Forms.TextBox numeroCuentaAcumulativaText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox activoCheck;
        private System.Windows.Forms.TextBox numeroCuentaPadreText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombreCuentaPadreText;
        private System.Windows.Forms.TextBox codigoCuentaText;
    }
}