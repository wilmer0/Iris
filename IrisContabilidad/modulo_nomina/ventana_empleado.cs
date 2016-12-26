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




        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        public ventana_empleado()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana empleado");
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
                }
                else
                {
                    //blanquear campos
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

        public void validarGetAction()
        {
            
        }
        
        public void getAction()
        {
            
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
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.Remove(dataGridView1.Rows[fila]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminarPermiso.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
