using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.Entities;

namespace week06
{
    public partial class Form1 : Form
    {
        List<Ball> _balls = new List<Ball>();
        private BallFactory _factory;           //propfull TabTab

        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e) //ezeknél át kellett állítani az Enabled-et és az időt is!!
        {
            var ball = Factory.CreateNew(); //így a gyárral létrehozok egy labdát, és azért így (nem create new = ...) mert a gyárat másra is akarom használni
            _balls.Add(ball);
            mainPanel.Controls.Add(ball);
            ball.Left = -ball.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e) //ezzel most beállítjuk, hogy kék labdák jöjjenek balról jobbra
        {
            var maxPosition = 0;
            foreach (var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxPosition)
                {
                    maxPosition = ball.Left;
                }
            }

            if (maxPosition > 1000) //ezzel állítjuk meg, hogy a végtelenségig menjenek a labdák
            {
                var oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);
            }
        }
    }
}
