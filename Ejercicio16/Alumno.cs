using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio16
{
    class Alumno
    {
        byte _nota1;
        byte _nota2;
        float _notaFinal;
        public string apellido;
        public string nombre;
        public int legajo;

        public void CalcularFinal()
        {
            Random r = new Random();
            if (this._nota1 >= 4 && this._nota2 >= 4)
            {
                this._notaFinal = r.Next(0, 10);//devuelve un numero entero aleatorio 
            }
            else
            {
                this._notaFinal = -1;
            }
        }

        public void Estudiar(byte notaUno, byte notaDos)
        {
            this._nota1 = notaUno;
            this._nota2 = notaDos;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();// Te permite Cargar contenido para devolverlo

            sb.AppendFormat("El alumno {1} {0} legajo {2} sacó {3} en el 1er examen y {4} en el 2do", this.apellido, this.nombre, this.legajo, this._nota1, this._nota2);
           
            if (this._notaFinal != -1)
            {
                sb.AppendFormat(" y su nota final fue {0}", this._notaFinal);
              
            }
            else
            {
                sb.AppendFormat(" Alumno Desaprobado");
                
            }
            sb.AppendFormat("\n");
            return sb.ToString();
        }
    }



    
}
