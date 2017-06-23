using System.ComponentModel;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_contabilidad
{
    partial class ventana_cuentas_contables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana_cuentas_contables));
            this.cuentaIdText = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.cuenta_label = new System.Windows.Forms.Label();
            this.numeroCuentaText = new System.Windows.Forms.TextBox();
            this.numeroCuentaLabel = new System.Windows.Forms.Label();
            this.nombre_label = new System.Windows.Forms.Label();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.cuentaPadreIdText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.cuentaPadreLabel = new System.Windows.Forms.Label();
            this.cuentaPadreText = new System.Windows.Forms.TextBox();
            this.radioCuentaAcumulativa = new System.Windows.Forms.RadioButton();
            this.radioCuentaMovimiento = new System.Windows.Forms.RadioButton();
            this.radioOrigenCredito = new System.Windows.Forms.RadioButton();
            this.radioOrigenDebito = new System.Windows.Forms.RadioButton();
            this.activoCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroCuentaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCuentaPadreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaPadreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroCuentaPadreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 555);
            this.panel1.Size = new System.Drawing.Size(952, 54);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(811, 5);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(976, 21);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(406, 5);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cuentaIdText
            // 
            this.cuentaIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cuentaIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaIdText.Location = new System.Drawing.Point(151, 23);
            this.cuentaIdText.Name = "cuentaIdText";
            this.cuentaIdText.Size = new System.Drawing.Size(183, 26);
            this.cuentaIdText.TabIndex = 118;
            this.cuentaIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuentaIdText_KeyDown);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(340, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 37);
            this.button7.TabIndex = 119;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cuenta_label
            // 
            this.cuenta_label.AutoSize = true;
            this.cuenta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuenta_label.Location = new System.Drawing.Point(60, 25);
            this.cuenta_label.Name = "cuenta_label";
            this.cuenta_label.Size = new System.Drawing.Size(67, 20);
            this.cuenta_label.TabIndex = 120;
            this.cuenta_label.Text = "Cuenta";
            // 
            // numeroCuentaText
            // 
            this.numeroCuentaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCuentaText.Location = new System.Drawing.Point(151, 123);
            this.numeroCuentaText.MaxLength = 19;
            this.numeroCuentaText.Name = "numeroCuentaText";
            this.numeroCuentaText.Size = new System.Drawing.Size(253, 26);
            this.numeroCuentaText.TabIndex = 122;
            this.numeroCuentaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numeroCuentaText_KeyDown);
            // 
            // numeroCuentaLabel
            // 
            this.numeroCuentaLabel.AutoSize = true;
            this.numeroCuentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCuentaLabel.Location = new System.Drawing.Point(45, 126);
            this.numeroCuentaLabel.Name = "numeroCuentaLabel";
            this.numeroCuentaLabel.Size = new System.Drawing.Size(82, 20);
            this.numeroCuentaLabel.TabIndex = 123;
            this.numeroCuentaLabel.Text = "# Cuenta";
            // 
            // nombre_label
            // 
            this.nombre_label.AutoSize = true;
            this.nombre_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_label.Location = new System.Drawing.Point(56, 79);
            this.nombre_label.Name = "nombre_label";
            this.nombre_label.Size = new System.Drawing.Size(71, 20);
            this.nombre_label.TabIndex = 125;
            this.nombre_label.Text = "Nombre";
            // 
            // nombreText
            // 
            this.nombreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreText.Location = new System.Drawing.Point(151, 74);
            this.nombreText.MaxLength = 150;
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(253, 26);
            this.nombreText.TabIndex = 124;
            this.nombreText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombreText_KeyDown);
            // 
            // cuentaPadreIdText
            // 
            this.cuentaPadreIdText.BackColor = System.Drawing.Color.SkyBlue;
            this.cuentaPadreIdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreIdText.Location = new System.Drawing.Point(151, 175);
            this.cuentaPadreIdText.Name = "cuentaPadreIdText";
            this.cuentaPadreIdText.Size = new System.Drawing.Size(183, 26);
            this.cuentaPadreIdText.TabIndex = 126;
            this.cuentaPadreIdText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuentaPadreIdText_KeyDown);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(340, 171);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 37);
            this.button6.TabIndex = 127;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cuentaPadreLabel
            // 
            this.cuentaPadreLabel.AutoSize = true;
            this.cuentaPadreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreLabel.Location = new System.Drawing.Point(9, 176);
            this.cuentaPadreLabel.Name = "cuentaPadreLabel";
            this.cuentaPadreLabel.Size = new System.Drawing.Size(118, 20);
            this.cuentaPadreLabel.TabIndex = 128;
            this.cuentaPadreLabel.Text = "Cuenta padre";
            // 
            // cuentaPadreText
            // 
            this.cuentaPadreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaPadreText.Location = new System.Drawing.Point(151, 214);
            this.cuentaPadreText.MaxLength = 19;
            this.cuentaPadreText.Name = "cuentaPadreText";
            this.cuentaPadreText.Size = new System.Drawing.Size(253, 26);
            this.cuentaPadreText.TabIndex = 129;
            // 
            // radioCuentaAcumulativa
            // 
            this.radioCuentaAcumulativa.AutoSize = true;
            this.radioCuentaAcumulativa.Checked = true;
            this.radioCuentaAcumulativa.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioCuentaAcumulativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCuentaAcumulativa.Location = new System.Drawing.Point(8, 39);
            this.radioCuentaAcumulativa.Name = "radioCuentaAcumulativa";
            this.radioCuentaAcumulativa.Size = new System.Drawing.Size(168, 21);
            this.radioCuentaAcumulativa.TabIndex = 130;
            this.radioCuentaAcumulativa.TabStop = true;
            this.radioCuentaAcumulativa.Text = "Cuenta acumulativa";
            this.radioCuentaAcumulativa.UseVisualStyleBackColor = true;
            this.radioCuentaAcumulativa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioCuentaAcumulativa_KeyDown);
            // 
            // radioCuentaMovimiento
            // 
            this.radioCuentaMovimiento.AutoSize = true;
            this.radioCuentaMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCuentaMovimiento.Location = new System.Drawing.Point(225, 39);
            this.radioCuentaMovimiento.Name = "radioCuentaMovimiento";
            this.radioCuentaMovimiento.Size = new System.Drawing.Size(163, 21);
            this.radioCuentaMovimiento.TabIndex = 131;
            this.radioCuentaMovimiento.Text = "Cuenta Movimiento";
            this.radioCuentaMovimiento.UseVisualStyleBackColor = true;
            this.radioCuentaMovimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioCuentaMovimiento_KeyDown);
            // 
            // radioOrigenCredito
            // 
            this.radioOrigenCredito.AutoSize = true;
            this.radioOrigenCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOrigenCredito.Location = new System.Drawing.Point(225, 28);
            this.radioOrigenCredito.Name = "radioOrigenCredito";
            this.radioOrigenCredito.Size = new System.Drawing.Size(130, 21);
            this.radioOrigenCredito.TabIndex = 133;
            this.radioOrigenCredito.Text = "Origen crédito";
            this.radioOrigenCredito.UseVisualStyleBackColor = true;
            this.radioOrigenCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioOrigenCredito_KeyDown);
            // 
            // radioOrigenDebito
            // 
            this.radioOrigenDebito.AutoSize = true;
            this.radioOrigenDebito.Checked = true;
            this.radioOrigenDebito.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioOrigenDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOrigenDebito.Location = new System.Drawing.Point(8, 28);
            this.radioOrigenDebito.Name = "radioOrigenDebito";
            this.radioOrigenDebito.Size = new System.Drawing.Size(125, 21);
            this.radioOrigenDebito.TabIndex = 132;
            this.radioOrigenDebito.TabStop = true;
            this.radioOrigenDebito.Text = "Origen debito";
            this.radioOrigenDebito.UseVisualStyleBackColor = true;
            this.radioOrigenDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radioOrigenDebito_KeyDown);
            // 
            // activoCheck
            // 
            this.activoCheck.AutoSize = true;
            this.activoCheck.Checked = true;
            this.activoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activoCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activoCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activoCheck.Location = new System.Drawing.Point(460, 214);
            this.activoCheck.Name = "activoCheck";
            this.activoCheck.Size = new System.Drawing.Size(83, 28);
            this.activoCheck.TabIndex = 134;
            this.activoCheck.Text = "Activo";
            this.activoCheck.UseVisualStyleBackColor = true;
            this.activoCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.activoCheck_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCuentaMovimiento);
            this.groupBox1.Controls.Add(this.radioCuentaAcumulativa);
            this.groupBox1.Location = new System.Drawing.Point(460, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 84);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo cuenta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioOrigenDebito);
            this.groupBox2.Controls.Add(this.radioOrigenCredito);
            this.groupBox2.Location = new System.Drawing.Point(460, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 72);
            this.groupBox2.TabIndex = 136;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Origen cuenta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.cuentaIdText);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.cuenta_label);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.activoCheck);
            this.groupBox3.Controls.Add(this.numeroCuentaText);
            this.groupBox3.Controls.Add(this.cuentaPadreText);
            this.groupBox3.Controls.Add(this.numeroCuentaLabel);
            this.groupBox3.Controls.Add(this.cuentaPadreIdText);
            this.groupBox3.Controls.Add(this.nombreText);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.nombre_label);
            this.groupBox3.Controls.Add(this.cuentaPadreLabel);
            this.groupBox3.Location = new System.Drawing.Point(16, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 250);
            this.groupBox3.TabIndex = 137;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(874, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(68, 54);
            this.button5.TabIndex = 138;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::IrisContabilidad.Properties.Resources.ayuda1;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(874, 25);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 54);
            this.button4.TabIndex = 137;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.numeroCuentaColumn,
            this.nombreColumn,
            this.idCuentaPadreColumn,
            this.cuentaPadreColumn,
            this.numeroCuentaPadreColumn});
            this.dataGridView1.Location = new System.Drawing.Point(16, 283);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(948, 266);
            this.dataGridView1.TabIndex = 138;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // idColumn
            // 
            this.idColumn.FillWeight = 50F;
            this.idColumn.HeaderText = "Id";
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            // 
            // numeroCuentaColumn
            // 
            this.numeroCuentaColumn.HeaderText = "No. cuenta";
            this.numeroCuentaColumn.Name = "numeroCuentaColumn";
            this.numeroCuentaColumn.ReadOnly = true;
            // 
            // nombreColumn
            // 
            this.nombreColumn.HeaderText = "Nombre";
            this.nombreColumn.Name = "nombreColumn";
            this.nombreColumn.ReadOnly = true;
            // 
            // idCuentaPadreColumn
            // 
            this.idCuentaPadreColumn.FillWeight = 50F;
            this.idCuentaPadreColumn.HeaderText = "Id";
            this.idCuentaPadreColumn.Name = "idCuentaPadreColumn";
            this.idCuentaPadreColumn.ReadOnly = true;
            // 
            // cuentaPadreColumn
            // 
            this.cuentaPadreColumn.HeaderText = "Cuenta padre";
            this.cuentaPadreColumn.Name = "cuentaPadreColumn";
            this.cuentaPadreColumn.ReadOnly = true;
            // 
            // numeroCuentaPadreColumn
            // 
            this.numeroCuentaPadreColumn.HeaderText = "No. cuenta";
            this.numeroCuentaPadreColumn.Name = "numeroCuentaPadreColumn";
            this.numeroCuentaPadreColumn.ReadOnly = true;
            // 
            // ventana_cuentas_contables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 621);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ventana_cuentas_contables";
            this.Text = "ventana_cuentas_contables";
            this.Load += new System.EventHandler(this.ventana_cuentas_contables_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox cuentaIdText;
        private Button button7;
        private Label cuenta_label;
        public TextBox numeroCuentaText;
        private Label numeroCuentaLabel;
        private Label nombre_label;
        public TextBox nombreText;
        private TextBox cuentaPadreIdText;
        private Button button6;
        private Label cuentaPadreLabel;
        public TextBox cuentaPadreText;
        private RadioButton radioCuentaAcumulativa;
        private RadioButton radioCuentaMovimiento;
        private RadioButton radioOrigenCredito;
        private RadioButton radioOrigenDebito;
        private CheckBox activoCheck;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        public Button button4;
        public Button button5;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn numeroCuentaColumn;
        private DataGridViewTextBoxColumn nombreColumn;
        private DataGridViewTextBoxColumn idCuentaPadreColumn;
        private DataGridViewTextBoxColumn cuentaPadreColumn;
        private DataGridViewTextBoxColumn numeroCuentaPadreColumn;
    }
}