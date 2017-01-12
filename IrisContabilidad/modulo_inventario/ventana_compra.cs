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

        //modelos
        private modeloItebis modeloItebis = new modeloItebis();
        private modeloUnidad modeloUnidad = new modeloUnidad();
        private modeloAlmacen modeloAlmacen = new modeloAlmacen();
        private modeloProducto modeloProducto = new modeloProducto();
        
        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<producto_vs_codigobarra> listaCodigoBarra;
        private List<productoUnidadConversion> listaProductoUnidadConversion; 



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
                    //llenar campos

                }
                else
                {
                    //blanquear campos

                    suplidorInformalCheck.Checked = false;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
