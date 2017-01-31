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

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_sucursal : formBase
    {
        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private sucursal sucursal;


        //modelos
        modeloSucursal modeloSucursal=new modeloSucursal();

        //listas



        public ventana_sucursal()
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana sucursal");
            this.Text = tituloLabel.Text;
        }

        private void ventana_sucursal_Load(object sender, EventArgs e)
        {

        }
        private void ventana_sucursal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_sucursal ventana=new ventana_busqueda_sucursal();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult==DialogResult.OK)
            {
                sucursal = ventana.getObjeto();
                loadVentana();    
            }
        }

        public void loadVentana()
        {
            try
            {
                if (sucursal != null)
                {
                    sucursalIdText.Text = sucursal.codigo.ToString();
                    secuenciaText.Text = sucursal.secuencia.ToString();
                    direccionText.Text = sucursal.direccion;
                    activoCheck.Checked = (bool) sucursal.activo;
                }
                else
                {
                    sucursalIdText.Text = "";
                    secuenciaText.Text = "";
                    direccionText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void secuenciaText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        public bool validarGetAction()
        {
            try
            {
                if (secuenciaText.Text == "")
                {
                    MessageBox.Show("Falta la secuencia", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    secuenciaText.Focus();
                    secuenciaText.SelectAll();
                    return false;
                }
                if (direccionText.Text == "")
                {
                    MessageBox.Show("Falta la dirección", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    direccionText.Focus();
                    direccionText.SelectAll();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
        public void getAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //validando campos no esten vacios
                if (!validarGetAction() == true)
                {
                    return;
                }

                bool crear = false;
                if (sucursal == null)
                {
                    //se agrega
                    crear = true;
                    sucursal = new sucursal();
                    sucursal.codigo = modeloSucursal.getNext();
                }
                    sucursal.codigo_empresa = 1;
                    sucursal.secuencia = secuenciaText.Text;
                    sucursal.activo = Convert.ToBoolean(activoCheck.Checked);
                    sucursal.direccion = direccionText.Text;

                if (crear == true)
                {
                    if ((modeloSucursal.agregarSucursal(sucursal)) == true)
                    {
                        sucursal = null;
                        loadVentana();
                        MessageBox.Show("Se agregó la sucursal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó la sucursal.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if ((modeloSucursal.modificarSucursal(sucursal)) == true)
                    {
                        sucursal = null;
                        loadVentana();
                        MessageBox.Show("Se modificó la sucursal.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó la sucursal.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                sucursal = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ventana_sucursal_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                getAction();
            }
            if (e.KeyCode == Keys.F2)
            {
                button3_Click_1(null, null);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            sucursal = null;
            loadVentana();
            sucursalIdText.Focus();
            sucursalIdText.SelectAll();
        }
    }
}
