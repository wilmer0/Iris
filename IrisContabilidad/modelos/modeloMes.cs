using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IrisContabilidad.clases;

namespace IrisContabilidad.modelos
{
    public class modeloMes
    {
        //get lista completa
        public List<mes> getListaCompleta()
        {
            try
            {

                List<mes> lista = new List<mes>();
                mes mes;

                mes=new mes();
                mes.numeroMes = 1;
                mes.nombre = "Enero";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 2;
                mes.nombre = "Febrero";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 3;
                mes.nombre = "Marzo";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 4;
                mes.nombre = "Abril";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 5;
                mes.nombre = "Mayo";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 6;
                mes.nombre = "Junio";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 7;
                mes.nombre = "Julio";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 8;
                mes.nombre = "Agosto";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 9;
                mes.nombre = "Septiembre";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 10;
                mes.nombre = "Octubre";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 11;
                mes.nombre = "Noviembre";
                lista.Add(mes);

                mes = new mes();
                mes.numeroMes = 12;
                mes.nombre = "Diciembre";
                lista.Add(mes);
                
                
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getListaCompleta.:" + ex.ToString(), "", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
