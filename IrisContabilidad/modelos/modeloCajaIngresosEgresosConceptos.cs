using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloCajaIngresosEgresosConceptos
    {
        //objetos
        utilidades utilidades = new utilidades();






        //agregar 
        public bool agregarConcepto(caja_ingresos_egresos_conceptos concepto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from caja_ingresos_egresos_conceptos where nombre='" + concepto.nombre + "' and codigo!='" + concepto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un concepto con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (concepto.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into caja_ingresos_egresos_conceptos(codigo,nombre,activo) values('" + concepto.codigo + "','" + concepto.nombre + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarConcepto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarConcepto(caja_ingresos_egresos_conceptos concepto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from caja_ingresos_egresos_conceptos where nombre='" + concepto.nombre + "' and codigo!='" + concepto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un concepto con ese nombre", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
                if (concepto.activo == true)
                {
                    activo = 1;
                }
                sql = "update caja_ingresos_egresos_conceptos set nombre='" + concepto.nombre + "',activo='" + activo.ToString() + "' where codigo='" + concepto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarConcepto.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from caja_ingresos_egresos_conceptos";
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
        public caja_ingresos_egresos_conceptos getConceptoById(int id)
        {
            try
            {
                caja_ingresos_egresos_conceptos concepto = new caja_ingresos_egresos_conceptos();
                string sql = "select codigo,nombre,activo from caja_ingresos_egresos_conceptos where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    concepto.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    concepto.nombre = ds.Tables[0].Rows[0][1].ToString();
                    concepto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                }
                return concepto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAlmacenById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<caja_ingresos_egresos_conceptos> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<caja_ingresos_egresos_conceptos> lista = new List<caja_ingresos_egresos_conceptos>();
                string sql = "";
                sql = "select codigo,nombre,activo from caja_ingresos_egresos_conceptos";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        caja_ingresos_egresos_conceptos concepto = new caja_ingresos_egresos_conceptos();
                        concepto.codigo = Convert.ToInt16(row[0].ToString());
                        concepto.nombre = row[1].ToString();
                        concepto.activo = Convert.ToBoolean(row[2].ToString());
                        lista.Add(concepto);
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
    }
}
