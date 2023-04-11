using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week06.Abstractions;

namespace week06.Entities
{
    public class CarFactory : IToyFactory
    {
        public Toy CreateNew() //a Ball-t is publicra kell állítani!!!
        {
            return new Car();
        }
    }
}
