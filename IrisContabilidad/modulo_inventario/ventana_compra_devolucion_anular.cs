using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_compra_devolucion_anular : formBase
    {
        //objetos
        private compra compra;
        private compraDevolucion devolucion;
        private empleado empleado;
        private suplidor suplidor;
        utilidades utilidades = new utilidades();


        //listas
        private List<compraDevolucion> listacompraDevolucion;


        //modelos
        private modeloCompraDevolucion modelocompraDevolucion = new modeloCompraDevolucion();
        modeloCompra modeloCompra = new modeloCompra();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloSuplidor modeloSuplidor = new modeloSuplidor();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



        public ventana_compra_devolucion_anular(bool mantenimiento = false)
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
                if (listacompraDevolucion == null)
                {
                    listacompraDevolucion=new List<compraDevolucion>();
                    listacompraDevolucion = modelocompraDevolucion.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listacompraDevolucion.ForEach(x =>
                {
                    compra = modeloCompra.getCompraById(x.codigo_compra);
                    suplidor = modeloSuplidor.getSuplidorById(compra.cod_suplidor);
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), x.codigo_compra, suplidor.nombre, empleado.nombre, compra.tipo_compra);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public compraDevolucion getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                devolucion = modelocompraDevolucion.getDevolucionById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
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
            if ((modelocompraDevolucion.anularDevolucion(id)) == true)
            {
                listacompraDevolucion = null;
                loadLista();
                MessageBox.Show("Se anuló la devolució de venta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listacompraDevolucion = null;
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
                listacompraDevolucion = new List<compraDevolucion>();
                listacompraDevolucion = modelocompraDevolucion.getListaCompleta();

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
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => x.codigo == id);
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
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => x.fecha <= fecha);
                }
                //ID compra
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
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => x.codigo_compra == id);
                }
                //suplidor
                if (radioButtonCliente.Checked == true)
                {
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => (suplidor = modeloSuplidor.getSuplidorById((compra = modeloCompra.getCompraById(x.codigo_compra)).cod_suplidor)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                }
                //empleado
                if (radioButtonEmpleado.Checked == true)
                {
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => (empleado = modeloEmpleado.getEmpleadoById((compra = modeloCompra.getCompraById(x.codigo_empleado)).codigo_empleado)).nombre.ToLower().Contains(nombreText.Text.ToLower())).ToList();
                }
                //tipo compra
                if (radioButtonTipoVenta.Checked == true)
                {
                    listacompraDevolucion = listacompraDevolucion.FindAll(x => nombreText.Text.ToLower().Contains((compra=modeloCompra.getCompraById(x.codigo_compra)).tipo_compra.ToLower()));
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
            listacompraDevolucion = null;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
