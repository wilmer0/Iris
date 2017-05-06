using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_busqueda_ciudad : formBase
    {

        //objetos
        private ciudad ciudad;

        //listas
        private List<ciudad> listaCiudad;

        //modelos
        private modeloCiudad modeloCiudad = new modeloCiudad();

        //variables 
        public bool mantenimiento=false;
        private int fila = 0;


       
        public ventana_busqueda_ciudad(bool mantenimiento=false)
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
                if (listaCiudad == null)
                {
                    listaCiudad = new List<ciudad>();
                    listaCiudad = modeloCiudad.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCiudad.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre,x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ciudad getObjeto()
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
                ciudad = modeloCiudad.getCiudadById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return ciudad;
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
        private void ventana_busqueda_ciudad_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_ciudad_KeyDown(object sender, KeyEventArgs e)
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
                    listaCiudad = modeloCiudad.getListaCompleta();
                    listaCiudad = listaCiudad.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaCiudad = null;
            loadLista();
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
