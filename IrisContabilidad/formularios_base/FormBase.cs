using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IrisContabilidad
{
    public partial class FormBase : Form
    {


        //objeto
        

        public FormBase()
        {
            InitializeComponent();
            loadVentana();
        }

       

        public virtual void loadVentana()
        {
            this.Text = "IrisCont";
            this.tituloLabel.Text = "Esto es un titulo";
            
        }

        public virtual Boolean ValidarCampos()
        {

            return true;
        }

        public virtual void limpiar()
        {
            if (MessageBox.Show("Desea limpiar los campos?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
            }
        }

        public virtual void Salir()
        {
            if(MessageBox.Show("Desea salir?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        public virtual void Procesar()
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
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
            Procesar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            
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
                Procesar();
            }
        }

        private void claveText_KeyDown(object sender, KeyEventArgs e)
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
                Procesar();
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            //panel para ocultar los controles que no quiero mostrar en los hijos en tiempo de diseño
        }

    }
}
