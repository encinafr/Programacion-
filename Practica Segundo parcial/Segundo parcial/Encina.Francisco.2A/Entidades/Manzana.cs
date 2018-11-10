using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    [Serializable]
    public class Manzana : Fruta, ISerializable
    {
        public string _distribuidora;

        #region "Propiedades"
        public override bool TieneCarozo
        { get { return true; } }

        public string Tipo
        { get { return "Manzana"; } }
        #endregion

        #region "Constructores"
        public Manzana() : base(0, ConsoleColor.White) { }

        public Manzana(float peso, ConsoleColor color, string distribuidora)
            : base(peso, color)
        { this._distribuidora = distribuidora; }
        #endregion

        #region "Métodos"
        #region "Implementacion de ISerializable"
        public string RutaArchivo
        { get; set; }

        public bool Deserializar()
        {
            Boolean retorno = false;
            XmlTextReader filePath = new XmlTextReader(this.RutaArchivo);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Manzana));

            try
            {
                Manzana auxManzana = ((Manzana)serializerXml.Deserialize(filePath));

                //Se asignan los atributos principales del auxiliar a la instancia
                this._color = auxManzana._color;
                this._distribuidora = auxManzana._distribuidora;
                this._peso = auxManzana._peso;
                this.RutaArchivo = auxManzana.RutaArchivo;

                retorno = true;
            }
            catch (Exception e) { }
            finally
            { filePath.Close(); }

            return retorno;
        }

        public bool Serializar()
        {
            Boolean retorno = false;
            XmlTextWriter fileEncoding = new XmlTextWriter(((ISerializable)this).RutaArchivo, Encoding.UTF8);
            XmlSerializer serializerXml = new XmlSerializer(typeof(Manzana));

            try
            {
                serializerXml.Serialize(fileEncoding, this);
                retorno = true;
            }
            catch (Exception e) { }
            finally
            { fileEncoding.Close(); }

            return retorno;
        }
        #endregion

        protected override string FrutaToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{2}-{1}", this.Tipo, this._distribuidora, base.FrutaToString());

            return stringBuild.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        { return this.FrutaToString(); }
        #endregion
    }
}
