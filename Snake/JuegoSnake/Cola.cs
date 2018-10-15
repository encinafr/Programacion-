using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoSnake
{
    class Cola: Objeto
    {
        Cola siguiente;
        public Cola(int x, int y)
        {
            this._x = x;
            this._y = y;
            siguiente = null;
        }


        public void dibujar(Graphics g)
        {
            if (siguiente != null)
            {
                siguiente.dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Green), this._x, this._y, this._ancho, this._ancho);
        }

        public void setxy(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.setxy(this._x, this._y);
            }
            this._x = x;
            this._y = y;
        
        }

        public void meter()
        {
            if (siguiente == null)
            {
                siguiente = new Cola(this._x, this._y);
            }
            else {
                siguiente.meter();
            }
        }

        public int getX()
        {
            return this._x;
        }


        public int getY()
        {
            return this._y;
        }

        public Cola GetSiguiente()
        {
              return siguiente;  
        }
    }
}
