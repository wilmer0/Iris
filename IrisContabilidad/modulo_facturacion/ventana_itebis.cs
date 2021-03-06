﻿using System;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_itebis : formBase
    {
        //objetos
        empleado empleadoSingleton;
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        itebis itebis;




        //modelos
        modeloItebis modeloItebis= new modeloItebis();



        public ventana_itebis()
        {
            InitializeComponent();
            empleadoSingleton = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleadoSingleton, "ventana itbis");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                if (itebis != null)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    itbisIdText.Text = itebis.codigo.ToString();
                    nombreText.Text = itebis.nombre;
                    porcientoText.Text = itebis.porciento.ToString("N");
                    activoCheck.Checked = Convert.ToBoolean(itebis.activo);
                }
                else
                {
                    itbisIdText.Focus();
                    itbisIdText.SelectAll();

                    itbisIdText.Text = "";
                    nombreText.Text = "";
                    porcientoText.Text = "";
                    activoCheck.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool validarGetAction()
        {
            try
            {
                //validar nombre
                if (nombreText.Text == "")
                {
                    MessageBox.Show("Falta el nombre del itbis ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreText.Focus();
                    nombreText.SelectAll();
                    return false;
                }
                //validar numero itebis
                if (porcientoText.Text == "")
                {
                    MessageBox.Show("Falta el porciento del itbis ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    porcientoText.Focus();
                    porcientoText.SelectAll();
                    return false;
                }
                //validar que sea porciento
                int n;
                decimal porciento;
                if (int.TryParse(porcientoText.Text, out n) == true)
                {
                    porciento = Convert.ToDecimal(porcientoText.Text);
                    porciento = porciento/100;
                    porcientoText.Text = porciento.ToString("##.##");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarGetAction.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void getAction()
        {
            try
            {
                //validando campos necesarios
                if (validarGetAction() == false)
                {
                    return;
                }

                if (MessageBox.Show("Desea guardar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                bool crear = false;
                //se instancia el empleado si esta nulo
                if (itebis == null)
                {
                    itebis = new itebis();
                    crear = true;
                    itebis.codigo = modeloItebis.getNext();
                }
                itebis.nombre = nombreText.Text;
                itebis.porciento = Convert.ToDecimal(porcientoText.Text.Trim());
                itebis.activo = Convert.ToBoolean(activoCheck.Checked);

                if (crear == true)
                {
                    //se agrega
                    if ((modeloItebis.agregarItebis(itebis)) == true)
                    {
                        itebis = null;
                        loadVentana();
                        MessageBox.Show("Se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("No se agregó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //se modifica
                    if ((modeloItebis.modificarItebis(itebis)) == true)
                    {
                        itebis = null;
                        loadVentana();
                        MessageBox.Show("Se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                itebis = null;
                MessageBox.Show("Error  getAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ventana_itebis_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void porcientoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            utilidades.validarTextBoxNumeroDecimal(e,porcientoText.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            itebis = null;
            loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_itbis ventana = new ventana_busqueda_itbis(true);
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                itebis = ventana.getObjeto();
                loadVentana();
            }
        }

        private void itbisIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    nombreText.Focus();
                    nombreText.SelectAll();

                    itebis = modeloItebis.getItebisById(Convert.ToInt16(itbisIdText.Text));
                    loadVentana();

                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
