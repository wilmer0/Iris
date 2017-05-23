using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.ventanas_comunes;
using Microsoft.Reporting.WinForms;

namespace IrisContabilidad.modelos
{
    public class ModeloReporte
    {

        private empleado empleado;
        utilidades utilidades=new utilidades();
        singleton singleton=new singleton();
        private sistemaConfiguracion sistemaConfiguracion;

        //modulo
        modeloSistemaConfiguracion modeloSistema=new modeloSistemaConfiguracion();

        //imprimri compra
        public bool imprimirCompra(int idcompra)
        {
            try
            {
                //datos generales
                String reporte = "IrisContabilidad.reportes.reporte_compra_hoja_completa.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                compra compra = new modeloCompra().getCompraById(idcompra);
                
                if (compra == null)
                {
                    return false;
                }


                //llenar encabezado
                reporte_compra_encabezado reporteCompraEncabezado = new reporte_compra_encabezado(compra);
                List<reporte_compra_encabezado> listaReporteCompraencabezado = new List<reporte_compra_encabezado>();
                listaReporteCompraencabezado.Add(reporteCompraEncabezado);
                
                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaReporteCompraencabezado);
                listaReportDataSource.Add(reporteGrafico);

                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", reporteCompraEncabezado.listaDetalles);
                listaReportDataSource.Add(reporteProblemas);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir compra pagos
        public bool imprirmirCompraPago(int codigoPago)
        {
            try
            {
                String reporte = "IrisContabilidad.reportes.reporte_compra_pago_hoja_completa.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                List<reporte_compra_pago_encabezado>listaReporteCompraEncabezado=new List<reporte_compra_pago_encabezado>();
                reporte_compra_pago_encabezado reporteCompraPagoEncabezado;
                List<reporte_compra_pago_detalle> listaReporteCompraPagoDetalle=new List<reporte_compra_pago_detalle>();
                List<compra_vs_pagos_detalles> listaCompraPagosDetalles=new List<compra_vs_pagos_detalles>();

                //llenar encabezado
                reporteCompraPagoEncabezado = new reporte_compra_pago_encabezado(codigoPago);
                listaReporteCompraEncabezado.Add(reporteCompraPagoEncabezado);
                
                //llenar detalle ya esta en el constructor
                listaCompraPagosDetalles = new modeloCompra().getListaCompraPagoDetalleByIdCompraPago(codigoPago);
                listaCompraPagosDetalles.ForEach(x =>
                {
                    compra compra = new modeloCompra().getCompraById(x.codigo_compra);
                    reporte_compra_pago_detalle reporteCompraPagoDetalle=new reporte_compra_pago_detalle();
                    reporteCompraPagoDetalle.numero_compra = utilidades.getRellenar(x.codigo.ToString(), '0', 9);
                    reporteCompraPagoDetalle.codigoCompra = x.codigo_compra;
                    reporteCompraPagoDetalle.fecha_compra = utilidades.getFechaddMMyyyy(compra.fecha);
                    reporteCompraPagoDetalle.monto_descuento = x.monto_descontado;
                    reporteCompraPagoDetalle.monto_pagado = x.monto_pagado;
                    reporteCompraPagoDetalle.codigo_metodo_pago = x.codigo_metodo_pago;
                    
                    reporteCompraPagoDetalle.metodo_pago = new modeloMetodoPago().getMetodoPagoById(x.codigo_metodo_pago).metodo;
                    listaReporteCompraPagoDetalle.Add(reporteCompraPagoDetalle);
                });

                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaReporteCompraEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", listaReporteCompraPagoDetalle);
                listaReportDataSource.Add(reporteProblemas);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter,true);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprirmiCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir venta
        public bool imprimirVenta(int idVenta)
        {
            try
            {
                sistemaConfiguracion=new sistemaConfiguracion();
                sistemaConfiguracion = modeloSistema.getSistemaConfiguracion();

                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                venta venta = new modeloVenta().getVentaById(idVenta);

                cajero cajero=new cajero();
                empleado = singleton.getEmpleado();
                cajero = new modeloCajero().getCajeroByIdEmpleado(empleado.codigo);
                if (cajero.tipoImpresionVenta == 1)
                {
                    //hoja normal
                    //reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_hoja_completa_rd.rdlc";
                    if (sistemaConfiguracion.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_hoja_completa_rd.rdlc";
                    
                    }
                    else if (sistemaConfiguracion.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_hoja_completa_usa.rdlc";
                    
                    }
                }
                else if (cajero.tipoImpresionVenta == 2)
                {
                    //hoja rollo de 3 pulgadas"
                    if (sistemaConfiguracion.tipoVentanaCuadreCaja == 1)
                    {
                        //rd
                        reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_hoja_rollo_rd.rdlc";
                    }
                    else if (sistemaConfiguracion.tipoVentanaCuadreCaja == 2)
                    {
                        //usa
                        reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_hoja_rollo_usa.rdlc";
                    }
                }

                if (venta == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_venta_encabezado reporteVentaEncabezado = new reporte_venta_encabezado(venta);
                List<reporte_venta_encabezado> listaReporteCompraencabezado = new List<reporte_venta_encabezado>();
                listaReporteCompraencabezado.Add(reporteVentaEncabezado);

                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaReporteCompraencabezado);
                listaReportDataSource.Add(reporteGrafico);

                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", reporteVentaEncabezado.listaDetalles);
                listaReportDataSource.Add(reporteProblemas);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir venta cobro
        public bool imprimirVentaCobro(int codigoCobro)
        {
            try
            {
                String reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_venta_cobro_hoja_completa.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                List<reporte_venta_cobro_encabezado> listaReporteVentaEncabezado = new List<reporte_venta_cobro_encabezado>();
                reporte_venta_cobro_encabezado reporteVentaCobroEncabezado;
                List<reporte_venta_cobro_detalle> listaReporteVentaCobroDetalle = new List<reporte_venta_cobro_detalle>();
                List<venta_vs_cobros_detalles> listaVentaCobroDetalles = new List<venta_vs_cobros_detalles>();

                //llenar encabezado
                reporteVentaCobroEncabezado = new reporte_venta_cobro_encabezado(codigoCobro);
                listaReporteVentaEncabezado.Add(reporteVentaCobroEncabezado);

                //llenar detalle ya esta en el constructor
                listaVentaCobroDetalles = new modeloVenta().getListaVentaCobroDetalleByIdVentaCobro(codigoCobro);
                listaVentaCobroDetalles.ForEach(x =>
                {
                    venta venta = new modeloVenta().getVentaById(x.codigo_venta);
                    reporte_venta_cobro_detalle reporteVentaCobroDetalle = new reporte_venta_cobro_detalle();
                    reporteVentaCobroDetalle.numero_venta = utilidades.getRellenar(x.codigo_venta.ToString(), '0', 9);
                    reporteVentaCobroDetalle.codigo_venta = x.codigo_venta;
                    reporteVentaCobroDetalle.fecha_venta = utilidades.getFechaddMMyyyy(venta.fecha);
                    reporteVentaCobroDetalle.monto_descuento = x.monto_descontado;
                    reporteVentaCobroDetalle.monto_cobrado = x.monto_cobrado;
                    reporteVentaCobroDetalle.codigo_metodo_cobro = x.codigo_metodo_cobro;

                    reporteVentaCobroDetalle.metodo_cobro = new modeloMetodoPago().getMetodoPagoById(x.codigo_metodo_cobro).metodo;
                    listaReporteVentaCobroDetalle.Add(reporteVentaCobroDetalle);
                });

                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaReporteVentaEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", listaReporteVentaCobroDetalle);
                listaReportDataSource.Add(reporteProblemas);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprirmirVentaCobro.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir nota credito cxc 
        public bool imprimirNotaCreditoCxc(int codigoNotaCredito)
        {
            try
            {
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                cxc_nota_credito nota = new modeloCxcNotaCredito().getNotaCreditoById(codigoNotaCredito);

                empleado empleado=new empleado();
                empleado = singleton.getEmpleado();
                
                //hoja normal
                reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_nota_credito.rdlc";
                if (nota == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleado);
                reporteEncabezado.listaReporteVentaDevolucionDetalle =new modeloVentaDevolucion().getListaReporteVentaDevolucionDetalleByDevolucionId(nota.codigoDevolucion);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);

                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //llenar detalle
                reporte_nota_credito_cxc_detalle detalle=new reporte_nota_credito_cxc_detalle(nota);
                List<reporte_nota_credito_cxc_detalle> listaDetalle=new List<reporte_nota_credito_cxc_detalle>();
                listaDetalle.Add(detalle);
                
                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaDetalle);
                listaReportDataSource.Add(reporteD);

                ReportDataSource reporteD2 = new ReportDataSource("reporte_detalle_devolucion_detalle", reporteEncabezado.listaReporteVentaDevolucionDetalle);
                listaReportDataSource.Add(reporteD2);

                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirNotaCreditoCxc.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        //imprimir nota debito cxc
        public bool imprimirNotaDebitoCxc(int codigoNotaDebito)
        {
            try
            {
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                cxc_nota_debito nota = new modeloCxcNotaDebito().getNotaDebitoById(codigoNotaDebito);

                empleado empleado = new empleado();
                empleado = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_nota_debito.rdlc";
                if (nota == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleado);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);

                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //llenar detalle
                reporte_nota_debito_cxc_detalle detalle = new reporte_nota_debito_cxc_detalle(nota);
                List<reporte_nota_debito_cxc_detalle> listaDetalle = new List<reporte_nota_debito_cxc_detalle>();
                listaDetalle.Add(detalle);

                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaDetalle);
                listaReportDataSource.Add(reporteD);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirNotaDebitoCxc.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir pagos a compras agrupados por compra
        public bool imprimirCompraPagosAgrupadoByCompra(compra compra,suplidor suplidor,string tipoCompra,DateTime fechaInicial,DateTime fechaFinal,bool incluirRangoFecha,bool incluirSoloPagadas)
        {
            try
            {
                //datos generales
                String reporte = "";
                List<compra> listaCompra = new List<compra>();
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                List<reporte_compra_pago_detalle> listaReportePagosDetalles = new List<reporte_compra_pago_detalle>();
                List<compra_vs_pagos_detalles> listaCompraPagos=new List<compra_vs_pagos_detalles>(); 
                listaCompra = new modeloCompra().getListaCompra();
                listaCompraPagos = new modeloCompra().getListaCompraPagoDetalleCompleta();

                //filtros
                //fecha
                if (incluirRangoFecha == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (compra = new modeloCompra().getCompraById(x.codigo_compra)).fecha >= fechaInicial.Date && (compra = new modeloCompra().getCompraById(x.codigo_compra)).fecha <= fechaFinal.Date).ToList();
                    //listaCompra = listaCompra.FindAll(x => x.fecha>= fechaInicial.Date && x.fecha<=fechaFinal.Date);
                }
                //pagadas
                if (incluirSoloPagadas == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (compra = new modeloCompra().getCompraById(x.codigo_compra)).pagada == true).ToList();
                    //listaCompra = listaCompra.FindAll(x => x.pagada == true);
                }
                //compra
                if (compra != null)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (compra = new modeloCompra().getCompraById(x.codigo_compra)).codigo == compra.codigo).ToList();
                    //listaCompra = listaCompra.FindAll(x => x.codigo == compra.codigo);
                }
                //suplidor 
                if (suplidor != null)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (compra = new modeloCompra().getCompraById(x.codigo_compra)).cod_suplidor == suplidor.codigo).ToList();
                    //listaCompra = listaCompra.FindAll(x => x.cod_suplidor == suplidor.codigo);
                }
                //tipo compra
                if (tipoCompra != "")
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (compra = new modeloCompra().getCompraById(x.codigo_compra)).tipo_compra.ToLower().Contains(tipoCompra.ToLower())).ToList();
                    //listaCompra = listaCompra.FindAll(x => tipoCompra.ToLower().Contains(x.tipo_compra.ToLower()));
                }

                foreach (var x in listaCompraPagos)
                {
                    reporte_compra_pago_detalle reporteDetalle=new reporte_compra_pago_detalle(x);
                    listaReportePagosDetalles.Add(reporteDetalle);   
                }

                empleado empleado = new empleado();
                empleado = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_cuenta_por_pagar.Reporte.reporte_pagos_compras_agrupado_compra.rdlc";
                if (listaReportePagosDetalles == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleado);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);
                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //llenar detalle
                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaReportePagosDetalles);
                listaReportDataSource.Add(reporteD);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter,true);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCompraPagosAgrupadoByCompra.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir nota credito cxp
        public bool imprimirNotaCreditoCxp(int codigoNotaCredito)
        {
            try
            {
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                cxp_nota_credito nota = new modeloCxpNotaCredito().getNotaCreditoById(codigoNotaCredito);

                empleado empleado = new empleado();
                empleado = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_cuenta_por_pagar.Reporte.reporte_nota_credito.rdlc";
                if (nota == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleado);
                reporteEncabezado.listaReporteCompraDevolucionDetalle = new modeloCompraDevolucion().getListaReporteCompraDevolucionDetalleByDevolucionId(nota.codigoDevolucion);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);

                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //llenar detalle
                reporte_nota_credito_cxp_detalle detalle = new reporte_nota_credito_cxp_detalle(nota);
                List<reporte_nota_credito_cxp_detalle> listaDetalle = new List<reporte_nota_credito_cxp_detalle>();
                listaDetalle.Add(detalle);

                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaDetalle);
                listaReportDataSource.Add(reporteD);

                ReportDataSource reporteD2 = new ReportDataSource("reporte_detalle_devolucion_detalle", reporteEncabezado.listaReporteCompraDevolucionDetalle);
                listaReportDataSource.Add(reporteD2);

                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirNotaCreditoCxp.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir nota debito cxp
        public bool imprimirNotaDebitoCxp(int codigoNotaDebito)
        {
            try
            {
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                cxp_nota_debito nota = new modeloCxpNotaDebito().getNotaDebitoById(codigoNotaDebito);

                empleado empleado = new empleado();
                empleado = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_cuenta_por_pagar.Reporte.reporte_nota_debito.rdlc";
                if (nota == null)
                {
                    return false;
                }

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleado);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);

                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //llenar detalle
                reporte_nota_debito_cxp_detalle detalle = new reporte_nota_debito_cxp_detalle(nota);
                List<reporte_nota_debito_cxp_detalle> listaDetalle = new List<reporte_nota_debito_cxp_detalle>();
                listaDetalle.Add(detalle);

                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaDetalle);
                listaReportDataSource.Add(reporteD);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirNotaDebitoCxp.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir ventas mensuales graficos
        public bool imprimirVentasMensualesByRangoAnos(int anoInicial,int anoFinal, bool soloCobradas ,cliente cliente,empleado empleado)
        {
            try
            {
                //buscando ventas en base al anio
                List<venta> listaVentas=new List<venta>();
                listaVentas = new modeloVenta().getListaCompletaByRangoAnos(anoInicial,anoFinal);

                reporte_ventas_mensuales_grafico_detalles reporteDetalle=new reporte_ventas_mensuales_grafico_detalles();
                List<reporte_ventas_mensuales_grafico_detalles> listaDetalle =new List<reporte_ventas_mensuales_grafico_detalles>();
                List<reporte_ventas_mensuales_grafico_detalles> listaDetalleTemporal = new List<reporte_ventas_mensuales_grafico_detalles>();

                //filtros
                //solo cobradas
                if (soloCobradas == true)
                {
                    listaVentas = listaVentas.FindAll(x => x.pagada == true);
                }
                //por cliente
                if (cliente != null)
                {
                    listaVentas = listaVentas.FindAll(x => x.codigo_cliente == cliente.codigo);
                }
                //por empleado
                if (empleado !=null)
                {
                    listaVentas = listaVentas.FindAll(x => x.codigo_empleado ==empleado.codigo);
                }


                //llenando la lista detalle
                foreach (var x in listaVentas)
                {
                    reporteDetalle=new reporte_ventas_mensuales_grafico_detalles(x);
                    listaDetalle.Add(reporteDetalle);
                }

                listaDetalleTemporal=new List<reporte_ventas_mensuales_grafico_detalles>();
                foreach (var d1 in listaDetalle)
                {
                    reporteDetalle = new reporte_ventas_mensuales_grafico_detalles();
                    reporteDetalle.anoNumero = d1.anoNumero;
                    reporteDetalle.mesNumero = d1.mesNumero;
                    reporteDetalle.mesNombre = d1.mesNombre;
                    foreach (var d2 in listaDetalle)
                    {
                        if (reporteDetalle.anoNumero == d2.anoNumero && reporteDetalle.mesNumero == d2.mesNumero)
                        {
                            reporteDetalle.montoDescuento += d2.montoDescuento;
                            reporteDetalle.montoItbis += d2.montoDescuento;
                            reporteDetalle.montoNotaCredito += d2.montoNotaCredito;
                            reporteDetalle.montoNotaDebito += d2.montoNotaDebito;
                            reporteDetalle.montoSubTotal += d2.montoSubTotal;
                            reporteDetalle.montoTotal += d2.montoTotal;
                        }
                    }


                    if (listaDetalleTemporal.Where(x => x.anoNumero == reporteDetalle.anoNumero && x.mesNumero == reporteDetalle.mesNumero).Count() == 0)
                    {
                        // si no existe el mes junto con el anio se agrega a la lista
                        listaDetalleTemporal.Add(reporteDetalle);
                    }
                }

                listaDetalle = listaDetalleTemporal;

                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();

                empleado empleadoSesion = new empleado();
                empleadoSesion = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_gerencia.Reporte.reporte_ventas_mensuales_graficos.rdlc";

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleadoSesion);
                reporteEncabezado.anioInicial = anoInicial;
                reporteEncabezado.anioFinal = anoFinal;
                if (cliente != null)
                {
                    reporteEncabezado.codigoCliente = cliente.codigo;
                    reporteEncabezado.cliente = cliente.nombre;
                }
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);
                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);

                //reporte detalle
                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaDetalle);
                listaReportDataSource.Add(reporteD);
                
                //reporte parametros
                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirVentasMensualesByRangoAnos.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir cuadre caja general
        public bool imprimirCuadreCajaGeneral(int idCuadreCaja)
        {
            try
            {

                //buscando cuadre caja
                cuadre_caja cuadreCaja;
                cuadreCaja = new modeloCuadreCaja().getCuadreCajaById(idCuadreCaja);
               
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();

                empleado empleadoSesion = new empleado();
                empleadoSesion = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_facturacion.Reporte.reporte_cuadre_caja_general.rdlc";

                //llenar encabezado
                reporte_encabezado_general reporteEncabezado = new reporte_encabezado_general(empleadoSesion);
                List<reporte_encabezado_general> listaReporteEncabezado = new List<reporte_encabezado_general>();
                listaReporteEncabezado.Add(reporteEncabezado);
                ReportDataSource reporteE = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteE);


                //reporte detalle
                List<cuadre_caja_detalle> listaCuadreCajaDetalle=new List<cuadre_caja_detalle>();
                listaCuadreCajaDetalle.Add(cuadreCaja.cuadre_caja_detalle);
                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaCuadreCajaDetalle);
                listaReportDataSource.Add(reporteD);

                //reporte parametros
                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);


                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCuadreCajaGeneral.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //imprimir reporte de cobros filtrado
        public bool imprimirCobrosFiltrado(empleado empleado, cliente cliente, venta venta, string tipoVenta, Boolean incluirRangoFechaVenta, DateTime fechaInicialVenta, DateTime fechaFinalVenta, bool soloVentasPagadas)
        {
            try
            {
                reporte_cobros_encabezado reporteEncabezado = new reporte_cobros_encabezado();
                reporte_cobros_detalle reporteDetalle=new reporte_cobros_detalle();
                sistemaConfiguracion sistemaConfiguracion=new sistemaConfiguracion();
                sistemaConfiguracion = new modeloSistemaConfiguracion().getSistemaConfiguracion();

                reporteEncabezado.listaDetalle = new List<reporte_cobros_detalle>();


                empresa empresa = new empresa();
                empresa = new modeloEmpresa().getEmpresaByEmpleadoId(empleado.codigo);

                sucursal sucursal = new sucursal();
                sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal);

                List<cliente> listaCliente = new List<cliente>();
                listaCliente = new modeloCliente().getListaCompleta();

                List<venta> listaVenta = new List<venta>();
                listaVenta = new modeloVenta().getListaCompleta();

                //llenando el encabezado
                reporteEncabezado.empleadoImpresion = empleado.nombre;
                if (sistemaConfiguracion.tipoVentanaCuadreCaja == 1)
                {
                    //rd
                    reporteEncabezado.fecha_impresion = utilidades.getFecha_MM_dd_yyyy_hh_mm_ss_tt(DateTime.Now);
                }
                else if (sistemaConfiguracion.tipoVentanaCuadreCaja == 2)
                {
                    //usa
                    reporteEncabezado.fecha_impresion = utilidades.getFecha_MM_dd_yyyy_hh_mm_ss_tt(DateTime.Now);
                }
                reporteEncabezado.empresa = empresa.nombre;
                reporteEncabezado.direccion = sucursal.direccion;
                reporteEncabezado.rnc = empresa.rnc;
                reporteEncabezado.telefonos = sucursal.telefono1 + " - " + sucursal.telefono2;

                //filtrando por cliente
                if (cliente != null)
                {
                    listaVenta = listaVenta.FindAll(x => x.codigo_cliente == cliente.codigo);
                }
                //filtrando por venta
                if (venta != null)
                {
                    listaVenta = listaVenta.FindAll(x => x.codigo == venta.codigo);
                }
                //filtrando por tipo venta
                if (tipoVenta != "")
                {
                    listaVenta = listaVenta.FindAll(x => tipoVenta.ToLower().Contains(x.tipo_venta.ToLower()));
                }

                //rango fechas ventas
                if (incluirRangoFechaVenta == true)
                {
                    listaVenta = listaVenta.FindAll(x => x.fecha >= fechaInicialVenta.Date && x.fecha <= fechaFinalVenta.Date);
                }

                //si solo son ventas pagadas
                if (soloVentasPagadas == true)
                {
                    listaVenta = listaVenta.FindAll(x => x.pagada == true);
                }

                foreach (var clienteActual in listaCliente)
                {
                    foreach (var ventaActual in listaVenta)
                    {
                        if (clienteActual.codigo == ventaActual.codigo_cliente)
                        {
                            reporteDetalle = new reporte_cobros_detalle(ventaActual.codigo);
                            reporteEncabezado.listaDetalle.Add(reporteDetalle);
                        }
                    }
                }

                reporteEncabezado.listaDetalle = reporteEncabezado.listaDetalle.OrderByDescending(x => x.idVenta).ToList();

                //datos generales
                String reporte = "IrisContabilidad.modulo_cuenta_por_cobrar.Reporte.reporte_cobros.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();

                //encabezado
                List<reporte_cobros_encabezado> listaCobroReporteEncabezado = new List<reporte_cobros_encabezado>();
                listaCobroReporteEncabezado.Add(reporteEncabezado);
                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaCobroReporteEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                //detalle
                ReportDataSource reporteDetalles = new ReportDataSource("reporte_detalle", reporteEncabezado.listaDetalle);
                listaReportDataSource.Add(reporteDetalles);

                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter, true);
                ventana.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCobrosFiltrado.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




    }
}
