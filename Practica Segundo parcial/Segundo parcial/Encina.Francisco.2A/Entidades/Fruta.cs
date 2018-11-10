using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Platano))]
    [XmlInclude(typeof(Manzana))]
    public abstract class Fruta
    {
        protected ConsoleColor _color;
        protected float _peso;

        public abstract bool TieneCarozo { get; }

        public ConsoleColor Color { get { return this._color; } set { this._color = value; } }
        public float Peso { get { return this._peso; } set { this._peso = value; } }

        public Fruta() { }

        public Fruta(float peso, ConsoleColor color)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {
            return String.Format("Color {0} -- Peso {1}", this._color, this._peso);
        }    
    }
}
