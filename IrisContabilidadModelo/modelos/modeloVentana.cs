using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidadModelo.modelos
{
    public class modeloVentana
    {
        public Boolean agregarVentana(sistema_ventanas ventana)
        {
            
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = (from c in entity.sistema_ventanas
                             where c.codigo == ventana.codigo
                             select c).FirstOrDefault();

                var validar = (from c in entity.sistema_ventanas
                               where c.nombre_logico == ventana.nombre_logico && c.codigo != ventana.codigo
                               select c).ToList().FirstOrDefault();

                if (validar != null)
                {
                    MessageBox.Show("Existe otra ventana con el mismo nombre lógico", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                entity.sistema_ventanas.Add(ventana);
                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarVentana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }



        public Boolean modificarVentanas(sistema_ventanas ventana)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {

                var lista = (from c in entity.sistema_ventanas
                             where c.codigo == ventana.codigo
                             select c).ToList().FirstOrDefault();

                var validar = (from c in entity.sistema_ventanas
                               where c.nombre_logico == ventana.nombre_logico && c.codigo != ventana.codigo
                               select c).ToList().FirstOrDefault();

                if (validar != null)
                {
                    MessageBox.Show("Existe otra ventana con el mismo nombre lógico", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                lista.cod_modulo = ventana.cod_modulo;
                lista.nombre_ventana = ventana.nombre_ventana;
                lista.nombre_logico = ventana.nombre_logico;
                lista.imagen = ventana.imagen;
                lista.activo = ventana.activo;


                entity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error modificarVentanas.:" + ex.ToString(), "", MessageBoxButtons.OK,
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
                count = entity.sistema_ventanas.Count();
                if (count > 0)
                {
                    count = entity.sistema_ventanas.Max(c => c.codigo);
                }
                return count + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getNext.: " + ex.ToString());
                return count;
            }
        }

        public sistema_ventanas getVentanaById(int id)
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();


                var lista = (from c in entity.sistema_ventanas
                             where c.codigo == id
                             select c).ToList().FirstOrDefault();


                return lista;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getVentanaById.: " + ex.ToString());
                return null;
            }
        }
        public List<sistema_ventanas> getListaCompleta(bool mantenimiento = false)
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                List<sistema_ventanas> lista = new List<sistema_ventanas>();
                if (mantenimiento == true)
                {
                    lista = (from c in entity.sistema_ventanas
                             select c).ToList();
                }
                else
                {
                    lista = (from c in entity.sistema_ventanas
                             where c.activo == true
                             select c).ToList();
                }

                return lista;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaCompleta.: " + ex.ToString());
                return null;
            }
        }

        public List<sistema_modulo> getListaSistemaModulos()
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                List<sistema_modulo> lista = new List<sistema_modulo>();

                lista = (from c in entity.sistema_modulo
                         where c.activo == true
                         select c).ToList();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaSistemaModulos.: " + ex.ToString());
                return null;
            }
        }
        public List<modulos_vs_ventanas> getListaCompletaModulosVsVentanas()
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();

                List<modulos_vs_ventanas> lista = new List<modulos_vs_ventanas>();

                lista = (from c in entity.modulos_vs_ventanas
                         select c).ToList();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getListaCompletaModulosVsVentanas.: " + ex.ToString());
                return null;
            }
        }
        public Boolean agregarModulosVentanas(List<sistema_ventanas> lista)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                modeloVentana modeloVentana = new modeloVentana();
                //eliminando las ventans viejas
                List<sistema_ventanas> listaVieja = modeloVentana.getListaCompleta();



                //MessageBox.Show("eliminar");
                listaVieja.ForEach(x =>
                {
                    //sistema_ventanas ventana = new sistema_ventanas();
                    //ventana = modeloVentana.getSistemaVentanaById(x.codigo);
                    //MessageBox.Show("eliminado->" + ventana.nombre_ventana);
                    //entity.sistema_ventanas.Attach(ventana);
                    entity.sistema_ventanas.Remove(x);

                });
                //MessageBox.Show("eliminadas todas");
                entity.SaveChanges();


                //agregando las ventanas nuevas
                //MessageBox.Show("agregar");
                lista.ForEach(x =>
                {
                    //    sistema_ventanas ventana=new sistema_ventanas();
                    //    ventana = modeloVentana.getSistemaVentanaById(x.codigo);
                    //entity.sistema_ventanas.Attach(ventana);
                    entity.sistema_ventanas.Add(x);
                });
                //MessageBox.Show("agregadas");
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

        private sistema_ventanas getSistemaVentanaById(int id)
        {
            try
            {
                coneccion coneccion = new coneccion();
                iris_contabilidadEntities entity = coneccion.GetConeccion();
                var lista = (from c in entity.sistema_ventanas
                             where c.codigo == id
                             select c).ToList().FirstOrDefault();


                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: getSistemaVentanaById.: " + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public Boolean agregarModuloVsVentana(List<modulos_vs_ventanas> lista)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                //eliminando las vieja
                List<modulos_vs_ventanas> listaVieja = new List<modulos_vs_ventanas>();
                listaVieja = (entity.modulos_vs_ventanas.Where(x => x.id_modulo > 0)).ToList();
                if (listaVieja.ToList().Count > 0)
                {
                    listaVieja.ForEach(x =>
                    {
                        entity.modulos_vs_ventanas.Remove(x);
                    });
                }

                //agregando lista nueva
                if (lista.ToList().Count > 0)
                {
                    lista.ForEach(x =>
                    {
                        MessageBox.Show(x.id_modulo + "-" + x.id_ventana);
                        modulos_vs_ventanas moduloVsVentana = new modulos_vs_ventanas();
                        moduloVsVentana.id_modulo = x.id_modulo;
                        moduloVsVentana.id_ventana = x.id_ventana;
                        entity.modulos_vs_ventanas.Add(moduloVsVentana);
                    });
                }
                entity.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error agregarModuloVsVentana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                entity = null;
            }
        }


        public List<sistema_ventanas> getListaByVentana(string ventana)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = (from c in entity.sistema_ventanas
                             where c.nombre_ventana.ToLower().Contains(ventana.ToLower()) || c.nombre_logico.ToLower().Contains(ventana.ToLower())
                             select c).ToList();

                return lista;

            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error getListaByVentana.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                entity = null;
            }
        }

        public List<sistema_ventanas> getListaByModuloID(int modulo)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            List<sistema_ventanas> listaVentanas = new List<sistema_ventanas>();
            sistema_ventanas ventana;
            try
            {
                var lista = (from c in entity.modulos_vs_ventanas
                             where c.id_modulo == modulo
                             select c).ToList();


                lista.ForEach(x =>
                {
                    ventana = new sistema_ventanas();
                    ventana = getVentanaById((int)x.id_ventana);
                    if (ventana != null)
                    {
                        listaVentanas.Add(ventana);
                    }
                });
                return listaVentanas;

            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error getListaByModuloID.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                entity = null;
            }
        }

        public List<sistema_ventanas> getListaModuloByNombre(string nombre)
        {
            coneccion coneccion = new coneccion();
            iris_contabilidadEntities entity = coneccion.GetConeccion();
            try
            {
                var lista = (from c in entity.sistema_ventanas
                             where c.nombre_ventana.ToLower().Contains(nombre.ToLower().Trim()) || c.nombre_logico.ToLower().Contains(nombre.ToLower().Trim())
                             select c).ToList();

                return lista;

            }
            catch (Exception ex)
            {
                entity = null;
                MessageBox.Show("Error getListaModuloByNombre.:" + ex.ToString(), "", MessageBoxButtons.OK,
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
