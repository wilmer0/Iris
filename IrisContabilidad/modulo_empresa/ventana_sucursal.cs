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
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_sucursal : formBase
    {
        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();

        public ventana_sucursal()
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana sucursal");
            this.Text = tituloLabel.Text;
        }

        private void ventana_sucursal_Load(object sender, EventArgs e)
        {

        }
        private void ventana_sucursal_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
