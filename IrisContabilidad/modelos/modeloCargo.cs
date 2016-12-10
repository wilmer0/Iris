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
    public class modeloCargo
    {
        //objetos
            utilidades utilidades = new utilidades();

        

            //get cargo
            public cargo getCargoById(int id)
            {
                try
                {
                    cargo cargo=new cargo();
                    string sql = "select id,nombre,activo from cargo where codigo='"+id+"'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cargo.id = (int) ds.Tables[0].Rows[0][0];
                        cargo.nombre = ds.Tables[0].Rows[0][1].ToString();
                        cargo.activo = (int)ds.Tables[0].Rows[0][2];
                    }

                    return cargo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getCargoById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            //agregar cargo
            public bool agregarCargo(cargo cargoAPP)
            {
                try
                {
                   cargo cargo=new cargo();
                    string sql = "select *from cargo where nombre='" + cargoAPP.nombre + "'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Existe un cargo con ese nombre", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }

                    cargo.id = cargoAPP.id;
                    cargo.nombre = cargoAPP.nombre;
                    if (cargoAPP.activo == 1)
                    {
                        cargoAPP.activo = 1;
                    }
                    else
                    {
                        cargoAPP.activo = 0;
                    }
                    cargo.activo = cargoAPP.activo;

                    sql="insert into cargo(id,nombre,activo) values('"+cargoAPP.id+"','"+cargoAPP.nombre+"','"+cargoAPP.activo+"')";
                    MessageBox.Show(sql);
                    ds=utilidades.ejecutarcomando(sql);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error agregarCargo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //modificar cargo
            public bool modificarCargo(cargo cargoAPP)
            {
                try
                {

                    string sql = "select *from cargo where nombre='" + cargoAPP.nombre + "' and id!='"+cargoAPP.id+"'";
                    DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Existe un cargo con ese nombre", "", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }
                    if (cargoAPP.activo == 1)
                    {
                        cargoAPP.activo = 1;
                    }
                    else
                    {
                        cargoAPP.activo = 0;
                    }
                    sql = "update cargo set nombre='" + cargoAPP.nombre + "',activo='"+cargoAPP.activo+"' where id='"+cargoAPP.id+"'";
                    ds=utilidades.ejecutarcomando(sql);
                    MessageBox.Show(sql);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error modificarCargo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


        //obtener el codigo siguiente cargo
        public int getNext()
        {
            try
            {
                string sql = "select max(id)from cargo";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                int id = (int)ds.Tables[0].Rows[0][0];
                if (id == null || id==0)
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

    }
}
