using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidadModelo.modelos
{
    public class modeloModulo
    {
        public Boolean agregarModulo(sistema_modulo modulo)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                //validar que el nombre logico no exista en otro modulo
                var validar = (from c in entity.sistema_modulo
                               where c.nombre_modulo_proyecto == modulo.nombre_modulo_proyecto && c.id != modulo.id
                               select c).ToList().FirstOrDefault();

                if (validar != null)
                {
                    MessageBox.Show("Existe otro módulo con el mismo nombre lógico", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                entity.sistema_modulo.Add(modulo);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulo.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }



        public Boolean modificarModulo(sistema_modulo modulo)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {

                var lista = (from c in entity.sistema_modulo
                             where c.id == modulo.id
                             select c).ToList().FirstOrDefault();

                //validar que el nombre logico no exista en otro modulo
                var validar = (from c in entity.sistema_modulo
                               where c.nombre_modulo_proyecto == modulo.nombre_modulo_proyecto && c.id != modulo.id
                               select c).ToList().FirstOrDefault();

                if (validar != null)
                {
                    MessageBox.Show("Existe otro módulo con el mismo nombre lógico", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                lista.id = modulo.id;
                lista.nombre = modulo.nombre;
                lista.nombre_modulo_proyecto = modulo.nombre_modulo_proyecto;
                lista.imagen = modulo.imagen;
                lista.activo = modulo.activo;

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error modificarModulo.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }


        public Boolean agregarModulos(List<sistema_modulo> listaModulos)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                listaModulos.ForEach(x =>
                {
                    entity.sistema_modulo.Add(x);
                });


                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }



        public Boolean modificarModulos(List<sistema_modulo> listaModulos)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var listaModulosViejas = GetListaCompleta();
                listaModulosViejas.ForEach(x =>
                {
                    entity.sistema_modulo.Remove(x);
                });

                listaModulos.ForEach(x =>
                {
                    entity.sistema_modulo.Add(x);
                });

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarListaModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }

        public int getNext()
        {
            int count = 0;

            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                count = entity.sistema_modulo.Count();
                if (count > 0)
                {
                    count = entity.sistema_modulo.Max(c => c.id);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public List<sistema_modulo> getListaSistemaVentanas()
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                var lista = (from c in entity.sistema_modulo
                             where c.activo == true
                             select c).ToList();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaSistemaVentanas.: " + ex.ToString());
                return null;
            }
        }


        public List<modulos_vs_ventanas> getModulosVentanasCompleta()
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                var lista = (from c in entity.modulos_vs_ventanas
                             select c).ToList();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getModulosVentanasCompleta.: " + ex.ToString());
                return null;
            }
        }
        public List<sistema_modulo> GetListaCompleta(bool mantenimiento = false)
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                List<sistema_modulo> lista = new List<sistema_modulo>();
                if (mantenimiento == true)
                {
                    lista = (from c in entity.sistema_modulo
                             select c).ToList();
                }
                else
                {
                    lista = (from c in entity.sistema_modulo
                             where c.activo == true
                             select c).ToList();
                }

                return lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: GetListaCompleta.: " + ex.ToString());
                return null;
            }
        }

        public Boolean agregarModulosVentanas(List<sistema_modulo> lista)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                //eliminando las ventans viejas
                List<sistema_modulo> listaVieja = getListaSistemaVentanas();
                listaVieja.ForEach(x =>
                {
                    entity.sistema_modulo.Remove(x);
                });

                //agregando las ventanas nuevas
                lista.ForEach(x =>
                {
                    entity.sistema_modulo.Add(x);
                });

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }
        //as


        public Boolean agregarModulosVentanas(List<modulos_vs_ventanas> lista)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                //eliminando las ventans viejas
                List<modulos_vs_ventanas> listaVieja = getModulosVentanasCompleta();
                listaVieja.ForEach(x =>
                {
                    entity.modulos_vs_ventanas.Remove(x);
                });

                //agregando las ventanas nuevas
                lista.ForEach(x =>
                {
                    entity.modulos_vs_ventanas.Add(x);
                });

                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulosVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }

        public sistema_modulo getModuloById(int id)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = (from c in entity.sistema_modulo
                             where c.id == id
                             select c).ToList().FirstOrDefault();

                return lista;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModulos.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                entity = null;
            }
        }

        public List<sistema_modulo> getListaByModulo(string modulo, bool mantenimiento = false)
        {

            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = new List<sistema_modulo>();
                if (mantenimiento == true)
                {
                    lista = (from c in entity.sistema_modulo
                             where c.nombre.ToLower().Contains(modulo.ToLower()) || c.nombre_modulo_proyecto.ToLower().Contains(modulo.ToLower())
                             select c).ToList();
                }
                else
                {
                    lista = (from c in entity.sistema_modulo
                             where c.nombre.ToLower().Contains(modulo.ToLower()) || c.nombre_modulo_proyecto.ToLower().Contains(modulo.ToLower())
                          && c.activo == true
                             select c).ToList();

                }

                return lista;

            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error getListaByModulo.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                entity = null;
            }
        }
    }
}
