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
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_cliente : formBase
    {


        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private cliente cliente;
        private categoria_cliente categoriaCliente;
        private tipo_comprobante_fiscal tipoComprobante;



        //modelos
        modeloCliente modeloCliente =new modeloCliente();
        private modeloCategoriaCliente modeloCategoriaCliente=new modeloCategoriaCliente();
        modeloTipoComprobanteFiscal modeloTipoComprobante=new modeloTipoComprobanteFiscal();



        public ventana_cliente()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cliente");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (cliente != null)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();


                    nombreText.Text = cliente.nombre;
                    cedulaText.Text = cliente.cedula;
                    rncText.Text = cliente.rnc;
                    telefono1Text.Text = cliente.telefono1;
                    telefono2Text.Text = cliente.telefono2;
                    categoriaCliente = modeloCategoriaCliente.getCategoriaClienteById(cliente.codigo_categoria);
                    loadCategoriaCliente();
                    creditoText.Text = cliente.limite_credito.ToString("N");
                    tipoComprobante =modeloTipoComprobante.getTipoComprobanteById(cliente.codigo_tipo_comprobante_fiscal);
                    loadTipocomprobante();
                    direccion1Text.Text = cliente.direccion1;
                    direccion2Text.Text = cliente.direccion2;
                    clienteContadoCheck.Checked = Convert.ToBoolean(cliente.cliente_contado);
                    activoCheck.Checked = Convert.ToBoolean(cliente.activo);
                }
                else
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();

                    clienteIdText.Text = "";
                    nombreText.Text = "";
                    cedulaText.Text = "";
                    rncText.Text = "";
                    telefono1Text.Text = "";
                    telefono2Text.Text = "";
                    categoriaCliente = null;
                    categoriaIdText.Text = "";
                    categoriaText.Text = "";
                    tipoComprobante = null;
                    tipoNcfIdText.Text = "";
                    tipoNcfText.Text = "";
                    creditoText.Text = "";
                    direccion1Text.Text = "";
                    direccion2Text.Text = "";
                    clienteContadoCheck.Checked = false;
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
                    MessageBox.Show("Falta el nombre del cliente ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }
                //validar cedula
                if (cedulaText.Text == "")
                {
                    MessageBox.Show("Falta la cedula del cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cedulaText.Focus();
                    cedulaText.SelectAll();
                    return false;
                }
                //validar categoria
                if (categoriaCliente == null)
                {
                    MessageBox.Show("Falta la categoria", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    categoriaIdText.Focus();
                    categoriaIdText.SelectAll();
                    return false;
                }
                //validar tipo comprobante fiscal
                if (tipoComprobante == null)
                {
                    MessageBox.Show("Falta el tipo de comprobante fiscal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tipoNcfIdText.Focus();
                    tipoNcfIdText.SelectAll();
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
                if (cliente == null)
                {
                    cliente = new cliente();
                    crear = true;
                    cliente.codigo = modeloCliente.getNext();
                    cliente.fecha_creado=DateTime.Today;
                    cliente.codigo_sucursal_creado = empleado.codigo_sucursal;
                }
                cliente.nombre = nombreText.Text;
                cliente.cedula = cedulaText.Text;
                cliente.rnc = rncText.Text;
                cliente.telefono1 = telefono1Text.Text;
                cliente.telefono2 = telefono2Text.Text;
                cliente.codigo_categoria = categoriaCliente.codigo;
                cliente.abrir_credito = Convert.ToBoolean(abrirCreditoCheck.Checked);
                cliente.limite_credito = Convert.ToDecimal(creditoText.Text);
                cliente.codigo_tipo_comprobante_fiscal = tipoComprobante.codigo;
                cliente.cliente_contado = Convert.ToBoolean(clienteContadoCheck.Checked);
                cliente.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCliente.agregarCliente(cliente)) == true)
                    {
                        cliente = null;
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
                    if ((modeloCliente.modificarCliente(cliente)) == true)
                    {
                        cliente = null;
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
                cliente = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_cliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void creditoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, creditoText.Text);
        }

        private void creditoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana = new ventana_busqueda_cliente(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadVentana();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cliente = null;
            loadVentana();
        }

        public void loadCategoriaCliente()
        {
            try
            {
                if(categoriaCliente==null)
                {
                    categoriaIdText.Text = "";
                    categoriaText.Text = "";
                    return;
                }

                categoriaIdText.Text = categoriaCliente.codigo.ToString();
                categoriaText.Text = categoriaCliente.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCategoriaCliente.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_categoria_cliente ventana=new ventana_busqueda_categoria_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                categoriaCliente = ventana.getObjeto();
                loadCategoriaCliente();
            }
        }

        public void loadTipocomprobante()
        {
            try
            {
                if (tipoComprobante == null)
                {
                    tipoNcfIdText.Text = "";
                    tipoNcfText.Text = "";
                    return;
                }

                tipoNcfIdText.Text = tipoComprobante.codigo.ToString();
                tipoNcfText.Text = tipoComprobante.nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipocomprobante.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_comprobante_fiscal ventana = new ventana_busqueda_tipo_comprobante_fiscal();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                tipoComprobante = ventana.getObjeto();
                loadTipocomprobante();
            }
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                nombreText.Focus();
                nombreText.SelectAll();

                cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                loadVentana();
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cedulaText.Focus();
                cedulaText.SelectAll();
            }
        }

        private void cedulaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                rncText.Focus();
                rncText.SelectAll();
            }
        }

        private void rncText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                telefono1Text.Focus();
                telefono1Text.SelectAll();
            }
        }

        private void telefono2Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                categoriaIdText.Focus();
                categoriaIdText.SelectAll();
            }
        }

        private void categoriaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    abrirCreditoCheck.Focus();

                    categoriaCliente = modeloCategoriaCliente.getCategoriaClienteById(Convert.ToInt16(categoriaIdText.Text));
                    loadCategoriaCliente();
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

        private void clienteIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void abrirCreditoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                creditoText.Focus();
                creditoText.SelectAll();
            }
        }

        private void creditoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tipoNcfIdText.Focus();
                tipoNcfIdText.SelectAll();
            }
        }

        private void tipoNcfIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void tipoNcfIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    direccion1Text.Focus();
                    direccion1Text.SelectAll();

                    tipoComprobante = modeloTipoComprobante.getTipoComprobanteById(Convert.ToInt16(tipoNcfIdText.Text));
                    loadTipocomprobante();

                }
                if (e.KeyCode == Keys.F1)
                {
                    button6_Click(null, null);
                }
            }
            catch (Exception)
            {
            }
           
        }

        private void clienteContadoCheck_KeyDown(object sender, KeyEventArgs e)
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

        private void direccion2Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                clienteContadoCheck.Focus();
            }
        }

        private void direccion1Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                direccion2Text.Focus();
                direccion2Text.SelectAll();

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void telefono1Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                telefono2Text.Focus();
                telefono2Text.SelectAll();
            }
        }
    }
}
