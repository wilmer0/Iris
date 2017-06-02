using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_tipo_gastos : formBase
    {

        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        tipo_gasto tipoGasto;




        //modelos
        modeloTipoGasto modeloTipoGastos = new modeloTipoGasto();


        public ventana_tipo_gastos()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana tipo de gastos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (tipoGasto != null)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    tipoIdText.Text = tipoGasto.id.ToString();
                    nombreText.Text = tipoGasto.nombre;
                    activoCheck.Checked = Convert.ToBoolean(tipoGasto.activo);
                }
                else
                {
                    tipoIdText.Focus();
                    tipoIdText.SelectAll();

                    tipoIdText.Text = "";
                    nombreText.Text = "";
                    activoCheck.Checked = true;
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
                    MessageBox.Show("Falta el nombre del tipo de gasto", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
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
                if (tipoGasto == null)
                {
                    tipoGasto = new tipo_gasto();
                    crear = true;
                    tipoGasto.id = modeloTipoGastos.getNext();
                }
                tipoGasto.nombre = nombreText.Text;
                tipoGasto.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloTipoGastos.agregarTipoGasto(tipoGasto)) == true)
                    {
                        tipoGasto = null;
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
                    if ((modeloTipoGastos.modificarTipoGasto(tipoGasto)) == true)
                    {
                        tipoGasto = null;
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
                tipoGasto = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_tipo_gastos_Load(object sender, EventArgs e)
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
            tipoGasto = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_gastos ventana=new ventana_busqueda_tipo_gastos(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult== DialogResult.OK)
            {
                tipoGasto = ventana.getObjeto();
                loadVentana();
            }
        }

        private void tipoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();


                    tipoGasto = modeloTipoGastos.getTipoGastoById(Convert.ToInt16(tipoIdText.Text));
                    loadVentana();
                }
            }
            catch (Exception)
            {
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    activoCheck.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
