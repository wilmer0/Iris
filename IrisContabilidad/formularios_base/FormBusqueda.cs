using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace puntoVenta.formularios_base
{
    public partial class FormBusqueda : Form
    {

        //variables
        public Boolean mantenimiento = false;
        public FormBusqueda()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        private void FormBusqueda_Load(object sender, EventArgs e)
        {

        }

        public virtual void loadVentana()
        {
           
        }

        public virtual Boolean ValidarCampos()
        {

            return true;
        }

        public virtual void limpiar()
        {
            if (MessageBox.Show("Desea limpiar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }

        public virtual void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public virtual void Seleccionar()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void usuarioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }

            if (e.KeyCode == Keys.F6)
            {
                limpiar();
            }

            if (e.KeyCode == Keys.F8)
            {
                Seleccionar();
            }
        }

        private void usuarioText_KeyUp(object sender, KeyEventArgs e)
        {
            buscar();
        }

        public virtual void buscar()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Seleccionar();
        }

    }
}
