using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
  [Serializable]
  public class Banana : Fruta
  {
    public string _paisOrigen;

    #region "Propiedades"
    public override bool TieneCarozo
    { get { return false; } }

    public string Nombre
    { get { return "Plátano"; } }
    #endregion

    #region "Constructores"
    public Banana() : base(0, "Amarillo") { }

    public Banana (string color, float peso, string pais)
        : base(peso, color)
    { this._paisOrigen = pais; }
    #endregion

    #region "Métodos"
    protected override string FrutaToString()
    {
      StringBuilder stringBuild = new StringBuilder();
      stringBuild.AppendFormat("{0}-{2}-{1}", this.Nombre, this._paisOrigen, base.FrutaToString());

      return stringBuild.ToString();
    }
    #endregion

    #region "Sobrecargas"
    public override string ToString()
    { return this.FrutaToString(); }
    #endregion
  }
}
