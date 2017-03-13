namespace IrisContabilidad.modulo_opciones
{
    partial class ventana_tipo_ventana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_tipo_ventana));
            this.comboBoxTipoVentana = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.modulo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ventana = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 387);
            this.panel1.Size = new System.Drawing.Size(689, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(548, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(713, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(274, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxTipoVentana
            // 
            this.comboBoxTipoVentana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoVentana.FormattingEnabled = true;
            this.comboBoxTipoVentana.Location = new System.Drawing.Point(236, 19);
            this.comboBoxTipoVentana.Name = "comboBoxTipoVentana";
            this.comboBoxTipoVentana.Size = new System.Drawing.Size(225, 21);
            this.comboBoxTipoVentana.TabIndex = 9;
            this.comboBoxTipoVentana.TextChanged += new System.EventHandler(this.comboBoxTipoVentana_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tipo Ventana";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.modulo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ventana);
            this.groupBox1.Controls.Add(this.comboBoxTipoVentana);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 354);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(143, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Módulo";
            // 
            // modulo
            // 
            this.modulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.modulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("modulo.BackgroundImage")));
            this.modulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.modulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modulo.Location = new System.Drawing.Point(79, 80);
            this.modulo.Name = "modulo";
            this.modulo.Size = new System.Drawing.Size(220, 185);
            this.modulo.TabIndex = 13;
            this.modulo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ventana";
            // 
            // ventana
            // 
            this.ventana.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ventana.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ventana.BackgroundImage")));
            this.ventana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ventana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ventana.Location = new System.Drawing.Point(383, 80);
            this.ventana.Name = "ventana";
            this.ventana.Size = new System.Drawing.Size(220, 185);
            this.ventana.TabIndex = 11;
            this.ventana.UseVisualStyleBackColor = true;
            // 
            // ventana_tipo_ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 453);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_tipo_ventana";
            this.Text = "ventana_tipo_ventana";
            this.Load += new System.EventHandler(this.ventana_tipo_ventana_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ventana_tipo_ventana_KeyDown);
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

        private System.Windows.Forms.ComboBox comboBoxTipoVentana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ventana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button modulo;
        private System.Windows.Forms.Label label1;
    }
}