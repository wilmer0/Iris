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
                    conceptoText.Focus();
                    conceptoText.SelectAll();

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
    }
}
