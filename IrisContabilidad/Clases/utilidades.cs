using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Data;

namespace IrisContabilidad.Clases
{
    public static class  utilidades
    {
       

        public static bool primo(Int64 n)
        {


            Int64 cont = 0;
            for (Int64 f = 1; f <= n; f++)
            {
                if (n % f == 0)
                {
                    cont++;
                }
            }
            if (cont == 2)
                return true;
            else
                return false;
        }
        public static string conv999(Int64 n)
        {
            if (n == 0) return "";
            string[] vu = new string[] { null, "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "veintiuno", "veintidos", "veintitres", "veinticuatro", "veinticinco", "veintiseis", "veintisiete", "veintiocho", "veintinueve", "trenta" };
            string[] vd = new string[] { null, "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string cn = n.ToString().PadLeft(3, '0');
            int c = Convert.ToInt16(cn.Substring(0, 1));
            int d = Convert.ToInt16(cn.Substring(1, 1));
            int u = Convert.ToInt16(cn.Substring(2, 1));
            int u2 = Convert.ToInt16(cn.Substring(1, 2));
            if (n == 100) return " cien ";
            string letras = "";
            if (c > 0) letras += vu[c] + " cientos ";
            if (u2 > 0)
            {
                if (u2 < 30) letras += vu[u2];
                else
                {
                    letras += vd[d];
                    if (u > 0) letras += " y " + vu[u];
                }
            }
            //arreglos
            letras = letras.ToLower();
            letras = letras.Replace("uno cientos", "cientos");
            letras = letras.Replace("cinco cientos", "quinientos");
            letras = letras.Replace("siete cientos", "setecientos");
            letras = letras.Replace("nueve cientos", "novecientos");
            return letras;
        }
        public static string conv15digitos(Int64 n)
        {
            string cn = n.ToString().PadLeft(18, '0');
            int n1 = Convert.ToInt16(cn.Substring(0, 3));
            int n2 = Convert.ToInt16(cn.Substring(3, 3));
            int n3 = Convert.ToInt16(cn.Substring(6, 3));
            int n4 = Convert.ToInt16(cn.Substring(9, 3));
            int n5 = Convert.ToInt16(cn.Substring(12, 3));
            int n6 = Convert.ToInt16(cn.Substring(15, 3));
            string Letras = "";
            if (n1 > 0)
                Letras += conv999(n1) + " trillones ";
            if (n2 > 0)
                Letras += conv999(n2) + " billones ";
            if (n3 > 0)
                Letras += conv999(n3) + " mil millones ";
            if (n4 > 0)
                Letras += conv999(n4) + " millones ";
            if (n5 > 0)
                Letras += conv999(n5) + " mil ";
            if (n6 > 0)
                Letras += conv999(n6) + " ";
            //arreglitos   
            Letras = Letras.ToLower();
            Letras = Letras.Replace("uno trillones", "un trillon ");
            Letras = Letras.Replace("uno billones", "un billon ");
            Letras = Letras.Replace("uno mil", "mil");
            Letras = Letras.Replace("uno  millones", "un millon  ");
            if (Letras == "millones")
                Letras = Letras.Replace(" millones", "un millon");
            //+arreglitos
            return Letras;
        }
        public static void hablar(string letras)
        {
            string[] v = letras.Split();
            for (int f = 0; f < v.Length; f++)
            {
                if (string.IsNullOrEmpty(v[f]) == false)
                {
                    System.Media.SoundPlayer sonar = new System.Media.SoundPlayer();
                    sonar.SoundLocation = @"C:\Users\wilmer\Desktop\numeros\" + v[f] + ".wav";
                    sonar.PlaySync();
                }
            }
        }
        public static void escribir(string ruta, string contenido)
        {
            StreamWriter escribir = new StreamWriter(ruta);
            escribir.WriteLine(contenido);
            escribir.Close();
        }
        public static DataSet ejecutarcomando(string query)
        {
            try
            {
                //string cmd = "select ip_server,base_datos,base_datos_usuario,base_datos_clave from sistema where ip_server!='' ";
                //DataSet dx = Utilidades.ejecutarcomando(cmd);
                //if(dx.Tables[0].Rows[0][0].ToString()!="")
                //{
                //    MessageBox.Show("Ip server tiene dato");
                //}

                //funaciona nitido para conecciones desde otra maquina porq se especifica el user y password de la bd
                //SqlConnection conn = new SqlConnection("Data Source=dlr-laptop.ddns.net,31164;" + "Initial Catalog=punto_venta;" + "User id=dextroyex;" + "Password=wilmerlomas1;");
                SqlConnection conn = new SqlConnection("Data Source=.;" + "Initial Catalog=punto_venta;" + "User id=dextroyex;" + "Password=wilmerlomas1;");
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                //MessageBox.Show("Fallo conectando al server:"+ex.ToString());
                return null;
            }
        }
        public static DataSet ejecutarcomando_mysql(string query)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=wilmerlomas1;database=prueba;");
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
                MessageBox.Show("Fallo conectando al server");
            }
        }
        public static string encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string desencriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        public static bool numero_entero(string cadena)
        {
            try
            {
                Convert.ToInt64(cadena.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool numero_decimal(string cadena)
        {
            try
            {
                Convert.ToDecimal(cadena.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string numero_miles(double numero)
        {
            try
            {
                numero.ToString("###,###,###,###,###,###.#0");
                return numero.ToString();
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        public static bool solo_letras(string cadena)
        {
            try
            {
                double x = 0;
                x = Convert.ToDouble(cadena);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public static string CadenaEliminarPalabra(string cadena, string palabra)
        {
            char[] partes = cadena.ToCharArray();
            string nuevaCadena = "";
            bool pegar = true;
            int cont = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (partes[i] == '|')
                {
                    pegar = false;
                }
                if (partes[i] == '|')
                {
                    pegar = true;
                    i++;
                    cont++;
                }

                if (pegar)
                {
                    nuevaCadena += partes[i].ToString();
                }
                nuevaCadena.Remove(0, cont);
            }

            return nuevaCadena;
        }


        public static string getNombreTercero(string codigo)
        {
            string cmd = "";
            DataSet ds;
            cmd = "select (t.nombre+' '+p.apellido) as nombre from tercero t join persona p on p.codigo=t.codigo where t.codigo='" + codigo.ToString() + "'";
            ds = utilidades.ejecutarcomando(cmd);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static Boolean enviarCoreeoElectronico(string emisor, string destinatario, string asunto, string mensaje)
        {
            try
            {

                //datos necesarios y dinamicos
                Boolean ssl = false;
                string host = "";
                string puerto = "";
                string clave = "";



                //sacar los datos del correo emisor con la tabla correos electronicos
                string sql = "select correo,clave,ssl_activo,host,puerto from correo_electronicos where correo='" + emisor.ToString() + "'";
                DataSet ds = utilidades.ejecutarcomando(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    clave = host = ds.Tables[0].Rows[0][1].ToString();
                    ssl = Convert.ToBoolean(ds.Tables[0].Rows[0][2].ToString());
                    host = ds.Tables[0].Rows[0][3].ToString();
                    puerto = ds.Tables[0].Rows[0][4].ToString();
                }


                //construyendo el mensaje con datos de envio
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(destinatario));
                email.From = new MailAddress(emisor);
                email.Subject = asunto;
                email.Body = mensaje;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;

                //configurando la conexion con host y abriendo sesion de correo
                SmtpClient smtp = new SmtpClient(host, int.Parse(puerto));
                smtp.Host = host;
                smtp.Port = int.Parse(puerto);
                smtp.EnableSsl = ssl;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emisor, clave);

                string output = null;

                //envio de correo
                smtp.Send(email);
                email.Dispose();
                //MessageBox.Show("Corre electrónico fue enviado satisfactoriamente.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando correo electrónico: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
