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
    public partial class ventana_carga_documentos : formBase
    {
        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        private sucursal sucursal;


        //modelos
        modeloSucursal modeloSucursal = new modeloSucursal();

        //listas


        public ventana_carga_documentos()
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana documentos");
            this.Text = tituloLabel.Text;
        }

        private void ventana_carga_documentos_Load(object sender, EventArgs e)
        {

        }
    }
}
