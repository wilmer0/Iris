using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IrisContabilidad.clases;

//carpetas modulos

namespace IrisContabilidad.modulo_sistema
{
    public partial class formBase : Form
    {

        //mover form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);







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

      

      

        private void formBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //salir
                this.button2_Click(null,null);
            }
            if (e.KeyCode == Keys.F2)
            {
                //proceso
                this.button1_Click(null, null);
            }
            if (e.KeyCode == Keys.F5)
            {
                //limpiar
                this.button3_Click(null, null);
            }
        }

        

        private void formBase_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void mensajeAyuda(string mensaje)
        {
            MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
