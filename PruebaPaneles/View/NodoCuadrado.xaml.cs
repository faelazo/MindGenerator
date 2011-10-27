using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PruebaPaneles.View
{
    public partial class NodoCuadrado : UserControl
    {
        public NodoCuadrado()
        {
            InitializeComponent();
        }

        public bool insertTitle(String text)
        {
            this.tbTitulo.Text = text;
            return true;
        }

        public void fondo()
        {
            this.rectangle1.SetValue(Canvas.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
        }

        private void rectangle1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
