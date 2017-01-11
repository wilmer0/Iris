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
    public partial class ventana_desglose_dinero : formBase
    {
        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private desglose_dinero desgloseDinero;




        //modelos
        


        public ventana_desglose_dinero()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana desglose dinero");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (desgloseDinero != null)
                {
                    efectivoText.Text = desgloseDinero.monto_esperado.ToString("N");
                }
                else
                {
                    MessageBox.Show("No se ha detectado ninguna necesidad de movimiento de dinero", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
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
                //validar nombre que la suma de los monto sea igual al monto esperado
                //if (porcientoText.Text == "")
                //{
                //    MessageBox.Show("Falta el porciento del itbis ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    porcientoText.Focus();
                //    porcientoText.SelectAll();
                //    return false;
                //}
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
                //if (itebis == null)
                //{
                //    itebis = new itebis();
                //    crear = true;
                //    itebis.codigo = modeloItebis.getNext();
                //}
                //itebis.nombre = nombreText.Text;
                //itebis.porciento = Convert.ToDecimal(porcientoText.Text.Trim());
                //itebis.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    //if ((modeloItebis.agregarItebis(itebis)) == true)
                    //{
                    //    itebis = null;
                    //    loadVentana();
                    //    MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //else
                    //{
                    //    MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    //se modifica
                    //if ((modeloItebis.modificarItebis(itebis)) == true)
                    //{
                    //    itebis = null;
                    //    loadVentana();
                    //    MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //else
                    //{
                    //    MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }

            }
            catch (Exception ex)
            {
                desgloseDinero = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_desglose_dinero_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void efectivoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,efectivoText.Text);
        }

        private void tarjetaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, tarjetaText.Text);
        }

        private void chequeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, chequeText.Text);
        }

        private void depositoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, depositoText.Text);
        }

        private void devueltoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, devueltoText.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, descuentoText.Text);
        }
    }
}
