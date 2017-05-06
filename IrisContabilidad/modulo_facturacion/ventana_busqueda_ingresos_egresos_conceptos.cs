using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_busqueda_ingresos_egresos_conceptos : formBase
    {

        //objetos
        private caja_ingresos_egresos_conceptos concepto;

        //listas
        private List<caja_ingresos_egresos_conceptos> listaConceptos;

        //modelos
        private modeloCajaIngresosEgresosConceptos modeloConcepto = new modeloCajaIngresosEgresosConceptos();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        
        public ventana_busqueda_ingresos_egresos_conceptos(bool mantenimiento=false)
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
                if (listaConceptos == null)
                {
                    listaConceptos = new List<caja_ingresos_egresos_conceptos>();
                    listaConceptos = modeloConcepto.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaConceptos.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public caja_ingresos_egresos_conceptos getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                concepto = modeloConcepto.getConceptoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return concepto;
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
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void ventana_busqueda_ingresos_egresos_conceptos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaConceptos = modeloConcepto.getListaCompleta();
                    listaConceptos = listaConceptos.FindAll(x => x.nombre.Contains(nombreText.Text));
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
            listaConceptos = null;
            loadLista();
        }
    }
}
