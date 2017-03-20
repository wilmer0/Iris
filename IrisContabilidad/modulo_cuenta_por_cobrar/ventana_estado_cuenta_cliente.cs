using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.clases_reportes_modelos;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;
using Microsoft.Reporting.WinForms;
using _7ADMFIC_1._0.VentanasComunes;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_estado_cuenta_cliente : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private cliente cliente;
        private reporte_estado_cuenta_cliente_encabezado reporteEncabezado;
        private reporte_encabezado_general reporteEncabezadoGeneral;
        
        //modelos
        modeloCliente modeloCliente = new modeloCliente();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        private modelo_reporte_estado_cuenta_cliente modeloReporte = new modelo_reporte_estado_cuenta_cliente();
        
        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private DateTime fechaFinalDateTime;
        
        //listas
        private List<reporte_encabezado_general> listaReporteEncabezado;
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;


        public ventana_estado_cuenta_cliente()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana estado cuenta cliente");
            this.Text = tituloLabel.Text;
            loadVentana();
            loadListaVentaCobros();
        }
        public void loadListaVentaCobros()
        {
            try
            {
                listaVenta = new List<venta>();
                listaVentaDetalle = new List<venta_detalle>();
                listaVentacobroDetalle = new List<venta_vs_cobros_detalles>();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaVentaCobros.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVentana()
        {
            try
            {
                fechaFinalDateTime=DateTime.Today;
                if (reporteEncabezado != null)
                {
                    //cargar
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();

                    cliente = null;
                    clienteIdText.Text = "";
                    clienteLabel.Text = "";

                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteLabel.Text = cliente.nombre;

                    loadLista();
                }
                else
                {
                    //limpiar

                    clienteIdText.Focus();
                    clienteIdText.SelectAll();

                    clienteIdText.Text = "";
                    clienteLabel.Text = "";

                    //fechaFinalVentaText.Text = utilidades.getFechaddMMyyyy(DateTime.Today);
                    
                }
                dataGridView1.Rows.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadLista()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }

                reporteEncabezado.listaDetalle.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.idCliente,x.cliente, x.montoFacturado.ToString("N"),x.montoNotasDebito.ToString("N"), x.montoCobrado.ToString("N"),x.montoNotasCredito.ToString("N"), x.montoPendiente.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {
                //incluir fecha venta
                //DateTime fecha;
                //if (DateTime.TryParse(fechaFinalVentaText.Text, out fecha) == false)
                //{
                //    fechaFinalVentaText.Focus();
                //    fechaFinalVentaText.SelectAll();
                //    MessageBox.Show("Error formato de fecha incorrecto");
                //    return false;
                //}

                //fechaFinalDateTime = Convert.ToDateTime(fechaFinalVentaText.Text);

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

                reporteEncabezado = modeloReporte.getReporteEstadoCuentaEncabezado(cliente, empleado,fechaFinalDateTime);
                loadLista();

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
                if (reporteEncabezado == null)
                {
                    MessageBox.Show("Debe procesar antes de imprimir.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //datos generales
                String reporte = "IrisContabilidad.reportes.reporte_estado_cuenta_cliente.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();


                //encabezado general
                listaReporteEncabezado = new List<reporte_encabezado_general>();
                reporteEncabezadoGeneral=new reporte_encabezado_general(empleado);
                listaReporteEncabezado.Add(reporteEncabezadoGeneral);
                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado", listaReporteEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                //detalle
                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", reporteEncabezado.listaDetalle);
                listaReportDataSource.Add(reporteProblemas);

                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter);
                ventana.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadImprimir.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                cliente = null;
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
        private void ventana_estado_cuenta_cliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana = new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadImprimir();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cliente = null;
            loadCliente();
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    clienteIdText.Text = "";
                    clienteLabel.Text = "";

                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    loadCliente();
                }
            }
            catch (Exception)
            {
                cliente = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reporteEncabezado = null;
            loadVentana();
        }
    }
}
