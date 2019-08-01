using System;

namespace Furniture.ViewModels.Materials.Items
{
    public class NoneItem : MaterialBase
    {
        public NoneItem(ItemViewModel source) : base(source) { }

        public override string Name { get; } = "None";

        public override Material Type => Material.None;

        public override decimal GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}