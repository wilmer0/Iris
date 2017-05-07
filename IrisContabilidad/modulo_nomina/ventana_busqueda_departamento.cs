using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_busqueda_departamento : formBase
    {
        //objetos
        private departamento departamento;

        //listas
        private List<departamento> listaDepartamento;



        //modelos
        private modeloDepartamento modeloDepartamento = new modeloDepartamento();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;


      
        public ventana_busqueda_departamento(bool mantenimiento=false)
        {
            InitializeComponent();
            this.tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaDepartamento == null)
                {
                    listaDepartamento = new List<departamento>();
                    listaDepartamento = modeloDepartamento.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaDepartamento.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public departamento getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                departamento = modeloDepartamento.getDepartamentoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return departamento;
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
        private void ventana_busqueda_departamento_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaDepartamento = modeloDepartamento.getListaCompleta();
                    listaDepartamento = listaDepartamento.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaDepartamento = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
