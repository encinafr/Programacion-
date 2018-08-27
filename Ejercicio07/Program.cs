using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 7";
            DateTime fecha;
            fecha = new DateTime();

            DateTime fecha1;
            fecha1 = new DateTime();
            fecha1 = DateTime.Now;

            Console.WriteLine("Ingrese su fecha de nacimiento dd/mm/yy");
            fecha = Convert.ToDateTime(Console.ReadLine());

            //Console.WriteLine(fecha.ToString());
            Console.WriteLine("Los dias vivido desde su nacimiento hasta hoy son: {0}",fecha1.Subtract(fecha).Days);
            Console.ReadKey();
        }
    }
}
