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
    public class modeloSucursal
    {
        //objetos
        private utilidades utilidades = new utilidades();
        sucursal sucursal = new sucursal();


        //agregar sucursal
        public bool agregarSucursal(sucursal sucursal)
        {
            try
            {

                string sql = "";
                DataSet ds = new DataSet();


                //validaciones
                sql = "select *from sucursal where secuencia='" + sucursal.secuencia + "' and codigo!='"+sucursal.codigo+"'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //existe una sucursal con esa secuencia
                    MessageBox.Show("No se agregó, existe una sucursal con la misma secuencia", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                int activo = 0;
                if (sucursal.activo == true)
                {
                    //MessageBox.Show(Convert.ToInt16(empresaApp.activo).ToString());
                    activo = 1;
                }

                //se agrega  
                sql = "insert into sucursal(codigo,codigo_empresa,secuencia,activo,direccion,telefono1,telefono2,fax,version_sistema,version_sistema,maxima) values('" +sucursal.codigo + "','" + sucursal.codigo_empresa + "','" + sucursal.secuencia + "','" + activo + "','" + sucursal.direccion + "','"+sucursal.telefono1+"','"+sucursal.telefono2+"','"+sucursal.fax+"','"+sucursal.versionSistema+"','"+sucursal.versionSistemaMaxima+"')";
                utilidades.ejecutarcomando_mysql(sql);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarSucursal.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar sucursal
        public bool modificarSucursal(sucursal sucursal)
        {
            try
            {

                string sql = "";
                DataSet ds = new DataSet();


                //validaciones
                sql = "select *from sucursal where secuencia='" + sucursal.secuencia + "' and codigo!='" + sucursal.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //existe una sucursal con esa secuencia
                    MessageBox.Show("No se agregó, existe una sucursal con la misma secuencia", "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }

                int activo = 0;
                if (sucursal.activo == true)
                {
                    //MessageBox.Show(Convert.ToInt16(empresaApp.activo).ToString());
                    activo = 1;
                }

                //se modifica  
                sql = "update sucursal set codigo_empresa='" + sucursal.codigo_empresa + "',secuencia='" + sucursal.secuencia + "',activo='" + activo + "',direccion='" + sucursal.direccion + "',telefono1='"+sucursal.telefono1+"',telefono2='"+sucursal.telefono2+"',fax='"+sucursal.fax+"',version_sistema='"+sucursal.versionSistema+"',version_sistema_maxima='"+sucursal.versionSistemaMaxima+"' where codigo='" + sucursal.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarSucursal.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
        
        //obtener el codigo siguiente sucursal
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from sucursal";
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
        
        //get sucursal
        public sucursal getSucursalById(int id)
        {
            try
            {
                sucursal sucursal = new sucursal();
                string sql = "select codigo,codigo_empresa,secuencia,activo,direccion,telefono1,telefono2,fax,version_sistema,version_sistema_maxima from sucursal where codigo='" + id +"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sucursal.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    sucursal.codigo_empresa = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    sucursal.secuencia = ds.Tables[0].Rows[0][2].ToString();
                    sucursal.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                    sucursal.direccion = ds.Tables[0].Rows[0][4].ToString();
                    sucursal.telefono1 = ds.Tables[0].Rows[0][5].ToString();
                    sucursal.telefono2 = ds.Tables[0].Rows[0][6].ToString();
                    sucursal.fax = ds.Tables[0].Rows[0][7].ToString();
                    sucursal.versionSistema = Convert.ToInt16(ds.Tables[0].Rows[0][8]);
                    sucursal.versionSistemaMaxima = Convert.ToInt16(ds.Tables[0].Rows[0][9]);
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalById.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<sucursal> getListaCompleta(bool mantenimiento=false)
        {
            try
            {
               
                List<sucursal> lista =new List<sucursal>();
                string sql = "";
                sql = "select codigo,codigo_empresa,secuencia,activo,direccion,telefono1,telefono2,fax,version_sistema,version_sistema_maxima from sucursal";
                if (mantenimiento == false)
                {
                    sql+=" where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sucursal.codigo = Convert.ToInt16(row[0]);
                        sucursal.codigo_empresa = Convert.ToInt16(row[1]);
                        sucursal.secuencia = row[2].ToString();
                        sucursal.activo = Convert.ToBoolean(row[3]);
                        sucursal.direccion = row[4].ToString();
                        sucursal.telefono1 = row[5].ToString();
                        sucursal.telefono2 = row[6].ToString();
                        sucursal.fax = row[7].ToString();
                        sucursal.versionSistema = Convert.ToInt16(row[8]);
                        sucursal.versionSistemaMaxima = Convert.ToInt16(row[9]);
                        lista.Add(sucursal);
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

        //get sucursal
        public sucursal getSucursalByEmpleado(int id)
        {
            try
            {
                sucursal sucursal = new sucursal();
                string sql = "select s.codigo,s.codigo_empresa,s.secuencia,s.activo,s.direccion,s.telefono1,s.telefono2,s.fax,s.version_sistema,s.version_sistema_maxima from sucursal s join empleado e on s.codigo=e.cod_sucursal where e.codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sucursal.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    sucursal.codigo_empresa = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    sucursal.secuencia = ds.Tables[0].Rows[0][2].ToString();
                    sucursal.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    sucursal.direccion = ds.Tables[0].Rows[0][4].ToString();
                    sucursal.telefono1 = ds.Tables[0].Rows[0][5].ToString();
                    sucursal.telefono2 = ds.Tables[0].Rows[0][6].ToString();
                    sucursal.fax = ds.Tables[0].Rows[0][7].ToString();
                    sucursal.versionSistema = Convert.ToInt16(ds.Tables[0].Rows[0][8]);
                    sucursal.versionSistemaMaxima = Convert.ToInt16(ds.Tables[0].Rows[0][9]);
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalByEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
