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

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_tipo_nomina : formBase
    {


        //objetos
        private nomina_tipo nomina_tipo;
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
                if (nomina_tipo != null)
                {
                    NominatipoIdText.Text = nomina_tipo.codigo.ToString();
                    NominaTipoText.Text = nomina_tipo.nombre;
                    activoCheck.Checked = Convert.ToBoolean(nomina_tipo.activo);
                }
                else
                {
                    NominatipoIdText.Text = "";
                    NominaTipoText.Text = "";
                    activoCheck.Checked = false;
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

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (!ValidarGetAction())
                {
                    return;
                }


                bool crear = false;
                if (nomina_tipo == null)
                {
                    //agrega
                    crear = true;
                    nomina_tipo = new nomina_tipo();
                    nomina_tipo.codigo = modeloNominaTipo.getNext();
                }

                nomina_tipo.nombre = NominaTipoText.Text;
                nomina_tipo.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloNominaTipo.agregarNominaTipo(nomina_tipo) == true)
                    {
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
                    if (modeloNominaTipo.modificarNominaTipo(nomina_tipo) == true)
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                nomina_tipo = null;
            }
            catch (Exception ex)
            {
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
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetAction();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            nomina_tipo = null;
            loadVentana();
        }
    }
}
