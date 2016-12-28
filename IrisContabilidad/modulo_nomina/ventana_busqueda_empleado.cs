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
    public partial class ventana_busqueda_empleado : formBase
    {
        //objetos
        private empleado empleado;
        private departamento departamento;
        private cargo cargo;

        //listas
        private List<empleado> listaEmpleado;



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloDepartamento modeloDepartamento=new modeloDepartamento();
        modeloCargo modeloCargo=new modeloCargo();

        //variables 
        private bool mantenimiento = false;
        private int fila = 0;


        public ventana_busqueda_empleado()
        {
            InitializeComponent();
            this.tituloLabel.Text = this.Text;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaEmpleado == null)
                {
                    listaEmpleado = new List<empleado>();
                    listaEmpleado =modeloEmpleado.getListaCompleta();
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaEmpleado.ForEach(x =>
                {
                    departamento=new departamento();
                    cargo=new cargo();
                    departamento = modeloDepartamento.getDepartamentoById(x.codigo_departamento);
                    cargo = modeloCargo.getCargoById(x.codigo_cargo);
                    dataGridView1.Rows.Add(x.codigo, x.nombre,x.identificacion,departamento.nombre,cargo.nombre, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public empleado getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                empleado = modeloEmpleado.getEmpleadoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return empleado;
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
        private void ventana_busqueda_empleado_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaEmpleado = modeloEmpleado.getListaCompleta();
                    listaEmpleado = listaEmpleado.FindAll(x => x.nombre.Contains(nombreText.Text));
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
            listaEmpleado = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
