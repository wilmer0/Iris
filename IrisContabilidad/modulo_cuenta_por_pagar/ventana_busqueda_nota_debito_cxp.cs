using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_busqueda_nota_debito_cxp : formBase
    { 
        //objetos
        private cxp_nota_debito notaDebito;
        utilidades utilidades = new utilidades();
        private nota_credito_debito_concepto concepto;
        private empleado cajero;
        private compra compra;
        private suplidor suplidor;


        //listas
        private List<cxp_nota_debito> listaNotasDebitos;


        //modelos
        private modeloCxpNotaDebito modeloNotaDebito = new modeloCxpNotaDebito();
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCompra modeloCompra = new modeloCompra();
        modeloSuplidor modeloSuplidor = new modeloSuplidor();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int cont = 0;


        public ventana_busqueda_nota_debito_cxp()
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
                if (listaNotasDebitos == null)
                {
                    listaNotasDebitos = new List<cxp_nota_debito>();
                    listaNotasDebitos = modeloNotaDebito.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaNotasDebitos.ForEach(x =>
                {
                    compra = modeloCompra.getCompraById(x.codigoCompra);

                    concepto = new nota_credito_debito_concepto();
                    concepto = modeloConcepto.getConceptoById(x.codigoConcepto);

                    cajero = new empleado();
                    cajero = modeloEmpleado.getEmpleadoByCajeroId(x.codigoEmpleado);

                    suplidor = modeloSuplidor.getSuplidorById(x.codigoSuplidor);

                    dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), concepto.concepto, suplidor.nombre, compra.codigo, compra.ncf, x.monto.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public cxp_nota_debito getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                notaDebito = modeloNotaDebito.getNotaDebitoById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return notaDebito;
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
        public void filtrar()
        {
            try
            {
                listaNotasDebitos = modeloNotaDebito.getListaCompleta();

                //filtrar por id
                if (radioId.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => x.codigo.ToString().ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por suplidor
                if (radioSuplidor.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (suplidor = modeloSuplidor.getSuplidorById(x.codigoSuplidor)).nombre.ToLower().Contains(nombreText.Text.ToLower()));
                }

                //filtrar por concepto
                if (radioConcepto.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (concepto = modeloConcepto.getConceptoById(x.codigoConcepto)).concepto.ToLower().Contains(nombreText.Text.ToLower()));
                }
                //filtrar por monto
                if (radioMonto.Checked == true)
                {
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaNotasDebitos = listaNotasDebitos.FindAll(x => x.monto <= Convert.ToDecimal(nombreText.Text));
                    }
                }

                //por ncf compra
                if (radioNCFCompra.Checked == true)
                {
                    listaNotasDebitos = listaNotasDebitos.FindAll(x => (compra = modeloCompra.getCompraById(x.codigoCompra)).ncf.ToLower().Contains(nombreText.Text.ToLower()));
                }

                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
        private void ventana_busqueda_nota_debito_cxc_Load(object sender, EventArgs e)
        {

        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filtrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        public void cambiarFiltro()
        {
            if (radioId.Checked == true)
            {
                radioSuplidor.Checked = true;
            }
            else if (radioSuplidor.Checked==true)
            {
                radioConcepto.Checked = true;
            }else if (radioConcepto.Checked == true)
            {
                radioMonto.Checked = true;
            } else if (radioNCFCompra.Checked == true)
            {
                radioId.Checked = true;
            }
        }
        private void ventana_busqueda_nota_debito_cxc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cambiarFiltro();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaNotasDebitos = null;
            loadLista();
        }
    }
}
