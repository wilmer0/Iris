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

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_busqueda_cuenta_contable : formBase
    {

        //objetos
        private cuenta_contable cuentaContable;

        //listas
        private List<cuenta_contable> lista;

        //modelos
        private modeloCuentaContable modeloCuentaContable=new modeloCuentaContable();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;


        public ventana_busqueda_cuenta_contable()
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
                if (lista == null)
                {
                    lista = new List<cuenta_contable>();
                    lista = modeloCuentaContable.getListaCompleta();
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                lista.ForEach(x =>
                {
                    cuenta_contable cuantaPadre=new cuenta_contable();
                    if (x.codigo_cuenta_superior != 0)
                    {
                        cuantaPadre = modeloCuentaContable.getCuentaContableById(x.codigo_cuenta_superior);
                    }
                    else
                    {
                        cuantaPadre.nombre = ".";
                        cuantaPadre.numero_cuenta = "0";
                    }
                    dataGridView1.Rows.Add(x.codigo, x.nombre, x.numero_cuenta, cuantaPadre.numero_cuenta,cuantaPadre.nombre);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void buscar()
        {
            try
            {

                lista = modeloCuentaContable.getListaCompleta();
                lista = lista.FindAll(x => x.nombre.ToLower().Contains(nombreText.Text.ToLower()) || x.numero_cuenta.ToLower().Contains(nombreText.Text.ToLower()));
                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        public cuenta_contable getObjeto()
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
                cuentaContable = modeloCuentaContable.getCuentaContableById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return cuentaContable;
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

        private void ventana_busqueda_cuenta_contable_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar();
            }
        }
    }
}
