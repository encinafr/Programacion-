using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio12;

namespace Ejercicio12
{
    class Program
    {
        static void Main(string[] args)
        {
            int suma;
            int num;
            int num1;
            char validar= 'N';
            do
            {
                Console.WriteLine("Ingrese el primer valor:");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el segundo valor:");
                num1 = int.Parse(Console.ReadLine());

                suma = num + num1;
                Console.WriteLine("La suma es: {0}", suma);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Presione S para seguir sumando");
                validar =Convert.ToChar(Console.ReadLine());
            } while (ValidarRespuesta.ValidaS_N(validar));

        }
    }
}
