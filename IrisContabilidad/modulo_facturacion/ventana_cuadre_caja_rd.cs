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
    public partial class ventana_cuadre_caja_rd : formBase
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
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();
        modeloCajero modeloCajero=new modeloCajero();
        modeloVenta modeloVenta=new modeloVenta();
        modeloEgresoCaja modeloEgreCaja=new modeloEgresoCaja();
        modeloIngresoCaja modeloIngresoCaja=new modeloIngresoCaja();
        modeloCompra modeloCompra=new modeloCompra();

        //listas


        //variables
        private decimal montoTotalEfectivo = 0;

        private decimal montoTotalEfectivoEsperado = 0;

        public ventana_cuadre_caja_rd()
        {
            InitializeComponent();
            empleadoSesion = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSesion, "ventana cuadre caja");
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
                    dosMilText.Text = "0.00";
                    milText.Text = "0.00";
                    quinientoText.Text = "0.00";
                    doscientosText.Text = "0.00";
                    cienText.Text = "0.00";
                    cincuentaText.Text = "0.00";
                    venticincoText.Text = "0.00";
                    veinteText.Text = "0.00";
                    diezText.Text = "0.00";
                    cincoText.Text = "0.00";
                    unoText.Text = "0.00";

                    //obtener todos los valores de los montos
                    cuadreCaja = modeloCuadreCaja.getCuadreCajaByCajeroId(cajero.codigo);

                    //se llenan todos los detalles del cuadre de caja en base al mismo cuadre de caja anterior
                    cuadreCaja = cuadreCaja.getCuadreCajaAndCuadreCajaDetalleByCuadreCaja(cuadreCaja);
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
                //2,000
                montoTotalEfectivo += (Convert.ToDecimal(dosMilText.Text))*2000;
                //1,000
                montoTotalEfectivo += (Convert.ToDecimal(milText.Text)) * 1000;
                //500
                montoTotalEfectivo += (Convert.ToDecimal(quinientoText.Text)) * 500;
                //200
                montoTotalEfectivo += (Convert.ToDecimal(doscientosText.Text)) * 200;
                //100
                montoTotalEfectivo += (Convert.ToDecimal(cienText.Text)) * 100;
                //50
                montoTotalEfectivo += (Convert.ToDecimal(cincuentaText.Text)) * 50;
                //25
                montoTotalEfectivo += (Convert.ToDecimal(venticincoText.Text)) * 25;
                //20
                montoTotalEfectivo += (Convert.ToDecimal(veinteText.Text)) * 20;
                //10
                montoTotalEfectivo += (Convert.ToDecimal(diezText.Text)) * 10;
                //5
                montoTotalEfectivo += (Convert.ToDecimal(cincoText.Text)) * 5;
                //1
                montoTotalEfectivo += (Convert.ToDecimal(unoText.Text)) * 1;

                montoTotalEfectivoText.Text = montoTotalEfectivo.ToString("N");
            }
            catch (Exception ex)
            {
                montoTotalEfectivo = 0;
                montoTotalEfectivoText.Text = "0.00";
                MessageBox.Show("Error calculando el total de efectivo.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public bool ValidarGetAction()
        {
            try
            {
                //cajero
                if (cajero==null)
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
                
                if (modeloCuadreCaja.modificarCuadreCaja(cuadreCaja,cuadreCaja.cuadre_caja_detalle)==true)
                {
                    cuadreCaja = null;
                    MessageBox.Show("Se realizó el cierre de caja con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadVentana();
                }
                else
                {
                    cuadreCaja = null;
                    MessageBox.Show("No se realizó el cierre de caja", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void ventana_cuadre_caja_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
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
                MessageBox.Show("Error loadCajero.: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ventana_busqueda_cajero ventana=new ventana_busqueda_cajero();
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                cajero = ventana.getObjeto();
                loadCajero();
            }
        }

        private void dosMilText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void dosMilText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void milText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void quinientoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void doscientosText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cienText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cincuentaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void venticincoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void veinteText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void diezText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void cincoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void unoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void milText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void quinientoText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void doscientosText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cienText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cincuentaText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void venticincoText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void veinteText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void diezText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void cincoText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }

        private void unoText_Leave(object sender, EventArgs e)
        {
            calcularTotalEfectivo();
        }
    }
}
