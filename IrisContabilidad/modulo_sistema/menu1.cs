using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;
using empleado = IrisContabilidad.clases.empleado;


namespace IrisContabilidad.modulo_sistema
{
    public partial class menu1 : formBase
    {

        //variable
        private string rutaProyectoActual = Directory.GetCurrentDirectory() + @"\";
        private string RutaImagenesVentanas = "";
        private string RutaImagenesModulos = "";
        Dictionary<string, Form> Ins = new Dictionary<string, Form>(); // Se Gurdan aqui los formularios que hayan sido abiertos para no volver a llamarlos




        //objetos
        private empleado empleado;
        private utilidades utilidades = new utilidades();
        private Button botonModulo;
        private Button botonVentana;

        //modelos
      


        //listas
       




        public menu1(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = empleadoApp;
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "menú");
            this.Text = tituloLabel.Text;
            RutaImagenesVentanas = rutaProyectoActual + @"Resources\ventanas\";
            RutaImagenesModulos = rutaProyectoActual + @"Resources\modulos\";
            LoadVentana();

        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public void loadModulos()
        {
            try
            {
               
               

                //limpiar el layout de modulos para empezar agregar
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadModulos.: " + ex.ToString(), "", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
        public void loadVentanas(int idModulo)
        {
            try
            {

                //obteniendo las ventanas que son del modulo presionado
               
                //limpiar el flowlayout con las ventanas viejas
                if (flowLayoutVentanas.Controls.Count > 0)
                {
                    flowLayoutVentanas.Controls.Clear();
                }

                //agregando las ventanas nuevas al flow layout
             




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadVentana()
        {
            try
            {
                //cargar todos los modulos que tiene habilitados el empleado con todas las ventanas que tiene habilitadas
                loadModulos();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Salir();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        public override void Salir()
        {
            Form1 ventana = new Form1();
            ventana.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void flowLayoutVentanas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ventana_cargo ventana=new ventana_cargo(empleado);
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
