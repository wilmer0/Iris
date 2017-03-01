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

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_producto_lista_precio : formBase
    {
        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private producto producto;
        private unidad unidadMinima;
        unidad unidad;
        
        //modelos
        private modeloUnidad modeloUnidad = new modeloUnidad();
        private modeloProducto modeloProducto = new modeloProducto();
        

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<producto> listaProducto;
        private List<producto_precio_venta> listaPrecioVenta; 

        public ventana_producto_lista_precio()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "producto lista precios");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                loadListaPrecioProducto();
                if (producto != null)
                {
                    //llenar campos
                    productoIdText.Text = producto.codigo.ToString();
                    productoLabel.Text = producto.nombre;
                }
                else
                {
                    productoIdText.Focus();
                    productoIdText.SelectAll();

                    //blanquear campos
                    productoIdText.Text = "";
                    productoLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadListaPrecioProducto()
        {
            try
            {
                if (listaPrecioVenta == null)
                {
                    listaPrecioVenta = new List<producto_precio_venta>();
                    listaPrecioVenta = modeloProducto.getListaProductoPrecioVenta();
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                
                if (producto != null)
                {
                    listaPrecioVenta = listaPrecioVenta.FindAll(x => x.codigo_producto == producto.codigo);
                }
                listaPrecioVenta.ForEach(x =>
                {
                    producto=new producto();
                    unidad=new unidad();

                    producto = modeloProducto.getProductoById(x.codigo_producto);
                    unidad = modeloUnidad.getUnidadById(x.codigo_unidad);

                    dataGridView1.Rows.Add(x.codigo_producto, producto.nombre, x.codigo_unidad, unidad.nombre, x.precio_venta1.ToString("N"), x.precio_venta2.ToString("N"), x.precio_venta3.ToString("N"), x.precio_venta4.ToString("N"), x.precio_venta5.ToString("N"));
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaPrecioProducto.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ventana_producto_lista_precio_Load(object sender, EventArgs e)
        {

        }

        public bool validarGetAction()
        {
            try
            {

                bool vacio = false;
                //validar itebis
                //if (itebis == null)
                //{
                //    MessageBox.Show("Falta el itbis", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    itebisIdText.Focus();
                //    itebisIdText.SelectAll();
                //    return false;
                //}
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    decimal precio = 0;
                    for (int i=4;i<8;i++)
                    {
                        if (decimal.TryParse(row.Cells[4].Value.ToString(), out precio) == false)
                        {
                            vacio = true;
                            MessageBox.Show("Error precio no tiene formato numerico en la linea.:"+row.Index, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                if (vacio == true)
                {
                    MessageBox.Show("Se detecto un precio no tiene formato numerico", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void GetAction()
        {
            try
            {

                //if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}

                //if (!validarGetAction())
                //{
                //    return;
                //}


                //bool crear = false;
                //if (producto == null)
                //{
                //    //agrega
                //    crear = true;
                //    producto = new producto();
                //    producto.codigo = modeloProducto.getNext();
                //}
                //producto.nombre = productoText.Text;
                //producto.referencia = referenciaText.Text;
                //producto.activo = Convert.ToBoolean(activoCheck.Checked);
                //producto.codigo_categoria = categoria.codigo;
                //producto.codigo_subcategoria = subCategoria.codigo;
                //producto.punto_maximo = Convert.ToDecimal(puntoMaximoText.Text);
                //producto.reorden = Convert.ToDecimal(puntoReordenText.Text);
                //producto.codigo_itebis = itebis.codigo;
                //producto.codigo_almacen = almacen.codigo;
                //producto.codigo_unidad_minima = unidadMinima.codigo;
                //if (rutaImagenText.Text != "")
                //{
                //    producto.imagen = rutaImagenText.Text;
                //}
                //else
                //{
                //    producto.imagen = "";
                //}
                //if (crear)
                //{
                //    //agrega
                //    if (modeloProducto.agregarProducto(producto) == true)
                //    {
                //        actualizarCodigoBarra();
                //        actualizarUnidadConversion();
                //        actualizarProductoProduccion();
                //        producto = null;
                //        listaCodigoBarra = null;
                //        loadVentana();
                //        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        producto = null;
                //        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                //else
                //{
                //    //actualiza
                //    if (modeloProducto.modificarProducto(producto) == true)
                //    {
                //        actualizarCodigoBarra();
                //        actualizarUnidadConversion();
                //        actualizarProductoProduccion();
                //        producto = null;
                //        listaCodigoBarra = null;
                //        loadVentana();
                //        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }

                //}
                //producto = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            listaPrecioVenta = null;
            loadListaPrecioProducto();
        }

        public void loadProducto()
        {
            try
            {
                productoIdText.Text = "";
                productoLabel.Text = "";
                if (producto != null)
                {
                    productoIdText.Text = producto.codigo.ToString();
                    productoLabel.Text = producto.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadProducto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_producto ventana=new ventana_busqueda_producto();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                producto = ventana.getObjeto();
                loadProducto();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadListaPrecioProducto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void productoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    producto = modeloProducto.getProductoById(Convert.ToInt16(productoIdText.Text));
                    loadProducto();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
