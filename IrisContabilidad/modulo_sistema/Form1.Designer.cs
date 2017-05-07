using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IrisContabilidad
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            this.label1 = new Label();
            this.panel3 = new Panel();
            this.groupBox1 = new GroupBox();
            this.label2 = new Label();
            this.usuarioText = new TextBox();
            this.claveText = new TextBox();
            this.label3 = new Label();
            this.button4 = new Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new Point(12, 375);
            this.panel1.Size = new Size(587, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new Point(446, 5);
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new Size(611, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new Point(222, 5);
            this.button3.Click += new EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new Point(13, 355);
            this.label1.Name = "label1";
            this.label1.Size = new Size(193, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Developed by Black Code";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = ImageLayout.Stretch;
            this.panel3.Location = new Point(207, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(224, 199);
            this.panel3.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.usuarioText);
            this.groupBox1.Controls.Add(this.claveText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new Point(16, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(580, 102);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new Point(126, 19);
            this.label2.Name = "label2";
            this.label2.Size = new Size(76, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario:";
            // 
            // usuarioText
            // 
            this.usuarioText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.usuarioText.Location = new Point(208, 19);
            this.usuarioText.MaxLength = 30;
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new Size(224, 26);
            this.usuarioText.TabIndex = 11;
            this.usuarioText.KeyDown += new KeyEventHandler(this.usuarioText_KeyDown);
            // 
            // claveText
            // 
            this.claveText.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.claveText.Location = new Point(208, 62);
            this.claveText.MaxLength = 30;
            this.claveText.Name = "claveText";
            this.claveText.PasswordChar = '*';
            this.claveText.Size = new Size(224, 26);
            this.claveText.TabIndex = 12;
            this.claveText.KeyDown += new KeyEventHandler(this.claveText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new Point(133, 62);
            this.label3.Name = "label3";
            this.label3.Size = new Size(58, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clave:";
            // 
            // button4
            // 
            this.button4.Anchor = AnchorStyles.None;
            this.button4.BackColor = Color.MediumSeaGreen;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = FlatStyle.Popup;
            this.button4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = Color.White;
            this.button4.Location = new Point(454, 340);
            this.button4.Name = "button4";
            this.button4.Size = new Size(142, 29);
            this.button4.TabIndex = 19;
            this.button4.Text = "Ver Información";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(611, 441);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label label2;
        public TextBox usuarioText;
        public TextBox claveText;
        private Label label3;
        public Button button4;
    }
}

