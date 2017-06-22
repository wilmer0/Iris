using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
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
        private venta_detalle VentaDetalle;
        private ventana_desglose_dinero ventanaDesglose;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobroDetalle;
        private cliente cliente;

        //modelos
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();
        private modeloEmpleado modeloEmpleado=new modeloEmpleado();
        ModeloReporte modeloReporte=new ModeloReporte();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra
        private decimal totalPendienteMonto = 0;
        private decimal totalCobradoMonto = 0;
        private decimal totalDescontado = 0;
        private string metodoPago = "";

        //listas
        private List<venta_vs_cobros> listaVentaCobro;
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
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
                if (cliente == null)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar un cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (dataGridView1.Rows.Count == 0)
                {
                    clienteIdText.Focus();
                    clienteIdText.SelectAll();
                    MessageBox.Show("No hay facturas", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar que se digito algun monto a pagar
                bool existe = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[8].Value)>0)
                    {
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    MessageBox.Show("Debe efectuar un abono", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                listaVentacobroDetalle=new List<venta_vs_cobros_detalles>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //validar que tenga monto abonar > 0 , que monto descuento sea cero o mayor y que tenga metodo de pago
                    if (Convert.ToDecimal(row.Cells[8].Value) > 0 && Convert.ToDecimal(row.Cells[9].Value)>=0 && row.Cells[10].Value != "" )
                    {
                        ventaCobroDetalle = new venta_vs_cobros_detalles();
                        ventaCobroDetalle.codigo = 0;
                        ventaCobroDetalle.codigo_cobro = ventaCobro.codigo;
                        ventaCobroDetalle.codigo_venta = Convert.ToInt16(row.Cells[0].Value);
                        if (row.Cells[10].Value.ToString().ToLower() == "efe")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 1;
                        }
                        if (row.Cells[10].Value.ToString().ToLower() == "dep")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 2;
                        }
                        if (row.Cells[10].Value.ToString().ToLower() == "che")
                        {
                            ventaCobroDetalle.codigo_metodo_cobro = 3;
                        }
                        ventaCobroDetalle.monto_cobrado = Convert.ToDecimal(row.Cells[8].Value);
                        ventaCobroDetalle.monto_descontado = Convert.ToDecimal(row.Cells[9].Value);
                        ventaCobroDetalle.monto_subtotal = (Convert.ToDecimal(row.Cells[8].Value)) - (Convert.ToDecimal(row.Cells[9].Value));
                        ventaCobroDetalle.activo = true;

                        listaVentacobroDetalle.Add(ventaCobroDetalle);
                    
                    }
                }
                if((modeloVenta.setVentaCobro(ventaCobro, listaVentacobroDetalle))==true)
                {
                    loadCliente();
                    if (MessageBox.Show("Se agregó el cobro, desea imprimir el cobro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        modeloReporte.imprimirVentaCobro(ventaCobro.codigo);
                    }
                    ventaCobro = null;
                }
                else
                {
                    loadCliente();
                    MessageBox.Show("No se agregó el cobro", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ventaCobro = null;
                }
            }
            catch (Exception ex)
            {
                venta = null;
                ventaCobro = null;
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
                    dataGridView1.Rows[fila].Cells[9].Value = "0.00";
                    dataGridView1.Rows[fila].Cells[10].Value = "";
                }
                calcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminar.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool validarAgregar()
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
                    return false;
                }
                //que descuento no este en blanco
                //el monto es mayor que cero
                if (montoDescuentoText.Text == "")
                {
                    montoDescuentoText.Focus();
                    montoDescuentoText.SelectAll();
                    MessageBox.Show("Falta el descuento", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (Convert.ToDecimal(montoAbonoText.Text) < 0)
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("El abono debe ser mayor que cero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (Convert.ToDecimal(montoDescuentoText.Text) < 0)
                {
                    montoDescuentoText.Focus();
                    montoDescuentoText.SelectAll();
                    MessageBox.Show("El descuento debe ser por lo menos cero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //monto abonar no sobrepase el monto pendiente
                if (Convert.ToDecimal(montoAbonoText.Text) > Convert.ToDecimal(dataGridView1.Rows[fila].Cells[7].Value.ToString()))
                {
                    montoAbonoText.Focus();
                    montoAbonoText.SelectAll();
                    MessageBox.Show("El abono debe ser menor que el monto pendiente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar que el descuento sea menor o igual al monto a pagar
                //monto descuento no sobrepase el monto de abono
                if (Convert.ToDecimal(montoDescuentoText.Text) > Convert.ToDecimal(montoAbonoText.Text))
                {
                    montoDescuentoText.Focus();
                    montoDescuentoText.SelectAll();
                    MessageBox.Show("El descuento debe ser menor o igual que el monto deabono", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarAgregar.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public void agregar()
        {
            try
            {
                if (validarAgregar() == false)
                {
                    return;
                }

                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                getMetodoPago();
                if (fila >= 0)
                {
                    dataGridView1.Rows[fila].Cells[8].Value = Convert.ToDecimal(montoAbonoText.Text).ToString("N");
                    dataGridView1.Rows[fila].Cells[9].Value = Convert.ToDecimal(montoDescuentoText.Text).ToString("N");
                    dataGridView1.Rows[fila].Cells[10].Value =metodoPago.ToString();
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
                if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows == null)
                {
                    return;
                }

                totalPendienteText.Text = "0.00";
                totalAbonadoText.Text = "0.00";

                
                totalPendienteMonto = 0;
                totalCobradoMonto = 0;
                totalDescontado = 0;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    totalPendienteMonto += Convert.ToDecimal(row.Cells[7].Value);
                    totalCobradoMonto += Convert.ToDecimal(row.Cells[8].Value);
                    totalDescontado+=Convert.ToDecimal(row.Cells[9].Value);
                }
                totalPendienteText.Text = totalPendienteMonto.ToString("N");
                totalAbonadoText.Text = totalCobradoMonto.ToString("N");
                totalDescontadoText.Text = totalDescontado.ToString("N");
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
      
        private void ventana_compra_pagos_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                getAction();
                calcularTotal();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cliente = null;
            loadVentana();
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
                listaVenta = listaVenta.FindAll(x => x.pagada == false && x.activo == true && x.codigo_tipo_venta == 2 || x.codigo_tipo_venta == 4).ToList();
                listaVenta = listaVenta.OrderByDescending(x => x.codigo).ToList();
                foreach (var x in listaVenta)
                {
                    decimal montoPendiente = 0;
                    montoPendiente = modeloVenta.getMontoPendienteByVenta(x.codigo);
                    empleado = modeloEmpleado.getEmpleadoById(x.codigo_empleado);
                    if (montoPendiente > 0)
                    {
                        dataGridView1.Rows.Add(x.codigo, x.fecha.ToString("dd/MM/yyyy"),utilidades.getDiasByRangoFecha(x.fecha_limite, DateTime.Today),empleado.nombre,x.tipo_venta, x.ncf, x.fecha_limite.ToString("dd/MM/yyyy"), montoPendiente.ToString("N"),"0.00","0.00","");
                    }
                    else
                    {
                        modeloVenta.setVentapagada(x.codigo);
                    }
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
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    metodoPagoComboBox.Focus();
                    metodoPagoComboBox.SelectAll();

                    cliente = modeloCliente.getClienteById(Convert.ToInt16(clienteIdText.Text));
                    loadCliente();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoAbonoText.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            eliminar();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void montoAbonoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoDescuentoText.Focus();
                montoDescuentoText.SelectAll();

            }
        }

        private void button20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
            if (e.KeyCode == Keys.Tab)
            {
                button19.Focus();
            }
        }

        private void ventana_compra_pagos_KeyDown(object sender, KeyEventArgs e)
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
                    cantItems = metodoPagoComboBox.Items.Count;
                    if (metodoPagoComboBox.SelectedIndex == (cantItems - 1))
                    {
                        metodoPagoComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        metodoPagoComboBox.SelectedIndex += 1;
                    }
                }
            }
            catch (Exception)
            {
                
            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void metodoPagoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                montoAbonoText.Focus();
                montoAbonoText.SelectAll();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter ||e.KeyCode == Keys.Tab)
            {
                metodoPagoComboBox.Focus();
                metodoPagoComboBox.SelectAll();
            }
        }

        private void montoDescuentoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button20.Focus();

            }
        }

        private void montoDescuentoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, montoAbonoText.Text);
        }
    }
}
