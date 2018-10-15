using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSnake
{
    class Objeto
    {
        protected int _x;
        protected int _y;
        protected int _ancho;

        public Objeto()
        {
            this._ancho = 10;
        }

        public Boolean Interseccion(Objeto O)
        {
            Boolean ret = false;
            int difx = Math.Abs(this._x - O._x);
            int dify = Math.Abs(this._y - O._y);
            if (difx >= 0 && difx < _ancho && dify >= 0 && dify < _ancho)
            {
                ret = true;
            }
            return ret;
            
        }
    }

}
