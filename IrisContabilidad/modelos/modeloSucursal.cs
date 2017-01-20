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
                sql = "insert into sucursal(codigo,codigo_empresa,secuencia,activo,direccion,telefono1,telefono2,fax) values('" +sucursal.codigo + "','" + sucursal.codigo_empresa + "','" + sucursal.secuencia + "','" + activo.ToString() + "','" + sucursal.direccion + "','"+sucursal.telefono1+"','"+sucursal.telefono2+"','"+sucursal.fax+"')";
                ds = utilidades.ejecutarcomando_mysql(sql);
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

                //se modifica  
                sql = "update sucursal set codigo_empresa='" + sucursal.codigo_empresa + "',secuencia='" + sucursal.secuencia + "',activo='" + activo + "',direccion='" + sucursal.direccion + "',telefono1='"+sucursal.telefono1+"',telefono2='"+sucursal.telefono2+"',fax='"+sucursal.fax+"' where codigo='" + sucursal.codigo + "'";
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
                string sql = "select codigo,codigo_empresa,secuencia,activo,direccion from sucursal,telefono1,telefono2,fax where codigo='" + id +"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sucursal.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    sucursal.codigo_empresa = Convert.ToInt16(ds.Tables[0].Rows[0][1].ToString());
                    sucursal.secuencia = ds.Tables[0].Rows[0][2].ToString();
                    sucursal.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3].ToString());
                    //if (ds.Tables[0].Rows[0][3].ToString() == "True")
                    //{
                    //    sucursal.activo = true;
                    //}
                    //else
                    //{
                    //    sucursal.activo = false;
                    //}
                    sucursal.direccion = ds.Tables[0].Rows[0][4].ToString();

                }
                return sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                sql = "select codigo,codigo_empresa,secuencia,activo,direccion,telefono1,telefono2,fax from sucursal ";
                if (mantenimiento == false)
                {
                    sql+=" where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sucursal = new sucursal();
                        sucursal.codigo = Convert.ToInt16(row[0].ToString());
                        sucursal.codigo_empresa = Convert.ToInt16(row[1].ToString());
                        sucursal.secuencia = row[2].ToString();
                        sucursal.activo = Convert.ToBoolean(row[3].ToString());
                        sucursal.direccion = row[4].ToString();
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

    }
}
