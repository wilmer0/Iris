using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisContabilidadModelo.modelos
{
    public class coneccion
    {
        private static coneccion instance;

        public static coneccion Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new coneccion();
                }
                return instance;
            }
        }
        public coneccion()
        {

        }
        public static DatosConeccionBD datosConeccionBd { get; set; }

        public coneccion(DatosConeccionBD datosConeccion)
        {
            datosConeccionBd = datosConeccion;
        }


        public DatosConeccionBD GetDatos()
        {
            return datosConeccionBd;
        }

        public iris_contabilidadEntities GetConeccion()
        {

            if (datosConeccionBd == null)
            {
                datosConeccionBd = new DatosConeccionBD();


                //         public iris_contabilidadEntities(string servidor, String baseDatos, String user, String pass, String Puerto="3306"): base("name=iris_contabilidadEntities")
                //        {


                //    var connectionString = this.Database.Connection.ConnectionString + ";password=" + pass;
                //    connectionString = "server=" + servidor + ";userid=" + user + ";persistsecurityinfo=true;database=" + baseDatos + ";password=" + pass;

                //    this.Database.Connection.ConnectionString = connectionString;
                //}

                //        if (!System.IO.Directory.Exists("Configuracion"))
                //        {

                //            System.IO.Directory.CreateDirectory("Configuracion");

                //   }




                //        // leer archivo

                //datosConeccionBd.Puerto = "3306";
                datosConeccionBd.Servidor = "localhost";
                datosConeccionBd.BaseDatos = "iris_contabilidad";
                datosConeccionBd.Usuario = "root";
                datosConeccionBd.Contrasena = "wilmerlomas1";

                //MessageBox.Show("BD: " + datosConeccionBd.BaseDatos);
                return new iris_contabilidadEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);

            }
            else
            {
                return new iris_contabilidadEntities(datosConeccionBd.Servidor, datosConeccionBd.BaseDatos, datosConeccionBd.Usuario, datosConeccionBd.Contrasena);
            }
        }
    }
}
