using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSnA
{
    // Riley contributed this code
    public class BSNode
    {
        public int Value;
        public BSNode Left, Right;

        public BSNode(int value)
        {
            Value = value;
            Left = Right = null;
        }
    }
}
