using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosaic.UI.Utils
{
    public struct Range
    {
        public int _min;
        public int _max;
        public bool Contains(int val)
        {
            return _min <= val && _max >= val;
        }
    };

}
