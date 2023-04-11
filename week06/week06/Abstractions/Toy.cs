using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace week06.Abstractions //átmásoltuk a labdát, de ezt írjuk át erre a mappára!!!
{
    public class Ball : Label //itt rename-el a Ballt átírtuk Toy-ra, de csak azután szabad, hogy átírtuk a mappát
    {
        public Ball()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_Paint; //itt is megváltoztattuk a nevet, rename-el
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics); //ez kell, hogy használja a rajzolást
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height); //ez rajzol rá egy kék kört
        }

        public void MoveBall()
        {
            Left += 1;
        }
    }
}
