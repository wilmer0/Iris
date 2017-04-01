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
    public partial class ventana_cuadre_caja : formBase
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
        private List<venta> listaVentas;
        private List<venta_detalle> listaVentasDetalles;
        private List<egreso_caja> listaEgresosCaja;
        private List<ingreso_caja> listaIngresoCaja;
        private List<compra_vs_pagos> listaCompraPagos;
        private List<compra_vs_pagos_detalles> listaCompraPagoDetalle;
        private List<venta_vs_cobros> listaVentaCobros;
        private List<venta_vs_cobros_detalles> listaVentaCobrosDetalles;
        private List<compra> listaCompra; 


        //variables
        private decimal montoEfectivoInicial = 0;
        private decimal montoFacturaEfectivo = 0;
        public decimal  montoCobrosEfectivo = 0;
        private decimal montoIngresosCaja = 0;
        private decimal montoNotascredito = 0;
        private decimal montoNotasDebito = 0;
        private decimal montoTarjeta = 0;
        private decimal montoCheque = 0;
        private decimal montoDeposito = 0;
        private decimal montoSobradnte = 0;
        private decimal montoFaltante = 0;
        private decimal montoPagosCompraEfectivo = 0;
        private decimal montoEgresosCajaEfectivo = 0;
        private decimal montoGastosEfectivo = 0;

        private decimal montoTotalEfectivoEsperado = 0;

        public ventana_cuadre_caja()
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
                if (cuadreCaja != null)
                {
                    cajero = modeloCajero.getCajeroByIdEmpleado(empleadoSesion.codigo);
                    if (cajero == null)
                    {
                        MessageBox.Show("Este usuario no es un cajero para poder realizar cierre de caja", "",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }

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



                    //llenando la listas
                    listaVentas=new List<venta>();
                    listaVentasDetalles=new List<venta_detalle>();
                    listaEgresosCaja=new List<egreso_caja>();
                    listaIngresoCaja=new List<ingreso_caja>();
                    listaCompraPagos=new List<compra_vs_pagos>();
                    listaCompraPagoDetalle=new List<compra_vs_pagos_detalles>();
                    listaVentaCobros=new List<venta_vs_cobros>();
                    listaVentaCobrosDetalles=new List<venta_vs_cobros_detalles>();
                    listaCompra=new List<compra>();
                    


                    //lista ventas
                    listaVentasDetalles = modeloCuadreCaja.getListaVentasDetallesBycuadreCaja(cuadreCaja);
                    
                    //lista egresos caja
                    //listaEgresosCaja = modeloEgreCaja.getListaCompletaNoCuadradoByFechaFinalAndCajeroId(fechaFinal,cajero.codigo);

                    //lista ingresos caja
                    listaIngresoCaja = modeloIngresoCaja.getListaIngresosCajaNoCuadradaCompletaByCuadreCaja(cuadreCaja);

                    //lista compra detalle

                   
                    //lista compra pagos
                   
                    
                    //lista venta cobros
                    




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
                    cajeroIdText.Focus();
                    cajeroIdText.SelectAll();
                    return false;
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

                //cambiar la clave
                if (modeloCuadreCaja.agregarCuadreCaja(cuadreCaja)==true)
                {
                    cuadreCaja = null;
                    MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cuadreCaja = null;
                    MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cajeroIdText.Text = "";
                cajeroLabel.Text = "";
                if (cajero != null)
                {
                    empleado = modeloEmpleado.getEmpleadoByCajeroId(cajero.codigo);

                    cajeroIdText.Text = cajero.codigo.ToString();
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
    }
}
