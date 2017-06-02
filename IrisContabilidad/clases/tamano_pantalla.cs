using System.Windows.Forms;

namespace IrisContabilidad.clases
{
    public class tamano_pantalla
    {
        public int width { get; set; }//ancho
        public int height { get; set; }//alto

        public tamano_pantalla()
        {
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
