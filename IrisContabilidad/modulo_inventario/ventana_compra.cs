using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_compra : formBase
    {
        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private compra compra;
        private producto producto;
        private itebis itebis;
        private unidad unidad;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;
        private productoUnidadConversion productoUnidadConversion;
        private suplidor suplidor;



        //modelos
        private modeloItebis modeloItebis = new modeloItebis();
        private modeloUnidad modeloUnidad = new modeloUnidad();
        private modeloAlmacen modeloAlmacen = new modeloAlmacen();
        private modeloProducto modeloProducto = new modeloProducto();
        modeloSuplidor modeloSuplidor=new modeloSuplidor();
        modeloCompra modeloCompra=new modeloCompra();

        
        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<producto_vs_codigobarra> listaCodigoBarra;
        private List<productoUnidadConversion> listaProductoUnidadConversion;
        private List<compra> listaCompra; 
        private List<compra_detalle> listaCompraDetalle;
        private List<unidad> listaUnidad; 



        public ventana_compra()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana compra");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                tipoCompraComboBox.SelectedIndex = 0;
                if (compra != null)
                {
                    //llenar campos
                    suplidorIdText.Text = compra.codigo_sucursal.ToString();
                    suplidorText.Text = modeloSuplidor.getSuplidorById(compra.cod_suplidor).nombre;
                    numeroFacturaText.Text = compra.numero_factura;
                    numerocComprobanteFiscalText.Text = compra.ncf;
                    tipoCompraComboBox.Enabled = false;
                    tipoCompraComboBox.Text = compra.tipo_compra;
                    fechaCreadaPicker.Value = compra.fecha;
                    fechaLimiteTimePicker.Value = compra.fecha_limite;
                    detalleText.Text = compra.detalle;
                    suplidorInformalCheck.Checked = Convert.ToBoolean(compra.suplidor_informal);
                    //llenar el detalle de la compra
                    listaCompraDetalle = modeloCompra.getListaCompraDetalle(compra.codigo,true);
                }
                else
                {
                    //blanquear campos
                    suplidorIdText.Text = "";
                    suplidorText.Text = "";
                    numeroFacturaText.Text = "";
                    numerocComprobanteFiscalText.Text = "";
                    tipoCompraComboBox.Enabled = true;
                    tipoCompraComboBox.Text = "";
                    fechaCreadaPicker.Value = DateTime.Today;
                    fechaLimiteTimePicker.Value = DateTime.Today;
                    detalleText.Text = "";
                    suplidorInformalCheck.Checked = false;
                    suplidorInformalCheck.Checked = false;
                    //limpiar el detalle de la compra
                    listaCompraDetalle=new List<compra_detalle>();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadListaCompraDetalle()
        {
            try
            {
                if (listaCompraDetalle == null)
                {
                    return;
                }

                listaCompraDetalle.ForEach(x =>
                {
                    producto = modeloProducto.getProductoById(x.cod_producto);
                    unidad = modeloUnidad.getUnidadById(x.cod_unidad);
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    dataGridView1.Rows.Add(x.cod_producto, producto.nombre, x.cod_unidad, unidad.unidad_abreviada,x.cantidad,x.precio,(itebis.porciento*x.monto),x.descuento,x.monto);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaCompraDetalle.:"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void ventana_compra_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ventana_suplidor ventana=new ventana_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            eliminarProducto();
        }

        public void eliminarProducto()
        {
            try
            {
                //validar que tenga filas el datagrid
                if (dataGridView1.Rows.Count < 0)
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

        private void button20_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }
        public void agregarProducto()
        {
            try
            {
                //validaciones

                //validar que tenga unidadConversion seleccionada
                if (producto == null)
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un producto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Falta el precio de costo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    precioText.Focus();
                    precioText.SelectAll();
                    return;
                }
                //validar que tenga precio de venta 
                if (descuentoText.Text == "")
                {
                    descuentoText.Text = "0.00";
                }
                //validar que tiene unidad seleccionada
                if (unidad == null)
                {
                    unidadComboText.Focus();
                    MessageBox.Show("Debe seleccionar una unidad", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //validar que si existe el producto y unidad se sume la cantidad
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == producto.codigo.ToString() && row.Cells[2].Value.ToString()==unidad.codigo.ToString())
                    {

                    }
                }

                if (existe == false)
                {
                    //dataGridView1.Rows.Add(unidadConversion.codigo.ToString(), unidadConversion.nombre, cantidadText.Text.Trim(), precioCostoText.Text.Trim(), precioVentaText.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarUnidadConversion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        public void loadProducto()
        {
            try
            {
                if (producto == null)
                {
                    productoIdText.Text = "";
                    productoText.Text = "";
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
                unidadComboText.ValueMember = "nombre";
                unidadComboText.DisplayMember = "nombre";
                if (listaUnidad.Count>0)
                {
                    unidad = modeloUnidad.getUnidadById(listaUnidad[0].codigo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void unidadComboText_TextChanged(object sender, EventArgs e)
        {
            //cuando el combo de la unidad cambie debe sacar la unidad seleccionada

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

        private void button3_Click_1(object sender, EventArgs e)
        {
            compra = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
