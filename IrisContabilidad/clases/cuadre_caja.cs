using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases_calculos;
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

        public cuadre_caja getCuadreCajaAndCuadreCajaDetalleByCuadreCaja(cuadre_caja cuadreCaja)
        {
            try
            {
                string sql = "";
                utilidades utilidades=new utilidades();        
                cuadre_caja_detalle = new cuadre_caja_detalle();

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
                cuadre_caja_detalle.codigo_cuadre_caja = cuadreCaja.codigo;

                //efectivo inicial o efectivo apertura caja
                cuadre_caja_detalle.montoEfectivoAperturaCaja = cuadreCaja.efectivo_inicial;

                //recorriendo la lista de venta para ir sacando los montos contado, credito,pedido,cotizacion
                #region
                foreach (var x in listaVentaDetalle)
                {
                    venta venta = new modeloVenta().getVentaById(x.cod_venta);
                    if (venta.tipo_venta.ToLower() == "con")
                    {
                        //contado
                        cuadre_caja_detalle.montoFacturaContado += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "cre")
                    {
                        //credito
                        cuadre_caja_detalle.montoFacturaCredito += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "ped")
                    {
                        //pedido
                        cuadre_caja_detalle.montoFacturaPedido += x.monto_total;
                    }
                    else if (venta.tipo_venta.ToLower() == "cot")
                    {
                        //cotizacion
                        cuadre_caja_detalle.montoFacturaCotizacion += x.monto_total;
                    }
                   
                    if (!listaVenta.Contains(venta.codigo))
                    {
                        listaVenta.Add(venta.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoVenta = x.codigo;
                        listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }
                }
                #endregion

                //recorriendo la lista de cobros para saber cuales cobros fueron de ventas en efectivo,deposito,cheque
                #region
                /*   1-el cobro tiene que ser efectivo
                     2-la venta que esta atada al cobro debe existir en las ventas detalles
                
                 */
                foreach (var x in listaVentasCobrosDetalles)
                {
                    bool existe = false;
                    //el cobro tiene que ser en efectivo
                    if (x.codigo_metodo_cobro == 1)
                    {
                        cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;

                        //si la venta de ese cobro existe en las ventas detalle
                        if (listaVentaDetalle.Where(vd => vd.cod_venta == x.codigo_venta).Count() >= 1)
                        {
                            cuadre_caja_detalle.montoFacturadoEfectivo += x.monto_cobrado;
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
                        listaCobros.Add(x.codigo_cobro);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoCobro = x.codigo_cobro;
                        listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }

                }

                #endregion

                //recorriendo la lista de cobros para sacar los montos
                #region
                //foreach (var x in listaVentasCobrosDetalles)
                //{
                //    if (x.codigo_metodo_cobro == 1)
                //    {
                //        //efectivo
                //        cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;
                //    }
                //    else if (x.codigo_metodo_cobro == 2)
                //    {
                //        //deposito
                //        cuadre_caja_detalle.montoCobrosDeposito += x.monto_cobrado;
                //    }
                //    else if (x.codigo_metodo_cobro == 3)
                //    {
                //        //cheque
                //        cuadre_caja_detalle.montoCobrosCheque += x.monto_cobrado;
                //    }
                   
                   
                //}
                #endregion

                //recorriendo la lista de ingresos de caja
                #region
                foreach (var x in listaIngresosCajas)
                {
                    cuadre_caja_detalle.monto_ingreso += x.monto;
                    sql = "insert into cuadre_caja_transacciones(codigo_cuadre_caja,codigo_venta,codigo_cobro,codigo_ingreso_caja,codigo_egreso_caja,codigo_nota_credito,codigo_nota_debito,codigo_gasto,codigo_pago) values('" + cuadreCaja.codigo + "','" + x.codigo + "','codigocobro','codigoingresocaja','codigoegresocaja','codigonotacredito','codigonotadebito','codigogasto','codigopago');";
                    utilidades.ejecutarcomando_mysql(sql);

                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoVenta = x.codigo;
                    listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    
                }
                #endregion

                //recorriendo la lista de pagos
                #region
                foreach (var x in listaPagoDetalle)
                {
                    if (x.codigo_metodo_pago == 1)
                    {
                        //efectivo
                        cuadre_caja_detalle.montoPagoEfectivo += x.monto_pagado;

                    }
                    else if (x.codigo_metodo_pago == 2)
                    {
                        //deposito
                        cuadre_caja_detalle.montoPagoDeposito += x.monto_pagado;

                    }
                    else if (x.codigo_metodo_pago == 3)
                    {
                        //cheque
                        cuadre_caja_detalle.montoPagoCheque += x.monto_pagado;
                    }

                    if (!listaPago.Contains(x.codigo))
                    {
                        listaPago.Add(x.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoPago = x.codigo_pago;
                        listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);

                    }
                   
                }
                #endregion

                //recorriendo la lista de cobros
                #region
                foreach (var x in listaVentasCobrosDetalles)
                {
                    //if (x.codigo_metodo_cobro == 1)
                    //{
                    //    //efectivo
                    //    cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;
                    //}
                    //else if (x.codigo_metodo_cobro == 2)
                    //{
                    //    //deposito
                    //    cuadre_caja_detalle.montoCobrosDeposito += x.monto_cobrado;
                    //}
                    //else if (x.codigo_metodo_cobro == 3)
                    //{
                    //    //cheque
                    //    cuadre_caja_detalle.montoCobrosCheque += x.monto_cobrado;
                    //}else if (x.codigo_metodo_cobro == 4)
                    //{
                    //    //tarjeta
                    //    cuadreCaja.cuadre_caja_detalle.montoCobrosTarjeta += x.monto_cobrado;
                    //}


                    //if (!listaCobros.Contains(x.codigo_cobro))
                    //{
                    //    listaCobros.Add(x.codigo_cobro);
                    //    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    //    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    //    cuadreCajaTransacciones.codigoCobro = x.codigo_cobro;
                    //    listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    //}
                    
                }
                #endregion

                //recorriendo la lista de egresos
                #region
                foreach (var x in listaEgresosCaja)
                {
                    cuadre_caja_detalle.monto_egreso += x.monto;


                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoEgresoCaja = x.codigo;
                    listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    
                }
                #endregion

                //recorriendo la lista de gastos
                #region
                foreach (var x in listaGastos)
                {
                    cuadre_caja_detalle.montoGasto += x.monto_total;

                   

                    if (!listaGasto.Contains(x.codigo))
                    {
                        listaGasto.Add(x.codigo);
                        cuadreCajaTransacciones = new cuadre_caja_transacciones();
                        cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                        cuadreCajaTransacciones.codigoGasto = x.codigo;
                        listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                    }
                }
                #endregion

                //recorriendo lista nota debito
                #region
                foreach (var x in listaNotasDebito)
                {
                    cuadre_caja_detalle.montoNotasDebito += x.monto;

                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoNotaDebito = x.codigo;
                    listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);

                }
                #endregion

                //recorriendo lista nota credito
                #region
                foreach (var x in listaNotasCredito)
                {
                    cuadre_caja_detalle.montoNotasCredito += x.monto;

                    cuadreCajaTransacciones = new cuadre_caja_transacciones();
                    cuadreCajaTransacciones.codigoCuadreCaja = cuadreCaja.codigo;
                    cuadreCajaTransacciones.codigoNotaCredito = x.codigo;
                    listaCuadreCajaTransacciones.Add(cuadreCajaTransacciones);
                }
                #endregion

                //recorriendo las devoluciones de venta
                #region
                foreach (var x in listaVentaDevolucion)
                {
                    cuadre_caja_detalle.montoVentaDevolucion += x.monto_total;

                }
                #endregion

               


                cuadreCaja.cuadre_caja_detalle = cuadre_caja_detalle;
                cuadreCaja.cuadreCajaTransacciones = listaCuadreCajaTransacciones;

                
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
