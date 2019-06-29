using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Models
{
    public interface IMaterial
    {
        decimal Price { get; }
        string Name { get; }
    }
}
