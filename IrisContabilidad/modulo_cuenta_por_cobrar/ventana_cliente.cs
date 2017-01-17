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




        //modelos
        modeloCliente modeloCliente =new modeloCliente();

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
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    nombreText.Text = cliente.nombre;
                    cedulaText.Text = cliente.cedula;
                    rncText.Text = cliente.rnc;
                    telefono1Text.Text = cliente.telefono1;
                    telefono2Text.Text = cliente.telefono2;
                    //categoria
                    creditoText.Text = cliente.limite_credito.ToString("N");
                    //tipo comprobante fiscal
                    clienteContadoCheck.Checked = Convert.ToBoolean(cliente.cliente_contado);
                    activoCheck.Checked = Convert.ToBoolean(cliente.activo);
                }
                else
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    nombreText.Text = "";
                    cedulaText.Text = "";
                    rncText.Text = "";
                    telefono1Text.Text = "";
                    telefono2Text.Text = "";
                    //categoria
                    creditoText.Text = "";
                    //tipo comprobante fiscal
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
                }
                cliente.nombre = nombreText.Text;
                cliente.cedula = cedulaText.Text;
                cliente.rnc = rncText.Text;
                cliente.telefono1 = telefono1Text.Text;
                cliente.telefono2 = telefono2Text.Text;
                //categoria
                cliente.abrir_credito = Convert.ToBoolean(abrirCreditoCheck.Checked);
                cliente.limite_credito = Convert.ToDecimal(creditoText.Text);
                //tipo comprobante fiscal
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
    }
}
