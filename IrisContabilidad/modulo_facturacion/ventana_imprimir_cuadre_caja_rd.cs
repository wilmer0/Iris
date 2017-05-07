using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_imprimir_cuadre_caja_rd : formBase
    {

        //objetos
        empleado empleadoSingleton;
        private empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private cajero cajero;
        private cuadre_caja cuadreCaja;
        


        //modelos
        modeloCajero modeloCajero = new modeloCajero();
        modeloEmpleado modeloEmpelado = new modeloEmpleado();
        ModeloReporte modeloReporte=new ModeloReporte();
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();

        //variables
        private DateTime fechaCierre;


        public ventana_imprimir_cuadre_caja_rd()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "reiprimir cuadre caja");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        public void loadVentana()
        {
            try
            {
                cajeroIdText.Focus();
                cajeroIdText.SelectAll();


                fechaCierreDateTime.Text = utilidades.getFechaddMMyyyy(DateTime.Today);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_imprimir_cuadre_caja_rd_Load(object sender, EventArgs e)
        {

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
                //validar cajero
                if (cajero == null)
                {
                    MessageBox.Show("Falta el cajero", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cajeroIdText.Focus();
                    cajeroIdText.SelectAll();
                    return false;
                }
                DateTime f;
                if (DateTime.TryParse(fechaCierreDateTime.Text, out f) == false)
                {
                    MessageBox.Show("Fecha cierre cuadre, formato incorrecto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fechaCierreDateTime.Focus();
                    fechaCierreDateTime.SelectAll();
                    return false;
                }
                fechaCierre = Convert.ToDateTime(fechaCierreDateTime.Text);
                
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

                cuadreCaja = modeloCuadreCaja.getCuadreCajaByCajeroIdAndFechaCiere(cajero.codigo, fechaCierre);

                if (cuadreCaja == null)
                {
                    MessageBox.Show("No se encuentra cuadre de caja con el cajero seleccionado y la fecha establecida.","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                modeloReporte.imprimirCuadreCajaGeneral(cuadreCaja.codigo);

            }
            catch (Exception ex)
            {
                cajero = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        public void loadCajero()
        {
            try
            {
                cajeroIdText.Text = "";
                cajeroText.Text = "";
                if (cajero != null)
                {
                    empleado = modeloEmpelado.getEmpleadoByCajeroId(cajero.codigo);
                    cajeroIdText.Text = cajero.codigo.ToString();
                    cajeroText.Text = empleado.nombre;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cajero = null;
            loadVentana();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cajeroText_TextChanged(object sender, EventArgs e)
        {

        }

        private void cajeroIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }

                if (e.KeyCode == Keys.Enter)
                {
                    fechaCierreDateTime.Focus();
                    fechaCierreDateTime.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void fechaCierreDateTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }
    }
}
