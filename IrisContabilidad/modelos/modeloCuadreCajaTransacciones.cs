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
    public class modeloCuadreCajaTransacciones
    {
        //objetos
        utilidades utilidades = new utilidades();



        //agregar 
        public bool agregarCuadreCajaTransaccion(cuadre_caja_transacciones transaccion)
        {
            try
            {
                string sql = "insert into cuadre_caja_transacciones(codigo_cuadre_caja,codigo_venta,codigo_cobro,codigo_ingreso_caja,codigo_egreso_caja,codigo_nota_credito,codigo_nota_debito,codigo_gasto,codigo_pago) values('" + transaccion.codigoCuadreCaja + "','" + transaccion.codigoVenta + "','" + transaccion.codigoCobro + "','" + transaccion.codigoIngresoCaja + "','" + transaccion.codigoEgresoCaja + "','" + transaccion.codigoNotaCredito + "','" + transaccion.codigoNotaDebito + "','" + transaccion.codigoGasto + "','" + transaccion.codigoPago + "');";
                utilidades.ejecutarcomando_mysql(sql);
                if (transaccion.codigoVenta != null && transaccion.codigoVenta>=1)
                {
                    sql = "update venta set cuadrado='1' where codigo='"+transaccion.codigoVenta+"';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoCobro != null && transaccion.codigoCobro >= 1)
                {
                    sql = "update venta_vs_cobros set cuadrado='1' where codigo='" + transaccion.codigoCobro + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoIngresoCaja != null && transaccion.codigoIngresoCaja >= 1)
                {
                    sql = "update ingresos_caja set cuadrado='1' where codigo='" + transaccion.codigoIngresoCaja + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoEgresoCaja != null && transaccion.codigoEgresoCaja >= 1)
                {
                    sql = "update egresos_caja set cuadrado='1' where codigo='" + transaccion.codigoEgresoCaja + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoNotaCredito != null && transaccion.codigoNotaCredito >= 1)
                {
                    sql = "update cxc_nota_credito set cuadrado='1' where codigo='" + transaccion.codigoNotaCredito + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoNotaDebito != null && transaccion.codigoNotaDebito >= 1)
                {
                    sql = "update cxc_nota_debito set cuadrado='1' where codigo='" + transaccion.codigoNotaDebito + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoGasto != null && transaccion.codigoGasto >= 1)
                {
                    sql = "update gastos set cuadrado='1' where codigo='" + transaccion.codigoGasto + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                else if (transaccion.codigoPago != null && transaccion.codigoPago >= 1)
                {
                    sql = "update compra_vs_pagos set cuadrado='1' where codigo='" + transaccion.codigoPago + "';";
                    utilidades.ejecutarcomando_mysql(sql);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregando cuadre caja transaccion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //agregar 
        public bool agregarCuadreCajaTransaccion(List<cuadre_caja_transacciones> lista)
        {
            try
            {
                foreach (var x in lista)
                {
                    agregarCuadreCajaTransaccion(x);
                }
               
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregando cuadre caja transaccion.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //get lista completa
        public List<cuadre_caja_transacciones> getListaCompleta()
        {
            try
            {
                List<cuadre_caja_transacciones> lista = new List<cuadre_caja_transacciones>();
                string sql = "";
                sql = "select codigo_cuadre_caja,codigo_venta,codigo_cobro,codigo_ingreso_caja,codigo_egreso_caja,codigo_nota_credito,codigo_nota_debito,codigo_gasto,codigo_pago from cuadre_caja_transacciones;";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuadre_caja_transacciones transacciones = new cuadre_caja_transacciones();
                        transacciones.codigoCuadreCaja = Convert.ToInt16(row[0]);
                        transacciones.codigoVenta = Convert.ToInt16(row[1]);
                        transacciones.codigoCobro = Convert.ToInt16(row[2]);
                        transacciones.codigoIngresoCaja = Convert.ToInt16(row[3]);
                        transacciones.codigoEgresoCaja = Convert.ToInt16(row[4]);
                        transacciones.codigoNotaCredito = Convert.ToInt16(row[5]);
                        transacciones.codigoNotaDebito = Convert.ToInt16(row[6]);
                        transacciones.codigoGasto = Convert.ToInt16(row[7]);
                        transacciones.codigoPago = Convert.ToInt16(row[8]);
                        
                        lista.Add(transacciones);
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

        //get lista completa by cuadre caja
        public List<cuadre_caja_transacciones> getListaCompletaByCuadreCajaId(int codigoCuadreCaja)
        {
            try
            {
                List<cuadre_caja_transacciones> lista = new List<cuadre_caja_transacciones>();
                string sql = "";
                sql = "select codigo_cuadre_caja,codigo_venta,codigo_cobro,codigo_ingreso_caja,codigo_egreso_caja,codigo_nota_credito,codigo_nota_debito,codigo_gasto,codigo_pago from cuadre_caja_transacciones where codigo_cuadre_caja='"+codigoCuadreCaja+"';";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cuadre_caja_transacciones transacciones = new cuadre_caja_transacciones();
                        transacciones.codigoCuadreCaja = Convert.ToInt16(row[0]);
                        transacciones.codigoVenta = Convert.ToInt16(row[1]);
                        transacciones.codigoCobro = Convert.ToInt16(row[2]);
                        transacciones.codigoIngresoCaja = Convert.ToInt16(row[3]);
                        transacciones.codigoEgresoCaja = Convert.ToInt16(row[4]);
                        transacciones.codigoNotaCredito = Convert.ToInt16(row[5]);
                        transacciones.codigoNotaDebito = Convert.ToInt16(row[6]);
                        transacciones.codigoGasto = Convert.ToInt16(row[7]);
                        transacciones.codigoPago = Convert.ToInt16(row[8]);

                        lista.Add(transacciones);
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
