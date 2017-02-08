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
    public class modeloTipoComprobanteFiscal
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarTipoComprobante(tipo_comprobante_fiscal tipo)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from tipo_comprobante_fiscal where nombre='" + tipo.nombre + "' and codigo!='" + tipo.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de comprobante con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar secuencia
                sql = "select *from tipo_comprobante_fiscal where secuencia='" + tipo.secuencia + "' and codigo!='" + tipo.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de comprobante con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                

                if (tipo.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into tipo_comprobante_fiscal(codigo,secuencia,nombre,activo) values('" + tipo.codigo + "','" + tipo.secuencia + "','" + tipo.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarTipoComprobante.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarTipoComprobante(tipo_comprobante_fiscal tipo)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from tipo_comprobante_fiscal where nombre='" + tipo.nombre + "' and codigo!='" + tipo.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de comprobante con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar secuencia
                sql = "select *from tipo_comprobante_fiscal where secuencia='" + tipo.secuencia + "' and codigo!='" + tipo.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un tipo de comprobante con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (tipo.activo == true)
                {
                    activo = 1;
                }
                sql = "update tipo_comprobante_fiscal set secuencia='" + tipo.secuencia + "',nombre='"+tipo.nombre+"',activo='" + activo.ToString() + "' where codigo='" + tipo.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarTipoComprobante.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from tipo_comprobante_fiscal";
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


        //get objeto
        public tipo_comprobante_fiscal getTipoComprobanteById(int id)
        {
            try
            {
                tipo_comprobante_fiscal tipo = new tipo_comprobante_fiscal();
                string sql = "select codigo,secuencia,nombre,activo from tipo_comprobante_fiscal where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    tipo.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    tipo.secuencia = ds.Tables[0].Rows[0][1].ToString();
                    tipo.nombre = ds.Tables[0].Rows[0][2].ToString();
                    tipo.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                }
                return tipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoComprobanteById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<tipo_comprobante_fiscal> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<tipo_comprobante_fiscal> lista = new List<tipo_comprobante_fiscal>();
                string sql = "select codigo,secuencia,nombre,activo from tipo_comprobante_fiscal";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        tipo_comprobante_fiscal tipo = new tipo_comprobante_fiscal();
                        tipo.codigo = Convert.ToInt16(row[0].ToString());
                        tipo.secuencia = row[1].ToString();
                        tipo.nombre = row[2].ToString();
                        tipo.activo = Convert.ToBoolean(row[3]);
                        lista.Add(tipo);
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

        internal tipo_comprobante_fiscal getTipoComprobanteByNCF(string ncf)
        {
            try
            {
                tipo_comprobante_fiscal tipoComprobante;
                string secuencia = ncf;
                secuencia.Substring(0, 9);
                secuencia.Substring(0, 2);
                string sql = "select codigo,secuencia,nombre,activo from tipo_comprobante_fiscal where secuencia='"+secuencia+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    tipoComprobante = new tipo_comprobante_fiscal();
                    tipoComprobante.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    tipoComprobante.secuencia = ds.Tables[0].Rows[0][1].ToString();
                    tipoComprobante.nombre = ds.Tables[0].Rows[0][2].ToString();
                    tipoComprobante.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    return tipoComprobante;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getTipoComprobanteByNCF.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
