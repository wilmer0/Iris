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
        public bool agregarEmpresa(empresa empresaApp)
        {
            try
            {

                int activo = 0;
                if (empresaApp.activo == true)
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
                    sql = "insert into empresa(codigo,secuencia,division,activo,rnc,nombre) values('"+empresaApp.codigo+"','"+empresaApp.seuencia+"','"+empresaApp.division+"','"+activo.ToString()+"','"+empresaApp.rnc+"','"+empresaApp.nombre+"')";
                    ds = utilidades.ejecutarcomando_mysql(sql);
                    return true;
                }
                else
                {
                    sql = "update empresa set secuencia='" + empresaApp.seuencia + "',division='" + empresaApp.division +
                    "',activo='" + activo.ToString()+ "',rnc='" + empresaApp.rnc + "',nombre='" +
                    empresaApp.nombre + "' where codigo='1'";
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
                int id = (int)ds.Tables[0].Rows[0][0];
                if (id == null || id == 0)
                {
                    id = 1;
                }
                else
                {
                    id += 1;
                }
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
                string sql = "select codigo,secuencia,division,activo,rnc,nombre from empresa where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    empresa.codigo = (int)ds.Tables[0].Rows[0][0];
                    empresa.seuencia = ds.Tables[0].Rows[0][1].ToString();
                    empresa.division = ds.Tables[0].Rows[0][2].ToString();
                    empresa.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    empresa.rnc = ds.Tables[0].Rows[0][4].ToString();
                    empresa.nombre = ds.Tables[0].Rows[0][5].ToString();
                }
                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

}
