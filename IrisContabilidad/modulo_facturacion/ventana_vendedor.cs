using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_vendedor : formBase
    {

        //objetos
        empleado empleado;
        private vendedor vendedor;
        private empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        caja caja;




        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloVendedor modeloVendedor=new modeloVendedor();



        public ventana_vendedor()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana vendedor");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (vendedor != null)
                {

                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();

                    vendedorIdText.Text=vendedor.codigo.ToString();
                    empleado = modeloEmpleado.getEmpleadoById(vendedor.codigo_empelado);
                    loadEmpleado();
                    porcientoText.Text = vendedor.porciento_ganancia.ToString("N");
                    activoCheck.Checked = Convert.ToBoolean(vendedor.activo);
                }
                else
                {
                    vendedorIdText.Focus();
                    vendedorIdText.SelectAll();

                    vendedor = null;
                    vendedorIdText.Text = "";

                    empleadoIdText.Text = "";
                    empleadoText.Text = "";
                    empleado = null;


                    porcientoText.Text = "0.00";
                    
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void loadEmpleado()
        {
            try
            {
                empleadoIdText.Text = "";
                empleadoText.Text = "";
                if (empleado != null)
                {
                    empleadoIdText.Text = empleado.codigo.ToString();
                    empleadoText.Text = empleado.nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //validar empleado
                if (empleado==null)
                {
                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();
                    MessageBox.Show("Falta el empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar porciento
                if (porcientoText.Text == "")
                {
                    porcientoText.Focus();
                    porcientoText.SelectAll();
                    MessageBox.Show("Falta el porciento", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //validar porciento numerico
                decimal numero;
                if (decimal.TryParse(porcientoText.Text, out numero)==false)
                {
                    porcientoText.Focus();
                    porcientoText.SelectAll();
                    MessageBox.Show("El porciento debe ser numerico", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (vendedor == null)
                {
                    vendedor = new vendedor();
                    crear = true;
                    vendedor.codigo = modeloVendedor.getNext();
                }
                vendedor.codigo_empelado = empleado.codigo;
                vendedor.porciento_ganancia = Convert.ToDecimal(porcientoText.Text);
                vendedor.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloVendedor.agregarVendedor(vendedor)) == true)
                    {
                        vendedor = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        vendedor = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloVendedor.modificarVendedor(vendedor)) == true)
                    {
                        vendedor = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                caja = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_vendedor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vendedor = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_vendedor ventana = new ventana_busqueda_vendedor();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                vendedor = ventana.getObjeto();
                loadVentana();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_empleado ventana=new ventana_busqueda_empleado();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                empleado = ventana.getObjeto();
                loadEmpleado();
            }
        }

        private void empleadoIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void vendedorIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void porcientoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,porcientoText.Text);
        }

        private void empleadoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode== Keys.Tab)
                {
                    porcientoText.Focus();
                    porcientoText.SelectAll();

                    empleado = modeloEmpleado.getEmpleadoById(Convert.ToInt16(empleadoIdText.Text));
                    loadEmpleado();
                }
            }
            catch (Exception)
            {
            }
        }

        private void vendedorIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();

                    vendedor = modeloVendedor.getVendedorById(Convert.ToInt16(vendedorIdText.Text));
                    loadVentana();
                }
            }
            catch (Exception)
            {
            }
        }

        private void porcientoText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    activoCheck.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void activoCheck_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
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
