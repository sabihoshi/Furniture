using System;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public class NoneViewModel : MaterialModel
    {
        public NoneViewModel(ItemViewModel source) : base(source) { }

        public override string Name { get; } = "None";

        public override decimal TryGetTotal()
        {
            throw new NotImplementedException();
        }
    }
}