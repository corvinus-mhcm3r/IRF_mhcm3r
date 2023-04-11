using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week06.Abstractions;
using week06.Entities;

namespace week06
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;           //propfull TabTab

        public IToyFactory Factory
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
            var toy = Factory.CreateNew(); //így a gyárral létrehozok egy labdát, és azért így (nem create new = ...) mert a gyárat másra is akarom használni
            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Width;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e) //ezzel most beállítjuk, hogy kék labdák jöjjenek balról jobbra
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveBall();
                if (toy.Left > maxPosition)
                {
                    maxPosition = toy.Left;
                }
            }

            if (maxPosition > 1000) //ezzel állítjuk meg, hogy a végtelenségig menjenek a labdák
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btnSelectBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }
    }
}
