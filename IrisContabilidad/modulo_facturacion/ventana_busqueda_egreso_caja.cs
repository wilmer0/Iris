using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_busqueda_egreso_caja : formBase
    {

        //objetos
        private egreso_caja egresoCaja;
        utilidades utilidades=new utilidades();
        private caja_ingresos_egresos_conceptos concepto;
        private empleado cajero;

        //listas
        private List<egreso_caja> listaEgresoCaja;
        List<egreso_caja> listaEgresoCajaTemporal;

        //modelos
        private modeloEgresoCaja modeloEgresoCaja = new modeloEgresoCaja();
        modeloCajaIngresosEgresosConceptos modeloConcepto=new modeloCajaIngresosEgresosConceptos();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        //variables 
        public bool mantenimiento = false;
        private int fila = 0;
        int cont = 0;

        public ventana_busqueda_egreso_caja(bool mantenimiento=false)
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
                if (listaEgresoCaja == null)
                {
                    listaEgresoCaja = new List<egreso_caja>();
                    listaEgresoCaja = modeloEgresoCaja.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaEgresoCaja.ForEach(x =>
                {
                   concepto=new caja_ingresos_egresos_conceptos();
                   concepto = modeloConcepto.getConceptoById(x.codigo_concepto);
                   cajero=new empleado();
                   cajero = modeloEmpleado.getEmpleadoByCajeroId(x.codigo_cajero);
                   dataGridView1.Rows.Add(x.codigo, utilidades.getFechaddMMyyyy(x.fecha), concepto.nombre,cajero.nombre, x.monto.ToString("N"));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public egreso_caja getObjeto()
        {
            try
            {
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                egresoCaja = modeloEgresoCaja.getEgresoCajaById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return egresoCaja;
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

                listaEgresoCaja = modeloEgresoCaja.getListaCompleta();
                listaEgresoCajaTemporal = new List<egreso_caja>();

                //filtrar por todos
                if (radioTodos.Checked == true)
                {
                    listaEgresoCaja = listaEgresoCaja.FindAll(x => x.detalle.ToLower().Contains(nombreText.Text.ToLower()));
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaEgresoCaja = listaEgresoCaja.FindAll(x => x.monto <= Convert.ToDecimal(nombreText.Text));
                    }
                }

                //filtrar por monto
                if (radioMonto.Checked == true)
                {
                    decimal dinero;
                    if (decimal.TryParse(nombreText.Text, out dinero) != false)
                    {
                        listaEgresoCaja = listaEgresoCaja.FindAll(x => x.monto <= Convert.ToDecimal(nombreText.Text));
                    }
                }

                listaEgresoCajaTemporal = listaEgresoCaja;

                if (radioCajero.Checked == true)
                {
                    //nombre de cajero
                    if (radioCajero.Checked == true)
                    {
                        cont = 0;
                        listaEgresoCajaTemporal.ForEach(x =>
                        {
                            cajero = new empleado();
                            cajero = modeloEmpleado.getEmpleadoByCajeroId(x.codigo_cajero);
                            if (!cajero.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                            {
                                listaEgresoCaja.RemoveAt(cont);
                            }
                            cont++;
                        });
                    }
                }

                listaEgresoCajaTemporal = listaEgresoCaja;

                if (radioConcepto.Checked == true)
                {
                    //por concepto
                    cont = 0;
                    listaEgresoCajaTemporal.ForEach(x =>
                    {
                        concepto = new caja_ingresos_egresos_conceptos();
                        concepto = modeloConcepto.getConceptoById(x.codigo_concepto);
                        if (!concepto.nombre.ToLower().Contains(nombreText.Text.ToLower()))
                        {
                            listaEgresoCaja.RemoveAt(cont);
                        }
                        cont++;
                    });
                }

                loadLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }
        private void ventana_busqueda_egreso_caja_Load(object sender, EventArgs e)
        {

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

       
        private void ventana_busqueda_egreso_caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (radioTodos.Checked == true)
                {
                    radioCajero.Checked = true;
                }
                else if (radioCajero.Checked==true)
                {
                    radioConcepto.Checked = true;
                }
                else if (radioConcepto.Checked==true)
                {
                    radioMonto.Checked = true;
                }
                else if (radioMonto.Checked==true)
                {
                    radioTodos.Checked = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaEgresoCaja = null;
            loadLista();
        }
    }
}
