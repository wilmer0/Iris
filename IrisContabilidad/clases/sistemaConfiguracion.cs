using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidad.clases
{
    public class sistemaConfiguracion
    {
        public int codigo { get; set; }
        public string imagenLogoEmpresa { get; set; }
        public int codigoMonedaDefault { get; set; }
        public bool permisosGrupo { get; set; }
        public decimal montoMaximoPedido { get; set; }
        public decimal montoLimiteEgresoCaja { get; set; }
        public DateTime fechaVencimientoSistema { get; set; }
        public bool verImagenProductoFacturacionTouch { get; set; }
        public bool verNombreProductoFacturacionTouch { get; set; }
        public decimal porcientoPropina { get; set; }
        public bool emitirNotasCreditoDebito { get; set; }
        public bool limitar_devoluciones_venta_30dias { get; set; }
        public int codigo_concepto_egreso_caja_devolucion_venta { get; set; }


    }
}
