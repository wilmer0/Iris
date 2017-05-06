using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_nota_credito_debito_concepto : formBase
    {
        //objetos
        private nota_credito_debito_concepto concepto;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloNotaCreditoDebitoConcepto modeloConcepto = new modeloNotaCreditoDebitoConcepto();

        public ventana_nota_credito_debito_concepto()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "notas credito-debitos conceptos");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (concepto != null)
                {
                    conceptoText.Focus();
                    conceptoText.SelectAll();

                    conceptoIdText.Text = concepto.codigo.ToString();
                    conceptoText.Text = concepto.concepto;
                    detalleText.Text = concepto.detalle;
                    activoCheck.Checked = Convert.ToBoolean(concepto.activo);
                }
                else
                {
                    conceptoIdText.Focus();
                    conceptoIdText.SelectAll();

                    conceptoIdText.Text = "";
                    conceptoText.Text = "";
                    detalleText.Text = "";
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
                if (conceptoText.Text == "")
                {
                    conceptoText.Focus();
                    conceptoText.SelectAll();
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                concepto = null;
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
                if (concepto == null)
                {
                    //agrega
                    crear = true;
                    concepto = new nota_credito_debito_concepto();
                    concepto.codigo = modeloConcepto.getNext();
                }
                concepto.concepto = conceptoText.Text;
                concepto.detalle = detalleText.Text;
                concepto.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloConcepto.agregarConcepto(concepto) == true)
                    {
                        concepto = null;
                        loadVentana();
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        concepto = null;
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloConcepto.modificarConcepto(concepto) == true)
                    {
                        concepto = null;
                        loadVentana();
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                concepto = null;
            }
            catch (Exception ex)
            {
                concepto = null;
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
        private void ventana_nota_credito_debito_concepto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            concepto = null;
            loadVentana();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_nota_credito_debito_concepto ventana=new ventana_busqueda_nota_credito_debito_concepto(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if((concepto==ventana.getObjeto())!=null)
            {
                concepto = ventana.getObjeto();
                loadVentana();
            }
        }

        private void conceptoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    conceptoText.Focus();
                    conceptoText.SelectAll();

                    concepto = modeloConcepto.getConceptoById(Convert.ToInt16(conceptoIdText.Text));
                    if (concepto != null)
                    {
                        loadVentana();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void conceptoText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    detalleText.Focus();
                    detalleText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void detalleText_KeyDown(object sender, KeyEventArgs e)
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
