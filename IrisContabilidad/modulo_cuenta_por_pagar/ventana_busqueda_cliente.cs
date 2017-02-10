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

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_busqueda_cliente : formBase
    {

        //objetos
        private cliente cliente;
        private categoria_cliente categoria;

        
        
        //listas
        private List<cliente> listaCliente;

        
        
        //modelos
        private modeloCliente modeloCliente = new modeloCliente();
        modeloCategoriaCliente modeloCategoria=new modeloCategoriaCliente();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int index = 0;

        public ventana_busqueda_cliente(bool mantenimiento=false)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaCliente == null)
                {
                    listaCliente = new List<cliente>();
                    listaCliente = modeloCliente.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCliente.ForEach(x =>
                {
                    string nombreCategoria = "";
                    categoria = modeloCategoria.getCategoriaClienteById(x.codigo_categoria);
                    if (categoria != null)
                    {
                        nombreCategoria = categoria.nombre;
                    }
                    dataGridView1.Rows.Add(x.codigo, x.nombre,x.cedula,x.rnc,nombreCategoria,(x.telefono1+"--"+x.telefono2), x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cliente getObjeto()
        {
            try
            {
                //validar que tenga datos el datagrid
                if (dataGridView1.Rows.Count < 0)
                {
                    return null;
                }
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                cliente = modeloCliente.getClienteById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return cliente;
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
        private void ventana_busqueda_cliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void ventana_busqueda_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                getAction();
            }
            if (e.KeyCode == Keys.F2)
            {
                button3_Click(null, null);
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaCliente = modeloCliente.getListaCompleta();
                    //por nombre
                    if (radioButtonNombre.Checked==true)
                    {
                        listaCliente = listaCliente.FindAll(x => x.nombre.ToLower().Contains(nombreText.Text.ToLower()));
                    }
                    //por cedula
                    if (radioButtonCedula.Checked == true)
                    {
                        listaCliente = listaCliente.FindAll(x => x.cedula.Contains(nombreText.Text));
                    }
                    //por rnc
                    if (radioButtonRnc.Checked == true)
                    {
                        listaCliente = listaCliente.FindAll(x => x.rnc.Contains(nombreText.Text));
                    }
                    //categoria
                    if (radioButtonCatgoria.Checked == true)
                    {
                        index = 0;
                        List<cliente> listaTemporal=new List<cliente>();
                        listaTemporal = listaCliente;
                        listaTemporal.ForEach(x =>
                        {
                            categoria = modeloCategoria.getCategoriaClienteById(x.codigo_categoria);
                            if (categoria != null)
                            {
                                if (!categoria.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                                {
                                    //si no contiene el nombre de la categoria escrita se borrara de la lista principal
                                    listaCliente.RemoveAt(index);
                                }
                            }
                            index++;
                        });
                    }
                    //telefono
                    if (radioButtonTelefono.Checked == true)
                    {
                        listaCliente = listaCliente.FindAll(x => x.telefono1.Contains(nombreText.Text) || x.telefono2.Contains(nombreText.Text));
                    }
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaCliente = null;
            loadLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }
    }
}
