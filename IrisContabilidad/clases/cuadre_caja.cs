using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases
{
    public class cuadre_caja
    {
        public int codigo { get; set; }
        public int codigo_cajero { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecha_cierre_cuadre { get; set; }
        public int turno { get; set; }
        public bool activo { get; set; }
        public int codigo_sucursal { get; set; }
        public int codigo_caja { get; set; }
        public decimal efectivo_inicial { get; set; }
        public bool caja_cuadrada { get; set; }
        public Boolean caja_abierta { get; set; }

        public cuadre_caja_detalle cuadre_caja_detalle { get; set; }
        public List<cuadre_caja_transacciones> cuadreCajaTransacciones { get; set; }


        public cuadre_caja()
        {
            
        }

        public cuadre_caja getCuadreCajaAndCuadreCajaDetalleByCuadreCaja(cuadre_caja cuadreCaja,decimal montoEfectivoIngresadoCajero)
        {
            try
            {

                sistemaConfiguracion sistema = new modeloSistemaConfiguracion().getSistemaConfiguracion();

                string sql = "";
                utilidades utilidades=new utilidades();

                List<cuadre_caja_transacciones> listaCuadreCajaTransacciones = new List<cuadre_caja_transacciones>();
                cuadre_caja_transacciones cuadreCajaTransacciones = new cuadre_caja_transacciones();

                empleado empleado = new modeloEmpleado().getEmpleadoById(singleton.getEmpleado().codigo);
                if (empleado == null)
                {
                    MessageBox.Show("Error empleado nulo en base al empleado de sesion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                cajero cajero = new modeloCajero().getCajeroByIdEmpleado(empleado.codigo);
                if (empleado == null)
                {
                    MessageBox.Show("Error cajero nulo en base al empleado de sesion", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                cuadreCaja = new modeloCuadreCaja().getCuadreCajaByCajeroId(cuadreCaja.codigo_cajero);

                List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
                List<venta_vs_cobros_detalles> listaVentasCobrosDetalles = new List<venta_vs_cobros_detalles>();
                List<ingreso_caja> listaIngresosCajas = new List<ingreso_caja>();
                List<compra_vs_pagos_detalles> listaPagoDetalle = new List<compra_vs_pagos_detalles>();
                List<egreso_caja> listaEgresosCaja = new List<egreso_caja>();
                List<gasto> listaGastos = new List<gasto>();
                List<cxc_nota_credito> listaNotasCredito = new List<cxc_nota_credito>();
                List<cxc_nota_debito> listaNotasDebito = new List<cxc_nota_debito>();
                List<ventaDevolucionDetalle> listaVentaDevolucion = new List<ventaDevolucionDetalle>();


                List<int> listaVenta = new List<int>();
                List<int> listaCobros = new List<int>();
                List<int> listaPago = new List<int>();
                List<int> listaGasto = new List<int>();
                
                
                listaVentaDetalle = new modeloVenta().getListaVentaDetallesCompletaSinCuadradaBycuadreCaja(cuadreCaja).OrderBy(x=> x.cod_venta).ToList();
                listaVentasCobrosDetalles = new modeloCobro().getListaCobrosDetallesCompletaSinCuadradaBycuadreCaja(cuadreCaja).OrderBy(x => x.codigo_cobro).ToList();
                listaIngresosCajas = new modeloIngresoCaja().getListaIngresosCajaNoCuadradaCompletaByCuadreCaja(cuadreCaja);
                listaPagoDetalle = new modeloCompra().getListaCompraPagoDetalleCompletaByCuadreCaja(cuadreCaja).OrderBy(x => x.codigo_pago).ToList();
                listaEgresosCaja = new modeloEgresoCaja().getListaCompletaByCuadreCaja(cuadreCaja);
                listaGastos = new modeloGasto().getListaGastosCompletabyCuadreCaja(cuadreCaja);
                listaNotasCredito = new modeloCxcNotaCredito().getListaCompletaByCuadreCaja(cuadreCaja);
                listaNotasDebito = new modeloCxcNotaDebito().getListaCompletaByCuadreCaja(cuadreCaja);
                listaVentaDevolucion = new modeloVentaDevolucion().getListaVentaDevolucionDetalleByCuadreCaja(cuadreCaja).OrderBy(x => x.codigo_devolucion).ToList();

               
                cuadreCaja.cuadre_caja_detalle=new cuadre_caja_detalle();
                cuadreCaja.cuadreCajaTransacciones=new List<cuadre_caja_transacciones>();

                //limpiando la tabla transacciones cuadre caja que pertenezcan a este cuadre de caja
                sql = "delete from cuadre_caja_transacciones where codigo_cuadre_caja='"+cuadreCaja.codigo+"';";
                utilidades.ejecutarcomando_mysql(sql);

                //llenando el detalle del cuadre de caja
                cuadreCaja.cuadre_caja_detalle.codigo_cuadre_caja = cuadreCaja.codigo;

                //efectivo inicial o efectivo apertura caja
                cuadreCaja.cuadre_caja_detalle.montoEfectivoAperturaCaja = cuadreCaja.efectivo_inicial;

                //recorriendo la lista de venta para ir sacando los montos contado, credito,pedido,cotizacion
                #region
                foreach (var x in listaVentaDetalle)
                {
                    venta venta = new modeloVenta().getVentaById(x.cod_venta);
                    if (venta.tipo_venta.ToLower() == "con")
                    {
                        //contado
                        cuadreCaja.cuadre_caja_detalle.montoFacturaContado += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "cre")
                    {
                        //credito
                        cuadreCaja.cuadre_caja_detalle.montoFacturaCredito += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "ped")
                    {
                        //pedido
                        cuadreCaja.cuadre_caja_detalle.montoFacturaPedido += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "cot")
                    {
                        //cotizacion
                        cuadreCaja.cuadre_caja_detalle.montoFacturaCotizacion += x.monto_total;
                    }

                    
                    if (!listaVenta.Contains(venta.codigo))
                    {
                        //docuento para saber que es una venta
                        #region
                        cuadreCaja.cuadre_caja_detalle.codigoDocumento = venta.codigo;
                        cuadreCaja.cuadre_caja_detalle.montoDocumento += x.monto_total;
                        if (sistema.tipoVentanaCuadreCaja == 1)
                        {
                            //rd
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Venta";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(venta.fecha);
                        }
                        else if (sistema.tipoVentanaCuadreCaja == 2)
                        {
                            //usa
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Sale";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(venta.fecha);
                        }
                        #endregion


                        listaVenta.Add(venta.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoVenta = x.codigo;
                        cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }
                }
                #endregion

                //recorriendo la lista de cobros para saber cuales cobros fueron  ventas en efectivo,deposito,cheque
                #region
                /*   1-el cobro tiene que ser efectivo
                     2-la venta que esta atada al cobro debe existir en las ventas detalles
                
                 */
                foreach (var x in listaVentasCobrosDetalles)
                {
                    bool existe = false;
                    venta_vs_cobros ventacobro = new modeloVenta().getVentaCobroById(x.codigo_cobro);
                    //el cobro tiene que ser en efectivo
                    if (x.codigo_metodo_cobro == 1)
                    {
                        cuadreCaja.cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;

                        //si la venta de ese cobro existe en las ventas detalle
                        if (listaVentaDetalle.Where(vd => vd.cod_venta == x.codigo_venta).Count() >= 1)
                        {
                            cuadreCaja.cuadre_caja_detalle.montoFacturadoEfectivo += x.monto_cobrado;
                        }

                    }else if (x.codigo_metodo_cobro == 2)
                    {
                        //deposito
                        cuadreCaja.cuadre_caja_detalle.montoCobrosDeposito += x.monto_cobrado;
                    }
                    else if (x.codigo_metodo_cobro == 3)
                    {
                        //cheque
                        cuadreCaja.cuadre_caja_detalle.montoCobrosCheque += x.monto_cobrado;
                    }
                    else if (x.codigo_metodo_cobro == 4)
                    {
                        //tarjeta
                        cuadreCaja.cuadre_caja_detalle.montoCobrosTarjeta += x.monto_cobrado;
                    }

                    if (!listaCobros.Contains(x.codigo_cobro))
                    {
                        //documento para saber que tipo de documento es
                        #region
                        cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo_cobro;
                        cuadreCaja.cuadre_caja_detalle.montoDocumento += x.monto_cobrado;
                        if(sistema.tipoVentanaCuadreCaja == 1)
                        {
                            //rd
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Cobro";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(ventacobro.fecha);
                        }
                        else if (sistema.tipoVentanaCuadreCaja == 2)
                        {
                            //usa
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Charges";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(ventacobro.fecha);
                        }
                        #endregion


                        listaCobros.Add(x.codigo_cobro);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoCobro = x.codigo_cobro;
                        cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }

                }

                #endregion

                //recorriendo la lista de ingresos de caja
                #region
                foreach (var x in listaIngresosCajas)
                {
                    //documento para saber que tipo de documento es
                    #region
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;

                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Ingreso caja";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Cash income";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                    }
                    #endregion


                    cuadreCaja.cuadre_caja_detalle.monto_ingreso += x.monto;
                    sql = "insert into cuadre_caja_transacciones(codigo_cuadre_caja,codigo_venta,codigo_cobro,codigo_ingreso_caja,codigo_egreso_caja,codigo_nota_credito,codigo_nota_debito,codigo_gasto,codigo_pago) values('" + cuadreCaja.codigo + "','" + x.codigo + "','codigocobro','codigoingresocaja','codigoegresocaja','codigonotacredito','codigonotadebito','codigogasto','codigopago');";
                    utilidades.ejecutarcomando_mysql(sql);

                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoVenta = x.codigo;
                    cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones); 

                }
                #endregion

                //recorriendo la lista de pagos
                #region
                foreach (var x in listaPagoDetalle)
                {
                    compra_vs_pagos compraPago = new modeloCompra().getCompraPagoById(x.codigo_pago);
                    if (x.codigo_metodo_pago == 1)
                    {
                        //efectivo
                        cuadreCaja.cuadre_caja_detalle.montoPagoEfectivo += x.monto_pagado;
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_pagado;

                    }
                    else if (x.codigo_metodo_pago == 2)
                    {
                        //deposito
                        cuadreCaja.cuadre_caja_detalle.montoPagoDeposito += x.monto_pagado;
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_pagado;
                    }
                    else if (x.codigo_metodo_pago == 3)
                    {
                        //cheque
                        cuadreCaja.cuadre_caja_detalle.montoPagoCheque += x.monto_pagado;
                    }

                    if (!listaPago.Contains(x.codigo))
                    {
                        //documento para saber que tipo de documento es
                        #region
                        cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                        cuadreCaja.cuadre_caja_detalle.montoDocumento += x.monto_pagado;
                        if (sistema.tipoVentanaCuadreCaja == 1)
                        {
                            //rd
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Pagos";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(compraPago.fecha);
                        }
                        else if (sistema.tipoVentanaCuadreCaja == 2)
                        {
                            //usa
                            cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Payments";
                            cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(compraPago.fecha);
                        }
                        #endregion


                        listaPago.Add(x.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoPago = x.codigo_pago;
                        cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);

                    }
                   
                }
                #endregion

                //recorriendo la lista de egresos
                #region
                foreach (var x in listaEgresosCaja)
                {

                    //documento para saber que tipo de documento es
                    #region
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                    cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Egresos de caja";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(x.fecha);
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Cash outflows";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(x.fecha);
                    }
                    #endregion


                    cuadreCaja.cuadre_caja_detalle.monto_egreso += x.monto;
                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoEgresoCaja = x.codigo;
                    cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                }
                #endregion

                //recorriendo la lista de gastos
                #region
                foreach (var x in listaGastos)
                {
                    //documento para saber que tipo de documento es
                    #region
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Gastos";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_total;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(x.fecha);
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Expenses";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_total;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(x.fecha);
                    }
                    #endregion

                    cuadreCaja.cuadre_caja_detalle.montoGasto += x.monto_total;
                    if (!listaGasto.Contains(x.codigo))
                    {
                        listaGasto.Add(x.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoGasto = x.codigo;
                        cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }
                }
                #endregion

                //recorriendo lista nota debito
                #region
                foreach (var x in listaNotasDebito)
                {

                    //documento para saber que tipo de documento es
                    #region
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Nota debito";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(x.fecha);
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Debit notes";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(x.fecha);
                    }
                    #endregion

                    cuadreCaja.cuadre_caja_detalle.montoNotasDebito += x.monto;
                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoNotaDebito = x.codigo;
                    cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);

                }
                #endregion

                //recorriendo lista nota credito
                #region
                foreach (var x in listaNotasCredito)
                {

                    //documento para saber que tipo de documento es
                    #region
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Nota Credito";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(x.fecha);
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Credit notes";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_MM_dd_yyyy(x.fecha);
                    }
                    #endregion


                    cuadreCaja.cuadre_caja_detalle.montoNotasCredito += x.monto;
                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoNotaCredito = x.codigo;
                    cuadreCaja.cuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                }
                #endregion

                //recorriendo las devoluciones de venta
                #region
                foreach (var x in listaVentaDevolucion)
                {
                    //documento para saber que tipo de documento es
                    #region
                    ventaDevolucion ventaDevolucion = new modeloVentaDevolucion().getDevolucionById(x.codigo);
                    cuadreCaja.cuadre_caja_detalle.codigoDocumento = x.codigo;
                    if (sistema.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Venta devolución";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_total;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(ventaDevolucion.fecha);
                    }
                    else if (sistema.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        cuadreCaja.cuadre_caja_detalle.tipoDocumento = "Sale return";
                        cuadreCaja.cuadre_caja_detalle.montoDocumento = x.monto_total;
                        cuadreCaja.cuadre_caja_detalle.fechaDocumentoS = utilidades.getFecha_dd_MM_yyyy(ventaDevolucion.fecha);
                    }
                    #endregion


                    cuadreCaja.cuadre_caja_detalle.montoVentaDevolucion += x.monto_total;
                }
                #endregion

                cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero = montoEfectivoIngresadoCajero;

                //obteniendo el efectivo esperado
                //en el monto efectivo cobro esta incluido lo facturado y lo cobrado en efectivo
                cuadreCaja.cuadre_caja_detalle.monto_efectivo_esperado = 
                    (cuadreCaja.cuadre_caja_detalle.montoEfectivoAperturaCaja +cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero + 
                    cuadreCaja.cuadre_caja_detalle.montoCobrosEfectivo +cuadreCaja.cuadre_caja_detalle.monto_ingreso) - 
                    (cuadreCaja.cuadre_caja_detalle.montoPagoEfectivo +cuadreCaja.cuadre_caja_detalle.monto_egreso);

                //obteniendo el monto sobrante
                if (cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero >= cuadreCaja.cuadre_caja_detalle.monto_efectivo_esperado)
                {
                    cuadreCaja.cuadre_caja_detalle.monto_sobrante =
                        cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero
                        - cuadreCaja.cuadre_caja_detalle.monto_efectivo_esperado;
                }
                //obteniendo el monto faltante
                if (cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero <= cuadreCaja.cuadre_caja_detalle.monto_efectivo_esperado)
                {
                    cuadreCaja.cuadre_caja_detalle.monto_faltante =
                        cuadreCaja.cuadre_caja_detalle.monto_efectivo_esperado -
                        cuadreCaja.cuadre_caja_detalle.montoEfectivoIngresadoCajero;
                }
                
                
                return cuadreCaja;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCuadreCajaAndCuadreCajaDetalleByCuadreCaja.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    
    }
}
