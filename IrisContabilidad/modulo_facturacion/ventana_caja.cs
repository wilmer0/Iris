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
    public partial class ventana_caja : formBase
    {
        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        caja caja;




        //modelos
        modeloCaja modeloCaja = new modeloCaja();

        public ventana_caja()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana caja");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (caja != null)
                {
                    nombreText.Text = caja.nombre;
                    secuenciaText.Text = caja.secuencia;
                    activoCheck.Checked = Convert.ToBoolean(caja.activo);
                }
                else
                {
                    nombreText.Text = "";
                    secuenciaText.Text = "";
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
                //validar nombre
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre de la caja ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }
                //validar numero secuencia
                if (secuenciaText.Text == "")
                {
                    MessageBox.Show("Falta la secuencia de la caja", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
                    return false;
                }
                //validar tamano de la secuencia
                if (secuenciaText.Text.Length !=3)
                {
                    MessageBox.Show("La secuencia no esta completa,deben ser 2 digitos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
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
                if (caja == null)
                {
                    caja=new caja();
                    crear = true;
                    caja.codigo = modeloCaja.getNext();
                }
                caja.nombre = nombreText.Text;
                caja.secuencia = secuenciaText.Text.Trim();
                caja.codigo_sucursal = empleado.codigo_sucursal;
                caja.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCaja.agregarCaja(caja)) == true)
                    {
                        caja = null;
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
                    if ((modeloCaja.modificarCaja(caja)) == true)
                    {
                        caja = null;
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
                caja = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ventana_caja_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            caja = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_caja ventana = new ventana_busqueda_caja(true);
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                caja = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
