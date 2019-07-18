using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public sealed class PlywoodViewModel : MaterialModel
    {
        private readonly Plywood _plywood = App.Config.Plywood;

        public PlywoodViewModel(IParent parentModel) : base(parentModel)
        {
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateComboBox(nameof(Thickness), _plywood.Thicknesses);
            Quantity = builder.CreateTextBox(nameof(Quantity), int.TryParse, 1);

            Fields = new List<IHasValue>
            {
                Thickness, Quantity
            };
        }

        public override string Name => "Plywood";
        public Plywood Plywood { get; set; } = App.Config.Plywood;
        public CaptionViewModel<int> Quantity { get; }
        public CaptionViewModel<decimal> Thickness { get; }

        public override Material Type => Material.Wood;

        public override decimal GetTotal()
        {
            return (decimal) (Thickness.Value * Quantity.Value);
        }
    }
}