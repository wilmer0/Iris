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
    public partial class ventana_seleccion_producto_unidad_precio : formBase
    {


        //objetos
        private producto producto;
        private unidad unidad;
        private empleado empleado;
        utilidades utilidades=new utilidades();


        //variables
        private int fila = 0;
        private decimal precio = 0;

        //modelos
        modeloProducto modeloProducto=new modeloProducto();
        modeloUnidad modeloUnidad=new modeloUnidad();
        

        //listas
        private List<producto_precio_venta> listaPrecioProducto;
 



        public ventana_seleccion_producto_unidad_precio(int codigoProducto,int codigoUnidad)
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "selección precio de venta");
            this.Text = tituloLabel.Text;
            this.producto = modeloProducto.getProductoById(codigoProducto);
            this.unidad = modeloUnidad.getUnidadById(codigoUnidad);
            loadVentana();
        }

        public void loadVentana()
        {
            try
            {
                listaPrecioProducto=new List<producto_precio_venta>();
                listaPrecioProducto = modeloProducto.getListaPrecioProductoUnidad(producto.codigo, unidad.codigo).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        public void loadLista()
        {
            try
            {
                if (listaPrecioProducto == null)
                {
                    MessageBox.Show("Este producto no tiene precio de venta", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                dataGridView1.Rows.Clear();
                listaPrecioProducto = listaPrecioProducto.Distinct().ToList();
                listaPrecioProducto.ForEach(x =>
                {
                    dataGridView1.Rows.Add(producto.nombre, unidad.nombre, x.precio_venta1);
                    dataGridView1.Rows.Add(producto.nombre, unidad.nombre, x.precio_venta2);
                    dataGridView1.Rows.Add(producto.nombre, unidad.nombre, x.precio_venta3);
                    dataGridView1.Rows.Add(producto.nombre, unidad.nombre, x.precio_venta4);
                    dataGridView1.Rows.Add(producto.nombre, unidad.nombre, x.precio_venta5);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ventana_seleccion_producto_unidad_precio_Load(object sender, EventArgs e)
        {

        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public bool validarGetAcion()
        {
            try
            {
                //que tenga una fila seleccionada
                fila = dataGridView1.CurrentRow.Index;
                if (fila < 0)
                {
                    MessageBox.Show("No ha seleccionado ningun precio", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

               
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

                precio = Convert.ToDecimal(dataGridView1.Rows[fila].Cells[2].Value.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaPrecioProducto = null;
            loadVentana();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }
    }
}
