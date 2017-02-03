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


        utilidades utilidades=new utilidades();
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

        public bool imprirmiCompraPago(int codigoPago)
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

    }
}
