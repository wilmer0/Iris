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

        //objetos
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private cuadre_caja cuadreCaja;
        private cajero cajero;
        private empleado empleadoSesion;

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();
        modeloCajero modeloCajero=new modeloCajero();


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
                if (cuadreCaja != null)
                {
                    fechaText.Text = DateTime.Today.ToString("dd/MM/yyyy");
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


                }
                else
                {
                    fechaText.Text = cuadreCaja.fecha.ToString("dd/MM/yyyy");
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
                ////
                //if (claveConfirmarText.Text == "")
                //{
                //    MessageBox.Show("Falta la confirmación de la nueva clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    claveConfirmarText.Focus();
                //    claveConfirmarText.SelectAll();
                //    return false;
                //}


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
