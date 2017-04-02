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
using IrisContabilidad.clases_reportes;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;
using Microsoft.Reporting.WinForms;


namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_nota_debito_cxc : formBase
    {
        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        //cxcNotaCredito
        private venta venta;
        private cliente cliente;
        private cxc_nota_debito notaDebito;
        private nota_credito_debito_concepto concepto;

        //modelos
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloVenta modeloVenta = new modeloVenta();
        modeloCxcNotaDebito modeloNotaDebito = new modeloCxcNotaDebito();
        ModeloReporte modeloReporte=new ModeloReporte();


        //listas
        private List<nota_credito_debito_concepto> listaConcepto; 



        public ventana_nota_debito_cxc()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana nota de debito (cxc)");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                loadConceptos();
                if (notaDebito != null)
                {
                    notaCreditoIdText.Text = notaDebito.codigo.ToString();

                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    venta = modeloVenta.getVentaById(notaDebito.codigoVenta);
                    ventaIdText.Text = venta.codigo.ToString();
                    NcfText.Text = venta.ncf;

                    concepto = modeloConcepto.getConceptoById(notaDebito.codigoConcepto);
                    conceptoComboBox.SelectedValue = concepto.codigo;

                    montoText.Text = notaDebito.monto.ToString("N");
                    fechaText.Text = utilidades.getFechaddMMyyyy(notaDebito.fecha);
                    detalleText.Text = notaDebito.detalle;

                    activoCheck.Checked = Convert.ToBoolean(notaDebito.activo);
                }
                else
                {
                    notaCreditoIdText.Focus();
                    notaCreditoIdText.SelectAll();

                    notaCreditoIdText.Text = "";
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
                if (montoText.Text == "")
                {
                    MessageBox.Show("Falta el monto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    montoText.Focus();
                    montoText.SelectAll();
                    return false;
                }
                DateTime f;
                if (DateTime.TryParse(fechaText.Text, out f) == false)
                {
                    MessageBox.Show("formato fecha incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fechaText.Focus();
                    fechaText.SelectAll();
                    return false;
                }
                if (detalleText.Text == "")
                {
                    MessageBox.Show("Falta el detalle", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detalleText.Focus();
                    detalleText.SelectAll();
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
                if (notaDebito == null)
                {
                    notaDebito = new cxc_nota_debito();
                    crear = true;
                    notaDebito.codigo = modeloNotaDebito.getNext();
                }
                notaDebito.fecha = Convert.ToDateTime(fechaText.Text);
                notaDebito.codigoCliente = venta.codigo_cliente;
                notaDebito.codigoConcepto = Convert.ToInt16(conceptoComboBox.SelectedValue);
                notaDebito.activo = Convert.ToBoolean(activoCheck.Checked);
                notaDebito.codigoVenta = venta.codigo;
                notaDebito.detalle = detalleText.Text;
                notaDebito.monto = Convert.ToDecimal(montoText.Text);
                notaDebito.codigoEmpleado = empleado.codigo;


                if (crear == true)
                {
                    //se agrega
                    if ((modeloNotaDebito.agregarNotaDebito(notaDebito)) == true)
                    {
                        notaDebito = null;
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
                    if ((modeloNotaDebito.modificarNotaDebito(notaDebito)) == true)
                    {
                        notaDebito = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        notaDebito = null;
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
        public void loadVenta()
        {
            try
            {
                ventaIdText.Text = "";
                NcfText.Text = "";
                if (venta != null)
                {
                    ventaIdText.Text = venta.codigo.ToString();
                    NcfText.Text = venta.ncf;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  loadVenta.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_nota_debito_cxc_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void notaCreditoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    notaDebito = modeloNotaDebito.getNotaDebitoById(Convert.ToInt16(notaCreditoIdText.Text));
                    if (notaDebito != null)
                    {
                        loadVentana();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void ventaIdText_KeyDown(object sender, KeyEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_nota_debito_cxc ventana = new ventana_busqueda_nota_debito_cxc();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult== DialogResult.OK)
            {
                notaDebito = ventana.getObjeto();
                loadVentana();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_venta ventana = new ventana_busqueda_venta();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.ShowDialog()== DialogResult.OK)
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
            notaDebito = null;
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (notaDebito != null)
            {
                modeloReporte.imprimirNotaDebitoCxc(notaDebito.codigo);
            }
        }
    }
}
