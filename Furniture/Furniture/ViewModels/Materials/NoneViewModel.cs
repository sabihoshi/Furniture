using System;

namespace Furniture.ViewModels.Materials
{
    public class NoneViewModel : MaterialModel
    {
        public NoneViewModel(ItemViewModel source) : base(source) { }
        public override string Name { get; } = "None";

        public override Material Type => Material.None;

        public override decimal GetTotal()
        {
            throw new NotImplementedException();
        }
    }
}