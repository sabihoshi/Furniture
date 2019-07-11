using System.Collections.Generic;
using Furniture.Caption;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public sealed class WoodViewModel : MaterialViewModel, IParent
    {
        private readonly Material _material;

        public WoodViewModel(ItemViewModel source, Material material) : base(source)
        {
            Fields = new List<CaptionViewModel>
            {
                this.CreateTextBox("Thickness"),
                this.CreateTextBox("Width"),
                this.CreateTextBox("Length"),
                this.CreateTextBox("Quantity"),
            };
            _material = material;
        }

        public List<CaptionViewModel> Fields { get; set; }

        public override string Name => _material.Name;
        public override decimal Total { get; set; }

        public override void Update()
        {
            Parent.Update();
        }
    }
}