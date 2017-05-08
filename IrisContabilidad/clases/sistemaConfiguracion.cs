using System;

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
        public bool limitarDevolucionesVenta30Dias { get; set; }
        public int codigoConceptoEgresoCajaDevolucionVenta { get; set; }
        public int codigoIdiomaSistema { get; set; }


    }
}
