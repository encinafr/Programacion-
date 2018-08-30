using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio08
{
    class Program
    {
        static void Main(string[] args)
        {
            int hora;
            int key=0;
            double horasTrabajadas;
            int antiguedad;
            double antiguedadBonificada;
            string nombre;
            Console.Title = "Ejercicio 8";
            double descuento;
            double sueldoSinDes;
            double sueldoTotal;
            bool continuar = true;
            do
            {
                // Menú
                Console.WriteLine("Ingrese el valor de la hora:");
                hora = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre:");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese sus años de antigüedad:");
                antiguedad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese las cantidad de horas trabadas:");
                horasTrabajadas = double.Parse(Console.ReadLine());

                sueldoSinDes = hora * horasTrabajadas;
                antiguedadBonificada = antiguedad * 150;
                descuento = (sueldoSinDes + antiguedadBonificada) * 0.13;
                sueldoTotal = (sueldoSinDes + antiguedadBonificada) - descuento;
                Console.WriteLine("El sueldo total de {0} es {1}", nombre, sueldoTotal);

                Console.WriteLine("Presione 1 para seguir ingresando");
                key = int.Parse(Console.ReadLine());
                if (key == 1)
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }



                
                Console.Clear();
            } while (continuar);
        }
    }
}
