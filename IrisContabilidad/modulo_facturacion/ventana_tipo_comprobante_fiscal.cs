using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_tipo_comprobante_fiscal : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        tipo_comprobante_fiscal tipoComprobante;




        //modelos
        modeloTipoComprobanteFiscal modeloTipoComprobanteFiscal = new modeloTipoComprobanteFiscal();


        public ventana_tipo_comprobante_fiscal()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana tipo de comprobante fiscal");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (tipoComprobante != null)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    tipoComprobanteIdText.Text = tipoComprobante.codigo.ToString();
                    nombreText.Text = tipoComprobante.nombre;
                    secuenciaText.Text = tipoComprobante.secuencia;
                    activoCheck.Checked = Convert.ToBoolean(tipoComprobante.activo);
                }
                else
                {
                    tipoComprobanteIdText.Focus();
                    tipoComprobanteIdText.SelectAll();
                    tipoComprobanteIdText.Text = "";
                    nombreText.Text = "";
                    secuenciaText.Text = "";
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
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre del tipo de comprobante ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }
                //validar numero secuencia
                if (secuenciaText.Text == "")
                {
                    MessageBox.Show("Falta la secuencia del tipo de comprobante", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
                    return false;
                }
                //validar tamano de la secuencia
                if (secuenciaText.Text.Length != 2)
                {
                    MessageBox.Show("La secuencia no esta completa,deben ser 2 digitos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
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
                if (tipoComprobante == null)
                {
                    tipoComprobante = new tipo_comprobante_fiscal();
                    crear = true;
                    tipoComprobante.codigo = modeloTipoComprobanteFiscal.getNext();
                }
                tipoComprobante.nombre = nombreText.Text;
                tipoComprobante.secuencia = secuenciaText.Text.Trim();
                tipoComprobante.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloTipoComprobanteFiscal.agregarTipoComprobante(tipoComprobante)) == true)
                    {
                        tipoComprobante = null;
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
                    if ((modeloTipoComprobanteFiscal.modificarTipoComprobante(tipoComprobante)) == true)
                    {
                        tipoComprobante = null;
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
                tipoComprobante = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_tipo_comprobante_fiscal_Load(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            tipoComprobante = null;
            loadVentana();
        }

        private void tipoComprobanteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    tipoComprobante =modeloTipoComprobanteFiscal.getTipoComprobanteById(Convert.ToInt16(tipoComprobanteIdText.Text));
                    loadVentana();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                secuenciaText.Focus();
                secuenciaText.SelectAll();
            }
        }

        private void secuenciaText_KeyDown(object sender, KeyEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_comprobante_fiscal ventana = new ventana_busqueda_tipo_comprobante_fiscal(true);
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                tipoComprobante = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
