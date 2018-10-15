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
    public partial class Form1 : Form
    {
        Cola cabeza;
        Comida comida;
        Graphics g;
        int xdir;
        int puntaje=0;
        int ydir;
        int cuadro = 10;
        Boolean ejex = true;
        Boolean ejey = true;
        public Form1()
        {
            InitializeComponent();
            cabeza = new Cola(10, 10);
            comida = new Comida();
            g = cambas.CreateGraphics();
           
        }
        public void choqueCuerpo()
        {
            Cola tem;
            try
            {
                tem = cabeza.GetSiguiente().GetSiguiente();
            }
            catch (Exception err)
            {
                tem = null;
            }
            while(tem != null)
            {
                if (cabeza.Interseccion(tem))
                {
                    Finjuego();
                }
                else
                {
                    tem = tem.GetSiguiente();
                }
            }
        }
        public void choquePared()
        {
            if (cabeza.getX() < 0 || cabeza.getX() > 770 || cabeza.getY() < 0 || cabeza.getY() > 380)
            {
                Finjuego();
            }
        }

        public void Finjuego()
        {
            puntaje = 0;
            lblpuntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new Cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Perdedor!!!");
        }

        public void movimiento()
        {
            cabeza.setxy(cabeza.getX() + xdir, cabeza.getY() + ydir);
        }
        private void bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.DibujerGraphics(g);
            movimiento();
            choqueCuerpo();
            choquePared();
            if (cabeza.Interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                lblpuntos.Text = puntaje.ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
 
            }
            if (ejey)
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
 
            }
        }

        
    }
}
