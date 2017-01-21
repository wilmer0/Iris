using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_busqueda_suplidor : formBase
    {

        //objetos
        private suplidor suplidor;

        //listas
        private List<suplidor> listaSuplidor;

        //modelos
        private modeloSuplidor modeloSuplidor = new modeloSuplidor();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;

        public ventana_busqueda_suplidor(bool mantenimiento = false)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaSuplidor == null)
                {
                    listaSuplidor = new List<suplidor>();
                    listaSuplidor = modeloSuplidor.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaSuplidor.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public suplidor getObjeto()
        {
            try
            {
                //validar que tenga datos el datagrid
                if (dataGridView1.Rows.Count < 0)
                {
                    return null;
                }
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return suplidor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void getAction()
        {
            this.DialogResult = DialogResult.OK;
            getObjeto();
            this.Close();
        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ventana_busqueda_suplidor_Load(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_suplidor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                getAction();
            }
            if (e.KeyCode == Keys.F2)
            {
                button3_Click_1(null, null);
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaSuplidor = modeloSuplidor.getListaCompleta();
                    listaSuplidor = listaSuplidor.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaSuplidor = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
    }
}
