using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_nota_credito_cxc : formBase
    {
        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        //cxcNotaCredito
        private venta venta;
        private ventaDevolucion ventaDevolucion;
        private cliente cliente;
        private cxc_nota_credito notaCredito;
        private nota_credito_debito_concepto concepto;
      


        //modelos
        modeloNotaCreditoDebitoConcepto modeloConcepto=new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloVenta modeloVenta=new modeloVenta();
        modeloCxcNotaCredito modeloNotaCredito=new modeloCxcNotaCredito();
        ModeloReporte modeloReporte=new ModeloReporte();
        private modeloVentaDevolucion modeloVentaDevolucion=new modeloVentaDevolucion();

        //listas
        private List<nota_credito_debito_concepto> listaConcepto;
        private List<ventaDevolucionDetalle> listaVentaDevoluciondetalle; 


        public ventana_nota_credito_cxc()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana nota de credito (cxc)");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                loadConceptos();
                if (notaCredito != null)
                {
                    notaCreditoIdText.Text = notaCredito.codigo.ToString();

                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    venta = modeloVenta.getVentaById(notaCredito.codigoVenta);
                    ventaIdText.Text = venta.codigo.ToString();
                    NcfText.Text = venta.ncf;

                    concepto = modeloConcepto.getConceptoById(notaCredito.codigoConcepto);
                    conceptoComboBox.SelectedValue = concepto.codigo;

                    montoText.Text = notaCredito.monto.ToString("N");
                    fechaText.Text = utilidades.getFechaddMMyyyy(notaCredito.fecha);
                    detalleText.Text = notaCredito.detalle;

                    activoCheck.Checked = Convert.ToBoolean(notaCredito.activo);
                }
                else
                {
                    notaCreditoIdText.Focus();
                    notaCreditoIdText.SelectAll();

                    notaCreditoIdText.Text = "";
                    ventaDevolucion = null;
                    loadVentaDevolucion();
                    venta = null;
                    ventaIdText.Text = "";
                    NcfText.Text = "";
                    concepto = null;
                    montoText.Text = "";
                    fechaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    detalleText.Text = "";
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadConceptos()
        {
            try
            {
                listaConcepto = new List<nota_credito_debito_concepto>();
                listaConcepto = modeloConcepto.getListaCompleta();
                conceptoComboBox.DisplayMember = "concepto";
                conceptoComboBox.ValueMember = "codigo";
                conceptoComboBox.DataSource = listaConcepto;
                conceptoComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadConceptos.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar nombre
                if (conceptoComboBox.Text == "")
                {
                    MessageBox.Show("Falta el concepto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conceptoComboBox.Focus();
                    conceptoComboBox.SelectAll();
                    return false;
                }
                //validar monto
                if (montoText.Text == "")
                {
                    MessageBox.Show("Falta el monto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    montoText.Focus();
                    montoText.SelectAll();
                    return false;
                }
                //validar fecha
                DateTime f;
                if (DateTime.TryParse(fechaText.Text, out f) == false)
                {
                    MessageBox.Show("formato fecha incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fechaText.Focus();
                    fechaText.SelectAll();
                    return false;
                }
                //validar detalle o nota
                if (detalleText.Text == "")
                {
                    MessageBox.Show("Falta el detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detalleText.Focus();
                    detalleText.SelectAll();
                    return false;
                }
                //validar venta
                if (venta == null)
                {
                    MessageBox.Show("Falta seleccionar la venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();
                    return false;
                }
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                //validando campos necesarios
                if (validarGetAction() == false)
                {
                    return;
                }

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                bool crear = false;
                //se instancia el empleado si esta nulo
                if (notaCredito == null)
                {
                    notaCredito = new cxc_nota_credito();
                    crear = true;
                    notaCredito.codigo = modeloNotaCredito.getNext();
                }
                notaCredito.fecha = Convert.ToDateTime(fechaText.Text);
                notaCredito.codigoCliente = venta.codigo_cliente;
                notaCredito.codigoConcepto = Convert.ToInt16(conceptoComboBox.SelectedValue);
                notaCredito.activo = Convert.ToBoolean(activoCheck.Checked);
                notaCredito.codigoVenta = venta.codigo;
                notaCredito.detalle = detalleText.Text;
                notaCredito.monto = Convert.ToDecimal(montoText.Text);
                notaCredito.codigoEmpleado = empleado.codigo;
                if (ventaDevolucion != null)
                {
                    notaCredito.codigoDevolucion = ventaDevolucion.codigo;
                    venta = modeloVenta.getVentaById(ventaDevolucion.codigo_venta);
                }

                if (crear == true)
                {
                    //se agrega
                    if ((modeloNotaCredito.agregarNotaCredito(notaCredito)) == true)
                    {
                        notaCredito = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloNotaCredito.modificarNotaCredito(notaCredito)) == true)
                    {
                        notaCredito = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        notaCredito = null;
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //objeto main debe estar nulo
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_nota_credito_cxc_Load(object sender, EventArgs e)
        {
            ventana_busqueda_venta ventana=new ventana_busqueda_venta();

        }

        public void loadVenta()
        {
            try
            {
                ventaIdText.Text = "";
                numeroVentaText.Text = "";
                NcfText.Text = "";
                
                if (venta != null)
                {
                    ventaIdText.Text = venta.codigo.ToString();
                    numeroVentaText.Text = venta.numero_factura.ToString();
                    NcfText.Text = venta.ncf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentaDevolucion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVentaDevolucion()
        {
            try
            {
                ventaIdText.Text = "";
                numeroVentaText.Text = "";
                NcfText.Text = "";
                if (ventaDevolucion != null)
                {
                    //validar que esa devolucion no este en uso en una nota credito
                    if (notaCredito == null)
                    {
                        //no hay nota credito, la devolucion no se puede encontrar registrada
                        if (modeloNotaCredito.getNotaCreditoByDevolucionId(ventaDevolucion.codigo) != null)
                        {
                            MessageBox.Show("Esta Devolución ya se le asigno su respectiva nota de credito, y no puede volver a usarse");
                            button3_Click(null,null);
                            return;
                        }
                    }
                    venta = modeloVenta.getVentaById(ventaDevolucion.codigo_venta);
                    ventaIdText.Text = venta.codigo.ToString();
                    numeroVentaText.Text = venta.numero_factura.ToString();
                    NcfText.Text = venta.ncf;

                    listaVentaDevoluciondetalle =modeloVentaDevolucion.getListaVentaDevolucionDetalleByDevolucionId(ventaDevolucion.codigo);
                    montoText.Text = listaVentaDevoluciondetalle.Sum(s => s.monto_total).ToString("N");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentaDevolucion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_venta ventana=new ventana_busqueda_venta();
            ventana.Owner = this;
            ventana.ShowDialog();
            if((venta==ventana.getObjeto())!=null)
            {
                venta = ventana.getObjeto();
                loadVenta();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notaCredito = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_nota_credito_cxc ventana=new ventana_busqueda_nota_credito_cxc();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult== DialogResult.OK)
            {
                notaCredito = ventana.getObjeto();
                loadVentana();
            }
        }

        private void notaCreditoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    notaCredito = modeloNotaCredito.getNotaCreditoById(Convert.ToInt16(notaCreditoIdText.Text));
                    if (notaCredito != null)
                    {
                        loadVentana();
                    }
                }
            }
            catch (Exception)
            {   
            }
        }

       
        private void conceptoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    montoText.Focus();
                    montoText.SelectAll();
                }
            }
            catch (Exception)
            {

            }
        }

        private void montoText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    fechaText.Focus();
                    fechaText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void fechaText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                if (e.KeyCode == Keys.Enter)
                {
                    detalleText.Focus();
                    detalleText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void detalleText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    activoCheck.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void montoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoText.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (notaCredito != null)
            {
                modeloReporte.imprimirNotaCreditoCxc(notaCredito.codigo);
            }
        }

        private void devolucionIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    conceptoComboBox.Focus();
                    conceptoComboBox.DroppedDown = true;

                    venta = modeloVenta.getVentaById(Convert.ToInt16(ventaIdText.Text));
                    if (venta != null)
                    {
                        loadVenta();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButtonVenta.Checked == true)
            {
                ventana_busqueda_venta ventana = new ventana_busqueda_venta();
                ventana.Owner = this;
                ventana.ShowDialog();

                if (ventana.DialogResult == DialogResult.OK)
                {
                    venta = ventana.getObjeto();
                    loadVenta();
                }
            }
            else
            {
                ventana_busqueda_venta_devolucion ventana=new ventana_busqueda_venta_devolucion();
                ventana.Owner = this;
                ventana.ShowDialog();
                if (ventana.DialogResult == DialogResult.OK)
                {
                    ventaDevolucion = ventana.getObjeto();
                    loadVentaDevolucion();
                }
            }
            
        }

        private void radioButtonDevolucion_Leave(object sender, EventArgs e)
        {
            montoText.Enabled = !(bool) radioButtonDevolucion.Checked;
        }

        private void radioButtonVenta_Leave(object sender, EventArgs e)
        {
            montoText.Enabled = (bool)radioButtonVenta.Checked;
            ventaDevolucion = null;
            loadVentaDevolucion();
        }
    }
}
