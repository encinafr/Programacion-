using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Validacion
    {
        static public bool Validar(int valor, int max, int min)
        {
            bool retorno = false;
            if (valor > max || valor < min)
            {
                return retorno;
            }
            else
            {
                retorno = true;

            }
            return retorno;
        }

    }
}
