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

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_empleado : formBase
    {

        //objetos
        private empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private situacion_empleado situacion;
        private sucursal sucursal;
        private departamento departamento;
        private cargo cargo;
        private nomina_tipo nominaTipo;
        private grupo_usuarios grupoUsuarios;
        


        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloSucursal modeloSucursal=new modeloSucursal();
        modeloCargo modeloCargo=new modeloCargo();
        modeloDepartamento modeloDepartamento=new modeloDepartamento();
        modeloNominaTipo modeloTipoNomina=new modeloNominaTipo();
        modeloSituacionEmpleado modeloSituacionEmpleado=new modeloSituacionEmpleado();



        public ventana_empleado()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana empleado");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        private void ventana_empleado_Load(object sender, EventArgs e)
        {

        }
        public void loadVentana()
        {
            try
            {
                if (empleado != null)
                {
                    //llenar campos
                    nombreText.Text = empleado.nombre;
                    identificacionText.Text = empleado.identificacion;
                    usuarioText.Text=empleado.login;
                    claveText.Text = utilidades.desencriptar(empleado.clave);
                    sucursal = modeloSucursal.getSucursalById(empleado.codigo_sucursal);
                    loadSucursal();
                    departamento = modeloDepartamento.getDepartamentoById(empleado.codigo_departamento);
                    loadDepartamento();
                    cargo = modeloCargo.getCargoById(empleado.codigo_cargo);
                    loadCargo();
                    fechaIngreso.Text = empleado.fecha_ingreso.ToString();
                    empleado.codigo_grupo_usuario = 1;
                    nominaTipo = modeloTipoNomina.getNominaTipoById(empleado.codigo_tipo_nomina);
                    loadNominaTipo();
                    sueldoText.Text = empleado.sueldo.ToString();
                    situacion = modeloSituacionEmpleado.getSituacionEmpleadoById(empleado.codigo_situacion);
                    loadSituacionEmpleado();
                    activoCheck.Checked = Convert.ToBoolean(empleado.activo);
                }
                else
                {
                    //blanquear campos
                    nombreText.Text = "";
                    identificacionText.Text = "";
                    usuarioText.Text = "";
                    claveText.Text = "";
                    sucursalIdText.Text = "";
                    sucursalText.Text = "";
                    departamentoIdText.Text = "";
                    departamentoText.Text = "";
                    cargoIdText.Text = "";
                    cargoText.Text = "";
                    fechaIngreso.Value = DateTime.Today;
                    nominaTipoIdText.Text = "";
                    nominaTipoText.Text = "";
                    sueldoText.Text = "";
                    situacionIdText.Text = "";
                    situacionText.Text = "";
                    activoCheck.Checked =false;
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
                //validar usuario
                if (usuarioText.Text == "")
                {
                    MessageBox.Show("Falta el nombre de usuario ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usuarioText.Focus();
                    usuarioText.SelectAll();
                    return false;
                }
                //validar clave
                if (usuarioText.Text == "")
                {
                    MessageBox.Show("Falta la clave ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    usuarioText.Focus();
                    usuarioText.SelectAll();
                    return false;
                }
                //validar sucursal
                if (sucursal == null)
                {
                    MessageBox.Show("Falta la sucursal ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sucursalIdText.Focus();
                    sucursalIdText.SelectAll();
                    return false;
                }
                //validar departamento
                if (departamento==null)
                {
                    MessageBox.Show("Falta el departamento ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    departamentoIdText.Focus();
                    departamentoIdText.SelectAll();
                    return false;
                }
                //validar cargo
                if (cargo==null)
                {
                    MessageBox.Show("Falta el cargo ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cargoIdText.Focus();
                    cargoIdText.SelectAll();
                    return false;
                }
                //validar tipo nomina
                if (nominaTipo == null)
                {
                    MessageBox.Show("Falta el tipo de nómina ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nominaTipoIdText.Focus();
                    nominaTipoIdText.SelectAll();
                    return false;
                }
                //validar sueldo
                if (sueldoText.Text == "")
                {
                    MessageBox.Show("Falta el sueldo ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sueldoText.Focus();
                    sueldoText.SelectAll();
                    return false;
                }
                //validar situacion empleado
                if (situacion == null)
                {
                    MessageBox.Show("Falta la situación empleado ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    situacionIdText.Focus();
                    situacionIdText.SelectAll();
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
                if (empleado == null)
                {
                    empleado = new empleado();
                    crear = true;
                    empleado.codigo = modeloEmpleado.getNext();
                }
                empleado.nombre = nombreText.Text;
                empleado.identificacion = identificacionText.Text;
                empleado.login = usuarioText.Text;
                empleado.clave = utilidades.encriptar(claveText.Text);
                empleado.codigo_sucursal = sucursal.codigo;
                empleado.codigo_cargo = cargo.id;
                empleado.fecha_ingreso = Convert.ToDateTime(fechaIngreso.Text);
                empleado.codigo_grupo_usuario = 1;
                empleado.codigo_tipo_nomina = nominaTipo.codigo;
                empleado.sueldo = Convert.ToDecimal(sueldoText.Text);
                empleado.codigo_situacion = situacion.codigo;
                empleado.codigo_departamento = departamento.codigo;
                empleado.activo= Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloEmpleado.agregarEmpleado(empleado)) == true)
                    {
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        empleado = null;
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloEmpleado.modificarEmpleado(empleado)) == true)
                    {
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        empleado = null;
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        public void loadSucursal()
        {
            try
            {
                if (sucursal != null)
                {
                    sucursalIdText.Text = sucursal.codigo.ToString();
                    sucursalText.Text = sucursal.secuencia;
                }
                else
                {
                    sucursalIdText.Text = "";
                    sucursalText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSucursal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadDepartamento()
        {
            try
            {
                if (departamento != null)
                {
                    departamentoIdText.Text = departamento.codigo.ToString();
                    departamentoText.Text = departamento.nombre;
                }
                else
                {
                    departamentoIdText.Text = "";
                    departamentoText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadDepartamento.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCargo()
        {
            try
            {
                if (cargo != null)
                {
                    cargoIdText.Text = cargo.id.ToString();
                    cargoText.Text = cargo.nombre;
                }
                else
                {
                    cargoIdText.Text = "";
                    cargoText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCargo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadNominaTipo()
        {
            try
            {
                if (nominaTipo != null)
                {
                    nominaTipoIdText.Text = nominaTipo.codigo.ToString();
                    nominaTipoText.Text = nominaTipo.nombre;
                }
                else
                {
                    nominaTipoIdText.Text = "";
                    nominaTipoText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadNominaTipo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSituacionEmpleado()
        {
            try
            {
                if (situacion != null)
                {
                    situacionIdText.Text = situacion.codigo.ToString();
                    situacionText.Text = situacion.descripcion;
                }
                else
                {
                    situacionIdText.Text = "";
                    situacionText.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSituacionEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ventana_busqueda_sucursal ventana=new ventana_busqueda_sucursal();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                sucursal = ventana.getObjeto();
                loadSucursal();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_departamento ventana = new ventana_busqueda_departamento();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                departamento = ventana.getObjeto();
                loadDepartamento();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cargo ventana = new ventana_busqueda_cargo();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cargo = ventana.getObjeto();
                loadCargo();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ventana_busqueda_tipo_nomina ventana = new ventana_busqueda_tipo_nomina();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                nominaTipo = ventana.getObjeto();
                loadNominaTipo();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ventana_busqueda_situacion_empleado ventana = new ventana_busqueda_situacion_empleado();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                situacion = ventana.getObjeto();
                loadSituacionEmpleado();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            empleado = null;
            loadVentana();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroEntero(e);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void agregarPermiso()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarPermiso.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void eliminarPermiso()
        {
            try
            {
                //validar que tenga filas el datagrid
                if (dataGridView1.Rows.Count < 0)
                {
                    return;
                }
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.Remove(dataGridView1.Rows[fila]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminarPermiso.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            agregarPermiso();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            eliminarPermiso();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_empleado ventana = new ventana_busqueda_empleado();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                empleado = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
