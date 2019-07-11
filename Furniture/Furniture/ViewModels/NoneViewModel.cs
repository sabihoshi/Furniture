using System;

namespace Furniture.ViewModels
{
    public class NoneViewModel : MaterialViewModel
    {
        public NoneViewModel(ItemViewModel source) : base(source) { }

        public override string Name { get; } = "None";
        public override decimal Total { get; set; }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}