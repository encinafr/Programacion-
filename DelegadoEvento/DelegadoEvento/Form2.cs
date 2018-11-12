using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegadoEvento
{
    public partial class Form2 : Form
    {
        public delegate void pasarDato(string dato);
        public event pasarDato pasado;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pasado(textBox1.Text);
        }

       
    }
}
