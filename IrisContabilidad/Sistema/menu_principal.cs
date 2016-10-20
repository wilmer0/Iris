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
namespace puntoVenta.Sistema
{
    public partial class menu_principal : FormBase
    {



        //variables
       
        string codigoModuloPresionado = "";
        string codigoVentanaPresionada = "";
        int top = 100;
        int left = 0;
        string carpetaImagenes = Directory.GetCurrentDirectory();


        public menu_principal()
        {
            InitializeComponent();
            loadVentana();
        }

        private void menu_principal_Load(object sender, EventArgs e)
        {

        }
        public void cargarModulosBotones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                string sql = "select ruta_imagen_productos from sistema";
                DataSet ds = Clases.utilidades.ejecutarcomando(sql);
                string rutaImagen = "";
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    rutaImagen = ds.Tables[0].Rows[0][0].ToString();
                }

                sql = "select codigo,descripcion,nombre_logico,imagen from sistema_modulos where estado='1'";
                ds = Clases.utilidades.ejecutarcomando(sql);
                int contador = 0;
                int top = 100;
                int left = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    
                    Button botonModulo = new Button();
                    //botonModulo.Text = row[0].ToString() + "-" + row[1].ToString();
                    botonModulo.Tag = row[0].ToString();
                    botonModulo.Width = 148;
                    botonModulo.Height = 112;
                    botonModulo.Tag = row[0].ToString();


                    //crear el evento click del boton modulo
                    botonModulo.Click += eventoClickBotonModulo;
                    botonModulo.FlatStyle = FlatStyle.Flat;
                   
                    //botonModulo.BackgroundImage = Image.FromFile(@"D:\wilmer\developer\github\data\DLR-POS\proyecto\prueba\fotos_productos\empresa.png");
                    if (row[3].ToString() != "")
                    {
                        botonModulo.BackgroundImage = Image.FromFile(rutaImagen + @"\" + row[3].ToString());
                        botonModulo.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    
                    flowLayoutPanel1.Controls.Add(botonModulo);             
                    
                }
                // MessageBox.Show("Desde "+desde.ToString()+" hasta "+hasta.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error cargando los botones del modulo: "+ex.ToString());
            }
        }

        private void eventoClickBotonModulo(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                //MessageBox.Show(btn.Tag.ToString());
                codigoModuloPresionado = btn.Tag.ToString(); //para tener el codigo
                cargarBotonesDelModulo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en el evento click de boton modulo");
            }
        }

        public void cargarBotonesDelModulo()
        {
            try
            {

            //    if (codigoModuloPresionado.ToString() == null)
            //        return;
                  flowLayoutPanel2.Controls.Clear();
            //    string sql = "select codigo,descripcion,cod_modulo,nombre_logico,imagen from sistema_modulo_opciones where estado='1' and cod_modulo='"+codigoModuloPresionado.ToString()+"'";
            //    DataSet ds = Clases.utilidades.ejecutarcomando(sql);
            //    string rutaImagen = "";
            //    if (ds.Tables[0].Rows[0][0].ToString() != "")
            //    {
            //        rutaImagen = ds.Tables[0].Rows[0][0].ToString();
            //    }

            //    int contador = 0;
            //    int top = 100;
            //    int left = 0;
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {

            //        Button botonModulo = new Button();
            //        //botonModulo.Text = row[0].ToString() + "-" + row[1].ToString();
            //        botonModulo.Tag = row[0].ToString();
            //        botonModulo.Width = 109;
            //        botonModulo.Height = 99;
            //        botonModulo.Tag = row[0].ToString();


            //        //crear el evento click del boton modulo
            //        //botonModulo.Click += eventoClickBotonModulo;
            //        botonModulo.FlatStyle = FlatStyle.Flat;

            //        //botonModulo.BackgroundImage = Image.FromFile(@"D:\wilmer\developer\github\data\DLR-POS\proyecto\prueba\fotos_productos\empresa.png");
            //        if (row[4].ToString() != "")
            //        {
            //            botonModulo.BackgroundImage = Image.FromFile(rutaImagen + @"\" + row[3].ToString());
            //            botonModulo.BackgroundImageLayout = ImageLayout.Stretch;
            //        }

            //        flowLayoutPanel2.Controls.Add(botonModulo);

            //    }
            //    // MessageBox.Show("Desde "+desde.ToString()+" hasta "+hasta.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los botones del modulo: " + ex.ToString());
            }
        }
        public override void loadVentana()
        {
            try
            {
                //cargarModulosBotones();
                cargarModulosBotones();
                

            }
            catch(Exception ex)
            {
                //MessageBox.Show("Error: "+ex.ToString());
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
