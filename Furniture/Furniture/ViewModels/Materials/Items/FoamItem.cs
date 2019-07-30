using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Furniture.ViewModels.Materials.Models;

namespace Furniture.ViewModels.Materials.Items
{
    public class FoamItem : MaterialBase
    {
        public FoamItem(ItemViewModel parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateTextBox(nameof(Thickness), int.TryParse, "in", 2);
            Width = builder.CreateComboBox(nameof(Width), App.Config.Widths, label: "in");
            Length = builder.CreateComboBox(nameof(Length), App.Config.Lengths, label: "ft");
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse, value: 1);
            Labor = builder.CreateComboBox<decimal>(nameof(Labor), App.Config.PieceValues, decimal.TryParse, "PHP", 150);

            Fields = new BindableCollection<IHasValue>
            {
                Thickness, Width, Length, Quantity
            };
        }

        public override string Name { get; } = "Foam";

        public override Material Type { get; } = Material.Foam;

        public Caption<int> Length { get; }

        public Caption<int> Quantity { get; }

        public Caption<int> Thickness { get; }

        public Caption<int> Width { get; }

        public Caption<decimal> Labor { get; }

        public override decimal GetTotal()
        {
            return (Thickness.Value ?? 0 * Width.Value ?? 0 * Length.Value ?? 0 / 12m * Quantity.Value ?? 0 + Labor.Value ?? 0);
        }
    }
}
