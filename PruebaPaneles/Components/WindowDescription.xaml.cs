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
    public partial class WindowDescription : UserControl
    {
        public Boolean mouseEnter;

        public WindowDescription()
        {
            InitializeComponent();

            this.mouseEnter = false;
        }

        public Boolean getMouseEnter()
        {
            return this.mouseEnter;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.mouseEnter = true;
            this.rectangle1.StrokeThickness = 3;
            this.lbCerrar.Visibility = Visibility.Visible;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.lbCerrar.Visibility = Visibility.Collapsed;
        }

        private void lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.mouseEnter = false;
            this.Visibility = Visibility.Collapsed;
            this.rectangle1.StrokeThickness = 0;
        }
    }
}
