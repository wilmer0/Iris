using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_nomina;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace IrisContabilidad.modulo_sistema
{
    public partial class menu1 : formBase
    {

        //variable
        private string rutaProyectoActual = Directory.GetCurrentDirectory() + @"\";
        private string RutaImagenesVentanas = "";
        private string RutaImagenesModulos = "";
        Dictionary<string, Form> Ins = new Dictionary<string, Form>(); // Se Gurdan aqui los formularios que hayan sido abiertos para no volver a llamarlos
        private int anchoVentana = 0;
        private int altoVentana = 0;
        private int anchoModulo = 0;
        private int altoModulo = 0;
        private bool inicioSesion = false;

        //objetos
        private singleton singleton;
        private modulo modulo;
        private ventana ventana;
        private empleado empleado;
        private utilidades utilidades = new utilidades();
        private Button botonModulo;
        private Button botonVentana;
        private tamano_pantalla tamanoPantalla;//obtiene las dimensiones de la pantalla
        private sistemaConfiguracion sistemaConfiguracion;
        private tipoVentana tipoVentana;


        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloModulo modeloModulo=new modeloModulo();
        modeloTipoVentana modeloTipoVentana=new modeloTipoVentana();
        modeloSistemaConfiguracion modeloSistemaConfiguracion=new modeloSistemaConfiguracion();

        //listas
        private List<string> listaTemp;
        private List<modulo> listaModulo; 
        private List<ventana> listaVentanas;
        private List<ventana> listaVentanasCompleta;
        private List<ventana> listaVentanaCompletaTemporal;


        public menu1(empleado empleadoApp)
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            //this.empleado = empleadoApp;
            this.sistemaConfiguracion = modeloSistemaConfiguracion.getSistemaConfiguracion();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "menú");
            this.Text = tituloLabel.Text;
            RutaImagenesVentanas = rutaProyectoActual + @"Resources\ventanas\";
            RutaImagenesModulos = rutaProyectoActual + @"Resources\modulos\";
            LoadVentana();
            loadTodasVentanas("");
        }
        public void LoadVentana()
        {
            try
            {
                validarSistema();
                tipoVentana=new tipoVentana();
                tipoVentana = modeloTipoVentana.getTipoVentanaById(empleado.tipoVentana);

                actualizarNotificacionesSistema();
                //cargar todos los modulos que tiene habilitados el empleado con todas las ventanas que tiene habilitadas
                loadModulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void loadTodasVentanas(string ventanaNombre)
        {
            try
            {
                listaVentanaCompletaTemporal = new List<ventana>(); 
                    
                if (listaVentanasCompleta == null)
                {
                    listaVentanasCompleta = new List<ventana>();
                    listaVentanasCompleta = modeloModulo.getListaVentanasProgramadorNo();
                }
                else
                {
                    if (ventanaNombre != "")
                    {
                        listaVentanaCompletaTemporal = listaVentanasCompleta.FindAll(x => x.nombre_ventana.ToLower().Contains(ventanaNombre.ToLower()));
                    }
                }

                foreach (var x in listaVentanasCompleta)
                {
                    //si el empleado no tiene acceso a la ventana actual se elimina de la lista
                    if ((modeloModulo.getAccederVentanaByEmpleadoId(empleado.codigo, x.codigo)) == false)
                    {
                        listaVentanaCompletaTemporal.Remove(x);
                    }
                }

                cargarListaVentanas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error loadTotasVentanas.: " + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void cargarListaVentanas()
        {
            try
            {
                if (flowLayoutVentanas.Controls.Count > 0)
                {
                    flowLayoutVentanas.Controls.Clear();
                }

                List<Button> listaBotonesVentanas = new List<Button>();
                foreach (var ventanaActual in listaVentanaCompletaTemporal)
                {
                    #region
                    botonVentana = new Button();
                    ventana = new ventana();
                    ventana.codigo = ventanaActual.codigo;
                    ventana = modeloModulo.getVentanaById(ventana.codigo);


                    //estableciendo el estilo del boton
                    botonVentana.FlatStyle = FlatStyle.Flat;
                    botonVentana.BackgroundImageLayout = ImageLayout.Stretch;
                    botonVentana.Width = tipoVentana.tamanoVentanaAncho;
                    botonVentana.Height = tipoVentana.tamanoVentanaAlto;


                    //dando estilo al texto del boton
                    //izquierda-arriba-derecha-abajo
                    Padding espacio = new Padding(25, 25, 25, 25);
                    botonVentana.Margin = espacio;
                    botonVentana.TextAlign = ContentAlignment.BottomCenter;
                    botonVentana.Text = ventana.nombre_ventana;
                    botonVentana.ForeColor = Color.White;
                    botonVentana.Font = new Font(botonVentana.Font.FontFamily.Name, tipoVentana.tamanoModuloLetra);
                    botonVentana.MouseHover += BotonVentanaOnMouseHover;
                    botonVentana.MouseLeave += BotonVentanaOnMouseLeave;


                    //estableciendo la imagen de fondo del boton
                    botonVentana.BackgroundImage = Image.FromFile(RutaImagenesVentanas + ventana.imagen);
                    botonVentana.Tag = ventana.codigo;
                    botonVentana.Click += BotonVentanaOnClick;

                    listaBotonesVentanas.Add(botonVentana);
                    

                    #endregion
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
                MessageBox.Show("Error cargarListaVentanas .:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        public void validarSistema()
        {
            try
            {
                //validar sistema si el sistema no es full debe ver la fecha de vencimiento para saber si caduco la version de prueba
                sistemaConfiguracion = modeloSistemaConfiguracion.getSistemaConfiguracion();
                if (sistemaConfiguracion.sistemaFull == false)
                {
                    DateTime hoy = DateTime.Today;
                    if (sistemaConfiguracion.fechaVencimientoSistema != null)
                    {
                        if (hoy <= sistemaConfiguracion.fechaVencimientoSistema)
                        {
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("La version de prueba se ha terminado, por favor contacte con el encargado, si desea mandar un correo automatico solicitando la version full pulse el boton de 'YES'", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                //se manda el correo automatico solitando que instalen la version full y se cierra la aplicacion
                                Application.Exit();
                            }
                            else
                            {
                                Application.Exit();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta la fecha de ingreso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validando sistema .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                //agregando los modulos visibles y que tiene acceso
                listaTemp = new List<string>();
                listaModulo = new List<modulo>();
                listaTemp = modeloEmpleado.GetListaModulosByEmpleado(empleado);
                List<string> listaTempVentanas = new List<string>();

                //estableciendo tamano altura del flow layaout para modulos
                flowLayoutModulos.Height = tipoVentana.tamanoModuloAlto + 20;
                flowLayoutModulos.Top += 20;

                //limpiar el layout de modulos para empezar agregar
                if (flowLayoutModulos.Controls.Count > 0)
                {
                    flowLayoutModulos.Controls.Clear();
                }

                foreach(var moduloActual in listaTemp)
                {
                    //MessageBox.Show("Modulo actual-> " + modulo);
                    //instanciando el modulo actual
                    modulo = new modulo();
                    modulo = modeloModulo.getModuloByid(Convert.ToInt16(moduloActual));
                    botonModulo = new Button();
                    botonModulo.FlatStyle = FlatStyle.Flat;
                    botonModulo.BackgroundImageLayout = ImageLayout.Stretch;
                    botonModulo.Width = tipoVentana.tamanoModuloAncho;
                    botonModulo.Height = tipoVentana.tamanoModuloAlto;
                    botonModulo.BackgroundImage = Image.FromFile(RutaImagenesModulos + modulo.imagen);
                    botonModulo.Click += BotonModuloOnClick;
                    botonModulo.Tag = moduloActual;
                    //letras
                    botonModulo.TextAlign = ContentAlignment.BottomCenter;
                    botonModulo.Text = modulo.nombre;
                    botonModulo.ForeColor = Color.White;
                    botonModulo.Font = new Font(botonModulo.Font.FontFamily.Name, tipoVentana.tamanoModuloLetra);
                    flowLayoutModulos.Controls.Add(botonModulo);
                    
                }
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
                string sql = "select distinct mv.id_modulo,v.id_ventana_sistema from empleado_accesos_ventanas v join modulos_vs_ventanas mv on v.id_ventana_sistema=mv.id_ventana where mv.id_modulo='"+idModulo+"' and v.id_empleado='" + empleado.codigo + "'";
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
                    botonVentana.Width = tipoVentana.tamanoVentanaAncho;
                    botonVentana.Height = tipoVentana.tamanoVentanaAlto;
                    
                    
                    //dando estilo al texto del boton
                    //izquierda-arriba-derecha-abajo
                    Padding espacio=new Padding(25,25,25,25);
                    botonVentana.Margin= espacio;
                    botonVentana.TextAlign = ContentAlignment.BottomCenter;
                    botonVentana.Text = ventana.nombre_ventana;
                    botonVentana.ForeColor = Color.White;
                    botonVentana.Font = new Font(botonVentana.Font.FontFamily.Name, tipoVentana.tamanoModuloLetra);
                    botonVentana.MouseHover+= BotonVentanaOnMouseHover;
                    botonVentana.MouseLeave+= BotonVentanaOnMouseLeave;
                    
                    
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

        private void BotonVentanaOnMouseLeave(object sender, EventArgs eventArgs)
        {
            try
            {
                Button boton = new Button();
                boton = (Button)sender;

                boton.FlatAppearance.BorderSize = 0;
                boton.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error hover de la ventana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BotonVentanaOnMouseHover(object sender, EventArgs eventArgs)
        {
            try
            {
                Button boton = new Button();
                boton = (Button)sender;
                boton.FlatAppearance.BorderSize = 10;
                boton.FlatAppearance.BorderColor = Color.Tomato;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error hover de la ventana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                MessageBox.Show("Error instanciando la ventana "+ventana.nombre_logico+" .:" + ex.ToString(), "", MessageBoxButtons.OK,
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
            inicioSesion = true;
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
                MessageBox.Show("Error actualizarNotificacionesSistema.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void menu1_Load_1(object sender, EventArgs e)
        {
            LoadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            ventana_informacion ventana=new ventana_informacion();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void flowLayoutModulos_Paint(object sender, PaintEventArgs e)
        {
        }

        private void menu1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inicioSesion == false)
            {
                e.Cancel = true;    
            }
        }

        private void menu1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void busquedaText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    loadTodasVentanas(busquedaText.Text);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error buscando", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
