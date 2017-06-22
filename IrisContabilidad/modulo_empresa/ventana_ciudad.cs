using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_ciudad : formBase
    {

        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        ciudad ciudad;
      



        //modelos
        modeloCiudad modeloCiudad=new modeloCiudad();


        public ventana_ciudad()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana ciudad");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (ciudad != null)
                {
                    ciudadIdText.Text = ciudad.codigo.ToString();
                    nombreText.Text = ciudad.nombre;
                    activoCheck.Checked = Convert.ToBoolean(ciudad.activo);
                }
                else
                {
                    nombreText.Text = "";
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre de la ciudad ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
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
                if (ciudad == null)
                {
                    ciudad = new ciudad();
                    crear = true;
                    ciudad.codigo = modeloCiudad.getNext();
                }
                ciudad.nombre = nombreText.Text;
                ciudad.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCiudad.agregarCiudad(ciudad)) == true)
                    {
                        ciudad = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloCiudad.modificarCiudad(ciudad)) == true)
                    {
                        ciudad = null;
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
                ciudad = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ventana_ciudad_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ciudad = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_ciudad ventana = new ventana_busqueda_ciudad(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                ciudad = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
