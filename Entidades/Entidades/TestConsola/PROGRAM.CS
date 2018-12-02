using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EntidadesPracticaPreRecuperatorio;
using System.Threading;

namespace TestConsola
{
   
    class Program


    {


        static void Main(string[] args)
        {

            Cartuchera<Utiles> cartuchera = new Cartuchera<Utiles>(2);
            cartuchera._marca = "Señor Cartuchera";
            Lapicera lapicera = new Lapicera("Big", 79, "Roja", "0.5");
            cartuchera.eventoCartuchera += new obtenerBD(cartuchera.obtenerUtilesBD);
            cartuchera.ElementoAgregadoEvent += new ElementoAgregado(ManejadorEventos);
            cartuchera.ElementoAgregadoEvent += new ElementoAgregado(ManejadorEventos2);
            cartuchera.Elementos = cartuchera.obtenerUtilesBD();
            Console.WriteLine(cartuchera.ToString());

            Thread t = new Thread(SegundoPlano);
            Thread.Sleep(10000);
            t.Start();


            Goma goma = new Goma("", 0.0, true);

            goma.Marca = "pork";
            goma.Precio = 56;
            goma.soloLapiz = true;




            try
            {
                cartuchera.Add(goma);
                cartuchera.Add(goma);
                cartuchera.Add(lapicera);
                cartuchera.Add(lapicera);

            }
            catch (CarucheraLlenaExeption e)
            {
                Console.WriteLine(e.Message);
            }



            Console.WriteLine(cartuchera.ToString());

            string path = AppDomain.CurrentDomain.BaseDirectory + "XML.xml";
            string path2 = AppDomain.CurrentDomain.BaseDirectory + "XML2.xml";
            cartuchera.SerializarXml(path);
            cartuchera.DeserializarXml(path);
            cartuchera.SerializarXML2(path2);
            cartuchera.DeserializarXml2(path2);
            lapicera.SerializarXml(path2);


            Console.ReadLine();

            Console.ReadKey();



        }


        public static void SegundoPlano()
        { 
            
        
        }

       public static void ManejadorEventos(object o, CartucheraEventArgs e)
        {

            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Cartuchera.txt", true);

            sw.WriteLine(e.Util +" "+ DateTime.Now.ToString());

            sw.Close();

        }

       public static void ManejadorEventos2(object o, CartucheraEventArgs e)
       {
           StreamReader objReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\Cartuchera.txt", true);

          Console.WriteLine(objReader.ReadToEnd());
          Console.ReadKey();

           objReader.Close();

       }
       
    }
        
    

}
