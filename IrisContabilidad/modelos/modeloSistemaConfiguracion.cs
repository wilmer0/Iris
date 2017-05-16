using System;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloSistemaConfiguracion
    {
        
        //objetos
        utilidades utilidades=new utilidades();
        

        //agregar 
        public bool modificarSistemaConsiguracion(sistemaConfiguracion sistemaconfiguracion)
        {
            try
            {
                int permisosGruposUsuarios = 0;
                int verImagenProductoFacturacionTouch = 0;
                int verNombreProductoFacturacionTouch = 0;
                int emitirNotasCreditoDebito = 0;
                int limitarDevolucionesVenta30Dias = 0;

                if (sistemaconfiguracion.permisosGrupo == true)
                {
                    permisosGruposUsuarios = 1;
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
                if (sistemaconfiguracion.limitarDevolucionesVenta30Dias == true)
                {
                    limitarDevolucionesVenta30Dias = 1;
                }

                string sql = "update sistema set imagen_logo_empresa='',codigo_moneda='1',permisos_por_grupos_usuarios='1',autorizar_pedidos_apartir='0',limite_egreso_caja='0',fecha_vencimiento='20301231',ver_imagen_fact_touch='1',ver_nombre_fact_touch='1',porciento_propina='0',emitir_notas_credito_debito='0',limitar_devoluciones_venta_30dias='0',concepto_egreso_caja_devolucion_venta='1',codigo_idioma_sistema='" + sistemaconfiguracion.codigoIdiomaSistema + "',tipo_ventana_cuadre_caja='"+sistemaconfiguracion.tipoVentanaCuadreCaja+"' where codigo='1'";
                utilidades.ejecutarcomando_mysql(sql);



                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarSistemaConsiguracion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public sistemaConfiguracion getSistemaConfiguracion()
        {
            try
            {
                int permisosGruposUsuarios = 0;
                int emitirComprobantes = 0;
                int verImagenProductoFacturacionTouch = 0;
                int verNombreProductoFacturacionTouch = 0;
                int emitirNotasCreditoDebito = 0;
                int limitarDevolucionesVenta30Dias = 0;

                sistemaConfiguracion sistemaConfiguracion=new sistemaConfiguracion();

                string sql = "select codigo,imagen_logo_empresa,codigo_moneda,permisos_por_grupos_usuarios,autorizar_pedidos_apartir,limite_egreso_caja,fecha_vencimiento,ver_imagen_fact_touch,ver_nombre_fact_touch,porciento_propina,emitir_notas_credito_debito,limitar_devoluciones_venta_30dias,concepto_egreso_caja_devolucion_venta,codigo_idioma_sistema,codigo_numero_comprobante_fiscal_defecto_ventas,codigo_tipo_venta_defecto,tipo_ventana_cuadre_caja_sistema_full from sistema where codigo='1'";
                DataSet ds=utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    //esta lleno
                    sistemaConfiguracion.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    sistemaConfiguracion.imagenLogoEmpresa = ds.Tables[0].Rows[0][1].ToString();
                    sistemaConfiguracion.codigoMonedaDefault = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                    sistemaConfiguracion.permisosGrupo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    sistemaConfiguracion.montoMaximoPedido = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    sistemaConfiguracion.montoLimiteEgresoCaja = Convert.ToDecimal(ds.Tables[0].Rows[0][5]);
                    sistemaConfiguracion.fechaVencimientoSistema = Convert.ToDateTime(ds.Tables[0].Rows[0][6]);
                    sistemaConfiguracion.verImagenProductoFacturacionTouch = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    sistemaConfiguracion.verNombreProductoFacturacionTouch = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                    sistemaConfiguracion.porcientoPropina = Convert.ToDecimal(ds.Tables[0].Rows[0][9]);
                    sistemaConfiguracion.emitirNotasCreditoDebito = Convert.ToBoolean(ds.Tables[0].Rows[0][10]);
                    sistemaConfiguracion.limitarDevolucionesVenta30Dias = Convert.ToBoolean(ds.Tables[0].Rows[0][11]);
                    sistemaConfiguracion.codigoConceptoEgresoCajaDevolucionVenta = Convert.ToInt16(ds.Tables[0].Rows[0][12]);
                    sistemaConfiguracion.codigoIdiomaSistema = Convert.ToInt16(ds.Tables[0].Rows[0][13]);
                    sistemaConfiguracion.codigoNumeroComprobanteFiscalDefectoVentas = Convert.ToInt16(ds.Tables[0].Rows[0][14]);
                    sistemaConfiguracion.codigoTipoVentaDefecto = Convert.ToInt16(ds.Tables[0].Rows[0][15]);
                    sistemaConfiguracion.tipoVentanaCuadreCaja = Convert.ToInt16(ds.Tables[0].Rows[0][16]);
                    sistemaConfiguracion.sistemaFull = Convert.ToBoolean(ds.Tables[0].Rows[0][17]);
                }
                else
                {
                    //esta vacio
                    sistemaConfiguracion = null;
                }

                return sistemaConfiguracion;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSistemaConfiguracion.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
