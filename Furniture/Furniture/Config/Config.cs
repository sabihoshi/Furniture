using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.Materials;
using Furniture.Work;

namespace Furniture.Config
{
    public class Config
    {
        public List<Material> Materials { get; set; }
        public Plywood Plywood { get; set; }
        public BindableCollection<QuotationColumn> Work { get; set; }
    }
}