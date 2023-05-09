using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irf_mhcm3r_gyak9_2.Entities
{
    public class BirthProbability
    {
        public Gender Gender { get; set; }
        public byte NbrOfChildren { get; set; }
        public double P {get;set; }
    }
}
