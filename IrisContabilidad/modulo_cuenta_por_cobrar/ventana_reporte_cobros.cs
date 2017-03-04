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
using IrisContabilidad.modelos;
using IrisContabilidad.modulo_cuenta_por_pagar;
using IrisContabilidad.modulo_sistema;

namespace IrisContabilidad.modulo_cuenta_por_cobrar
{
    public partial class ventana_reporte_cobros : formBase
    {
        //objetos
        utilidades utilidades = new utilidades();
        singleton singleton = new singleton();
        empleado empleado;
        private venta venta;
        private venta_detalle VentaDetalle;
        private venta_vs_cobros ventaCobro;
        private venta_vs_cobros_detalles ventaCobroDetalle;
        private cliente cliente;
        private metodo_pago metodoPago;

        //modelos
        modeloVenta modeloVenta = new modeloVenta();
        modeloCliente modeloCliente = new modeloCliente();
        modeloEmpleado modeloEmpleado = new modeloEmpleado();
        modeloCobro modeloCobro = new modeloCobro();
        modeloMetodoPago modeloMetodoPago = new modeloMetodoPago();

        //variables
        bool existe = false;//para saber si existe la unidad actual y el codigo de barra


        //listas
        private List<venta_vs_cobros_detalles> listaVentacobroDetalle;
        private List<venta> listaVenta;
        private List<venta_detalle> listaVentaDetalle;

        //variables


        public ventana_reporte_cobros()
        {
            InitializeComponent();
        }

        private void ventana_reporte_cobros_Load(object sender, EventArgs e)
        {

        }

        public void loadCliente()
        {
            try
            {
                clienteIdText.Text = "";
                clienteLabel.Text = "";
                if (cliente != null)
                {
                    clienteIdText.Text = cliente.codigo.ToString();
                    clienteLabel.Text = cliente.nombre;
                }
            }
            catch (Exception)
            {
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ventana_busqueda_cliente ventana=new ventana_busqueda_cliente();
            ventana.Owner = this;
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                cliente = ventana.getObjeto();
                loadCliente();
            }
        }
    }
}
