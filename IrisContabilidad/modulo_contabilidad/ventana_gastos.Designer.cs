﻿using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_contabilidad
{
    partial class ventana_gastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_gastos));
            this.label2 = new System.Windows.Forms.Label();
            this.suplidorText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.NcfText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numeroFacturaText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gastoIdText = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.montoRetencionIsrText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tipoRetencionIsrIdText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tipoRetencionIsrText = new System.Windows.Forms.TextBox();
            this.montoItebisText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.montoSubTotalText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FechaText = new System.Windows.Forms.MaskedTextBox();
            this.tipoGastoIdText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoGastoText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 349);
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
            this.label2.Location = new System.Drawing.Point(40, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Suplidor";
            // 
            // suplidorText
            // 
            this.suplidorText.BackColor = System.Drawing.Color.White;
            this.suplidorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorText.Location = new System.Drawing.Point(121, 99);
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
            this.button5.Location = new System.Drawing.Point(310, 58);
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
            this.suplidorIdText.Location = new System.Drawing.Point(121, 62);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(183, 26);
            this.suplidorIdText.TabIndex = 79;
            this.suplidorIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suplidorIdText_KeyDown);
            this.suplidorIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.suplidorIdText_KeyPress);
            // 
            // NcfText
            // 
            this.NcfText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NcfText.Location = new System.Drawing.Point(645, 50);
            this.NcfText.MaxLength = 19;
            this.NcfText.Name = "NcfText";
            this.NcfText.Size = new System.Drawing.Size(253, 26);
            this.NcfText.TabIndex = 88;
            this.NcfText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NcfText_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numeroFacturaText);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.gastoIdText);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.label9);
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
            this.groupBox1.Controls.Add(this.tipoGastoIdText);
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
            this.groupBox1.Size = new System.Drawing.Size(913, 314);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // numeroFacturaText
            // 
            this.numeroFacturaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroFacturaText.Location = new System.Drawing.Point(121, 210);
            this.numeroFacturaText.MaxLength = 19;
            this.numeroFacturaText.Name = "numeroFacturaText";
            this.numeroFacturaText.Size = new System.Drawing.Size(253, 26);
            this.numeroFacturaText.TabIndex = 111;
            this.numeroFacturaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroFacturaText_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(44, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 20);
            this.label10.TabIndex = 110;
            this.label10.Text = "Factura";
            // 
            // gastoIdText
            // 
            this.gastoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.gastoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gastoIdText.Location = new System.Drawing.Point(121, 19);
            this.gastoIdText.Name = "gastoIdText";
            this.gastoIdText.Size = new System.Drawing.Size(183, 26);
            this.gastoIdText.TabIndex = 106;
            this.gastoIdText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(310, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 107;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 109;
            this.label9.Text = "Gasto";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // montoRetencionIsrText
            // 
            this.montoRetencionIsrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoRetencionIsrText.Location = new System.Drawing.Point(645, 248);
            this.montoRetencionIsrText.MaxLength = 30;
            this.montoRetencionIsrText.Name = "montoRetencionIsrText";
            this.montoRetencionIsrText.Size = new System.Drawing.Size(236, 26);
            this.montoRetencionIsrText.TabIndex = 105;
            this.montoRetencionIsrText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoRetencionIsrText_KeyDown);
            this.montoRetencionIsrText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoRetencionIsrText_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(493, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 104;
            this.label8.Text = "Monto Retención";
            // 
            // tipoRetencionIsrIdText
            // 
            this.tipoRetencionIsrIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoRetencionIsrIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoRetencionIsrIdText.Location = new System.Drawing.Point(645, 167);
            this.tipoRetencionIsrIdText.Name = "tipoRetencionIsrIdText";
            this.tipoRetencionIsrIdText.Size = new System.Drawing.Size(183, 26);
            this.tipoRetencionIsrIdText.TabIndex = 100;
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(834, 163);
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
            this.label7.Location = new System.Drawing.Point(512, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 103;
            this.label7.Text = "Retención ISR";
            // 
            // tipoRetencionIsrText
            // 
            this.tipoRetencionIsrText.BackColor = System.Drawing.Color.White;
            this.tipoRetencionIsrText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoRetencionIsrText.Location = new System.Drawing.Point(645, 204);
            this.tipoRetencionIsrText.MaxLength = 200;
            this.tipoRetencionIsrText.Name = "tipoRetencionIsrText";
            this.tipoRetencionIsrText.ReadOnly = true;
            this.tipoRetencionIsrText.Size = new System.Drawing.Size(236, 26);
            this.tipoRetencionIsrText.TabIndex = 102;
            // 
            // montoItebisText
            // 
            this.montoItebisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoItebisText.Location = new System.Drawing.Point(645, 131);
            this.montoItebisText.MaxLength = 30;
            this.montoItebisText.Name = "montoItebisText";
            this.montoItebisText.Size = new System.Drawing.Size(253, 26);
            this.montoItebisText.TabIndex = 99;
            this.montoItebisText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoItebisText_KeyDown);
            this.montoItebisText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoItebisText_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(595, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 98;
            this.label6.Text = "Itbis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(553, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Sub Total";
            // 
            // montoSubTotalText
            // 
            this.montoSubTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoSubTotalText.Location = new System.Drawing.Point(645, 91);
            this.montoSubTotalText.MaxLength = 30;
            this.montoSubTotalText.Name = "montoSubTotalText";
            this.montoSubTotalText.Size = new System.Drawing.Size(253, 26);
            this.montoSubTotalText.TabIndex = 96;
            this.montoSubTotalText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.montoSubTotalText_KeyDown);
            this.montoSubTotalText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.montoSubTotalText_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(595, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 95;
            this.label4.Text = "NCF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(580, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 94;
            this.label3.Text = "Fecha";
            // 
            // FechaText
            // 
            this.FechaText.Location = new System.Drawing.Point(645, 15);
            this.FechaText.Mask = "00/00/0000";
            this.FechaText.Name = "FechaText";
            this.FechaText.Size = new System.Drawing.Size(100, 20);
            this.FechaText.TabIndex = 93;
            this.FechaText.ValidatingType = typeof(System.DateTime);
            this.FechaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FechaText_KeyDown);
            // 
            // tipoGastoIdText
            // 
            this.tipoGastoIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.tipoGastoIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGastoIdText.Location = new System.Drawing.Point(121, 135);
            this.tipoGastoIdText.Name = "tipoGastoIdText";
            this.tipoGastoIdText.Size = new System.Drawing.Size(183, 26);
            this.tipoGastoIdText.TabIndex = 89;
            this.tipoGastoIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tipoGadtoIdText_KeyDown);
            this.tipoGastoIdText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoGadtoIdText_KeyPress);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(310, 131);
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
            this.label1.Location = new System.Drawing.Point(18, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "Tipo Gasto";
            // 
            // tipoGastoText
            // 
            this.tipoGastoText.BackColor = System.Drawing.Color.White;
            this.tipoGastoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoGastoText.Location = new System.Drawing.Point(121, 172);
            this.tipoGastoText.MaxLength = 200;
            this.tipoGastoText.Name = "tipoGastoText";
            this.tipoGastoText.ReadOnly = true;
            this.tipoGastoText.Size = new System.Drawing.Size(236, 26);
            this.tipoGastoText.TabIndex = 91;
            // 
            // ventana_gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 415);
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

        private Label label2;
        private TextBox suplidorText;
        private Button button5;
        private TextBox suplidorIdText;
        public TextBox NcfText;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private MaskedTextBox FechaText;
        private TextBox tipoGastoIdText;
        private Button button4;
        private Label label1;
        private TextBox tipoGastoText;
        public TextBox montoItebisText;
        private Label label6;
        private Label label5;
        public TextBox montoSubTotalText;
        private TextBox tipoRetencionIsrIdText;
        private Button button6;
        private Label label7;
        private TextBox tipoRetencionIsrText;
        public TextBox montoRetencionIsrText;
        private Label label8;
        private TextBox gastoIdText;
        private Button button7;
        private Label label9;
        public TextBox numeroFacturaText;
        private Label label10;
    }
}