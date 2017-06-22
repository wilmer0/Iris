using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_egreso_caja : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        egreso_caja egresoCaja;
        private caja_ingresos_egresos_conceptos concepto;
        private cajero cajero;




        //modelos
        modeloEgresoCaja modeloEgreso = new modeloEgresoCaja();
        modeloCajaIngresosEgresosConceptos modeloConcepto=new modeloCajaIngresosEgresosConceptos();
        modeloCajero modeloCajero=new modeloCajero();


        public ventana_egreso_caja()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana egreso de caja");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (egresoCaja != null)
                {
                    conceptoIdText.Focus();
                    conceptoIdText.SelectAll();

                    concepto = modeloConcepto.getConceptoById(egresoCaja.codigo_concepto);
                    loadConcepto();
                    
                    montoText.Text = egresoCaja.monto.ToString("N");
                    
                    detalleText.Text = egresoCaja.detalle;
                    
                    activoCheck.Checked = Convert.ToBoolean(egresoCaja.activo);
                }
                else
                {   
                    conceptoIdText.Focus();
                    conceptoIdText.SelectAll();
                    conceptoIdText.Text = "";

                    concepto = null;
                    conceptoIdText.Text = "";
                    conceptoText.Text = "";

                    montoText.Text = "";
                    
                    detalleText.Text = "";
                    
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar nombre
                if (concepto==null)
                {
                    MessageBox.Show("Falta el concepto del egreso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conceptoIdText.Focus();
                    conceptoIdText.SelectAll();
                    return false;
                }
                //validar numero itebis
                if (montoText.Text == "")
                {
                    MessageBox.Show("Falta el monto del egreso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    montoText.Focus();
                    montoText.SelectAll();
                    return false;
                }
                //validar que el usuario sea cajero
                cajero=new cajero();
                cajero = modeloCajero.getCajeroByIdEmpleado(empleado.codigo);
                if (cajero == null)
                {
                    MessageBox.Show("para poder realizar esta operación debe de ser cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                //validando campos necesarios
                if (validarGetAction() == false)
                {
                    return;
                }

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                bool crear = false;
                //se instancia el empleado si esta nulo
                if (egresoCaja == null)
                {
                    egresoCaja = new egreso_caja();
                    crear = true;
                    egresoCaja.codigo = modeloEgreso.getNext();
                    egresoCaja.fecha = DateTime.Today;
                    egresoCaja.cuadrado = false;
                    egresoCaja.codigo_cajero = cajero.codigo;
                    egresoCaja.modificable = true;
                }
                egresoCaja.codigo_concepto = concepto.codigo;
                egresoCaja.monto = Convert.ToDecimal(montoText.Text.Trim());
                egresoCaja.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloEgreso.agregarEgreso(egresoCaja)) == true)
                    {
                        egresoCaja = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloEgreso.modificarEgreso(egresoCaja)) == true)
                    {
                        egresoCaja = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                egresoCaja = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventata_egreso_caja_Load(object sender, EventArgs e)
        {

        }

        private void porcientoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        public void loadConcepto()
        {
            try
            {
                if (concepto == null)
                {
                    conceptoIdText.Text = "";
                    conceptoText.Text = "";
                    return;
                }
                conceptoIdText.Text = concepto.codigo.ToString();
                conceptoText.Text = concepto.nombre;
            }
            catch (Exception)
            {

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_ingresos_egresos_conceptos ventana = new ventana_busqueda_ingresos_egresos_conceptos();
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                concepto = ventana.getObjeto();
                loadConcepto();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            egresoCaja = null;
            loadVentana();
        }

        private void egresoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    conceptoIdText.Focus();
                    conceptoIdText.SelectAll();

                    egresoCaja = modeloEgreso.getEgresoCajaById(Convert.ToInt16(egresoIdText.Text));
                    if (egresoCaja != null)
                    {
                        loadVentana();
                    }
                }
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
            }
            catch (Exception)
            {
                
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_egreso_caja ventana = new ventana_busqueda_egreso_caja(true);
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                egresoCaja = ventana.getObjeto();
                loadVentana();
            }
        }

        private void egresoIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void conceptoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    montoText.Focus();
                    montoText.SelectAll();

                    concepto = modeloConcepto.getConceptoById(Convert.ToInt16(conceptoIdText.Text));
                    loadConcepto();
                }
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void montoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                detalleText.Focus();
                detalleText.SelectAll();

            }
        }

        private void detalleText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                activoCheck.Focus();

            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }
    }
}
