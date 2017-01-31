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
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_compra_pagos : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private compra compra;
        private compra_detalle compraDetalle;
        private producto producto;
        private itebis itebis;
        private unidad unidad;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;
        private productoUnidadConversion productoUnidadConversion;
        private suplidor suplidor;
        private ventana_desglose_dinero ventanaDesglose;


        //modelos
        private modeloItebis modeloItebis = new modeloItebis();
        private modeloUnidad modeloUnidad = new modeloUnidad();
        private modeloAlmacen modeloAlmacen = new modeloAlmacen();
        private modeloProducto modeloProducto = new modeloProducto();
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloCompra modeloCompra = new modeloCompra();


        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private decimal totalItebisMonto = 0;
        private decimal totalCompraMonto = 0;

        //listas
        private List<producto_vs_codigobarra> listaCodigoBarra;
        private List<productoUnidadConversion> listaProductoUnidadConversion;
        private List<compra> listaCompra;
        private List<compra_detalle> listaCompraDetalle;
        private List<unidad> listaUnidad;


        //variables
        private decimal cantidad_monto = 0;
        private decimal precio_monto = 0;
        private decimal importe_monto = 0;
        private decimal descuento_monto = 0;
        private decimal descuento_porciento = 0;
        private decimal itebis_monto = 0;


        public ventana_compra_pagos()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana compra pagos");
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
                  
                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                if (!validarGetAcion())
                {
                    return;
                }

               
            }
            catch (Exception ex)
            {
                compra = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void agregarProducto()
        {
            try
            {
                //validaciones

               

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarUnidadConversion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void calcularTotal()
        {
            try
            {
                //if (dataGridView1.Rows.Count <= 0)
                //{
                //    totalItebisText.Text = "0.00";
                //    totalCompraText.Text = "0.00";
                //    return;
                //}

                //totalItebisMonto = 0;
                //totalCompraMonto = 0;


                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    totalItebisMonto += Convert.ToDecimal(row.Cells[6].Value.ToString());
                //    totalCompraMonto = Convert.ToDecimal(row.Cells[8].Value.ToString());
                //}
                //totalItebisText.Text = totalItebisMonto.ToString("N");
                //totalCompraText.Text = totalCompraMonto.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calcularTotal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void eliminarProducto()
        {
            try
            {
                //validar que tenga filas el datagrid
                if (dataGridView1 == null || dataGridView1.Rows.Count < 0)
                {
                    return;
                }
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                if (fila >= 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[fila]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminarProducto.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_compra_pagos_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            suplidor = null;
            loadVentana();
        }
    }
}
