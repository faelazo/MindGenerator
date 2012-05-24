using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PruebaPaneles.Modelo
{

    public class Nodo
    {
        private int id_nodo;
        private string titulo;
        private string descripcion;
        private int id_diagrama;
        private string nombre_diagrama;
        private Uri enlace;
        private Image imagen;
        private List<Image> iconos;

        public Nodo(int id, string t)
        {
            this.id_nodo = id;
            this.titulo = t;
            this.iconos = new List<Image>();
        }

        public void setTitulo(string t)
        {
            this.titulo = t;
        }
        public void setDescripcion(string d)
        {
            this.descripcion = d;
        }
        public void setDiagrama(int id, string n)
        {
            this.id_diagrama = id;
            this.nombre_diagrama = n;
        }
        public void setEnlace(String e)
        {
            this.enlace = new Uri(e);
        }
        public void setImagen(Image i)
        {
            this.imagen = new Image();
            this.imagen.Source = i.Source;
        }
        public void addIcono(Image i)
        {
            Image aux = new Image();
            aux.Source = i.Source;
            this.iconos.Add(aux);
        }
        public void removeIcono(Image i)
        {
            this.iconos.Remove(i);
        }

        public int getIdNodo()
        {
            return this.id_nodo;
        }
        public string getTitulo()
        {
            return this.titulo;
        }
        public string getDescripcion()
        {
            return this.descripcion;
        }
        public int getIdDiagrama()
        {
            return this.id_diagrama;
        }
        public string getNombreDiagrama()
        {
            return this.nombre_diagrama;
        }
        public Uri getEnlace()
        {
            return this.enlace;
        }
        public Image getImagen()
        {
            return this.imagen;
        }
        public List<Image> getIconos()
        {
            return this.iconos;
        }
    }
}
