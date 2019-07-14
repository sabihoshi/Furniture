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

            Thickness = builder.CreateTextBox<decimal>(nameof(Thickness), decimal.TryParse);
            Width = builder.CreateComboBox(nameof(Width), App.Config.Widths);
            Length = builder.CreateComboBox(nameof(Length), App.Config.Lengths);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse);


            Fields = new List<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public CaptionViewModel<decimal> Thickness { get; } 
        public CaptionViewModel<int> Width { get; } 
        public CaptionViewModel<int> Length { get; } 
        public CaptionViewModel<int> Quantity { get; } 

        public override string Name => _material.Name;

        public override decimal TryGetTotal()
        {
            return (decimal) ((Thickness.Value + Width.Value + Length.Value) / 12 * Quantity.Value);
        }
    }
}