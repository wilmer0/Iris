using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_sistema
{
    public partial class formBase : Form
    {
        public formBase()
        {
            InitializeComponent();
        }

        private void tituloLabel_Click(object sender, EventArgs e)
        {

        }
        public virtual void GetAction()
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
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
        private void button2_Click(object sender, EventArgs e)
        {
          Salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }
    }
}
