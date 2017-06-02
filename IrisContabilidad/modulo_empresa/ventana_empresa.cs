using System;
using System.Windows.Forms;
using Citiport.Util.Google.Language;
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
                empresa = modeloEmpresa.getEmpresaById(1);
                if (empresa != null)
                {
                    empresaText.Focus();
                    empresaText.SelectAll();

                    empresaIdText.Text = empresa.codigo.ToString();
                    empresaText.Text = empresa.nombre;
                    RncText.Text = empresa.rnc;
                    divisionText.Text = empresa.division;
                    serieComprobanteText.Text = empresa.serie_comprobante;
                    activoCheck.Checked = Convert.ToBoolean(empresa.activo);
                }
                else
                {
                    empresaIdText.Focus();
                    empresaIdText.SelectAll();

                    empresaIdText.Text = "";
                    empresaText.Text = "";
                    RncText.Text = "";
                    divisionText.Text = "";
                    serieComprobanteText.Text = "";
                    activoCheck.Checked = true;
                }
                empresaText.Focus();
                empresaText.SelectAll();
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
            Salir();
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
            if (e.KeyCode == Keys.F2)
            {
                button3_Click(null, null);
            }
        }

        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public  bool ValidarGetAction()
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

        public  void GetAction()
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            
            //si validar me retorna false entonces no hace nada
            if (!ValidarGetAction())
            {
                return;
            }
            //hacer getAction
            empresa=new empresa();
            empresa.codigo = 1;
            empresa.nombre = empresaText.Text;
            empresa.rnc = RncText.Text;
            empresa.division = divisionText.Text;
            empresa.secuencia = "001";
            empresa.activo = true;
            empresa.serie_comprobante = serieComprobanteText.Text;

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

        private void button3_Click(object sender, EventArgs e)
        {
            empresa = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void empresaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                RncText.Focus();
                RncText.SelectAll();
            }
        }

        private void RncText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                divisionText.Focus();
                divisionText.SelectAll();
            }
        }

        private void divisionText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                activoCheck.Focus();
            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                activoCheck.Checked = !(bool)activoCheck.Checked;
            }
        }

        private void RncText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void empresaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                empresaText.Focus();
                empresaText.SelectAll();

                empresa = modeloEmpresa.getEmpresaById(Convert.ToInt16(empresaIdText.Text));
                if (empresa != null)
                {
                    loadVentana();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            localizarEmpresa();
        }

        public void localizarEmpresa()
        {
            try
            {
                //localizar la empresa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error localizando empresa.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


    }
}