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
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_cajero : formBase
    {

        //objetos
        empleado empleadoSingleton;
        private empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        itebis itebis;
        private cajero cajero;
        private caja caja;



        //modelos
        modeloCaja modeloCaja = new modeloCaja();
        modeloCajero modeloCajero=new modeloCajero();
        modeloEmpleado modeloEmpelado=new modeloEmpleado();



        public ventana_cajero()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cajero");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (cajero != null)
                {
                    caja = modeloCaja.getCajaById(cajero.codigo_caja);
                    loadCaja();
                    empleado = modeloEmpelado.getEmpleadoById(cajero.codigo_empleado);
                    loadEmpleado();
                    activoCheck.Checked = Convert.ToBoolean(cajero.activo);
                }
                else
                {
                    cajeroIdText.Text = "";
                    caja = null;
                    loadCaja();
                    empleado = null;
                    loadEmpleado();
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //validar caja
                if (caja== null)
                {
                    MessageBox.Show("Falta la caja", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cajaIdText.Focus();
                    cajaIdText.SelectAll();
                    return false;
                }
                //validar empleado
                if (empleado==null)
                {
                    MessageBox.Show("Falta el empelado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();
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
                if (cajero == null)
                {
                    cajero = new cajero();
                    crear = true;
                    cajero.codigo = modeloCajero.getNext();
                }
                cajero.codigo_caja = caja.codigo;
                cajero.codigo_empleado = empleado.codigo;
                cajero.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCajero.agregarCajero(cajero)) == true)
                    {
                        cajero = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloCajero.modificarCajero(cajero)) == true)
                    {
                        cajero = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                cajero = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_cajero_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        public void loadEmpleado()
        {
            try
            {
                if (empleado == null)
                {
                    empleadoIdText.Text = "";
                    empleadoText.Text = "";
                    return;
                }
                empleadoIdText.Text = empleado.codigo.ToString();
                empleadoText.Text = empleado.nombre;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCaja()
        {
            try
            {
                if(caja==null)
                {
                    cajaIdText.Text = "";
                    cajaText.Text = "";
                    return;
                }
                cajaIdText.Text = caja.codigo.ToString();
                cajaText.Text = caja.nombre;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCaja.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_caja ventana = new ventana_busqueda_caja();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                caja = ventana.getObjeto();
                loadCaja();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_empleado ventana = new ventana_busqueda_empleado();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                empleado = ventana.getObjeto();
                loadEmpleado();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            cajero = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cajero ventana = new ventana_busqueda_cajero(true);
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cajero = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
