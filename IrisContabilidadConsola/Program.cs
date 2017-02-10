using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad;
using IrisContabilidad.modelos;

namespace IrisContabilidadConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeloReporte modeloReporte = new ModeloReporte();
            modeloReporte.imprimirCompra(4);
            modeloReporte.imprirmirCompraPago(4);
            modeloReporte.imprimirVenta(5);
            modeloReporte.imprimirVentaCobro(5);
        }
    }
}
