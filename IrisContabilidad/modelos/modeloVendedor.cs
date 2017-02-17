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
    public class modeloVendedor
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarVendedor(vendedor vendedor)
        {
            try
            {
                int activo = 0;
                //validar empleado no se repita
                string sql = "select *from vendedor where cod_empleado='" + vendedor.codigo_empelado + "' and codigo!='" + vendedor.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un vendedor con ese empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (vendedor.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into vendedor(codigo,cod_empleado,porciento,activo) values('" + vendedor.codigo + "','" + vendedor.codigo_empelado + "','" + vendedor.porciento_ganancia + "','" + activo.ToString() + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVendedor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarVendedor(vendedor vendedor)
        {
            try
            {
                int activo = 0;
                //validar empleado no se repita
                string sql = "select *from vendedor where cod_empleado='" + vendedor.codigo_empelado + "' and codigo!='" + vendedor.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un vendedor con ese empleado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }



                if (vendedor.activo == true)
                {
                    activo = 1;
                }
                sql = "update vendedor set cod_empleado='" + vendedor.codigo_empelado + "',porciento='" + vendedor.porciento_ganancia + "',activo='" + activo.ToString() + "' where codigo='" + vendedor.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarVendedor.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from vendedor";
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
        public vendedor getVendedorById(int id)
        {
            try
            {
                vendedor vendedor = new vendedor();
                string sql = "select codigo,cod_empleado,porciento,activo from vendedor where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    vendedor.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    vendedor.codigo_empelado = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
                    vendedor.porciento_ganancia = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                    vendedor.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                }
                return vendedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVendedorById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<vendedor> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<vendedor> lista = new List<vendedor>();
                string sql = "select codigo,cod_empleado,porciento,activo from vendedor ";
                if (mantenimiento == false)
                {
                    sql += " where activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        vendedor vendedor = new vendedor();
                        vendedor.codigo = Convert.ToInt16(row[0]);
                        vendedor.codigo_empelado = Convert.ToInt16(row[1]);
                        vendedor.porciento_ganancia = Convert.ToDecimal(row[2]);
                        vendedor.activo = Convert.ToBoolean(row[3]);
                        lista.Add(vendedor);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        //get lista completa por sucursal
        public List<vendedor> getListaBySucursal(int id)
        {
            try
            {

                List<vendedor> lista = new List<vendedor>();
                string sql = "";
                sql = "select v.codigo,v.cod_empleado,v.porciento,v.activo from vendedor v join empleado e on e.codigo=v.cod_empleado and e.cod_sucursal='" + id + "' where e.activo='1' and v.activo='1';";

                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        vendedor vendedor = new vendedor();
                        vendedor.codigo = Convert.ToInt16(row[0].ToString());
                        vendedor.codigo_empelado = Convert.ToInt16(row[1].ToString());
                        vendedor.porciento_ganancia = Convert.ToDecimal(row[2].ToString());
                        vendedor.activo = Convert.ToBoolean(row[3]);
                        lista.Add(vendedor);
                    }
                }
                lista = lista.OrderBy(x => x.codigo).ToList();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
