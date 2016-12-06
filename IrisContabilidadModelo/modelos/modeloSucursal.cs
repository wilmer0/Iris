using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidadModelo.modelos
{
    public class modeloSucursal
    {
        public Boolean agregarSucursal(sucursal sucursal)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var listaSecuencia = (from c in entity.sucursal
                                      where c.codigo != sucursal.codigo && c.secuencia == sucursal.secuencia
                                      select c).FirstOrDefault();

                if (listaSecuencia != null)
                {
                    MessageBox.Show("No se modifico: se encuentra una sucursal con la misma secuencia", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                entity.sucursal.Add(sucursal);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarSucursal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }


        public bool ModificarSucursal(sucursal sucursal)
        {

            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {

                var Lista = (from c in entity.sucursal
                             where c.codigo == sucursal.codigo
                             select c).FirstOrDefault();

                var listaSecuencia = (from c in entity.sucursal
                                      where c.codigo != sucursal.codigo && c.secuencia == sucursal.secuencia
                                      select c).FirstOrDefault();

                if (listaSecuencia != null)
                {
                    MessageBox.Show("No se modifico: se encuentra una sucursal con la misma secuencia", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Lista.codigo = sucursal.codigo;
                Lista.codigo_empresa = sucursal.codigo_empresa;
                Lista.activo = sucursal.activo;
                Lista.secuencia = sucursal.secuencia;
                Lista.direccion = sucursal.direccion;

                entity.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ModificarSucursal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public int getNext()
        {
            int count = 0;

            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                count = entity.sucursal.Count();
                if (count > 0)
                {
                    count = entity.sucursal.Max(c => c.codigo);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public List<sucursal> getSucursalByEmpresa(empresa empresa)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                List<sucursal> lista = new List<sucursal>();
                lista = (from c in entity.sucursal
                         where c.codigo_empresa == empresa.codigo
                         select c).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalByEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public sucursal getSucursalById(int id)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                sucursal sucursal;
                sucursal = (from c in entity.sucursal
                            where c.codigo == id
                            select c).FirstOrDefault();

                return sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getSucursalById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<sucursal> getListaCompleta()
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {

                var Lista = (from c in entity.sucursal
                             select c).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
