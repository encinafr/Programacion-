using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 6 ";
            int anio;
            Console.WriteLine("Ingrese un anio:");
            anio = int.Parse(Console.ReadLine());

            if (anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0))
            {
                Console.WriteLine("El anio {0} es un anio bisiesto", anio);
            }
            else
            {
                Console.WriteLine("El anio {0} no es bisiesto",anio);
            }
            Console.ReadKey();
        }
    }
}
