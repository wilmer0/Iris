using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_facturacion
{
    public partial class ventana_busqueda_tipo_comprobante_fiscal : formBase
    {
        //objetos
        private tipo_comprobante_fiscal tipoComprobanteFiscal;

        //listas
        private List<tipo_comprobante_fiscal> listaTipoComprobanteFiscal;

        //modelos
        private modeloTipoComprobanteFiscal modeloTipoComprobanteFiscal = new modeloTipoComprobanteFiscal();

        //variables 
        public bool mantenimiento = false;
        private int fila = 0;


        public ventana_busqueda_tipo_comprobante_fiscal(bool mantenimiento=false)
        {
            InitializeComponent();
            tituloLabel.Text = this.Text;
            this.mantenimiento = mantenimiento;
            loadLista();
        }
        public void loadLista()
        {
            try
            {
                //si la lista esta null se inicializa
                if (listaTipoComprobanteFiscal == null)
                {
                    listaTipoComprobanteFiscal = new List<tipo_comprobante_fiscal>();
                    listaTipoComprobanteFiscal = modeloTipoComprobanteFiscal.getListaCompleta(mantenimiento);
                }
                //se limpia el grid si tiene datos
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                }
                //se agrega todos los datos de la lista en el gridView
                listaTipoComprobanteFiscal.ForEach(x =>
                {
                    dataGridView1.Rows.Add(x.codigo, x.nombre,x.secuencia, x.activo);

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadLista.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public tipo_comprobante_fiscal getObjeto()
        {
            try
            {
                //validar que tenga datos el datagrid
                if (dataGridView1.Rows.Count < 0)
                {
                    return null;
                }
                //para pasar el objeto sucursal desde deonde se llamo
                fila = dataGridView1.CurrentRow.Index;
                tipoComprobanteFiscal = modeloTipoComprobanteFiscal.getTipoComprobanteById(Convert.ToInt16(dataGridView1.Rows[fila].Cells[0].Value.ToString()));
                return tipoComprobanteFiscal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getObjeto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void getAction()
        {
            this.DialogResult = DialogResult.OK;
            getObjeto();
            this.Close();
        }
        public void Salir()
        {
            if (MessageBox.Show("Desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void ventana_busqueda_tipo_comprobante_fiscal_Load(object sender, EventArgs e)
        {

        }

        private void ventana_busqueda_tipo_comprobante_fiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Salir();
            }
            if (e.KeyCode == Keys.F8)
            {
                getAction();
            }
        }

        private void nombreText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    listaTipoComprobanteFiscal = modeloTipoComprobanteFiscal.getListaCompleta();
                    listaTipoComprobanteFiscal = listaTipoComprobanteFiscal.FindAll(x => x.nombre.Contains(nombreText.Text));
                    loadLista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscando.: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tipoComprobanteFiscal = null;
            loadLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAction();
        }
    }
}
