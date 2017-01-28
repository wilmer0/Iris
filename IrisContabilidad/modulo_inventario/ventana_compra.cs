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


        //variables
        private decimal cantidad_monto = 0;
        private decimal precio_monto = 0;
        private decimal importe_monto = 0;
        private decimal descuento_monto = 0;
        private decimal descuento_porciento = 0;
        private decimal itebis_monto = 0;


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
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
                    //llenar campos
                    suplidorIdText.Text = compra.codigo_sucursal.ToString();
                    suplidorText.Text = modeloSuplidor.getSuplidorById(compra.cod_suplidor).nombre;
                    numeroFacturaText.Text = compra.numero_factura;
                    numerocComprobanteFiscalText.Text = compra.ncf;
                    tipoCompraComboBox.Enabled = false;
                    tipoCompraComboBox.Text = compra.tipo_compra;
                    fechaInicialText.Text = compra.fecha.ToString("d");
                    fechaFinalText.Text = compra.fecha_limite.ToString("d");
                    detalleText.Text = compra.detalle;
                    suplidorInformalCheck.Checked = Convert.ToBoolean(compra.suplidor_informal);
                    //llenar el detalle de la compra
                    listaCompraDetalle = modeloCompra.getListaCompraDetalle(compra.codigo,true);
                }
                else
                {
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
                    //blanquear campos
                    suplidorIdText.Text = "";
                    suplidorText.Text = "";
                    numeroFacturaText.Text = "";
                    numerocComprobanteFiscalText.Text = "";
                    tipoCompraComboBox.Enabled = true;
                    tipoCompraComboBox.Text = "";
                    fechaInicialText.Text = DateTime.Today.ToString("d");
                    fechaFinalText.Text = DateTime.Today.ToString("d");
                    detalleText.Text = "";
                    suplidorInformalCheck.Checked = false;
                    suplidorInformalCheck.Checked = false;
                    //limpiar el detalle de la compra
                    listaCompraDetalle=new List<compra_detalle>();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                    }
                    fechaInicialText.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    fechaFinalText.Text = DateTime.Today.ToString("dd-MM-yyyy");
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
                if (dataGridView1==null || dataGridView1.Rows.Count < 0)
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
                    MessageBox.Show("Falta el precio de costo", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    cantidadText.Focus();
                    cantidadText.SelectAll();
                    MessageBox.Show("Falta el importe", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
                //validar que si existe el producto y unidad se sume la cantidad
                int fila = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == producto.codigo.ToString() && row.Cells[2].Value.ToString()==unidad.codigo.ToString())
                    {
                        //son iguales se sacan los valores del grid
                        cantidad_monto = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[4].Value.ToString());
                        precio_monto = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[5].Value.ToString());
                        descuento_porciento = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[7].Value.ToString());
                        importe_monto = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[8].Value.ToString());
                        
                        //sumar lo que se quiere agregar
                        cantidad_monto += Convert.ToDecimal(cantidadText.Text);
                        if (precio_monto != Convert.ToDecimal(precioText.Text))
                        {
                            precio_monto = Convert.ToDecimal(precioText.Text);
                        }
                        descuento_porciento = Convert.ToDecimal(descuentoText.Text);
                        importe_monto = (cantidad_monto * precio_monto);
                        descuento_monto = importe_monto * descuento_porciento;
                        importe_monto = importe_monto - descuento_monto;


                        //asignar los nuevos valores en el grid
                        dataGridView1.Rows[fila].Cells[4].Value = cantidad_monto.ToString("N");
                        dataGridView1.Rows[fila].Cells[5].Value = precio_monto.ToString("N");
                        dataGridView1.Rows[fila].Cells[7].Value = descuento_monto.ToString("N");
                        dataGridView1.Rows[fila].Cells[8].Value = importe_monto.ToString("N");
                    }
                    //si no se repite el producto y unidad entonces se agrega los valores del textbox
                    cantidad_monto = Convert.ToDecimal(cantidadText.Text);
                    precio_monto = Convert.ToDecimal(precioText.Text);
                    descuento_porciento = Convert.ToDecimal(descuentoText.Text);
                    importe_monto = Convert.ToDecimal(importeText.Text);
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    itebis_monto = importe_monto*itebis.porciento;
                    dataGridView1.Rows.Add(producto.codigo, producto.nombre, unidad.codigo, unidad.nombre, cantidad_monto.ToString("N"),precio_monto.ToString("N"),itebis_monto.ToString("N"),descuento_monto.ToString("N"),importe_monto.ToString("N"));
                    fila++;
                }

                if (existe == false)
                {
                    importe_monto = Convert.ToDecimal(cantidadText.Text)*Convert.ToDecimal(precioText.Text);
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    itebis_monto = itebis.porciento*importe_monto;
                    //para saber si el porciento descuento sea siempre 50->0.50 o 23->0.23
                    if (Convert.ToDecimal(descuentoText.Text) > 0)
                    {
                        descuentoText.Text = (Convert.ToDecimal(descuentoText.Text)/100).ToString();
                    }
                    descuento_monto = Convert.ToDecimal(descuentoText.Text)*importe_monto;
                    importe_monto = importe_monto - descuento_monto;
                    dataGridView1.Rows.Add(producto.codigo.ToString(), producto.nombre, unidad.codigo.ToString(), unidad.nombre, cantidadText.Text, precioText.Text, itebis_monto.ToString("n"), descuento_monto.ToString("n"), importe_monto.ToString("n"));
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
                unidadComboText.ValueMember = "codigo";
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

        private void suplidorIdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                suplidorText.Focus();
                suplidorText.SelectAll();
            }
            if (e.KeyCode == Keys.F1)
            {
                button5_Click(null, null);
            }
        }

        private void suplidorText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                numeroFacturaText.Focus();
                numeroFacturaText.SelectAll();
            }
        }

        private void numeroFacturaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                numerocComprobanteFiscalText.Focus();
                numerocComprobanteFiscalText.SelectAll();
            }
        }

        private void numerocComprobanteFiscalText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tipoCompraComboBox.Focus();
                tipoCompraComboBox.SelectAll();
            }
        }

        private void tipoCompraComboBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                fechaInicialText.Focus();
                fechaInicialText.SelectAll();
            }
        }

        

        private void fechaLimiteTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                detalleText.Focus();
                detalleText.Select();
            }
        }

        private void detalleText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                suplidorInformalCheck.Focus();
            }
        }

        private void suplidorInformalCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                productoIdText.Focus();
                productoIdText.SelectAll();
            }
        }

        private void productoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                unidadComboText.Focus();
                unidadComboText.SelectAll();
            }
            if (e.KeyCode == Keys.F1)
            {
                button4_Click(null,null);
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

        private void cantidadText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                precioText.Focus();
                precioText.SelectAll();
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

        private void descuentoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button20.Focus();
            }
        }

        private void ventana_compra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
               button20_Click(null,null);
            }
            if (e.KeyCode == Keys.F2)
            {
                button19_Click(null, null);
            }
        }

        public void loadSuplidor()
        {
            try
            {
                if(suplidor==null)
                {
                    suplidorIdText.Text = "";
                    suplidorText.Text = "";
                    return;
                }
                suplidorIdText.Text = suplidor.codigo.ToString();
                suplidorText.Text = suplidor.nombre;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana = new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }
        public void cargarPrecioProductoUnidad()
        {
            try
            {
                //validar producto
                if (producto == null)
                {
                    productoIdText.Text = "";
                    productoText.Text = "";

                    productoIdText.Focus();
                    productoIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un producto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //validar unidad
                if (unidad == null)
                {
                    unidadComboText.Focus();
                    unidadComboText.SelectAll();
                    MessageBox.Show("Debe seleccionar una unidad", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                productoUnidadConversion = modeloProducto.getPrecioProductoUnidad(producto.codigo, unidad.codigo);
                precioText.Text = productoUnidadConversion.precio_costo.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargarPrecioProductoUnidad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                importe_monto = cantidad_monto*precio_monto;
                descuento_monto = importe_monto*descuento_porciento;
                importe_monto = importe_monto - descuento_monto;
                itebis_monto = importe_monto*itebis.porciento;
                importeText.Text = importe_monto.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calularImporte.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cantidadText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,cantidadText.Text);
        }

        private void precioText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, precioText.Text);
        }

        private void descuentoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, descuentoText.Text);
        }

        private void cantidadText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
        }

        private void precioText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
        }

        private void descuentoText_TextChanged(object sender, EventArgs e)
        {
            calularImporte();
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
    }
}
