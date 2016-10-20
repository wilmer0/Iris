using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace puntoVenta
{
    public partial class login : FormBase
    {



        //objetos
        Sistema.menu_principal ventana = new Sistema.menu_principal();





        public login()
        {
            InitializeComponent();
            loadVentana();
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        public override void loadVentana()
        {
           
            this.tituloLabel.Text = "Inicio de Sesión";
            usuarioText.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public override void Procesar()
        {
            ventana.Owner = this;
            ventana.Show();
            this.Hide();
        }
        
    }
}
