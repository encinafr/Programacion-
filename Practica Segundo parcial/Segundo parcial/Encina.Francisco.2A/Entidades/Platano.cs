using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Platano : Fruta
    {
        private string _paisOrigen;

        public Platano() { }

        public Platano(float peso, ConsoleColor color, string pais)
            : base(peso, color)
        {
            this._paisOrigen = pais;
        }

        public string Tipo { get { return "Platano"; } }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        protected override string FrutaToString()
        {
            return String.Format("TIPO: {0} -- {1} -- Pais Origen {2}", this.Tipo, base.FrutaToString(), this._paisOrigen);    
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
