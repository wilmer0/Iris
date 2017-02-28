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
                if (producto != null)
                {
                    //llenar campos
                }
                else
                {
                    //blanquear campos
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
                //validar itebis
                //if (itebis == null)
                //{
                //    MessageBox.Show("Falta el itbis", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    itebisIdText.Focus();
                //    itebisIdText.SelectAll();
                //    return false;
                //}

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
    }
}
