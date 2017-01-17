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

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_subcategoria_producto : formBase
    {
        //objetos
        private subCategoriaProducto subCategoria;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private categoria_producto categoria;


        //modelos
        modeloCategoriaProducto modeloCategoria = new modeloCategoriaProducto();
        modeloSubCategoriaProducto modeloSubCategoria=new modeloSubCategoriaProducto();

        public ventana_subcategoria_producto()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "subcategoria producto");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (subCategoria != null)
                {
                    categoria = modeloCategoria.getCategoriaById(subCategoria.codigo_categoria);
                    loadCategoria();
                    categoriaIdText.Text = categoria.codigo.ToString();
                    CategoriaText.Text = categoria.nombre;
                    nombreText.Text = subCategoria.nombre;
                    activoCheck.Checked = Convert.ToBoolean(subCategoria.activo);
                }
                else
                {
                    subCategoria = null;
                    categoria = null;
                    categoriaIdText.Text = "";
                    CategoriaText.Text = "";
                    nombreText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarGetAction()
        {
            try
            {

                //categoria
                if (categoria == null)
                {
                    MessageBox.Show("Falta la categoria ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    categoriaIdText.Focus();
                    categoriaIdText.SelectAll();
                    return false;
                }

                //nombre
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                categoria = null;
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!ValidarGetAction())
                {
                    return;
                }
                bool crear = false;
                if (subCategoria == null)
                {
                    //agrega
                    crear = true;
                    subCategoria = new subCategoriaProducto();
                    subCategoria.codigo = modeloSubCategoria.getNext();
                }
                subCategoria.codigo_categoria = categoria.codigo;
                subCategoria.nombre = nombreText.Text;
                subCategoria.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloSubCategoria.agregarSubCategoria(subCategoria) == true)
                    {
                        subCategoria = null;
                        loadVentana();
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        subCategoria = null;
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloSubCategoria.modificarSubCategoria(subCategoria) == true)
                    {
                        subCategoria = null;
                        loadVentana();
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                categoria = null;
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
        private void ventana_subcategoria_producto_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_TextChanged(object sender, EventArgs e)
        {

        }

        private void activoCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void loadCategoria()
        {
            try
            {
                if (categoria != null)
                {
                    categoriaIdText.Text = categoria.codigo.ToString();
                    CategoriaText.Text = categoria.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            subCategoria = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_subcategoria_producto ventana = new ventana_busqueda_subcategoria_producto(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                subCategoria = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
