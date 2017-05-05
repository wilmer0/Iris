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
using Message = System.Web.Services.Description.Message;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_desglose_dinero : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private desglose_dinero desgloseDinero;
        private compra compra;
        private venta venta;
        private compra_vs_pagos pago;
        compra_vs_pagos_detalles pagoDetalle;
        private venta_vs_cobros_detalles cobroDetalle;
        

        
        //modelos
        modeloCompra modeloCompra=new modeloCompra();
        modeloVenta modeloVenta=new modeloVenta();
        ModeloReporte modeloReporte = new ModeloReporte();


        //listas 
        private List<compra_detalle> listaCompraDetalles;
        private List<venta_detalle> listaVentaDetalles;
        List<compra_vs_pagos_detalles> listaPagoDetalle = new List<compra_vs_pagos_detalles>();
        List<venta_vs_cobros_detalles> listaCobroDetalle=new List<venta_vs_cobros_detalles>(); 

        //variables
        private decimal montoTotalPagar = 0;
        private decimal montoTotalCobrar = 0;
        private decimal montoEsperado=0;
        private decimal montoItebis=0;
        private decimal montoDescuento=0; //el descuento que me trae producto por producto
        public decimal  montoDescuentoFactura = 0;//para aplicar descuento a toda la fctura
        private decimal montoDevuelta = 0;
        private decimal montoEfectivo = 0;
        private decimal montoDeposito = 0;
        private decimal montoCheque = 0;
        private decimal montoTarjeta=0;

        //constructor para compras
        public ventana_desglose_dinero(compra compra,List<compra_detalle> listaDetalle )
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana desglose dinero");
            this.Text = tituloLabel.Text;
            this.compra = compra;
            this.listaCompraDetalles = listaDetalle;
            loadVentana();
        }

        //constructor para ventas,pedidos
        public ventana_desglose_dinero(venta venta, List<venta_detalle> listaDetalle)
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana desglose dinero");
            this.Text = tituloLabel.Text;
            this.venta = venta;
            this.listaVentaDetalles = listaDetalle;
            loadVentana();
        }


        public void loadVentana()
        {
            try
            {
                montoEsperado = 0;
                montoDescuento = 0;
                montoItebis = 0;
                if (compra != null)
                {
                    //compra
                    //sacando monto esperado, monto itebis, monto descuento
                    foreach(var x in listaCompraDetalles)
                    {
                        montoEsperado += (x.cantidad*x.precio)-x.monto_descuento;
                        montoItebis += x.monto_itebis;
                        montoDescuento += x.monto_descuento;
                    }
                    MontoTotalText.Text = montoEsperado.ToString("N");
                    MontoItebisText.Text = montoItebis.ToString("N");
                    montoDevueltoText.Text = montoDescuento.ToString("N");

                    //focus
                    montoEfectivoText.Text = montoEsperado.ToString("N");
                    montoEfectivoText.Focus();
                    montoEfectivoText.SelectAll();
                }
                else if(venta!=null)
                {
                    //venta
                    //sacando monto esperado, monto itebis, monto descuento
                    foreach (var x in listaVentaDetalles)
                    {
                        montoEsperado += (x.cantidad * x.precio)-x.monto_descuento;
                        montoItebis += x.monto_itebis;
                        montoDescuento += x.monto_descuento;
                    }
                    MontoTotalText.Text = montoEsperado.ToString("N");
                    MontoItebisText.Text = montoItebis.ToString("N");
                    montoDevueltoText.Text = montoDescuento.ToString("N");

                    //focus
                    montoEfectivoText.Text = montoEsperado.ToString("N");
                    montoEfectivoText.Focus();
                    montoEfectivoText.SelectAll();
                }


                calcular();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //1-efectivo
                //2-deposito
                //3-cheque
                listaPagoDetalle=new List<compra_vs_pagos_detalles>();
                listaCobroDetalle=new List<venta_vs_cobros_detalles>();

                if (compra != null)
                {
                    //compra
                    #region compra
                    //validar que el descuento sea menor que el monto
                    if (montoDescuentoFactura > montoEsperado)
                    {
                        MessageBox.Show("El monto descontado no puede ser mayor al monto total de la factura", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    //validar si pagara con efectivo
                    if (Convert.ToDecimal(montoEfectivoText.Text) > 0)
                    {
                        pagoDetalle = new compra_vs_pagos_detalles();
                        pagoDetalle.codigo = 0;
                        pagoDetalle.codigo_pago = 0;
                        pagoDetalle.codigo_compra = 0;
                        pagoDetalle.codigo_metodo_pago = 1;
                        pagoDetalle.monto_descontado = 0;
                        pagoDetalle.monto_pagado = Convert.ToDecimal(montoEfectivoText.Text);
                        pagoDetalle.monto_sub_total = pagoDetalle.monto_pagado - pagoDetalle.monto_descontado;
                        pagoDetalle.activo = true;
                        listaPagoDetalle.Add(pagoDetalle);
                    }
                    //validar si pagara con deposito
                    if (Convert.ToDecimal(montoDepositoText.Text) > 0)
                    {
                        if (depositoBancoText.Text == "")
                        {
                            depositoBancoText.Focus();
                            depositoBancoText.SelectAll();
                            MessageBox.Show("Falta el banco", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        pagoDetalle = new compra_vs_pagos_detalles();
                        pagoDetalle.codigo = 0;
                        pagoDetalle.codigo_pago = 0;
                        pagoDetalle.codigo_compra = 0;
                        pagoDetalle.codigo_metodo_pago = 2;
                        pagoDetalle.monto_descontado = 0;
                        pagoDetalle.monto_pagado = Convert.ToDecimal(montoDepositoText.Text);
                        pagoDetalle.monto_sub_total = pagoDetalle.monto_pagado - pagoDetalle.monto_descontado;
                        pagoDetalle.activo = true;
                        listaPagoDetalle.Add(pagoDetalle);
                    }
                    //validar si pagara con cheque
                    if (Convert.ToDecimal(montoChequeText.Text) > 0)
                    {
                        if (numeroChequeText.Text == "")
                        {
                            numeroChequeText.Focus();
                            numeroChequeText.SelectAll();
                            MessageBox.Show("Falta el número de cheque", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return false;
                        }
                        if (chequeBancoText.Text == "")
                        {
                            chequeBancoText.Focus();
                            chequeBancoText.SelectAll();
                            MessageBox.Show("Falta el banco", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        pagoDetalle = new compra_vs_pagos_detalles();
                        pagoDetalle.codigo = 0;
                        pagoDetalle.codigo_pago = 0;
                        pagoDetalle.codigo_compra = 0;
                        pagoDetalle.codigo_metodo_pago = 3;
                        pagoDetalle.monto_descontado = 0;
                        pagoDetalle.monto_pagado = Convert.ToDecimal(montoChequeText.Text);
                        pagoDetalle.monto_sub_total = pagoDetalle.monto_pagado - pagoDetalle.monto_descontado;
                        pagoDetalle.activo = true;
                        listaPagoDetalle.Add(pagoDetalle);
                    }
                    montoTotalPagar = 0;
                    //validar montos si son iguales para poder pagar
                    listaPagoDetalle.ForEach(x =>
                    {
                        montoTotalPagar += x.monto_pagado - x.monto_descontado;
                    });
                    if (Convert.ToDecimal(montoEsperado) > montoTotalPagar + montoDescuentoFactura)
                    {
                        MessageBox.Show("Falta dinero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        montoEfectivoText.Focus();
                        montoEfectivoText.SelectAll();
                        return false;
                    }
                    #endregion
                }
                else if (venta != null)
                {
                    //venta
                    #region venta
                    //validar que el descuento sea menor que el monto
                    if (montoDescuentoFactura > montoEsperado)
                    {
                        MessageBox.Show("El monto descontado no puede ser mayor al monto total de la factura", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    //validar si cobrar con efectivo
                    #region
                    if (Convert.ToDecimal(montoEfectivoText.Text) > 0)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = 0;
                        cobroDetalle.codigo_cobro = 0;
                        cobroDetalle.codigo_venta = 0;
                        cobroDetalle.codigo_metodo_cobro = 1;
                        cobroDetalle.monto_descontado = 0;
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(montoEfectivoText.Text);
                        cobroDetalle.monto_subtotal = cobroDetalle.monto_cobrado - cobroDetalle.monto_descontado;
                        cobroDetalle.activo = true;
                        listaCobroDetalle.Add(cobroDetalle);
                    }
                    #endregion
                    
                    //validar si cobrar con deposito
                    #region
                    if (Convert.ToDecimal(montoDepositoText.Text) > 0)
                    {
                        if (depositoBancoText.Text == "")
                        {
                            depositoBancoText.Focus();
                            depositoBancoText.SelectAll();
                            MessageBox.Show("Falta el banco", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = 0;
                        cobroDetalle.codigo_cobro = 0;
                        cobroDetalle.codigo_venta = 0;
                        cobroDetalle.codigo_metodo_cobro = 2;
                        cobroDetalle.monto_descontado = 0;
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(montoDepositoText.Text);
                        cobroDetalle.monto_subtotal = cobroDetalle.monto_cobrado - cobroDetalle.monto_descontado;
                        cobroDetalle.activo = true;
                        listaCobroDetalle.Add(cobroDetalle);
                    }
                    #endregion
                    
                    //validar si cobrar con cheque
                    #region
                    if (Convert.ToDecimal(montoChequeText.Text) > 0)
                    {
                        if (numeroChequeText.Text == "")
                        {
                            numeroChequeText.Focus();
                            numeroChequeText.SelectAll();
                            MessageBox.Show("Falta el número de cheque", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return false;
                        }
                        if (chequeBancoText.Text == "")
                        {
                            chequeBancoText.Focus();
                            chequeBancoText.SelectAll();
                            MessageBox.Show("Falta el banco", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = 0;
                        cobroDetalle.codigo_cobro = 0;
                        cobroDetalle.codigo_venta = 0;
                        cobroDetalle.codigo_metodo_cobro = 3;
                        cobroDetalle.monto_descontado = 0;
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(montoChequeText.Text);
                        cobroDetalle.monto_subtotal = cobroDetalle.monto_cobrado - cobroDetalle.monto_descontado;
                        cobroDetalle.activo = true;
                        listaCobroDetalle.Add(cobroDetalle);
                    }
                    #endregion

                    //validar si cobrar con tarjeta
                    #region
                    if (Convert.ToDecimal(montoTarjetaText.Text) > 0)
                    {
                        cobroDetalle = new venta_vs_cobros_detalles();
                        cobroDetalle.codigo = 0;
                        cobroDetalle.codigo_cobro = 0;
                        cobroDetalle.codigo_venta = 0;
                        cobroDetalle.codigo_metodo_cobro = 4;
                        cobroDetalle.monto_descontado = 0;
                        cobroDetalle.monto_cobrado = Convert.ToDecimal(montoTarjetaText.Text);
                        cobroDetalle.monto_subtotal = cobroDetalle.monto_cobrado - cobroDetalle.monto_descontado;
                        cobroDetalle.activo = true;
                        listaCobroDetalle.Add(cobroDetalle);
                    }
                    #endregion

                    montoTotalCobrar = 0;
                    //validar montos si son iguales para poder cobrar
                    listaCobroDetalle.ForEach(x =>
                    {
                        montoTotalCobrar += x.monto_cobrado;
                    });
                    if (Convert.ToDecimal(montoEsperado) > montoTotalPagar + montoDescuentoFactura)
                    {
                        MessageBox.Show("Falta dinero por cobrar, monto establecido no concuerda con el monto esperado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        montoEfectivoText.Focus();
                        montoEfectivoText.SelectAll();
                        return false;
                    }
                    #endregion
                
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
                if (!validarGetAction())
                {
                    return;
                }

                //if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}

                if (compra != null)
                {
                    //compra
                    if (modeloCompra.agregarCompra(compra, listaCompraDetalles) == true)
                    {
                        compra_vs_pagos pago = new compra_vs_pagos();
                        compra_vs_pagos_detalles pagoDetalle = new compra_vs_pagos_detalles();

                        //pago encabezado
                        pago.codigo = modeloCompra.getNextPago();
                        pago.fecha = DateTime.Today;
                        pago.detalle = "";
                        pago.cod_empleado = empleado.codigo;
                        pago.activo = true;
                        pago.cod_empleado_anular = 0;
                        pago.motivo_anulado = "";
                        pago.cuadrado = false;

                        //asigando que todos los pagos afecten a esta compra
                        listaPagoDetalle.ForEach(x=> x.codigo_compra=compra.codigo);

                        if (modeloCompra.setCompraPago(compra, pago, listaPagoDetalle) == true)
                        {
                            if(MessageBox.Show("Se agregó, desea Imprimir la compra?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                            {
                                modeloReporte.imprimirCompra(compra.codigo);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if(venta!=null)
                {
                    //venta
                    if (modeloVenta.agregarVenta(venta, listaVentaDetalles) == true)
                    {
                        venta_vs_cobros cobro = new venta_vs_cobros();
                        venta_vs_cobros_detalles cobroDetalle = new venta_vs_cobros_detalles();

                        //pago encabezado
                        cobro.codigo = modeloVenta.getNextCobro();
                        cobro.fecha = DateTime.Today;
                        cobro.detalle = "";
                        cobro.cod_empleado = empleado.codigo;
                        cobro.activo = true;
                        cobro.cod_empleado_anular = 0;
                        cobro.motivo_anulado = "";
                        cobro.cuadrado = false;

                        //asigando que todos los pagos afecten a esta compra
                        listaCobroDetalle.ForEach(x=> x.codigo_venta=venta.codigo);

                        if (modeloVenta.setVentaCobro(venta, cobro, listaCobroDetalle) == true)
                        {
                            if(MessageBox.Show("Se agregó, desea Imprimir la venta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                            {
                                modeloReporte.imprimirVenta(venta.codigo);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                    this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                desgloseDinero = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ventana_desglose_dinero_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                getAction();
            }
        }

        private void efectivoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoEfectivoText.Text);
        }

        private void tarjetaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoTarjetaText.Text);
        }

        private void chequeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoChequeText.Text);
        }

        private void depositoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoDepositoText.Text);
        }

        private void devueltoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoDevueltoText.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoDescuentoText.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numeroChequeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        public void calcular()
        {
            try
            {
                montoDescuento = 0;
                montoDescuentoFactura = Convert.ToDecimal(montoDescuentoText.Text);
                montoEfectivo = Convert.ToDecimal(montoEfectivoText.Text);
                montoDeposito = Convert.ToDecimal(montoDepositoText.Text);
                montoCheque = Convert.ToDecimal(montoChequeText.Text);
                montoTarjeta = Convert.ToDecimal(montoTarjetaText.Text);
                montoDevuelta = 0;

                montoTotalPagar = (montoEfectivo + montoDeposito + montoCheque + montoTarjeta);
                montoDevuelta = montoTotalPagar - montoEsperado;
                montoDevuelta = montoDevuelta + montoDescuentoFactura;
                montoDevueltoText.Text = montoDevuelta.ToString("N");
            }
            catch (Exception ex)
            {
                montoEfectivoText.Text = montoEsperado.ToString("N");
                montoChequeText.Text = "0.00";
                montoDepositoText.Text = "0.00";
                montoTarjetaText.Text = "0.00";
                montoDescuentoText.Text = "0.00";
                montoDevueltoText.Text = "0.00";
                MessageBox.Show("Error calcular.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void montoEfectivoText_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void montoTarjetaText_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void montoChequeText_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void montoDepositoText_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void descuentoText_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void montoEfectivoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoTarjetaText.Focus();
                montoTarjetaText.SelectAll();
            }
        }

        private void montoTarjetaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoChequeText.Focus();
                montoChequeText.SelectAll();
            }
        }

        private void montoChequeText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                numeroChequeText.Focus();
                numeroChequeText.SelectAll();
            }
        }

        private void numeroChequeText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                chequeBancoText.Focus();
                chequeBancoText.SelectAll();
            }
        }

        private void montoDepositoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                depositoBancoText.Focus();
                depositoBancoText.SelectAll();
            }
        }

        private void depositoBancoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoDescuentoText.Focus();
                montoDescuentoText.SelectAll();
            }
        }

        private void descuentoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }

        private void chequeBancoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoDepositoText.Focus();
                montoDepositoText.SelectAll();
            }
        }

        private void imprimirVenta()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimircompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimircompra()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimircompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
