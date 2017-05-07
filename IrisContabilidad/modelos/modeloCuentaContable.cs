using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloCuentaContable
    {
        //objetos
        utilidades utilidades = new utilidades();

        //listas
        private List<cuenta_contable> listaCuentaContables;



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

                sql = "insert into catalogo_cuentas(codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo) values('" + cuenta.codigo + "','" + cuenta.nombre + "','" + cuenta.numero_cuenta + "','" + cuenta.codigo_cuenta_superior + "','" + acumulativa + "','" + movimiento + "','" + origenCredito + "','" + origenDebito + "','" + activo + "')";
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
                sql = "update catalogo_cuentas set nombre='" + cuenta.nombre + "',numero_cuenta='" + cuenta.numero_cuenta + "',codigo_cuenta_superior='" + cuenta.codigo_cuenta_superior + "',cuenta_acumulativa='" + acumulativa + "',cuenta_movimiento='" + movimiento + "',origen_credito='" + origenCredito + "',origen_debito='" + origenDebito + "',activo='" + activo + "'  where codigo='" + cuenta.codigo + "'";
                utilidades.ejecutarcomando_mysql(sql);
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
        public cuenta_contable getCuentaContableById(int id)
        {
            try
            {
                cuenta_contable cuentaContable = new cuenta_contable();
                string sql = "select codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo from catalogo_cuentas where codigo='" + id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cuentaContable.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    cuentaContable.nombre = ds.Tables[0].Rows[0][1].ToString();
                    cuentaContable.numero_cuenta = ds.Tables[0].Rows[0][2].ToString();
                    cuentaContable.codigo_cuenta_superior = Convert.ToInt16(ds.Tables[0].Rows[0][3].ToString());
                    cuentaContable.cuenta_acumulativa = Convert.ToBoolean(ds.Tables[0].Rows[0][4]);
                    cuentaContable.cuenta_movimiento = Convert.ToBoolean(ds.Tables[0].Rows[0][5]);
                    cuentaContable.origen_credito = Convert.ToBoolean(ds.Tables[0].Rows[0][6]);
                    cuentaContable.origen_debito = Convert.ToBoolean(ds.Tables[0].Rows[0][7]);
                    cuentaContable.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][8]);
                }
                return cuentaContable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getCuentaContableById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //get lista completa
        public List<cuenta_contable> getListaCompleta()
        {
            try
            {
                listaCuentaContables = new List<cuenta_contable>();
                string sql = "select codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo from catalogo_cuentas where cuenta_acumulativa='1' order by numero_cuenta;";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuenta_contable cuentaContable = new cuenta_contable();
                        cuentaContable = getCuentaContableById(Convert.ToInt16(row[0].ToString()));

                        //validar si la cuenta actual tiene hijos
                        if (validarCuentaTieneHijos(cuentaContable.codigo) == true)
                        {
                            listaCuentaContables.AddRange(getListaCuentasHijoByPadreId(cuentaContable.codigo));
                        }
                    }
                }

                listaCuentaContables = listaCuentaContables.OrderBy(x => x.numero_cuenta).ToList();
                return listaCuentaContables;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

        
        //get lista de cuentas contables hija
        public List<cuenta_contable> getListaCuentasHijoByPadreId(Int64 idCuentaPadre,bool mantenimiento=false)
        {
            try
            {
                List<cuenta_contable> lista = new List<cuenta_contable>();
                string sql = "select codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo from catalogo_cuentas where codigo_cuenta_superior='"+idCuentaPadre+"'";
                if (mantenimiento == false)
                {
                    sql += " and activo=1 order by numero_cuenta;";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuenta_contable cuentaContable = new cuenta_contable();
                        cuentaContable.codigo = Convert.ToInt16(row[0].ToString());
                        cuentaContable.nombre = row[1].ToString();
                        cuentaContable.numero_cuenta = row[2].ToString();
                        cuentaContable.codigo_cuenta_superior = Convert.ToInt16(row[3].ToString());
                        cuentaContable.cuenta_acumulativa = Convert.ToBoolean(row[4]);
                        cuentaContable.cuenta_movimiento = Convert.ToBoolean(row[5]);
                        cuentaContable.origen_credito = Convert.ToBoolean(row[6]);
                        cuentaContable.origen_debito = Convert.ToBoolean(row[7]);
                        cuentaContable.activo = Convert.ToBoolean(row[8]);
                        lista.Add(cuentaContable);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCuentasHijoByPadreId.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }

        //saber si esta cuenta tiene cuenta hijos
        public bool validarCuentaTieneHijos(Int64 idCuentaPadre)
        {
            try
            {
                bool hijos = false;//para saber si tiene hijos
                List<cuenta_contable> lista = new List<cuenta_contable>();
                string sql = "select count(*) from catalogo_cuentas where  activo=1 and codigo_cuenta_superior='"+idCuentaPadre+"';";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString()) >= 0)
                    {
                        hijos = true;
                    }
                }
                return hijos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarCuentaTieneHijos.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        //tomar el primer hijo de una cuenta contable
        public List<cuenta_contable> getListaCuentaContablesHijos(Int64 idCuentaPadre)
        {
            try
            {
                List<cuenta_contable> lista = new List<cuenta_contable>();
                string sql = "select codigo,nombre,numero_cuenta,codigo_cuenta_superior,cuenta_acumulativa,cuenta_movimiento,origen_credito,origen_debito,activo from catalogo_cuentas where codigo_cuenta_superior='" + idCuentaPadre + "' order by numero_cuenta;";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuenta_contable cuentaContable = new cuenta_contable();
                        cuentaContable.codigo = Convert.ToInt16(row[0].ToString());
                        cuentaContable.nombre = row[1].ToString();
                        cuentaContable.numero_cuenta = row[2].ToString();
                        cuentaContable.codigo_cuenta_superior = Convert.ToInt16(row[3].ToString());
                        cuentaContable.cuenta_acumulativa = Convert.ToBoolean(row[4]);
                        cuentaContable.cuenta_movimiento = Convert.ToBoolean(row[5]);
                        cuentaContable.origen_credito = Convert.ToBoolean(row[6]);
                        cuentaContable.origen_debito = Convert.ToBoolean(row[7]);
                        cuentaContable.activo = Convert.ToBoolean(row[8]);
                        lista.Add(cuentaContable);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCuentaContablesHijos.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
