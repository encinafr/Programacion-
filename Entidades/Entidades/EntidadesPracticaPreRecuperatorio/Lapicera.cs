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
   public class Lapicera: Utiles,ISerializar
    {
        public string _color;
        public string _trazo;
       

        public Lapicera()
        {}
       
        public Lapicera(string marca, double precio, string color, string trazo):base(marca,precio)
        {
            this._color = color;
            this._trazo = trazo;
        }

        public override double Precio
        {
            get
            {
                return base._precio;
                
            }

            set
            {
                base._precio = value;

            }
        }
        public override string Marca
        {
            get
            {
                return base._marca;
            }
            set
            { base._marca = value; }
        }


        public override string ToString()
        {
            return string.Format(base.utilesToString()+ "| Color: "+this._color + "| Trazo: "+ this._trazo);
        }

        public bool SerializarXml(string ruta)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(this.GetType());
                TextWriter tw = new StreamWriter(ruta);
                serializer.Serialize(tw, this);
                tw.Close();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }
        }

        public bool DeserializarXml(string ruta)
        {
            StreamReader tr = new StreamReader(ruta);
            Lapicera lapicera = new Lapicera(" ",0.0,"","");
            try
            {

                XmlSerializer serializer = new XmlSerializer(this.GetType());
                lapicera = (Lapicera)serializer.Deserialize(tr);

                Console.WriteLine(lapicera.ToString());
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
