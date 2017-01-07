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
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_producto : formBase
    {

        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private producto producto;
        itebis itebis;
        unidad unidadMinima;
        private almacen almacen;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;

        //modelos
        modeloItebis modeloItebis = new modeloItebis();
        modeloUnidad modeloUnidad=new modeloUnidad();
        modeloAlmacen modeloAlmacen=new modeloAlmacen();
        modeloProducto modeloProducto=new modeloProducto();
        modeloCategoriaProducto modeloCategoria=new modeloCategoriaProducto();
        modeloSubCategoriaProducto modeloSubcategoria=new modeloSubCategoriaProducto();

        //variables
        private string rutaResources = "";
        private string rutaImagenesProductos = "";


        public ventana_producto()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana producto");
            this.Text = tituloLabel.Text;
            rutaResources = Directory.GetCurrentDirectory().ToString() + @"\Resources\";
            rutaImagenesProductos = rutaResources + @"productos\";
            imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + "default1.png");
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (producto != null)
                {
                    //llenar campos
                    productoText.Text = producto.nombre;
                    referenciaText.Text = producto.referencia;
                    categoria = modeloCategoria.getCategoriaById(producto.codigo_categoria);
                    loadCategoria();
                    subCategoria = modeloSubcategoria.getSubCategoriaById(producto.codigo_subcategoria);
                    loadSubCategoria();
                    puntoMaximoText.Text = producto.punto_maximo.ToString("N");
                    puntoReordenText.Text = producto.reorden.ToString("N");
                    itebis = modeloItebis.getItebisById(producto.codigo_itebis);
                    loadItebis();
                    almacen = modeloAlmacen.getAlmacenById(producto.codigo_almacen);
                    loadAlmacen();
                    unidadMinima = modeloUnidad.getUnidadById(producto.codigo_unidad_minima);
                    loadUnidad();
                    if (producto.imagen != "")
                    {
                        rutaImagenText.Text = rutaImagenesProductos + producto.imagen;
                        imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + producto.imagen);
                    }
                    else
                    {
                        imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + "default1.png");
                    }
                    activoCheck.Checked = Convert.ToBoolean(producto.activo);
                }
                else
                {
                    //blanquear campos
                    productoText.Text = "";
                    referenciaText.Text = "";
                    categoria = null;
                    categoriaIdText.Text = "";
                    categoriaText.Text = "";
                    subCategoria = null;
                    subcategoriaIdText.Text = "";
                    subCategoriaText.Text = "";
                    puntoMaximoText.Text = "";
                    puntoReordenText.Text = "";
                    itebis = null;
                    loadItebis();
                    almacen = null;
                    loadAlmacen();
                    unidadMinima = null;
                    loadUnidad();
                    rutaImagenText.Text = "";
                    imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + "default1.png");
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_producto_Load(object sender, EventArgs e)
        {

        }
     
      
        public void loadItebis()
        {
            try
            {
                if (itebis == null)
                {
                    itebisIdText.Text = "";
                    itebisText.Text = "";
                    return;
                }
                itebisIdText.Text = itebis.codigo.ToString();
                itebisText.Text = itebis.nombre;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadItebis.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar itebis
                if (itebis==null)
                {
                    MessageBox.Show("Falta el itbis", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    itebisIdText.Focus();
                    itebisIdText.SelectAll();
                    return false;
                }
                //validar almacen
                if (almacen == null)
                {
                    MessageBox.Show("Falta el almacen", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    almacenIdText.Focus();
                    almacenIdText.SelectAll();
                    return false;
                }
                //validar punto maximo
                if (puntoMaximoText.Text == "")
                {
                    MessageBox.Show("Falta el punto maximo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    puntoMaximoText.Focus();
                    puntoMaximoText.SelectAll();
                    return false;
                }
                //validar punto reorden
                if (puntoReordenText.Text == "")
                {
                    MessageBox.Show("Falta el punto de reorden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    puntoReordenText.Focus();
                    puntoReordenText.SelectAll();
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

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (!validarGetAction())
                {
                    return;
                }


                bool crear = false;
                if (producto == null)
                {
                    //agrega
                    crear = true;
                    producto = new producto();
                    producto.codigo = modeloProducto.getNext();
                }
                producto.nombre =productoText.Text;
                producto.referencia = referenciaText.Text;
                producto.activo = Convert.ToBoolean(activoCheck.Checked);
                producto.codigo_categoria = categoria.codigo;
                producto.codigo_subcategoria = subCategoria.codigo;
                producto.punto_maximo = Convert.ToDecimal(puntoMaximoText.Text);
                producto.reorden = Convert.ToDecimal(puntoReordenText.Text);
                producto.codigo_itebis = itebis.codigo;
                producto.codigo_almacen = almacen.codigo;
                producto.codigo_unidad_minima = unidadMinima.codigo;
                if (rutaImagenText.Text != "")
                {
                    producto.imagen = rutaImagenText.Text;
                }
                else
                {
                    producto.imagen = "";
                }
                if (crear)
                {
                    //agrega
                    if (modeloProducto.agregarProducto(producto) == true)
                    {
                        producto = null;
                        loadVentana();
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        producto = null;
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloProducto.modificarProducto(producto) == true)
                    {
                        producto = null;
                        loadVentana();
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                producto = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ventana_busqueda_itbis ventana = new ventana_busqueda_itbis();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                itebis = ventana.getObjeto();
                loadItebis();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,puntoMaximoText.Text);
        }

        private void puntoReordenText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, puntoReordenText.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rutaImagenText.Text = file.FileName;
                    imagenProducto.BackgroundImage = Image.FromFile(rutaImagenText.Text);
                }
            }
            catch (Exception)
            {
                rutaImagenText.Text = "";
                imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + "default1.png");
                MessageBox.Show("Debe seleccionar una imagen", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea eliminar la foto del empleado?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                rutaImagenText.Text = "";
                imagenProducto.BackgroundImage = Image.FromFile(rutaImagenesProductos + @"default1.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadAlmacen()
        {
            try
            {
                if (almacen == null)
                {
                    almacenIdText.Text = "";
                    almacenText.Text = "";
                    return;
                }
                almacenIdText.Text = almacen.codigo.ToString();
                almacenText.Text = almacen.nombre;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadAlmacen.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ventana_busqueda_almacen ventana = new ventana_busqueda_almacen();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                almacen = ventana.getObjeto();
                loadAlmacen();
            }
        }
        public void loadUnidad()
        {
            try
            {
                if (unidadMinima == null)
                {
                    unidadMinimaIdText.Text = "";
                    unidadMinimaText.Text = "";
                    return;
                }
                unidadMinimaIdText.Text = unidadMinima.codigo.ToString();
                unidadMinimaText.Text = unidadMinima.nombre;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadAlmacen.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            ventana_busqueda_unidad ventana = new ventana_busqueda_unidad();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                unidadMinima = ventana.getObjeto();
                loadUnidad();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            producto = null;
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_categoria_producto ventana = new ventana_busqueda_categoria_producto();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                categoria = ventana.getObjeto();
                loadCategoria();
            }
        }
        public void loadCategoria()
        {
            try
            {
                if (categoria != null)
                {
                    categoriaIdText.Text = categoria.codigo.ToString();
                    categoriaText.Text = categoria.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadSubCategoria()
        {
            try
            {
                if (subCategoria != null)
                {
                    subcategoriaIdText.Text = subCategoria.codigo.ToString();
                    subCategoriaText.Text = subCategoria.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSubCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (categoria == null)
            {
                MessageBox.Show("Falta la categoria", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoriaIdText.Focus();
                categoriaIdText.SelectAll();
                return;
            }
            ventana_busqueda_subcategoria_producto ventana = new ventana_busqueda_subcategoria_producto(categoria.codigo);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                subCategoria = ventana.getObjeto();
                loadSubCategoria();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_producto ventana = new ventana_busqueda_producto(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                producto = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
