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
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_nota_credito_cxp : formBase
    {
        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        //cxcNotaCredito
        private compra compra;
        private suplidor suplidor;
        private cxp_nota_credito notaCredito;
        private nota_credito_debito_concepto concepto;



        //modelos
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCompra modeloCompra = new modeloCompra();
        modeloCxpNotaCredito modeloNotaCredito = new modeloCxpNotaCredito();
        ModeloReporte modeloReporte = new ModeloReporte();


        //listas
        private List<nota_credito_debito_concepto> listaConcepto;


        public ventana_nota_credito_cxp()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana nota de credito (cxp)");
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

                    compraIdText.Focus();
                    compraIdText.SelectAll();

                    compra = modeloCompra.getCompraById(notaCredito.codigoCompra);
                    compraIdText.Text = compra.codigo.ToString();
                    NcfText.Text = compra.ncf;

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
                    compra = null;
                    compraIdText.Text = "";
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
                if (compra == null)
                {
                    MessageBox.Show("Falta seleccionar la venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    compraIdText.Focus();
                    compraIdText.SelectAll();
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
                    notaCredito = new cxp_nota_credito();
                    crear = true;
                    notaCredito.codigo = modeloNotaCredito.getNext();
                }
                notaCredito.fecha = Convert.ToDateTime(fechaText.Text);
                notaCredito.codigoSuplidor = compra.cod_suplidor;
                notaCredito.codigoConcepto = Convert.ToInt16(conceptoComboBox.SelectedValue);
                notaCredito.activo = Convert.ToBoolean(activoCheck.Checked);
                notaCredito.codigoCompra = compra.codigo;
                notaCredito.detalle = detalleText.Text;
                notaCredito.monto = Convert.ToDecimal(montoText.Text);
                notaCredito.codigoEmpleado = empleado.codigo;


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
        public void loadCompra()
        {
            try
            {
                compraIdText.Text = "";
                NcfText.Text = "";
                if (compra != null)
                {
                    compraIdText.Text = compra.codigo.ToString();
                    numeroCompraText.Text = compra.numero_factura.ToString();
                    NcfText.Text = compra.ncf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentaDevolucion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_nota_credito_cxp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_nota_credito_cxp ventana = new ventana_busqueda_nota_credito_cxp();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                notaCredito = ventana.getObjeto();
                loadVentana();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (notaCredito != null)
            {
                modeloReporte.imprimirNotaCreditoCxp(notaCredito.codigo);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButtonCompra.Checked == true)
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
            else
            {
                //compra devolucion
            }
            
        }
    }
}
