using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;

        public int CantidadDePaginas
        {
            get
            {

                if (this._cantidadDePaginas == 0)
                {
                    this._cantidadDePaginas = Libro._generadorDePaginas.Next(10, 580);
                }

                return this._cantidadDePaginas;
            }
        }


        static Libro()
        {
            Libro._generadorDePaginas = new Random();
        }
        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="precio"></param>
        public Libro(string titulo, Autor autor, float precio)
        {
            this._autor = autor;
            this._titulo = titulo;
            this._precio = precio;
        }

        public Libro(float precio, string titulo, string nombre, string apellido)
        {
            this._titulo = titulo;
            this._precio = precio;
            this._autor = new Autor(nombre, apellido);
        }



        public static explicit operator string(Libro l)
        {
            return l._autor +
                   "CANTIDAD DE PAGINAS: " + l.CantidadDePaginas + "\n" +
                   "PRECIO: " + l._precio + "\n" +
                   "TITULO: " + l._titulo + "\n";
        }

        private static string Mostrar(Libro l)
        {
            return (string)l;
        }

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno;
            if (a._titulo == b._titulo && a._autor == b._autor)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }
    }
}
