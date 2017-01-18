using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.modulo_empresa;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_categoria_cliente : formBase
    {
        public ventana_categoria_cliente()
        {
            InitializeComponent();
        }

        private void ventana_categoria_cliente_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_categoria_cliente ventana = new ventana_busqueda_categoria_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                //cate = ventana.getObjeto();
                //loadve();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
