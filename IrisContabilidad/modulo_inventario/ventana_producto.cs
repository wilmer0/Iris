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

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_producto : formBase
    {

        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        itebis itebis;
        unidad unidad;



        //modelos
        modeloItebis modeloItebis = new modeloItebis();
        modeloUnidad modeloUnidad=new modeloUnidad();

        public ventana_producto()
        {
            InitializeComponent();
        }

        private void ventana_producto_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ventana_busqueda_itbis ventana = new ventana_busqueda_itbis();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                itebis = ventana.getObjeto();
               
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,puntoMaximoText.Text);
        }

        private void puntoReordenText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e, puntoReordenText.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
