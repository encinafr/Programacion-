using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int i;
            int max = 0;
            int min = 0;
            int acum = 0;
            double promedio;
            
                for ( i = 0; i < 10; i++)
                {
                    Console.WriteLine("Ingrese un numero");
                    num = int.Parse(Console.ReadLine());
                    while (!(Validacion.Validar(num, 100, 0)))
                    {
                        Console.WriteLine("Error,Fuera del rango");
                        Console.WriteLine("Ingrese un numero");
                        num = int.Parse(Console.ReadLine());
                    }
                    acum=acum +num;
                    if (i == 0)
                    {
                        max = num;
                        min = num;
                    }
                    if (num > max)
                    {
                        max = num;
                    }
                    if (num < min)
                    {
                        min = num;
                    }
                    Console.Clear();
                }
            promedio = (acum / (float)i);
            Console.WriteLine("El max ingresado es: {0} el min {1} y el promedio {2}", max, min, promedio);
                   
            Console.ReadKey();

        }
    }
}
