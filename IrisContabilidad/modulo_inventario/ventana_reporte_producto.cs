using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.clases_reportes;
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_facturacion;
using IrisContabilidad.modulo_sistema;
using IrisContabilidad.ventanas_comunes;
using Microsoft.Reporting.WinForms;

namespace IrisContabilidad.modulo_inventario
{
    public partial class ventana_reporte_producto : formBase
    {

        //objetos
        utilidades utilidades = new utilidades();
        private singleton singleton = new singleton();
        private empleado empleado;
        private producto producto;
        private itebis itebis;
        private categoria_producto categoria;
        private subCategoriaProducto subCategoria;
        private almacen almacen;
        private unidad unidad;
        private reporte_producto_encabezado reporteProductoEncabezado;
        private reporte_producto_detalle reporteProductoDetalle;

        


        //modelos
        modeloEmpleado modeloEmpleado=new modeloEmpleado();
        modeloProducto modeloProducto=new modeloProducto();
        modeloItebis modeloItebis=new modeloItebis();
        modeloCategoriaProducto modeloCategoriaProducto=new modeloCategoriaProducto();
        modeloSubCategoriaProducto modeloSubcategoriaProducto=new modeloSubCategoriaProducto();
        modeloAlmacen modeloAlmacen = new modeloAlmacen();
        modeloUnidad modeloUnidad=new modeloUnidad();
        modeloEmpresa modeloEmpresa = new modeloEmpresa();
        modeloSucursal modeloSucursal=new modeloSucursal();


        //listas
        private List<producto> listaProducto; 
        private List<reporte_producto_encabezado> listaReporteProductoEncabezado;
        private List<reporte_producto_detalle> listaReporteProductoDetalle;


        public ventana_reporte_producto()
        {
            InitializeComponent();
            empleado = singleton.getEmpleado();
            this.tituloLabel.Text = utilidades.GetTituloVentana(empleado, "reporte producto");
            this.Text = tituloLabel.Text;
            loadVentana();
        }
        public void loadVentana()
        {
            try
            {
                productoText.Focus();
                productoText.SelectAll();

                productoText.Clear();
                referenciaText.Clear();

                unidad = null;
                loadUnidad();

                itebis = null;
                loadItebis();

                categoria = null;
                loadCategoria();

                subCategoria = null;
                loadSubCategoria();

                almacen = null;
                loadAlmacen();

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
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidarGetAction.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void GetAction()
        {
            try
            {

                if (MessageBox.Show("Desea imprimir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                {
                    return;
                }
                if (!ValidarGetAction())
                {
                    return;
                }

                #region


                //datos generales
                String reporte = "IrisContabilidad.reportes.reporte_producto.rdlc";
                List<ReportDataSource> listaReportDataSource = new List<ReportDataSource>();
                listaReporteProductoEncabezado = new List<reporte_producto_encabezado>();
                listaReporteProductoDetalle = new List<reporte_producto_detalle>();
                reporteProductoEncabezado = new reporte_producto_encabezado();
                listaProducto = new List<producto>();


                //llenar encabezado
                reporteProductoEncabezado.empresa = modeloEmpresa.getEmpresaBySucursalId(empleado.codigo_sucursal).nombre;
                reporteProductoEncabezado.direccion = modeloSucursal.getSucursalById(empleado.codigo_sucursal).direccion;
                reporteProductoEncabezado.empleado = empleado.nombre;
                reporteProductoEncabezado.fecha_impresion = DateTime.Now;
                reporteProductoEncabezado.almacen = almacenText.Text;
                reporteProductoEncabezado.categoria = categoriaText.Text;
                reporteProductoEncabezado.itebis = itebisText.Text;
                reporteProductoEncabezado.producto = productoText.Text;
                reporteProductoEncabezado.referencia = referenciaText.Text;
                reporteProductoEncabezado.subcategoria = subcategoriaText.Text;
                reporteProductoEncabezado.unidad_minima = unidadMinimaText.Text;
                listaReporteProductoEncabezado.Add(reporteProductoEncabezado);

                //llenar lista detalle
                listaProducto = modeloProducto.getListaCompleta();


                //filtar lista

                #region

                //nombre
                if (productoText.Text != "")
                {

                    listaProducto =
                        listaProducto.FindAll(x => x.nombre.ToLower().Contains(productoText.Text.ToLower())).ToList();
                }
                //referencia
                if (referenciaText.Text != "")
                {
                    listaProducto =
                        listaProducto.FindAll(x => x.referencia.ToLower().Contains(referenciaText.Text.ToLower()));
                }
                //unidad minima
                if (unidadMinimaIdText.Text != "")
                {
                    listaProducto =
                        listaProducto.FindAll(x => x.codigo_unidad_minima == Convert.ToInt16(unidadMinimaIdText.Text));
                }
                //itebis
                if (itebisIdText.Text != "")
                {
                    listaProducto = listaProducto.FindAll(x => x.codigo_itebis == Convert.ToInt16(itebisIdText.Text));
                }
                //categoria
                if (categoriaIdText.Text != "")
                {
                    listaProducto =
                        listaProducto.FindAll(x => x.codigo_categoria == Convert.ToInt16(categoriaIdText.Text));
                }
                //subcategoria
                if (subcategoriaIdText.Text != "")
                {
                    listaProducto =
                        listaProducto.FindAll(x => x.codigo_subcategoria == Convert.ToInt16(subcategoriaIdText.Text));
                }
                //almacen
                if (almacenIdText.Text != "")
                {
                    listaProducto = listaProducto.FindAll(x => x.codigo_almacen == Convert.ToInt16(almacenIdText.Text));
                }

                #endregion


                //llelando la lista reporteProductoDetalle
                foreach (var x in listaProducto)
                {
                    reporteProductoDetalle = new reporte_producto_detalle();

                    almacen = modeloAlmacen.getAlmacenById(x.codigo_almacen);
                    reporteProductoDetalle.almacen = almacen.nombre;
                    categoria = modeloCategoriaProducto.getCategoriaById(x.codigo_categoria);
                    reporteProductoDetalle.categoria = categoria.nombre;
                    reporteProductoDetalle.codigo_producto = x.codigo;
                    reporteProductoDetalle.existencia = 0;
                    itebis = modeloItebis.getItebisById(x.codigo_itebis);
                    reporteProductoDetalle.itebis = itebis.porciento.ToString();
                    reporteProductoDetalle.nombre = x.nombre;
                    reporteProductoDetalle.referencia = x.referencia;
                    subCategoria = modeloSubcategoriaProducto.getSubCategoriaById(x.codigo_subcategoria);
                    reporteProductoDetalle.subcategoria = subCategoria.nombre;
                    unidad = modeloUnidad.getUnidadById(x.codigo_unidad_minima);
                    reporteProductoDetalle.unidad_minima = unidad.nombre;
                    listaReporteProductoDetalle.Add(reporteProductoDetalle);
                }


                //validar que tenga datos
                if (listaReporteProductoDetalle == null)
                {
                    MessageBox.Show("No hay datos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                ReportDataSource reporteGrafico = new ReportDataSource("reporte_encabezado",listaReporteProductoEncabezado);
                listaReportDataSource.Add(reporteGrafico);

                ReportDataSource reporteProblemas = new ReportDataSource("reporte_detalle", listaReporteProductoDetalle);
                listaReportDataSource.Add(reporteProblemas);


                List<ReportParameter> ListaReportParameter = new List<ReportParameter>();

                VisorReporteComun ventana = new VisorReporteComun(reporte, listaReportDataSource, ListaReportParameter,true);
                ventana.ShowDialog();

                #endregion

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
        private void ventana_reporte_producto_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            salir();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           loadVentana();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAction();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ventana_busqueda_subcategoria_producto ventana = new ventana_busqueda_subcategoria_producto(categoria.codigo);
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                subCategoria = ventana.getObjeto();
                loadSubCategoria();
            }
        }
        public void loadSubCategoria()
        {
            try
            {
                subcategoriaIdText.Text = "";
                subcategoriaText.Text = "";
                if (subCategoria == null)
                {
                    return;
                }
                subcategoriaIdText.Text = subCategoria.codigo.ToString();
                subcategoriaText.Text = subCategoria.nombre;

                almacenIdText.Focus();
                almacenIdText.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadSubCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ventana_busqueda_categoria_producto ventana = new ventana_busqueda_categoria_producto();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                categoria = ventana.getObjeto();
                loadCategoria();
            }
        }
        public void loadCategoria()
        {
            try
            {
                categoriaIdText.Text = "";
                categoriaText.Text = "";
                if (categoria == null)
                {
                    return;
                }
                
                categoriaIdText.Text = categoria.codigo.ToString();
                categoriaText.Text = categoria.nombre;

                subcategoriaIdText.Focus();
                subcategoriaIdText.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadCategoria.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_itbis ventana = new ventana_busqueda_itbis();
            ventana.mantenimiento = true;
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                itebis = ventana.getObjeto();
                loadItebis();
            }
        }
        public void loadItebis()
        {
            try
            {
                itebisIdText.Text = "";
                itebisText.Text = "";
                if (itebis == null)
                {
                    return;
                }

                itebisIdText.Text = itebis.codigo.ToString();
                itebisText.Text = itebis.porciento.ToString();

                categoriaIdText.Focus();
                categoriaIdText.SelectAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadItebis.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ventana_busqueda_almacen ventana = new ventana_busqueda_almacen();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                almacen = ventana.getObjeto();
                loadAlmacen();
            }
        }
        public void loadAlmacen()
        {
            try
            {
                almacenIdText.Text = "";
                almacenText.Text = "";
                if (almacen == null)
                {
                    return;
                }

                almacenIdText.Text = almacen.codigo.ToString();
                almacenText.Text = almacen.nombre;

                button1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadAlmacen.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ventana_busqueda_unidad ventana = new ventana_busqueda_unidad();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                unidad = ventana.getObjeto();
                loadUnidad();
            }
        }
        public void loadUnidad()
        {
            try
            {
                unidadMinimaIdText.Text = "";
                unidadMinimaText.Text = "";
                if (unidad == null)
                {
                    return;
                }
                unidadMinimaIdText.Text = unidad.codigo.ToString();
                unidadMinimaText.Text = unidad.nombre;

                itebisIdText.Focus();
                itebisIdText.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loadUnidadConversion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                referenciaText.Focus();
                referenciaText.SelectAll();
            }
        }

        private void referenciaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                unidadMinimaIdText.Focus();
                unidadMinimaIdText.SelectAll();
            }
        }

        private void unidadMinimaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button8_Click(null,null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    itebisIdText.Focus();
                    itebisIdText.SelectAll();

                    unidad = modeloUnidad.getUnidadById(Convert.ToInt16(unidadMinimaIdText.Text));
                    loadUnidad();
                }
            }
            catch (Exception)
            {
            }
        }

        private void categoriaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button4_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    subcategoriaIdText.Focus();
                    subcategoriaIdText.SelectAll();

                    categoria = modeloCategoriaProducto.getCategoriaById(Convert.ToInt16(categoriaIdText.Text));
                    loadCategoria();
                }
            }
            catch (Exception)
            {
            }
        }

        private void itebisIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button5_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    categoriaIdText.Focus();
                    categoriaIdText.SelectAll();

                    itebis = modeloItebis.getItebisById(Convert.ToInt16(itebisIdText.Text));
                    loadItebis();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void subcategoriaIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button6_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    almacenIdText.Focus();
                    almacenIdText.SelectAll();

                    subCategoria =modeloSubcategoriaProducto.getSubCategoriaById(Convert.ToInt16(subcategoriaIdText.Text));
                    loadSubCategoria();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void almacenIdText_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    button7_Click(null, null);
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    button1.Focus();

                    almacen = modeloAlmacen.getAlmacenById(Convert.ToInt16(almacenIdText.Text));
                    loadAlmacen();
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
