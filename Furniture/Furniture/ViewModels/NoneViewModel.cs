using System;

namespace Furniture.ViewModels
{
    public class NoneViewModel : MaterialViewModel
    {
        public NoneViewModel(ItemViewModel sourceViewModel) : base(sourceViewModel)
        {
        }

        public override string Name { get; } = "None";
        public override decimal Total { get; set; }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}