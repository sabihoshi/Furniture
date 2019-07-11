using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Caption
{
    public class String : IParse<string>
    {
        public bool TryParse(string input, out string output)
        {
            output = input;
            return true;
        }
    }
}
