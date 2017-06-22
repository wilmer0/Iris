using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_inventario
{
    partial class ventana_subcategoria_producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_subcategoria_producto));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CategoriaText = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.categoriaIdText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.subCategoriaIdText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 343);
            this.panel1.Size = new System.Drawing.Size(534, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(393, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(558, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(197, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CategoriaText);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.nombreText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.activoCheck);
            this.groupBox2.Controls.Add(this.categoriaIdText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 224);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // CategoriaText
            // 
            this.CategoriaText.BackColor = System.Drawing.Color.White;
            this.CategoriaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoriaText.Location = new System.Drawing.Point(170, 71);
            this.CategoriaText.MaxLength = 200;
            this.CategoriaText.Name = "CategoriaText";
            this.CategoriaText.ReadOnly = true;
            this.CategoriaText.Size = new System.Drawing.Size(236, 26);
            this.CategoriaText.TabIndex = 28;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(359, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 37);
            this.button5.TabIndex = 27;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // nombreText
            // 
            this.nombreText.BackColor = System.Drawing.Color.White;
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(170, 126);
            this.nombreText.MaxLength = 200;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(236, 26);
            this.nombreText.TabIndex = 14;
            this.nombreText.TextChanged += new System.EventHandler(this.nombreText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Categoria";
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(170, 168);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(68, 21);
            this.activoCheck.TabIndex = 21;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.CheckedChanged += new System.EventHandler(this.activoCheck_CheckedChanged);
            // 
            // categoriaIdText
            // 
            this.categoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.categoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriaIdText.Location = new System.Drawing.Point(170, 32);
            this.categoriaIdText.Name = "categoriaIdText";
            this.categoriaIdText.Size = new System.Drawing.Size(183, 26);
            this.categoriaIdText.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.subCategoriaIdText);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 80);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(359, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 37);
            this.button4.TabIndex = 24;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "SubCategoria";
            // 
            // subCategoriaIdText
            // 
            this.subCategoriaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.subCategoriaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subCategoriaIdText.Location = new System.Drawing.Point(170, 31);
            this.subCategoriaIdText.Name = "subCategoriaIdText";
            this.subCategoriaIdText.Size = new System.Drawing.Size(183, 26);
            this.subCategoriaIdText.TabIndex = 0;
            // 
            // ventana_subcategoria_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_subcategoria_producto";
            this.Text = "ventana_subcategoria_producto";
            this.Load += new System.EventHandler(this.ventana_subcategoria_producto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox2;
        private TextBox nombreText;
        private CheckBox activoCheck;
        private Label label2;
        private GroupBox groupBox1;
        private Button button4;
        private Label label1;
        private TextBox subCategoriaIdText;
        private Button button5;
        private Label label3;
        private TextBox categoriaIdText;
        private TextBox CategoriaText;
    }
}