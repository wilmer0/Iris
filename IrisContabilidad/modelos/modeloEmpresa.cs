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
    public class modeloEmpresa
    {
        //objetos
        utilidades utilidades = new utilidades();



      

        //agregar empresa
        public bool agregarEmpresa(empresa empresa)
        {
            try
            {

                int activo = 0;
                if (empresa.activo == true)
                {
                    //MessageBox.Show(Convert.ToInt16(empresaApp.activo).ToString());
                    activo = 1;
                }
                string sql = "";
                sql = "select *from empresa";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //se agrega
                    sql = "insert into empresa(codigo,secuencia,division,activo,rnc,nombre,serie_comprobante) values('"+empresa.codigo+"','"+empresa.secuencia+"','"+empresa.division+"','"+activo.ToString()+"','"+empresa.rnc+"','"+empresa.nombre+"','"+empresa.serie_comprobante+"')";
                    ds = utilidades.ejecutarcomando_mysql(sql);
                    return true;
                }
                else
                {
                    sql = "update empresa set secuencia='" + empresa.secuencia + "',division='" + empresa.division +"',activo='" + activo.ToString()+ "',rnc='" + empresa.rnc + "',nombre='" +empresa.nombre + "',serie_comprobante='"+empresa.serie_comprobante+"' where codigo='1'";
                    ds = utilidades.ejecutarcomando_mysql(sql);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //obtener el codigo siguiente cargo
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from empresa";
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



        //get empresa
        public empresa getEmpresaById(int id)
        {
            try
            {
                empresa empresa = new empresa();
                string sql = "select codigo,secuencia,division,activo,rnc,nombre,serie_comprobante from empresa where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    empresa.codigo = (int)ds.Tables[0].Rows[0][0];
                    empresa.secuencia = ds.Tables[0].Rows[0][1].ToString();
                    empresa.division = ds.Tables[0].Rows[0][2].ToString();
                    empresa.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    empresa.rnc = ds.Tables[0].Rows[0][4].ToString();
                    empresa.nombre = ds.Tables[0].Rows[0][5].ToString();
                    empresa.serie_comprobante = ds.Tables[0].Rows[0][6].ToString();
                }
                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get empresa by sucursal
        public empresa getEmpresaBySucursalId(int id)
        {
            try
            {
                empresa empresa = new empresa();
                string sql = "select e.codigo,e.secuencia,e.division,e.activo,e.rnc,e.nombre,e.serie_comprobante from sucursal s join empresa e on s.codigo_empresa=e.codigo where s.codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    empresa.codigo = (int)ds.Tables[0].Rows[0][0];
                    empresa.secuencia = ds.Tables[0].Rows[0][1].ToString();
                    empresa.division = ds.Tables[0].Rows[0][2].ToString();
                    empresa.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    empresa.rnc = ds.Tables[0].Rows[0][4].ToString();
                    empresa.nombre = ds.Tables[0].Rows[0][5].ToString();
                    empresa.serie_comprobante = ds.Tables[0].Rows[0][6].ToString();
                }
                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaBySucursalId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get empresa by empleado id
        public empresa getEmpresaByEmpleadoId(int id)
        {
            try
            {
                empresa empresa = new empresa();
                string sql = "select e.codigo,e.secuencia,e.division,e.activo,e.rnc,e.nombre,e.serie_comprobante from empresa e join sucursal s on e.codigo=s.codigo_empresa join empleado em on em.cod_sucursal=s.codigo where em.codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    empresa.codigo = (int)ds.Tables[0].Rows[0][0];
                    empresa.secuencia = ds.Tables[0].Rows[0][1].ToString();
                    empresa.division = ds.Tables[0].Rows[0][2].ToString();
                    empresa.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    empresa.rnc = ds.Tables[0].Rows[0][4].ToString();
                    empresa.nombre = ds.Tables[0].Rows[0][5].ToString();
                    empresa.serie_comprobante = ds.Tables[0].Rows[0][6].ToString();
                }
                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaByEmpleadoId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }

}
