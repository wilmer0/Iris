﻿using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_empresa
{
    partial class ventana_empresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_empresa));
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.divisionText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RncText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.empresaText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.empresaIdText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.serieComprobanteText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 374);
            this.panel1.Size = new System.Drawing.Size(582, 54);
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
            this.button1.Location = new System.Drawing.Point(441, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(606, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(222, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(175, 215);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 21;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // divisionText
            // 
            this.divisionText.BackColor = System.Drawing.Color.White;
            this.divisionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divisionText.Location = new System.Drawing.Point(175, 133);
            this.divisionText.MaxLength = 2;
            this.divisionText.Name = "divisionText";
            this.divisionText.Size = new System.Drawing.Size(256, 26);
            this.divisionText.TabIndex = 19;
            this.divisionText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.divisionText_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "División:";
            // 
            // RncText
            // 
            this.RncText.BackColor = System.Drawing.Color.White;
            this.RncText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RncText.Location = new System.Drawing.Point(175, 91);
            this.RncText.MaxLength = 11;
            this.RncText.Name = "RncText";
            this.RncText.Size = new System.Drawing.Size(256, 26);
            this.RncText.TabIndex = 17;
            this.RncText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RncText_KeyDown);
            this.RncText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RncText_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Rnc:";
            // 
            // empresaText
            // 
            this.empresaText.BackColor = System.Drawing.Color.White;
            this.empresaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresaText.Location = new System.Drawing.Point(175, 54);
            this.empresaText.MaxLength = 200;
            this.empresaText.Name = "empresaText";
            this.empresaText.Size = new System.Drawing.Size(256, 26);
            this.empresaText.TabIndex = 14;
            this.empresaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empresaText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.empresaIdText);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 80);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresa";
            // 
            // empresaIdText
            // 
            this.empresaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.empresaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresaIdText.Location = new System.Drawing.Point(163, 32);
            this.empresaIdText.Name = "empresaIdText";
            this.empresaIdText.Size = new System.Drawing.Size(256, 26);
            this.empresaIdText.TabIndex = 0;
            this.empresaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.empresaIdText_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.serieComprobanteText);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.empresaText);
            this.groupBox2.Controls.Add(this.activoCheck);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.divisionText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.RncText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 255);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(477, 181);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 68);
            this.button4.TabIndex = 24;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // serieComprobanteText
            // 
            this.serieComprobanteText.BackColor = System.Drawing.Color.White;
            this.serieComprobanteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serieComprobanteText.Location = new System.Drawing.Point(175, 168);
            this.serieComprobanteText.MaxLength = 1;
            this.serieComprobanteText.Name = "serieComprobanteText";
            this.serieComprobanteText.Size = new System.Drawing.Size(256, 26);
            this.serieComprobanteText.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Serie comprobante:";
            // 
            // ventana_empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_empresa";
            this.Text = "ventana_empresa";
            this.Load += new System.EventHandler(this.ventana_empresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ventana_empresa_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox activoCheck;
        private TextBox divisionText;
        private Label label4;
        private TextBox RncText;
        private Label label3;
        private TextBox empresaText;
        private Label label2;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox empresaIdText;
        private GroupBox groupBox2;
        private TextBox serieComprobanteText;
        private Label label5;
        public Button button4;
    }
}