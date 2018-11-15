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

  public class Cajon<T> : ISerializar
  {
    #region "Evento"
    public event CajonDelegado EventoPrecio;
    #endregion

    #region "Delegado para Cajon"
    public delegate void CajonDelegado(double precio);
    #endregion
    protected List<T> _elementos;
    protected int _capacidad;
    protected double _precioUnitario;

    #region "Propiedades"
    public List<T> Elementos
    { get { return this._elementos; } }

    public double PrecioTotal
    {
      get
      {
         double precio = this._precioUnitario * this._elementos.Count();
         if (precio > 55)
         {
             this.EventoPrecio(precio);
         }
         return precio;
      }
    }
    #endregion

    #region "Constructores"
    private Cajon()
    {
        this._elementos = new List<T>();
    }

    public Cajon(int capacidad)
        : this()
    {
        this._capacidad = capacidad;
    }

    public Cajon(double precioUnitario, int capacidad)
        : this(capacidad)
    {
        this._precioUnitario = precioUnitario;
    }
    #endregion





    public static Cajon<T> operator +(Cajon<T> cajon, T fruta)
    {
        if (cajon.Elementos.Count <= cajon._capacidad)
        {
            cajon.Elementos.Add(fruta);
            return cajon;
        }
        else
        {
            throw new CajonLlenoException("\nCajon Lleno");
        }
    }





    public override string ToString()
    {
      StringBuilder stringBuild = new StringBuilder();
      stringBuild.AppendFormat("Capacidad del Cajón: {0}\n", this._capacidad);
      stringBuild.AppendFormat("Cantidad de frutas en el Cajón: {0}\n", this._elementos.Count);
      stringBuild.AppendFormat("Precio total del Cajón: {0}\n", this.PrecioTotal);

      foreach (T frutaA in this._elementos)
      { stringBuild.AppendLine(frutaA.ToString()); }

      return stringBuild.ToString();
    }


    public bool Xml(string dato)
    {
      Boolean retorno = false;
        using (TextWriter writer = new StreamWriter(String.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), dato)))
      

      try
      {
          XmlSerializer serializerXml = new XmlSerializer(typeof(Cajon<T>));
        serializerXml.Serialize(writer, this);
        retorno = true;
      }
      catch (Exception e)
      { /*Console.WriteLine(e.Message);*/ }
      finally
      { writer.Close(); }

      return retorno;
    }

   

  } 
  }
