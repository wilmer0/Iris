using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloSistemaConfiguracion
    {

        //objetos
        utilidades utilidades=new utilidades();

        //agregar 
        public bool agregarConfiguracion(sistemaConfiguracion sistemaconfiguracion)
        {
            try
            {
                int permisosGruposUsuarios = 0;
                int emitirComprobantes = 0;
                int verImagenProductoFacturacionTouch = 0;
                int verNombreProductoFacturacionTouch = 0;
                int emitirNotasCreditoDebito = 0;
                int limitarDevolucionesVenta30Dias = 0;

                if (sistemaconfiguracion.permisosGrupo == true)
                {
                    permisosGruposUsuarios = 1;
                }
                if (sistemaconfiguracion.emitirComprobante == true)
                {
                    emitirComprobantes = 1;
                }
                if (sistemaconfiguracion.verImagenProductoFacturacionTouch == true)
                {
                    verImagenProductoFacturacionTouch = 1;
                }
                if (sistemaconfiguracion.verNombreProductoFacturacionTouch == true)
                {
                    verNombreProductoFacturacionTouch = 1;
                }
                if (sistemaconfiguracion.emitirNotasCreditoDebito == true)
                {
                    emitirNotasCreditoDebito = 1;
                }
                if (sistemaconfiguracion.limitar_devoluciones_venta_30dias == true)
                {
                    limitarDevolucionesVenta30Dias = 1;
                }

                string sql = "delete from sistema";
                utilidades.ejecutarcomando_mysql(sql);


                sql = "";
                utilidades.ejecutarcomando_mysql(sql);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVenta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
