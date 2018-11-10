using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Manzana : Fruta, ISerializable
    {
        private string _distribuidora;

        public Manzana() { }

        public Manzana(float peso, ConsoleColor color, string distribuidora)
            : base(peso, color)
        {
            this._distribuidora = distribuidora;
        }

        public string Tipo { get { return "Manzana"; } }

        public override bool TieneCarozo
        {
	        get { return true; }
        }

        public string RutaArchivo { get; set; }

        protected override string FrutaToString()
        {
            return String.Format("TIPO: {0} -- {1} -- Distribuidora {2}", this.Tipo, base.FrutaToString(), this._distribuidora);
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        public bool SerializarXML()
        {
            bool returnValue = true;

            try
            {
                XmlTextWriter xmlT = new XmlTextWriter(this.RutaArchivo, Encoding.UTF8);

                XmlSerializer xmlS = new XmlSerializer(typeof(Manzana));

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
                XmlSerializer xmlS = new XmlSerializer(typeof(Manzana));

                Manzana m = (Manzana)xmlS.Deserialize(xmlR);

                this.Color = m.Color;
                this.Peso = m.Peso;
                this._distribuidora = m._distribuidora;

                xmlR.Close();
            }
            catch (Exception)
            {
                returnValue = false;
            }            

            return returnValue;
        }
    }
    }

