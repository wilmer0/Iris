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
    public partial class ventana_busqueda_nota_debito_cxc : formBase
    { 
        //objetos
        private cxc_nota_debito notaDebito;
        utilidades utilidades = new utilidades();
        private nota_credito_debito_concepto concepto;
        private empleado cajero;
        private venta venta;
        private cliente cliente;


        //listas
        private List<cxc_nota_debito> listaNotasDebitos;


        //modelos
        private modeloCxcNotaDebito modeloNotaDebito = new modeloCxcNotaDebito();
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int cont = 0;


        public ventana_busqueda_nota_debito_cxc()
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
                if (listaNotasDebitos == null)
                {
                    listaNotasDebitos = new List<cxc_nota_debito>();
                    listaNotasDebitos = modeloNotaDebito.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaNotasDebitos.ForEach(x =>
                {
                    venta = modeloVenta.getVentaById(x.codigoVenta);

                    concepto = new nota_credito_debito_concepto();
                    concepto = modeloConcepto.getConceptoById(x.codigoConcepto);

                    cajero = new empleado();
                    cajero = modeloEmpleado.getEmpleadoByCajeroId(x.codigoEmpleado);

                    cliente = modeloCliente.getClienteById(x.codigoCliente);

                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), concepto.concepto, cliente.nombre, venta.codigo, venta.ncf, x.monto.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cxc_nota_debito getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                notaDebito = modeloNotaDebito.getNotaDebitoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return notaDebito;
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
        public void filtrar()
        {
            try
            {
                listaNotasDebitos = modeloNotaDebito.getListaCompleta();

                //filtrar por id
                if (radioId.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => x.codigo.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por cliente
                if (radioCliente.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (cliente = modeloCliente.getClienteById(x.codigoCliente)).nombre.ToLower().Contains(nombreText.Text.ToLower()));
                }

                //filtrar por concepto
                if (radioConcepto.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (concepto = modeloConcepto.getConceptoById(x.codigoConcepto)).concepto.ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por monto
                if (radioMonto.Checked == true)
                {
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaNotasDebitos = listaNotasDebitos.FindAll(x => x.monto <= Convert.ToDecimal(nombreText.Text));
                    }
                }

                //por ncf venta
                if (radioNCFVenta.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (venta = modeloVenta.getVentaById(x.codigoVenta)).ncf.ToLower().Contains(nombreText.Text.ToLower()));
                }

                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
        private void ventana_busqueda_nota_debito_cxc_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filtrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void cambiarFiltro()
        {
            if (radioId.Checked == true)
            {
                radioCliente.Checked = true;
            }
            else if (radioCliente.Checked==true)
            {
                radioConcepto.Checked = true;
            }else if (radioConcepto.Checked == true)
            {
                radioMonto.Checked = true;
            } else if (radioNCFVenta.Checked == true)
            {
                radioId.Checked = true;
            }
        }
        private void ventana_busqueda_nota_debito_cxc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cambiarFiltro();
            }
        }
    }
}
