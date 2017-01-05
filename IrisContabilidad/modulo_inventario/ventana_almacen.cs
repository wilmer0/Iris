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

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_almacen : formBase
    {
        //objetos
        private almacen almacen;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloAlmacen modeloAlmacen = new modeloAlmacen();

        public ventana_almacen()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "Almacen");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (almacen != null)
                {
                    almacenIdText.Text = almacen.codigo.ToString();
                    nombreText.Text = almacen.nombre;
                    activoCheck.Checked = Convert.ToBoolean(almacen.activo);
                }
                else
                {
                    almacenIdText.Text = "";
                    nombreText.Text = "";
                    activoCheck.Checked = false;
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
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                almacen = null;
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
                if (almacen == null)
                {
                    //agrega
                    crear = true;
                    almacen = new almacen();
                    almacen.codigo = modeloAlmacen.getNext();
                }
                almacen.codigo_sucursal = empleado.codigo_sucursal;
                almacen.nombre = nombreText.Text;
                almacen.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloAlmacen.agregarAlmacen(almacen) == true)
                    {
                        almacen = null;
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloAlmacen.modificarAlmacen(almacen) == true)
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                almacen = null;
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

        private void ventana_almacen_Load(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            almacen = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_almacen ventana = new ventana_busqueda_almacen(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                almacen = ventana.getObjeto();
                loadVentana();
            }
        }
    }
}
