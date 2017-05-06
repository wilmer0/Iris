using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_opciones
{
    public partial class ventana_tipo_ventana : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        tipoVentana tipoVentana;



        //modelos
        modeloTipoVentana modeloTipoVentana=new modeloTipoVentana();
        modeloEmpleado modeloEmpleado=new modeloEmpleado();

        //listas
        private List<tipoVentana> listaTipoVentana; 


        public ventana_tipo_ventana()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "configuración iconos menú");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                listaTipoVentana=new List<tipoVentana>();
                listaTipoVentana = modeloTipoVentana.getListaCompleta();
                comboBoxTipoVentana.DataSource = listaTipoVentana;
                comboBoxTipoVentana.DisplayMember = "nombre";
                comboBoxTipoVentana.ValueMember = "codigo";
                comboBoxTipoVentana.SelectedIndex = 0;
                getSizeVentanaModulo();
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

        private void getSizeVentanaModulo()
        {
            try
            {
                tipoVentana = modeloTipoVentana.getTipoVentanaById(Convert.ToInt16(comboBoxTipoVentana.SelectedValue));
                ventana.Width = tipoVentana.tamanoVentanaAncho;
                ventana.Height = tipoVentana.tamanoVentanaAlto;

                modulo.Width = tipoVentana.tamanoModuloAncho;
                modulo.Height = tipoVentana.tamanoModuloAlto;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error getSizeVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar nombre
                if (empleado == null)
                {
                    MessageBox.Show("No se ha detectado el empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (comboBoxTipoVentana.Text == "")
                {
                    comboBoxTipoVentana.Focus();
                    comboBoxTipoVentana.SelectAll();
                    MessageBox.Show("Falta el tipo de ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                empleado.tipoVentana = Convert.ToInt16(comboBoxTipoVentana.SelectedValue);
                if (modeloEmpleado.modificarEmpleado(empleado) == true)
                {
                    MessageBox.Show("Se agregó, para ver el cambio debe salir e iniciar sesión nuevamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                tipoVentana = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_tipo_ventana_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void comboBoxTipoVentana_TextChanged(object sender, EventArgs e)
        {
            getSizeVentanaModulo();
        }

        private void ventana_tipo_ventana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //salir
                button2_Click(null, null);
            }
            if (e.KeyCode == Keys.F1)
            {
                //proceso
                button1_Click(null, null);
            }
            if (e.KeyCode == Keys.F5)
            {
                //limpiar
                button3_Click(null, null);
            }
        }
    }
}
