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
    public class modeloEntidades
    {
        //objetos
        utilidades utilidades = new utilidades();

        //get by cliente 
        public entidades getEntidadesByCliente(int id)
        {
            try
            {
                entidades entidad=new entidades();
                //validar nombre
                string sql = "select codigo,codigo_cliente,codigo_suplidor,codigo_empleado,codigo_cajero from entidades where codigo_cliente='"+id+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                entidad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                entidad.codigoCliente = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                entidad.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                entidad.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                entidad.codigoCajero = Convert.ToInt16(ds.Tables[0].Rows[0][4]);
                
                return entidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEntidadesByCliente.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return  null;
            }
        }
        //get by empleado 
        public entidades getEntidadesByEmpleado(int id)
        {
            try
            {
                entidades entidad = new entidades();
                //validar nombre
                string sql = "select codigo,codigo_cliente,codigo_suplidor,codigo_empleado,codigo_cajero from entidades where codigo_empleado='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                entidad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                entidad.codigoCliente = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                entidad.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                entidad.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                entidad.codigoCajero = Convert.ToInt16(ds.Tables[0].Rows[0][4]);

                return entidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEntidadesByEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get by suplidor 
        public entidades getEntidadesBySuplidor(int id)
        {
            try
            {
                entidades entidad = new entidades();
                //validar nombre
                string sql = "select codigo,codigo_cliente,codigo_suplidor,codigo_empleado,codigo_cajero from entidades where codigo_suplidor='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                entidad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                entidad.codigoCliente = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                entidad.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                entidad.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                entidad.codigoCajero = Convert.ToInt16(ds.Tables[0].Rows[0][4]);

                return entidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEntidadesBySuplidor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //get by cajero
        public entidades getEntidadesByCajero(int id)
        {
            try
            {
                entidades entidad = new entidades();
                //validar nombre
                string sql = "select codigo,codigo_cliente,codigo_suplidor,codigo_empleado,codigo_cajero from entidades where codigo_cajero='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                entidad.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                entidad.codigoCliente = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                entidad.codigoSuplidor = Convert.ToInt16(ds.Tables[0].Rows[0][2]);
                entidad.codigoEmpleado = Convert.ToInt16(ds.Tables[0].Rows[0][3]);
                entidad.codigoCajero = Convert.ToInt16(ds.Tables[0].Rows[0][4]);

                return entidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEntidadesByCajero.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
