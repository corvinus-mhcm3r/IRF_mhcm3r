﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week06.Entities
{
    public class BallFactory
    {
        public Ball CreateNew() //a Ball-t is publicra kell állítani!!!
        {
            return new Ball();
        }
    }
}