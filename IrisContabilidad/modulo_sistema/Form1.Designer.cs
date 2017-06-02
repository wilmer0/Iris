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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.claveText = new System.Windows.Forms.TextBox();
            this.usuarioText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 331);
            this.panel1.Size = new System.Drawing.Size(650, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(509, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(674, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(255, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(241, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 173);
            this.panel4.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.claveText);
            this.groupBox2.Controls.Add(this.usuarioText);
            this.groupBox2.Location = new System.Drawing.Point(16, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 111);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // claveText
            // 
            this.claveText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveText.Location = new System.Drawing.Point(225, 62);
            this.claveText.MaxLength = 30;
            this.claveText.Name = "claveText";
            this.claveText.PasswordChar = '*';
            this.claveText.Size = new System.Drawing.Size(220, 29);
            this.claveText.TabIndex = 1;
            this.claveText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claveText_KeyDown_1);
            // 
            // usuarioText
            // 
            this.usuarioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioText.Location = new System.Drawing.Point(225, 19);
            this.usuarioText.MaxLength = 30;
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new System.Drawing.Size(220, 29);
            this.usuarioText.TabIndex = 0;
            this.usuarioText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuarioText_KeyDown_1);
            this.usuarioText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.usuarioText_KeyUp);
            this.usuarioText.Leave += new System.EventHandler(this.usuarioText_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "user name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(674, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel3;
        private GroupBox groupBox1;
        private Label label3;
        public Button button4;
        private Panel panel4;
        private GroupBox groupBox2;
        private TextBox usuarioText;
        private TextBox claveText;
        private Label label2;
        private Label label1;
    }
}

