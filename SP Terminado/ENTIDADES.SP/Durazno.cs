using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{
  public class Durazno: Fruta
  {
    protected int _cantPelusa;
    #region "Constructores"
    public Durazno() : base(0, "Blanco") { }

    public Durazno(string color, float peso, int pelusa)
        : base(peso, color)
    { this._cantPelusa = pelusa; }
    #endregion

    public string Nombre
    { get { return "Durazno"; } }

    public override bool TieneCarozo
    { get { return true; } }

    #region "Métodos"
    protected override string FrutaToString()
    {
      StringBuilder stringBuild = new StringBuilder();
      stringBuild.AppendFormat("{0}-{2}-{1}", this.Nombre, this._cantPelusa, base.FrutaToString());

      return stringBuild.ToString();
    }
    #endregion

    #region "Sobrecargas"
    public override string ToString()
    { return this.FrutaToString(); }
    #endregion
  }
}
