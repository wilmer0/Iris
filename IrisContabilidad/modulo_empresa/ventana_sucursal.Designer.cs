namespace IrisContabilidad.modulo_empresa
{
    partial class ventana_sucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_sucursal));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sucursalIdText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.secuenciaText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.direccionText = new System.Windows.Forms.TextBox();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.telefono2Text = new System.Windows.Forms.TextBox();
            this.telefono1Text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 447);
            this.panel1.Size = new System.Drawing.Size(620, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(479, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(644, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(241, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sucursalIdText);
            this.groupBox1.Location = new System.Drawing.Point(16, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 80);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(439, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 22;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sucursal";
            // 
            // sucursalIdText
            // 
            this.sucursalIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.sucursalIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalIdText.Location = new System.Drawing.Point(163, 32);
            this.sucursalIdText.Name = "sucursalIdText";
            this.sucursalIdText.Size = new System.Drawing.Size(270, 26);
            this.sucursalIdText.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Secuencia:";
            // 
            // secuenciaText
            // 
            this.secuenciaText.BackColor = System.Drawing.Color.White;
            this.secuenciaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secuenciaText.Location = new System.Drawing.Point(163, 31);
            this.secuenciaText.MaxLength = 3;
            this.secuenciaText.Name = "secuenciaText";
            this.secuenciaText.Size = new System.Drawing.Size(256, 26);
            this.secuenciaText.TabIndex = 17;
            this.secuenciaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secuenciaText_KeyDown);
            this.secuenciaText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.secuenciaText_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dirección:";
            // 
            // direccionText
            // 
            this.direccionText.BackColor = System.Drawing.Color.White;
            this.direccionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionText.Location = new System.Drawing.Point(163, 126);
            this.direccionText.MaxLength = 200;
            this.direccionText.Multiline = true;
            this.direccionText.Name = "direccionText";
            this.direccionText.Size = new System.Drawing.Size(323, 136);
            this.direccionText.TabIndex = 19;
            this.direccionText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.direccionText_KeyDown);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(163, 278);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 21;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.telefono2Text);
            this.groupBox2.Controls.Add(this.telefono1Text);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.activoCheck);
            this.groupBox2.Controls.Add(this.direccionText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.secuenciaText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 321);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // telefono2Text
            // 
            this.telefono2Text.BackColor = System.Drawing.Color.White;
            this.telefono2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono2Text.Location = new System.Drawing.Point(424, 77);
            this.telefono2Text.MaxLength = 10;
            this.telefono2Text.Name = "telefono2Text";
            this.telefono2Text.Size = new System.Drawing.Size(131, 26);
            this.telefono2Text.TabIndex = 25;
            this.telefono2Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono2Text_KeyDown);
            // 
            // telefono1Text
            // 
            this.telefono1Text.BackColor = System.Drawing.Color.White;
            this.telefono1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono1Text.Location = new System.Drawing.Point(163, 77);
            this.telefono1Text.MaxLength = 10;
            this.telefono1Text.Name = "telefono1Text";
            this.telefono1Text.Size = new System.Drawing.Size(131, 26);
            this.telefono1Text.TabIndex = 24;
            this.telefono1Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.telefono1Text_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(318, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Telefono 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Telefono 1:";
            // 
            // ventana_sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 513);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_sucursal";
            this.Text = "ventana_sucursal";
            this.Load += new System.EventHandler(this.ventana_sucursal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ventana_sucursal_KeyDown_1);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
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

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sucursalIdText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secuenciaText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox direccionText;
        private System.Windows.Forms.CheckBox activoCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox telefono2Text;
        private System.Windows.Forms.TextBox telefono1Text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}