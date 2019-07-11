using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Caption
{
    public class Int : IParse<int>
    {
        public bool TryParse(string input, out int output)
        {
            return int.TryParse(input, out output);
        }
    }
}
