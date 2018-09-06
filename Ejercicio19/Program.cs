using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio19;

namespace Ejercicio19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 19";

            Sumador suma = new Sumador(1);

            Sumador suma1 = new Sumador(4);

            Sumador suma2 = new Sumador();

            long a, b;
            string c = "holA";
            string d = "¿todo bien?";
            b = 2;

            a = suma + b;
            if (!(suma1 | suma))
            {
                Console.WriteLine(suma.Sumar(a, b));
                Console.WriteLine(suma.Sumar(c, d));
                
            }
            Console.ReadKey();

            
            
        }
    }
}
