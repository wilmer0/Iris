using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_pago_detalle
    {
        public string numero_compra { get; set; }
        public int codigoCompra { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal monto_pagado { get; set; }
        public string fecha_compra { get; set; }
        public int codigo_metodo_pago { get; set; }
        public string metodo_pago { get; set; }

    }
}
