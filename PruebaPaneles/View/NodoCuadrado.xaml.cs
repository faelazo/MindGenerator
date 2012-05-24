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
        private System.Windows.Threading.DispatcherTimer timer;
        private System.Windows.Threading.DispatcherTimer timer2;
        public Boolean hasFocus;
        public int indexObject;
        private MainPage padre;
        private double posX;
        private double posY;
        private double posCenterX;
        private double posCenterY;
        public List<Line> lines;
        public List<int> pointLine;
        public Modelo.Nodo nodo;
        public Boolean descriptionVisible;

        public NodoCuadrado(MainPage p)
        {
            InitializeComponent();

            this.padre = p;
            this.indexObject = -1;
            this.hasFocus = false;
            this.lines = new List<Line>();
            this.pointLine = new List<int>();
            this.descriptionVisible = false;
        }

        public List<Line> getLines()
        {
            return this.lines;
        }

        public void setIndex(int index)
        {
            this.indexObject = index;
        }

        public int getIndex()
        {
            return indexObject;
        }

        public void setPos()
        {
            this.posY = (double)this.GetValue(Canvas.TopProperty);
            this.posX = (double)this.GetValue(Canvas.LeftProperty);
            this.setCenter();
        }

        public void setCenter()
        {
            double width, height;
            width = this.rectangle1.Width;
            height = this.rectangle1.Height;

            this.posCenterX = this.posX + (width / 2);
            this.posCenterY = this.posY + (height / 2);
        }

        public void setBackground(SolidColorBrush cbg)
        {
            this.rectangle1.Fill = cbg;
        }

        public double getPosCenterX()
        {
            return this.posCenterX;
        }

        public double getPosCenterY()
        {
            return this.posCenterY;
        }

        public void addLine(Line l, int pos)
        {
            this.lines.Add(l);
            this.pointLine.Add(pos);
        }

        public void moveLines()
        {
            for (int i = 0; i < this.lines.Count; i++)
            {
                int aux = this.pointLine.ElementAt(i);
                if (aux == 1)
                {
                    this.lines.ElementAt(i).X1 = this.posCenterX;
                    this.lines.ElementAt(i).Y1 = this.posCenterY;
                }
                else if (aux == 2)
                {
                    this.lines.ElementAt(i).X2 = this.posCenterX;
                    this.lines.ElementAt(i).Y2 = this.posCenterY;
                }
            }
        }

        public bool insertTitle(String text)
        {
            this.tbTitulo.Text = text;
            return true;
        }

        public void setFocus()
        {
            if (this.padre.createLine)
            {
                this.addLine(this.padre.linea, 2);
                this.lines.Last().X2 = this.getPosCenterX();
                this.lines.Last().Y2 = this.getPosCenterY();
                this.lines.Last().Stroke = Configuration.COLOR_NORMAL;
                this.padre.createLine = false;
            }

            if (!hasFocus)
            {
                hasFocus = true;
                this.padre.quitarSeleccion();
                this.padre.setFoco(this, Configuration.CUADRADO);
            }
            this.rectangle1.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
            this.rectangle1.Stroke = Configuration.COLOR_SELECT;
        }

        public void loseFocus()
        {
            if (hasFocus)
            {
                hasFocus = false;
            }
            this.rectangle1.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
            this.rectangle1.Stroke = Configuration.COLOR_NORMAL;
        }

        private void Canvas_GotFocus(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void tbTitulo_GotFocus(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.hasFocus)
            {
                this.rectangle1.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
                this.rectangle1.Stroke = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.hasFocus)
            {
                this.rectangle1.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
                this.rectangle1.Stroke = Configuration.COLOR_SELECT;
            }
            else
            {
                this.rectangle1.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
                this.rectangle1.Stroke = Configuration.COLOR_NORMAL;
            }
        }

        private void rectangle1_MouseEnter(object sender, MouseEventArgs e)
        {
            if ((!this.descriptionVisible) && (!this.windowDescription1.getMouseEnter()))
            {
                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += new EventHandler(Each_Tick);
                timer.Start();
            }
        }

        private void rectangle1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.timer.IsEnabled)
            {
                this.timer.Stop();
            }
            else
            {
                this.descriptionVisible = false;
                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                timer.Tick += new EventHandler(Each_Tick_Close);
                timer.Start();
            }
        }

        public void Each_Tick(object o, EventArgs sender)
        {
            if (!this.descriptionVisible)
            {
                this.descriptionVisible = true;
                this.windowDescription1.Visibility = Visibility.Visible;
                timer.Stop();
            }
        }
        public void Each_Tick_Close(object o, EventArgs sender)
        {
            if (!this.windowDescription1.getMouseEnter())
            {
                this.windowDescription1.Visibility = Visibility.Collapsed;
                this.descriptionVisible = false;
                timer.Stop();
            }
        }

        private void rectangle1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.descriptionVisible = true;
        }

        private void rectangle1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.descriptionVisible = false;
        }
    }
}
