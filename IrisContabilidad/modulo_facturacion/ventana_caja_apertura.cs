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
    public partial class ventana_caja_apertura : formBase
    {

        //objetos
        singleton singleton=new singleton();
        utilidades utilidades = new utilidades();
        empleado empleado;
        private empleado empleadoCajero;
        private cuadre_caja cuadreCaja;
        private cajero cajero;


        //modelos
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();
        modeloCajero modeloCajero=new modeloCajero();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        

        public ventana_caja_apertura()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "apertura caja");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                cuadreCaja = null;
                cajero = null;
                cajeroIdText.Focus();
                cajeroIdText.SelectAll();

                cajeroIdText.Text = "";
                cajeroText.Text = "";
                montoAperturaText.Text = "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadCajero()
        {
            try
            {
                cajeroIdText.Text = "";
                cajeroText.Text = "";
                if (cajero == null)
                {
                    return;
                }
                empleadoCajero=new empleado();
                empleadoCajero = modeloEmpleado.getEmpleadoByCajeroId(cajero.codigo);
                cajeroIdText.Text = cajero.codigo.ToString();
                cajeroText.Text = empleadoCajero.nombre;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCajero.:"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                if (cajero==null)
                {
                    cajeroIdText.Focus();
                    cajeroIdText.SelectAll();
                    MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar que tenga monto de apertura
                if (montoAperturaText.Text=="")
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
                if ((modeloCajero.getValidarCajaAbiertaByCajero(cajero.codigo))==true)
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
        private void ventana_caja_apertura_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void montoAperturaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,montoAperturaText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void cajeroIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    montoAperturaText.Focus();
                    montoAperturaText.SelectAll();

                    cajero = modeloCajero.getCajeroById(Convert.ToInt16(cajeroIdText.Text));
                    loadCajero();
                }
            }
            catch (Exception)
            {
            }
        }

        private void montoAperturaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }
    }
}
