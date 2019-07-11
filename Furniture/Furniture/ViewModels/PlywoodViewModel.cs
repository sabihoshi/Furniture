using System.Collections.Generic;
using System.Linq;
using Furniture.Caption;
using Furniture.Materials;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : MaterialModel, IParent
    {
        private readonly Plywood _plywood = App.Config.Plywood;
        public PlywoodViewModel(IParent parentModel) : base(parentModel)
        {
            var builder = new CaptionBuilder(this);

            Fields = new List<CaptionViewModel<decimal>>
            {
                builder.CreateComboBox<decimal>(Thickness, nameof(Thickness), _plywood.Thicknesses),
                builder.CreateTextBox(Quantity, nameof(Quantity))
            };
        }

        public override string Name => "Plywood";

        public Plywood Plywood { get; set; } = App.Config.Plywood;

        public CaptionViewModel<decimal> Quantity { get; } 
        public CaptionViewModel<decimal> Thickness { get; }

        public override decimal Total { get; set; }

        public override void Update()
        {
            var price = Plywood.Thicknesses.Single(thickness => thickness.Value == Thickness.Input.Value).Value;
            Total = price * Quantity.Value;

            base.Update();
        }
    }
}