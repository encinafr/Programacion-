using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Platano : Fruta
    {
        public string _paisOrigen;

        #region "Propiedades"
        public override bool TieneCarozo
        { get { return false; } }

        public string Tipo
        { get { return "Plátano"; } }
        #endregion

        #region "Constructores"
        public Platano() : base(0, ConsoleColor.White) { }

        public Platano(float peso, ConsoleColor color, string pais)
            : base(peso, color)
        { this._paisOrigen = pais; }
        #endregion

        #region "Métodos"
        protected override string FrutaToString()
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.AppendFormat("{0}-{2}-{1}", this.Tipo, this._paisOrigen, base.FrutaToString());

            return stringBuild.ToString();
        }
        #endregion

        #region "Sobrecargas"
        public override string ToString()
        { return this.FrutaToString(); }
        #endregion
    }
}
