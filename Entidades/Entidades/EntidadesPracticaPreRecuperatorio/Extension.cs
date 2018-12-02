using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesPracticaPreRecuperatorio
{
    [XmlInclude(typeof(Lapicera))]
    [XmlInclude(typeof(Goma))]
    [Serializable]
   public static class Extension
    {
       public static bool SerializarXML2(this ISerializar xml, string ruta)
       {
          /* try
           {
               
               StreamWriter tw = new StreamWriter(ruta);
               XmlSerializer serializer = new XmlSerializer(typeof(Cartuchera<Utiles>));
               serializer.Serialize(tw, xml);
               tw.Close();
               return true;

           }
           catch (Exception e)
           {

              // tw.Close();
               return false;

           }*/
           return xml.SerializarXml(ruta);
       }

       public static bool DeserializarXml2(this ISerializar xml, string ruta)
       {

           StreamReader tr = new StreamReader(ruta);
           Cartuchera<Utiles> cartuvhera = new Cartuchera<Utiles>(2);
           try
           {

               XmlSerializer serializer = new XmlSerializer(typeof(Cartuchera<Utiles>));
               cartuvhera = (Cartuchera<Utiles>)serializer.Deserialize(tr);

               Console.WriteLine(cartuvhera.ToString());
               Console.ReadKey();
               tr.Close();
               return true;

           }
           catch (Exception e)
           {

               tr.Close();

               return false;

           }
       }
    }
}
