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

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_busqueda_cargo : formBase
    {

        //objetos
        private cargo cargo;

        //listas
        private List<cargo> listaCargo;



        //modelos
        private modeloCargo modeloCargo = new modeloCargo();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;


      
        public ventana_busqueda_cargo(bool mantenimiento=false)
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
                if (listaCargo == null)
                {
                    listaCargo = new List<cargo>();
                    listaCargo = modeloCargo.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCargo.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.id, x.nombre,x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cargo getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                cargo = modeloCargo.getCargoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return cargo;
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
        private void ventana_busqueda_cargo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                this.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaCargo = null;
            loadLista();
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
                    listaCargo = modeloCargo.getListaCompleta();
                    listaCargo = listaCargo.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
