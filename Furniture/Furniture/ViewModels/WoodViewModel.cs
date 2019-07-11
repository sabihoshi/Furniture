using System.Collections.Generic;
using System.Linq;
using Furniture.Caption;
using Furniture.Materials;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public sealed class WoodViewModel : MaterialModel, IParent
    {
        private readonly IMaterial _material;

        public WoodViewModel(ItemViewModel source, IMaterial material) : base(source)
        {
            _material = material;
            var builder = new CaptionBuilder(this);

            Fields = new List<CaptionViewModel<decimal>>
            {
                builder.CreateTextBox(Thickness, nameof(Thickness)),
                builder.CreateComboBox(Width, nameof(Width), App.Config.Widths),
                builder.CreateComboBox(Length, nameof(Length), App.Config.Lengths),
                builder.CreateTextBox(Quantity, nameof(Quantity))
            };
        }

        public CaptionViewModel<decimal> Thickness { get; } 
        public CaptionViewModel<decimal> Width { get; } 
        public CaptionViewModel<decimal> Length { get; } 
        public CaptionViewModel<decimal> Quantity { get; } 

        public override string Name => _material.Name;
        public override decimal Total { get; set; }
    }
}