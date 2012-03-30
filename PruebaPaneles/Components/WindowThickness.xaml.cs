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
    public partial class WindowThickness : ChildWindow
    {
        public int grosor;

        public WindowThickness()
        {
            InitializeComponent();

            grosor = 1;
            this.rectangle1.Fill = Configuration.COLOR_SELECT;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void comprobarSeleccion(int sel)
        {
            if (sel != 1) this.rectangle1.Fill = Configuration.COLOR_TRANSPARENT;
            if (sel != 3) this.rectangle2.Fill = Configuration.COLOR_TRANSPARENT;
            if (sel != 5) this.rectangle3.Fill = Configuration.COLOR_TRANSPARENT;
            if (sel != 7) this.rectangle4.Fill = Configuration.COLOR_TRANSPARENT;
        }

        private void rectangle1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle1.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(1);
            this.grosor = 1;
        }

        private void rectangle2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle2.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(3);
            this.grosor = 3;
        }

        private void rectangle3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle3.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(5);
            this.grosor = 5;
        }

        private void rectangle4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle4.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(7);
            this.grosor = 7;
        }

        private void line1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle1.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(1);
            this.grosor = 1;
        }

        private void line2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle2.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(3);
            this.grosor = 3;
        }

        private void line3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle3.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(5);
            this.grosor = 5;
        }

        private void line4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.rectangle4.Fill = Configuration.COLOR_SELECT;
            this.comprobarSeleccion(7);
            this.grosor = 7;
        }

        private void rectangle1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.grosor != 1)
            {
                this.rectangle1.Fill = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void rectangle2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.grosor != 3)
            {
                this.rectangle2.Fill = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void rectangle3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.grosor != 5)
            {
                this.rectangle3.Fill = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void rectangle4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.grosor != 7)
            {
                this.rectangle4.Fill = Configuration.COLOR_MOUSEOVER;
            }
        }

        private void rectangle1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.grosor == 1)
            {
                this.rectangle1.Fill = Configuration.COLOR_SELECT;
            }
            else
            {
                this.rectangle1.Fill = Configuration.COLOR_TRANSPARENT;
            }
        }

        private void rectangle2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.grosor == 3)
            {
                this.rectangle2.Fill = Configuration.COLOR_SELECT;
            }
            else
            {
                this.rectangle2.Fill = Configuration.COLOR_TRANSPARENT;
            }
        }

        private void rectangle3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.grosor == 5)
            {
                this.rectangle3.Fill = Configuration.COLOR_SELECT;
            }
            else
            {
                this.rectangle3.Fill = Configuration.COLOR_TRANSPARENT;
            }
        }

        private void rectangle4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.grosor == 7)
            {
                this.rectangle4.Fill = Configuration.COLOR_SELECT;
            }
            else
            {
                this.rectangle4.Fill = Configuration.COLOR_TRANSPARENT;
            }
        }
    }
}

