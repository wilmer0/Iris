using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloLogReporteGenerado
    {

        //objetos
        utilidades utilidades = new utilidades();

        public bool agregarLogReporteGenerado(log_reportes_generados log)
        {
            try
            {
                string sql = "insert into log_reportes_generados(codigo,reporte_generado,codigo_empleado,fecha,fecha_hora) values('"+log.codigo+"','"+log.reporteGenerado+"','"+log.codigoEmpleado+"','"+utilidades.getFechayyyyMMdd(log.fecha)+"','"+utilidades.getFechayyyyMMddhhmmss(log.fechaHora)+"')";
                DataSet ds = utilidades.ejecutarcomando_mysql(sql);
               
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error agregarLogReportesGenerados.: " + ex.ToString(), "", MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }
        }

        //obtener el codigo siguiente
        public int getNext()
        {
            try
            {
                string sql = "select max(codigo)from log_reportes_generados";
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
                System.Windows.Forms.MessageBox.Show("Error getNext.:" + ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


    }
}
