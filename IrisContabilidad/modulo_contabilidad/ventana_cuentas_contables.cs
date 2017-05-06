using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_contabilidad
{
    public partial class ventana_cuentas_contables : formBase
    {
        //objetos
        singleton singleton = new singleton();
        utilidades utilidades = new utilidades();
        empleado empleado;
        private cuenta_contable cuentaContable;
        private cuenta_contable cuentaPadre;

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCuentaContable modeloCuentaContable=new modeloCuentaContable();

        public ventana_cuentas_contables()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cuentas contables");
            this.Text = tituloLabel.Text;
            loadVentana(); 
        }
        public void loadVentana()
        {
            try
            {
                if (cuentaContable != null)
                {
                    //llena
                    nombreText.Focus();
                    nombreText.SelectAll();

                    cuentaIdText.Text = cuentaContable.codigo.ToString();
                    nombreText.Text = cuentaContable.nombre;
                    numeroCuentaText.Text = cuentaContable.numero_cuenta;
                    cuentaPadre=new cuenta_contable();
                    cuentaPadre = modeloCuentaContable.getCuentaContableById(cuentaContable.codigo_cuenta_superior);


                }
                else
                {
                    //limpia
                    cuentaIdText.Focus();
                    cuentaIdText.SelectAll();

                    cuentaIdText.Text = "";
                    nombreText.Text = "";
                    numeroCuentaText.Text = "";
                    cuentaPadre = null;
                    cuentaPadreIdText.Text = "";
                    cuentaPadreText.Text = "";
                    radioCuentaAcumulativa.Checked = true;
                    radioCuentaMovimiento.Checked = false;

                    radioOrigenDebito.Checked = true;
                    radioOrigenCredito.Checked = false;
                    activoCheck.Checked = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCuentaPadre()
        {
            try
            {
                cuentaPadreIdText.Text = "";
                cuentaPadreText.Text = "";
                if (cuentaPadre != null)
                {
                    cuentaPadreIdText.Text = cuentaPadre.codigo.ToString();
                    cuentaPadreText.Text = cuentaPadre.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCuentaPadre.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (nombreText.Text=="")
                {
                    nombreText.Focus();
                    nombreText.SelectAll();
                    MessageBox.Show("Falta el nombre de la cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar numero cuenta
                if (numeroCuentaText.Text == "")
                {
                    numeroCuentaText.Focus();
                    numeroCuentaText.SelectAll();
                    MessageBox.Show("Falta el número de la cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar cuent apadre
                if (cuentaPadre == null)
                {
                    cuentaPadreIdText.Focus();
                    cuentaPadreIdText.SelectAll();
                    MessageBox.Show("Falta la cuenta padre", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (cuentaContable == null)
                {
                    cuentaContable = new cuenta_contable();
                    crear = true;
                    cuentaContable.codigo = modeloCuentaContable.getNext();
                    cuentaContable.activo = true;

                }
                cuentaContable.nombre = nombreText.Text;
                cuentaContable.numero_cuenta = numeroCuentaText.Text;
                cuentaContable.codigo_cuenta_superior = cuentaPadre.codigo;
                cuentaContable.cuenta_acumulativa = (bool) radioCuentaAcumulativa.Checked;
                cuentaContable.cuenta_movimiento = (bool)radioCuentaMovimiento.Checked;
                cuentaContable.origen_credito = (bool)radioOrigenCredito.Checked;
                cuentaContable.origen_debito = (bool)radioOrigenDebito.Checked;

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCuentaContable.agregarCuentaContable(cuentaContable) == true))
                    {
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cuentaContable = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloCuentaContable.modificarCuentaContable(cuentaContable) == true))
                    {
                        loadVentana();
                        MessageBox.Show("Se modificó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                cuentaContable = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_cuentas_contables_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            cuentaContable = null;
            loadVentana();
        }
    }
}
