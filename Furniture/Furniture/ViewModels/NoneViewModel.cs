using System;

namespace Furniture.ViewModels
{
    public class NoneViewModel : ChildViewModel
    {
        public NoneViewModel(ItemViewModel sourceViewModel) : base(sourceViewModel) { }
        public override string Name { get; } = "None";
        public override decimal Total { get; set; }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}