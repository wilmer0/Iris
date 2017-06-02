using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_empresa;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad
{
    public partial class Form1 : formBase
    {

        //variables
        private string usuarioS;
        private string claveS;
        private bool inicioSesion = false;

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        private modeloPrimerLogin modeloPrimerLogin = new modeloPrimerLogin();
        modeloActualizacion modeloActualizacion=new modeloActualizacion();
        modeloSistemaConfiguracion modeloSistemaConfiguracion=new modeloSistemaConfiguracion();

        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        private singleton singleton;
        private sistemaConfiguracion sistemaConfiguracion;

        //Proceso
        private ventana_procesando procesando;
        private BackgroundWorker SicronizarProceso = new BackgroundWorker();


        public Form1()
        {
            InitializeComponent();
            this.tituloLabel.Text = "Sign in";
            this.Text = tituloLabel.Text;
            usuarioText.Focus();
            usuarioText.Select();


            SicronizarProceso.WorkerReportsProgress = true;
            SicronizarProceso.DoWork += LoadReporte;
            SicronizarProceso.ProgressChanged += ProcesoRun;
            SicronizarProceso.RunWorkerCompleted += ProcesoCompleto;

            usuarioText.GotFocus += UsuarioTextOnGotFocus;
            usuarioText.LostFocus += UsuarioTextOnLostFocus;
        }

        private void UsuarioTextOnLostFocus(object sender, EventArgs eventArgs)
        {
            usuarioText = utilidades.placeHolder(usuarioText, "user name", Color.LightGray, Color.Black);
        }

        private void UsuarioTextOnGotFocus(object sender, EventArgs eventArgs)
        {
            usuarioText = utilidades.placeHolder(usuarioText, "user name", Color.LightGray,Color.Black);
        }

        private void LoadReporte(object sender, DoWorkEventArgs e)
        {
            SicronizarProceso.ReportProgress(10);
            try
            {
                GetAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error imprimiendo.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcesoRun(object sender, ProgressChangedEventArgs e)
        {
            if (procesando == null)
            {
                procesando = new ventana_procesando();
                procesando.ShowDialog();
            }
        }

        private void ProcesoCompleto(object sender, RunWorkerCompletedEventArgs e)
        {
            procesando.Close();
            procesando = null;
            if (inicioSesion == true)
            {
                this.Hide();
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
                    DateTime hoy=DateTime.Today;
                    if (sistemaConfiguracion.fechaVencimientoSistema != null)
                    {
                        if (hoy <= sistemaConfiguracion.fechaVencimientoSistema)
                        {
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("La version de prueba se ha terminado, por favor contacte con el encargado, si desea mandar un correo automatico solicitando la version full pulse el boton de 'YES'","", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                MessageBox.Show("Error validando sistema .:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public  bool ValidarGetAction()
        {
            try
            {
                if (usuarioText.Text == "")
                {
                    MessageBox.Show("Falta el usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    usuarioText.Focus();
                    usuarioText.SelectAll();
                    return false;
                }

                if (claveText.Text == "")
                {
                    MessageBox.Show("Falta el clave", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    claveText.Focus();
                    claveText.SelectAll();
                    return false;
                }
                usuarioS = usuarioText.Text;
                claveS = claveText.Text;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarCampos.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void ValidarCrearPrimeraEmpresa()
        {
            try
            {
                string sql = "select *from empresa";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //debe crear la primera empresa
                    ventana_empresa ventana=new ventana_empresa();
                    ventana.Owner = this;
                    ventana.ShowDialog();
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error validarPrimeraEmpresa.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ValidarCrearPrimeraSucursal()
        {
            try
            {
                string sql = "select *from sucursal";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //debe crear la primera empresa
                    ventana_sucursal ventana = new ventana_sucursal();
                    ventana.Owner = this;
                    ventana.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error validarPrimeraEmpresa.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        public  void GetAction()
        {
            try
            {
                if (ValidarGetAction() == false)
                {
                    return;
                }
                //modeloEmpleado.adminPrimerLogin();
                modeloPrimerLogin.validarPrimerLogin();
                empleado = modeloEmpleado.getEmpleadoByLogin(usuarioS, utilidades.encriptar(claveS));

                if(empleado == null)
                {
                    limpiar();
                    return;
                }
                if (empleado.login != null || empleado.login!="")
                {
                    inicioSesion = true;
                    singleton.empleado = empleado;
                    menu1 ventana = new menu1(empleado);
                    ventana.Show();
                    this.Hide();
                }
                else
                {
                    inicioSesion = false;
                    empleado = null;
                    MessageBox.Show("Datos incorrectos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.:"+ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void limpiar()
        {
            try
            {
                usuarioText.Clear();
                claveText.Clear();
                usuarioText.Focus();
                usuarioText.SelectAll();
            }
            catch (Exception)
            {

            }
        }
        
        public  void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void usuarioText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                claveText.Focus();
                claveText.SelectAll();
            }
        }

        private void claveText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null,null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //modeloActualizacion.version1();
            //GetAction();
            if (!ValidarGetAction())
            {
                return;
            }
            GetAction();
            //SicronizarProceso.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_informacion ventana=new ventana_informacion();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetAction();
        }

        private void usuarioText_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    claveText.Focus();
                    claveText.SelectAll();
                }
            }
            catch (Exception)
            {
            }
        }

        private void claveText_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button1.Focus();
                }
            }
            catch (Exception)
            {
            }
        }

        private void usuarioText_Leave(object sender, EventArgs e)
        {
        }

        


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void usuarioText_KeyUp(object sender, KeyEventArgs e)
        {
        }

    }
}
