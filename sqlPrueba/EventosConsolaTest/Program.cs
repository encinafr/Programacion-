using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades2;

namespace EventosConsolaTest
{
  class Program
  {
    static void Main(string[] args)
    {
      Televisor miTele = new Televisor(15, "Phonic", 222, 42, "Argentina");
      
      //siempre ejecuta todos los metodos asociados al evento
      miTele.MiEvento += new MiDelegado(MiMetodoDelegado);
      miTele.MiEvento += new MiDelegado(new Program().MiMetodoDelegado2);
      miTele.EventoTv += new DelegadoTv(new Program().MostrarDeEvento);

      //miTele.MiEvento += new MiDelegado(MiMetodoDelegado);
      //miTele.MiEvento += new MiDelegado(new Program().MiMetodoDelegado2);
      //miTele.EventoTv += new DelegadoTv(new Program().MostrarDeEvento);

      //miTele.MiEvento += new MiDelegado(MiMetodoDelegado);
      //miTele.MiEvento += new MiDelegado(new Program().MiMetodoDelegado2);
      //miTele.EventoTv += new DelegadoTv(new Program().MostrarDeEvento);

      miTele.Insertar();

    }

    public static void MiMetodoDelegado()
    {
      Console.WriteLine("Se inserto un registro en la base de datos");
      Console.ReadKey();

    }

    public void MiMetodoDelegado2()
    {
      Console.WriteLine("Estoy en el segundo metodo del delegado");
      Console.ReadKey();
    }

    public void MostrarDeEvento(Televisor Tv,TvEventsArg tv)
    {
     Console.WriteLine(Tv.ToString());
      Console.WriteLine(tv.Fecha);
      Console.ReadKey();
    }

    
  }
}
