using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace _7ADMFIC_1._0.VentanasComunes
{


    public partial class VisorReporteComun : Form
    {


        //primters PrinterDefaul;
        //Utilitarios util= new Utilitarios();
        //public VisorReporteComun(String reporte, List<ReportDataSource> lista, usuario usuario)
        //{
        //    InitializeComponent();
        //    List<empresa> listaempresa = new List<empresa>();
        //    listaempresa.Add(usuario.empresa1);
        //    ReportDataSource empresaDataSource = new ReportDataSource("empresa", listaempresa);
        //    lista.Add(empresaDataSource);
        //    List<usuario> listausuario = new List<usuario>();
        //    ReportDataSource usuarioDataSource = new ReportDataSource("usuario", listausuario);
        //    lista.Add(usuarioDataSource);
        //    GetLoad(reporte, lista,null);
        //}
        public VisorReporteComun(String reporte, List<ReportDataSource> lista, List<ReportParameter> ListaReportParameter,Boolean IncluirEmpresa, Boolean IncluirUsuario, Boolean IncluirFechaActual, Boolean ExportarExel = false)
        {
            InitializeComponent();
            ExportarExel = ExportarExel;
            //List<empresa> listaempresa = new List<empresa>();
            //if (IncluirEmpresa)
            //{
            //    listaempresa.Add(usuario.empresa1);
            //    ReportDataSource empresaDataSource = new ReportDataSource("empresa", listaempresa);
            //    lista.Add(empresaDataSource);
            //}
            //if (IncluirUsuario)
            //{
            //    List<usuario> listausuario = new List<usuario>();
            //    listausuario.Add(usuario);
            //    ReportDataSource usuarioDataSource = new ReportDataSource("usuario", listausuario);
            //    lista.Add(usuarioDataSource);
            //}
            //if (IncluirFechaActual)
            //{
            //    if (ListaReportParameter == null)
            //    {
            //        ListaReportParameter = new List<ReportParameter>();
            //    }
            //    ReportParameter parameter = new ReportParameter("fecha", util.getFormaFechaNormal(DateTime.Now));
            //    ListaReportParameter.Add(parameter);
            //    GetLoad(reporte, lista, ListaReportParameter);
            //}
            GetLoad(reporte, lista, ListaReportParameter);
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



        //public void ImprimirMedio(String Impresora)
        //{
        //    PageSettings _pageSettings = new PageSettings();
        //    _pageSettings.PaperSize = new System.Drawing.Printing.PaperSize("MYNEWSIZE", 850, 550);
        //    _pageSettings.PrinterSettings.PrinterName = Impresora;
        //    _pageSettings.Margins.Left = 0;
        //    _pageSettings.Margins.Right = 0;
        //    _pageSettings.Margins.Bottom = 0;
        //    _pageSettings.Margins.Top = 0;

        //    _pageSettings.Landscape = false;

        //    AutoPrintClsMedio2 autoprintme = new AutoPrintClsMedio2(Reporte.LocalReport, _pageSettings);

        //    autoprintme.Print();
        //}
    }
}
