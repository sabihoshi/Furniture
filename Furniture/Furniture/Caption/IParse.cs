using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Caption
{
    public interface IParse<TOutput>
    {
        bool TryParse(string input, out TOutput output);
    }
}
