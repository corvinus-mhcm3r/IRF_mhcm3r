using irf_mhcm3r_gak7.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace irf_mhcm3r_gak7.Entities
{
    public class Food : Product
    {

        public Food()
        {
            Click += Food_Click;
        }

        private void Food_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                string.Format(
                    "Cím: {0}\n Megjegyzés: {1}",
                    Title,
                    Description
                    ));
        }

        public override void Display()
        {
            if (Calories <= 750)
                BackColor = Color.LightGreen;
            else if (Calories <= 1000)
                BackColor = Color.LightYellow;
            else
                BackColor = Color.Salmon;
        }
    }
}
