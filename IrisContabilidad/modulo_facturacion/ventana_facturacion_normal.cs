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
using IrisContabilidad.modulo_cuenta_por_cobrar;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_facturacion_normal : formBase
    {


        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private venta venta;
        private venta_detalle ventaDetalle;
        private producto producto;
        private itebis itebis;
        private unidad unidad;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;
        private productoUnidadConversion productoUnidadConversion;
        private cliente cliente;
        private ventana_desglose_dinero ventanaDesglose;
        producto_precio_venta productoPrecioVenta;
        private cajero cajero;


        //modelos
        modeloTipoComprobanteFiscal modeloTipoComprobanteFiscal=new modeloTipoComprobanteFiscal();
        private modeloItebis modeloItebis = new modeloItebis();
        private modeloUnidad modeloUnidad = new modeloUnidad();
        private modeloAlmacen modeloAlmacen = new modeloAlmacen();
        private modeloProducto modeloProducto = new modeloProducto();
        modeloCliente modeloCliente = new modeloCliente();
        ModeloReporte modeloReporte = new ModeloReporte();
        modeloVenta modeloVenta=new modeloVenta();
        modeloComprobanteFiscal modeloComprobantefiscal=new modeloComprobanteFiscal();
        modeloCajero modeloCajero=new modeloCajero();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private decimal totalItebisMonto = 0;
        private decimal totalCompraMonto = 0;
        private decimal cantidadExistencia = 0;

        //listas
        private List<producto_vs_codigobarra> listaCodigoBarra;
        private List<productoUnidadConversion> listaProductoUnidadConversion;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;
        private List<unidad> listaUnidad;
        private List<tipo_comprobante_fiscal> listaTipoComprobanteFiscal; 

        //variables
        private decimal cantidad_monto = 0;
        private decimal precio_monto = 0;
        private decimal importe_monto = 0;
        private decimal descuento_monto = 0;
        private decimal descuento_porciento = 0;
        private decimal itebis_monto = 0;


        public ventana_facturacion_normal()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana facturación");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                listaTipoComprobanteFiscal = modeloTipoComprobanteFiscal.getListaCompleta();
                if (listaTipoComprobanteFiscal != null)
                {
                    tipoComprobanteCombo.DataSource = listaTipoComprobanteFiscal;
                    tipoComprobanteCombo.DisplayMember = "nombre";
                    tipoComprobanteCombo.ValueMember = "codigo";
                }

                tipoVentaComboBox.SelectedIndex = 0;
                tipoComprobanteCombo.SelectedIndex = 0;
                if (venta != null)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();

                    //llenar campos
                    cliente = modeloCliente.getClienteById(venta.codigo_cliente);
                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteText.Text = cliente.nombre;
                    numeroFacturaText.Text = venta.numero_factura;
                    tipoVentaComboBox.Enabled = false;
                    tipoVentaComboBox.Text = venta.tipo_venta;
                    tipoComprobanteCombo.Enabled = false;
                    numerocComprobanteFiscalText.Text = venta.ncf;
                    fechaInicialText.Enabled = false;
                    fechaInicialText.Text = venta.fecha.ToString("d");
                    fechaFinalText.Enabled = false;
                    fechaFinalText.Text = venta.fecha_limite.ToString("d");
                    detalleText.Enabled = false;
                    detalleText.Text = venta.detalle;

                    //llenar el detalle de la venta
                    dataGridView1.Rows.Clear();
                    listaVentaDetalle = modeloVenta.getListaVentaDetalle(venta.codigo, true);
                    loadListaVentaDetalle();
                    botonImprimir.Visible = true;
                }
                else
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();


                    //blanquear campos
                    clienteIdText.Text = "";
                    clienteText.Text = "";
                    numeroFacturaText.Text = "";
                    numerocComprobanteFiscalText.Text = "";
                    tipoVentaComboBox.Enabled = true;
                    tipoVentaComboBox.Text = "";
                    fechaInicialText.Text = DateTime.Today.ToString("d");
                    fechaFinalText.Text = DateTime.Today.ToString("d");
                    detalleText.Text = "";
                    //limpiar el detalle de la compra
                    listaVentaDetalle = new List<venta_detalle>();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                    }
                    fechaInicialText.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    fechaFinalText.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    botonImprimir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {

                
                //validar que el usuario actual es cajero
                cajero = modeloCajero.getCajeroByIdEmpleado(empleado.codigo);
                if (cajero == null)
                {
                    MessageBox.Show("Su usuario no es cajero, no puede realizar ventas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //si tiene una compra existente abierta
                if (venta != null)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("Tiene una compra existente abierta debe limpiar antes de continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
               
                //suplidor
                if (cliente == null)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("Falta el suplidor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dataGridView1.Rows.Count == 0)
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("No hay productos para realizar la venta", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //tipo de compra
                if (tipoVentaComboBox.Text.Trim() == "")
                {
                    tipoVentaComboBox.Focus();
                    tipoVentaComboBox.SelectAll();
                    MessageBox.Show("Falta el tipo de compra", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //fecha inicial
                DateTime fecha1;
                if (DateTime.TryParse(fechaInicialText.Text, out fecha1) == false)
                {
                    fechaInicialText.Focus();
                    fechaInicialText.SelectAll();
                    MessageBox.Show("Formato de fecha no es valido", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //fecha a credito
                DateTime fecha2;
                if (DateTime.TryParse(fechaFinalText.Text, out fecha2) == false)
                {
                    fechaFinalText.Focus();
                    fechaFinalText.SelectAll();
                    MessageBox.Show("Formato de fecha no es valido", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //que hayan productos
                if (dataGridView1.Rows.Count < 0)
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("Debe de seleccionar productos para la compra", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

                //en esta ventana siempre va ser true el crear, siempre se va crear
                bool crear = true;
                venta = new venta();
                venta.codigo = modeloVenta.getNext();
                venta.numero_factura = numeroFacturaText.Text;
                venta.codigo_cliente = cliente.codigo;
                venta.fecha = Convert.ToDateTime(fechaInicialText.Text);
                venta.fecha_limite = Convert.ToDateTime(fechaFinalText.Text);
                venta.ncf =modeloComprobantefiscal.getNextComprobanteFiscalByTipoId(cajero.codigo_caja,Convert.ToInt16(tipoComprobanteCombo.SelectedValue));
                venta.tipo_venta = tipoVentaComboBox.Text;
                venta.activo = true;
                venta.pagada = false;
                venta.codigo_sucursal = empleado.codigo_sucursal;
                venta.codigo_empleado = empleado.codigo;
                venta.codigo_empelado_anular = 0;
                venta.motivo_anulada = "";
                venta.detalle = detalleText.Text;
                venta.codigo_tipo_comprobante = Convert.ToInt16(tipoComprobanteCombo.SelectedValue);


                //hacer lista del detalle de la venta
                listaVentaDetalle = new List<venta_detalle>();
                int cont = 1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    ventaDetalle = new venta_detalle();
                    ventaDetalle.codigo = cont;
                    ventaDetalle.cod_venta = venta.codigo;
                    //MessageBox.Show(row.Cells[0].ToString() + "-" + row.Cells[2].Value.ToString() + "-" + row.Cells[5].Value.ToString() + "-" + row.Cells[4].Value.ToString() + "-" + row.Cells[8].Value.ToString() + "-" + row.Cells[7].Value.ToString());
                    ventaDetalle.codigo_producto = Convert.ToInt16(row.Cells[0].Value);
                    ventaDetalle.codigo_unidad = Convert.ToInt16(row.Cells[2].Value);
                    ventaDetalle.precio = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    ventaDetalle.cantidad = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    ventaDetalle.monto = Convert.ToDecimal(row.Cells[8].Value.ToString());
                    ventaDetalle.monto_itebis = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    ventaDetalle.monto_descuento = Convert.ToDecimal(row.Cells[7].Value.ToString());
                    ventaDetalle.activo = true;
                    listaVentaDetalle.Add(ventaDetalle);
                    cont++;
                }

                if (crear == true)
                {
                    //agregar
                    //validar si la compra es al contado para proceder hacer el cobro
                    if (venta.tipo_venta == "CON")
                    {
                        ventanaDesglose = new ventana_desglose_dinero(venta, listaVentaDetalle);
                        ventanaDesglose.ShowDialog();
                        if (ventanaDesglose.DialogResult == DialogResult.OK)
                        {
                            venta = null;
                            loadVentana();
                        }
                    }
                    else
                    {
                        //la compra no es al contado entonces solo se guarda pero no hay desglose de pago
                        if (modeloVenta.agregarVenta(venta, listaVentaDetalle) == true)
                        {
                            if (MessageBox.Show("Se agregó, desea Imprimir la venta?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                modeloReporte.imprimirVenta(venta.codigo);
                            }
                            venta = null;
                            loadVentana();
                        }
                        else
                        {
                            venta = null;
                            MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                venta = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadListaVentaDetalle()
        {
            try
            {
                if (listaVentaDetalle == null)
                {
                    return;
                }

                listaVentaDetalle.ForEach(x =>
                {
                    producto = modeloProducto.getProductoById(x.codigo_producto);
                    unidad = modeloUnidad.getUnidadById(x.codigo_unidad);
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    dataGridView1.Rows.Add(x.codigo_producto, producto.nombre, x.codigo_unidad, unidad.unidad_abreviada, x.cantidad, x.precio, (itebis.porciento * x.monto), x.monto_descuento, x.monto);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaVentaDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void eliminarProducto()
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
                    dataGridView1.Rows.Remove(dataGridView1.Rows[fila]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminarProducto.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void agregarProducto()
        {
            try
            {
                //validaciones

                //validar que tenga producto seleccionado
                if (producto == null)
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un producto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //validar que tiene unidad seleccionada
                if (unidad == null)
                {
                    unidadComboText.Focus();
                    MessageBox.Show("Debe seleccionar una unidad", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //validar que tenga cantidad 
                if (cantidadText.Text == "")
                {
                    MessageBox.Show("Falta la cantidad", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cantidadText.Focus();
                    cantidadText.SelectAll();
                    return;
                }
                //validar que tenga costo 
                if (precioText.Text == "")
                {
                    MessageBox.Show("Falta el precio del producto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    precioText.Focus();
                    precioText.SelectAll();
                    return;
                }
                //validar que tenga descuento o que sea 0
                if (descuentoText.Text == "")
                {
                    descuentoText.Text = "0.00";
                }
                //validar que tenga importe
                if (importeText.Text == "")
                {
                    importeText.Focus();
                    importeText.SelectAll();
                    MessageBox.Show("Falta el importe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //validar que si existe el producto y unidad se sume la cantidad
                int fila = 0;
                existe = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == producto.codigo.ToString() && row.Cells[2].Value.ToString() == unidad.codigo.ToString())
                    {
                        existe = true;
                        //son iguales se sacan los valores de los textBox
                        //para saber si el porciento descuento sea siempre 50->0.50 o 23->0.23
                        if (Convert.ToDecimal(descuentoText.Text) > 1)
                        {
                            descuentoText.Text = (Convert.ToDecimal(descuentoText.Text) / 100).ToString();
                        }
                        cantidad_monto = Convert.ToDecimal(cantidadText.Text);
                        precio_monto = Convert.ToDecimal(precioText.Text);
                        importe_monto = Convert.ToDecimal(importeText.Text);
                        itebis = modeloItebis.getItebisById(producto.codigo_itebis);

                        //sumar y procesar
                        cantidad_monto += Convert.ToDecimal(row.Cells[4].Value.ToString());
                        importe_monto = cantidad_monto * precio_monto;
                        itebis_monto = Convert.ToDecimal(itebis.porciento * Convert.ToDecimal(importe_monto));
                        descuento_monto = Convert.ToDecimal(descuentoText.Text) * importe_monto;
                        importe_monto = importe_monto - descuento_monto;


                        //asignar los nuevos valores en el grid
                        row.Cells[4].Value = cantidad_monto.ToString("N");
                        row.Cells[5].Value = precio_monto.ToString("N");
                        row.Cells[6].Value = itebis_monto.ToString("N");
                        row.Cells[7].Value = descuento_monto.ToString("N");
                        row.Cells[8].Value = importe_monto.ToString("N");
                    }
                    //si no se repite el producto y unidad entonces se agrega los valores del textbox
                }

                if (existe == false)
                {
                    importe_monto = Convert.ToDecimal(cantidadText.Text) * Convert.ToDecimal(precioText.Text);
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    itebis_monto = itebis.porciento * importe_monto;
                    //para saber si el porciento descuento sea siempre 50->0.50 o 23->0.23
                    if (Convert.ToDecimal(descuentoText.Text) > 1)
                    {
                        descuentoText.Text = (Convert.ToDecimal(descuentoText.Text) / 100).ToString();
                    }
                    descuento_monto = Convert.ToDecimal(descuentoText.Text) * importe_monto;
                    importe_monto = importe_monto - descuento_monto;
                    dataGridView1.Rows.Add(producto.codigo.ToString(), producto.nombre, unidad.codigo.ToString(), unidad.nombre, cantidadText.Text, precioText.Text, itebis_monto.ToString("N"), descuento_monto.ToString("N"), importe_monto.ToString("N"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarProducto.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calcularTotal()
        {
            try
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    totalItebisText.Text = "0.00";
                    totalCompraText.Text = "0.00";
                    return;
                }

                totalItebisMonto = 0;
                totalCompraMonto = 0;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    totalItebisMonto += Convert.ToDecimal(row.Cells[6].Value.ToString());
                    totalCompraMonto = Convert.ToDecimal(row.Cells[8].Value.ToString());
                }
                totalItebisText.Text = totalItebisMonto.ToString("N");
                totalCompraText.Text = totalCompraMonto.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calcularTotal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadProducto()
        {
            try
            {
                productoIdText.Text = "";
                productoText.Text = "";
                if (producto == null)
                {
                    return;
                }
                productoIdText.Text = producto.codigo.ToString();
                productoText.Text = producto.nombre;

                loadUnidad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void loadUnidad()
        {
            try
            {
                if (producto == null)
                {
                    unidadComboText.Text = "";
                    unidadComboText.DataSource = null;
                    unidadComboText.DisplayMember = null;
                    return;
                }
                listaUnidad = modeloUnidad.getListaByProducto(producto.codigo);
                unidadComboText.DataSource = listaUnidad;
                unidadComboText.ValueMember = "codigo";
                unidadComboText.DisplayMember = "nombre";
                if (listaUnidad.Count > 0)
                {
                    unidad = modeloUnidad.getUnidadById(listaUnidad[0].codigo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void getInventarioByProductoUnidad()
        {
            try
            {
                cantidadExistencia = 0;
                if (producto == null)
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un producto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (unidadComboText.Text == "")
                {
                    return;
                }
                //MessageBox.Show(unidadComboText.SelectedValue + "-" + unidadComboText.Text);
                cantidadExistencia = modeloProducto.getExistenciaByProductoAndUnidad(producto.codigo, Convert.ToInt16(unidadComboText.SelectedValue.ToString()));
                existenciaText.Text = cantidadExistencia.ToString("N");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error getInventarioByProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void calularImporte()
        {
            try
            {
                if (descuentoText.Text == "")
                {
                    descuentoText.Text = "0.00";
                }
                if (cantidadText.Text == "")
                {
                    importeText.Text = "";
                    return;
                }
                if (precioText.Text == "")
                {
                    importeText.Text = "";
                    return;
                }

                itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                cantidad_monto = Convert.ToDecimal(cantidadText.Text);
                precio_monto = Convert.ToDecimal(precioText.Text);
                descuento_monto = Convert.ToDecimal(descuentoText.Text);
                importe_monto = cantidad_monto * precio_monto;
                descuento_monto = importe_monto * descuento_porciento;
                importe_monto = importe_monto - descuento_monto;
                itebis_monto = importe_monto * itebis.porciento;
                importeText.Text = importe_monto.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calularImporte.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void actualizarCompraDetalle()
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string sql = "insert into compra_detalle(codigo,cod_compra,cod_producto,cod_unidad,precio,cantidad,monto,descuento,activo) values('','','','','','','','','')";
                    utilidades.ejecutarcomando_mysql(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizarCompraDetalle.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_facturacion_normal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ventana_cliente ventana = new ventana_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            agregarProducto();
            productoIdText.Focus();
            productoIdText.SelectAll();
            calcularTotal();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            eliminarProducto();
            productoIdText.Focus();
            productoIdText.SelectAll();
            calcularTotal();
        }

        private void unidadComboText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                getInventarioByProductoUnidad();
                getPrecioVentaProductoUnidad();
            }
            catch (Exception)
            {
                //MessageBox.Show("Error cambiando de unidad", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCliente()
        {
            try
            {
                if (cliente == null)
                {
                    clienteIdText.Text = "";
                    clienteText.Text = "";
                    return;
                }
                clienteIdText.Text = cliente.codigo.ToString();
                clienteText.Text = cliente.nombre;

            }
            catch (Exception)
            {
                
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana = new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
                tipoVentaComboBox.Focus();
                tipoVentaComboBox.SelectAll();
            }
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    clienteIdText.Focus();
                    clienteText.SelectAll();

                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    loadCliente();
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

        private void productoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    producto = modeloProducto.getProductoById(Convert.ToInt16(productoIdText.Text));
                    if (producto != null)
                    {
                        loadProducto();
                    }
                    unidadComboText.Focus();
                    unidadComboText.SelectAll();
                    loadUnidad();
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_producto ventana = new ventana_busqueda_producto();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                producto = ventana.getObjeto();
                loadProducto();
                unidadComboText.Focus();
                unidadComboText.SelectAll();
            }
        }

        private void tipoVentaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tipoComprobanteCombo.Focus();
                tipoComprobanteCombo.SelectAll();
            }

        }

        private void tipoComprobanteCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                fechaInicialText.Focus();
                fechaInicialText.SelectAll();
            }
        }

        private void fechaInicialText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                fechaFinalText.Focus();
                fechaFinalText.SelectAll();
            }
        }

        private void fechaFinalText_KeyDown(object sender, KeyEventArgs e)
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
                productoIdText.Focus();
                productoIdText.SelectAll();
            }
        }

        private void unidadComboText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                cantidadText.Focus();
                cantidadText.SelectAll();
            }
        }

        private void precioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                descuentoText.Focus();
                descuentoText.SelectAll();
            }
        }

        private void cantidadText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                precioText.Focus();
                precioText.SelectAll();
            }
        }

        private void descuentoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                importeText.Focus();
                importeText.SelectAll();
            }
        }

        private void importeText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button20.Focus();
            }
        }

        private void button20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                button19.Focus();
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
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

        private void descuentoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, descuentoText.Text);
        }

        private void descuentoText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
        }

        private void precioText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
        }

        private void precioText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, precioText.Text);
        }

        private void cantidadText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
        }

        private void cantidadText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, cantidadText.Text);
        }

        public void getPrecioVentaProductoUnidad()
        {
            try
            {
                 precioText.Text= modeloProducto.getPrecioProductoUnidad(producto.codigo, Convert.ToInt16(unidadComboText.SelectedValue)).precio_venta1.ToString("N");
            }
            catch (Exception ex)
            {
                precioText.Text = "0.00";
                //MessageBox.Show("Error getPrecioVentaProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void ventana_facturacion_normal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                agregarProducto();
            }
            if (e.KeyCode == Keys.F2)
            {
                eliminarProducto();
            }
            if (e.KeyCode == Keys.F3)
            {
                cambiarTipoVentacombo();
            }
            if (e.KeyCode == Keys.F4)
            {
                cambiarTipoComprobante();
            }
        }

        public void cambiarTipoVentacombo()
        {
            try
            {
                int cantItems = 0;
                cantItems = tipoVentaComboBox.Items.Count;
                if (tipoVentaComboBox.SelectedIndex == (cantItems - 1))
                {
                    tipoVentaComboBox.SelectedIndex = 0;
                }
                else
                {
                    tipoVentaComboBox.SelectedIndex += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cambiarTipoVentacombo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void cambiarTipoComprobante()
        {
            try
            {
                int cantItems = 0;
                cantItems = tipoComprobanteCombo.Items.Count;
                if (tipoComprobanteCombo.SelectedIndex == (cantItems - 1))
                {
                    tipoComprobanteCombo.SelectedIndex = 0;
                }
                else
                {
                    tipoComprobanteCombo.SelectedIndex += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cambiarTipoComprobante.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
