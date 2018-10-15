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
    class Comida : Objeto
    {
        public Comida()
        {
            this._x = generar(78);//78 es ancho del pictureBox
            this._y = generar(39);
        }
        public void DibujerGraphics(Graphics g)
        { 
            g.FillRectangle(new SolidBrush(Color.Red), this._x,this._y,this._ancho,this._ancho);
        }
        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
        public void colocar()
        {
            this._x = generar(78);//87 es ancho del pictureBox
            this._y = generar(39);
        }
    }
}
