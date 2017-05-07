using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_busqueda_cobros : formBase
    {
        //objetos
        private cliente cliente;
        private venta_vs_cobros ventaCobro;
        private empleado empleado;
        utilidades utilidades=new utilidades();

        //listas
        private List<venta_vs_cobros> listaVentaCobros;


        //modelos
        private modeloCliente modeloCliente = new modeloCliente();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloCobro modeloCobro=new modeloCobro();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int index = 0;



        public ventana_busqueda_cobros(bool mantenimiento=false)
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
                if (listaVentaCobros == null)
                {
                    listaVentaCobros = new List<venta_vs_cobros>();
                    listaVentaCobros = modeloCobro.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaVentaCobros.ForEach(x =>
                {
                    cliente=new cliente();
                    empleado=new empleado();
                    cliente = modeloCliente.getClienteByVentaCobro(x.codigo);
                    empleado = modeloEmpleado.getEmpleadoById(x.cod_empleado);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha),cliente.nombre,empleado.nombre);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public venta_vs_cobros getObjeto()
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
                ventaCobro = modeloCobro.getVentaCobroById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return ventaCobro;
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
        private void ventana_busqueda_cobros_Load(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_cobros_KeyDown(object sender, KeyEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaVentaCobros = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filtrar();
            }
        }

        public void filtrar()
        {
            try
            {
                    empleado = new empleado();
                    cliente = new cliente();
                    listaVentaCobros = modeloCobro.getListaCompleta();
                    //por id
                    if (radioButtonID.Checked == true)
                    {
                        listaVentaCobros = listaVentaCobros.FindAll(x => x.codigo.ToString().Contains(nombreText.Text.ToLower()));
                    }
                    //por fecha
                    if (radioButtonFecha.Checked == true)
                    {
                        DateTime fecha;
                        if (DateTime.TryParse(nombreText.Text, out fecha) != false)
                        {
                            fecha = Convert.ToDateTime(nombreText.Text);
                            listaVentaCobros = listaVentaCobros.FindAll(x => x.fecha <= fecha || x.fecha.ToString().Contains(fecha.ToString()));
                        }
                        else
                        {
                            nombreText.Focus();
                            nombreText.SelectAll();
                            MessageBox.Show("El formato de la fecha no es valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //por empleado
                    if (radioButtonEmpleado.Checked == true)
                    {
                        listaVentaCobros = listaVentaCobros.FindAll(x => (empleado = modeloEmpleado.getEmpleadoById(x.cod_empleado)).nombre.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //por cliente
                    if (radioButtonCliente.Checked == true)
                    {
                        listaVentaCobros = listaVentaCobros.FindAll(x => (cliente  = modeloCliente.getClienteByVentaCobro(x.codigo)).nombre.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //por detalle
                    if (radioButtonDetalle.Checked == true)
                    {
                        listaVentaCobros = listaVentaCobros.FindAll(x => x.detalle.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    loadLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
    }
}
