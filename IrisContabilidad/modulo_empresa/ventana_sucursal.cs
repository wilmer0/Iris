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
using IrisContabilidad.modulo_sistema;
using IrisContabilidadModelo.modelos;

namespace IrisContabilidad.modulo_empresa
{
    public partial class ventana_sucursal : formBase
    {
        //modelos
        modeloSucursal modeloSucursal = new modeloSucursal();

        //objetos 
        public sucursal sucursal;
        utilidades utilidades = new utilidades();
        public empleado empleado;
        singleton singleton = new singleton();


        public ventana_sucursal()
        {
            InitializeComponent();
            this.empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "ventana sucursal");
            this.Text = tituloLabel.Text;
            LoadVentana();
        }
        public void LoadVentana()
        {
            try
            {
                if (sucursal != null)
                {
                    sucursalIdText.Text = sucursal.codigo.ToString();
                    secuenciaTet.Text = sucursal.secuencia.ToString();
                    direccionText.Text = sucursal.direccion;
                    activoCheck.Checked = (bool)sucursal.activo;
                }
                else
                {
                    sucursalIdText.Focus();
                    sucursalIdText.SelectAll();
                    sucursalIdText.Text = "";
                    secuenciaTet.Text = "";
                    direccionText.Text = "";
                    activoCheck.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override bool ValidarGetAction()
        {
            try
            {
                if (secuenciaTet.Text == "")
                {
                    MessageBox.Show("Falta la secuencia ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    secuenciaTet.Focus();
                    secuenciaTet.SelectAll();
                    return false;
                }
                if (secuenciaTet.Text.Length != 3)
                {
                    MessageBox.Show("La secuencia no esta completa ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    secuenciaTet.Focus();
                    secuenciaTet.SelectAll();
                    return false;
                }
                if (direccionText.Text == "")
                {
                    MessageBox.Show("Falta la dirección ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    direccionText.Focus();
                    direccionText.SelectAll();
                    return false;
                }
               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override void GetAction()
        {
            try
            {
                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                    DialogResult.No)
                {
                    return;
                }
                if (!ValidarGetAction())
                    return;


                if (sucursal == null)
                {
                    //agrega
                    sucursal = new sucursal();
                    sucursal.codigo = modeloSucursal.getNext();
                    sucursal.secuencia = secuenciaTet.Text.Trim();
                    sucursal.direccion = direccionText.Text.Trim();
                    sucursal.activo = (bool)activoCheck.Checked;
                    if (modeloSucursal.agregarSucursal(sucursal))
                    {
                        MessageBox.Show("Se agregó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    sucursal.secuencia = secuenciaTet.Text.Trim();
                    sucursal.direccion = direccionText.Text.Trim();
                    sucursal.activo = (bool)activoCheck.Checked;
                    if (modeloSucursal.ModificarSucursal(sucursal))
                    {
                        MessageBox.Show("Se modificó", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetAcion .:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void limpiar()
        {
            LoadVentana();
        }
        private void ventana_sucursal_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sucursal = null;
            LoadVentana();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
