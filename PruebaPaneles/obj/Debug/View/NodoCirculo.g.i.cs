﻿#pragma checksum "C:\Users\Fael\Documents\Visual Studio 2010\Projects\SolPruebaPaneles\PruebaPaneles\View\NodoCirculo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7BED838A9CC45D54ACB433D2B32ECCBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PruebaPaneles.View {
    
    
    public partial class NodoCirculo : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Shapes.Ellipse elipse;
        
        internal System.Windows.Controls.TextBox tbTitulo;
        
        internal System.Windows.Controls.Viewbox vbIcono1;
        
        internal System.Windows.Controls.Viewbox vbIcono2;
        
        internal System.Windows.Controls.Button btLink;
        
        internal System.Windows.Controls.Button btLinkDiagram;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PruebaPaneles;component/View/NodoCirculo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.elipse = ((System.Windows.Shapes.Ellipse)(this.FindName("elipse")));
            this.tbTitulo = ((System.Windows.Controls.TextBox)(this.FindName("tbTitulo")));
            this.vbIcono1 = ((System.Windows.Controls.Viewbox)(this.FindName("vbIcono1")));
            this.vbIcono2 = ((System.Windows.Controls.Viewbox)(this.FindName("vbIcono2")));
            this.btLink = ((System.Windows.Controls.Button)(this.FindName("btLink")));
            this.btLinkDiagram = ((System.Windows.Controls.Button)(this.FindName("btLinkDiagram")));
        }
    }
}
