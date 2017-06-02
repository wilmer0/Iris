using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_opciones
{
    public partial class ventana_permisos_empleado : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleadoSingleton;
        private empleado empleado;
        private ventana ventana;
        

        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloModulo modeloModulo=new modeloModulo();
        
        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<ventana> listaVentana; 

        //variables
        private int indice = 0;


        public ventana_permisos_empleado()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana permisos empleado");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                empleado = null;
                empleadoIdText.Text = "";
                empleadoText.Text = "";
                dataGridView1.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool validarGetAcion()
        {
            try
            {

                //valiar que tenga empleado
                if (empleado == null)
                {
                    empleadoIdText.Focus();
                    empleadoIdText.SelectAll();
                    MessageBox.Show("Debe seleccionar una empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //validar que tenga un permiso seleccionado
                existe = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[2].Value) == true)
                    {
                        existe = true;
                    }
                }
                if (existe == false)
                {
                    MessageBox.Show("Debe seleccionar una ventana", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void getAction()
        {
            try
            {
                if (!validarGetAcion())
                {
                    return;
                }

                listaVentana=new List<ventana>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[2].Value) == true)
                    {
                        //MessageBox.Show("Se agrega--> " + row.Cells[0].Value.ToString());
                        ventana=new ventana();
                        ventana=modeloModulo.getVentanaById(Convert.ToInt16(row.Cells[0].Value));
                        listaVentana.Add(ventana);
                    }
                }


                //borrar todas las ventanas en la que este el usuario
                string sql = "delete from empleado_accesos_ventanas where id_empleado='"+empleado.codigo+"'";
                utilidades.ejecutarcomando_mysql(sql);

                //agregar las ventana que selecciono
                listaVentana.ForEach(x =>
                {
                    modeloModulo.agregarPermisoVentanaEmpleado(empleado.codigo,x.codigo);
                });

                MessageBox.Show("Finalizó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                listaVentana = null;
                ventana = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
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
                    loadVentanas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVentanas()
        {
            try
            {
                listaVentana = modeloModulo.getListaVentanasProgramadorNo();
                dataGridView1.Rows.Clear();
                
 
                //me trae todas las ventas disponibles
                listaVentana.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo,x.nombre_ventana);
                });

                //marcar en el grid las ventanas que el ya tiene acceso
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //verificar si el empleado tiene acceso a esta ventana actual
                    if ((modeloModulo.getAccederVentanaByEmpleadoId(empleado.codigo,Convert.ToInt16(row.Cells[0].Value.ToString()))) == true)
                    {
                        row.Cells[2].Value = true;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanasByEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ventana_permisos_empleado_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
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

        private void empleadoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button7_Click(null,null);   
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    empleado = modeloEmpleado.getEmpleadoById(Convert.ToInt16(empleadoIdText.Text));
                    loadEmpleado();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
            {
                getAction();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadVentana();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 == null || dataGridView1.Rows.Count < 0)
                {
                    return;
                }
                int fila = 0;
                fila = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[fila].Cells[2].Value = !(Convert.ToBoolean(dataGridView1.Rows[fila].Cells[2].Value));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea marcar todas las ventanas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[2].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea desmarcar todas las ventanas?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[2].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
