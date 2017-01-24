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
using System.Windows;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;
using empleado = IrisContabilidad.clases.empleado;
using MessageBox = System.Windows.Forms.MessageBox;


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
        private singleton singleton;
        private modulo modulo;
        private ventana ventana;
        private empleado empleado;
        private utilidades utilidades = new utilidades();
        private Button botonModulo;
        private Button botonVentana;

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloModulo modeloModulo=new modeloModulo();


        //listas
        private List<string> listaTemp;
        private List<modulo> listaModulo; 
        private List<ventana> listaVentanas; 




        public menu1(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
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
        private void BotonModuloOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                Button boton = (Button) sender;
                //MessageBox.Show(boton.Tag.ToString());
                loadVentanas(Convert.ToInt16(boton.Tag));
            }
            catch (Exception)
            {
                MessageBox.Show("Error haciendo click en el módulo", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadModulos()
        {
            try
            {
                listaTemp = new List<string>();
                listaModulo = new List<modulo>();
                listaTemp = modeloEmpleado.GetListaModulosByEmpleado(empleado);
                List<string> listaTempVentanas = new List<string>();

                //limpiar el layout de modulos para empezar agregar
                if (flowLayoutModulos.Controls.Count > 0)
                {
                    flowLayoutModulos.Controls.Clear();
                }

                listaTemp.ForEach(moduloActual =>
                {
                    //MessageBox.Show("Modulo actual-> " + modulo);
                    //instanciando el modulo actual
                    modulo = new modulo();
                    modulo = modeloModulo.getModuloByid(Convert.ToInt16(moduloActual));
                    botonModulo = new Button();
                    botonModulo.FlatStyle = FlatStyle.Flat;
                    botonModulo.BackgroundImageLayout = ImageLayout.Stretch;
                    botonModulo.Width = 165;
                    botonModulo.Height = 140;
                    botonModulo.BackgroundImage = Image.FromFile(RutaImagenesModulos + modulo.imagen);
                    botonModulo.Click += BotonModuloOnClick;
                    botonModulo.Tag = moduloActual;
                    //letras
                    botonModulo.TextAlign = ContentAlignment.BottomCenter;
                    botonModulo.Text = modulo.nombre;
                    botonModulo.ForeColor = Color.White;
                    botonModulo.Font = new Font(botonModulo.Font.FontFamily.Name, 19);
                    flowLayoutModulos.Controls.Add(botonModulo);

                });
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
                //limpiar el flowlayout con las ventanas viejas
                if (flowLayoutVentanas.Controls.Count > 0)
                {
                    flowLayoutVentanas.Controls.Clear();
                }

                //select de las ventanas con el modulo presionado
                //agregando las ventanas nuevas al flow layout
                string sql = "SELECT id_modulo,id_ventana from modulos_vs_ventanas where id_modulo='"+idModulo+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                List<Button> listaBotonesVentanas=new List<Button>();
                foreach (DataRow rowVentana  in ds.Tables[0].Rows)
                {
                    botonVentana = new Button();
                    ventana=new ventana();
                    ventana.codigo = Convert.ToInt16(rowVentana[1].ToString());
                    ventana = modeloModulo.getVentanaById(ventana.codigo);
                    
                    
                    //estableciendo el estilo del boton
                    botonVentana.FlatStyle = FlatStyle.Flat;
                    botonVentana.BackgroundImageLayout = ImageLayout.Stretch;
                    botonVentana.Width = 200;
                    botonVentana.Height = 170;
                    
                    
                    //dando estilo al texto del boton
                    botonVentana.TextAlign = ContentAlignment.BottomCenter;
                    botonVentana.Text = ventana.nombre_ventana;
                    botonVentana.ForeColor = Color.White;
                    botonVentana.Font = new Font(botonVentana.Font.FontFamily.Name, 20);
                    
                    
                    
                    //estableciendo la imagen de fondo del boton
                    botonVentana.BackgroundImage = Image.FromFile(RutaImagenesVentanas + ventana.imagen);
                    botonVentana.Tag = ventana.codigo;
                    botonVentana.Click += BotonVentanaOnClick;
                    
                    listaBotonesVentanas.Add(botonVentana);
                    //flowLayoutVentanas.Controls.Add(botonVentana);
                }
                //ordenar las ventanas en orden alfabetico
                listaBotonesVentanas = listaBotonesVentanas.OrderBy(x => x.Text).ToList();
                listaBotonesVentanas.ForEach(x =>
                {
                    flowLayoutVentanas.Controls.Add(x);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotonVentanaOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                Button boton = new Button();
                boton = (Button)sender;
                ventana = new ventana();
                ventana = modeloModulo.getVentanaById(Convert.ToInt16(boton.Tag));
                if (ventana != null)
                {
                    Assembly asm = Assembly.GetEntryAssembly();
                    Type formtype = asm.GetType(ventana.nombre_logico);
                    Form f = (Form)Activator.CreateInstance(formtype);
                    f.Owner = this;
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error instanciando la ventana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void LoadVentana()
        {
            try
            {
                actualizarNotificacionesSistema();
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
        public  void Salir()
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
            ventana_cargo ventana=new ventana_cargo();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void menu1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void notificacionesBoton_Click(object sender, EventArgs e)
        {

        }

        public void actualizarNotificacionesSistema()
        {
            try
            {
                //notificacionesBoton.BackColor=Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error actualizarNotificacionesSistema.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void menu1_Load_1(object sender, EventArgs e)
        {
            LoadVentana();
        }
    }
}
