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

namespace PruebaPaneles
{
    public partial class MainPage : UserControl
    {
        private Boolean enMovimiento;
        private Double posVertical;
        private Double posHorizontal;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btCuadrado_Click(object sender, RoutedEventArgs e)
        {
            View.NodoCuadrado nodo = new View.NodoCuadrado();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.cuadrado_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.cuadrado_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.cuadrado_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void btCirculo_Click(object sender, RoutedEventArgs e)
        {
            View.NodoCirculo nodo = new View.NodoCirculo();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.circulo_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.circulo_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.circulo_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void cuadrado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;
            item.rectangle1.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.Yellow));

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            item.CaptureMouse();
        }

        private void cuadrado_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;
            item.rectangle1.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.White));

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void cuadrado_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoCuadrado item = sender as View.NodoCuadrado;

                double deltaV = e.GetPosition(null).Y - posVertical;
                double deltaH = e.GetPosition(null).X - posHorizontal;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
            }
        }

        private void circulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoCirculo item = sender as View.NodoCirculo;
            item.elipse.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.Yellow));

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            item.CaptureMouse();
        }

        private void circulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCirculo item = sender as View.NodoCirculo;
            item.elipse.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.White));

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void circulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoCirculo item = sender as View.NodoCirculo;

                double deltaV = e.GetPosition(null).Y - posVertical;
                double deltaH = e.GetPosition(null).X - posHorizontal;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
            }
        }
    }
}
