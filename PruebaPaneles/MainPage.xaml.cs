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
        public int foco;
        public String tipoFoco;

        public Boolean createLine;
        public Line linea;

        double OriginalWidth;
        double originalHeight;

        public MainPage()
        {
            InitializeComponent();

            foco = -1;
            tipoFoco = "";
            createLine = false;
            this.setFoco(null, "");

            View.NodoPrincipal nP = new View.NodoPrincipal(this);
            nP.SetValue(Canvas.MarginProperty, new Thickness(1200,1200,0,0));
            nP.MouseLeftButtonDown += new MouseButtonEventHandler(this.principal_MouseLeftButtonDown);
            nP.MouseLeftButtonUp += new MouseButtonEventHandler(this.principal_MouseLeftButtonUp);
            this.cvDiagram.Children.Add(nP);
            nP.setFocus();
            nP.setPos(1200, 1200);
        }

        public void setFoco(object f, String t)
        {
            switch (t)
            {
                case Configuration.CUADRADO:
                    View.NodoCuadrado nodoCua = f as View.NodoCuadrado;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoCua);
                    break;
                case Configuration.CIRCULO:
                    View.NodoCirculo nodoCir = f as View.NodoCirculo;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoCir);
                    break;
                case Configuration.TRIANGULO:
                    View.NodoTriangulo nodoTri = f as View.NodoTriangulo;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoTri);
                    break;
                case Configuration.PENTAGONO:
                    View.NodoPentagono nodoPen = f as View.NodoPentagono;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoPen);
                    break;
                case Configuration.NUBE:
                    View.NodoNube nodoNub = f as View.NodoNube;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoNub);
                    break;
                case Configuration.NOTA:
                    View.NodoNota nodoNot = f as View.NodoNota;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoNot);
                    break;
                case Configuration.PRINCIPAL:
                    View.NodoPrincipal nodoPri = f as View.NodoPrincipal;
                    this.foco = this.cvDiagram.Children.IndexOf(nodoPri);
                    break;
            }
            this.tipoFoco = t;
        }

        private void btCuadrado_Click(object sender, RoutedEventArgs e)
        {
            View.NodoCuadrado nodo = new View.NodoCuadrado(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.cuadrado_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.cuadrado_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.cuadrado_MouseMove);
            
            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset/this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }
        private void btCirculo_Click(object sender, RoutedEventArgs e)
        {
            View.NodoCirculo nodo = new View.NodoCirculo(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.circulo_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.circulo_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.circulo_MouseMove);

            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset / this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }
        private void btTriangulo_Click(object sender, RoutedEventArgs e)
        {
            View.NodoTriangulo nodo = new View.NodoTriangulo(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.triangulo_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.triangulo_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.triangulo_MouseMove);

            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset / this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }
        private void btPentagono_Click(object sender, RoutedEventArgs e)
        {
            View.NodoPentagono nodo = new View.NodoPentagono(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.pentagono_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.pentagono_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.pentagono_MouseMove);

            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset / this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }
        private void btNube_Click(object sender, RoutedEventArgs e)
        {
            View.NodoNube nodo = new View.NodoNube(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.nube_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.nube_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.nube_MouseMove);

            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset / this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }
        private void btChincheta_Click(object sender, RoutedEventArgs e)
        {
            View.NodoNota nodo = new View.NodoNota(this);
            nodo.MouseLeftButtonDown += new MouseButtonEventHandler(this.nota_MouseLeftButtonDown);
            nodo.MouseLeftButtonUp += new MouseButtonEventHandler(this.nota_MouseLeftButtonUp);
            nodo.MouseMove += new MouseEventHandler(this.nota_MouseMove);

            cvDiagram.Children.Add(nodo);
            nodo.setIndex(cvDiagram.Children.IndexOf(nodo));
            nodo.setFocus();
            double x, y;
            x = this.scroller.HorizontalOffset / this.Slider1.Value;
            y = this.scroller.VerticalOffset / this.Slider1.Value;
            nodo.SetValue(Canvas.TopProperty, y);
            nodo.SetValue(Canvas.LeftProperty, x);
            nodo.setPos(y, x);
        }

        private void principal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoPrincipal item = sender as View.NodoPrincipal;

            posVertical = e.GetPosition(null).Y/this.scroller.VerticalOffset;
            posHorizontal = e.GetPosition(null).X/this.scroller.HorizontalOffset;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void principal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoPrincipal item = sender as View.NodoPrincipal;

            item.ReleaseMouseCapture();
        }

        private void cuadrado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void cuadrado_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCuadrado item = sender as View.NodoCuadrado;

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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        private void circulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoCirculo item = sender as View.NodoCirculo;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void circulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoCirculo item = sender as View.NodoCirculo;

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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        private void triangulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoTriangulo item = sender as View.NodoTriangulo;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void triangulo_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoTriangulo item = sender as View.NodoTriangulo;

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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);
                
                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        private void pentagono_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoPentagono item = sender as View.NodoPentagono;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void pentagono_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoPentagono item = sender as View.NodoPentagono;

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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        private void nube_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoNube item = sender as View.NodoNube;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
        }
        private void nube_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            View.NodoNube item = sender as View.NodoNube;

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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        private void nota_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View.NodoNota item = sender as View.NodoNota;

            posVertical = e.GetPosition(null).Y;
            posHorizontal = e.GetPosition(null).X;

            enMovimiento = true;

            if (!item.hasFocus)
            {
                item.setFocus();
            }

            item.CaptureMouse();

            if (this.createLine)
            {
                item.setPos(posHorizontal, posVertical);
            }
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

                double deltaV = (e.GetPosition(null).Y - posVertical)/this.Slider1.Value;
                double deltaH = (e.GetPosition(null).X - posHorizontal)/this.Slider1.Value;
                double newTop = deltaV + (double)item.GetValue(Canvas.TopProperty);
                double newLeft = deltaH + (double)item.GetValue(Canvas.LeftProperty);

                item.SetValue(Canvas.TopProperty, newTop);
                item.SetValue(Canvas.LeftProperty, newLeft);

                posVertical = e.GetPosition(null).Y;
                posHorizontal = e.GetPosition(null).X;
                item.setPos(newTop, newLeft);
                item.moveLines();
            }
        }

        public void quitarSeleccion()
        {
            if (tipoFoco.Equals(Configuration.CUADRADO))
            {
                View.NodoCuadrado nodo = this.cvDiagram.Children.ElementAt(foco) as View.NodoCuadrado;
                nodo.loseFocus();
            }
            else if(tipoFoco.Equals(Configuration.CIRCULO))
            {
                View.NodoCirculo nodo = cvDiagram.Children.ElementAt(foco) as View.NodoCirculo;
                nodo.loseFocus();
            }
            else if (tipoFoco.Equals(Configuration.TRIANGULO))
            {
                View.NodoTriangulo nodo = cvDiagram.Children.ElementAt(foco) as View.NodoTriangulo;
                nodo.loseFocus();
            }
            else if (tipoFoco.Equals(Configuration.PENTAGONO))
            {
                View.NodoPentagono nodo = cvDiagram.Children.ElementAt(foco) as View.NodoPentagono;
                nodo.loseFocus();
            }
            else if (tipoFoco.Equals(Configuration.NUBE))
            {
                View.NodoNube nodo = cvDiagram.Children.ElementAt(foco) as View.NodoNube;
                nodo.loseFocus();
            }
            else if (tipoFoco.Equals(Configuration.NOTA))
            {
                View.NodoNota nodo = cvDiagram.Children.ElementAt(foco) as View.NodoNota;
                nodo.loseFocus();
            }
            else if (tipoFoco.Equals(Configuration.LINEA))
            {
                Line linea = cvDiagram.Children.ElementAt(foco) as Line;
                linea.Stroke = Configuration.COLOR_NORMAL;
            }
            else if(tipoFoco.Equals(Configuration.PRINCIPAL))
            {
                View.NodoPrincipal nodo = cvDiagram.Children.ElementAt(foco) as View.NodoPrincipal;
                nodo.loseFocus();
            }
        }

        private void btLinea_Click(object sender, RoutedEventArgs e)
        {
            if (!this.tipoFoco.Equals(Configuration.LINEA))
            {
                linea = new Line();
                linea.MouseLeftButtonDown += new MouseButtonEventHandler(this.linea_MouseLeftButtonDown);
                linea.MouseEnter += new MouseEventHandler(this.linea_MouseEnter);
                linea.MouseLeave += new MouseEventHandler(this.linea_MouseLeave);

                linea.StrokeThickness = Configuration.STROKE_THICKNESS_LINE;
                linea.Stroke = Configuration.COLOR_TRANSPARENT;

                switch (this.tipoFoco)
                {
                    case Configuration.CUADRADO:
                        View.NodoCuadrado nodoCua = this.cvDiagram.Children.ElementAt(foco) as View.NodoCuadrado;
                        this.linea.X1 = nodoCua.getPosCenterX();
                        this.linea.Y1 = nodoCua.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoCua.addLine(linea, 1);
                        break;
                    case Configuration.CIRCULO:
                        View.NodoCirculo nodoCir = this.cvDiagram.Children.ElementAt(foco) as View.NodoCirculo;
                        this.linea.X1 = nodoCir.getPosCenterX();
                        this.linea.Y1 = nodoCir.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoCir.addLine(linea, 1);
                        break;
                    case Configuration.TRIANGULO:
                        View.NodoTriangulo nodoTri = this.cvDiagram.Children.ElementAt(foco) as View.NodoTriangulo;
                        this.linea.X1 = nodoTri.getPosCenterX();
                        this.linea.Y1 = nodoTri.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoTri.addLine(linea, 1);
                        break;
                    case Configuration.PENTAGONO:
                        View.NodoPentagono nodoPen = this.cvDiagram.Children.ElementAt(foco) as View.NodoPentagono;
                        this.linea.X1 = nodoPen.getPosCenterX();
                        this.linea.Y1 = nodoPen.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoPen.addLine(linea, 1);
                        break;
                    case Configuration.NUBE:
                        View.NodoNube nodoNub = this.cvDiagram.Children.ElementAt(foco) as View.NodoNube;
                        this.linea.X1 = nodoNub.getPosCenterX();
                        this.linea.Y1 = nodoNub.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoNub.addLine(linea, 1);
                        break;
                    case Configuration.NOTA:
                        View.NodoNota nodoNot = this.cvDiagram.Children.ElementAt(foco) as View.NodoNota;
                        this.linea.X1 = nodoNot.getPosCenterX();
                        this.linea.Y1 = nodoNot.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoNot.addLine(linea, 1);
                        break;
                    case Configuration.PRINCIPAL:
                        View.NodoPrincipal nodoPri = this.cvDiagram.Children.ElementAt(foco) as View.NodoPrincipal;
                        this.linea.X1 = nodoPri.getPosCenterX();
                        this.linea.Y1 = nodoPri.getPosCenterY();
                        this.cvDiagram.Children.Insert(0, this.linea);

                        nodoPri.addLine(linea, 1);
                        break;
                }

                this.linea.X2 = this.linea.X1;
                this.linea.Y2 = this.linea.Y1;

                this.foco++;

                this.createLine = true;
            }
            else
            {
                Components.WindowMessage msg = new Components.WindowMessage("Error", "Debe tener seleccionado un nodo", Components.WindowMessage.TIPO.OKCANCEL);
            }
        }

        private void linea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Line item = sender as Line;

            this.quitarSeleccion();

            if (this.foco != this.cvDiagram.Children.IndexOf(item))
            {
                this.quitarSeleccion();

                this.foco = this.cvDiagram.Children.IndexOf(item);
                this.tipoFoco = Configuration.LINEA;

                item.Stroke = Configuration.COLOR_SELECT;

            }

            item.ReleaseMouseCapture();
        }
        private void linea_MouseEnter(object sender, MouseEventArgs e)
        {
            Line linea = sender as Line;
            if (this.foco != this.cvDiagram.Children.IndexOf(linea))
            {
                linea.Stroke = Configuration.COLOR_MOUSEOVER;
            }
        }
        private void linea_MouseLeave(object sender, MouseEventArgs e)
        {
            Line linea = sender as Line;
            if (this.foco == this.cvDiagram.Children.IndexOf(linea))
            {
                linea.Stroke = Configuration.COLOR_SELECT;
            }
            else
            {
                linea.Stroke = Configuration.COLOR_NORMAL;
            }
        }

        private void btGrosor_Click(object sender, RoutedEventArgs e)
        {
            Components.WindowThickness winGrosor = new Components.WindowThickness();
            winGrosor.Show();
        }

        private void btColores_Click(object sender, RoutedEventArgs e)
        {
            Components.WindowColor wc = new Components.WindowColor();
            wc.Closed += new EventHandler(this.windowColor_Closed);
            wc.Show();
        }

        private void windowColor_Closed(object sender, EventArgs e)
        {
            Components.WindowColor wc = sender as Components.WindowColor;

            if (wc.DialogResult == true)
            {
                switch (this.tipoFoco)
                {
                    case Configuration.CUADRADO:
                        View.NodoCuadrado nc = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoCuadrado;
                        nc.setBackground(wc.getColor());
                        break;
                    case Configuration.CIRCULO:
                        View.NodoCirculo nci = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoCirculo;
                        nci.setBackground(wc.getColor());
                        break;
                    case Configuration.TRIANGULO:
                        View.NodoTriangulo nt = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoTriangulo;
                        nt.setBackground(wc.getColor());
                        break;
                    case Configuration.PENTAGONO:
                        View.NodoPentagono np = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoPentagono;
                        np.setBackground(wc.getColor());
                        break;
                    case Configuration.NUBE:
                        View.NodoNube nn = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoNube;
                        nn.setBackground(wc.getColor());
                        break;
                    case Configuration.PRINCIPAL:
                        View.NodoPrincipal npr = this.cvDiagram.Children.ElementAt(this.foco) as View.NodoPrincipal;
                        npr.setBackground(wc.getColor());
                        break;
                }
            }
        }

        private void btIconos_Click(object sender, RoutedEventArgs e)
        {
            switch (this.tipoFoco)
            {
                case Configuration.CUADRADO:
                    break;
                case Configuration.CIRCULO:
                    break;
                case Configuration.TRIANGULO:
                    break;
                case Configuration.PENTAGONO:
                    break;
                case Configuration.NUBE:
                    break;
            }
        }

        private void content_Loaded(object sender, RoutedEventArgs e)
        {
            originalHeight = content.ActualHeight;
            OriginalWidth = content.ActualWidth;
        }
        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.Slider1 != null)
            {
                CanvasScaleTransform.ScaleX = Slider1.Value;
                CanvasScaleTransform.ScaleY = Slider1.Value;
                content.Height = originalHeight * Slider1.Value;
                content.Width = OriginalWidth * Slider1.Value;

                string porcentaje = "%";
                double aux;
                if (this.Slider1.Value >= 1)
                {
                    aux = (Math.Round(this.Slider1.Value,2) - 1) * 100;
                    porcentaje = aux + porcentaje;
                }
                else
                {
                    aux = (1 - Math.Round(this.Slider1.Value, 2)) * 100;
                    porcentaje = "-" + aux + porcentaje;
                }

                this.label2.Content = porcentaje;
            }
        }

        private void cvDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            this.scroller.ScrollToVerticalOffset(1100);
            this.scroller.ScrollToHorizontalOffset(900);
        }
    }
}
