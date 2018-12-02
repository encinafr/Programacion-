using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPracticaPreRecuperatorio
{
    public abstract class Utiles
    {
        public double _precio;
        public string _marca;

        public Utiles()
        { }


        public Utiles(string marca, double precio)
        {
            this._marca = marca;
            this._precio = precio;
        }
         public abstract double Precio { get; set; }
        public abstract string Marca { get; set; }

        public virtual string utilesToString()
        {
            return string.Format("| Precio:  " + this._precio + "| Marca:  " + this._marca+ "| ");
        }
    }
}
