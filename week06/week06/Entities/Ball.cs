using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace week06.Entities
{
    public class Ball : Label
    {
        public Ball()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Ball_Paint; //ez meghívja a 
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
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
