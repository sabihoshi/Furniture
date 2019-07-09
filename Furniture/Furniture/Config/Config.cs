using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Micro;
using Furniture.Materials;
using Furniture.Work;

namespace Furniture.Config
{
    public class Config
    {
        public List<Material> Materials { get; set; }
        public BindableCollection<ICanCalculate> Work { get; set; }
        public Plywood Plywood { get; set; }
    }
}