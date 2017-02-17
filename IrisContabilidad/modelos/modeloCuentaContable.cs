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
    public class modeloCuentaContable
    {
        //objetos
        utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarCuentaContable(cuenta_contable cuenta)
        {
            try
            {
                int activo = 0;
                int origenCredito = 0;
                int origenDebito = 0;
                int acumulativa = 0;
                int movimiento = 0;
                //validar numero cuenta
                string sql = "select *from catalogo_cuentas where numero_cuenta='" + cuenta.numero_cuenta + "' and codigo!='" + cuenta.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cuenta con ese mismo número de cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre
                sql = "select *from catalogo_cuentas where nombre='" + cuenta.nombre + "' and codigo!='" + cuenta.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cuenta con ese mismo nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cuenta.activo == true)
                {
                    activo = 1;
                }
                if (cuenta.origen_credito == true)
                {
                    origenCredito= 1;
                }
                if (cuenta.origen_debito == true)
                {
                    origenDebito = 1;
                }
                if (cuenta.cuenta_acumulativa == true)
                {
                    acumulativa = 1;
                }
                if (cuenta.cuenta_movimiento == true)
                {
                    movimiento = 1;
                }

                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo) values('" + cuenta.codigo + "','" + cuenta.nombre + "','" + cuenta.numero_cuenta + "','" + cuenta.cuenta_superior + "','" + acumulativa + "','" + movimiento + "','" + origenCredito + "','" + origenDebito + "','" + activo + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarCuentaContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarCuentaContable(cuenta_contable cuenta)
        {
            try
            {
                int activo = 0;
                int origenCredito = 0;
                int origenDebito = 0;
                int acumulativa = 0;
                int movimiento = 0;
                //validar numero cuenta
                string sql = "select *from catalogo_cuentas where numero_cuenta='" + cuenta.numero_cuenta + "' and codigo!='" + cuenta.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cuenta con ese mismo número de cuenta", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre
                sql = "select *from catalogo_cuentas where nombre='" + cuenta.nombre + "' and codigo!='" + cuenta.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una cuenta con ese mismo nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cuenta.activo == true)
                {
                    activo = 1;
                }
                if (cuenta.origen_credito == true)
                {
                    origenCredito = 1;
                }
                if (cuenta.origen_debito == true)
                {
                    origenDebito = 1;
                }
                if (cuenta.cuenta_acumulativa == true)
                {
                    acumulativa = 1;
                }
                if (cuenta.cuenta_movimiento == true)
                {
                    movimiento = 1;
                }
                sql = "update almacen set  where codigo='" + cuenta.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarCuentaContable.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from catalogo_cuentas";
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
        public almacen getAlmacenById(int id)
        {
            try
            {
                almacen almacen = new almacen();
                string sql = "select codigo,nombre,cod_sucursal,activo from almacen where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    almacen.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    almacen.nombre = ds.Tables[0].Rows[0][1].ToString();
                    almacen.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][2].ToString());
                    almacen.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                }
                return almacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getAlmacenById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<almacen> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<almacen> lista = new List<almacen>();
                string sql = "";
                sql = "select codigo,nombre,cod_sucursal,activo from almacen";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        almacen almacen = new almacen();
                        almacen.codigo = Convert.ToInt16(row[0].ToString());
                        almacen.nombre = row[1].ToString();
                        almacen.codigo_sucursal = Convert.ToInt16(row[2].ToString());
                        almacen.activo = Convert.ToBoolean(row[3]);
                        lista.Add(almacen);
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
