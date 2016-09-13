using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
namespace IrisContabilidad.Sistema
{
    public partial class menu_principal : FormBase
    {
        public menu_principal()
        {
            InitializeComponent();
            loadVentana();
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {

        }
        public override void loadVentana()
        {
            
            this.tituloLabel.Text = "Menú principal";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Contabilidad.catalogo_cuentas ventana = new Contabilidad.catalogo_cuentas();
            ventana.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form ventana=new Form();
            Type tipoObjeto= Type.GetType("IrisContabilidad.Sistema.menu_principal");
            Object objeto = Activator.CreateInstance(tipoObjeto);
            ventana = (Form)objeto;
            ventana.Show();            
        }
    }
}
