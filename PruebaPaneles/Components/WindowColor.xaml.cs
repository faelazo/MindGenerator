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

namespace PruebaPaneles.Components
{
    public partial class WindowColor : ChildWindow
    {
        public Rectangle rectSelect;

        public WindowColor()
        {
            InitializeComponent();

            this.rectSelect = r1;
            this.rectSelect.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
            this.rectSelect.Stroke = Configuration.COLOR_SELECT;
        }

        public SolidColorBrush getColor()
        {
            return (SolidColorBrush)this.rectSelect.Fill;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Configuration.color_selected = (SolidColorBrush)this.rectSelect.Fill;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void r_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            
            if (!r.Stroke.Equals(Configuration.COLOR_SELECT))
            {
                r.Stroke = Configuration.COLOR_MOUSEOVER;
                r.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;
            }
        }

        private void r_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle r = sender as Rectangle;

            if (!r.Stroke.Equals(Configuration.COLOR_SELECT))
            {
                r.Stroke = Configuration.COLOR_NORMAL;
                r.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
            }
        }

        private void r_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;

            if (!r.Stroke.Equals(Configuration.COLOR_SELECT))
            {
                r.Stroke = Configuration.COLOR_SELECT;
                r.StrokeThickness = Configuration.STROKE_THICKNESS_SELECT;

                this.rectSelect.Stroke = Configuration.COLOR_NORMAL;
                this.rectSelect.StrokeThickness = Configuration.STROKE_THICKNESS_NORMAL;
                this.rectSelect = r;
            }
        }
    }
}

