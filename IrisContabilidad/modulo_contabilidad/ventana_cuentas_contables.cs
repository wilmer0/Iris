using System;
using System.Collections.Generic;
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
        modeloSistemaConfiguracion modeloSistema=new modeloSistemaConfiguracion();


        //listas
        private List<cuenta_contable> listaCuentacontable; 

        public ventana_cuentas_contables()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            singleton.obtenerDatos();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cuentas contables");
            this.Text = tituloLabel.Text;
            loadVentana(); 
            loadListaCuentascontables();
            traducirContenido();
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
                    loadCuentaPadre();

                    radioCuentaAcumulativa.Checked = (bool) cuentaContable.cuenta_acumulativa;
                    radioCuentaMovimiento.Checked = (bool) cuentaContable.cuenta_movimiento;

                    radioOrigenDebito.Checked = (bool)cuentaContable.origen_debito;
                    radioOrigenCredito.Checked = (bool) cuentaContable.origen_credito;

                    activoCheck.Checked = (bool) cuentaContable.activo;

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

        public void loadListaCuentascontables()
        {
            try
            {
                dataGridView1.Rows.Clear();
                listaCuentacontable = modeloCuentaContable.getListaCompleta();

                foreach (var x in listaCuentacontable)
                {
                    cuentaPadre = new cuenta_contable();
                    cuentaPadre.codigo =0;
                    cuentaPadre.nombre = ".";
                    if (x.codigo_cuenta_superior != 0)
                    {
                        cuentaPadre = modeloCuentaContable.getCuentaContableById(x.codigo_cuenta_superior);
                    }
                    dataGridView1.Rows.Add(x.codigo,x.numero_cuenta, x.nombre,cuentaPadre.codigo,cuentaPadre.nombre,cuentaPadre.numero_cuenta);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando las lista de cuenta contables", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                //validar cuenta padre
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
                        cuentaContable = null;
                        loadVentana();
                        loadListaCuentascontables();
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
                        loadListaCuentascontables();
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

        private void cuentaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button7_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    cuentaContable = modeloCuentaContable.getCuentaContableById(Convert.ToInt16(cuentaIdText.Text));
                    if (cuentaContable != null)
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
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                }
                if (e.KeyCode == Keys.Enter)
                {
                    numeroCuentaText.Focus();
                    numeroCuentaText.SelectAll();
                }
            }
            catch (Exception)
            {

            }
        }

        private void numeroCuentaText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                }
                if (e.KeyCode == Keys.Enter)
                {
                    cuentaPadreIdText.Focus();
                    cuentaPadreIdText.SelectAll();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cuentaPadreIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button6_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (radioCuentaAcumulativa.Checked == true)
                    {
                        radioCuentaAcumulativa.Focus();

                    }else if (radioCuentaMovimiento.Checked == true)
                    {
                        radioCuentaMovimiento.Focus();
                    }
                    else
                    {
                        radioCuentaAcumulativa.Focus();
                    }
                    cuentaPadre = modeloCuentaContable.getCuentaContableById(Convert.ToInt16(cuentaPadreIdText.Text));
                    if (cuentaPadre != null)
                    {
                        loadCuentaPadre();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void radioCuentaAcumulativa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (radioOrigenDebito.Checked == true)
                    {
                        radioOrigenDebito.Focus();    
                    
                    }else if (radioOrigenCredito.Checked == true)
                    {
                        radioOrigenCredito.Focus();
                    }
                    else
                    {
                        radioOrigenDebito.Focus();  
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void radioOrigenDebito_KeyDown(object sender, KeyEventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cuenta_contable ventana=new ventana_busqueda_cuenta_contable();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cuentaContable = ventana.getObjeto();
                loadVentana();
            }
        }

        private void radioCuentaMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    radioOrigenDebito.Focus();
                    if (radioOrigenDebito.Checked == true)
                    {
                        radioOrigenDebito.Focus();

                    }else if (radioOrigenCredito.Checked == true)
                    {
                        radioOrigenCredito.Focus();
                    }
                    else
                    {
                        radioOrigenDebito.Focus();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void radioOrigenCredito_KeyDown(object sender, KeyEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cuenta_contable ventana = new ventana_busqueda_cuenta_contable();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cuentaPadre = ventana.getObjeto();
                loadCuentaPadre();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int fila = -1;
                if (dataGridView1.Rows.Count >= 0)
                {
                    fila = dataGridView1.CurrentRow.Index;
                    if (fila >= 0)
                    {
                        cuentaContable =modeloCuentaContable.getCuentaContableById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                        loadVentana();
                        cuentaIdText.Text = "";
                        nombreText.Focus();
                        nombreText.SelectAll();
                        cuentaContable = null;
                    }
                    else
                    {
                        MessageBox.Show("No hay cuenta contable para seleccionar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No hay cuenta contable para seleccionar", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error seleccionando la cuenta contable", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensajeAyuda = "Si selecciona una de las cuentas contables de la lista inferior no modificara dicha cuenta, mas bien se utiliza como guia para crear más cuentas contables usando la cuenta seleccionada.";
            this.mensajeAyuda(mensajeAyuda);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Desea cargar un catalogo de cuentas desde un archivo de excel", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult.No == MessageBox.Show("Desea cargar un catalogo de cuentas desde un archivo de excel", "",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                return;
            }

            //la respuesta fue si




        }

        public void traducirContenido()
        {
            try
            {
                singleton.sistema = modeloSistema.getSistemaConfiguracion();
                if (singleton.sistema.codigoIdiomaSistema == 1)
                {
                    //es
                    cuenta_label.Text = idiomas.Es_do.cuenta;
                    nombre_label.Text = idiomas.Es_do.nombre;
                    numeroCuentaLabel.Text = idiomas.Es_do.noCuenta;
                    cuentaPadreLabel.Text = idiomas.Es_do.cuentaPadre;
                    radioCuentaAcumulativa.Text = idiomas.Es_do.cuentaAcumulativa;
                    radioCuentaMovimiento.Text = idiomas.Es_do.cuentaMovimiento;
                    radioOrigenDebito.Text = idiomas.Es_do.origenDebito;
                    radioOrigenCredito.Text = idiomas.Es_do.origenCredito;
                    activoCheck.Text = idiomas.Es_do.activo;

                    idColumn.HeaderText = idiomas.Es_do.id;
                    numeroCuentaColumn.HeaderText = idiomas.Es_do.numeroCuenta;
                    nombreColumn.HeaderText = idiomas.Es_do.nombre;
                    idCuentaPadreColumn.HeaderText = idiomas.Es_do.id;
                    cuentaPadreColumn.HeaderText = idiomas.Es_do.cuentaPadre;
                    numeroCuentaPadreColumn.HeaderText = idiomas.Es_do.numeroCuenta;

                }else if (singleton.sistema.codigoIdiomaSistema == 2)
                {
                    //usa
                    cuenta_label.Text = idiomas.En_us.cuenta;
                    nombre_label.Text = idiomas.En_us.nombre;
                    numeroCuentaLabel.Text = idiomas.En_us.noCuenta;
                    cuentaPadreLabel.Text = idiomas.En_us.cuentaPadre;
                    radioCuentaAcumulativa.Text = idiomas.En_us.cuentaAcumulativa;
                    radioCuentaMovimiento.Text = idiomas.En_us.cuentaMovimiento;
                    radioOrigenDebito.Text = idiomas.En_us.origenDebito;
                    radioOrigenCredito.Text = idiomas.En_us.origenCredito;
                    activoCheck.Text = idiomas.En_us.activo;

                    idColumn.HeaderText = idiomas.En_us.id;
                    numeroCuentaColumn.HeaderText = idiomas.En_us.numeroCuenta;
                    nombreColumn.HeaderText = idiomas.En_us.nombre;
                    idCuentaPadreColumn.HeaderText = idiomas.En_us.id;
                    cuentaPadreColumn.HeaderText = idiomas.En_us.cuentaPadre;
                    numeroCuentaPadreColumn.HeaderText = idiomas.En_us.numeroCuenta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error traducir contenido.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }    
        }




    }
}
