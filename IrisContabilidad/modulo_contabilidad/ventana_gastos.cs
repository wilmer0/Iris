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

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_gastos : formBase
    {

        //objetos
        singleton singleton = new singleton();
        utilidades utilidades = new utilidades();
        empleado empleado;
        private suplidor suplidor;
        private tipo_gasto tipoGasto;


        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        private modeloTipoGasto modeloTipoGasto;

        public ventana_gastos()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana gastos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSuplidor()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadTipoGasto()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadTipoRetencion()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoRetencion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar que el usuario es cajero
                if (cajero == null)
                {
                    cajeroIdText.Focus();
                    cajeroIdText.SelectAll();
                    MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar que tenga monto de apertura
                if (montoAperturaText.Text == "")
                {
                    montoAperturaText.Focus();
                    montoAperturaText.SelectAll();
                    MessageBox.Show("Falta el monto efectivo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar monto sea cero o mayor
                if (Convert.ToDecimal(montoAperturaText.Text) < 0)
                {
                    montoAperturaText.Focus();
                    montoAperturaText.SelectAll();
                    MessageBox.Show("El monto debe ser un número mayor o igual a cero", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar si este cajero tiene caja abierta
                if ((modeloCajero.getValidarCajaAbiertaByCajero(cajero.codigo)) == true)
                {
                    MessageBox.Show("Este cajero ya tiene una caja abierta, no puede realizar apertura sobre una ya existente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                //validando campos necesarios
                if (validarGetAction() == false)
                {
                    return;
                }

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                bool crear = false;
                //se instancia el empleado si esta nulo
                if (cuadreCaja == null)
                {
                    cuadreCaja = new cuadre_caja();
                    crear = true;
                    cuadreCaja.codigo = modeloCuadreCaja.getNext();
                    cuadreCaja.turno = modeloCuadreCaja.getNextTurno();
                    cuadreCaja.activo = true;
                }

                cuadreCaja.codigo_cajero = cajero.codigo;
                cuadreCaja.fecha = DateTime.Today;
                cuadreCaja.codigo_sucursal = empleado.codigo_sucursal;
                cuadreCaja.codigo_caja = cajero.codigo_caja;
                cuadreCaja.efectivo_inicial = Convert.ToDecimal(montoAperturaText.Text);
                cuadreCaja.caja_cuadrada = false;
                cuadreCaja.caja_abierta = true;

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCuadreCaja.agregarCuadreCaja(cuadreCaja)) == true)
                    {
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cuadreCaja = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                cuadreCaja = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_gastos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
