using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_facturacion
{
    partial class ventana_cuadre_caja_rd
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
            this.cajeroLabel = new System.Windows.Forms.Label();
            this.fechaText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dosMilText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.milText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.quinientoText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cienText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cincuentaText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.venticincoText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.veinteText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.diezText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cincoText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.unoText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.doscientosText = new System.Windows.Forms.TextBox();
            this.montoTotalEfectivoText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 355);
            this.panel1.Size = new System.Drawing.Size(869, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(728, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(893, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(364, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cajeroLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 56);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cajeroLabel
            // 
            this.cajeroLabel.AutoSize = true;
            this.cajeroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajeroLabel.Location = new System.Drawing.Point(6, 16);
            this.cajeroLabel.Name = "cajeroLabel";
            this.cajeroLabel.Size = new System.Drawing.Size(58, 20);
            this.cajeroLabel.TabIndex = 31;
            this.cajeroLabel.Text = "cajero";
            // 
            // fechaText
            // 
            this.fechaText.Location = new System.Drawing.Point(734, 89);
            this.fechaText.Name = "fechaText";
            this.fechaText.ReadOnly = true;
            this.fechaText.Size = new System.Drawing.Size(138, 20);
            this.fechaText.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(601, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Fecha cuadre";
            // 
            // dosMilText
            // 
            this.dosMilText.BackColor = System.Drawing.Color.White;
            this.dosMilText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dosMilText.Location = new System.Drawing.Point(85, 16);
            this.dosMilText.MaxLength = 4;
            this.dosMilText.Name = "dosMilText";
            this.dosMilText.Size = new System.Drawing.Size(111, 26);
            this.dosMilText.TabIndex = 33;
            this.dosMilText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dosMilText_KeyPress);
            this.dosMilText.Leave += new System.EventHandler(this.dosMilText_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "$2000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "$1000";
            // 
            // milText
            // 
            this.milText.BackColor = System.Drawing.Color.White;
            this.milText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.milText.Location = new System.Drawing.Point(85, 53);
            this.milText.MaxLength = 4;
            this.milText.Name = "milText";
            this.milText.Size = new System.Drawing.Size(111, 26);
            this.milText.TabIndex = 35;
            this.milText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.milText_KeyPress);
            this.milText.Leave += new System.EventHandler(this.milText_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "$500";
            // 
            // quinientoText
            // 
            this.quinientoText.BackColor = System.Drawing.Color.White;
            this.quinientoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quinientoText.Location = new System.Drawing.Point(85, 87);
            this.quinientoText.MaxLength = 4;
            this.quinientoText.Name = "quinientoText";
            this.quinientoText.Size = new System.Drawing.Size(111, 26);
            this.quinientoText.TabIndex = 37;
            this.quinientoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quinientoText_KeyPress);
            this.quinientoText.Leave += new System.EventHandler(this.quinientoText_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "$100";
            // 
            // cienText
            // 
            this.cienText.BackColor = System.Drawing.Color.White;
            this.cienText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cienText.Location = new System.Drawing.Point(287, 16);
            this.cienText.MaxLength = 4;
            this.cienText.Name = "cienText";
            this.cienText.Size = new System.Drawing.Size(111, 26);
            this.cienText.TabIndex = 39;
            this.cienText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cienText_KeyPress);
            this.cienText.Leave += new System.EventHandler(this.cienText_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "$50";
            // 
            // cincuentaText
            // 
            this.cincuentaText.BackColor = System.Drawing.Color.White;
            this.cincuentaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cincuentaText.Location = new System.Drawing.Point(287, 51);
            this.cincuentaText.MaxLength = 4;
            this.cincuentaText.Name = "cincuentaText";
            this.cincuentaText.Size = new System.Drawing.Size(111, 26);
            this.cincuentaText.TabIndex = 41;
            this.cincuentaText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cincuentaText_KeyPress);
            this.cincuentaText.Leave += new System.EventHandler(this.cincuentaText_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(242, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "$25";
            // 
            // venticincoText
            // 
            this.venticincoText.BackColor = System.Drawing.Color.White;
            this.venticincoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venticincoText.Location = new System.Drawing.Point(287, 88);
            this.venticincoText.MaxLength = 4;
            this.venticincoText.Name = "venticincoText";
            this.venticincoText.Size = new System.Drawing.Size(111, 26);
            this.venticincoText.TabIndex = 43;
            this.venticincoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.venticincoText_KeyPress);
            this.venticincoText.Leave += new System.EventHandler(this.venticincoText_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(242, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "$20";
            // 
            // veinteText
            // 
            this.veinteText.BackColor = System.Drawing.Color.White;
            this.veinteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.veinteText.Location = new System.Drawing.Point(287, 124);
            this.veinteText.MaxLength = 4;
            this.veinteText.Name = "veinteText";
            this.veinteText.Size = new System.Drawing.Size(111, 26);
            this.veinteText.TabIndex = 45;
            this.veinteText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.veinteText_KeyPress);
            this.veinteText.Leave += new System.EventHandler(this.veinteText_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(462, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 48;
            this.label10.Text = "$10";
            // 
            // diezText
            // 
            this.diezText.BackColor = System.Drawing.Color.White;
            this.diezText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diezText.Location = new System.Drawing.Point(507, 16);
            this.diezText.MaxLength = 4;
            this.diezText.Name = "diezText";
            this.diezText.Size = new System.Drawing.Size(111, 26);
            this.diezText.TabIndex = 47;
            this.diezText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.diezText_KeyPress);
            this.diezText.Leave += new System.EventHandler(this.diezText_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(472, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 50;
            this.label11.Text = "$5";
            // 
            // cincoText
            // 
            this.cincoText.BackColor = System.Drawing.Color.White;
            this.cincoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cincoText.Location = new System.Drawing.Point(507, 52);
            this.cincoText.MaxLength = 4;
            this.cincoText.Name = "cincoText";
            this.cincoText.Size = new System.Drawing.Size(111, 26);
            this.cincoText.TabIndex = 49;
            this.cincoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cincoText_KeyPress);
            this.cincoText.Leave += new System.EventHandler(this.cincoText_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(472, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 20);
            this.label12.TabIndex = 52;
            this.label12.Text = "$1";
            // 
            // unoText
            // 
            this.unoText.BackColor = System.Drawing.Color.White;
            this.unoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unoText.Location = new System.Drawing.Point(507, 87);
            this.unoText.MaxLength = 4;
            this.unoText.Name = "unoText";
            this.unoText.Size = new System.Drawing.Size(111, 26);
            this.unoText.TabIndex = 51;
            this.unoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.unoText_KeyPress);
            this.unoText.Leave += new System.EventHandler(this.unoText_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.doscientosText);
            this.groupBox2.Controls.Add(this.montoTotalEfectivoText);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.dosMilText);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.unoText);
            this.groupBox2.Controls.Add(this.milText);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cincoText);
            this.groupBox2.Controls.Add(this.venticincoText);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.diezText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.veinteText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cincuentaText);
            this.groupBox2.Controls.Add(this.quinientoText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cienText);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(866, 230);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(584, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 20);
            this.label14.TabIndex = 55;
            this.label14.Text = "Total efectivo";
            // 
            // doscientosText
            // 
            this.doscientosText.BackColor = System.Drawing.Color.White;
            this.doscientosText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doscientosText.Location = new System.Drawing.Point(85, 124);
            this.doscientosText.MaxLength = 4;
            this.doscientosText.Name = "doscientosText";
            this.doscientosText.Size = new System.Drawing.Size(111, 26);
            this.doscientosText.TabIndex = 53;
            this.doscientosText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doscientosText_KeyPress);
            this.doscientosText.Leave += new System.EventHandler(this.doscientosText_Leave);
            // 
            // montoTotalEfectivoText
            // 
            this.montoTotalEfectivoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.montoTotalEfectivoText.Location = new System.Drawing.Point(707, 194);
            this.montoTotalEfectivoText.Name = "montoTotalEfectivoText";
            this.montoTotalEfectivoText.ReadOnly = true;
            this.montoTotalEfectivoText.Size = new System.Drawing.Size(153, 30);
            this.montoTotalEfectivoText.TabIndex = 54;
            this.montoTotalEfectivoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 54;
            this.label13.Text = "$200";
            // 
            // ventana_cuadre_caja_rd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaText);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_cuadre_caja_rd";
            this.Text = "s";
            this.Load += new System.EventHandler(this.ventana_cuadre_caja_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.fechaText, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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

        private GroupBox groupBox1;
        private Label cajeroLabel;
        private TextBox fechaText;
        private Label label1;
        private TextBox dosMilText;
        private Label label3;
        private Label label4;
        private TextBox milText;
        private Label label5;
        private TextBox quinientoText;
        private Label label6;
        private TextBox cienText;
        private Label label7;
        private TextBox cincuentaText;
        private Label label8;
        private TextBox venticincoText;
        private Label label9;
        private TextBox veinteText;
        private Label label10;
        private TextBox diezText;
        private Label label11;
        private TextBox cincoText;
        private Label label12;
        private TextBox unoText;
        private GroupBox groupBox2;
        private TextBox doscientosText;
        private Label label13;
        private Label label14;
        private TextBox montoTotalEfectivoText;

    }
}