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
    public partial class NodoCirculo : UserControl
    {
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

        public NodoCirculo(MainPage p)
        {
            InitializeComponent();

            this.padre = p;
            this.indexObject = -1;
            this.hasFocus = false;
            this.lines = new List<Line>();
            this.pointLine = new List<int>();
        }

        public void setBackground(SolidColorBrush cbg)
        {
            this.elipse.Fill = cbg;
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
        public void setPos(double x, double y)
        {
            this.posY = x;
            this.posX = y;
            this.setCenter();
        }

        public void setCenter()
        {
            double width, height;
            width = this.elipse.Width;
            height = this.elipse.Height;

            this.posCenterX = this.posX + (width / 2);
            this.posCenterY = this.posY + (height / 2);
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
                this.padre.setFoco(this, Configuration.CIRCULO);
            }
            this.elipse.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
            this.elipse.Stroke = Configuration.COLOR_SELECT;
        }

        public void loseFocus()
        {
            if (hasFocus)
            {
                hasFocus = false;
            }
            this.elipse.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
            this.elipse.Stroke = Configuration.COLOR_NORMAL;
        }

        private void tbTitulo_GotFocus(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void btLink_Click(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void btLinkDiagram_Click(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void elipse_GotFocus(object sender, RoutedEventArgs e)
        {
            this.setFocus();
        }

        private void elipse_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.hasFocus)
            {
                this.elipse.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
                this.elipse.Stroke = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void elipse_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.hasFocus)
            {
                this.elipse.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
                this.elipse.Stroke = Configuration.COLOR_SELECT;
            }
            else
            {
                this.elipse.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
                this.elipse.Stroke = Configuration.COLOR_NORMAL;
            }
        }

    }
}
