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
    public partial class ventana_empleado : formBase
    {

        //objetos
        private empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();


        public ventana_empleado()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana empleado");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        private void ventana_empleado_Load(object sender, EventArgs e)
        {

        }
        public void loadVentana()
        {
            try
            {
                if (empleado != null)
                {
                    //llenar campos
                }
                else
                {
                    //blanquear campos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        public void salir()
        {
            
        }

        public void validarGetAction()
        {
            
        }
        
        public void getAction()
        {
            
        }

       

    }
}
