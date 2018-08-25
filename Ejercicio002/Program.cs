using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Clase 2";
            Double num;
            Double res;
            Double res1;
            
            Console.WriteLine("Ingrese un numero");
            num = Convert.ToDouble(Console.ReadLine());

            while(num < 0)
            {
                Console.WriteLine("Error,Ingrese un numero");
                num = Convert.ToDouble(Console.ReadLine());
            }
            res = Math.Pow(num, 2);
            res1 = Math.Pow(num, 3);
            Console.WriteLine("El cuadrado del numero ingresado es es {0} y el cubo {1,1:#,##.00}",res,res1);
            Console.ReadKey();
            
        }
    }
}
