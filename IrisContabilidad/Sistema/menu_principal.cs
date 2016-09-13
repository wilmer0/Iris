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



        //variables
        string codigoModuloPresionado = "";
        string codigoVentanaPresionada = "";


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
            try
            {
                string carpetaImagenes = Directory.GetCurrentDirectory();
                carpetaImagenes += @"\Resources\Imagenes\";
                MessageBox.Show(carpetaImagenes);
                //cargar modulos
                string sql = "select codigo,descripcion,nombre_logico,imagen from sistema_modulos where estado='1'";
                DataSet ds = Clases.utilidades.ejecutarcomando(sql);
                foreach (DataRow rowModulo in ds.Tables[0].Rows)
                {
                    Button botonModulo = new Button();
                    botonModulo.Width = 148;
                    botonModulo.Height = 112;
                    if (rowModulo[3].ToString() != "")
                    {
                        botonModulo.BackgroundImage = Image.FromFile(carpetaImagenes + rowModulo[3].ToString());
                    }
                    botonModulo.Tag = rowModulo[0].ToString();
                    flowLayoutPanel1.Controls.Add(botonModulo);


                    //cargar ventana de cada modulo
                    //string cmd = "select codigo,descripcion,cod_modulo,nombre_logico,imagen from sistema_modulo_opciones where estado='1' and cod_modulo='1'";
                    //DataSet ds2 = Clases.utilidades.ejecutarcomando(cmd);
                    //Button botonVentana = new Button();
                    //botonVentana.Width = 148;
                    //botonVentana.Height = 112;
                    //if (ds2.Tables[0].Rows[0][4].ToString() != "")
                    //{
                    //    botonVentana.BackgroundImage = Image.FromFile(carpetaImagenes + ds2.Tables[0].Rows[0][4].ToString());
                    //}
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString());
            }
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

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
