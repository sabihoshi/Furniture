using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.Models;

namespace Furniture.ViewModels
{
    public class NoneViewModel : IMaterial
    {
        public decimal Price { get; }
        public string Name { get; } = "None";
    }
}
