using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Furniture.ViewModels.Materials.Models;

namespace Furniture.ViewModels.Materials.Items
{
    public sealed class WoodItem : MaterialBase
    {
        private readonly Wood _wood;

        public WoodItem(ItemViewModel parent, Wood wood) : base(parent)
        {
            _wood = wood;
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateTextBox(nameof(Thickness), int.TryParse, "in", 2);
            Width = builder.CreateComboBox(nameof(Width), this.GetCuboid().Widths, label: "in");
            Length = builder.CreateComboBox(nameof(Length), this.GetCuboid().Lengths, label: "ft");
            Quantity = builder.CreateTextBox(nameof(Quantity), int.TryParse, value: 1);

            Fields = new BindableCollection<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public override string Name => _wood.Name;

        public override Material Type { get; } = Material.Wood;

        public Caption<int> Length { get; }

        public Caption<int> Quantity { get; }

        public Caption<int> Thickness { get; }

        public Caption<int> Width { get; }

        public override decimal GetTotal()
        {
            return (Thickness.Value ?? 0) * (Width.Value ?? 0) * (Length.Value ?? 0) / 12m * (Quantity.Value ?? 0) * _wood.Value;
        }
    }
}