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
    public partial class ventana_busqueda_producto : formBase
    {

        //objetos
        private producto producto;
        private sucursal sucursal;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;
        private almacen almacen;

        //listas
        private List<producto> listaProducto;
        private List<producto> listaTemporal; 


        //modelos
        private modeloProducto modeloProducto = new modeloProducto();
        modeloSucursal modeloSucursal = new modeloSucursal();
        modeloCategoriaProducto modeloCategoria=new modeloCategoriaProducto();
        modeloSubCategoriaProducto modeloSubCategoria=new modeloSubCategoriaProducto();
        modeloAlmacen modeloAlmacen=new modeloAlmacen();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        private int index = 0;


        public ventana_busqueda_producto(bool mantenimiento=false)
        {
            InitializeComponent();
            this.tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaProducto == null)
                {
                    listaProducto = new List<producto>();
                    listaProducto = modeloProducto.getListaCompleta(mantenimiento);
                }
                if (listaProducto == null)
                {
                    listaProducto = new List<producto>();
                }
                listaProducto = listaProducto.ToList();
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaProducto.ForEach(x =>
                {
                    producto = new producto();
                    producto = modeloProducto.getProductoById(x.codigo);
                    categoria=new categoria_producto();
                    subCategoria=new subCategoriaProducto();
                    categoria = modeloCategoria.getCategoriaById(x.codigo_categoria);
                    subCategoria = modeloSubCategoria.getSubCategoriaById(x.codigo_subcategoria);
                    dataGridView1.Rows.Add(x.codigo, x.nombre,x.referencia,categoria.nombre,subCategoria.nombre, x.activo);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public producto getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                producto = modeloProducto.getProductoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void getAction()
        {
            this.DialogResult = DialogResult.OK;
            getObjeto();
            this.Close();
        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }
        private void ventana_busqueda_producto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaProducto = null;
            loadLista();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaProducto = modeloProducto.getListaCompleta();
                    listaTemporal = new List<producto>();
                    if (listaProducto.Count > 0)
                    {
                        listaTemporal = listaProducto;
                    }
                    else
                    {
                        listaTemporal = modeloProducto.getListaCompleta();
                    }
                    //nombre
                    if (nombreRadioButton.Checked == true)
                    {
                        listaProducto = listaProducto.FindAll(x => x.nombre.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //referencia
                    if (referenciaRadioButton.Checked == true)
                    {
                        listaProducto = listaProducto.FindAll(x => x.referencia.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //categoria
                    if (categoriaRadionButton.Checked == true)
                    {
                            index = 0;
                            categoria = modeloCategoria.getCategoriaByNombre(nombreText.Text);
                            if (categoria != null)
                            {
                                foreach (var x in listaTemporal)
                                {
                                    if (!categoria.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                                    {
                                        //si no contiene el nombre de la categoria escrita se borrara de la lista principal
                                        listaProducto.RemoveAt(index);
                                    }
                                }
                                index++;
                            }
                        
                    }
                    //subcategoria
                    if (subCategoriaRadionButton.Checked == true)
                    {
                        index = 0;
                        foreach (var x in listaTemporal)
                        {
                            subCategoria = modeloSubCategoria.getSubCategoriaById(x.codigo_subcategoria);
                            if (subCategoria != null)
                            {
                                if (!subCategoria.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                                {
                                    //si no contiene el nombre de la categoria escrita se borrara de la lista principal
                                    try
                                    {
                                        listaProducto.RemoveAt(index);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                            index++;
                        }
                    }
                    //almacen
                    if (almacenRadionButton.Checked == true)
                    {
                        almacen = new almacen();
                        //seleccionando el primero que me trae la lista
                        almacen = modeloAlmacen.getListaByNombre(nombreText.Text).FirstOrDefault();
                        if (almacen != null)
                        {
                            listaProducto =listaProducto.FindAll(x => x.codigo_subcategoria == subCategoria.codigo);
                        }
                    }
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
    }
}
