using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using Microsoft.Reporting.WinForms;
using _7ADMFIC_1._0.VentanasComunes;

namespace IrisContabilidad.modelos
{
    public class ModeloReporte
    {

        private empleado empleado;
        utilidades utilidades=new utilidades();
        singleton singleton=new singleton();

        //compra
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
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprirmiCompraPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //venta
        public bool imprimirVenta(int idVenta)
        {
            try
            {
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
                    reporte = "IrisContabilidad.reportes.reporte_venta_hoja_completa.rdlc";
                }
                else if (cajero.tipoImpresionVenta == 2)
                {
                    //hoja rollo de 3 "
                    reporte = "IrisContabilidad.reportes.reporte_venta_hoja_rollo.rdlc";
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

        //venta cobro
        public bool imprimirVentaCobro(int codigoCobro)
        {
            try
            {
                String reporte = "IrisContabilidad.reportes.reporte_venta_cobro_hoja_completa.rdlc";
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

        //nota credito
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
        
        //nota debito
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

        //pagos a compras agrupados por compra
        public bool imprimirCompraPagosAgrupadoByCompra(compra compra,suplidor suplidor,string tipoCompra,DateTime fechaInicial,DateTime fechaFinal,bool incluirRangoFecha,bool incluirSoloPagadas)
        {
            try
            {
                //datos generales
                String reporte = "";

                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                List<reporte_compra_pago_agrupado_compra> listaReporteCompraPagoAgrupadoCompra=new List<reporte_compra_pago_agrupado_compra>();
                List<compra> listaCompra=new List<compra>();

                listaCompra = new modeloCompra().getListaCompra();

                //filtros
                //fecha
                if (incluirRangoFecha == true)
                {
                    listaCompra = listaCompra.FindAll(x => x.fecha>= fechaInicial.Date && x.fecha<=fechaFinal.Date);
                }
                //pagadas
                if (incluirSoloPagadas == true)
                {
                    listaCompra = listaCompra.FindAll(x => x.pagada == true);
                }
                //compra
                if (compra != null)
                {
                    listaCompra = listaCompra.FindAll(x => x.codigo == compra.codigo);
                }
                //suplidor 
                if (suplidor != null)
                {
                    listaCompra = listaCompra.FindAll(x => x.cod_suplidor == suplidor.codigo);
                }
                //tipo compra
                if (tipoCompra != "")
                {
                    listaCompra = listaCompra.FindAll(x => tipoCompra.ToLower().Contains(x.tipo_compra.ToLower()));
                }

                foreach (var x in listaCompra)
                {
                    reporte_compra_pago_agrupado_compra reporteCompra=new reporte_compra_pago_agrupado_compra(x);
                    listaReporteCompraPagoAgrupadoCompra.Add(reporteCompra);   
                }

                empleado empleado = new empleado();
                empleado = singleton.getEmpleado();

                //hoja normal
                reporte = "IrisContabilidad.modulo_cuenta_por_pagar.Reporte.reporte_pagos_compras_agrupado_compra.rdlc";
                if (listaReporteCompraPagoAgrupadoCompra == null)
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
                ReportDataSource reporteD = new ReportDataSource("reporte_detalle", listaReporteCompraPagoAgrupadoCompra);
                listaReportDataSource.Add(reporteD);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCompraPagosAgrupadoByCompra.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
