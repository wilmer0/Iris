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
using IrisContabilidad.modulo_sistema;
using IrisContabilidadModelo.modelos;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_empresa : formBase
    {

        //modelos
        modeloEmpresa modeloEmpresa = new modeloEmpresa();

        //objetos 
        public empresa empresa;
        utilidades utilidades = new utilidades();
        public empleado empleado;
        singleton singleton=new singleton();



        
        public ventana_empresa()
        {
            InitializeComponent();
            this.empleado=singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana empresa");
            this.Text = tituloLabel.Text;
            LoadVentana();
        }

        private void ventana_empresa_Load(object sender, EventArgs e)
        {

        }
        public void LoadVentana()
        {
            try
            {
                //empresa = new empresa();
                empresa = modeloEmpresa.getListaCompleta().ToList().FirstOrDefault();
                if (empresa != null)
                {
                    empresaText.Text = empresa.nombre;
                    RncText.Text = empresa.rnc;
                    divisionText.Text = empresa.division;
                    activoCheck.Checked = (bool)empresa.activo;
                }
                else
                {
                    empresaText = new TextBox();
                    RncText = new TextBox();
                    divisionText = new TextBox();
                    activoCheck = new CheckBox();
                    empresaText.Text = "";
                    RncText.Text = "";
                    divisionText.Text = "";
                    activoCheck.Checked = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public override bool ValidarGetAction()
        {
            try
            {
                if (empresaText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    empresaText.Focus();
                    empresaText.SelectAll();
                    return false;
                }
                if (RncText.Text == "")
                {
                    MessageBox.Show("Falta el rnc ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RncText.Focus();
                    RncText.SelectAll();
                    return false;
                }
                if (divisionText.Text == "")
                {
                    MessageBox.Show("Falta la división ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    divisionText.Focus();
                    divisionText.SelectAll();
                    return false;
                }

                if (divisionText.Text.Length != 2)
                {
                    MessageBox.Show("La división no esta completa ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    divisionText.Focus();
                    divisionText.SelectAll();
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void GetAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                    DialogResult.No)
                {
                    return;
                }
                if (!ValidarGetAction())
                    return;


                if (empresa == null)
                {
                    //agrega
                    empresa = new empresa();
                    empresa.codigo = modeloEmpresa.getNext();
                    empresa.nombre = empresaText.Text.Trim();
                    empresa.rnc = RncText.Text.Trim();
                    empresa.division = divisionText.Text.Trim();
                    empresa.activo = (bool)activoCheck.Checked;
                    if (modeloEmpresa.agregarEmpresa(empresa))
                    {
                        MessageBox.Show("Se agrego", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    empresa.nombre = empresaText.Text.Trim();
                    empresa.rnc = RncText.Text.Trim();
                    empresa.division = divisionText.Text.Trim();
                    empresa.activo = (bool)activoCheck.Checked;
                    if (modeloEmpresa.ModificarEmpresa(empresa))
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public  void limpiar()
        {
            LoadVentana();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void empresaText_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void RncText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.textBoxNumeroEntero(e);
        }

        private void divisionText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.textBoxNumeroEntero(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
