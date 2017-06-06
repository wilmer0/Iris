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
    public partial class ventana_cuadre_caja_usa : formBase
    {

        //variables
        private DateTime fechaFinal;

        //objetos
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private cuadre_caja cuadreCaja;
        private cajero cajero;
        private empleado empleadoSesion;
        private venta venta;
        private venta_detalle ventaDetalle;
        private egreso_caja egresoCaja;
        private ingreso_caja ingresoCaja;
        private compra_vs_pagos compraPago;
        private compra_vs_pagos_detalles compraPagoDetalle;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobrosDetalle;
        private compra compra;

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCuadreCaja modeloCuadreCaja = new modeloCuadreCaja();
        modeloCajero modeloCajero = new modeloCajero();
        modeloVenta modeloVenta = new modeloVenta();
        modeloEgresoCaja modeloEgreCaja = new modeloEgresoCaja();
        modeloIngresoCaja modeloIngresoCaja = new modeloIngresoCaja();
        modeloCompra modeloCompra = new modeloCompra();
        ModeloReporte modeloReporte = new ModeloReporte();

        //listas


        //variables
        private decimal montoTotalEfectivo = 0;

        private decimal montoTotalEfectivoEsperado = 0;


        public ventana_cuadre_caja_usa()
        {
            InitializeComponent();
            empleadoSesion = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSesion, "cashbox closing");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        public void loadVentana()
        {
            try
            {
                if (cuadreCaja == null)
                {
                    cuadreCaja = new cuadre_caja();
                    cienDolaresText.Focus();
                    cienDolaresText.SelectAll();

                    cajero = modeloCajero.getCajeroByIdEmpleado(empleadoSesion.codigo);
                    
                    if (cajero == null)
                    {
                        MessageBox.Show("Este usuario no es un cajero para poder realizar cierre de caja", "",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    
                    loadCajero();

                    //validando que el cajero tenga caja abierta
                    if (modeloCajero.getValidarCajaAbiertaByCajero(cajero.codigo) == false)
                    {
                        MessageBox.Show("No se puede realizar un cierre de caja si no tiene una caja abierta activa", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                    montoTotalEfectivo = 0;
                    montoTotalEfectivoText.Text = "0.00";
                    fechaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    fechaFinal = DateTime.Today;
                    
                    //billetes
                    cienDolaresText.Text = "0.00";
                    cincuentaDolaresText.Text = "0.00";
                    veinteDolaresText.Text = "0.00";
                    diezDolaresText.Text = "0.00";
                    cincoDolaresText.Text = "0.00";
                    dosDolaresText.Text = "0.00";
                    unoDolarText.Text = "0.00";
                    
                    //monedas
                    ventiCincoCentavosText.Text = "0.00";
                    diezCentavosText.Text = "0.00";
                    
                    cincoCentavosText.Text = "0.00";
                    unCentavoText.Text = "0.00";

                    ////obtener todos los valores de los montos
                    //cuadreCaja = modeloCuadreCaja.getCuadreCajaByCajeroId(cajero.codigo);

                    ////se llenan todos los detalles del cuadre de caja en base al mismo cuadre de caja anterior
                    //cuadreCaja = cuadreCaja.getCuadreCajaAndCuadreCajaDetalleByCuadreCaja(cuadreCaja);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        
        public void calcularTotalEfectivo()
        {
            try
            {
                montoTotalEfectivo = 0;
                //100
                montoTotalEfectivo += (Convert.ToDecimal(cienDolaresText.Text)) * 100;
                //50
                montoTotalEfectivo += (Convert.ToDecimal(cincuentaDolaresText.Text)) * 50;
                //20
                montoTotalEfectivo += (Convert.ToDecimal(veinteDolaresText.Text)) * 20;
                //10
                montoTotalEfectivo += (Convert.ToDecimal(diezDolaresText.Text)) * 10;
                //5
                montoTotalEfectivo += (Convert.ToDecimal(cincoDolaresText.Text)) * 5;
                //2
                montoTotalEfectivo += (Convert.ToDecimal(dosDolaresText.Text)) * 2;
                //1
                montoTotalEfectivo += (Convert.ToDecimal(unoDolarText.Text)) * 1;
                //25
                montoTotalEfectivo += ((Convert.ToDecimal(ventiCincoCentavosText.Text)) * 25 )/100;
                //10
                montoTotalEfectivo += ((Convert.ToDecimal(diezCentavosText.Text)) * 10) / 100;
                //5
                montoTotalEfectivo += ((Convert.ToDecimal(cincoCentavosText.Text)) * 5) / 100;
                //1
                montoTotalEfectivo += ((Convert.ToDecimal(unCentavoText.Text)) * 1) / 100;

                montoTotalEfectivoText.Text = montoTotalEfectivo.ToString("N");
            }
            catch (Exception ex)
            {
                cienDolaresText.Focus();
                cienDolaresText.SelectAll();
                montoTotalEfectivo = 0;
                montoTotalEfectivoText.Text = "0.00";
                MessageBox.Show("Error calculando el total de efectivo.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarGetAction()
        {
            try
            {
                //cajero
                if (cajero == null)
                {
                    MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void GetAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (!ValidarGetAction())
                {
                    return;
                }

                cuadreCaja.activo = true;
                cuadreCaja.caja_abierta = false;
                cuadreCaja.caja_cuadrada = true;
                cuadreCaja.fecha_cierre_cuadre = DateTime.Today;

                
                //obtener todos los valores de los montos
                cuadreCaja = modeloCuadreCaja.getCuadreCajaByCajeroId(cajero.codigo);

                //sumatoria del efectivo entregado en caja sumatoria del desglose del dinero al momento de cuadrar
                decimal montoEfectivoIngresadoCajero = Convert.ToDecimal(montoTotalEfectivoText.Text);

                //se llenan todos los detalles del cuadre de caja en base al mismo cuadre de caja anterior
                cuadreCaja = cuadreCaja.getCuadreCajaAndCuadreCajaDetalleByCuadreCaja(cuadreCaja,montoEfectivoIngresadoCajero);

                
                if (modeloCuadreCaja.modificarCuadreCaja(cuadreCaja) == true)
                {
                    MessageBox.Show("Operation successfully completed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Do you want to print cash closing detailed report?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //imprimir
                        modeloReporte.imprimirCuadreCajaGeneral(cuadreCaja.codigo);
                    }

                    cuadreCaja = null;
                    loadVentana();
                }
                else
                {
                    cuadreCaja = null;
                    MessageBox.Show("Operation was not completed successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadVentana();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void loadCajero()
        {
            try
            {
                cajeroLabel.Text = "";
                if (cajero != null)
                {
                    empleado = modeloEmpleado.getEmpleadoByCajeroId(cajero.codigo);
                    cajeroLabel.Text = empleado.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCajero.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_cuadre_caja_usa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void cienDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cienDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cincuentaDolaresText.Focus();
                    cincuentaDolaresText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cienDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cincuentaDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cincuentaDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    veinteDolaresText.Focus();
                    veinteDolaresText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cincuentaDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void veinteDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void veinteDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    diezDolaresText.Focus();
                    diezDolaresText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void veinteDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void diezDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void diezDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cincoDolaresText.Focus();
                    cincoDolaresText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void diezDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cincoDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cincoDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dosDolaresText.Focus();
                    dosDolaresText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cincoDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void dosDolaresText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void dosDolaresText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    unoDolarText.Focus();
                    unoDolarText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {

            }
        }

        private void dosDolaresText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void unoDolarText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void unoDolarText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ventiCincoCentavosText.Focus();
                    ventiCincoCentavosText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {
            }
        }

        private void unoDolarText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void ventiCincoCentavosText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void ventiCincoCentavosText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    diezCentavosText.Focus();
                    diezCentavosText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ventiCincoCentavosText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void diezCentavosText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void diezCentavosText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cincoCentavosText.Focus();
                    cincoCentavosText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {
            }
        }

        private void diezCentavosText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cincoCentavosText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cincoCentavosText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    unCentavoText.Focus();
                    unCentavoText.SelectAll();
                    calcularTotalEfectivo();
                }
            }
            catch (Exception)
            {
            }
        }

        private void cincoCentavosText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void unCentavoText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void unCentavoText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    calcularTotalEfectivo();
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void unCentavoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cuadreCaja = null;
            loadVentana();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



    }
}
