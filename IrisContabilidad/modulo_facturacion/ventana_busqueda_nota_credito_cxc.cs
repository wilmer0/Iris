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
    public partial class ventana_busqueda_nota_credito_cxc : formBase
    {
        //objetos
        private cxc_nota_credito notaCredito;
        utilidades utilidades = new utilidades();
        private nota_credito_debito_concepto concepto;
        private empleado cajero;
        private venta venta;
        private cliente cliente;


        //listas
        private List<cxc_nota_credito> listaNotasCreditos;
        List<cxc_nota_credito> listaNotasCreditosTemporal;


        //modelos
        private modeloCxcNotaCredito modeloNotaCredito = new modeloCxcNotaCredito();
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloVenta modeloVenta=new modeloVenta();
        modeloCliente modeloCliente=new modeloCliente();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int cont = 0;

        public ventana_busqueda_nota_credito_cxc()
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
                if (listaNotasCreditos == null)
                {
                    listaNotasCreditos = new List<cxc_nota_credito>();
                    listaNotasCreditos = modeloNotaCredito.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaNotasCreditos.ForEach(x =>
                {
                    venta = modeloVenta.getVentaById(x.codigoVenta);

                    concepto = new nota_credito_debito_concepto();
                    concepto = modeloConcepto.getConceptoById(x.codigoConcepto);
                    
                    cajero = new empleado();
                    cajero = modeloEmpleado.getEmpleadoByCajeroId(x.codigoEmpleado);

                    cliente = modeloCliente.getClienteById(x.codigoCliente);

                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), concepto.concepto, cliente.nombre,venta.codigo,venta.ncf,x.monto.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cxc_nota_credito getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                notaCredito = modeloNotaCredito.getNotaCreditoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return notaCredito;
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
        private void ventana_busqueda_nota_credito_cxc_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                listaNotasCreditos = modeloNotaCredito.getListaCompleta();
                listaNotasCreditosTemporal = new List<cxc_nota_credito>();

                //filtrar por id
                if (radioId.Checked == true)
                {
                    listaNotasCreditos = listaNotasCreditos.FindAll(x => x.codigo.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por cliente
                if (radioCliente.Checked == true)
                {
                    listaNotasCreditos = listaNotasCreditos.FindAll(x => (cliente = modeloCliente.getClienteById(x.codigoCliente)).nombre.ToLower().Contains(nombreText.Text.ToLower()));
                }

                //filtrar por concepto
                if (radioConcepto.Checked == true)
                {
                    listaNotasCreditos = listaNotasCreditos.FindAll(x =>(concepto = modeloConcepto.getConceptoById(x.codigoConcepto)).concepto.ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por monto
                if (radioMonto.Checked == true)
                {
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaNotasCreditos = listaNotasCreditos.FindAll(x => x.monto <= Convert.ToDecimal(nombreText.Text));
                    }
                }
                
                //por ncf venta
                if (radioNCFVenta.Checked == true)
                {
                    listaNotasCreditos = listaNotasCreditos.FindAll(x => (venta = modeloVenta.getVentaById(x.codigoVenta)).ncf.ToLower().Contains(nombreText.Text.ToLower()));
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
