using puntoVenta.formularios_base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace puntoVenta.Contabilidad
{
    public partial class busqueda_cuenta_contable : FormBusqueda
    {

        
        public busqueda_cuenta_contable()
        {
            InitializeComponent();
            loadVentana();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        [Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
        public class ucInheritedDataGridView : DataGridView { }
        private void busqueda_cuenta_contable_Load(object sender, EventArgs e)
        {

        }
        public override void loadVentana()
        {
            this.Text = "Busqueda Cuenta Contable";
            buscar();
        }
        public override void Seleccionar()
        {
            if (MessageBox.Show("Desea seleccionar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string codigo = "";
                    //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    pasado(codigo.ToString());
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error pasando: " + ex.ToString());
                }
            }
        }
        public override void buscar()
        {
            string sql = "";
            sql = "select codigo,descripcion,numero_cuenta,estado from catalogo_cuentas where codigo>0";
            if (descripcionText.Text.Trim() != "")
            {
                sql += " and descripcion like '%" + descripcionText.Text.Trim() + "%' ";
            }
            if (mantenimiento == false)
            {
                //debe de ser siempre activo para poder usar 
                sql += " and estado='1'";
            }
            DataSet ds = Clases.utilidades.ejecutarcomando(sql);
            dataGridView1.Rows.Clear();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }
        public virtual void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
