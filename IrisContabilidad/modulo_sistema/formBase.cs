using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidadModelo.modelos;
using IrisContabilidad.modulo_cuenta_por_cobrar;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_empresa;
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_inventario;
using IrisContabilidad.modulo_nomina;
using IrisContabilidad.modulo_sistema;


//carpetas modulos

namespace IrisContabilidad.modulo_sistema
{
    public partial class formBase : Form
    {
        //mover form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //objeto
        utilidades utilidades = new utilidades();
        private empleado empleado;


        public formBase()
        {
            InitializeComponent();
        }

        private void tituloLabel_Click(object sender, EventArgs e)
        {

        }
        public virtual void GetAction()
        {
            if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
        }
        public virtual void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
          Salir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tituloLabel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void formBase_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        public virtual bool ValidarGetAction()
        {
            throw new NotImplementedException();
        }

        private void formBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                GetAction();
            }
        }
    }
}
