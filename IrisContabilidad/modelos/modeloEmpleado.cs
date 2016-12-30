﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IrisContabilidad.clases;
using empleado = IrisContabilidad.clases.empleado;

namespace IrisContabilidad.modelos
{
    internal class modeloEmpleado
    {
        //objetos
        private utilidades utilidades = new utilidades();
        private empleado empleado;



        //agregar 
        public bool agregarEmpleado(empleado empleado)
        {
            try
            {
                int activo = 0;
                //validar identificacion
                string sql = "select *from empleado where identificacion='" + empleado.identificacion +
                             "' and identificacion!='' and codigo!='" + empleado.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con esa identificacion con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                //validar pasaporte
                sql = "select *from empleado where pasaporte='" + empleado.pasaporte +
                      "' and pasaporte!='' and codigo!='" + empleado.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con ese login", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar login
                sql = "select *from empleado where login='" + empleado.login + "' and codigo!='" + empleado.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con ese login", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (empleado.activo == true)
                {
                    activo = 1;
                }
                sql =
                    "insert into empleado(codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte) values('" +
                    empleado.codigo + "','" + empleado.nombre + "','" + empleado.login + "','" + empleado.clave + "','" +
                    empleado.sueldo + "','" + empleado.codigo_situacion + "','" + activo + "','" +
                    empleado.codigo_sucursal + "','" + empleado.codigo_departamento + "','" + empleado.codigo_cargo +
                    "','" + empleado.codigo_grupo_usuario + "','" + empleado.fecha_ingreso.ToString("yyyy-MM-dd") +
                    "','" + empleado.tipo_permiso + "','" + empleado.codigo_tipo_nomina + "','" +
                    empleado.identificacion + "','" + empleado.pasaporte + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarEmpleado(empleado empleado)
        {
            try
            {
                int activo = 0;
                //validar identificacion
                string sql = "select *from empleado where identificacion='" + empleado.identificacion +
                             "' and identificacion!='' and codigo!='" + empleado.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con esa identificacion con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                //validar pasaporte
                sql = "select *from empleado where pasaporte='" + empleado.pasaporte +
                      "' and pasaporte!='' and codigo!='" + empleado.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con ese login", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar login
                sql = "select *from empleado where login='" + empleado.login + "' and codigo!='" + empleado.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con ese login", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (empleado.activo == true)
                {
                    activo = 1;
                }
                sql = "update empleado set nombre='" + empleado.nombre + "',login='" + empleado.login + "',clave='" +
                      empleado.clave + "',sueldo='" + empleado.sueldo + "',cod_situacion='" + empleado.codigo_situacion +
                      "',activo='" + activo + "',cod_sucursal='" + empleado.codigo_sucursal + "',cod_departamento='" +
                      empleado.codigo_departamento + "',cod_cargo='" + empleado.codigo_cargo + "',cod_grupo_usuario='" +
                      empleado.codigo_grupo_usuario + "',fecha_ingreso='" +
                      empleado.fecha_ingreso.ToString("yyyy-MM-dd") + "',permiso='" + empleado.tipo_permiso +
                      "',cod_tipo_nomina='" + empleado.codigo_tipo_nomina + "',identificacion='" +
                      empleado.identificacion + "',pasaporte='" + empleado.pasaporte + "' where codigo='" +
                      empleado.codigo + "'";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente sucursal
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from empleado";
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

        //validar login
        public Boolean validarLogin(string usuario, string clave)
        {
            try
            {

                //hacer select de usuario y clave
                string sql = "";
                sql = "select *from empleado where login='" + usuario + "' and clave='" + clave + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validarLogin.: " + ex.ToString());
                return false;
            }
        }



        //get modulos by empleado
        public List<string> GetListaModulosByEmpleado(empleado empleado)
        {
            try
            {
                //listas
                List<string> listaModulos = new List<string>();
                string sql = "";
                sql = "SELECT id_ventana_sistema FROM empleado_accesos_ventanas  where  id_empleado ='" +empleado.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //hacer select para saber a que modulo pertenece esa ventana
                    string sql2 = "";
                    sql2 = "SELECT id_modulo FROM modulos_vs_ventanas  where id_ventana='" + row[0] + "'";
                    DataSet ds2 = utilidades.ejecutarcomando_mysql(sql2);
                    //MessageBox.Show(ds2.Tables[0].Rows[0][0].ToString());
                    if (ds2.Tables[0].Rows[0][0].ToString() != null)
                    {
                        listaModulos.Add(ds2.Tables[0].Rows[0][0].ToString());
                    }
                }

                listaModulos = listaModulos.Distinct().ToList();
                return listaModulos;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error GetListaModulosByEmpleado.: " + ex.ToString());
                return null;
            }
        }

        //get lista completa
        public List<empleado> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                List<empleado> listaEmpleado = new List<empleado>();
                string sql =
                    "select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado";
                if (mantenimiento == false)
                {
                    sql += "  where activo='1'";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    clases.empleado empleado = new empleado();
                    empleado.codigo = (int) row[0];
                    empleado.nombre = row[1].ToString();
                    empleado.login = row[2].ToString();
                    empleado.clave = row[3].ToString();
                    empleado.sueldo = (decimal) row[4];
                    empleado.codigo_situacion = (int) row[5];
                    empleado.activo = (bool) row[6];
                    empleado.codigo_sucursal = (int) row[7];
                    empleado.codigo_departamento = (int) row[8];
                    empleado.codigo_cargo = (int) row[9];
                    empleado.codigo_grupo_usuario = (int) row[10];
                    empleado.fecha_ingreso = (DateTime) row[11];
                    empleado.tipo_permiso = row[12].ToString();
                    empleado.codigo_tipo_nomina = (int) row[13];
                    empleado.identificacion = row[14].ToString();
                    empleado.pasaporte = row[15].ToString();

                    listaEmpleado.Add(empleado);
                }
                return listaEmpleado;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error getListaCompleta.: " + ex.ToString());
                return null;
            }
        }

        //get by login
        public empleado getEmpleadoByLogin(string usuario, string clave)
        {
            try
            {
                empleado = new empleado();
                List<empleado> listaEmpleado = new List<empleado>();
                string sql =
                    "select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where login='" +
                    usuario + "' and clave='" + clave + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    empleado.codigo = Convert.ToInt16(row[0]);
                    empleado.nombre = row[1].ToString();
                    empleado.login = row[2].ToString();
                    empleado.clave = row[3].ToString();
                    empleado.sueldo = (decimal) row[4];
                    empleado.codigo_situacion = (int) row[5];
                    empleado.activo = (bool) row[6];
                    empleado.codigo_sucursal = (int) row[7];
                    empleado.codigo_departamento = Convert.ToInt16(row[8]);
                    empleado.codigo_cargo = Convert.ToInt16(row[9]);
                    empleado.codigo_grupo_usuario = Convert.ToInt16(row[10]);
                    empleado.fecha_ingreso = (DateTime) row[11];
                    empleado.tipo_permiso = row[12].ToString();
                    empleado.codigo_tipo_nomina = Convert.ToInt16(row[13]);
                    empleado.identificacion = row[14].ToString();
                    empleado.pasaporte = row[15].ToString();

                }
                return empleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpleadoByLogin.: " + ex.ToString());
                return null;
            }
        }

        //get by id
        public empleado getEmpleadoById(int id)
        {
            try
            {
                empleado empleado = new empleado();
                string sql =
                    "select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where codigo='" +
                    id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    /* 
                        codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,
                        cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,
                        cod_tipo_nomina,identificacion,pasaporte
                     */
                    empleado.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    empleado.nombre = ds.Tables[0].Rows[0][1].ToString();
                    empleado.login = ds.Tables[0].Rows[0][2].ToString();
                    empleado.clave = ds.Tables[0].Rows[0][3].ToString();
                    empleado.sueldo = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString());
                    empleado.codigo_situacion = Convert.ToInt16(ds.Tables[0].Rows[0][5].ToString());
                    empleado.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][6].ToString());
                    empleado.codigo_sucursal = Convert.ToInt16(ds.Tables[0].Rows[0][7].ToString());
                    empleado.codigo_departamento = Convert.ToInt16(ds.Tables[0].Rows[0][8].ToString());
                    empleado.codigo_cargo = Convert.ToInt16(ds.Tables[0].Rows[0][9].ToString());
                    empleado.codigo_grupo_usuario = Convert.ToInt16(ds.Tables[0].Rows[0][10].ToString());
                    empleado.fecha_ingreso = Convert.ToDateTime(ds.Tables[0].Rows[0][11].ToString());
                    empleado.tipo_permiso = ds.Tables[0].Rows[0][12].ToString();
                    empleado.codigo_tipo_nomina = Convert.ToInt16(ds.Tables[0].Rows[0][13].ToString());
                    empleado.identificacion = ds.Tables[0].Rows[0][14].ToString();
                    empleado.pasaporte = ds.Tables[0].Rows[0][15].ToString();
                }
                return empleado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpleadoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
