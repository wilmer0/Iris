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



        public void imprimirCompra(int idcompra)
        {
            try
            {
                //datos generales
                String reporte = "IrisContabilidad.reportes.reporte_compra_hoja_completa.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                compra compra = new modeloCompra().getCompraById(idcompra);
                
                if (compra == null)
                {
                    return;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimirCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
