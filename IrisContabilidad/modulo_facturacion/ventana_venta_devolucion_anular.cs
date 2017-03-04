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
    public partial class ventana_venta_devolucion_anular : formBase
    {
        //objetos
        private venta venta;
        private ventaDevolucion devolucion;
        private empleado empleado;
        private cliente cliente;
        utilidades utilidades = new utilidades();


        //listas
        private List<ventaDevolucion> listaVentaDevolucion;


        //modelos
        private modeloVentaDevolucion modeloVentaDevolucion = new modeloVentaDevolucion();
        modeloVenta modeloVenta = new modeloVenta();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCliente modeloCliente = new modeloCliente();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



        public ventana_venta_devolucion_anular()
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
                if (listaVentaDevolucion == null)
                {
                    listaVentaDevolucion=new List<ventaDevolucion>();
                    listaVentaDevolucion = modeloVentaDevolucion.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaVentaDevolucion.ForEach(x =>
                {
                    venta = modeloVenta.getVentaById(x.codigo_venta);
                    cliente = modeloCliente.getClienteById(venta.codigo_cliente);
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), x.codigo_venta, cliente.nombre, empleado.nombre, venta.tipo_venta);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ventaDevolucion getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                devolucion = modeloVentaDevolucion.getDevolucionById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return devolucion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool validarGetAction()
        {
            try
            {
                if (dataGridView1.Rows.Count < 0)
                {
                    MessageBox.Show("Debe seleccionar una devolución para poder anular", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void getAction()
        {
            if (validarGetAction() == false)
            {
                return;
            }

            if (MessageBox.Show("Desea anular la devolución?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            fila = dataGridView1.CurrentRow.Index;
            int id = Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString());
            if ((modeloVentaDevolucion.anularDevolucion(id)) == true)
            {
                listaVentaDevolucion = null;
                loadLista();
                MessageBox.Show("Se anuló la devolució de venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listaVentaDevolucion = null;
                loadLista();
            }
        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void filtrar()
        {
            try
            {
                listaVentaDevolucion = new List<ventaDevolucion>();
                listaVentaDevolucion = modeloVentaDevolucion.getListaCompleta();

                //por id
                if (radioButtonID.Checked == true)
                {
                    int id;
                    if (int.TryParse(nombreText.Text, out id) == false)
                    {
                        MessageBox.Show("Formato de número no es correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nombreText.Focus();
                        nombreText.SelectAll();
                        return;
                    }
                    id = Convert.ToInt16(nombreText.Text);
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => x.codigo == id);
                }
                //por fecha
                if (radioButtonFecha.Checked == true)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(nombreText.Text, out fecha) == false)
                    {
                        MessageBox.Show("Formato de fecha no es correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nombreText.Focus();
                        nombreText.SelectAll();
                        return;
                    }
                    fecha = Convert.ToDateTime(nombreText.Text);
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => x.fecha <= fecha);
                }
                //ID Venta
                if (radioButtonIdVenta.Checked == true)
                {
                    int id;
                    if (int.TryParse(nombreText.Text, out id) == false)
                    {
                        MessageBox.Show("Formato de número no es correcto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        nombreText.Focus();
                        nombreText.SelectAll();
                        return;
                    }
                    id = Convert.ToInt16(nombreText.Text);
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => x.codigo_venta == id);
                }
                //Cliente
                if (radioButtonCliente.Checked == true)
                {
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => (cliente = modeloCliente.getClienteById((venta = modeloVenta.getVentaById(x.codigo_venta)).codigo_cliente)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                }
                //empleado
                if (radioButtonEmpleado.Checked == true)
                {
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => (empleado = modeloEmpleado.getEmpleadoById((venta = modeloVenta.getVentaById(x.codigo_empleado)).codigo_empleado)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                }
                //tipo venta
                if (radioButtonTipoVenta.Checked == true)
                {
                    listaVentaDevolucion = listaVentaDevolucion.FindAll(x => nombreText.Text.ToLower().Contains((venta=modeloVenta.getVentaById(x.codigo_venta)).tipo_venta.ToLower()));
                }

                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtrar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_venta_devolucion_anular_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaVentaDevolucion = null;
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
                filtrar();
            }
        }
    }
}
