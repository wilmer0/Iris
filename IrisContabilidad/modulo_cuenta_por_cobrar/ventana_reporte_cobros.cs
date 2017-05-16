using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.clases_reportes_modelos;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;
using IrisContabilidad.ventanas_comunes;
using Microsoft.Reporting.WinForms;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_reporte_cobros : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private venta venta;
        private venta_detalle VentaDetalle;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobroDetalle;
        private cliente cliente;
        private metodo_pago metodoPago;
        private reporte_cobros_encabezado reporteCobrosEncabezado;


        //modelos
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCobro modeloCobro = new modeloCobro();
        modeloMetodoPago modeloMetodoPago = new modeloMetodoPago();
        private modelo_reporte_cobros modeloReporteCobros = new modelo_reporte_cobros();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private bool incluirRangoFechaVenta = false;
        bool SoloVentasPagadas = false;
        private DateTime fechaInicialVentaDateTime;
        private DateTime fechaFinalVentaDateTime;
        private string tipoVenta="";
        
        //listas
        private List<reporte_cobros_encabezado> listaCobroReporteEncabezado; 
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;

        //Proceso
        private ventana_procesando procesando;
        private BackgroundWorker SicronizarProceso = new BackgroundWorker();

       
        public ventana_reporte_cobros()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana reporte cobros");
            this.Text = tituloLabel.Text;
            loadVentana();
            loadListaVentaCobros();
            SicronizarProceso.WorkerReportsProgress = true;
            SicronizarProceso.DoWork += LoadReporte;
            SicronizarProceso.ProgressChanged += ProcesoRun;
            SicronizarProceso.RunWorkerCompleted += ProcesoCompleto;
        }

        private void LoadReporte(object sender, DoWorkEventArgs e)
        {
            SicronizarProceso.ReportProgress(10);
            try
            {
                loadImprimir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesoRun(object sender, ProgressChangedEventArgs e)
        {
            if (procesando == null)
            {
                procesando = new ventana_procesando();
                procesando.ShowDialog();
            }
        }

        private void ProcesoCompleto(object sender, RunWorkerCompletedEventArgs e)
        {
            procesando.Close();
            procesando = null;
        }

        public void loadListaVentaCobros()
        {
            try
            {
                listaVenta=new List<venta>();
                listaVentaDetalle=new List<venta_detalle>();
                listaVentacobroDetalle = new List<venta_vs_cobros_detalles>();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaVentaCobros.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void loadVentana()
        {
            try
            {

                clienteIdText.Focus();
                clienteIdText.SelectAll();

                cliente = null;
                clienteIdText.Text = "";
                clienteLabel.Text = "";

                venta = null;
                ventaIdText.Text = "";
                ventaLabel.Text = "";

                tipoVentaComboBox.Text = "";
                
                checkBoxIncluirRangoFechaVenta.Checked = false;
                //fecha ventas
                fechaInicialVentaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                fechaFinalVentaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                fechaInicialVentaText.Enabled = (bool)checkBoxIncluirRangoFechaVenta.Checked;
                fechaFinalVentaText.Enabled = (bool)checkBoxIncluirRangoFechaVenta.Checked;



                dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCobros()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }

                reporteCobrosEncabezado.listaDetalle.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.idCliente, x.cliente, x.idVenta,x.tipoVenta, x.NCF, x.montoFactura.ToString("N"), x.montoCobrado.ToString("N"), x.montoPendiente.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCobros.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool validarGetAcion()
        {
            try
            {
                //incluir fecha venta
                if (checkBoxIncluirRangoFechaVenta.Checked == true)
                {
                    incluirRangoFechaVenta = true;
                }
                else
                {
                    incluirRangoFechaVenta = false;
                }

                //fechas ventas
                fechaInicialVentaDateTime = Convert.ToDateTime(fechaInicialVentaText.Text);
                fechaFinalVentaDateTime = Convert.ToDateTime(fechaFinalVentaText.Text);
                
                //tipo venta
                if (tipoVentaComboBox.Text != "")
                {
                    tipoVenta = tipoVentaComboBox.Text;
                }
                else
                {
                    tipoVenta = "";
                }
                //solo ventas pagas
                if (checkBoxSoloVentasPagadas.Checked == true)
                {
                    SoloVentasPagadas = true;
                }
                else
                {
                    SoloVentasPagadas = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                if (!validarGetAcion())
                {
                    return;
                }
                if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                reporteCobrosEncabezado = modeloReporteCobros.getReporteCobrosEncabezado(empleado, cliente, venta, tipoVenta, incluirRangoFechaVenta, fechaInicialVentaDateTime, fechaFinalVentaDateTime, SoloVentasPagadas);
                loadCobros();   
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadImprimir()
        {
            try
            {
                if (reporteCobrosEncabezado == null)
                {
                    MessageBox.Show("Debe procesar antes de imprimir.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //datos generales
                String reporte = "IrisContabilidad.reportes.reporte_cobros.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
               
                //encabezado
                listaCobroReporteEncabezado=new List<reporte_cobros_encabezado>();
                listaCobroReporteEncabezado.Add(reporteCobrosEncabezado);
                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaCobroReporteEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                //detalle
                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", reporteCobrosEncabezado.listaDetalle);
                listaReportDataSource.Add(reporteProblemas);

                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();
                
                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter,true);
                ventana.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadImprimir.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_reporte_cobros_Load(object sender, EventArgs e)
        {

        }

        public void loadCliente()
        {
            try
            {
                clienteIdText.Text = "";
                clienteLabel.Text = "";
                if (cliente != null)
                {
                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteLabel.Text = cliente.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana=new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        public void loadVenta()
        {
            try
            {
                ventaIdText.Text = "";
                ventaLabel.Text = "";
                if (venta != null)
                {
                    ventaIdText.Text = venta.codigo.ToString();
                    ventaLabel.Text = venta.ncf;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error loadVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_venta ventana= new ventana_busqueda_venta();
            ventana.Owner = this;
            ventana.ShowDialog();
            if ((venta == ventana.getObjeto()) != null)
            {
                venta = ventana.getObjeto();
                loadVenta();
            }
        }

        private void checkBoxIncluirRangoFechaVenta_CheckStateChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SicronizarProceso.RunWorkerAsync();
            //loadImprimir();
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    clienteIdText.Text = "";
                    clienteLabel.Text = "";
                    loadCliente();   
                }
            }
            catch (Exception)
            {
                cliente = null;
            }
        }

        private void ventaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    venta = modeloVenta.getVentaById(Convert.ToInt16(ventaIdText.Text));
                    ventaIdText.Text = "";
                    ventaLabel.Text = "";
                    loadVenta();
                }
            }
            catch (Exception)
            {
                venta = null;
            }
        }

        private void checkBoxIncluirRangoFechaVenta_CheckedChanged(object sender, EventArgs e)
        {
            //fecha ventas
            fechaInicialVentaText.Enabled = (bool)checkBoxIncluirRangoFechaVenta.Checked;
            fechaFinalVentaText.Enabled = (bool)checkBoxIncluirRangoFechaVenta.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cliente = null;
            loadCliente();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            venta = null;
            loadVenta();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            tipoVentaComboBox.SelectedIndex = 0;
        }
    }
}
