using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_busqueda_venta_devolucion : formBase
    {
        //objetos
        private ventaDevolucion ventaDevolucion;
        utilidades utilidades = new utilidades();
        private nota_credito_debito_concepto notaCreditoDebitoConcepto;
        private venta venta;
        private cajero cajero;
        

        //listas
        private List<ventaDevolucion> listaventaDevolucion;
        private List<ventaDevolucionDetalle> listaVentaDevolucionDetalle; 

        //modelos
        private modeloVentaDevolucion modeloDevolucion = new modeloVentaDevolucion();
        modeloNotaCreditoDebitoConcepto modeloNotaCreditoDebitoConcepto=new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        private modeloCxcNotaCredito modeloCxcNotaCredito = new modeloCxcNotaCredito();
        modeloVenta modeloVenta=new modeloVenta();
        modeloCajero modeloCajero=new modeloCajero();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int cont = 0;
        public ventana_busqueda_venta_devolucion(bool mantenimiento=false)
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
                if (listaventaDevolucion == null)
                {
                    listaventaDevolucion = new List<ventaDevolucion>();
                    listaventaDevolucion = modeloDevolucion.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaventaDevolucion.ForEach(x =>
                {
                    venta=new venta();
                    venta = modeloVenta.getVentaById(x.codigo_venta);
                    listaVentaDevolucionDetalle=new List<ventaDevolucionDetalle>();
                    listaVentaDevolucionDetalle = modeloDevolucion.getListaVentaDevolucionDetalleByDevolucionId(x.codigo);
                    decimal monto = listaVentaDevolucionDetalle.Sum(s => s.monto_total);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha),venta.ncf,venta.numero_factura,monto.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ventaDevolucion getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                ventaDevolucion = modeloDevolucion.getDevolucionById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return ventaDevolucion;
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

                listaventaDevolucion = modeloDevolucion.getListaCompleta();
              

                //filtrar por id
                if (radioID.Checked == true)
                {
                    listaventaDevolucion = listaventaDevolucion.FindAll(x => x.codigo.ToString().Contains(nombreText.Text));
                }

                //filtrar por ncf
                if (radioNCF.Checked == true)
                {
                    listaventaDevolucion = listaventaDevolucion.FindAll(x => (venta=modeloVenta.getVentaById(x.codigo_venta)).ncf.ToLower().Contains(nombreText.Text.ToLower()));
                }

                //filtrar por fecha
                if (radioFecha.Checked == true)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(nombreText.Text, out fecha) == false)
                    {
                        MessageBox.Show("Error, formato fecha incorrecto");
                        nombreText.Focus();
                        nombreText.SelectAll();
                        return;
                    }
                    fecha = Convert.ToDateTime(nombreText.Text);
                    listaventaDevolucion = listaventaDevolucion.FindAll(x => x.fecha<=fecha.Date);
                }


                //filtrar por monto
                if (radioMonto.Checked == true)
                {
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaventaDevolucion = listaventaDevolucion.FindAll(x => (listaVentaDevolucionDetalle=modeloDevolucion.getListaVentaDevolucionDetalleByDevolucionId(x.codigo)).Sum(s=> s.monto_total)<=dinero);
                    }
                }

              
               
                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
        private void ventana_busqueda_venta_devolucion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void ventana_busqueda_venta_devolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (radioID.Checked == true)
                {
                    radioNCF.Checked = true;
                }
                else if (radioNCF.Checked == true)
                {
                    radioFecha.Checked = true;
                }
                else if (radioFecha.Checked == true)
                {
                    radioMonto.Checked = true;
                }
                else if (radioMonto.Checked == true)
                {
                    radioID.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaventaDevolucion = null;
            loadLista();
        }
    }
}
