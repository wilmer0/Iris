using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_busqueda_sucursal : formBase
    {

        //objetos
        private sucursal sucursal;

        //listas
        private List<sucursal> listaSucursal;

        //modelos
        private modeloSucursal modeloSucursal=new modeloSucursal();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



       
        public ventana_busqueda_sucursal(bool mantenimiento=false)
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
                if (listaSucursal == null)
                {
                    listaSucursal=new List<sucursal>();
                    listaSucursal = modeloSucursal.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaSucursal.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.secuencia, x.direccion, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_busqueda_sucursal_Load(object sender, EventArgs e)
        {

        }

        public sucursal getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                sucursal = modeloSucursal.getSucursalById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          getAction();
        }

        public void getAction()
        {
            this.DialogResult = DialogResult.OK;
            getObjeto();
            this.Close();
        }
        public  void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaSucursal = null;
            loadLista();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaSucursal = modeloSucursal.getListaCompleta();
                    listaSucursal = listaSucursal.FindAll(x => x.secuencia.Contains(nombreText.Text) || x.direccion.ToLower().Contains(nombreText.Text.ToLower()));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_sucursal_KeyDown(object sender, KeyEventArgs e)
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
                button3_Click(null,null);
            }
        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
