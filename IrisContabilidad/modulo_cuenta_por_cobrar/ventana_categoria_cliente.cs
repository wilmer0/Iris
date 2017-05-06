using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_categoria_cliente : formBase
    {
        //objetos
        empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        categoria_cliente categoriaCliente;




        //modelos
        modeloCategoriaCliente modeloCategoriaCliente = new modeloCategoriaCliente();

        public ventana_categoria_cliente()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana categoria cliente");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (categoriaCliente != null)
                {
                    categoriaIdText.Text = categoriaCliente.codigo.ToString();
                    nombreText.Focus();
                    nombreText.SelectAll();
                    nombreText.Text = categoriaCliente.nombre;
                    activoCheck.Checked = Convert.ToBoolean(categoriaCliente.activo);
                }
                else
                {
                    categoriaIdText.Focus();
                    categoriaIdText.SelectAll();
                    categoriaIdText.Text = "";
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
                    MessageBox.Show("Falta el nombre de la categoria ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (categoriaCliente == null)
                {
                    categoriaCliente = new categoria_cliente();
                    crear = true;
                    categoriaCliente.codigo = modeloCategoriaCliente.getNext();
                }
                categoriaCliente.nombre = nombreText.Text;
                categoriaCliente.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloCategoriaCliente.agregarCategoriaCliente(categoriaCliente)) == true)
                    {
                        categoriaCliente = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        categoriaCliente = null;
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloCategoriaCliente.modificarCategoriaCliente(categoriaCliente)) == true)
                    {
                        categoriaCliente = null;
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
                categoriaCliente = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_categoria_cliente_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_categoria_cliente ventana = new ventana_busqueda_categoria_cliente(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                categoriaCliente = ventana.getObjeto();
                loadVentana();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            categoriaCliente = null;
            loadVentana();
        }

        private void categoriaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                nombreText.Focus();
                nombreText.SelectAll();
            }
            if (e.KeyCode == Keys.F1)
            {
                button4_Click(null,null);
            }
        }

        private void categoriaIdText_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void categoriaIdText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                nombreText.Focus();
                nombreText.SelectAll();
            }
        }

        private void nombreText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                activoCheck.Focus();
            }
        }

        private void activoCheck_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }
    }
}
