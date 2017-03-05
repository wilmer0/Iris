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
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_reporte_cobros : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private venta venta;
        private venta_detalle VentaDetalle;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobroDetalle;
        private cliente cliente;
        private metodo_pago metodoPago;

        //modelos
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCobro modeloCobro = new modeloCobro();
        modeloMetodoPago modeloMetodoPago = new modeloMetodoPago();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;

        //variables


        public ventana_reporte_cobros()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana reporte cobros");
            this.Text = tituloLabel.Text;
            loadVentana();
            loadListaVentaCobros();
        }

        public void loadListaVentaCobros()
        {
            try
            {
                listaVenta=new List<venta>();
                listaVentaDetalle=new List<venta_detalle>();
                listaVentacobroDetalle = new List<venta_vs_cobros_detalles>();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadListaVentaCobros.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void loadVentana()
        {
            try
            {
                cliente = null;
                venta = null;
                tipoVentaComboBox.Text = "";
                checkBoxIncluirRangoFechaVenta.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCobros()
        {
            try
            {
                dataGridView1.Rows.Clear();
                listaVentacobroDetalle = modeloCobro.getListaCobrosDetallesActivosByClienteId(cliente.codigo);
                listaVentacobroDetalle.ForEach(x =>
                {
                    venta = new venta();
                    venta = modeloVenta.getVentaById(x.codigo_venta);
                    ventaCobro = new venta_vs_cobros();
                    ventaCobro = modeloVenta.getVentaCobroById(x.codigo_cobro);
                    empleado = new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(ventaCobro.cod_empleado);
                    metodoPago = modeloMetodoPago.getMetodoPagoById(x.codigo_metodo_cobro);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(ventaCobro.fecha), empleado.nombre, metodoPago.metodo, venta.numero_factura);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCobros.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {
                //validar que el cliente no sea nulo
                if (cliente == null)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar que hayan datos en el grid
                if (dataGridView1.Rows.Count == 0)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("No hay facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                //validar que tenga cobros seleccionado
                existe = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[5].Value) == true)
                    {
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    MessageBox.Show("No hay cobros seleccionado para anular", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[5].Value) == true)
                    {
                        string sql = "update venta_vs_cobros_detalles set activo='0' where codigo='" + row.Cells[0].Value.ToString() + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                        sql = "update venta set pagada=0 where codigo ='" + row.Cells[4] + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                    }
                }
                MessageBox.Show("Se eliminaron los cobros", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCobros();
            }
            catch (Exception ex)
            {
                venta = null;
                ventaCobro = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_reporte_cobros_Load(object sender, EventArgs e)
        {

        }

        public void loadCliente()
        {
            try
            {
                clienteIdText.Text = "";
                clienteLabel.Text = "";
                if (cliente != null)
                {
                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteLabel.Text = cliente.nombre;
                }
            }
            catch (Exception)
            {
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana=new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
