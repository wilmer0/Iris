namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    partial class ventana_tipo_gasto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_tipo_gasto));
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.suplidorIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 262);
            this.panel1.Size = new System.Drawing.Size(536, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(395, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(560, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(198, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(172, 195);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 70;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(172, 135);
            this.nombreText.MaxLength = 30;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(253, 26);
            this.nombreText.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 68;
            this.label3.Text = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.suplidorIdText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 66);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            // 
            // suplidorIdText
            // 
            this.suplidorIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.suplidorIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suplidorIdText.Location = new System.Drawing.Point(166, 21);
            this.suplidorIdText.Name = "suplidorIdText";
            this.suplidorIdText.Size = new System.Drawing.Size(155, 26);
            this.suplidorIdText.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "tipo gasto";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(327, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 23;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ventana_tipo_gasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 328);
            this.Controls.Add(this.activoCheck);
            this.Controls.Add(this.nombreText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_tipo_gasto";
            this.Text = "ventana_tipo_gasto";
            this.Load += new System.EventHandler(this.ventana_tipo_gasto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.nombreText, 0);
            this.Controls.SetChildIndex(this.activoCheck, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox activoCheck;
        public System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox suplidorIdText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}