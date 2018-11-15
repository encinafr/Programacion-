using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ENTIDADES.SP
{
  public abstract class Fruta: ISerializar
  {
    protected string _color;
    protected double _peso;

    #region "Propiedades"
    public abstract bool TieneCarozo
    { get; }

    public double Peso
    {
        get
        {
            return this._peso;
        }
        set
        {
            this._peso = value;
        }
    }

     
    #endregion

    #region "Constructores"
    public Fruta(float peso, string color)
    {
      this._color = color;
      this._peso = peso;
    }
    #endregion

    #region "Métodos"
    protected virtual string FrutaToString()
    {
      StringBuilder stringBuild = new StringBuilder();
      stringBuild.AppendFormat("{0}-{1}", this._color, this._peso);

      return stringBuild.ToString();
    }
    #endregion

    public bool Xml(string dato)
    {
      Boolean retorno = false;
      XmlTextWriter fileEncoding = new XmlTextWriter(dato, Encoding.UTF8);
      XmlSerializer serializerXml = new XmlSerializer(typeof(Fruta));

      try
      {
        serializerXml.Serialize(fileEncoding, this);
        retorno = true;
      }
      catch (Exception e)
      { /*Console.WriteLine(e.Message);*/ }
      finally
      { fileEncoding.Close(); }

      return retorno;
    }
  }
}
