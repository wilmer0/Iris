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

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_busqueda_vendedor : formBase
    {

        //objetos
        private vendedor vendedor;
        private empleado empleado;


        //listas
        private List<vendedor> listaVendedor;
        private List<vendedor> listaVendedorTemp;


        //modelos
        modeloVendedor modeloVendedor=new modeloVendedor();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



        public ventana_busqueda_vendedor(bool mantenimiento=false)
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
                if (listaVendedor == null)
                {
                    listaVendedor = new List<vendedor>();
                    listaVendedor = modeloVendedor.getListaCompleta(mantenimiento);
                    listaVendedorTemp = listaVendedor;
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                if (listaVendedor == null)
                {
                    return;
                }
                //se agrega todos los datos de la lista en el gridView
                foreach(var x in listaVendedor.ToList())
                {
                    empleado=new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empelado);
                    vendedor=new vendedor();
                    dataGridView1.Rows.Add(x.codigo,empleado.nombre,x.porciento_ganancia,x.activo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public vendedor getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                if (fila < 0)
                {
                    return null;
                }
                vendedor = modeloVendedor.getVendedorById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return vendedor;
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
        private void ventana_busqueda_vendedor_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    empleado = new empleado();

                    listaVendedor = modeloVendedor.getListaCompleta();
                    listaVendedorTemp = new List<vendedor>();

                    //por nombre
                    listaVendedor.ForEach(x =>
                    {
                        empleado = new empleado();
                        empleado = modeloEmpleado.getEmpleadoById(x.codigo_empelado);
                        vendedor = new vendedor();
                        vendedor = x;
                        if (empleado.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                        {
                            //cajero = modeloCajero.getCajeroById(empleado.codigo);
                            listaVendedorTemp.Add(vendedor);
                        }
                    });
                    listaVendedor = listaVendedorTemp;
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

        private void button3_Click(object sender, EventArgs e)
        {
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
    }
}
