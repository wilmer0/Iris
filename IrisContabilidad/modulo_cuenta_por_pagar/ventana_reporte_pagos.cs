using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleApi.Extensions;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_reporte_pagos : formBase
    {

        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        suplidor suplidor;
        private compra compra;

        //variables
        private DateTime fechaInicial;
        private DateTime fechaFinal;
        bool incluirRangoFechas = false;
        private bool incluirSoloCompraPagadas = false;
        private string tipoCompra = "";

        //modelos
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloCompra modeloCompra=new modeloCompra();
        ModeloReporte modeloReporte=new ModeloReporte();

        public ventana_reporte_pagos()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana suplidor");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (suplidor != null)
                {
                   
                }
                else
                {
                    //blanquear campos
                    suplidor = null;
                    compra = null;

                    checkBoxSoloComprasPagadas.Checked = false;
                    checkBoxIncluirRangoFechaVenta.Checked = false;
                    fechaInicialText.Enabled = !(bool) checkBoxIncluirRangoFechaVenta.Checked;
                    fechaFinalText.Enabled = !(bool)checkBoxIncluirRangoFechaVenta.Checked;
                    fechaInicialText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    fechaFinalText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void ventana_reporte_pagos_Load(object sender, EventArgs e)
        {

        }

        public void getAction()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        public bool validarImpresion()
        {
            try
            {
                if (tipoCompraComboBox.Text != "")
                {
                    tipoCompra = tipoCompraComboBox.Text;
                }
                if (checkBoxIncluirRangoFechaVenta.Checked == true)
                {
                    incluirRangoFechas = true;
                }
                else
                {
                    incluirRangoFechas = false;
                }
                if (checkBoxSoloComprasPagadas.Checked == true)
                {
                    incluirSoloCompraPagadas = true;
                }
                else
                {
                    incluirSoloCompraPagadas = false;
                }
                DateTime f1;
                DateTime f2;
                if (DateTime.TryParse(fechaInicialText.Text, out f1) == false)
                {
                    MessageBox.Show("Error formato fecha incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fechaInicialText.Focus();
                    fechaInicialText.SelectAll();
                    return false;
                }
                if (DateTime.TryParse(fechaFinalText.Text, out f1) == false)
                {
                    MessageBox.Show("Error formato fecha incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fechaFinalText.Focus();
                    fechaFinalText.SelectAll();
                    return false;
                }
                fechaInicial = Convert.ToDateTime(fechaInicialText.Text);
                fechaFinal = Convert.ToDateTime(fechaFinalText.Text);


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarImpresion.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if(validarImpresion()==false)
            {
                return;
            }
        }

        private void label8_Click(object sender, EventArgs e)
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

        public void loadSuplidor()
        {
            try
            {
                suplidorIdText.Text = "";
                suplidorLabel.Text = "";

                if (suplidor != null)
                {
                    suplidorIdText.Text = suplidor.codigo.ToString();
                    suplidorLabel.Text = suplidor.nombre+"-"+suplidor.rnc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCompra()
        {
            try
            {
                compraIdText.Text = "";
                compraLabel.Text = "";

                if (compra != null)
                {
                    compraIdText.Text = compra.codigo.ToString();
                    compraLabel.Text = compra.numero_factura + "-" + suplidor.rnc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCompra.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana=new ventana_busqueda_suplidor();
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadSuplidor();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_compra ventana=new ventana_busqueda_compra();
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                compra = ventana.getObjeto();
                loadCompra();
            }
        }
    }
}
