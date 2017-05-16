using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_sistema
{
    partial class menu1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu1));
            this.flowLayoutVentanas = new System.Windows.Forms.FlowLayoutPanel();
            this.notificacionesBoton = new System.Windows.Forms.Button();
            this.flowLayoutModulos = new System.Windows.Forms.FlowLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.busquedaText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 594);
            this.panel1.Size = new System.Drawing.Size(940, 54);
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(799, 5);
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(964, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(401, 5);
            this.button3.Visible = false;
            // 
            // flowLayoutVentanas
            // 
            this.flowLayoutVentanas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutVentanas.AutoScroll = true;
            this.flowLayoutVentanas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutVentanas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutVentanas.Location = new System.Drawing.Point(12, 150);
            this.flowLayoutVentanas.Name = "flowLayoutVentanas";
            this.flowLayoutVentanas.Size = new System.Drawing.Size(940, 284);
            this.flowLayoutVentanas.TabIndex = 13;
            this.flowLayoutVentanas.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutVentanas_Paint);
            // 
            // notificacionesBoton
            // 
            this.notificacionesBoton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notificacionesBoton.BackColor = System.Drawing.Color.Transparent;
            this.notificacionesBoton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("notificacionesBoton.BackgroundImage")));
            this.notificacionesBoton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notificacionesBoton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notificacionesBoton.Location = new System.Drawing.Point(745, 3);
            this.notificacionesBoton.Name = "notificacionesBoton";
            this.notificacionesBoton.Size = new System.Drawing.Size(93, 77);
            this.notificacionesBoton.TabIndex = 0;
            this.notificacionesBoton.UseVisualStyleBackColor = false;
            this.notificacionesBoton.Click += new System.EventHandler(this.notificacionesBoton_Click);
            // 
            // flowLayoutModulos
            // 
            this.flowLayoutModulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutModulos.AutoScroll = true;
            this.flowLayoutModulos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutModulos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutModulos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutModulos.Location = new System.Drawing.Point(12, 440);
            this.flowLayoutModulos.Name = "flowLayoutModulos";
            this.flowLayoutModulos.Size = new System.Drawing.Size(940, 208);
            this.flowLayoutModulos.TabIndex = 12;
            this.flowLayoutModulos.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutModulos_Paint);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(646, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 77);
            this.button5.TabIndex = 11;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_2);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(844, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 77);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // busquedaText
            // 
            this.busquedaText.BackColor = System.Drawing.Color.SkyBlue;
            this.busquedaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.busquedaText.Location = new System.Drawing.Point(84, 118);
            this.busquedaText.MaxLength = 25;
            this.busquedaText.Name = "busquedaText";
            this.busquedaText.Size = new System.Drawing.Size(348, 26);
            this.busquedaText.TabIndex = 117;
            this.busquedaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.busquedaText_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "Search";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.notificacionesBoton);
            this.panel3.Controls.Add(this.button5);
            this.panel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(940, 87);
            this.panel3.TabIndex = 14;
            // 
            // menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(964, 660);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.busquedaText);
            this.Controls.Add(this.flowLayoutVentanas);
            this.Controls.Add(this.flowLayoutModulos);
            this.MaximizeBox = true;
            this.Name = "menu1";
            this.Text = "menu1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menu1_FormClosing);
            this.Load += new System.EventHandler(this.menu1_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.menu1_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.flowLayoutModulos, 0);
            this.Controls.SetChildIndex(this.flowLayoutVentanas, 0);
            this.Controls.SetChildIndex(this.busquedaText, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutVentanas;
        private FlowLayoutPanel flowLayoutModulos;
        private Button button4;
        private Button notificacionesBoton;
        private Button button5;
        private TextBox busquedaText;
        private Label label4;
        private FlowLayoutPanel panel3;
    }
}