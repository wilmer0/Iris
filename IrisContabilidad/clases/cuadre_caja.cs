using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public cuadre_caja()
        {
            
        }

        public cuadre_caja(cuadre_caja cuadreCaja)
        {
            cuadre_caja_detalle = new cuadre_caja_detalle();

            List<venta_detalle> listaVentaDetalle = new List<venta_detalle>();
            List<venta_vs_cobros_detalles> listaVentasCobrosDetalles = new List<venta_vs_cobros_detalles>();
            List<ingreso_caja> listaIngresosCajas = new List<ingreso_caja>();
            List<compra_vs_pagos_detalles> listaPagoDetalle = new List<compra_vs_pagos_detalles>();
            List<egreso_caja> listaEgresosCaja = new List<egreso_caja>();
            List<gasto> listaGastos = new List<gasto>();
            List<cxc_nota_credito> listaNotasCredito=new List<cxc_nota_credito>(); 
            List<cxc_nota_debito> listaNotasDebito=new List<cxc_nota_debito>();
            List<ventaDevolucionDetalle> listaVentaDevolucion=new List<ventaDevolucionDetalle>();
            
            
            listaVentaDetalle = new modeloVenta().getListaVentaDetallesCompletaSinCuadradaBycuadreCaja(cuadreCaja);
            listaVentasCobrosDetalles = new modeloCobro().getListaCobrosDetallesCompletaSinCuadradaBycuadreCaja(cuadreCaja);
            listaIngresosCajas = new modeloIngresoCaja().getListaIngresosCajaNoCuadradaCompletaByCuadreCaja(cuadreCaja);
            listaPagoDetalle = new modeloCompra().getListaCompraPagoDetalleCompletaByCuadreCaja(cuadreCaja);
            listaEgresosCaja = new modeloEgresoCaja().getListaCompletaByCuadreCaja(cuadreCaja);
            listaGastos = new modeloGasto().getListaGastosCompletabyCuadreCaja(cuadreCaja);
            listaNotasCredito = new modeloCxcNotaCredito().getListaCompletaByCuadreCaja(cuadreCaja);
            listaNotasDebito = new modeloCxcNotaDebito().getListaCompletaByCuadreCaja(cuadreCaja);
            listaVentaDevolucion = new modeloVentaDevolucion().getListaVentaDevolucionDetalleByCuadreCaja(cuadreCaja);


            //llenando el detalle del cuadre de caja
            cuadre_caja_detalle.codigo_cuadre_caja = cuadreCaja.codigo;
            //efectivo inicial
            cuadre_caja_detalle.monto_efectivo_inicial = cuadreCaja.efectivo_inicial;
            
            //recorriendo la lista de venta para ir sacando los montos cheque, deposito, efectivo etc...
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

                }else if (venta.tipo_venta.ToLower() == "cot")
                {
                    //cotizacion
                    cuadre_caja_detalle.montoFacturaCotizacion += x.monto_total;

                }
            }

            //recorriendo la lista de cobros para sacar los montos
            foreach (var x in listaVentasCobrosDetalles)
            {
                if (x.codigo_metodo_cobro == 1)
                {
                    //efectivo
                    cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;
                }else if (x.codigo_metodo_cobro == 2)
                {
                    //deposito
                    cuadre_caja_detalle.montoCobrosDeposito += x.monto_cobrado;
                }else if (x.codigo_metodo_cobro == 3)
                {
                    //cheque
                    cuadre_caja_detalle.montoCobrosCheque += x.monto_cobrado;
                }
            }

            //recorriendo la lista de ingresos de caja
            foreach (var x in listaIngresosCajas)
            {
                cuadre_caja_detalle.monto_ingreso += x.monto;
            }

            //recorriendo la lista de pagos
            foreach (var x in listaPagoDetalle)
            {
                if (x.codigo_metodo_pago == 1)
                {
                    //efectivo
                    cuadre_caja_detalle.montoPagoEfectivo += x.monto_pagado;

                }else if (x.codigo_metodo_pago == 2)
                {
                    //deposito
                    cuadre_caja_detalle.montoPagoDeposito += x.monto_pagado;

                }else if (x.codigo_metodo_pago == 3)
                {
                    //cheque
                    cuadre_caja_detalle.montoPagoCheque += x.monto_pagado;
                }
            }

            //recorriendo la lista de cobros
            foreach (var x in listaVentasCobrosDetalles)
            {
                if (x.codigo_metodo_cobro == 1)
                {
                    //efectivo
                    cuadre_caja_detalle.montoCobrosEfectivo += x.monto_cobrado;
                }else if (x.codigo_metodo_cobro == 2)
                {
                    //deposito
                    cuadre_caja_detalle.montoCobrosDeposito += x.monto_cobrado;
                }else if (x.codigo_metodo_cobro == 3)
                {
                    //cheque
                    cuadre_caja_detalle.montoCobrosCheque += x.monto_cobrado;
                }
            }

            //recorriendo la lista de egresos
            foreach (var x in listaEgresosCaja)
            {
                cuadre_caja_detalle.monto_egreso += x.monto;
            }

            //recorriendo la lista de gastos
            foreach (var x in listaGastos)
            {
                cuadre_caja_detalle.montoGasto += x.monto_total;
            }

            //recorriendo lista nota debito
            foreach (var x in listaNotasDebito)
            {
                cuadre_caja_detalle.montoNotasDebito += x.monto;
            }

            //recorriendo lista nota credito
            foreach (var x in listaNotasCredito)
            {
                cuadre_caja_detalle.montoNotasCredito += x.monto;
            }

            //recorriendo las devoluciones de venta
            foreach (var x in listaVentaDevolucion)
            {
                cuadre_caja_detalle.montoVentaDevolucion += x.monto_total;
            }


        }
    }
}
