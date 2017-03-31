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

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCuadreCaja modeloCuadreCaja=new modeloCuadreCaja();
        modeloCajero modeloCajero=new modeloCajero();


        public ventana_cuadre_caja()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cuadre caja");
            this.Text = tituloLabel.Text;
            //loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (cuadreCaja != null)
                {

                }
                else
                {
                    
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
    }
}
