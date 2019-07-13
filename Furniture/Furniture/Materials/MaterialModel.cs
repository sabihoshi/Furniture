using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Furniture.Properties;
using Furniture.Relationship;
using Furniture.ViewModels;

namespace Furniture.Materials
{
    public abstract class MaterialModel : Child, IParent
    {
        public MaterialModel(IParent parent) : base(parent)
        {
        }

        public List<object> Fields { get; set; }
        public abstract string Name { get; }
        public abstract decimal Total { get; set; }
        public abstract decimal GetTotal();
        public bool CanTotal() => Fields?.All(field => field != null) ?? false;

        public override void OnPropertyChanged(string propertyName = null)
        {
            if (CanTotal())
                Total = GetTotal();

            base.OnPropertyChanged(propertyName);
        }
    }
}