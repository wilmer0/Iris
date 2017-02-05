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
    public partial class ventana_grupo_usuarios : formBase
    {

        //objetos
        private grupo_usuarios grupoUsuarios;
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        
        
        //modelos
        modeloGrupoUsuarios modeloGrupoUsuarios=new modeloGrupoUsuarios();

        public ventana_grupo_usuarios()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "grupo de usuarios");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (grupoUsuarios != null)
                {
                    grupoText.Focus();
                    grupoText.SelectAll();

                    grupoIdText.Text = grupoUsuarios.codigo.ToString();
                    grupoText.Text = grupoUsuarios.nombre;
                    descripcionText.Text = grupoUsuarios.detalles;
                    activoCheck.Checked = Convert.ToBoolean(grupoUsuarios.activo);
                }
                else
                {
                    grupoIdText.Focus();
                    grupoIdText.SelectAll();
                    
                    grupoIdText.Text = "";
                    grupoText.Text = "";
                    descripcionText.Text = "";
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarGetAction()
        {
            try
            {
                if (grupoText.Text == "")
                {
                    MessageBox.Show("Falta el nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grupoText.Focus();
                    grupoText.SelectAll();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                grupoUsuarios = null;
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void GetAction()
        {
            try
            {

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (!ValidarGetAction())
                {
                    return;
                }

                bool crear = false;
                if (grupoUsuarios == null)
                {
                    //agrega
                    crear = true;
                    grupoUsuarios = new grupo_usuarios();
                    grupoUsuarios.codigo = modeloGrupoUsuarios.getNext();
                }
                grupoUsuarios.detalles = descripcionText.Text;
                grupoUsuarios.nombre = grupoText.Text;
                grupoUsuarios.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear)
                {
                    //agrega
                    if (modeloGrupoUsuarios.agregarGrupoUsuario(grupoUsuarios) == true)
                    {
                        grupoUsuarios = null;
                        loadVentana();
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //actualiza
                    if (modeloGrupoUsuarios.modificarGrupoUsuario(grupoUsuarios) == true)
                    {
                        grupoUsuarios = null;
                        loadVentana();
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                grupoUsuarios = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ventana_grupo_usuarios_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void grupoIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    grupoText.Focus();
                    grupoText.SelectAll();


                    grupoUsuarios = modeloGrupoUsuarios.getGrupoUsuarioById(Convert.ToInt16(grupoIdText.Text));
                    loadVentana();
                }
            }
            catch (Exception)
            {
            }
        }
        private void grupoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                descripcionText.Focus();
                descripcionText.SelectAll();
            }
        }

        private void descripcionText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                activoCheck.Focus();
                
            }
        }

        private void activoCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                button1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grupoUsuarios = null;
            loadVentana();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_grupo_usuario ventana = new ventana_busqueda_grupo_usuario(true);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                grupoUsuarios = ventana.getObjeto();
                loadVentana();
            }
        }

        private void activoCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
