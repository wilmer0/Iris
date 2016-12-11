using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidadModelo.modelos
{
    public class modeloEmpresa
    {
        public Boolean agregarEmpresa(empresa empresa)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var listaEmpresa = (from c in entity.empresa
                                    select c).FirstOrDefault();
                if (listaEmpresa != null)
                {
                    MessageBox.Show("No se puede agregar la empresa, porque ya existe una", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
                entity.empresa.Add(empresa);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregarEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }


        public bool ModificarEmpresa(empresa objeto)
        {

            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa = new empresa();
                empresa = (from c in entity.empresa
                           where c.codigo == objeto.codigo
                           select c).FirstOrDefault();

                empresa.nombre = objeto.nombre;
                empresa.division = objeto.division;
                empresa.rnc = objeto.rnc;
                empresa.secuencia = objeto.secuencia;
                empresa.activo = objeto.activo;

                entity.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ModificarEmpresa.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                count = entity.empresa.Count();
                if (count > 0)
                {
                    count = entity.empresa.Max(c => c.codigo);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public empresa getEmpresaByRnc(string rnc)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa;
                empresa = (from c in entity.empresa
                           where c.rnc.ToLower().Contains(rnc.ToLower())
                           select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaByRnc.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public empresa getEmpresaById(int id)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa;
                empresa = (from c in entity.empresa
                           where c.codigo == id
                           select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaById.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<empresa> getListaCompleta()
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                List<empresa> Lista = new List<empresa>();
                Lista = (from c in entity.empresa
                         select c).ToList();

                return Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public empresa getEmpresaBySucursal(sucursal sucursal)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                empresa empresa;
                empresa = (from c in entity.empresa
                           where c.codigo == sucursal.codigo_empresa
                           select c).FirstOrDefault();

                return empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getEmpresaBySucursal.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
