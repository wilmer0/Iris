using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_venta_devolucion : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private cliente cliente;
        private venta venta;


        //modelos
        modeloCliente modeloCliente = new modeloCliente();
        modeloVenta modeloVenta=new modeloVenta();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();

        public ventana_venta_devolucion()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana venta devolución");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            //try
            //{
            //    if (cliente != null)
            //    {
            //        nombreText.Focus();
            //        nombreText.SelectAll();


            //        nombreText.Text = cliente.nombre;
            //        cedulaText.Text = cliente.cedula;
            //        rncText.Text = cliente.rnc;
            //        telefono1Text.Text = cliente.telefono1;
            //        telefono2Text.Text = cliente.telefono2;
            //        categoriaCliente = modeloCategoriaCliente.getCategoriaClienteById(cliente.codigo_categoria);
            //        loadCategoriaCliente();
            //        creditoText.Text = cliente.limite_credito.ToString("N");
            //        tipoComprobante = modeloTipoComprobante.getTipoComprobanteById(cliente.codigo_tipo_comprobante_fiscal);
            //        loadTipocomprobante();
            //        direccion1Text.Text = cliente.direccion1;
            //        direccion2Text.Text = cliente.direccion2;
            //        clienteContadoCheck.Checked = Convert.ToBoolean(cliente.cliente_contado);
            //        activoCheck.Checked = Convert.ToBoolean(cliente.activo);
            //    }
            //    else
            //    {
            //        clienteIdText.Focus();
            //        clienteIdText.SelectAll();

            //        clienteIdText.Text = "";
            //        nombreText.Text = "";
            //        cedulaText.Text = "";
            //        rncText.Text = "";
            //        telefono1Text.Text = "";
            //        telefono2Text.Text = "";
            //        categoriaCliente = null;
            //        categoriaIdText.Text = "";
            //        categoriaText.Text = "";
            //        tipoComprobante = null;
            //        tipoNcfIdText.Text = "";
            //        tipoNcfText.Text = "";
            //        creditoText.Text = "";
            //        direccion1Text.Text = "";
            //        direccion2Text.Text = "";
            //        clienteContadoCheck.Checked = false;
            //        activoCheck.Checked = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //public bool validarGetAction()
        //{
        //    try
        //    {
        //        //validar nombre
        //        if (nombreText.Text == "")
        //        {
        //            MessageBox.Show("Falta el nombre del cliente ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            nombreText.Focus();
        //            nombreText.SelectAll();
        //            return false;
        //        }
        //        //validar cedula
        //        if (cedulaText.Text == "")
        //        {
        //            MessageBox.Show("Falta la cedula del cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            cedulaText.Focus();
        //            cedulaText.SelectAll();
        //            return false;
        //        }
        //        //validar categoria
        //        if (categoriaCliente == null)
        //        {
        //            MessageBox.Show("Falta la categoria", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            categoriaIdText.Focus();
        //            categoriaIdText.SelectAll();
        //            return false;
        //        }
        //        //validar tipo comprobante fiscal
        //        if (tipoComprobante == null)
        //        {
        //            MessageBox.Show("Falta el tipo de comprobante fiscal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            tipoNcfIdText.Focus();
        //            tipoNcfIdText.SelectAll();
        //            return false;
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        public void getAction()
        {
            //try
            //{
            //    //validando campos necesarios
            //    if (validarGetAction() == false)
            //    {
            //        return;
            //    }

            //    if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }

            //    bool crear = false;
            //    //se instancia el empleado si esta nulo
            //    if (cliente == null)
            //    {
            //        cliente = new cliente();
            //        crear = true;
            //        cliente.codigo = modeloCliente.getNext();
            //        cliente.fecha_creado = DateTime.Today;
            //        cliente.codigo_sucursal_creado = empleado.codigo_sucursal;
            //    }
            //    cliente.nombre = nombreText.Text;
            //    cliente.cedula = cedulaText.Text;
            //    cliente.rnc = rncText.Text;
            //    cliente.telefono1 = telefono1Text.Text;
            //    cliente.telefono2 = telefono2Text.Text;
            //    cliente.codigo_categoria = categoriaCliente.codigo;
            //    cliente.abrir_credito = Convert.ToBoolean(abrirCreditoCheck.Checked);
            //    cliente.limite_credito = Convert.ToDecimal(creditoText.Text);
            //    cliente.codigo_tipo_comprobante_fiscal = tipoComprobante.codigo;
            //    cliente.cliente_contado = Convert.ToBoolean(clienteContadoCheck.Checked);
            //    cliente.activo = Convert.ToBoolean(activoCheck.Checked);

            //    if (crear == true)
            //    {
            //        //se agrega
            //        if ((modeloCliente.agregarCliente(cliente)) == true)
            //        {
            //            cliente = null;
            //            loadVentana();
            //            MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        }
            //        else
            //        {
            //            MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        //se modifica
            //        if ((modeloCliente.modificarCliente(cliente)) == true)
            //        {
            //            cliente = null;
            //            loadVentana();
            //            MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        }
            //        else
            //        {
            //            MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    cliente = null;
            //    MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void ventana_venta_devolucion_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_venta ventana=new ventana_busqueda_venta();
            ventana.Owner = this;
            ventana.ShowDialog();
            
        }
    }
}
