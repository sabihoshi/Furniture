using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public sealed class WoodViewModel : MaterialBase, IParent
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

            Fields = new BindableCollection<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public CaptionViewModel<int> Length { get; }

        public override string Name => _material.Name;
        public CaptionViewModel<int> Quantity { get; }

        public CaptionViewModel<int> Thickness { get; }

        public override Material Type => Material.Wood;
        public CaptionViewModel<int> Width { get; }

        public override decimal GetTotal()
        {
            return (decimal) (Thickness.Value * Width.Value * Length.Value / 12m * Quantity.Value * _material.Price);
        }
    }
}