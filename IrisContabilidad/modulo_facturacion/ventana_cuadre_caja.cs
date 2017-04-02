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
    public partial class ventana_cuadre_caja : formBase
    {

        //variables
        private DateTime fechaFinal;

        //objetos
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private cuadre_caja cuadreCaja;
        private cajero cajero;
        private empleado empleadoSesion;
        private venta venta;
        private venta_detalle ventaDetalle;
        private egreso_caja egresoCaja;
        private ingreso_caja ingresoCaja;
        private compra_vs_pagos compraPago;
        private compra_vs_pagos_detalles compraPagoDetalle;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobrosDetalle;
        private compra compra;

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();
        modeloCajero modeloCajero=new modeloCajero();
        modeloVenta modeloVenta=new modeloVenta();
        modeloEgresoCaja modeloEgreCaja=new modeloEgresoCaja();
        modeloIngresoCaja modeloIngresoCaja=new modeloIngresoCaja();
        modeloCompra modeloCompra=new modeloCompra();

        //listas


        //variables

        private decimal montoTotalEfectivoEsperado = 0;

        public ventana_cuadre_caja()
        {
            InitializeComponent();
            empleadoSesion = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSesion, "ventana cuadre caja");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (cuadreCaja == null)
                {
                    cuadreCaja=new cuadre_caja();
                    cajero = modeloCajero.getCajeroByIdEmpleado(empleadoSesion.codigo);
                    if (cajero == null)
                    {
                        MessageBox.Show("Este usuario no es un cajero para poder realizar cierre de caja", "",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }

                    fechaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    fechaFinal = DateTime.Today;
                    dosMilText.Text = "0.00";
                    milText.Text = "0.00";
                    quinientoText.Text = "0.00";
                    doscientosText.Text = "0.00";
                    cienText.Text = "0.00";
                    cincuentaText.Text = "0.00";
                    venticincoText.Text = "0.00";
                    veinteText.Text = "0.00";
                    diezText.Text = "0.00";
                    cincoText.Text = "0.00";
                    unoText.Text = "0.00";

                    //obtener todos los valores de los montos
                    cuadreCaja=modeloCuadreCaja.getCuadreCajaByCajeroId(cajero.codigo);

                    //se llenan todos los detalles del cuadre de caja en base al mismo cuadre de caja anterior
                    cuadreCaja=new cuadre_caja(cuadreCaja);



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public bool ValidarGetAction()
        {
            try
            {
                //cajero
                if (cajero==null)
                {
                    MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cajeroIdText.Focus();
                    cajeroIdText.SelectAll();
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void GetAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (!ValidarGetAction())
                {
                    return;
                }

                //cambiar la clave
                if (modeloCuadreCaja.agregarCuadreCaja(cuadreCaja)==true)
                {
                    cuadreCaja = null;
                    MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cuadreCaja = null;
                    MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ventana_cuadre_caja_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cuadreCaja = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        public void loadCajero()
        {
            try
            {
                cajeroIdText.Text = "";
                cajeroLabel.Text = "";
                if (cajero != null)
                {
                    empleado = modeloEmpleado.getEmpleadoByCajeroId(cajero.codigo);

                    cajeroIdText.Text = cajero.codigo.ToString();
                    cajeroLabel.Text = empleado.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCajero.: "+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            ventana_busqueda_cajero ventana=new ventana_busqueda_cajero();
            ventana.Owner = this;
            ventana.ShowDialog();

            if (ventana.DialogResult == DialogResult.OK)
            {
                cajero = ventana.getObjeto();
                loadCajero();
            }
        }
    }
}
