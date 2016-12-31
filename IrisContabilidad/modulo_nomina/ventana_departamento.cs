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
    public partial class ventana_departamento : formBase
    {

        //objetos
        private departamento departamento;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloDepartamento modeloDepartamento = new modeloDepartamento();



        public ventana_departamento()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "departamento");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (departamento != null)
                {
                    departamentoIdText.Text = departamento.codigo.ToString();
                    departamentoText.Text = departamento.nombre;
                    activoCheck.Checked = Convert.ToBoolean(departamento.activo);
                }
                else
                {
                    departamentoIdText.Text = "";
                    departamentoText.Text = "";
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
                if (departamentoText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    departamentoText.Focus();
                    departamentoText.SelectAll();
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
                if (departamento == null)
                {
                    //agrega
                    crear = true;
                    departamento = new departamento();
                    departamento.codigo = modeloDepartamento.getNext();
                }

                departamento.nombre = departamentoText.Text;
                departamento.codigo_sucursal = empleado.codigo_sucursal;
                departamento.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloDepartamento.agregarDepartamento(departamento) == true)
                    {
                        departamento = null;
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
                    if (modeloDepartamento.modificarDepartamento(departamento)== true)
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                departamento = null;
            }
            catch (Exception ex)
            {
                departamento = null;
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

        private void ventana_departamento_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            departamento = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_departamento ventana = new ventana_busqueda_departamento();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                departamento = ventana.getObjeto();
                loadVentana();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
