using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public sealed class WoodViewModel : MaterialModel, IParent
    {
        private readonly IMaterial _material;

        public override Material Type => Material.Wood;

        public WoodViewModel(ItemViewModel source, IMaterial material) : base(source)
        {
            _material = material;
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateTextBox(nameof(Thickness), int.TryParse, 2);
            Width = builder.CreateComboBox(nameof(Width), App.Config.Widths);
            Length = builder.CreateComboBox(nameof(Length), App.Config.Lengths);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse, 1);


            Fields = new List<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public CaptionViewModel<int> Thickness { get; } 
        public CaptionViewModel<int> Width { get; } 
        public CaptionViewModel<int> Length { get; } 
        public CaptionViewModel<int> Quantity { get; } 

        public override string Name => _material.Name;

        public override decimal GetTotal()
        {
            return (decimal) ((Thickness.Value * Width.Value * Length.Value) / 12m * Quantity.Value * _material.Price);
        }
    }
}