using irf_mhcm3r_gak7.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irf_mhcm3r_gak7.Entities
{
    public class Drink : Product //miután quick actionnel behoztuk az abstract mappát, még probléma volt a Drink-el, quick actions --> implement
    {
        public string Description { get; set; }


        public override void Display()
        {
            BackColor = Color.LightBlue;
        }
    }
}
