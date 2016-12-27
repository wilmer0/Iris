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
                string sql = "select *from empelado where identificacion='" + empleado.nombre + "' || pasaporte='"+empleado.pasaporte+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un empleado con esa identificacion con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (empleado.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into empleado() values('','')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarEmpleado(cargo cargoAPP)
        {
            try
            {
                int activo = 0;
                string sql = "select *from cargo where nombre='" + cargoAPP.nombre + "' and id!='" + cargoAPP.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un cargo con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                if (cargoAPP.activo == true)
                {
                    activo = 1;
                }
                sql = "update cargo set nombre='" + cargoAPP.nombre + "',activo='" + activo.ToString() + "' where id='" + cargoAPP.id + "'";
                ds = utilidades.ejecutarcomando(sql);
                MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarEmpleado.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente sucursal
        public int getNext()
        {
            try
            {
                int id = 0;
                string sql = "select max(codigo)from empleado";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                }
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




        public List<string> GetListaModulosByEmpleado(empleado empleado)
        {
            try
            {
                //listas
                List<string> listaModulos = new List<string>();
                string sql = "";
                sql = "SELECT id_ventana_sistema FROM empleado_accesos_ventanas  where  id_empleado ='"+empleado.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
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

        public List<empleado> getListaCompleta()
        {
            try
            {
                List<empleado> listaEmpleado = new List<empleado>();
                string sql ="select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_gripo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where activo='1'";
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

        public empleado getEmpleadoByLogin(string usuario,string clave)
        {
            try
            {
                empleado = new empleado();
                List<empleado> listaEmpleado = new List<empleado>();
                string sql ="select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where login='"+usuario+"' and clave='"+clave+"'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    empleado.codigo = Convert.ToInt16(row[0]);
                    empleado.nombre = row[1].ToString();
                    empleado.login = row[2].ToString();
                    empleado.clave = row[3].ToString();
                    empleado.sueldo = (decimal)row[4];
                    empleado.codigo_situacion = (int)row[5];
                    empleado.activo = (bool)row[6];
                    empleado.codigo_sucursal = (int)row[7];
                    empleado.codigo_departamento = Convert.ToInt16(row[8]);
                    empleado.codigo_cargo = Convert.ToInt16(row[9]);
                    empleado.codigo_grupo_usuario = Convert.ToInt16(row[10]);
                    empleado.fecha_ingreso = (DateTime)row[11];
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

        public empleado getEmpleadoById(int id)
        {
            try
            {
                empleado empleado = new empleado();
                string sql = "select codigo,nombre,login,clave,sueldo,cod_situacion,activo,cod_sucursal,cod_departamento,cod_cargo,cod_grupo_usuario,fecha_ingreso,permiso,cod_tipo_nomina,identificacion,pasaporte from empleado where codigo='" + id + "'";
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
                MessageBox.Show("Error getEmpleadoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public void adminPrimerLogin()
        {
            try
            {
                string sql = "select codigo,nombre_ventana,nombre_logico,imagen,activo,programador FROM sistema_ventanas";
                DataSet ventanas = utilidades.ejecutarcomando_mysql(sql);
                //ingresando acceso a ventanas del primer usuario
                foreach (DataRow row in ventanas.Tables[0].Rows)
                {
                    sql = "insert into empleado_accesos_ventanas(id_empleado,id_ventana_sistema) values('1','"+row[0].ToString()+"')";
                    utilidades.ejecutarcomando_mysql(sql);
                }
                //agregando el primer modulo
                sql ="insert into sistema_modulo(id,nombre,activo,nombre_modulo_proyecto,imagen) values('1','modulo_empresa','1','IrisContabilidad.modulo_empresa','empresa1.png')";
                utilidades.ejecutarcomando_mysql(sql);
                //agregando todas las ventanas al primer modulo
                foreach (DataRow row in ventanas.Tables[0].Rows)
                {
                    sql = "insert into modulos_vs_ventanas(id_modulo,id_ventana) values('1','" + row[0].ToString() + "')";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adminCargarVentanas.: " + ex.ToString());
            }
        }

    }
}
