using System;
using System.Windows.Forms;

namespace IrisContabilidad.modulo_sistema
{
    public partial class ventana_informacion : formBase
    {
        public ventana_informacion()
        {
            InitializeComponent();
            this.Text = "Ventana información";
            this.tituloLabel.Text = this.Text;
        }

        private void ventana_informacion_Load(object sender, EventArgs e)
        {

        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }
    }
}
