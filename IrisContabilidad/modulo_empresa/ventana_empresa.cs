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
    public partial class ventana_empresa : formBase
    {
        //objetos
        private empleado empleado;
        utilidades utilidades=new utilidades();
        singleton singleton=new singleton();
        empresa empresa;

        //modelos
        modeloEmpresa modeloEmpresa=new modeloEmpresa();
        
        public ventana_empresa()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana empresa");
            this.Text = tituloLabel.Text;
            loadVentana();
        }


        public void loadVentana()
        {
            try
            {
                empresa=new empresa();
                empresa = modeloEmpresa.getEmpresaById(3);
                if (empresa != null)
                {
                    empresaIdText.Text = empresa.codigo.ToString();
                    empresaText.Text = empresa.nombre;
                    RncText.Text = empresa.rnc;
                    divisionText.Text = empresa.division;
                    activoCheck.Checked = Convert.ToBoolean(empresa.activo);
                }
                else
                {
                    empresaIdText.Text = "";
                    empresaText.Text = "";
                    RncText.Text = "";
                    divisionText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString());
            }
        }
        private void ventana_empresa_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void ventana_empresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                GetAction();
            }
        }

        public override bool ValidarGetAction()
        {
            try
            {
                if (empresaText.Text == "")
                {
                    MessageBox.Show("Falta el nombre.:","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    empresaText.Focus();
                    empresaText.SelectAll();
                    return false;
                }

                if (RncText.Text == "")
                {
                    MessageBox.Show("Falta el RNC.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RncText.Focus();
                    RncText.SelectAll();
                    return false;
                }
                if (divisionText.Text == "")
                {
                    MessageBox.Show("Error división.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    divisionText.Focus();
                    divisionText.SelectAll();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.:" + ex.ToString());
                return false;
            }
        }

        public override void GetAction()
        {
            //si validar me retorna false entonces no hace nada
            if (!ValidarGetAction())
            {
                return;
            }
            //hacer getAction
            empresa=new empresa();
            empresa.nombre = empresaText.Text;
            empresa.rnc = RncText.Text;
            empresa.division = divisionText.Text;
            empresa.activo = true;

            if ((modeloEmpresa.agregarEmpresa(empresa)) == true)
            {
                MessageBox.Show("Se agregó la empresa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadVentana();
            }
            else
            {
                MessageBox.Show("No se agregó la empresa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}