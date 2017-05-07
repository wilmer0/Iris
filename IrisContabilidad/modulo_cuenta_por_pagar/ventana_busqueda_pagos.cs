using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_busqueda_pagos : formBase
    {

        //objetos
        private suplidor suplidor;
        private compra_vs_pagos compraPago;
        private empleado empleado;
        utilidades utilidades = new utilidades();

        //listas
        private List<compra_vs_pagos> listaCompraPagos;


        //modelos
        private modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloPago modeloPago = new modeloPago();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int index = 0;


        public ventana_busqueda_pagos(bool mantenimiento=false)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaCompraPagos == null)
                {
                    listaCompraPagos = new List<compra_vs_pagos>();
                    listaCompraPagos = modeloPago.getListaCompletaPagos(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaCompraPagos.ForEach(x =>
                {
                    suplidor = new suplidor();
                    empleado = new empleado();
                    suplidor = modeloSuplidor.getSuplidorByCompraPago(x.codigo);
                    empleado = modeloEmpleado.getEmpleadoById(x.cod_empleado);
                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), suplidor.nombre, empleado.nombre);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public compra_vs_pagos getObjeto()
        {
            try
            {
                //validar que tenga datos el datagrid
                if (dataGridView1.Rows.Count < 0)
                {
                    return null;
                }
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                compraPago = modeloPago.getCompraPagoById((Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString())));
                return compraPago;
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
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ventana_busqueda_pagos_Load(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_pagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                getAction();
            }
            if (e.KeyCode == Keys.F2)
            {
                button3_Click(null, null);
            }
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
            listaCompraPagos = null;
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
                empleado = new empleado();
                suplidor = new suplidor();
                listaCompraPagos = modeloPago.getListaCompletaPagos(mantenimiento);
                //por id
                if (radioButtonID.Checked == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => x.codigo.ToString().Contains(nombreText.Text.ToLower()));
                }
                //por fecha
                if (radioButtonFecha.Checked == true)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(nombreText.Text, out fecha) != false)
                    {
                        fecha = Convert.ToDateTime(nombreText.Text);
                        listaCompraPagos = listaCompraPagos.FindAll(x => x.fecha <= fecha || x.fecha.ToString().Contains(fecha.ToString()));
                    }
                    else
                    {
                        nombreText.Focus();
                        nombreText.SelectAll();
                        MessageBox.Show("El formato de la fecha no es valido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //por empleado
                if (radioButtonEmpleado.Checked == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (empleado = modeloEmpleado.getEmpleadoById(x.cod_empleado)).nombre.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                }
                //por cliente
                if (radioButtonCliente.Checked == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => (suplidor = modeloSuplidor.getSuplidorByCompraPago(x.codigo)).nombre.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                }
                //por detalle
                if (radioButtonDetalle.Checked == true)
                {
                    listaCompraPagos = listaCompraPagos.FindAll(x => x.detalle.ToLower().Contains(nombreText.Text.ToLower()));
                }
                loadLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
    }
}
