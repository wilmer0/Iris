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

namespace IrisContabilidad
{
    public partial class Form1 : formBase
    {

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();

        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        private singleton singleton;



        public Form1()
        {
            InitializeComponent();
            this.tituloLabel.Text = "Inicio sesión";
            this.Text = tituloLabel.Text;
            usuarioText.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public override bool ValidarGetAction()
        {
            try
            {
                if (usuarioText.Text == "")
                {
                    MessageBox.Show("Falta el usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usuarioText.Focus();
                    usuarioText.SelectAll();
                    return false;
                }

                if (claveText.Text == "")
                {
                    MessageBox.Show("Falta el clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveText.Focus();
                    claveText.SelectAll();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarCampos.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void GetAction()
        {
            if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (!ValidarGetAction())
                return;

            if ((empleado = modeloEmpleado.getEmpleadoByLogin(usuarioText.Text.Trim(),utilidades.encriptar(claveText.Text.Trim()))) != null)
            {
                singleton.empleado = empleado;
                menu1 ventana = new menu1(empleado);
                ventana.Show();
                this.Hide();
                //MessageBox.Show("Existe");
            }
            else
            {
                empleado = null;
                MessageBox.Show("No existe el usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        public override void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void usuarioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                claveText.Focus();
                claveText.SelectAll();
            }
        }

        private void claveText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }










    }
}
