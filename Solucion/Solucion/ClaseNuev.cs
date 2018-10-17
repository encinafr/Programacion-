using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
   public class Numero
    {
        public double _divided;

        public Numero(int x, int y)
        {
            try
            { _divided = Divide(x, y); }
            catch (DivideByZeroException e)
            { throw new UnaException(e.Message + "\nUna Excepcion.", e); }
        }

        public static double Divide(int x, int y)
        {
            double retorno = 0;

            if (y != 0)
            { retorno = x / y; }
            else
            { throw new DivideByZeroException("Intento Dividir por 0."); }

            return retorno;
        }
    }

    public class N2
    {
        public Numero _numero;

        public N2(int x, int y)
        {
            try { this._numero = new Numero(x, y); }
            catch (UnaException e)
            { throw new MiExcepcion(e.Message + "\nMi excepcion", e); }
        }
    }

    public class UnaException : Exception
    {
        public UnaException(string message, Exception inner) : base(message, inner) { }
    }

    public class MiExcepcion : Exception
    {
        public MiExcepcion(string message, Exception inner) : base(message, inner) { }
    }

}

