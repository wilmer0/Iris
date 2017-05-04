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

namespace IrisContabilidad.modulo_facturacion
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
        private ventaDevolucion ventaDevolucion;
        private ventaDevolucionDetalle ventaDevolucionDetalle;
        private egreso_caja egresoCaja;

        //modelos
        modeloCliente modeloCliente = new modeloCliente();
        modeloVenta modeloVenta=new modeloVenta();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloProducto modeloProducto=new modeloProducto();
        modeloUnidad modeloUnidad=new modeloUnidad();
        modeloVentaDevolucion modeloVentaDevolucion=new modeloVentaDevolucion();
        private modeloEgresoCaja modeloEgresoCaja=new modeloEgresoCaja();

        //listas
        private List<venta_detalle> listaVentaDetalle;
        private List<ventaDevolucionDetalle> listaVentaDevolucionDetalle; 


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
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    listaVentaDevolucionDetalle=new List<ventaDevolucionDetalle>();
                    cliente = modeloCliente.getClienteById(venta.codigo_cliente);
                    clienteLabel.Text = cliente.nombre;
                    tipoVentaLabel.Text = venta.tipo_venta;
                    ncfLabel.Text = venta.ncf;
                    loadDetalleVenta();
                }
                else
                {
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();

                    listaVentaDevolucionDetalle = new List<ventaDevolucionDetalle>();
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
                listaVentaDetalle = modeloVenta.getListaVentaDetalleByVentaId(venta.codigo);

                listaVentaDetalle.ForEach(x =>
                {
                    producto = modeloProducto.getProductoById(x.codigo_producto);
                    unidad = modeloUnidad.getUnidadById(x.codigo_unidad);
                    dataGridView1.Rows.Add(x.codigo_producto,producto.nombre,x.codigo_unidad,unidad.nombre,x.cantidad,x.precio,x.monto_total,"0.00");
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
        public bool validarGetAction()
        {
            try
            {
                //validar venta
                if (venta==null)
                {
                    MessageBox.Show("Falta la venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();
                    return false;
                }
                //validar que datagrid tenga datos
                if (dataGridView1.Rows.Count<0)
                {
                    MessageBox.Show("Esta venta no tiene articulos disponibles para realizar devolución", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ventaIdText.Focus();
                    ventaIdText.SelectAll();
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
                if (dataGridView1.Rows.Count > 0)
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
                if ( ventaDevolucion== null)
                {
                    ventaDevolucion = new ventaDevolucion();
                    crear = true;
                    ventaDevolucion.codigo = modeloVentaDevolucion.getNext();
                    ventaDevolucion.codigo_venta = venta.codigo;
                    ventaDevolucion.fecha = DateTime.Today;
                    ventaDevolucion.codigo_empleado = empleado.codigo;
                    ventaDevolucion.activo = true;
                }
                //llenando la lista devolucion detalle
                listaVentaDevolucionDetalle=new List<ventaDevolucionDetalle>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    ventaDevolucionDetalle=new ventaDevolucionDetalle();
                    ventaDevolucionDetalle.codigo = 0;
                    ventaDevolucionDetalle.codigo_devolucion = 0;
                    ventaDevolucionDetalle.codigo_producto = Convert.ToInt16(row.Cells[0].Value.ToString());
                    ventaDevolucionDetalle.codigo_unidad = Convert.ToInt16(row.Cells[2].Value.ToString());
                    ventaDevolucionDetalle.cantidad = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    ventaDevolucionDetalle.precio = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    ventaDevolucionDetalle.monto_total = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    ventaDevolucionDetalle.cantidad = Convert.ToDecimal(row.Cells[7].Value.ToString());
                    listaVentaDevolucionDetalle.Add(ventaDevolucionDetalle);
                 }

                decimal montoTotalDevolucion = 0;
                //tomando el monto total de la devolucion
                listaVentaDevolucionDetalle.ForEach(x =>
                {
                    montoTotalDevolucion += x.monto_total;
                });
                //si se efectuara un egreso de caja automatico
                if (egresoCajaAutomaticoCheck.Checked == true)
                {
                    egresoCaja=new egreso_caja();
                    egresoCaja.codigo = modeloEgresoCaja.getNext();
                    egresoCaja.afecta_cuadre = true;
                    egresoCaja.cuadrado = false;
                    egresoCaja.fecha=DateTime.Today;
                    egresoCaja.activo = true;
                    egresoCaja.detalle = "Por concepto de devolución";
                    egresoCaja.codigo_cajero = empleado.codigo;
                    egresoCaja.codigo_concepto = 1;
                    egresoCaja.monto = montoTotalDevolucion;
                    egresoCaja.modificable = false;
                    egresoCaja.activo = true;
                }
                if (crear == true)
                {
                    //se agrega
                    if ((modeloVentaDevolucion.agregarDevolucion(ventaDevolucion, listaVentaDevolucionDetalle,egresoCaja)) == true)
                    {
                        ventaDevolucion = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        ventaDevolucion = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                cliente = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void ventana_venta_devolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                egresoCajaAutomaticoCheck.Checked = !(bool) egresoCajaAutomaticoCheck.Checked;
            }
        }
    }
}
