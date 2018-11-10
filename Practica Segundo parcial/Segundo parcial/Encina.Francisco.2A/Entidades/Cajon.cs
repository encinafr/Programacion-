using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public delegate bool CajonDelegado(float precio, string path);

    [Serializable]
    public class Cajon<T> : ISerializable
    {
        private int _capacidad;
        private List<T> _frutas;
        private float _precioUnitario;

        //HAGO PROPIEDADES DE L/E PARA SERIALIZAR
        public int Capacidad { get { return this._capacidad; } set { this._capacidad = value; } }
        public List<T> Frutas { get { return this._frutas; } set { this._frutas = value; } }
        public float PrecioTotal { 
            get {
                if (this._precioUnitario > 25)                    
                    this.EventoPrecio(this._precioUnitario, "cajonTxt.txt");

                return this._precioUnitario;
                
            } 
            set{ this._precioUnitario = value; } }

        public string RutaArchivo { get; set; }

        public Cajon()
        {
            this._frutas = new List<T>();
        }

        public Cajon(int capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(int capacidad, float precio)
            : this(capacidad)
        {
            this._precioUnitario = precio;
        }

        public static Cajon<T> operator +(Cajon<T> c, T f)
        {
            if (c.Frutas.Count < c._capacidad)
                c.Frutas.Add(f);
            else
                throw new CajonLlenoException();

            return c;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CAPACIDAD: {0}\n " +
                            "CANTIDAD DE FRUTAS: {1}\n " +
                            "PRECIO TOTAL: {2}\n\n", this._capacidad, this.Frutas.Count, this.PrecioTotal
                            );
            sb.AppendLine("FRUTAS:");

            foreach (T item in this.Frutas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public bool SerializarXML()
        {
            bool returnValue = true;

            try
            {
                XmlTextWriter xmlT = new XmlTextWriter(this.RutaArchivo, Encoding.UTF8);

                XmlSerializer xmlS = new XmlSerializer(typeof(Cajon<T>));

                xmlS.Serialize(xmlT, this);

                xmlT.Close();
            }
            catch (Exception)
            {
                returnValue = false;
            }

            return returnValue;
        }

        public bool DeserealizarXML()
        {
            bool returnValue = true;

            try
            {
                XmlTextReader xmlR = new XmlTextReader(this.RutaArchivo);
                XmlSerializer xmlS = new XmlSerializer(typeof(Cajon<T>));

                Cajon<T> c = (Cajon<T>)xmlS.Deserialize(xmlR);

                this.Capacidad = c.Capacidad;
                this.Frutas = c.Frutas;
                this.PrecioTotal = c.PrecioTotal;

                xmlR.Close();
            }
            catch (Exception)
            {
                returnValue = false;
            }

            return returnValue;
        }

            public bool ManejadorEventoPrecio(float precio, string path)
            {
                bool returnValue = true;

                try
                {
                    StreamWriter sw = new StreamWriter(path, true);
                    sw.Write("{0:G} -- PRECIO TOTAL: ", DateTime.Now);
                    sw.WriteLine(precio);
                    sw.Close();
                }
                catch (Exception)
                {
                    returnValue = false;
                }

                return returnValue;
            }

            public event CajonDelegado EventoPrecio;
    }
}
