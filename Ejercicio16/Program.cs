using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio 16";
            Alumno a1 = new Alumno();
            a1.nombre = "Maluma";
            a1.apellido = "Babe";
            a1.legajo = 1234;

            a1.Estudiar(2, 10);
            a1.CalcularFinal();
            Console.WriteLine(a1.Mostrar());

            Alumno a2 = new Alumno();
            a2.nombre = "Turrita";
            a2.apellido = "...";
            a2.legajo = 2345;
            a2.Estudiar(5, 8);
            a2.CalcularFinal();
            Console.WriteLine(a2.Mostrar());

            Alumno a3 = new Alumno();
            a3.nombre = "Pepe";
            a3.apellido = "Salta Salta";
            a3.legajo = 2222;
            a3.Estudiar(4, 4);
            a3.CalcularFinal();
            Console.WriteLine(a3.Mostrar());

            Console.ReadKey();
        }
    }
}
