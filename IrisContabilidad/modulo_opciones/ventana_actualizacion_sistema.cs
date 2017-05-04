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
    public partial class ventana_actualizacion_sistema : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private sucursal sucursal;
        
        //modelos
        modeloSucursal modeloSucursal=new modeloSucursal();
        modeloActualizacion modeloActualizacion=new modeloActualizacion();

        
        public ventana_actualizacion_sistema()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana actualizar sistema");
            this.Text = tituloLabel.Text;
            loadVentana();
        }

        public void loadVentana()
        {
            try
            {
                //saber la version actual que corre el sistema de la sucursal del empleado.
                sucursal = modeloSucursal.getSucursalByEmpleado(empleado.codigo);
                versionActualText.Text = sucursal.versionSistema.ToString();
                versionActualizarText.Text = sucursal.versionSistemaMaxima.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventana_actualizacion_sistema_Load(object sender, EventArgs e)
        {

        }

        public bool validarGetAcion()
        {
            try
            {
                if (sucursal == null)
                {
                    MessageBox.Show("Sucursal esta nulo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (sucursal.versionSistema >= sucursal.versionSistemaMaxima)
                {
                    MessageBox.Show("Ya el sistema se encuentra actualizado", "", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAcion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                if (validarGetAcion() == false)
                {
                    return;
                }

                if (MessageBox.Show("Desea actualizar a la siguiente versión?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                modeloActualizacion.actualizar(sucursal);

                sucursal = null;
                loadVentana();

            }
            catch (Exception ex)
            {
                sucursal = null;
                MessageBox.Show("Error getAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sucursal = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    
    
    }
}
