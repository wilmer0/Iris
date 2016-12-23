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

namespace IrisContabilidad.modulo_nomina
{
    public partial class ventana_cargo : formBase
    {

        //objetos
        private cargo cargo;
        utilidades utilidades=new utilidades();



        //modelos
        modeloCargo modeloCargo=new modeloCargo();

        public ventana_cargo()
        {
        }

        public ventana_cargo(empleado empleado)
        {
            InitializeComponent();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "cargo empleado");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        private void ventana_cargo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void loadVentana()
        {
            try
            {
                if (cargo != null)
                {
                    cargoIdText.Text = cargo.id.ToString();
                    CargoText.Text = cargo.nombre;
                    activoCheck.Checked = Convert.ToBoolean(cargo.activo);
                }
                else
                {
                    cargoIdText.Text = "";
                    CargoText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public  bool ValidarGetAction()
        {
            try
            {
                if (CargoText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargoText.Focus();
                    CargoText.SelectAll();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public  void GetAction()
        {
            try
            {
                bool crear = false;
                if (cargo == null)
                {
                    //agrega
                    crear = true;
                    cargo = new cargo();
                    cargo.id = modeloCargo.getNext();
                }

                cargo.nombre = CargoText.Text;
                cargo.activo = Convert.ToInt16(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloCargo.agregarCargo(cargo) == true)
                    {
                        cargo = null;
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
                    if (modeloCargo.modificarCargo(cargo) == true)
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                cargo = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
