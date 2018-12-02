using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesPracticaPreRecuperatorio
{
    public class Goma : Utiles
    {
        public bool soloLapiz;

        public Goma()
        { }

         public Goma(string marca, double precio, bool lapiz):base(marca,precio)
        {
            this.soloLapiz = lapiz;
           
        }
        public override double Precio
        {
            get
            { return base._precio; }
            
            set
            {
                base._precio = value;
            }
        }
        public override string Marca
        {
            get
            {
                return base._marca;
            }
            set
            { base._marca = value; }
        }
     

        public override string ToString()
        {
            return string.Format(base.utilesToString()+" Es solo lapiz?: "+ this.soloLapiz.ToString());
        }
    }
}
