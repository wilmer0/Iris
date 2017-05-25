using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using IrisContabilidad.modelos;

namespace IrisContabilidad.clases_reportes
{
    public class reporte_estado_cuenta_suplidor_detalle
    {
        
        public int idSuplidor { get; set; }
        public string suplidor { get; set; }
        public string rnc { get; set; }
        public string telefonos { get; set; }
        public decimal montoFacturado { get; set; }
        public decimal montoPagado { get; set; }
        public decimal montoPendiente { get; set; }
        public decimal montoNotasCredito { get; set; }
        public decimal montoNotasDebito { get; set; }
        

        public reporte_estado_cuenta_suplidor_detalle()
        {

        }

        public reporte_estado_cuenta_suplidor_detalle(suplidor suplidor)
        {
            try
            {
                this.idSuplidor = suplidor.codigo;
                this.suplidor = suplidor.nombre;
                this.rnc = suplidor.rnc;
                this.telefonos = suplidor.telefono1 + " - " + suplidor.telefono2;
                this.montoFacturado = new modeloCompra().getMontoFacturadoBySuplidorId(suplidor.codigo);
                this.montoPendiente = new modeloCompra().getMontoPendienteBySuplidorId(suplidor.codigo);
                this.montoPagado = new modeloCompra().getMontoPagadoBySuplidorId(suplidor.codigo);
                this.montoNotasCredito = new modeloCompra().getMontoNotasCreditoBySuplidorId(suplidor.codigo);
                this.montoNotasDebito = new modeloCompra().getMontoNotasDebitoBySuplidorId(suplidor.codigo);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reporte_estado_cuenta_suplidor_detalle.:"+ex.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Error);   
            }
        }
    
    
    }
}
