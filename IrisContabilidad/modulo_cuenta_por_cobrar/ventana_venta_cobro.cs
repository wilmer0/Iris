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

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_venta_cobro : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private venta venta;
        private venta_detalle ventaDetalle;
        private ventana_desglose_dinero ventanaDesglose;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobroDetalle;
        private cliente cliente;

        //modelos
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();
        private modeloEmpleado modeloEmpleado = new modeloEmpleado();
        ModeloReporte modeloReporte = new ModeloReporte();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private decimal totalPendienteMonto = 0;
        private decimal totalCobradoMonto = 0;
        private string metodoCobro = "";

        //listas
        private List<venta_vs_cobros> listaVentaCobro;
        private List<venta_vs_cobros_detalles> listaVentaCobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;

        //variables
        private decimal cantidad_monto = 0;
        private decimal precio_monto = 0;
        private decimal importe_monto = 0;
        private decimal descuento_monto = 0;
        private decimal descuento_porciento = 0;
        private decimal itebis_monto = 0;




        public ventana_venta_cobro()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana venta cobro");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                clienteIdText.Focus();
                clienteIdText.SelectAll();

                metodoCobroComboBox.SelectedIndex = 0;
                cliente = null;
                loadCliente();
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
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay elementos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                //cobro enzabezado
                ventaCobro = new venta_vs_cobros();
                ventaCobro.codigo = modeloVenta.getNextCobro();
                ventaCobro.fecha = DateTime.Today;
                ventaCobro.detalle = "";
                ventaCobro.cod_empleado = empleado.codigo;
                ventaCobro.activo = true;
                ventaCobro.cod_empleado_anular = 0;
                ventaCobro.motivo_anulado = "";
                ventaCobro.cuadrado = false;


                //cobro detalle
                listaVentaCobroDetalle = new List<venta_vs_cobros_detalles>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //validar que tenga monto > 0 y que tenga metodo de pago
                    if (Convert.ToDecimal(row.Cells[8].Value.ToString()) > 0 && (row.Cells[9].Value.ToString() != ""))
                    {
                        ventaCobroDetalle = new venta_vs_cobros_detalles();
                        ventaCobroDetalle.codigo = 0;
                        ventaCobroDetalle.codigo_cobro = ventaCobro.codigo;
                        ventaCobroDetalle.codigo_venta = Convert.ToInt16(row.Cells[0].Value.ToString());
                        if (row.Cells[9].Value.ToString().ToLower() == "efe")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 1;
                        }
                        if (row.Cells[9].Value.ToString().ToLower() == "dep")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 2;
                        }
                        if (row.Cells[9].Value.ToString().ToLower() == "che")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 3;
                        }
                        ventaCobroDetalle.monto_cobrado = Convert.ToDecimal(row.Cells[8].Value.ToString());
                        ventaCobroDetalle.monto_descontado = 0;
                        ventaCobroDetalle.activo = true;


                        listaVentaCobroDetalle.Add(ventaCobroDetalle);
                    }
                }
                if ((modeloVenta.setVentaCobro(ventaCobro, listaVentaCobroDetalle) == true))
                {
                    
                    loadCliente();
                    if (MessageBox.Show("Se agregó el cobro, desea imprimir el cobro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        modeloReporte.imprirmirVentaCobro(ventaCobro.codigo);
                    }
                    ventaCobro = null;
                }
                else
                {
                    ventaCobro = null;
                    loadCliente();
                    MessageBox.Show("No se agregó el cobro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ventaCobro = null;
                venta = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void eliminar()
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
                    //dataGridView1.Rows.Remove(dataGridView1.Rows[fila]);
                    dataGridView1.Rows[fila].Cells[8].Value = "0.00";
                    dataGridView1.Rows[fila].Cells[9].Value = "";
                }
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void agregar()
        {
            try
            {
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                //validaciones
                //monto no esta en blanco
                if (montoAbonoText.Text == "")
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("Falta el abono", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal dinero;
                if (decimal.TryParse(montoAbonoText.Text, out dinero) == false)
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("El abono debe ser un monto dinero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //el monto es mayor que cero
                if (Convert.ToDecimal(montoAbonoText.Text) < 0)
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("El abono debe ser mayor que cero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //monto abonar no sobrepase el monto pendiente
                if (Convert.ToDecimal(montoAbonoText.Text) > Convert.ToDecimal(dataGridView1.Rows[fila].Cells[7].Value.ToString()))
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("El abono debe ser menor que el monto pendiente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                getMetodoCobro();
                if (fila >= 0)
                {
                    dataGridView1.Rows[fila].Cells[8].Value = Convert.ToDecimal(montoAbonoText.Text).ToString("N");
                    dataGridView1.Rows[fila].Cells[9].Value = metodoCobro.ToString();
                }
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void calcularTotal()
        {
            try
            {
                totalPendienteText.Text = "0.00";
                totalAbonadoText.Text = "0.00";

                if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows == null)
                {
                    return;
                }

                totalPendienteMonto = 0;
                totalCobradoMonto = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //MessageBox.Show(row.Cells[7].Value.ToString()+"----"+row.Cells[8].Value.ToString());
                    totalPendienteMonto += Convert.ToDecimal(row.Cells[7].Value);
                    totalCobradoMonto += Convert.ToDecimal(row.Cells[8].Value);
                }
                totalPendienteText.Text = totalPendienteMonto.ToString("N");
                totalAbonadoText.Text = totalCobradoMonto.ToString("N");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error calcularTotal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void loadVentas()
        {
            try
            {
                dataGridView1.Rows.Clear();

                if (cliente == null)
                {
                    return;
                }
                listaVenta = modeloVenta.getListaVentaByClienteId(cliente.codigo);
                //filtrando las compra que esten activa, que no esten pagada y que no sean a contado
                listaVenta = listaVenta.FindAll(x => x.pagada == false && x.activo == true && x.tipo_venta != "CON").ToList();
                listaVenta = listaVenta.OrderByDescending(x => x.codigo).ToList();
                foreach (var x in listaVenta)
                {
                    decimal montoPendiente = 0;
                    montoPendiente = modeloVenta.getMontoPendienteByVenta(x.codigo);
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    dataGridView1.Rows.Add(x.codigo, x.fecha.ToString("dd/MM/yyyy"), utilidades.getDiasByRangoFecha(x.fecha_limite, DateTime.Today), empleado.nombre, x.tipo_venta, x.ncf, x.fecha_limite.ToString("dd/MM/yyyy"), montoPendiente.ToString("N"));
                }
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentas.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    loadVentas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getMetodoCobro()
        {
            try
            {
                if (metodoCobroComboBox.Text == "")
                {
                    return;
                }
                if (metodoCobroComboBox.Text.ToLower() == "efectivo")
                {
                    metodoCobro = "EFE";
                }
                else if (metodoCobroComboBox.Text.ToLower() == "deposito")
                {
                    metodoCobro = "DEP";
                }
                else if (metodoCobroComboBox.Text.ToLower() == "cheque")
                {
                    metodoCobro = "CHE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMetodoCobro.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_venta_cobro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                getAction();
                calcularTotal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cliente = null;
            loadVentana();
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
                    metodoCobroComboBox.Focus();
                    metodoCobroComboBox.SelectAll();

                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    loadCliente();
                }
            }
            catch (Exception)
            {

            }
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
            calcularTotal();
        }

        private void metodoPagoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoAbonoText.Focus();
                montoAbonoText.SelectAll();
            }
        }

        private void montoAbonoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button20.Focus();

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void ventana_venta_cobro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    salir();
                }
                if (e.KeyCode == Keys.F2)
                {
                    int cantItems = 0;
                    cantItems = metodoCobroComboBox.Items.Count;
                    if (metodoCobroComboBox.SelectedIndex == (cantItems - 1))
                    {
                        metodoCobroComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        metodoCobroComboBox.SelectedIndex += 1;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void clienteIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void montoAbonoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoAbonoText.Text);
        }
    }
}
