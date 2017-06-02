using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_busqueda_compra : formBase
    {

        //objetos
        private compra compra;
        private sucursal sucursal;
        private suplidor suplidor;
        utilidades utilidades=new utilidades();
        private empleado empleado;


        //listas
        private List<compra> listaCompra;


        //modelos
        private modeloCompra modeloCompra = new modeloCompra();
        private modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        private int index = 0;


        public ventana_busqueda_compra()
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
                if(listaCompra == null)
                {
                    listaCompra = new List<compra>();
                    listaCompra = modeloCompra.getListaCompra();
                }
                
                //se limpia el grid si tiene datos
                if(dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCompra.ForEach(x =>
                {
                    empleado =new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    compra = new compra();
                    compra = modeloCompra.getCompraById(x.codigo);
                    suplidor=new suplidor();
                    suplidor = modeloSuplidor.getSuplidorById(x.cod_suplidor);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), utilidades.getFechaddMMyyyy(x.fecha_limite),suplidor.nombre,x.ncf,x.tipo_compra,empleado.nombre);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public compra getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                compra = modeloCompra.getCompraById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return compra;
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
        private void ventana_busqueda_compra_Load(object sender, EventArgs e)
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
                    listaCompra = modeloCompra.getListaCompra();
                    //nombre
                    if (todoRadioButton.Checked == true)
                    {
                        listaCompra =listaCompra.FindAll(x => x.codigo==Convert.ToInt16(nombreText.Text) || 
                            x.numero_factura.ToLower().Contains(nombreText.Text.ToLower()) || x.ncf.ToLower().Contains(nombreText.Text.ToLower())
                            || x.tipo_compra.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //suplidor
                    if (suplidorRadioButton.Checked == true)
                    {
                        suplidor = modeloSuplidor.getSuplidorByNombre(nombreText.Text);
                        listaCompra = listaCompra.FindAll(x => x.cod_suplidor.ToString().Contains(suplidor.codigo.ToString()));
                    }
                    //ncf
                    if (ncfRadionButton.Checked == true)
                    {
                        listaCompra = listaCompra.FindAll(x => x.ncf.ToLower().Contains(nombreText.Text)).ToList();
                    }
                    //numero compra
                    if (numeroCompraRadioButton.Checked == true)
                    {
                        listaCompra = listaCompra.FindAll(x => x.numero_factura.Contains(nombreText.Text)).ToList();
                    }
                    //tipo compra
                    if (tipoCompraRadionButton.Checked == true)
                    {
                        listaCompra = listaCompra.FindAll(x => x.tipo_compra.ToLower().Contains(nombreText.Text.ToLower()));
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

        private void button3_Click(object sender, EventArgs e)
        {
            loadLista();
        }
    }
}
