using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week06.Abstractions
{
    public interface IToyFactory //az interface-eket általában nagy I-vel kezdünk
    {
        Toy CreateNew();
    }
}
