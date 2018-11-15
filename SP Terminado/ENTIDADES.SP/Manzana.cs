using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ENTIDADES.SP
{
  
  public class Manzana : Fruta,ISerializar,IDeserializar
  {
    public string _provinciaOrigen;

    #region "Propiedades"
    public override bool TieneCarozo
    { get { return true; } }

    public string Nombre
    { get { return "Manzana"; } }
    #endregion

    #region "Constructores"
    public Manzana() : base(0, "Blanco") { }

    public Manzana( string provincia, float peso, string color) : base(peso, color)
    { this._provinciaOrigen= provincia; }
    #endregion

    

    
    protected override string FrutaToString()
    {
      StringBuilder stringBuild = new StringBuilder();
      stringBuild.AppendFormat("{0}-{2}-{1}", this.Nombre, this._provinciaOrigen, base.FrutaToString());

      return stringBuild.ToString();
    }
    

    #region "Sobrecargas"
    public override string ToString()
    { return this.FrutaToString(); }

    public bool Xml(string dato)
    {
        Boolean retorno = false;
        using (TextWriter writer = new StreamWriter(String.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dato)))


            try
            {
                XmlSerializer serializerXml = new XmlSerializer(typeof(Manzana));
                serializerXml.Serialize(writer, this);
                retorno = true;
            }
            catch (Exception e)
            { /*Console.WriteLine(e.Message);*/ }
            finally
            { writer.Close(); }

        return retorno;

     
    }

    bool IDeserializar.Xml(string ruta, out Fruta fruta)
    {
        bool retorno = false;
        using (TextReader reader = new StreamReader(String.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ruta)))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Manzana));
            fruta = (Manzana)serializer.Deserialize(reader);
            retorno = true;
        }
        return retorno;
    }
    #endregion
  }
}
