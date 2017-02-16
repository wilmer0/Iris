namespace IrisContabilidad.modulo_contabilidad
{
    partial class ventana_gastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_gastos));
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.NcfText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tipoGadtoIdText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoGastoText = new System.Windows.Forms.TextBox();
            this.FechaText = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.montoSubTotalText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.montoItebisText = new System.Windows.Forms.TextBox();
            this.tipoRetencionIsrIdText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tipoRetencionIsrText = new System.Windows.Forms.TextBox();
            this.montoRetencionIsrText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 454);
            this.panel1.Size = new System.Drawing.Size(916, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(775, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(940, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(388, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Suplidor";
            // 
            // suplidorText
            // 
            this.suplidorText.BackColor = System.Drawing.Color.White;
            this.suplidorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorText.Location = new System.Drawing.Point(121, 56);
            this.suplidorText.MaxLength = 200;
            this.suplidorText.Name = "suplidorText";
            this.suplidorText.ReadOnly = true;
            this.suplidorText.Size = new System.Drawing.Size(236, 26);
            this.suplidorText.TabIndex = 81;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(310, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 80;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(121, 19);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(183, 26);
            this.suplidorIdText.TabIndex = 79;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
            this.suplidorIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.suplidorIdText_KeyPress);
            // 
            // NcfText
            // 
            this.NcfText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NcfText.Location = new System.Drawing.Point(121, 235);
            this.NcfText.MaxLength = 19;
            this.NcfText.Name = "NcfText";
            this.NcfText.Size = new System.Drawing.Size(253, 26);
            this.NcfText.TabIndex = 88;
            this.NcfText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NcfText_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.montoRetencionIsrText);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tipoRetencionIsrIdText);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tipoRetencionIsrText);
            this.groupBox1.Controls.Add(this.montoItebisText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.montoSubTotalText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FechaText);
            this.groupBox1.Controls.Add(this.tipoGadtoIdText);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tipoGastoText);
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Controls.Add(this.NcfText);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.suplidorText);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 420);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // tipoGadtoIdText
            // 
            this.tipoGadtoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoGadtoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGadtoIdText.Location = new System.Drawing.Point(121, 107);
            this.tipoGadtoIdText.Name = "tipoGadtoIdText";
            this.tipoGadtoIdText.Size = new System.Drawing.Size(183, 26);
            this.tipoGadtoIdText.TabIndex = 89;
            this.tipoGadtoIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoGadtoIdText_KeyDown);
            this.tipoGadtoIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoGadtoIdText_KeyPress);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(310, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 90;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "Tipo Gasto";
            // 
            // tipoGastoText
            // 
            this.tipoGastoText.BackColor = System.Drawing.Color.White;
            this.tipoGastoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGastoText.Location = new System.Drawing.Point(121, 144);
            this.tipoGastoText.MaxLength = 200;
            this.tipoGastoText.Name = "tipoGastoText";
            this.tipoGastoText.ReadOnly = true;
            this.tipoGastoText.Size = new System.Drawing.Size(236, 26);
            this.tipoGastoText.TabIndex = 91;
            // 
            // FechaText
            // 
            this.FechaText.Location = new System.Drawing.Point(121, 190);
            this.FechaText.Mask = "00/00/0000";
            this.FechaText.Name = "FechaText";
            this.FechaText.Size = new System.Drawing.Size(100, 20);
            this.FechaText.TabIndex = 93;
            this.FechaText.ValidatingType = typeof(System.DateTime);
            this.FechaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FechaText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 94;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 95;
            this.label4.Text = "NCF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Sub Total";
            // 
            // montoSubTotalText
            // 
            this.montoSubTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoSubTotalText.Location = new System.Drawing.Point(121, 291);
            this.montoSubTotalText.MaxLength = 30;
            this.montoSubTotalText.Name = "montoSubTotalText";
            this.montoSubTotalText.Size = new System.Drawing.Size(253, 26);
            this.montoSubTotalText.TabIndex = 96;
            this.montoSubTotalText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoSubTotalText_KeyDown);
            this.montoSubTotalText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoSubTotalText_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 98;
            this.label6.Text = "Itbis";
            // 
            // montoItebisText
            // 
            this.montoItebisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoItebisText.Location = new System.Drawing.Point(121, 346);
            this.montoItebisText.MaxLength = 30;
            this.montoItebisText.Name = "montoItebisText";
            this.montoItebisText.Size = new System.Drawing.Size(253, 26);
            this.montoItebisText.TabIndex = 99;
            this.montoItebisText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoItebisText_KeyDown);
            this.montoItebisText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoItebisText_KeyPress);
            // 
            // tipoRetencionIsrIdText
            // 
            this.tipoRetencionIsrIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoRetencionIsrIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoRetencionIsrIdText.Location = new System.Drawing.Point(585, 19);
            this.tipoRetencionIsrIdText.Name = "tipoRetencionIsrIdText";
            this.tipoRetencionIsrIdText.Size = new System.Drawing.Size(183, 26);
            this.tipoRetencionIsrIdText.TabIndex = 100;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(774, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 101;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(441, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 103;
            this.label7.Text = "Retención ISR";
            // 
            // tipoRetencionIsrText
            // 
            this.tipoRetencionIsrText.BackColor = System.Drawing.Color.White;
            this.tipoRetencionIsrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoRetencionIsrText.Location = new System.Drawing.Point(585, 56);
            this.tipoRetencionIsrText.MaxLength = 200;
            this.tipoRetencionIsrText.Name = "tipoRetencionIsrText";
            this.tipoRetencionIsrText.ReadOnly = true;
            this.tipoRetencionIsrText.Size = new System.Drawing.Size(236, 26);
            this.tipoRetencionIsrText.TabIndex = 102;
            // 
            // montoRetencionIsrText
            // 
            this.montoRetencionIsrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoRetencionIsrText.Location = new System.Drawing.Point(585, 102);
            this.montoRetencionIsrText.MaxLength = 30;
            this.montoRetencionIsrText.Name = "montoRetencionIsrText";
            this.montoRetencionIsrText.Size = new System.Drawing.Size(253, 26);
            this.montoRetencionIsrText.TabIndex = 105;
            this.montoRetencionIsrText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoRetencionIsrText_KeyDown);
            this.montoRetencionIsrText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoRetencionIsrText_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 104;
            this.label8.Text = "Monto Retención";
            // 
            // ventana_gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 520);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_gastos";
            this.Text = "ventana_gastos";
            this.Load += new System.EventHandler(this.ventana_gastos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox suplidorText;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox suplidorIdText;
        public System.Windows.Forms.TextBox NcfText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox FechaText;
        private System.Windows.Forms.TextBox tipoGadtoIdText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tipoGastoText;
        public System.Windows.Forms.TextBox montoItebisText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox montoSubTotalText;
        private System.Windows.Forms.TextBox tipoRetencionIsrIdText;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tipoRetencionIsrText;
        public System.Windows.Forms.TextBox montoRetencionIsrText;
        private System.Windows.Forms.Label label8;
    }
}