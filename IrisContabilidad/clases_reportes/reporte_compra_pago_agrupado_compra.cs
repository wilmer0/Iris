using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_compra_pago_agrupado_compra
    {
        public int codigoComrpa { get; set; }
        public string numeroCompra { get; set; }
        public string tipoCompra { get; set; }
        public string NCF { get; set; }
        public int codigoSuplidor { get; set; }
        public string suplidor { get; set; }
        public List<reporte_compra_pago_detalle> listaPagosDetalles { get; set; }
    }
}
