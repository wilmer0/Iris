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
    public partial class ventana_venta_cobros : formBase
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
        private decimal totalAbonadoMonto = 0;
        private string metodoPago = "";

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


        public ventana_venta_cobros()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana venta cobros");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                clienteIdText.Focus();
                clienteIdText.SelectAll();


                metodoPagoComboBox.SelectedIndex = 0;
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

                //pago enzabezado
                ventaCobro = new venta_vs_cobros();
                ventaCobro.codigo = modeloVenta.getNextCobro();
                ventaCobro.fecha = DateTime.Today;
                ventaCobro.detalle = "";
                ventaCobro.cod_empleado = empleado.codigo;
                ventaCobro.activo = true;
                ventaCobro.cod_empleado_anular = 0;
                ventaCobro.motivo_anulado = "";
                ventaCobro.cuadrado = false;


                //pago detalle
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
                }
                else
                {
                    loadCliente();
                    MessageBox.Show("No se agregó el cobro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
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
                MessageBox.Show("Error eliminarProducto.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                getMetodoPago();
                if (fila >= 0)
                {
                    dataGridView1.Rows[fila].Cells[8].Value = Convert.ToDecimal(montoAbonoText.Text).ToString("N");
                    dataGridView1.Rows[fila].Cells[9].Value = metodoPago.ToString();
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
                totalCobradoText.Text = "0.00";

                if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows == null)
                {
                    return;
                }

                totalPendienteMonto = 0;
                totalAbonadoMonto = 0;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    totalPendienteMonto += Convert.ToDecimal(row.Cells[7].Value.ToString());
                    totalAbonadoMonto += Convert.ToDecimal(row.Cells[8].Value.ToString());
                }
                totalPendienteText.Text = totalPendienteMonto.ToString("N");
                totalCobradoText.Text = totalAbonadoMonto.ToString("N");
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
                listaVenta = modeloVenta.getListaVentasByClienteId(cliente.codigo);
                //filtrando las compra que esten activa, que no esten pagada y que no sean a contado
                listaVenta = listaVenta.FindAll(x => x.pagada == false && x.activo == true && x.tipo_venta != "CON").ToList();
                foreach (var x in listaVenta)
                {
                    decimal montoPendiente = 0;
                    montoPendiente = modeloVenta.getMontoPendienteBycompra(x.codigo);
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
        public void getMetodoPago()
        {
            try
            {
                if (metodoPagoComboBox.Text == "")
                {
                    return;
                }
                if (metodoPagoComboBox.Text.ToLower() == "efectivo")
                {
                    metodoPago = "EFE";
                }
                else if (metodoPagoComboBox.Text.ToLower() == "deposito")
                {
                    metodoPago = "DEP";
                }
                else if (metodoPagoComboBox.Text.ToLower() == "cheque")
                {
                    metodoPago = "CHE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getMetodoPago.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_venta_cobros_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
