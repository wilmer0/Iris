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
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_configuracion_comprobante_fiscal : formBase
    {


        //objetos
        private empleado empleadoSingleton;
        private empleado empleado;
        private utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private caja caja;
        private tipo_comprobante_fiscal tipoComprobanteFiscal;
        private comprobante_fiscal comprobanteFiscal;
        private empresa empresa;

        //modelos
        modeloCaja modeloCaja = new modeloCaja();
        modeloCajero modeloCajero = new modeloCajero();
        modeloEmpleado modeloEmpelado = new modeloEmpleado();
        modeloComprobanteFiscal modeloComprobanteFiscal=new modeloComprobanteFiscal();
        modeloTipoComprobanteFiscal modeloTipoComprobanteFiscal=new modeloTipoComprobanteFiscal();
        private modeloEmpresa modeloEmpresa = new modeloEmpresa();

        public ventana_configuracion_comprobante_fiscal()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana comprobantes fiscales");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (comprobanteFiscal != null)
                {
                    comprobanteTipoIdText.Focus();
                    comprobanteTipoIdText.SelectAll();

                    caja = modeloCaja.getCajaById(comprobanteFiscal.codigo_caja);
                    loadCaja();
                    tipoComprobanteFiscal =modeloTipoComprobanteFiscal.getTipoComprobanteById(comprobanteFiscal.codigo_tipo);
                    loadComprobanteTipo();
                    numeroInicialText.Text = comprobanteFiscal.numero_desde.ToString();
                    numeroFinalText.Text = comprobanteFiscal.numero_hasta.ToString();
                }
                else
                {
                    cajaIdText.Focus();
                    cajaIdText.SelectAll();

                    caja = null;
                    cajaIdText.Text = "";
                    cajaText.Text = "";
                    tipoComprobanteFiscal = null;
                    comprobanteTipoIdText.Text = "";
                    comprobanteTipoText.Text = "";
                    numeroInicialText.Text = "0";
                    numeroFinalText.Text = "0";
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
                //validar caja
                if (caja == null)
                {
                    MessageBox.Show("Falta la caja", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cajaIdText.Focus();
                    cajaIdText.SelectAll();
                    return false;
                }
                //validar tipo de comprobante
                if (tipoComprobanteFiscal == null)
                {
                    MessageBox.Show("Falta el tipo de comprobante fiscal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comprobanteTipoIdText.Focus();
                    comprobanteTipoIdText.SelectAll();
                    return false;
                }
                //validar que numero inicial
                if (numeroInicialText.Text == "")
                {
                    MessageBox.Show("Falta el número inicial", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numeroInicialText.Focus();
                    numeroInicialText.SelectAll();
                    return false;
                }
                //validar que numero final
                if (numeroFinalText.Text == "")
                {
                    MessageBox.Show("Falta el número final", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numeroFinalText.Focus();
                    numeroFinalText.SelectAll();
                    return false;
                }
                //validar que el numero inicial sea menor que el numero final
                if(Convert.ToDecimal(numeroInicialText.Text)> (Convert.ToDecimal(numeroFinalText.Text)))
                {
                    MessageBox.Show("El núumero inicial es mayor que el número final", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numeroInicialText.Focus();
                    numeroInicialText.SelectAll();
                    return false;
                }
                //validar el ultimo usaro
                if (ultimoUsadoText.Text == "")
                {
                    MessageBox.Show("Falta el ultimo número usado de este tipo de comprobante", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ultimoUsadoText.Focus();
                    ultimoUsadoText.SelectAll();
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
                empresa = modeloEmpresa.getEmpresaBySucursalId(empleado.codigo_sucursal);
                bool crear = false;
                //se instancia el empleado si esta nulo
                if (comprobanteFiscal == null)
                {
                    comprobanteFiscal = new comprobante_fiscal();
                    crear = true;
                    comprobanteFiscal.codigo = modeloComprobanteFiscal.getNext();
                }
                comprobanteFiscal.codigo_caja = caja.codigo;
                comprobanteFiscal.codigo_tipo = tipoComprobanteFiscal.codigo;
                comprobanteFiscal.serie = empresa.serie_comprobante;
                comprobanteFiscal.numero_desde = Convert.ToInt16(numeroInicialText.Text);
                comprobanteFiscal.numero_hasta = Convert.ToInt16(numeroFinalText.Text);
                comprobanteFiscal.avisar = Convert.ToInt16(ultimoUsadoText.Text);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloComprobanteFiscal.agregarComprobante(comprobanteFiscal)) == true)
                    {
                        comprobanteFiscal = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        comprobanteFiscal = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloComprobanteFiscal.modificarComprobante(comprobanteFiscal)) == true)
                    {
                        comprobanteFiscal = null;
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
                comprobanteFiscal = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCaja()
        {
            try
            {
                if (caja == null)
                {
                    cajaIdText.Text = "";
                    cajaText.Text = "";
                    return;
                }
                cajaIdText.Text = caja.codigo.ToString();
                cajaText.Text = caja.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadComprobanteTipo()
        {
            try
            {
                if (tipoComprobanteFiscal == null)
                {
                    comprobanteTipoIdText.Text = "";
                    comprobanteTipoText.Text = "";
                    return;
                }
                comprobanteTipoIdText.Text = tipoComprobanteFiscal.codigo.ToString();
                comprobanteTipoText.Text = tipoComprobanteFiscal.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadComprobanteTipo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_configuracion_comprobante_fiscal_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comprobanteFiscal = null;
            loadVentana();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_caja ventana = new ventana_busqueda_caja();
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                caja = ventana.getObjeto();
                loadCaja();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_comprobante_fiscal ventana = new ventana_busqueda_tipo_comprobante_fiscal();
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                tipoComprobanteFiscal = ventana.getObjeto();
                loadComprobanteTipo();
            }
        }

        private void cajaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    comprobanteTipoIdText.Focus();
                    comprobanteTipoIdText.SelectAll();

                    caja = modeloCaja.getCajaById(Convert.ToInt16(cajaIdText.Text));
                    loadCaja();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void comprobanteTipoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    numeroInicialText.Focus();
                    numeroInicialText.SelectAll();

                    tipoComprobanteFiscal = modeloTipoComprobanteFiscal.getTipoComprobanteById(Convert.ToInt16(comprobanteTipoIdText.Text));
                    loadComprobanteTipo();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void numeroInicialText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void numeroFinalText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void ultimoUsadoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void numeroInicialText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numeroFinalText.Focus();
                numeroFinalText.SelectAll();
            }
        }

        private void numeroFinalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultimoUsadoText.Focus();
                ultimoUsadoText.SelectAll();
            }
        }

        private void ultimoUsadoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
}
