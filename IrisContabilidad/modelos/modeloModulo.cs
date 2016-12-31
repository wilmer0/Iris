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
    public class modeloModulo
    {
        //objetos
        utilidades utilidades = new utilidades();

        //agregar ventana
        public bool agregarVentana(ventana ventana)
        {
            try
            {
                int activo = 0;
                int programador = 0;
                ventana.codigo = getNextVentana();
                
                //validar nombre
                string sql = "select *from sistema_ventanas where nombre_ventana='" + ventana.nombre_ventana + "' and codigo!='" + ventana.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un modulo con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre_logico
                sql = "select *from sistema_ventanas where nombre_logico='" + ventana.nombre_logico + "' and codigo!='" + ventana.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe una ventana con ese nombre lógico", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (ventana.activo == true)
                {
                    activo = 1;
                }
                if (ventana.programador == true)
                {
                    programador = 1;
                }

                sql = "insert into sistema_ventanas(codigo,nombre_ventana,nombre_logico,imagen,activo,programador) values('" + ventana.codigo + "','" + ventana.nombre_ventana + "','" + ventana.nombre_logico + "','" + ventana.imagen + "','" + activo.ToString() + "','" + programador + "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //agregar ventana
        public bool agregarModulo(modulo modulo)
        {
            try
            {
                int activo = 0;
                modulo.id = getNextModulo();
                //validar nombre
                string sql = "select *from sistema_modulo where nombre='" + modulo.nombre + "' and id!='" + modulo.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un modulo con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre_modulo_proyecto
                sql = "select *from sistema_modulo where nombre_modulo_proyecto='" + modulo.nombre + "' and id!='" + modulo.id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un modulo con ese nombre de proyecto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (modulo.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into sistema_modulo(id,nombre,activo,nombre_modulo_proyecto,imagen) values('" + modulo.id + "','" + modulo.nombre + "','" + activo.ToString() + "','"+modulo.nombre_logico+"','"+modulo.imagen+"')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarModulo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //agregar ventana
        public bool agregarModulo(List<modulo> listaModulo)
        {
            try
            {
                listaModulo.ForEach(moduloActual =>
                {
                   
                int activo = 0;
                moduloActual.id = getNextModulo();
                //validar nombre
                string sql = "select *from sistema_modulo where nombre='" + moduloActual.nombre + "' and id!='" + moduloActual.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        //validar nombre_modulo_proyecto
                        sql = "select *from sistema_modulo where nombre_modulo_proyecto='" + moduloActual.nombre +"' and id!='" + moduloActual.id + "'";
                        ds = utilidades.ejecutarcomando_mysql(sql);
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            if (moduloActual.activo == true)
                            {
                                activo = 1;
                            }
                            sql ="insert into sistema_modulo(id,nombre,activo,nombre_modulo_proyecto,imagen) values('" +moduloActual.id + "','" + moduloActual.nombre + "','" + activo.ToString() + "','" +
                            moduloActual.nombre_logico + "','" + moduloActual.imagen + "')";
                            //MessageBox.Show(sql);
                            ds = utilidades.ejecutarcomando_mysql(sql);
                        }
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarModulo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarModulo(modulo modulo)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from sistema_modulo where nombre='" + modulo.nombre + "' and id!='" + modulo.id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un modulo con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //validar nombre_modulo_proyecto
                sql = "select *from sistema_modulo where nombre_modulo_proyecto='" + modulo.nombre + "' and id!='" + modulo.id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un modulo con ese nombre de proyecto", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (modulo.activo == true)
                {
                    activo = 1;
                }
                sql = "update sistema_modulo set nombre='" + modulo.nombre + "',activo='" + activo.ToString() + "',nombre_modulo_proyecto='" +modulo.nombre_logico+ "',imagen='"+modulo.imagen+"' where id='" + modulo.id + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificarModulo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public modulo getModuloByid(int id)
        {
            try
            {
                modulo modulo=new modulo();
                string sql = "select id,nombre,activo,imagen from sistema_modulo where id='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    modulo.id = (int)ds.Tables[0].Rows[0][0];
                    modulo.nombre = ds.Tables[0].Rows[0][1].ToString();
                    modulo.activo = (bool)ds.Tables[0].Rows[0][2];
                    modulo.imagen = ds.Tables[0].Rows[0][3].ToString();
                }

                return modulo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getModuloByid.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<string> getVentanasByModuloId(int id)
        {
            try
            {
                List<string> listaVentanas=new List<string>();
                ventana ventana=new ventana();
                string sql = "SELECT id_modulo,id_ventana FROM modulos_vs_ventanas where id_modulo='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ventana.codigo = (int) row[1];
                        listaVentanas.Add(row[1].ToString());
                    }
                }

                return listaVentanas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentanasByModuloId.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ventana getVentanaById(int id)
        {
            try
            {
                ventana ventana = new ventana();
                string sql = "SELECT codigo,nombre_ventana,nombre_logico,imagen,activo,programador FROM sistema_ventanas s where codigo ='" + id.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ventana.codigo = (int)ds.Tables[0].Rows[0][0];
                    ventana.nombre_ventana = ds.Tables[0].Rows[0][1].ToString();
                    ventana.nombre_logico = ds.Tables[0].Rows[0][2].ToString();
                    ventana.imagen = ds.Tables[0].Rows[0][3].ToString();
                    ventana.activo = (bool) ds.Tables[0].Rows[0][4];
                    ventana.programador = (bool)ds.Tables[0].Rows[0][5];
                }

                return ventana;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getVentanaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public int getNextModulo()
        {
            try
            {
                string sql = "select max(id)from sistema_modulo";
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
                MessageBox.Show("Error getNextModulo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int getNextVentana()
        {
            try
            {
                string sql = "select max(codigo)from sistema_ventanas";
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
                MessageBox.Show("Error getgetNextVentanaNext.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

       
    }
}
