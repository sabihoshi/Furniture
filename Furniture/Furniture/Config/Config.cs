using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Materials;
using Furniture.ViewModels.Quotation;

namespace Furniture.Config
{
    public class Config
    {
        public List<int> Lengths { get; set; }
        public Plywood Plywood { get; set; }
        public List<decimal> Values { get; set; }
        public List<int> Widths { get; set; }
        public List<Wood> Woods { get; set; }
        public BindableCollection<Quotation> Work { get; set; }
    }
}