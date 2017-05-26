using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.clases_reportes_modelos;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;
using IrisContabilidad.ventanas_comunes;
using Microsoft.Reporting.WinForms;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_estado_cuenta_suplidor : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private suplidor suplidor;
        private reporte_encabezado_general reporteEncabezadoGeneral;
        

        //modelos
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        //private modelo_reporte_estado_cuenta_cliente modeloReporte = new modelo_reporte_estado_cuenta_cliente();
        ModeloReporte modeloReporte=new ModeloReporte();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private DateTime fechaFinalDateTime;
        private bool imprimir = false;

        //Proceso
        private ventana_procesando procesando;
        private BackgroundWorker SicronizarProceso = new BackgroundWorker();


        //listas
        private List<reporte_encabezado_general> listaReporteEncabezadoGeneral; 


        public ventana_estado_cuenta_suplidor()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana estado cuenta suplidor");
            this.Text = tituloLabel.Text;
            loadVentana();
            
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
                reporteEncabezadoGeneral = modeloReporte.imprimirEstadoCuentaSuplidor(suplidor, fechaFinalDateTime, imprimir);
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
            loadLista();
        }

        public void loadVentana()
        {
            try
            {
                fechaFinalDateTime=DateTime.Today;
                
                    //limpiar
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
                    suplidorIdText.Text = "";
                    suplidorLabel.Text = "";
                    //fechaFinalVentaText.Text = utilidades.getFechaddMMyyyy(DateTime.Today);
                    
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
                if (reporteEncabezadoGeneral == null)
                {
                    return;
                }
                foreach (var x in reporteEncabezadoGeneral.listaReporteEstadoCuentaSuplidorDetalle)
                {
                    dataGridView1.Rows.Add(x.suplidor,x.suplidor, x.montoFacturado.ToString("N"),x.montoNotasDebito.ToString("N"), x.montoPagado.ToString("N"),x.montoNotasCredito.ToString("N"), x.montoPendiente.ToString("N"));
                }
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

                SicronizarProceso.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        public void loadSuplidor()
        {
            try
            {
                suplidorIdText.Text = "";
                suplidorLabel.Text = "";
                if (suplidor != null)
                {
                    suplidorIdText.Text = suplidor.codigo.ToString();
                    suplidorLabel.Text = suplidor.nombre;
                }
            }
            catch (Exception ex)
            {
                suplidor = null;
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            imprimir = false;
            getAction();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana = new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!validarGetAcion())
            {
                return;
            }
            imprimir = true;
            SicronizarProceso.RunWorkerAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            suplidor = null;
            loadSuplidor();
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
                    suplidorIdText.Text = "";
                    suplidorLabel.Text = "";

                    suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(suplidorIdText.Text));
                    loadSuplidor();
                }
            }
            catch (Exception)
            {
                suplidor = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reporteEncabezadoGeneral = null;
            loadVentana();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }


 
    }

}
