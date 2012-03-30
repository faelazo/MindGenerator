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
    public partial class WindowMessage : ChildWindow
    {
        public enum TIPO { YESNO, OKCANCEL, YESNOCANCEL, QUESTION, ERROR};
        private TIPO type;

        private double[] POSICION_BT1 = {0, 12, 0, 0 };
        private double[] POSICION_BT2 = {0, 12, 80, 0 };
        private double[] POSICION_BT3 = {0, 12, 160, 0 };

        public int result;

        public WindowMessage(string title, string message)
        {
            InitializeComponent();

            this.showWindow(title, message, TIPO.ERROR);
        }

        public WindowMessage(string title, string message, TIPO type)
        {
            InitializeComponent();

            this.showWindow(title, message, type);
        }

        public void showWindow(string title, string message, TIPO type)
        {
            this.Title = title;
            this.label1.Content = message;
            this.type = type;

            switch (type)
            {
                case TIPO.ERROR: this.buildError();
                    break;
                case TIPO.OKCANCEL: this.buildOkCancel();
                    break;
                case TIPO.QUESTION: this.buildQuestion();
                    break;
                case TIPO.YESNO: this.buildYesNo();
                    break;
                case TIPO.YESNOCANCEL: this.builYesNoCancel();
                    break;
            }
            this.Show();
        }

        private void positionButton(Button button, int pos)
        {
            switch (pos)
            {
                case 1: button.Margin = new Thickness(this.POSICION_BT1[0], this.POSICION_BT1[1], this.POSICION_BT1[2], this.POSICION_BT1[3]);
                    break;
                case 2: button.Margin = new Thickness(this.POSICION_BT2[0], this.POSICION_BT2[1], this.POSICION_BT2[2], this.POSICION_BT2[3]);
                    break;
                case 3: button.Margin = new Thickness(this.POSICION_BT3[0], this.POSICION_BT3[1], this.POSICION_BT3[2], this.POSICION_BT3[3]);
                    break;
            }
        }

        private void buildYesNo()
        {
            this.showButtons(false, false, true, true);
            this.positionButton(this.NoButton, 1);
            this.positionButton(this.YesButton, 2);
            //this.image1 = Asigno la imagen de yesno
        }

        private void buildOkCancel()
        {
            this.showButtons(true, true, false, false);
            this.positionButton(this.CancelButton, 1);
            this.positionButton(this.OKButton, 2);
            //this.image1 = Asigno la imagen de okcancel.
        }

        private void buildError()
        {
            this.showButtons(true, false, false, false);
            this.positionButton(this.OKButton, 1);
            //this.image1 = Asigno la imagen de error.
        }

        private void buildQuestion()
        {
            this.showButtons(false, false, true, true);
            this.positionButton(this.NoButton, 1);
            this.positionButton(this.YesButton, 2);
            //this.image1 = Asigno la imagen de question
        }

        private void builYesNoCancel()
        {
            this.showButtons(false, true, true, true);
            this.positionButton(this.CancelButton, 1);
            this.positionButton(this.NoButton, 2);
            this.positionButton(this.YesButton, 3);
            //this.image1 = Asigno la imagen de yesnocancel.
        }

        private void showButtons(bool aceptar, bool cancelar, bool si, bool no)
        {
            if (aceptar) this.OKButton.Visibility = System.Windows.Visibility.Visible;
            else this.OKButton.Visibility = System.Windows.Visibility.Collapsed;

            if (cancelar) this.CancelButton.Visibility = System.Windows.Visibility.Visible;
            else this.CancelButton.Visibility = System.Windows.Visibility.Collapsed;

            if (si) this.YesButton.Visibility = System.Windows.Visibility.Visible;
            else this.YesButton.Visibility = System.Windows.Visibility.Collapsed;

            if (no) this.NoButton.Visibility = System.Windows.Visibility.Visible;
            else this.NoButton.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.result = 1;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.type.Equals(TIPO.YESNOCANCEL))
            {
                this.result = 0;
            }
            else
            {
                this.result = -1;
            }

            this.DialogResult = false;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.result = 1;
            this.DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.result = -1;
            this.DialogResult = false;
        }

        public int getResult()
        {
            return this.result;
        }
    }
}

