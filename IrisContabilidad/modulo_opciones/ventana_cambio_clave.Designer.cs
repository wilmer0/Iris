using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_opciones
{
    partial class ventana_cambio_clave
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.usuarioLabelText = new System.Windows.Forms.Label();
            this.claveConfirmarText = new System.Windows.Forms.TextBox();
            this.claveNuevaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.claveActualText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 286);
            this.panel1.Size = new System.Drawing.Size(538, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(397, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(562, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(199, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.usuarioLabelText);
            this.groupBox2.Controls.Add(this.claveConfirmarText);
            this.groupBox2.Controls.Add(this.claveNuevaText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.claveActualText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 245);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // usuarioLabelText
            // 
            this.usuarioLabelText.AutoSize = true;
            this.usuarioLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioLabelText.Location = new System.Drawing.Point(6, 16);
            this.usuarioLabelText.Name = "usuarioLabelText";
            this.usuarioLabelText.Size = new System.Drawing.Size(68, 20);
            this.usuarioLabelText.TabIndex = 20;
            this.usuarioLabelText.Text = "usuario";
            // 
            // claveConfirmarText
            // 
            this.claveConfirmarText.BackColor = System.Drawing.Color.White;
            this.claveConfirmarText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveConfirmarText.Location = new System.Drawing.Point(174, 187);
            this.claveConfirmarText.MaxLength = 200;
            this.claveConfirmarText.Name = "claveConfirmarText";
            this.claveConfirmarText.PasswordChar = '*';
            this.claveConfirmarText.Size = new System.Drawing.Size(256, 26);
            this.claveConfirmarText.TabIndex = 19;
            this.claveConfirmarText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claveConfirmarText_KeyDown);
            // 
            // claveNuevaText
            // 
            this.claveNuevaText.BackColor = System.Drawing.Color.White;
            this.claveNuevaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveNuevaText.Location = new System.Drawing.Point(174, 126);
            this.claveNuevaText.MaxLength = 200;
            this.claveNuevaText.Name = "claveNuevaText";
            this.claveNuevaText.PasswordChar = '*';
            this.claveNuevaText.Size = new System.Drawing.Size(256, 26);
            this.claveNuevaText.TabIndex = 18;
            this.claveNuevaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claveNuevaText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "confirmar clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Clave nueva";
            // 
            // claveActualText
            // 
            this.claveActualText.BackColor = System.Drawing.Color.White;
            this.claveActualText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveActualText.Location = new System.Drawing.Point(174, 63);
            this.claveActualText.MaxLength = 200;
            this.claveActualText.Name = "claveActualText";
            this.claveActualText.PasswordChar = '*';
            this.claveActualText.Size = new System.Drawing.Size(256, 26);
            this.claveActualText.TabIndex = 14;
            this.claveActualText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.claveActualText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Clave actual";
            // 
            // ventana_cambio_clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 352);
            this.Controls.Add(this.groupBox2);
            this.Name = "ventana_cambio_clave";
            this.Text = "ventana_cambio_clave";
            this.Load += new System.EventHandler(this.ventana_cambio_clave_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
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

        private GroupBox groupBox2;
        private TextBox claveActualText;
        private Label label2;
        private TextBox claveConfirmarText;
        private TextBox claveNuevaText;
        private Label label3;
        private Label label1;
        private Label usuarioLabelText;
    }
}