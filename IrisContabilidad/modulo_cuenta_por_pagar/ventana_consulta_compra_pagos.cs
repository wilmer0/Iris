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
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_consulta_compra_pagos : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleadoSingleton;
        private empleado empleado;
        private empleado empleadoFiltro;
        private suplidor suplidor;
        private suplidor suplidorFiltro ;
        private compra compra;
        private metodo_pago metodoPago;
        private compra_vs_pagos compraPago;
        

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloSuplidor modeloSuplidor=new modeloSuplidor();
        modeloCompra modeloCompra=new modeloCompra();
        modeloMetodoPago modeloMetodoPago=new modeloMetodoPago();
        modeloPago modeloPago=new modeloPago();
        
        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<compra_vs_pagos_detalles> listaCompraPagosDetalles;
        private List<compra_vs_pagos_detalles> listaCompraPagosDetallesTemporal;
        private List<metodo_pago> listaMetodoPago; 

        //variables
        private int indice = 0;

        public ventana_consulta_compra_pagos()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana consulta pagos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                suplidor = null;
                suplidorIdText.Focus();
                suplidorIdText.SelectAll();

                suplidorIdText.Text = "";
                suplidorText.Text = "";

                compra = null;
                CompraIdText.Text = "";
                numeroCompraText.Text = "";

                metodoPago = null;
                
                empleado = null;
                empleadoIdText.Text = "";
                empleadoText.Text="";

                dataGridView1.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {
                ////validar que el cliente no sea nulo
                //if (suplidor == null)
                //{
                //    suplidorIdText.Focus();
                //    suplidorIdText.SelectAll();
                //    MessageBox.Show("Debe seleccionar un suplidor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                ////validar que hayan datos en el grid
                //if (dataGridView1.Rows.Count == 0)
                //{
                //    suplidorIdText.Focus();
                //    suplidorIdText.SelectAll();
                //    MessageBox.Show("No hay facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                ////validar que tenga cobros seleccionado
                //existe = false;
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    if (Convert.ToBoolean(row.Cells[5].Value) == true)
                //    {
                //        existe = true;
                //    }
                //}
                //if (existe == false)
                //{
                //    MessageBox.Show("No hay cobros seleccionado para anular", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                if (!validarGetAcion())
                {
                    return;
                }
               
                listaCompraPagosDetalles=new List<compra_vs_pagos_detalles>();
                listaCompraPagosDetalles = modeloPago.getListaCompraPagosDetallesActivos();

                loadPagos();


            }
            catch (Exception ex)
            {
                compra = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void loadEmpleado()
        {
            try
            {
                empleadoIdText.Text = "";
                empleadoText.Text = "";
                if (empleado != null)
                {
                    empleadoIdText.Text = empleado.codigo.ToString();
                    empleadoText.Text = empleado.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadMetodoPago()
        {
            try
            {
                metodoPagoComboBox.Items.Clear();
                metodoPagoComboBox.DisplayMember = "metodo";
                metodoPagoComboBox.ValueMember = "codigo";
                listaMetodoPago=new List<metodo_pago>();
                listaMetodoPago = modeloMetodoPago.getListaMetodoPago();
                metodoPagoComboBox.DataSource = listaMetodoPago;
                metodoPagoComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadMetodoPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCompra()
        {
            try
            {
                CompraIdText.Text = "";
                numeroCompraText.Text = "";
                if (compra != null)
                {
                    CompraIdText.Text = compra.codigo.ToString();
                    numeroCompraText.Text = compra.numero_factura;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSuplidor()
        {
            try
            {
                suplidorIdText.Text = "";
                suplidorText.Text = "";
                if (suplidor != null)
                {
                    suplidorIdText.Text = suplidor.codigo.ToString();
                    suplidorText.Text = suplidor.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void getListaFiltrada()
        {
            try
            {

                if (listaCompraPagosDetalles == null)
                {
                    listaCompraPagosDetalles=new List<compra_vs_pagos_detalles>();
                    return;
                }
                //filtrar la lista
                //suplidor
                if (suplidor != null)
                {
                    listaCompraPagosDetalles =listaCompraPagosDetalles.FindAll(x =>(suplidorFiltro = modeloSuplidor.getSuplidorByCompraPago(x.codigo)).codigo.ToString().Contains(suplidor.codigo.ToString())).ToList();
                }
                //compra
                if (compra != null)
                {
                    listaCompraPagosDetalles = listaCompraPagosDetalles.FindAll(x => x.codigo_compra == compra.codigo).ToList();
                }
                //metodo pago
                if (metodoPagoComboBox.Text != "")
                {
                    listaCompraPagosDetalles = listaCompraPagosDetalles.FindAll(x => x.codigo_metodo_pago == Convert.ToInt16(metodoPagoComboBox.SelectedValue.ToString())).ToList();
                }
                //empleado
                if (empleado != null)
                {
                    listaCompraPagosDetalles = listaCompraPagosDetalles.FindAll(x => (empleadoFiltro = modeloEmpleado.getEmpleadoByCompraPago(x.codigo)).codigo.ToString().Contains(empleado.codigo.ToString())).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaFiltrada.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void loadPagos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                
                getListaFiltrada();

                indice= 0;
                listaCompraPagosDetalles.ForEach(x =>
                {
                    compra = new compra();
                    compra = modeloCompra.getCompraById(x.codigo_compra);
                    
                    compraPago = new compra_vs_pagos();
                    compraPago = modeloCompra.getCompraPagoById(x.codigo_pago);
                    
                    empleado = new empleado();
                    empleado = modeloEmpleado.getEmpleadoByCompraPago(x.codigo);
                    
                    metodoPago=new metodo_pago();
                    metodoPago = modeloMetodoPago.getMetodoPagoById(x.codigo_metodo_pago);

                    decimal montoPago = x.monto_pagado + x.monto_descontado;

                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(compraPago.fecha), empleado.nombre, metodoPago.metodo, compra.numero_factura, montoPago.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadPagos.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_consulta_compra_pagos_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana=new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_compra ventana = new ventana_busqueda_compra();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                compra = ventana.getObjeto();
                loadCompra();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void suplidorIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(suplidorIdText.Text));
                    loadSuplidor();
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
