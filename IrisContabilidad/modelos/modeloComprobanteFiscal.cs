using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloComprobanteFiscal
    {

        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarComprobante(comprobante_fiscal comprobante)
        {
            try
            {
                //validar que la caja no acepte un numero de comprobante que ya se puede usar o se uso
                string sql = "select *from comprobante_fiscal where codigo_tipo='" + comprobante.codigo_tipo + "' and cod_caja='" + comprobante.codigo_caja + "' and ((" + comprobante.numero_desde + " between desde_numero and hasta_numero) or (" + comprobante.numero_hasta + " between desde_numero and hasta_numero)) and codigo!='" + comprobante.codigo+ "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Se ha detectado un empalme con relación al rango del comprobante", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                sql = "insert into comprobante_fiscal(codigo,serie,cod_caja,codigo_tipo,desde_numero,hasta_numero,fecha) values('" + comprobante.codigo + "','" + comprobante.serie + "','" + comprobante.codigo_caja + "','" + comprobante.codigo_tipo + "','" + comprobante.numero_desde + "','" + comprobante.numero_hasta + "'," + utilidades.getFechayyyyMMdd(comprobante.fecha) + ")";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);

                sql = "select *from comprobante_fiscal_notificaciones where codigo_caja='"+comprobante.codigo_caja+"' and comprobante_tipo='"+comprobante.codigo_tipo+"'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    sql = "insert into comprobante_fiscal_notificaciones(codigo_caja,comprobante_tipo,avisar) values('" + comprobante.codigo_caja + "','" + comprobante.codigo_tipo + "','" + comprobante.avisar + "');";
                    utilidades.ejecutarcomando_mysql(sql);    
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarComprobante.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarComprobante(comprobante_fiscal comprobante)
        {
            try
            {
                //validar que la caja no acepte un numero de comprobante que ya se puede usar o se uso
                string sql = "select *from comprobante_fiscal where codigo_tipo='" + comprobante.codigo_tipo + "' and cod_caja='" + comprobante.codigo_caja + "' and ((" + comprobante.numero_desde + " between desde_numero and hasta_numero) or (" + comprobante.numero_hasta + " between desde_numero and hasta_numero)) and codigo!='" + comprobante.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Se ha detectado un empalme con relación al rango del comprobante", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                sql = "update comprobante_fiscal set serie='" + comprobante.serie + "',cod_caja='" + comprobante.codigo_caja + "',codigo_tipo='" + comprobante.codigo_tipo + "',desde_numero='" + comprobante.numero_desde + "',hasta_numero='" + comprobante.numero_hasta + "' where codigo='" + comprobante.codigo + "'";
                utilidades.ejecutarcomando_mysql(sql);
                
                //actualizar el numero avisar en comprobante fiscal notificaciones
                sql ="update comprobante_fiscal_notificaciones set avisar='"+comprobante.avisar+"' where codigo_caja='"+comprobante.codigo_caja+"' and comprobante_tipo='"+comprobante.codigo_tipo+"'";
                utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarComprobante.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from comprobante_fiscal";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                //int id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                int id = 0;
                if (ds.Tables[0].Rows[0][0].ToString() == null || ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
                id += 1;
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNext.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        //get lista completa
        public List<comprobante_fiscal> getListaCompleta()
        {
            try
            {
                List<comprobante_fiscal> lista = new List<comprobante_fiscal>();
                string sql = "";
                sql = "select codigo,serie,cod_caja,codigo_tipo,desde_numero,hasta_numero,fecha from comprobante_fiscal";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        comprobante_fiscal comprobante = new comprobante_fiscal();
                        comprobante.codigo = Convert.ToInt16(row[0].ToString());
                        comprobante.serie = row[1].ToString();
                        comprobante.codigo_caja = Convert.ToInt16(row[2].ToString());
                        comprobante.codigo_tipo = Convert.ToInt16(row[3].ToString());
                        comprobante.numero_desde = Convert.ToInt16(row[4].ToString());
                        comprobante.numero_hasta = Convert.ToInt16(row[5].ToString());
                        comprobante.fecha = Convert.ToDateTime(row[6].ToString());
                        lista.Add(comprobante);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public bool validarMasComprobanteByTipoAndCaja(int tipoComprobante, int codigoCaja)
        {
            try
            {
                List<comprobante_fiscal> lista = new List<comprobante_fiscal>();
                lista = getListaCompleta();

                //me trae el primer registro del comprobante fiscal que debe utilizar
                string sql = "select codigo,serie,cod_caja,codigo_tipo,desde_numero,hasta_numero,fecha from comprobante_fiscal where cod_caja=1 and codigo_tipo=1 and hasta_numero>contador limit 1";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarMasComprobanteByTipoAndCaja.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        
        //me trae la cantidad que tengo disponible de ese tipo de comprobante en mi caja
        //select sum(hasta_numero)-sum(contador) from comprobante_fiscal where cod_caja=1 and codigo_tipo=1;

        //get next comprobante fiscal by tipo 
        public string getNextComprobanteFiscalByTipoId(int codigoCaja,int codigoTipoComprobante)
        {
            try
            {
                singleton singleton=new singleton();
                empleado empleado = singleton.getEmpleado();
                cajero cajero;
                cajero = new modeloCajero().getCajeroByIdEmpleado(empleado.codigo);
                tipo_comprobante_fiscal tipocomprobante;
                tipocomprobante = new modeloTipoComprobanteFiscal().getTipoComprobanteById(codigoTipoComprobante);


                string ncf = "";
                string serie = "";
                string divisionNegocio = "";
                string sucursal = "";
                string caja = "";
                string tipo = "";
                string secuencia = "";
                int contador = 0;
               
                string sql ="select contador from comprobante_fiscal where contador<>hasta_numero and cod_caja='"+codigoCaja+"' and codigo_tipo='"+codigoTipoComprobante+"' limit 1";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (int.TryParse(ds.Tables[0].Rows[0][0].ToString(),out contador)==true)
                {
                    //encontro un numero valido
                    contador = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    contador = 0;
                }
                contador+=1;
                sql = "update comprobante_fiscal set contador='"+contador+"' where contador<>hasta_numero and cod_caja='"+codigoCaja+"' and codigo_tipo='"+codigoTipoComprobante+"'";
                utilidades.ejecutarcomando_mysql(sql);

                secuencia = contador.ToString();
                secuencia = utilidades.getRellenar(secuencia, '0', 8);
                //ahora el ncf saldra asi-> 00000999
                serie = new modeloEmpresa().getEmpresaBySucursalId(empleado.codigo_sucursal).serie_comprobante;
                divisionNegocio=new modeloEmpresa().getEmpresaBySucursalId(empleado.codigo_sucursal).division;
                sucursal = new modeloSucursal().getSucursalById(empleado.codigo_sucursal).secuencia;
                caja = new modeloCaja().getCajaById(cajero.codigo_caja).secuencia;
                tipo = tipocomprobante.secuencia;
                
                
                ncf = serie + divisionNegocio + sucursal + caja + tipo + secuencia;
                if (ncf.Length != 19)
                {
                    MessageBox.Show("Se ha generado de forma incorrecta el comprobante fiscal->" + ncf);
                }

                return ncf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getNextComprobanteFiscalByTipoId.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
