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

namespace IrisContabilidad.modulo_opciones
{
    public partial class ventana_cambio_clave : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;


        //modelos
        modeloEmpleado modeloEmpleado = new modeloEmpleado();


        public ventana_cambio_clave()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana cambio clave");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                usuarioLabelText.Text = "Usuario.:"+empleado.nombre;

                claveActualText.Focus();
                claveActualText.SelectAll();

                claveActualText.Clear();
                claveNuevaText.Clear();
                claveConfirmarText.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public bool ValidarGetAction()
        {
            try
            {
                //clave actual
                if (claveActualText.Text == "")
                {
                    MessageBox.Show("Falta la clave actual", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveActualText.Focus();
                    claveActualText.SelectAll();
                    return false;
                }
                //clave1
                if (claveNuevaText.Text == "")
                {
                    MessageBox.Show("Falta la clave nueva", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveNuevaText.Focus();
                    claveNuevaText.SelectAll();
                    return false;
                }
                //clave2
                if (claveConfirmarText.Text == "")
                {
                    MessageBox.Show("Falta la confirmación de la nueva clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveConfirmarText.Focus();
                    claveConfirmarText.SelectAll();
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

                //cambiar la clave
                if (modeloEmpleado.cambiarClave(empleado,claveActualText.Text,claveNuevaText.Text,claveConfirmarText.Text) == true)
                {
                    MessageBox.Show("Se efectuó el cambio correctamente", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
                   button3_Click_1(null,null);
                }
                else
                {
                    claveActualText.Focus();
                    claveActualText.SelectAll();
                    MessageBox.Show("No se efectuó el cambio", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
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
        private void ventana_cambio_clave_Load(object sender, EventArgs e)
        {

        }

        private void activoCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void claveActualText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                claveNuevaText.Focus();
                claveNuevaText.SelectAll();
            }
        }

        private void claveNuevaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                claveConfirmarText.Focus();
                claveConfirmarText.SelectAll();
            }
        }

        private void claveConfirmarText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            loadVentana();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }
    }
}
