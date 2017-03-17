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
    public partial class ventana_busqueda_venta : formBase
    {

        //objetos
        private venta venta;
        private empleado empleado;
        private cliente cliente;
        utilidades utilidades=new utilidades();

        //listas
        private List<venta> listaVenta;
        
        //modelos
        private modeloVenta modeloVenta = new modeloVenta();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloCliente modeloCliente=new modeloCliente();
        
        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int index = 0;
        string TipoVenta = "";
        private int idCliente = 0;

        public ventana_busqueda_venta(bool mantenimiento =false)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public ventana_busqueda_venta(int idcliente)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = false;
            this.idCliente = idcliente;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaVenta == null)
                {
                    listaVenta = new List<venta>();
                    listaVenta = modeloVenta.getListaCompleta();
                }
                if (idCliente != 0)
                {
                    listaVenta = listaVenta.FindAll(x => x.codigo_cliente == idCliente).ToList();
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaVenta.ForEach(x =>
                {
                    TipoVenta = "--------";
                    cliente = modeloCliente.getClienteById(x.codigo_cliente);
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    TipoVenta = x.tipo_venta;
                    if (TipoVenta.ToLower()=="cre")
                    {
                        TipoVenta = "Credito";
                    }else if (TipoVenta.ToLower() == "con")
                    {
                        TipoVenta = "Contado";
                    }else if (TipoVenta.ToLower() == "ped")
                    {
                        TipoVenta = "Pedido";
                    }
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha),x.ncf,cliente.nombre,TipoVenta,empleado.nombre);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public venta getObjeto()
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
                venta=modeloVenta.getVentaById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return venta;
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
        private void ventana_busqueda_venta_Load(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_venta_KeyDown(object sender, KeyEventArgs e)
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
                button3_Click(null, null);
            }
        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaVenta = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void nombreText_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    listaVenta = new List<venta>();
                    listaVenta = modeloVenta.getListaCompleta();
                    if (idCliente != 0)
                    {
                        listaVenta = listaVenta.FindAll(x => x.codigo_cliente == idCliente).ToList();
                    }
                    //por id
                    if (radioButtonId.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.codigo.ToString().Contains(nombreText.Text.ToLower()));
                    }
                    //por ncf
                    if (radioButtonNCF.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.ncf.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //por cliente
                    if (radioButtonCliente.Checked == true)
                    {
                        listaVenta =listaVenta.FindAll(x =>(cliente = modeloCliente.getClienteById(x.codigo_cliente)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                    }
                    //por tipo venta
                    if (radioButtonTipoVenta.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.tipo_venta.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //categoria
                    if (radioButtonEmpleado.Checked == true)
                    {
                        listaVenta =listaVenta.FindAll(x =>(empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                    }
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
