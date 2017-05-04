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

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_anular_pagos : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private compra compra;
        private compra_detalle compraDetalle;
        private compra_vs_pagos compraPago;
        private compra_vs_pagos_detalles compraPagoDetalle;
        private suplidor suplidor;
        private metodo_pago metodoPago;

        //modelos
        modeloCompra modeloCompra = new modeloCompra();
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloPago modeloPago = new modeloPago();
        modeloMetodoPago modeloMetodoPago = new modeloMetodoPago();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<compra_vs_pagos_detalles> listaVentacobroDetalle;
        private List<compra> listaCompra;
        private List<compra_detalle> listaCompraDetalle;

        //variables


        public ventana_anular_pagos()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana anular pagos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                suplidorIdText.Focus();
                suplidorIdText.SelectAll();


                suplidor = null;
                suplidorIdText.Text = "";
                suplidorText.Text = "";
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
                if (suplidor == null)
                {
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un suplidor", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar que hayan datos en el grid
                if (dataGridView1.Rows.Count == 0)
                {
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();
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
                        string sql = "update compra_vs_pagos_detalles set activo='0' where codigo='" + row.Cells[0].Value.ToString() + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                        sql = "update compra set pagada=0 where codigo ='" + row.Cells[4] + "'";
                        utilidades.ejecutarcomando_mysql(sql);
                    }
                }
                MessageBox.Show("Se eliminaron los pagos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadPagos();
            }
            catch (Exception ex)
            {
                compra = null;
                compraPago = null;
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

        public void loadSuplidor()
        {
            try
            {
                suplidorIdText.Text = "";
                suplidorText.Text = "";
                if (suplidor != null)
                {
                    suplidorIdText.Text = suplidor.codigo.ToString();
                    suplidorText.Text = suplidor.nombre;
                    loadPagos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadPagos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                listaVentacobroDetalle = modeloPago.getListaPagosDetallesActivosBySuplidorId(suplidor.codigo);
                listaVentacobroDetalle.ForEach(x =>
                {
                    compra = new compra();
                    compra = modeloCompra.getCompraById(x.codigo_compra);
                    compraPago = new compra_vs_pagos();
                    compraPago = modeloCompra.getCompraPagoById(x.codigo_pago);
                    empleado = new empleado();
                    empleado = modeloEmpleado.getEmpleadoById(compraPago.cod_empleado);
                    metodoPago = modeloMetodoPago.getMetodoPagoById(x.codigo_metodo_pago);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(compraPago.fecha), empleado.nombre, metodoPago.metodo, compra.numero_factura);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadPagos.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_anular_pagos_Load(object sender, EventArgs e)
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

        private void clienteIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    motivoAnularText.Focus();
                    motivoAnularText.SelectAll();

                    suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(suplidorIdText.Text));
                    loadSuplidor();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana = new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea anular los pagos?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                getAction();
            }
        }


    }
}
