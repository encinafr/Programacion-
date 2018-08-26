using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 3";
            int num;
            int Flag =0;
            int cont = 0;

            Console.WriteLine("Ingrese un numero");
            num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        cont++;
                    }
                }
                if (cont < 3)
                {
                    if (Flag == 0)
                    {
                        Console.WriteLine("Los numeros primos que existen hasta el {0} son:", num);
                        Flag = 1;
                    }
                    Console.Write(i+" ");

                }
                cont = 0;
                
            }
                Console.ReadKey();         
        }
    }
}
