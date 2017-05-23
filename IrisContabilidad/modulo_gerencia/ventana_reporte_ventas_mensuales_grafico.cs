using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IrisContabilidad.modulo_gerencia
{
    public partial class ventana_reporte_ventas_mensuales_grafico : formBase
    {
        //objetos
        private almacen almacen;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private empleado empleadoSesion;
        private cliente cliente;

        //modelos
        ModeloReporte modeloReporte=new ModeloReporte();
        modeloCliente modelocliente=new modeloCliente();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();

        //variables
        private int anioInicial = 0;
        private int anioFinal = 0;
        private bool soloCobradas = false;

        //Proceso
        private ventana_procesando procesando;
        private BackgroundWorker SicronizarProceso = new BackgroundWorker();



        public ventana_reporte_ventas_mensuales_grafico()
        {
            InitializeComponent();
            empleadoSesion = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSesion, "reporte ventas mensuales gráfico");
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
                modeloReporte.imprimirVentasMensualesByRangoAnos(anioInicial, anioFinal, soloCobradas, cliente, empleado);
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

        public void loadVentana()
        {
            try
            {
                anoInicialText.Focus();
                anoInicialText.SelectAll();

                anoInicialText.Text = DateTime.Today.Year.ToString();
                anofinalText.Text = DateTime.Today.Year.ToString();

                cliente = null;
                loadCliente();
                empleado = null;
                loadEmpleado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception)
            {
                
            }
        }

        public void loadEmpleado()
        {
            try
            {
                empleadoIdText.Text = "";
                empleadoLabel.Text = "";
                if (empleado != null)
                {
                    empleadoIdText.Text = empleado.codigo.ToString();
                    empleadoLabel.Text = empleado.nombre;
                }
            }
            catch (Exception)
            {

            }
        }

        public bool ValidarGetAction()
        {
            try
            {
                
                //validar fecha
                if (anoInicialText.Text == "")
                {
                    anoInicialText.Focus();
                    anoInicialText.SelectAll();
                    System.Windows.MessageBox.Show("Falta el año inicial", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return false;
                }
                if (anofinalText.Text == "")
                {
                    anofinalText.Focus();
                    anofinalText.SelectAll();
                    System.Windows.MessageBox.Show("Falta el año final", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return false;
                }

                if (anoInicialText.Text.Length != 4)
                {
                    anoInicialText.Focus();
                    anoInicialText.SelectAll();
                    System.Windows.MessageBox.Show("El año inicial debe tener 4 digitos", "", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return false;
                }
                if (anofinalText.Text.Length!=4)
                {
                    anofinalText.Focus();
                    anofinalText.SelectAll();
                    MessageBox.Show("debe tener 4 digitos", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }

                anioInicial = Convert.ToInt16(anoInicialText.Text);
                anioFinal = Convert.ToInt16(anofinalText.Text);
                if (radioSoloVentasCobradas.Checked == true)
                {
                    soloCobradas = true;
                }
                else
                {
                    soloCobradas = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                almacen = null;
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void GetAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                SicronizarProceso.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ventana_reporte_ventas_mensuales_grafico_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarGetAction())
            {
                return;
            }
            GetAction();
        }

        private void nombreText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void anoInicialText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                anofinalText.Focus();
                anofinalText.SelectAll();
            }
        }

        private void anofinalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clienteIdText.Focus();
                clienteIdText.SelectAll();
            }
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana=new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();

            if ((ventana.DialogResult == DialogResult.OK))
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_empleado ventana = new ventana_busqueda_empleado();
            ventana.Owner = this;
            ventana.ShowDialog();

            if ((ventana.DialogResult == DialogResult.OK))
            {
                empleado = ventana.getObjeto();
                loadEmpleado();
            }
        }

        private void empleadoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
