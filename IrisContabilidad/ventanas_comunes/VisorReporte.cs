using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;


namespace IrisContabilidad.ventanas_comunes
{
    public partial class VisorReporte : Form
    {
        //private finalizacion_productos finalizacion;
        //private string rutaReporte;
        //public VisorReporte(string ruta,finalizacion_productos finalizacion)
        //{
        //    InitializeComponent();
        //    this.finalizacion = finalizacion;
        //    this.rutaReporte = ruta;
        //    LoadR();
        //}


        private void LoadR()
        {
            ////reportViewer1.LocalReport.ReportPath = @"C:\Users\7soft\Documents\GitHub\7ADMFIC-7SOFT\APP-4.0\7ADMFIC-1.0\7ADMFIC-1.0\ModuloInventarioFac\CierreCaja\CierreReportViewr.rdlc";
            ////reportViewer1.LocalReport.ReportEmbeddedResource = "_7ADMFIC_1._0.ModuloGerentes.ReporteVentas.ReporteVentasMensuales.rdlc";
           

            ////var setup = this.reportViewer1.GetPageSettings();
            ////setup.Margins = new System.Drawing.Printing.Margins(1, 1, 1, 1);
            ////this.reportViewer1.SetPageSettings(setup);

            //reportViewer1.LocalReport.ReportEmbeddedResource = rutaReporte;
           
            //FinalizacionReporte finalizacionReporte= new FinalizacionReporte(finalizacion);
            //List<empresa> ListaEmpresa = new List<empresa>();
            //ListaEmpresa.Add(finalizacion.usuario1.empresa1);
            //ReportDataSource rdSEmpresa = new ReportDataSource("Empresa", ListaEmpresa);

            //List<FinalizacionReporte> ListaFinalizacion = new List<FinalizacionReporte>();
            //ListaFinalizacion.Add(finalizacionReporte);
            
            //ReportDataSource rdSFinalizacion = new ReportDataSource("Finalizacion", ListaFinalizacion);
            //ReportDataSource rdSDetalleFinalizacion = new ReportDataSource("DetalleFinalizacion", finalizacionReporte.ListaDetalleProductoFinalizacion);

            //reportViewer1.LocalReport.DataSources.Add(rdSEmpresa);
            //reportViewer1.LocalReport.DataSources.Add(rdSFinalizacion);
            //reportViewer1.LocalReport.DataSources.Add(rdSDetalleFinalizacion);

            // MessageBox.Show(Path.GetFullPath( @"\CierreCaja"));
        }

        private void VisorReporte_Load(object sender, EventArgs e)
        {


            PageSettings pageSettings = new PageSettings();
            Margins margin = new Margins(25, 1, 25, 1);

            PaperSize paperSize = new PaperSize();
            paperSize.RawKind = (int)PaperKind.A4;
            paperSize.Width = 850;
            paperSize.Height = 11000;
            pageSettings.Landscape = false;
            pageSettings.PaperSize = paperSize;
            pageSettings.Margins = margin;
            reportViewer1.SetPageSettings(pageSettings);
            reportViewer1.RefreshReport();


        }

        private void VisorReporte_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void reportViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void VisorReporte_KeyPress(object sender, KeyPressEventArgs e)
        {

         
        }

        private void VisorReporte_Load_1(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
