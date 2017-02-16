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
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_gastos : formBase
    {

        //objetos
        singleton singleton = new singleton();
        utilidades utilidades = new utilidades();
        empleado empleado;
        private suplidor suplidor;
        private tipo_gasto tipoGasto;
        private gasto gasto;

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        private modeloTipoGasto modeloTipoGasto;
        modeloSuplidor modeloSuplidor=new modeloSuplidor();
        modeloGasto modeloGasto=new modeloGasto();

        public ventana_gastos()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana gastos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (gasto != null)
                {
                    //llena
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();


                    suplidor = modeloSuplidor.getSuplidorById(gasto.codigo_suplidor);
                    loadSuplidor();
                    tipoGasto = modeloTipoGasto.getTipoGastoById(gasto.codigo_tipo_gasto);
                    loadTipoGasto();
                    FechaText.Text = gasto.fecha.ToString("dd/MM/yyyy");
                    NcfText.Text = gasto.ncf;
                    montoSubTotalText.Text = gasto.monto_subtotal.ToString("N");
                    montoItebisText.Text = gasto.monto_itebis.ToString("N");
                    //retencion isr
                    montoRetencionIsrText.Text = gasto.monto_isr.ToString("N");

                }
                else
                {
                    //limpia
                    gastoIdText.Focus();
                    gastoIdText.SelectAll();

                    suplidor = null;
                    suplidorIdText.Text = "";
                    suplidorText.Text = "";

                    tipoGasto = null;
                    tipoGastoIdText.Text = "";
                    tipoGastoText.Text = "";

                    FechaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    NcfText.Text = "";
                    montoSubTotalText.Text = "0.00";
                    montoItebisText.Text = "0.00";
                    
                    //retencion isr
                    tipoRetencionIsrIdText.Text = "";
                    montoRetencionIsrText.Text = "0.00";
                    
                    montoRetencionIsrText.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSuplidor()
        {
            try
            {
                suplidorIdText.Text = "";
                suplidorText.Text = "";
                if (suplidor != null)
                {
                    suplidorIdText.Text = suplidor.codigo.ToString();
                    suplidorText.Text = suplidor.nombre;
                    //loadTipoGastoDefectoBySuplidor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadTipoGastoDefectoBySuplidor()
        {
            try
            {
                tipoGastoIdText.Text = "";
                tipoGastoText.Text = "";
                tipoGasto=new tipo_gasto();
                tipoGasto = modeloTipoGasto.getTipoGastoDefectoBySuplidorId(suplidor.codigo);
                if (tipoGasto != null)
                {
                    tipoGastoIdText.Text = tipoGasto.id.ToString();
                    tipoGastoText.Text = tipoGasto.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoGastoDefectoBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadTipoGasto()
        {
            try
            {
                tipoGastoIdText.Text = "";
                tipoGastoText.Text = "";
                if (tipoGasto != null)
                {
                    tipoGastoIdText.Text = tipoGasto.id.ToString();
                    tipoGastoText.Text = tipoGasto.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadTipoRetencion()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoRetencion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //validar suplidor
                if (suplidor == null)
                {
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
                    MessageBox.Show("Falta el suplidor", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar tipo gasto
                if (tipoGasto == null)
                {
                    tipoGastoIdText.Focus();
                    tipoGastoIdText.SelectAll();
                    MessageBox.Show("Falta el tipo de gasto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar fehcha
                if (FechaText.Text == "")
                {
                    FechaText.Focus();
                    FechaText.SelectAll();
                    MessageBox.Show("Falta la fecha", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar fehcha formato
                DateTime fecha1;
                if (DateTime.TryParse(FechaText.Text,out fecha1)==false)
                {
                    FechaText.Focus();
                    FechaText.SelectAll();
                    MessageBox.Show("Formato de fecha no es valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //validar sub total
                if (Convert.ToDecimal(montoSubTotalText.Text)<0)
                {
                    montoSubTotalText.Focus();
                    montoSubTotalText.SelectAll();
                    MessageBox.Show("Falta el sub total", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar itebis
                if (Convert.ToDecimal(montoItebisText.Text) < 0)
                {
                    montoItebisText.Focus();
                    montoItebisText.SelectAll();
                    MessageBox.Show("Falta el monto itbis", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar retencion isr
                //if (Convert.ToDecimal(montoSubTotalText.Text) < 0)
                //{
                //    montoSubTotalText.Focus();
                //    montoSubTotalText.SelectAll();
                //    MessageBox.Show("Falta el sub total", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
                //validar monto isr
                if (Convert.ToDecimal(montoRetencionIsrText.Text) < 0)
                {
                    montoRetencionIsrText.Focus();
                    montoRetencionIsrText.SelectAll();
                    MessageBox.Show("Falta el monto de retencion isr", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar ncf
                if (NcfText.Text == "")
                {
                    NcfText.Focus();
                    NcfText.SelectAll();
                    MessageBox.Show("Falta el NCF", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (gasto == null)
                {
                    gasto = new gasto();
                    crear = true;
                    gasto.codigo = modeloGasto.getNext();
                    gasto.activo = true;
                    gasto.contabilizado = false;
                    
                }
                gasto.codigo_empleado = empleado.codigo;
                gasto.codigo_suplidor = suplidor.codigo;
                gasto.codigo_tipo_gasto = tipoGasto.id;
                gasto.fecha = Convert.ToDateTime(FechaText.Text);
                gasto.ncf = NcfText.Text;
                gasto.monto_subtotal = Convert.ToDecimal(montoSubTotalText.Text);
                gasto.monto_itebis = Convert.ToDecimal(montoItebisText.Text);
                //retencion

                gasto.monto_isr = Convert.ToDecimal(montoRetencionIsrText.Text);

               

                if (crear == true)
                {
                    //se agrega
                    if ((modeloGasto.agregarGasto(gasto) == true))
                    {
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        gasto = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                gasto = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_gastos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana=new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_gastos ventana=new ventana_busqueda_tipo_gastos();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                tipoGasto = ventana.getObjeto();
                loadTipoGasto();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void suplidorIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void tipoGadtoIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void montoSubTotalText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoSubTotalText.Text);
        }

        private void montoItebisText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoItebisText.Text);
        }

        private void montoRetencionIsrText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoRetencionIsrText.Text);
        }

        private void suplidorIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    tipoGastoIdText.Focus();
                    tipoGastoIdText.Focus();

                    suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(suplidorIdText.Text));
                    loadSuplidor();
                }
            }
            catch (Exception)
            {
            }
        }

        private void tipoGadtoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    FechaText.Focus();
                    FechaText.Focus();

                    tipoGasto = modeloTipoGasto.getTipoGastoById(Convert.ToInt16(tipoGastoIdText));
                    loadTipoGasto();
                }
            }
            catch (Exception)
            {
            }
        }

        private void FechaText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    NcfText.Focus();
                    NcfText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void NcfText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    montoSubTotalText.Focus();
                    montoSubTotalText.Focus();

                }
            }
            catch (Exception)
            {
            }
        }

        private void montoSubTotalText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    montoItebisText.Focus();
                    montoItebisText.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void montoItebisText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    tipoRetencionIsrIdText.Focus();
                    tipoRetencionIsrIdText.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void montoRetencionIsrText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
