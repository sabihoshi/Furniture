using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public sealed class WoodViewModel : MaterialModel, IParent
    {
        private readonly IMaterial _material;

        public WoodViewModel(ItemViewModel source, IMaterial material) : base(source)
        {
            _material = material;
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateTextBox(nameof(Thickness), int.TryParse, 2);
            Width = builder.CreateComboBox(nameof(Width), App.Config.Widths);
            Length = builder.CreateComboBox(nameof(Length), App.Config.Lengths);
            Quantity = builder.CreateTextBox(nameof(Quantity), int.TryParse, 1);

            Fields = new List<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public CaptionModel<int> Length { get; }

        public override string Name => _material.Name;
        public CaptionModel<int> Quantity { get; }

        public CaptionModel<int> Thickness { get; }

        public override Material Type => Material.Wood;
        public CaptionModel<int> Width { get; }

        public override decimal GetTotal()
        {
            return (decimal) (Thickness.Value * Width.Value * Length.Value / 12m * Quantity.Value * _material.Price);
        }
    }
}