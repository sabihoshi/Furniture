using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.Micro;
using Furniture.Materials;
using Furniture.Work;

namespace Furniture.Config
{
    public class Config
    {
        public List<Material> Materials { get; set; }
        public BindingList<ICanCalculate> Work { get; set; }
        public Plywood Plywood { get; set; }
    }
}