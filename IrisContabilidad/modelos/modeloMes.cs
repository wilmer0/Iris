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

                sistemaConfiguracion sistema=new sistemaConfiguracion();
                sistema = new modeloSistemaConfiguracion().getSistemaConfiguracion();

                List<mes> lista = new List<mes>();
                mes mes;

                if (sistema.tipoVentanaCuadreCaja == 1)
                {
                    //rd
                    #region
                    
                    mes = new mes();
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
                    #endregion
                }
                else if (sistema.tipoVentanaCuadreCaja == 2)
                {
                    //usa
                    #region
                    mes = new mes();
                    mes.numeroMes = 1;
                    mes.nombre = "January";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 2;
                    mes.nombre = "Febrary";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 3;
                    mes.nombre = "March";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 4;
                    mes.nombre = "April";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 5;
                    mes.nombre = "May";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 6;
                    mes.nombre = "June";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 7;
                    mes.nombre = "July";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 8;
                    mes.nombre = "Agoust";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 9;
                    mes.nombre = "September";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 10;
                    mes.nombre = "October";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 11;
                    mes.nombre = "November";
                    lista.Add(mes);

                    mes = new mes();
                    mes.numeroMes = 12;
                    mes.nombre = "Dicember";
                    lista.Add(mes);
                    #endregion
                }

                
                
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
