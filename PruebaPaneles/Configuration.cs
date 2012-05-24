using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PruebaPaneles
{
    public class Configuration
    {
        /*****     COLORES     *****/
        public static SolidColorBrush COLOR_SELECT = new SolidColorBrush(Color.FromArgb(255, 155, 62, 253));
        public static SolidColorBrush COLOR_MOUSEOVER = new SolidColorBrush(Color.FromArgb(255, 190, 187, 187));
        public static SolidColorBrush COLOR_NORMAL = new SolidColorBrush(Colors.Black);
        public static SolidColorBrush COLOR_TRANSPARENT = new SolidColorBrush(Colors.Transparent);
        public static SolidColorBrush color_selected = new SolidColorBrush(Colors.White);
        
        /*****     CADENAS     *****/
        public const string CUADRADO = "CUADRADO";
        public const string CIRCULO = "CIRCULO";
        public const string TRIANGULO = "TRIANGULO";
        public const string PENTAGONO = "PENTAGONO";
        public const string NUBE = "NUBE";
        public const string NOTA = "NOTA";
        public const string LINEA = "LINEA";

        /*****     ENTEROS     *****/
        public static int STROKE_THICKNESS_NORMAL = 1;
        public static int STROKE_THICKNESS_SELECT = 5;
        public static int STROKE_THICKNESS_LINE = 4;
    }
}
