namespace IrisContabilidad.modulo_facturacion
{
    partial class ventana_imprimir_cuadre_caja_rd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_imprimir_cuadre_caja_rd));
            this.cajeroIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cajeroText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaCierreDateTime = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 340);
            this.panel1.Size = new System.Drawing.Size(570, 54);
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
            this.button1.Location = new System.Drawing.Point(429, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(594, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(215, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cajeroIdText
            // 
            this.cajeroIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cajeroIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajeroIdText.Location = new System.Drawing.Point(149, 83);
            this.cajeroIdText.Name = "cajeroIdText";
            this.cajeroIdText.Size = new System.Drawing.Size(155, 26);
            this.cajeroIdText.TabIndex = 25;
            this.cajeroIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cajeroIdText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cajero";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(310, 78);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 26;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cajeroText
            // 
            this.cajeroText.BackColor = System.Drawing.Color.White;
            this.cajeroText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cajeroText.Location = new System.Drawing.Point(149, 121);
            this.cajeroText.MaxLength = 100;
            this.cajeroText.Name = "cajeroText";
            this.cajeroText.ReadOnly = true;
            this.cajeroText.Size = new System.Drawing.Size(286, 26);
            this.cajeroText.TabIndex = 81;
            this.cajeroText.TextChanged += new System.EventHandler(this.cajeroText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "Fecha Cierre";
            // 
            // fechaCierreDateTime
            // 
            this.fechaCierreDateTime.Location = new System.Drawing.Point(150, 179);
            this.fechaCierreDateTime.Mask = "00/00/0000";
            this.fechaCierreDateTime.Name = "fechaCierreDateTime";
            this.fechaCierreDateTime.Size = new System.Drawing.Size(100, 20);
            this.fechaCierreDateTime.TabIndex = 84;
            this.fechaCierreDateTime.ValidatingType = typeof(System.DateTime);
            this.fechaCierreDateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fechaCierreDateTime_KeyDown);
            // 
            // ventana_imprimir_cuadre_caja_rd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 406);
            this.Controls.Add(this.fechaCierreDateTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cajeroText);
            this.Controls.Add(this.cajeroIdText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Name = "ventana_imprimir_cuadre_caja_rd";
            this.Text = "ventana_imprimir_cuadre_caja_rd";
            this.Load += new System.EventHandler(this.ventana_imprimir_cuadre_caja_rd_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cajeroIdText, 0);
            this.Controls.SetChildIndex(this.cajeroText, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.fechaCierreDateTime, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cajeroIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox cajeroText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox fechaCierreDateTime;

    }
}