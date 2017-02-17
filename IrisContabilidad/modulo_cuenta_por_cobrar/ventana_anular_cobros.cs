using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CtpGglTranslate.Ggl;
using CtpGglTranslate.Impl;
using GoogleApi;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;
using GoogleApi.Entities.Translate;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_anular_cobros : formBase
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
        modeloCobro modeloCobro=new modeloCobro();
        modeloMetodoPago modeloMetodoPago=new modeloMetodoPago();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        

        //listas
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;

        //variables


        public ventana_anular_cobros()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana anular cobros");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        
        public void loadVentana()
        {
            try
            {
                clienteIdText.Focus();
                clienteIdText.SelectAll();


                cliente = null;
                clienteIdText.Text = "";
                clienteText.Text = "";
                motivoAnularText.Text = "";
                dataGridView1.Rows.Clear();
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
                //validar que tenga motivo porque anular
                if (motivoAnularText.Text == "")
                {
                    motivoAnularText.Focus();
                    motivoAnularText.SelectAll();
                    MessageBox.Show("Debe especificar el motivo porque desea anular los cobros", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void loadCliente()
        {
            try
            {
                clienteIdText.Text = "";
                clienteText.Text = "";
                if (cliente != null)
                {
                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteText.Text = cliente.nombre;
                    loadCobros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    venta=new venta();
                    venta = modeloVenta.getVentaById(x.codigo_venta);
                    ventaCobro=new venta_vs_cobros();
                    ventaCobro = modeloVenta.getVentaCobroById(x.codigo_cobro);
                    empleado = new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(ventaCobro.cod_empleado);
                    metodoPago =modeloMetodoPago.getMetodoPagoById(x.codigo_metodo_cobro);
                    dataGridView1.Rows.Add(x.codigo,utilidades.getFechaddMMyyyy(ventaCobro.fecha),empleado.nombre,metodoPago.metodo,venta.numero_factura);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCobros.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_anular_cobros_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana = new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
           
        }

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    motivoAnularText.Focus();
                    motivoAnularText.SelectAll();

                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    loadCliente();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea anular los cobros?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                getAction();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
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
                    dataGridView1.Rows[fila].Cells[5].Value = !Convert.ToBoolean(dataGridView1.Rows[fila].Cells[5].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
