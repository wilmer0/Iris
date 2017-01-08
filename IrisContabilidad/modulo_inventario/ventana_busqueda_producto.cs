﻿using System;
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
        private List<producto> listaProductoFiltrada; 


        //modelos
        private modeloProducto modeloProducto = new modeloProducto();
        modeloSucursal modeloSucursal = new modeloSucursal();
        modeloCategoriaProducto modeloCategoria=new modeloCategoriaProducto();
        modeloSubCategoriaProducto modeloSubCategoria=new modeloSubCategoriaProducto();
        modeloAlmacen modeloAlmacen=new modeloAlmacen();
        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



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
                if (listaProductoFiltrada == null)
                {
                    listaProductoFiltrada = new List<producto>();
                }
                listaProductoFiltrada = listaProducto.ToList();
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaProductoFiltrada.ForEach(x =>
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
            listaProductoFiltrada = null;
            loadLista();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaProductoFiltrada = modeloProducto.getListaCompleta();


                    //nombre
                    if (nombreRadioButton.Checked == true)
                    {
                        listaProductoFiltrada = listaProducto.FindAll(x => x.nombre.Contains(nombreText.Text));
                    }
                    //referencia
                    if (referenciaRadioButton.Checked == true)
                    {
                        listaProductoFiltrada = listaProducto.FindAll(x => x.referencia.Contains(nombreText.Text));
                    }
                    //categoria
                    if (categoriaRadionButton.Checked == true)
                    {
                        categoria=new categoria_producto();
                        //seleccionando el primero que me trae la lista
                        categoria = modeloCategoria.getListaByNombre(nombreText.Text).FirstOrDefault();
                        if (categoria != null)
                        {
                            listaProductoFiltrada = listaProducto.FindAll(x => x.codigo_categoria == categoria.codigo);
                        }
                    }
                    //subcategoria
                    if (subCategoriaRadionButton.Checked == true)
                    {
                        subCategoria = new subCategoriaProducto();
                        //seleccionando el primero que me trae la lista
                        subCategoria = modeloSubCategoria.getListaByNombre(nombreText.Text).FirstOrDefault();
                        if (subCategoria != null)
                        {
                            listaProductoFiltrada = listaProducto.FindAll(x => x.codigo_subcategoria == subCategoria.codigo);
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
                            listaProductoFiltrada =listaProducto.FindAll(x => x.codigo_subcategoria == subCategoria.codigo);
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