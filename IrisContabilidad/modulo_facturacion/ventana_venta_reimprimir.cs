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
    public partial class ventana_venta_reimprimir : formBase
    {
        //objetos
        private venta venta;
        private empleado empleado;
        private cliente cliente;
        utilidades utilidades=new utilidades();
        

        //listas
        private List<venta> listaVenta;



        //modelos
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCliente modeloCliente=new modeloCliente();
        modeloVenta modeloVenta=new modeloVenta();
        ModeloReporte modeloReporte=new ModeloReporte();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;



        public ventana_venta_reimprimir()
        {
            InitializeComponent();
            this.Text = "Reimprimir ventas";
            this.tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaVenta == null)
                {
                    listaVenta = new List<venta>();
                    listaVenta = modeloVenta.getListaCompleta();
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaVenta.ForEach(x =>
                {
                    empleado=new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    cliente=new cliente();
                    cliente = modeloCliente.getClienteById(x.codigo_cliente);
                    dataGridView1.Rows.Add(x.codigo,utilidades.getFechaddMMyyyy(x.fecha),x.ncf,empleado.nombre,cliente.nombre,x.tipo_venta);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public venta getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                venta = modeloVenta.getVentaById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return venta;
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
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ventana_venta_reimprimir_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            listaVenta = null;
            loadLista();
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filtrar();
            }
        }
        public void filtrar()
        {
            try
            {
                listaVenta=new List<venta>();
                listaVenta = modeloVenta.getListaCompleta();
                
                //por id venta
                if (radioID.Checked == true)
                {
                    listaVenta =listaVenta.FindAll(x => x.codigo.ToString().ToLower().Contains(nombreText.Text.ToLower())).ToList();
                }
                //por fecha
                if (radioFecha.Checked == true)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(nombreText.Text, out fecha) == false)
                    {
                        return;
                    }
                    fecha = Convert.ToDateTime(nombreText.Text);
                    listaVenta = listaVenta.FindAll(x => x.fecha<=fecha.Date);
                }
                //por empleado
                if (radioEmpleado.Checked == true)
                {
                    listaVenta = listaVenta.FindAll(x => (empleado=modeloEmpleado.getEmpleadoById(x.codigo_empleado)).nombre.ToLower().Contains(nombreText.Text.ToLower()));
                }
                //por ncf
                if (radioNCF.Checked == true)
                {
                    listaVenta = listaVenta.FindAll(x => x.ncf.ToLower().Contains(nombreText.Text.ToLower()));
                }
                //por tipo venta
                if (radioTipoVenta.Checked == true)
                {
                    listaVenta = listaVenta.FindAll(x => nombreText.Text.ToLower().Contains(x.tipo_venta.ToLower()));
                }
                loadLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                modeloReporte.imprimirVenta(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Reimprimiendo.: " + ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          
        }
    }
}
