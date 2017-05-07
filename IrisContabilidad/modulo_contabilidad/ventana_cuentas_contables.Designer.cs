using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_contabilidad
{
    partial class ventana_cuentas_contables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_cuentas_contables));
            this.cuentaIdText = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numeroCuentaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.cuentaPadreIdText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cuentaPadreText = new System.Windows.Forms.TextBox();
            this.radioCuentaAcumulativa = new System.Windows.Forms.RadioButton();
            this.radioCuentaMovimiento = new System.Windows.Forms.RadioButton();
            this.radioOrigenCredito = new System.Windows.Forms.RadioButton();
            this.radioOrigenDebito = new System.Windows.Forms.RadioButton();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 368);
            this.panel1.Size = new System.Drawing.Size(919, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(778, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(943, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(389, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cuentaIdText
            // 
            this.cuentaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cuentaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaIdText.Location = new System.Drawing.Point(133, 23);
            this.cuentaIdText.Name = "cuentaIdText";
            this.cuentaIdText.Size = new System.Drawing.Size(183, 26);
            this.cuentaIdText.TabIndex = 118;
            this.cuentaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuentaIdText_KeyDown);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(322, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 119;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(60, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 120;
            this.label9.Text = "Cuenta";
            // 
            // numeroCuentaText
            // 
            this.numeroCuentaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCuentaText.Location = new System.Drawing.Point(133, 123);
            this.numeroCuentaText.MaxLength = 19;
            this.numeroCuentaText.Name = "numeroCuentaText";
            this.numeroCuentaText.Size = new System.Drawing.Size(253, 26);
            this.numeroCuentaText.TabIndex = 122;
            this.numeroCuentaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroCuentaText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 123;
            this.label3.Text = "# Cuenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 125;
            this.label4.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(133, 74);
            this.nombreText.MaxLength = 19;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(253, 26);
            this.nombreText.TabIndex = 124;
            this.nombreText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreText_KeyDown);
            // 
            // cuentaPadreIdText
            // 
            this.cuentaPadreIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cuentaPadreIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreIdText.Location = new System.Drawing.Point(133, 175);
            this.cuentaPadreIdText.Name = "cuentaPadreIdText";
            this.cuentaPadreIdText.Size = new System.Drawing.Size(183, 26);
            this.cuentaPadreIdText.TabIndex = 126;
            this.cuentaPadreIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuentaPadreIdText_KeyDown);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(322, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 127;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Cuenta padre";
            // 
            // cuentaPadreText
            // 
            this.cuentaPadreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreText.Location = new System.Drawing.Point(133, 214);
            this.cuentaPadreText.MaxLength = 19;
            this.cuentaPadreText.Name = "cuentaPadreText";
            this.cuentaPadreText.Size = new System.Drawing.Size(253, 26);
            this.cuentaPadreText.TabIndex = 129;
            // 
            // radioCuentaAcumulativa
            // 
            this.radioCuentaAcumulativa.AutoSize = true;
            this.radioCuentaAcumulativa.Checked = true;
            this.radioCuentaAcumulativa.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioCuentaAcumulativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCuentaAcumulativa.Location = new System.Drawing.Point(8, 39);
            this.radioCuentaAcumulativa.Name = "radioCuentaAcumulativa";
            this.radioCuentaAcumulativa.Size = new System.Drawing.Size(168, 21);
            this.radioCuentaAcumulativa.TabIndex = 130;
            this.radioCuentaAcumulativa.TabStop = true;
            this.radioCuentaAcumulativa.Text = "Cuenta acumulativa";
            this.radioCuentaAcumulativa.UseVisualStyleBackColor = true;
            this.radioCuentaAcumulativa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioCuentaAcumulativa_KeyDown);
            // 
            // radioCuentaMovimiento
            // 
            this.radioCuentaMovimiento.AutoSize = true;
            this.radioCuentaMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCuentaMovimiento.Location = new System.Drawing.Point(225, 39);
            this.radioCuentaMovimiento.Name = "radioCuentaMovimiento";
            this.radioCuentaMovimiento.Size = new System.Drawing.Size(163, 21);
            this.radioCuentaMovimiento.TabIndex = 131;
            this.radioCuentaMovimiento.Text = "Cuenta Movimiento";
            this.radioCuentaMovimiento.UseVisualStyleBackColor = true;
            this.radioCuentaMovimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioCuentaMovimiento_KeyDown);
            // 
            // radioOrigenCredito
            // 
            this.radioOrigenCredito.AutoSize = true;
            this.radioOrigenCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOrigenCredito.Location = new System.Drawing.Point(225, 28);
            this.radioOrigenCredito.Name = "radioOrigenCredito";
            this.radioOrigenCredito.Size = new System.Drawing.Size(130, 21);
            this.radioOrigenCredito.TabIndex = 133;
            this.radioOrigenCredito.Text = "Origen crédito";
            this.radioOrigenCredito.UseVisualStyleBackColor = true;
            this.radioOrigenCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioOrigenCredito_KeyDown);
            // 
            // radioOrigenDebito
            // 
            this.radioOrigenDebito.AutoSize = true;
            this.radioOrigenDebito.Checked = true;
            this.radioOrigenDebito.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioOrigenDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOrigenDebito.Location = new System.Drawing.Point(8, 28);
            this.radioOrigenDebito.Name = "radioOrigenDebito";
            this.radioOrigenDebito.Size = new System.Drawing.Size(125, 21);
            this.radioOrigenDebito.TabIndex = 132;
            this.radioOrigenDebito.TabStop = true;
            this.radioOrigenDebito.Text = "Origen debito";
            this.radioOrigenDebito.UseVisualStyleBackColor = true;
            this.radioOrigenDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioOrigenDebito_KeyDown);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(460, 214);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(83, 28);
            this.activoCheck.TabIndex = 134;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCuentaMovimiento);
            this.groupBox1.Controls.Add(this.radioCuentaAcumulativa);
            this.groupBox1.Location = new System.Drawing.Point(460, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 84);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo cuenta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioOrigenDebito);
            this.groupBox2.Controls.Add(this.radioOrigenCredito);
            this.groupBox2.Location = new System.Drawing.Point(460, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 72);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origen cuenta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cuentaIdText);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.activoCheck);
            this.groupBox3.Controls.Add(this.numeroCuentaText);
            this.groupBox3.Controls.Add(this.cuentaPadreText);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cuentaPadreIdText);
            this.groupBox3.Controls.Add(this.nombreText);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(16, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(912, 335);
            this.groupBox3.TabIndex = 137;
            this.groupBox3.TabStop = false;
            // 
            // ventana_cuentas_contables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 434);
            this.Controls.Add(this.groupBox3);
            this.Name = "ventana_cuentas_contables";
            this.Text = "ventana_cuentas_contables";
            this.Load += new System.EventHandler(this.ventana_cuentas_contables_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
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

        private TextBox cuentaIdText;
        private Button button7;
        private Label label9;
        public TextBox numeroCuentaText;
        private Label label3;
        private Label label4;
        public TextBox nombreText;
        private TextBox cuentaPadreIdText;
        private Button button6;
        private Label label5;
        public TextBox cuentaPadreText;
        private RadioButton radioCuentaAcumulativa;
        private RadioButton radioCuentaMovimiento;
        private RadioButton radioOrigenCredito;
        private RadioButton radioOrigenDebito;
        private CheckBox activoCheck;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}