using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials.Items
{
    public abstract class MaterialBase : Child, IParent
    {
        public MaterialBase(IParent parent = null) : base(parent) { }

        public enum Material
        {
            None = 0,
            Wood = 1,
            Frame = 2,
            Concealed = 3,
            Handles = 4,
            Glass = 5,
            Drawer = 6,
            Foam = 7,
            Fabric = 8
        }

        public BindableCollection<IHasValue> Fields { get; set; }

        public abstract Material Type { get; }

        public abstract string Name { get; }

        public decimal Total { get; set; }

        public abstract decimal GetTotal();

        public override void OnPropertyChanged(string propertyName = null)
        {
            if (Fields?.All(field => field.HasValue) ?? false)
                Total = GetTotal();
            base.OnPropertyChanged(propertyName);
        }
    }
}