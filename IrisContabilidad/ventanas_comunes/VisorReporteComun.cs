using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using Microsoft.Reporting.WinForms;

namespace IrisContabilidad.ventanas_comunes
{


    public partial class VisorReporteComun : Form
    {
        //objetos
        private singleton singleton = new singleton();
        private empleado empleado;

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloLogReporteGenerado modeloLogReporte=new modeloLogReporteGenerado();

        
        public VisorReporteComun(String reporte, List<ReportDataSource> lista, List<ReportParameter> ListaReportParameter,bool agregarLog=false)
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            GetLoad(reporte, lista, ListaReportParameter);
            if (agregarLog == true)
            {
                agregarLogReporte();
            } 
        }

        public void agregarLogReporte()
        {
            try
            {
                log_reportes_generados log=new log_reportes_generados();
                log.codigo = modeloLogReporte.getNext();
                log.codigoEmpleado = empleado.codigo;
                log.fecha = DateTime.Today;
                log.fechaHora = DateTime.Now;
                log.reporteGenerado = Reporte.LocalReport.ReportEmbeddedResource.ToString();
                modeloLogReporte.agregarLogReporteGenerado(log);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregando el log de reporte.: "+ex.ToString());
            }
        }

        private void GetLoad(String reporte, List<ReportDataSource> lista, List<ReportParameter> ListaReportParameter)
        {
            Reporte.LocalReport.ReportEmbeddedResource = reporte;
            lista.ForEach(x =>
            {
                 Reporte.LocalReport.DataSources.Add(x);
            });
            if(ListaReportParameter!=null)
            {
                Reporte.LocalReport.SetParameters(ListaReportParameter);
            }
        }

        private void visor_reporte_Load(object sender, EventArgs e)
        {
            Reporte.SetDisplayMode(DisplayMode.PrintLayout);
            this.Reporte.RefreshReport();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

        }
    }
}
