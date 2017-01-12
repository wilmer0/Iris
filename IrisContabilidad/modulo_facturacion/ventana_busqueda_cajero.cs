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
    public partial class ventana_busqueda_cajero : formBase
    {

        //objetos
        private caja caja;
        private cajero cajero;
        private empleado empleado;


        //listas
        private List<cajero> listaCajero;
        private List<cajero> listaCajeroTemp; 


        //modelos
        private modeloCaja modeloCaja = new modeloCaja();
        modeloCajero modeloCajero=new modeloCajero();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;




        public ventana_busqueda_cajero(bool mantenimiento=false)
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
                if (listaCajero == null)
                {
                    listaCajero = new List<cajero>();
                    listaCajero = modeloCajero.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCajero.ForEach(x =>
                {
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    caja = modeloCaja.getCajaById(x.codigo_caja);
                    dataGridView1.Rows.Add(x.codigo, empleado.nombre, caja.nombre+"-"+caja.secuencia, x.activo);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cajero getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                cajero = modeloCajero.getCajeroById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return cajero;
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
        private void ventana_busqueda_cajero_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    empleado=new empleado();
                    listaCajero = modeloCajero.getListaCompleta();
                    listaCajeroTemp = listaCajeroTemp;
                    listaCajero = new List<cajero>();
                    foreach (cajero x in listaCajeroTemp)
                    {
                        cajero=new cajero();
                        empleado=new empleado();
                        empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                        if (empleado.nombre.ToLower().Contains(nombreText.Text))
                        {
                            cajero = modeloCajero.getCajeroById(x.codigo);
                            listaCajero.Add(cajero);
                        }
                    }
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
            listaCajeroTemp = null;
            listaCajero = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
    }
}
