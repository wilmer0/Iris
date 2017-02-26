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
        private producto producto;
        private unidad unidad;


        //modelos
        modeloCliente modeloCliente = new modeloCliente();
        modeloVenta modeloVenta=new modeloVenta();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloProducto modeloProducto=new modeloProducto();
        modeloUnidad modeloUnidad=new modeloUnidad();

        //listas
        private List<venta_detalle> listaVentaDetalle; 


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
            try
            {
                dataGridView1.Rows.Clear();
                if (venta != null)
                {
                    cliente = modeloCliente.getClienteById(venta.codigo_cliente);
                    clienteLabel.Text = cliente.nombre;
                    tipoVentaLabel.Text = venta.tipo_venta;
                    ncfLabel.Text = venta.ncf;
                    loadDetalleVenta();
                }
                else
                {
                    cliente = null;
                    clienteLabel.Text = ".";
                    tipoVentaLabel.Text = ".";
                    ncfLabel.Text = ".";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadDetalleVenta()
        {
            try
            {
                if (venta == null)
                {
                    return;
                }

                listaVentaDetalle=new List<venta_detalle>();
                listaVentaDetalle = modeloVenta.getListaVentaDetalleByVenta(venta.codigo);

                listaVentaDetalle.ForEach(x =>
                {
                    producto = modeloProducto.getProductoById(x.codigo_producto);
                    unidad = modeloUnidad.getUnidadById(x.codigo_unidad);
                    dataGridView1.Rows.Add(x.codigo_producto,producto.nombre,x.codigo_unidad,unidad.nombre,x.cantidad,x.precio,x.monto_total);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadDetalleVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if ((venta = ventana.getObjeto()) != null)
            {
                loadVentana();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            venta = null;
            loadVentana();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        public void eliminar()
        {
            try
            {
                //validar que tenga filas el datagrid
                if (dataGridView1 == null || dataGridView1.Rows.Count < 0)
                {
                    return;
                }
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                if (fila >= 0)
                {
                    dataGridView1.Rows[fila].Cells[7].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void agregar()
        {
            try
            {
                //validaciones
                if (cantidadDevolverText.Text == "")
                {
                    cantidadDevolverText.Focus();
                    cantidadDevolverText.SelectAll();
                    MessageBox.Show("Falta la cantidad", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                decimal canti;
                if (decimal.TryParse(cantidadDevolverText.Text, out canti) == false)
                {
                    cantidadDevolverText.Focus();
                    cantidadDevolverText.SelectAll();
                    MessageBox.Show("Cantidad a devolder no tiene formato de número", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                canti = Convert.ToDecimal(cantidadDevolverText.Text);
                if (dataGridView1 == null || dataGridView1.Rows.Count < 0)
                {
                    return;
                }
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                if (canti > Convert.ToDecimal(dataGridView1.Rows[fila].Cells[4].Value.ToString()))
                {
                    cantidadDevolverText.Focus();
                    cantidadDevolverText.SelectAll();
                    MessageBox.Show("La cantidad que esta insertando es mas alta que la facturada", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (fila >= 0)
                {
                    dataGridView1.Rows[fila].Cells[7].Value = cantidadDevolverText.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void cantidadDevolverText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, cantidadDevolverText.Text);
        }
    }
}
