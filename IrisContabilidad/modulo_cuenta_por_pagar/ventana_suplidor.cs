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
using IrisContabilidad.modulo_empresa;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_pagar
{
    public partial class ventana_suplidor : formBase
    {

        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        suplidor suplidor;
        private tipo_gasto tipoGasto;
        private ciudad ciudad;

        //modelos
        modeloSuplidor modeloSuplidor = new modeloSuplidor();
        modeloCiudad modeloCiudad=new modeloCiudad();
        modeloTipoGasto modeloTipoGasto=new modeloTipoGasto();
        
        
        public ventana_suplidor()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana suplidor");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        //load ciudad
        public void loadCiudad()
        {
            try
            {
                if (ciudad != null)
                {
                    ciudadIdText.Text = ciudad.codigo.ToString();
                    ciudadText.Text = ciudad.nombre;
                }
                else
                {
                    ciudadIdText.Text = "";
                    ciudadText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCiudad.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //load tipo gasto
        public void loadTipoGasto()
        {
            try
            {
                if (tipoGasto != null)
                {
                    tipoGastoIdText.Text = tipoGasto.id.ToString();
                    tipoGastoText.Text = tipoGasto.nombre;
                }
                else
                {
                    tipoGastoIdText.Text = "";
                    tipoGastoText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadTipoGasto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVentana()
        {
            try
            {
                if (suplidor != null)
                {
                    //llenar campos
                    nombreText.Focus();
                    nombreText.SelectAll();


                    nombreText.Text = suplidor.nombre;
                    rncText.Text = suplidor.rnc;
                    telefono1Text.Text = suplidor.telefono1;
                    telefono2Text.Text = suplidor.telefono2;
                    faxText.Text = suplidor.fax;
                    ciudad = modeloCiudad.getCiudadById(suplidor.codigo_ciudad);
                    loadCiudad();
                    tipoGasto = modeloTipoGasto.getTipoGastoById(suplidor.cod_tipo_gasto);
                    loadTipoGasto();
                    direccionText.Text = suplidor.direccion;
                    limiteCreditoText.Text = suplidor.limite_credito.ToString("N");
                    activoCheck.Checked = Convert.ToBoolean(suplidor.activo);
                }
                else
                {
                    //blanquear campos
                    suplidorIdText.Focus();
                    suplidorIdText.SelectAll();

                    nombreText.Text = "";
                    rncText.Text = "";
                    telefono1Text.Text = "";
                    telefono2Text.Text = "";
                    faxText.Text = "";
                    ciudad = null;
                    ciudadIdText.Text = "";
                    ciudadText.Text = "";;
                    tipoGasto = null;
                    tipoGastoIdText.Text = "";
                    tipoGastoText.Text = "";
                    direccionText.Text = "";
                    limiteCreditoText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar nombre
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }
                //validar la ciudad
                if (ciudad == null)
                {
                    MessageBox.Show("Falta la ciudad", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ciudadIdText.Focus();
                    ciudadIdText.SelectAll();
                    return false;
                }
                //validar limite credito
                if (limiteCreditoText.Text == "")
                {
                    MessageBox.Show("Falta el limite de credito", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limiteCreditoText.Focus();
                    limiteCreditoText.SelectAll();
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

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                bool crear = false;
                //se instancia el empleado si esta nulo
                if (suplidor == null)
                {
                    suplidor = new suplidor();
                    crear = true;
                    suplidor.codigo = modeloSuplidor.getNext();
                    suplidor.fecha_creacion = DateTime.Today;
                    suplidor.codigo_sucursal_creado = empleadoSingleton.codigo_sucursal;
                }
                suplidor.fecha_modificacion = DateTime.Today;
                suplidor.nombre = nombreText.Text;
                suplidor.rnc = rncText.Text;
                suplidor.telefono1 = telefono1Text.Text;
                suplidor.telefono2 = telefono2Text.Text;
                suplidor.fax = faxText.Text;
                suplidor.limite_credito = Convert.ToDecimal(limiteCreditoText.Text);
                suplidor.codigo_ciudad = ciudad.codigo;
                suplidor.cod_tipo_gasto = tipoGasto.id;
                suplidor.direccion = direccionText.Text;
                suplidor.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloSuplidor.agregarSuplidor(suplidor)) == true)
                    {
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suplidor = null;
                        loadVentana();
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    suplidor.fecha_modificacion = DateTime.Today;
                    if ((modeloSuplidor.modificarSuplidor(suplidor)) == true)
                    {
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        suplidor = null;
                        loadVentana();
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                suplidor = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void ventana_suplidor_Load(object sender, EventArgs e)
        {

        }

        private void sueldoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
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
            suplidor = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void rncText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void telefono1Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void telefono2Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void faxText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ventana_busqueda_ciudad ventana = new ventana_busqueda_ciudad();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                ciudad = ventana.getObjeto();
                loadCiudad();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_gasto ventana = new ventana_busqueda_tipo_gasto();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                tipoGasto = ventana.getObjeto();
                loadTipoGasto();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_suplidor ventana = new ventana_busqueda_suplidor(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                suplidor = ventana.getObjeto();
                loadVentana();
            }
        }

        private void suplidorIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    suplidor = modeloSuplidor.getSuplidorById(Convert.ToInt16(suplidorIdText.Text));
                    if (suplidor != null)
                    {
                        loadVentana();
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                rncText.Focus();
                rncText.SelectAll();
            }
        }

        private void rncText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                telefono1Text.Focus();
                telefono1Text.SelectAll();
            }
        }

        private void telefono1Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                telefono2Text.Focus();
                telefono2Text.SelectAll();
            }
        }

        private void telefono2Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                faxText.Focus();
                faxText.SelectAll();
            }
        }

        private void faxText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                limiteCreditoText.Focus();
                limiteCreditoText.SelectAll();
            }
        }

        private void limiteCreditoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ciudadIdText.Focus();
                ciudadIdText.SelectAll();
            }
        }

        private void ciudadIdText_TextChanged(object sender, EventArgs e)
        {

        }

        private void ciudadIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button8_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    tipoGastoIdText.Focus();
                    tipoGastoIdText.SelectAll();


                    ciudad = modeloCiudad.getCiudadById(Convert.ToInt16(ciudadIdText.Text));
                    ciudadIdText.Text="";
                    ciudadText.Text="";
                    loadCiudad();
                }
            }
            catch (Exception)
            {
            }
        }

        private void tipoGastoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    direccionText.Focus();
                    direccionText.SelectAll();

                    tipoGasto = modeloTipoGasto.getTipoGastoById(Convert.ToInt16(tipoGastoIdText.Text));
                    tipoGastoIdText.Text = "";
                    tipoGastoText.Text = "";
                    loadTipoGasto();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ciudadIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void tipoGastoIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }

        private void direccionText_KeyDown(object sender, KeyEventArgs e)
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
        }
    }
}
