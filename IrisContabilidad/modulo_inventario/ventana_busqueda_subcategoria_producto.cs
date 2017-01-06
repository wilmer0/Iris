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
    public partial class ventana_busqueda_subcategoria_producto : formBase
    {
        //objetos
        private subCategoriaProducto subCategoria;

        //listas
        private List<subCategoriaProducto> listaSubCategoria;

        //modelos
        modeloSubCategoriaProducto modeloSubCategoria = new modeloSubCategoriaProducto();

        //variables 
        public int codigoCategoria=0;
        public bool mantenimiento = false;
        private int fila = 0;


        public ventana_busqueda_subcategoria_producto(bool mantenimiento=false)
        {
            InitializeComponent();
            this.tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        //para buscar subcategoria de una categoria en especifico
        public ventana_busqueda_subcategoria_producto(int codigoCategoria)
        {
            InitializeComponent();
            this.tituloLabel.Text = this.Text;
            this.codigoCategoria = codigoCategoria;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaSubCategoria == null)
                {
                    listaSubCategoria = new List<subCategoriaProducto>();
                    listaSubCategoria = modeloSubCategoria.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //si codigo categoria es diferente de cero entonces que filtre por dicho codigo de categoria
                if (codigoCategoria != 0)
                {
                    listaSubCategoria.Where(x => x.codigo_categoria == codigoCategoria);
                }
                //se agrega todos los datos de la lista en el gridView
                listaSubCategoria.ForEach(x =>
                {
                    subCategoria = new subCategoriaProducto();
                    subCategoria = modeloSubCategoria.getSubCategoriaById(x.codigo);
                    dataGridView1.Rows.Add(x.codigo, x.nombre, x.activo);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public subCategoriaProducto getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                subCategoria = modeloSubCategoria.getSubCategoriaById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return subCategoria;
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
        private void ventana_busqueda_subcategoria_producto_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaSubCategoria = modeloSubCategoria.getListaCompleta();
                    listaSubCategoria = listaSubCategoria.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listaSubCategoria = null;
            loadLista();
        }
    }
}
