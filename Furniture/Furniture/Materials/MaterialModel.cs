using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Furniture.Caption;
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

        public List<IHasValue> Fields { get; set; }
        public abstract string Name { get; }

        public decimal Total { get; set; }

        public abstract decimal TryGetTotal();

        public override void OnPropertyChanged(string propertyName = null)
        {
            if (Fields?.All(field => field.HasValue) ?? false)
                Total = TryGetTotal();
            base.OnPropertyChanged(propertyName);
        }
    }
}