using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_compra_devolucion : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private suplidor suplidor;
        private compra compra;
        private producto producto;
        private unidad unidad;
        private compraDevolucion compraDevolucion;
        private compraDevolucionDetalle compraDevolucionDetalle;
        private ingreso_caja ingresoCaja;
        private cxp_nota_credito notaCredito;

        //modelos
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloCompra modeloCompra=new modeloCompra();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloProducto modeloProducto=new modeloProducto();
        modeloUnidad modeloUnidad=new modeloUnidad();
        modeloCompraDevolucion modeloCompraDevolucion=new modeloCompraDevolucion();
        private modeloIngresoCaja modeloIngresoCaja =new modeloIngresoCaja();
        modeloCxpNotaCredito modeloNotaCredito=new modeloCxpNotaCredito();


        //listas
        private List<compra_detalle> listaCompraDetalle;
        private List<compraDevolucionDetalle> listaCompraDevolucionDetalle;


        public ventana_compra_devolucion()
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
                if (compra != null)
                {
                    compraIdText.Focus();
                    compraIdText.SelectAll();

                    listaCompraDevolucionDetalle=new List<compraDevolucionDetalle>();
                    suplidor = modeloSuplidor.getSuplidorById(compra.cod_suplidor);
                    clienteLabel.Text = suplidor.nombre;
                    tipoVentaLabel.Text = compra.tipo_compra;
                    ncfLabel.Text = compra.ncf;
                    loadDetalleCompra();
                }
                else
                {
                    compraIdText.Focus();
                    compraIdText.SelectAll();

                    listaCompraDevolucionDetalle = new List<compraDevolucionDetalle>();
                    suplidor = null;
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

        public void loadDetalleCompra()
        {
            try
            {
                if (compra == null)
                {
                    return;
                }

                listaCompraDetalle=new List<compra_detalle>();
                listaCompraDetalle = modeloCompra.getListaCompraDetalleByCompra(compra.codigo);

                listaCompraDetalle.ForEach(x =>
                {
                    producto = modeloProducto.getProductoById(x.cod_producto);
                    unidad = modeloUnidad.getUnidadById(x.cod_unidad);
                    dataGridView1.Rows.Add(x.cod_producto,producto.nombre,x.cod_unidad,unidad.nombre,x.cantidad,x.precio,x.monto,"0.00");
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadDetalleCompra.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //validar venta
                if (compra==null)
                {
                    MessageBox.Show("Falta la compra", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    compraIdText.Focus();
                    compraIdText.SelectAll();
                    return false;
                }
                //validar que datagrid tenga datos
                if (dataGridView1.Rows.Count<0)
                {
                    MessageBox.Show("Esta compra no tiene articulos disponibles para realizar devolución", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    compraIdText.Focus();
                    compraIdText.SelectAll();
                    return false;
                }
                //validar que exista un concepto de devolucion
                if (detalleText.Text == "")
                {
                    MessageBox.Show("Debe especificar una descripción o razón de la devolución", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detalleText.Focus();
                    detalleText.SelectAll();
                    return false;
                }
                //validar que exista un producto devuelto
                if (dataGridView1.Rows.Count < 0)
                {
                    bool existe = false;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToDecimal(row.Cells[7].Value.ToString()) > 0)
                        {
                            existe = true;
                        }
                    }
                    if (existe == false)
                    {
                        MessageBox.Show("No ha puesto algun producto a devolver", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
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
                if ( compraDevolucion== null)
                {
                    compraDevolucion = new compraDevolucion();
                    crear = true;
                    compraDevolucion.codigo = modeloCompraDevolucion.getNext();
                    compraDevolucion.codigo_compra = compra.codigo;
                    compraDevolucion.fecha = DateTime.Today;
                    compraDevolucion.codigo_empleado = empleado.codigo;
                    compraDevolucion.activo = true;
                }
                //llenando la lista devolucion detalle
                listaCompraDevolucionDetalle=new List<compraDevolucionDetalle>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    compraDevolucionDetalle=new compraDevolucionDetalle();
                    compraDevolucionDetalle.codigo = 0;
                    compraDevolucionDetalle.codigo_devolucion = 0;
                    compraDevolucionDetalle.codigo_producto = Convert.ToInt16(row.Cells[0].Value.ToString());
                    compraDevolucionDetalle.codigo_unidad = Convert.ToInt16(row.Cells[2].Value.ToString());
                    compraDevolucionDetalle.cantidad = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    compraDevolucionDetalle.precio = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    compraDevolucionDetalle.monto_total = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    compraDevolucionDetalle.cantidad = Convert.ToDecimal(row.Cells[7].Value.ToString());
                    listaCompraDevolucionDetalle.Add(compraDevolucionDetalle);
                 }

                decimal montoTotalDevolucion = 0;
                //tomando el monto total de la devolucion
                listaCompraDevolucionDetalle.ForEach(x =>
                {
                    montoTotalDevolucion += x.monto_total;
                });
                //si se efectuara un egreso de caja automatico
                if (crearNotaCreditoCheck.Checked == true)
                {
                    ingresoCaja=new ingreso_caja();
                    ingresoCaja.codigo = modeloIngresoCaja.getNext();
                    ingresoCaja.afecta_cuadre = true;
                    ingresoCaja.cuadrado = false;
                    ingresoCaja.fecha=DateTime.Today;
                    ingresoCaja.activo = true;
                    ingresoCaja.detalle = "Por concepto de devolución";
                    ingresoCaja.codigo_cajero = empleado.codigo;
                    ingresoCaja.codigo_concepto = 1;
                    ingresoCaja.monto = montoTotalDevolucion;
                    ingresoCaja.modificable = false;
                    ingresoCaja.activo = true;
                }
                if (crear == true)
                {
                    //se agrega
                    if ((modeloCompraDevolucion.agregarDevolucion(compraDevolucion, listaCompraDevolucionDetalle,ingresoCaja)) == true)
                    {
                        compraDevolucion = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        compraDevolucion = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                compraDevolucion = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_venta_devolucion_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_compra ventana = new ventana_busqueda_compra();
            ventana.Owner = this;
            ventana.ShowDialog();
            if ((compra = ventana.getObjeto()) != null)
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
            compra = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void ventana_venta_devolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                //crearNotaCreditoCheck.Checked = !(bool) crearNotaCreditoCheck.Checked;
            }
        }
    }
}
