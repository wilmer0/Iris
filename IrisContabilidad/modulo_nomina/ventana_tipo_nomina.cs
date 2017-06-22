using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_tipo_nomina : formBase
    {


        //objetos
        private nomina_tipo nominaTipo;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloNominaTipo modeloNominaTipo = new modeloNominaTipo();



        public ventana_tipo_nomina()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana tipos de nómina");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (nominaTipo != null)
                {
                    NominatipoIdText.Text = nominaTipo.codigo.ToString();
                    NominaTipoText.Text = nominaTipo.nombre;
                    activoCheck.Checked = Convert.ToBoolean(nominaTipo.activo);
                }
                else
                {
                    NominatipoIdText.Text = "";
                    NominaTipoText.Text = "";
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidarGetAction()
        {
            try
            {
                if (NominaTipoText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NominaTipoText.Focus();
                    NominaTipoText.SelectAll();
                    return false;
                }



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


                bool crear = false;
                if (nominaTipo == null)
                {
                    //agrega
                    crear = true;
                    nominaTipo = new nomina_tipo();
                    nominaTipo.codigo = modeloNominaTipo.getNext();
                }

                nominaTipo.nombre = NominaTipoText.Text;
                nominaTipo.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloNominaTipo.agregarNominaTipo(nominaTipo) == true)
                    {
                        nominaTipo = null;
                        loadVentana();
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloNominaTipo.modificarNominaTipo(nominaTipo) == true)
                    {
                        nominaTipo = null;
                        loadVentana();
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                nominaTipo = null;
            }
            catch (Exception ex)
            {
                nominaTipo = null;
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void ventana_tipo_nomina_Load(object sender, EventArgs e)
        {

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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            GetAction();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            nominaTipo = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_nomina ventana = new ventana_busqueda_tipo_nomina();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                nominaTipo = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
