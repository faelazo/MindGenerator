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
        private int foco;
        private String tipoFoco;

        public MainPage()
        {
            InitializeComponent();

            foco = -1;
            tipoFoco = "";
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

        private void btTriangulo_Click(object sender, RoutedEventArgs e)
        {
            View.NodoTriangulo nodo = new View.NodoTriangulo();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.triangulo_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.triangulo_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.triangulo_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void btPentagono_Click(object sender, RoutedEventArgs e)
        {
            View.NodoPentagono nodo = new View.NodoPentagono();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.pentagono_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.pentagono_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.pentagono_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void btNube_Click(object sender, RoutedEventArgs e)
        {
            View.NodoNube nodo = new View.NodoNube();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.nube_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.nube_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.nube_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void btChincheta_Click(object sender, RoutedEventArgs e)
        {
            View.NodoNota nodo = new View.NodoNota();
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.nota_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.nota_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.nota_MouseMove);

            cvDiagram.Children.Add(nodo);
        }

        private void cuadrado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;
            item.rectangle1.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.Yellow));
            
            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                //item.tbTitulo.Text = cvDiagram.Children.IndexOf(item).ToString() + " - " + foco;
                //if (foco != -1)
                //{
               //     Type tipo = cvDiagram.Children.ElementAt(foco).GetType();
                //    if(cvDiagram.Children.ElementAt(foco).GetType() != item.GetType())
                 //   {
                 //   }
                 //   View.NodoCuadrado nodo = cvDiagram.Children.ElementAt(foco) as ;
                 //   nodo.rectangle1.Fill = new SolidColorBrush(Colors.White);
                //}
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "CUADRADO";

            item.CaptureMouse();
        }

        private void cuadrado_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;
            //item.rectangle1.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.White));

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

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "CIRCULO";

            item.CaptureMouse();
        }

        private void circulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCirculo item = sender as View.NodoCirculo;
            //item.elipse.SetValue(Ellipse.FillProperty, new SolidColorBrush(Colors.White));

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

        private void triangulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoTriangulo item = sender as View.NodoTriangulo;
            item.triangle.SetValue(Polygon.FillProperty, new SolidColorBrush(Colors.Yellow));

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "TRIANGULO";

            item.CaptureMouse();
        }

        private void triangulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoTriangulo item = sender as View.NodoTriangulo;
            //item.triangle.SetValue(Polygon.FillProperty, new SolidColorBrush(Colors.White));

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void triangulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoTriangulo item = sender as View.NodoTriangulo;

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

        private void pentagono_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoPentagono item = sender as View.NodoPentagono;
            item.pentagono.SetValue(Polygon.FillProperty, new SolidColorBrush(Colors.Yellow));

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "PENTAGONO";

            item.CaptureMouse();
        }

        private void pentagono_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoPentagono item = sender as View.NodoPentagono;
            //item.pentagono.SetValue(Polygon.FillProperty, new SolidColorBrush(Colors.White));

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void pentagono_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoPentagono item = sender as View.NodoPentagono;

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

        private void nube_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoNube item = sender as View.NodoNube;
            item.nube.Fill = new SolidColorBrush(Colors.Yellow);

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "NUBE";

            item.CaptureMouse();
        }

        private void nube_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoNube item = sender as View.NodoNube;
            //item.nube.Fill = new SolidColorBrush(Colors.White);

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void nube_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoNube item = sender as View.NodoNube;

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

        private void nota_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoNota item = sender as View.NodoNota;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (cvDiagram.Children.IndexOf(item) != foco)
            {
                this.quitarSeleccion();
            }
            foco = cvDiagram.Children.IndexOf(item);
            tipoFoco = "NOTA";

            item.CaptureMouse();
        }

        private void nota_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoNota item = sender as View.NodoNota;

            posVertical = -1;
            posHorizontal = -1;

            enMovimiento = false;

            item.ReleaseMouseCapture();
        }

        private void nota_MouseMove(object sender, MouseEventArgs e)
        {
            if (enMovimiento)
            {
                View.NodoNota item = sender as View.NodoNota;

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

        private void quitarSeleccion()
        {
            if (tipoFoco.Equals("CUADRADO"))
            {
                View.NodoCuadrado nodo = cvDiagram.Children.ElementAt(foco) as View.NodoCuadrado;
                nodo.rectangle1.Fill = new SolidColorBrush(Colors.White);
            }
            else if(tipoFoco.Equals("CIRCULO"))
            {
                View.NodoCirculo nodo = cvDiagram.Children.ElementAt(foco) as View.NodoCirculo;
                nodo.elipse.Fill = new SolidColorBrush(Colors.White);
            }
            else if (tipoFoco.Equals("TRIANGULO"))
            {
                View.NodoTriangulo nodo = cvDiagram.Children.ElementAt(foco) as View.NodoTriangulo;
                nodo.triangle.Fill = new SolidColorBrush(Colors.White);
            }
            else if (tipoFoco.Equals("PENTAGONO"))
            {
                View.NodoPentagono nodo = cvDiagram.Children.ElementAt(foco) as View.NodoPentagono;
                nodo.pentagono.Fill = new SolidColorBrush(Colors.White);
            }
            else if (tipoFoco.Equals("NUBE"))
            {
                View.NodoNube nodo = cvDiagram.Children.ElementAt(foco) as View.NodoNube;
                nodo.nube.Fill = new SolidColorBrush(Colors.White);
            }
            else if (tipoFoco.Equals("NOTA"))
            {
                //View.NodoCuadrado nodo = cvDiagram.Children.ElementAt(foco) as View.NodoCuadrado;
                //nodo.rectangle1.Fill = new SolidColorBrush(Colors.White);
            }
        }
    }
}
