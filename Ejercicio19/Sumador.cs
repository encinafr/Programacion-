using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio19
{
    class Sumador
    {
        private int _cantidadSumas;

        public Sumador(int suma)
        {
            this._cantidadSumas = suma;
        }

        public Sumador()
        {
            Sumador suma = new Sumador(0);
        }

        public long Sumar(long a, long b)
        {
            return a + b;
        }

        public string Sumar(string a, string b)
        {
            return a +" "+ b;
        }

        public static implicit operator int(Sumador valor)
        {

            return valor._cantidadSumas;
        }

        public static long operator +(Sumador op1, Sumador op2)
        {
            long retorno = op1._cantidadSumas + op2._cantidadSumas;
            return retorno;
        }

        public static bool operator |(Sumador op1, Sumador op2)
        {
            bool retorno = false;
            if (op1._cantidadSumas == op2._cantidadSumas)
            {
                retorno = true;
            }
            
            return retorno;
        }

    }
}
