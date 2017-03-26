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
using IrisContabilidad.modulo_empresa;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad
{
    public partial class Form1 : formBase
    {

        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        private modeloPrimerLogin modeloPrimerLogin = new modeloPrimerLogin();
        modeloActualizacion modeloActualizacion=new modeloActualizacion();

        //objetos
        private empleado empleado;
        utilidades utilidades = new utilidades();
        private singleton singleton;



        public Form1()
        {
            InitializeComponent();
            this.tituloLabel.Text = "Inicio sesión";
            this.Text = tituloLabel.Text;
            usuarioText.Select();
            utilidades.notificacionWindows("titulo prueba", "hola mundo esto es un mensaje",5);
           
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
                //modeloEmpleado.adminPrimerLogin();
                
                if (!ValidarGetAction())
                    return;
                if (MessageBox.Show("Desea procesar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                modeloPrimerLogin.validarPrimerLogin();
                modeloPrimerLogin.agregarModulos();
                modeloPrimerLogin.agregarVentanas();
                

                empleado = modeloEmpleado.getEmpleadoByLogin(usuarioText.Text.Trim(), utilidades.encriptar(claveText.Text.Trim()));

                if (empleado == null)
                {
                    limpiar();
                    return;
                }
                //empleado = modeloEmpleado.validarLogin(usuarioText.Text, claveText.Text);
                if (empleado.login != null || empleado.login!="")
                {
                    singleton.empleado = empleado;
                    menu1 ventana = new menu1(empleado);
                    ventana.Show();
                    this.Hide();
                    //MessageBox.Show(empleado.fecha_ingreso.ToString());
                }
                else
                {
                    empleado = null;
                    MessageBox.Show("Datos incorrectos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error GetAction.:", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool primerLogin()
        {
            try
            {
                string sql = "";
                sql = "select *from empresa;";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //debe ingresar todos los datos de primer login
                    modeloPrimerLogin.primerosDatos();
                    modeloPrimerLogin.agregarModulos();
                    modeloPrimerLogin.agregarVentanas();
                    modeloPrimerLogin.agregarPrimerEmpleado();
                    modeloPrimerLogin.agregarAccesosVentanas();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error primerLogin.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //modeloActualizacion.version1();
            GetAction();
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
       
    }
}
