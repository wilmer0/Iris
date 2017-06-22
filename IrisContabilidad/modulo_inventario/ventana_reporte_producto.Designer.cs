using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_inventario
{
    partial class ventana_reporte_producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_reporte_producto));
            this.label1 = new System.Windows.Forms.Label();
            this.productoText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.itebisIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.referenciaText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itebisText = new System.Windows.Forms.TextBox();
            this.categoriaText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.categoriaIdText = new System.Windows.Forms.TextBox();
            this.subcategoriaText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.subcategoriaIdText = new System.Windows.Forms.TextBox();
            this.almacenText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.almacenIdText = new System.Windows.Forms.TextBox();
            this.unidadMinimaText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.unidadMinimaIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 453);
            this.panel1.Size = new System.Drawing.Size(857, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(716, 5);
            this.button1.Text = "Imprimir";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(881, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(358, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Producto";
            // 
            // productoText
            // 
            this.productoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productoText.Location = new System.Drawing.Point(142, 52);
            this.productoText.Name = "productoText";
            this.productoText.Size = new System.Drawing.Size(268, 26);
            this.productoText.TabIndex = 25;
            this.productoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.productoText_KeyDown);
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(330, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 29;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // itebisIdText
            // 
            this.itebisIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.itebisIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itebisIdText.Location = new System.Drawing.Point(141, 223);
            this.itebisIdText.Name = "itebisIdText";
            this.itebisIdText.Size = new System.Drawing.Size(183, 26);
            this.itebisIdText.TabIndex = 28;
            this.itebisIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itebisIdText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Referencia";
            // 
            // referenciaText
            // 
            this.referenciaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenciaText.Location = new System.Drawing.Point(142, 95);
            this.referenciaText.Name = "referenciaText";
            this.referenciaText.Size = new System.Drawing.Size(268, 26);
            this.referenciaText.TabIndex = 30;
            this.referenciaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.referenciaText_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Itbis";
            // 
            // itebisText
            // 
            this.itebisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itebisText.Location = new System.Drawing.Point(141, 262);
            this.itebisText.Name = "itebisText";
            this.itebisText.ReadOnly = true;
            this.itebisText.Size = new System.Drawing.Size(268, 26);
            this.itebisText.TabIndex = 33;
            // 
            // categoriaText
            // 
            this.categoriaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaText.Location = new System.Drawing.Point(543, 91);
            this.categoriaText.Name = "categoriaText";
            this.categoriaText.ReadOnly = true;
            this.categoriaText.Size = new System.Drawing.Size(268, 26);
            this.categoriaText.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Categoria";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(732, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 35;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // categoriaIdText
            // 
            this.categoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.categoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaIdText.Location = new System.Drawing.Point(543, 52);
            this.categoriaIdText.Name = "categoriaIdText";
            this.categoriaIdText.Size = new System.Drawing.Size(183, 26);
            this.categoriaIdText.TabIndex = 34;
            this.categoriaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoriaIdText_KeyDown);
            // 
            // subcategoriaText
            // 
            this.subcategoriaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subcategoriaText.Location = new System.Drawing.Point(543, 176);
            this.subcategoriaText.Name = "subcategoriaText";
            this.subcategoriaText.ReadOnly = true;
            this.subcategoriaText.Size = new System.Drawing.Size(268, 26);
            this.subcategoriaText.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Subcategoria";
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(732, 133);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 39;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // subcategoriaIdText
            // 
            this.subcategoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.subcategoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subcategoriaIdText.Location = new System.Drawing.Point(543, 137);
            this.subcategoriaIdText.Name = "subcategoriaIdText";
            this.subcategoriaIdText.Size = new System.Drawing.Size(183, 26);
            this.subcategoriaIdText.TabIndex = 38;
            this.subcategoriaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.subcategoriaIdText_KeyDown);
            // 
            // almacenText
            // 
            this.almacenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.almacenText.Location = new System.Drawing.Point(543, 262);
            this.almacenText.Name = "almacenText";
            this.almacenText.ReadOnly = true;
            this.almacenText.Size = new System.Drawing.Size(268, 26);
            this.almacenText.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Almacen";
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(732, 219);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 43;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // almacenIdText
            // 
            this.almacenIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.almacenIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.almacenIdText.Location = new System.Drawing.Point(543, 223);
            this.almacenIdText.Name = "almacenIdText";
            this.almacenIdText.Size = new System.Drawing.Size(183, 26);
            this.almacenIdText.TabIndex = 42;
            this.almacenIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.almacenIdText_KeyDown);
            // 
            // unidadMinimaText
            // 
            this.unidadMinimaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unidadMinimaText.Location = new System.Drawing.Point(141, 176);
            this.unidadMinimaText.Name = "unidadMinimaText";
            this.unidadMinimaText.ReadOnly = true;
            this.unidadMinimaText.Size = new System.Drawing.Size(268, 26);
            this.unidadMinimaText.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "Unidad minima";
            // 
            // button8
            // 
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(330, 133);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 37);
            this.button8.TabIndex = 47;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // unidadMinimaIdText
            // 
            this.unidadMinimaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.unidadMinimaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unidadMinimaIdText.Location = new System.Drawing.Point(141, 137);
            this.unidadMinimaIdText.Name = "unidadMinimaIdText";
            this.unidadMinimaIdText.Size = new System.Drawing.Size(183, 26);
            this.unidadMinimaIdText.TabIndex = 46;
            this.unidadMinimaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.unidadMinimaIdText_KeyDown);
            // 
            // ventana_reporte_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 519);
            this.Controls.Add(this.unidadMinimaText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.unidadMinimaIdText);
            this.Controls.Add(this.almacenText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.almacenIdText);
            this.Controls.Add(this.subcategoriaText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.subcategoriaIdText);
            this.Controls.Add(this.categoriaText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.categoriaIdText);
            this.Controls.Add(this.itebisText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.referenciaText);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.itebisIdText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productoText);
            this.Name = "ventana_reporte_producto";
            this.Text = "ventana_reporte_producto";
            this.Load += new System.EventHandler(this.ventana_reporte_producto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.productoText, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.itebisIdText, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.referenciaText, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.itebisText, 0);
            this.Controls.SetChildIndex(this.categoriaIdText, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.categoriaText, 0);
            this.Controls.SetChildIndex(this.subcategoriaIdText, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.subcategoriaText, 0);
            this.Controls.SetChildIndex(this.almacenIdText, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.almacenText, 0);
            this.Controls.SetChildIndex(this.unidadMinimaIdText, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.unidadMinimaText, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox productoText;
        private Button button5;
        private TextBox itebisIdText;
        private Label label2;
        private TextBox referenciaText;
        private Label label3;
        private TextBox itebisText;
        private TextBox categoriaText;
        private Label label4;
        private Button button4;
        private TextBox categoriaIdText;
        private TextBox subcategoriaText;
        private Label label5;
        private Button button6;
        private TextBox subcategoriaIdText;
        private TextBox almacenText;
        private Label label6;
        private Button button7;
        private TextBox almacenIdText;
        private TextBox unidadMinimaText;
        private Label label7;
        private Button button8;
        private TextBox unidadMinimaIdText;
    }
}