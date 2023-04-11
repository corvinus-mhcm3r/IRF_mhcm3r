using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace week06.Abstractions //átmásoltuk a labdát, de ezt írjuk át erre a mappára!!!
{
    public abstract class Toy : Label //itt rename-el a Ballt átírtuk Toy-ra, de csak azután szabad, hogy átírtuk a mappát
    {
        public Toy()
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

        protected abstract void DrawImage(Graphics g); //itt ezt az osztályhoz is be kell írni, hogy abstract

        public void MoveBall()
        {
            Left += 1;
        }
    }
}
