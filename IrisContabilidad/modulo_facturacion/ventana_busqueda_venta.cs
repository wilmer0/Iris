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


        public ventana_busqueda_venta()
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
                if (listaVenta == null)
                {
                    listaVenta = new List<venta>();
                    listaVenta = modeloVenta.getListaCompleta();
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
                    //por id
                    if (radioButtonId.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.codigo.ToString().Contains(nombreText.Text.ToLower()));
                    }
                    //por cedula
                    if (radioButtonCedula.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.cedula.Contains(nombreText.Text));
                    }
                    //por rnc
                    if (radioButtonRnc.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.rnc.Contains(nombreText.Text));
                    }
                    //categoria
                    if (radioButtonCatgoria.Checked == true)
                    {
                        index = 0;
                        List<cliente> listaTemporal = new List<cliente>();
                        listaTemporal = listaVenta;
                        listaTemporal.ForEach(x =>
                        {
                            categoria = modeloCategoria.getCategoriaClienteById(x.codigo_categoria);
                            if (categoria != null)
                            {
                                if (!categoria.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                                {
                                    //si no contiene el nombre de la categoria escrita se borrara de la lista principal
                                    listaVenta.RemoveAt(index);
                                }
                            }
                            index++;
                        });
                    }
                    //telefono
                    if (radioButtonTelefono.Checked == true)
                    {
                        listaVenta = listaVenta.FindAll(x => x.telefono1.Contains(nombreText.Text) || x.telefono2.Contains(nombreText.Text));
                    }
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
    }
}
