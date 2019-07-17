using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;
using Furniture.Views.Materials;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public abstract class MaterialModel : Child, IParent
    {
        public enum Material
        {
            None, Wood, Frame,
            Concealed, Handles, Glass
        }

        public MaterialModel(IParent parent) : base(parent)
        {
            // Currently does not work
            // ViewModelBinder.Bind(this, new MaterialMasterView(), null);
        }

        public List<IHasValue> Fields { get; set; }
        public abstract string Name { get; }
        public decimal Total { get; set; }

        public abstract Material Type { get; }

        public override void OnPropertyChanged(string propertyName = null)
        {
            if (Fields?.All(field => field.HasValue) ?? false)
                Total = GetTotal();
            base.OnPropertyChanged(propertyName);
        }

        public abstract decimal GetTotal();
    }
}