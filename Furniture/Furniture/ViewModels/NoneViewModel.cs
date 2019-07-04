using System;

namespace Furniture.ViewModels
{
    public class NoneViewModel : ChildModel
    {
        public NoneViewModel(ItemViewModel sourceViewModel) : base(sourceViewModel) { }
        public override string Name { get; } = "None";
        public override decimal Total { get; set; }

        public override void UpdatePrice()
        {
            throw new NotImplementedException();
        }
    }
}