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
    public class modeloNotaCreditoDebitoConcepto
    {
        //objetos
        private utilidades utilidades = new utilidades();





        //agregar 
        public bool agregarConcepto(nota_credito_debito_concepto concepto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from nota_credito_debito_concepto where concepto='" + concepto.concepto +
                             "' and codigo!='" + concepto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un concepto con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }





                if (concepto.activo == true)
                {
                    activo = 1;
                }

                sql = "insert into nota_credito_debito_concepto(codigo,concepto,detalle,activo) values('" +
                      concepto.codigo + "','" + concepto.concepto + "','" + concepto.detalle + "','" + activo.ToString() +
                      "')";
                //MessageBox.Show(sql);
                ds = utilidades.ejecutarcomando_mysql(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error agregar.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //modificar
        public bool modificarConcepto(nota_credito_debito_concepto concepto)
        {
            try
            {
                int activo = 0;
                //validar nombre
                string sql = "select *from nota_credito_debito_concepto where concepto='" + concepto.concepto +
                             "' and codigo!='" + concepto.codigo + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Existe un concepto con ese nombre", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }



                if (concepto.activo == true)
                {
                    activo = 1;
                }
                sql = "update nota_credito_debito_concepto set concepto='" + concepto.concepto + "',detalle='" +
                      concepto.detalle + "',activo='" + activo.ToString() + "' where codigo='" + concepto.codigo + "'";
                ds = utilidades.ejecutarcomando_mysql(sql);
                //MessageBox.Show(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error modificar.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from nota_credito_debito_concepto";
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
        public nota_credito_debito_concepto getConceptoById(int id)
        {
            try
            {
                nota_credito_debito_concepto concepto = new nota_credito_debito_concepto();
                string sql = "select codigo,concepto,detalle,activo from nota_credito_debito_concepto where codigo='" +
                             id + "'";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    concepto.codigo = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                    concepto.concepto = ds.Tables[0].Rows[0][1].ToString();
                    concepto.detalle = ds.Tables[0].Rows[0][2].ToString();
                    concepto.activo = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);
                }
                return concepto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getConceptoById.:" + ex.ToString(), "", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }


        //get lista completa
        public List<nota_credito_debito_concepto> getListaCompleta(bool mantenimiento = false)
        {
            try
            {

                List<nota_credito_debito_concepto> lista = new List<nota_credito_debito_concepto>();
                string sql = "";
                sql = "select codigo,concepto,detalle,activo from nota_credito_debito_concepto";
                if (mantenimiento == false)
                {
                    sql += " where activo=1";
                }
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        nota_credito_debito_concepto concepto = new nota_credito_debito_concepto();
                        concepto.codigo = Convert.ToInt16(row[0].ToString());
                        concepto.concepto = row[1].ToString();
                        concepto.detalle = row[2].ToString();
                        concepto.activo = Convert.ToBoolean(row[3]);
                        lista.Add(concepto);
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
