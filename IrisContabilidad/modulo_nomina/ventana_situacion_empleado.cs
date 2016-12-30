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
    public partial class ventana_situacion_empleado : formBase
    {

        //objetos
        private situacion_empleado situacion;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloSituacionEmpleado modeloSituacionEmpleado = new modeloSituacionEmpleado();


        public ventana_situacion_empleado()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "situación empleado");
            this.Text = tituloLabel.Text;
            loadVentana();

        }
        public void loadVentana()
        {
            try
            {
                if (situacion != null)
                {
                    situacionIdText.Text = situacion.codigo.ToString();
                    situacionText.Text = situacion.descripcion;
                    activoCheck.Checked = Convert.ToBoolean(situacion.activo);
                }
                else
                {
                    situacionIdText.Text = "";
                    situacionText.Text = "";
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
                if (situacionText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    situacionText.Focus();
                    situacionText.SelectAll();
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
                if (situacion == null)
                {
                    //agrega
                    crear = true;
                    situacion = new situacion_empleado();
                    situacion.codigo = modeloSituacionEmpleado.getNext();
                }

                situacion.descripcion = situacionText.Text;
                situacion.activo = Convert.ToBoolean(activoCheck.Checked);
                if (crear)
                {
                    //agrega
                    if (modeloSituacionEmpleado.agregarSituacionEmpleado(situacion) == true)
                    {
                        situacion = null;
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
                    if (modeloSituacionEmpleado.modificarSituacionEmpleado(situacion) == true)
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                situacion = null;
            }
            catch (Exception ex)
            {
                situacion = null;
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_situacion_empleado_Load(object sender, EventArgs e)
        {

        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            situacion = null;
            loadVentana();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_situacion_empleado ventana=new ventana_busqueda_situacion_empleado();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                situacion = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
