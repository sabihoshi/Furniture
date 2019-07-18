using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public class HandleViewModel : MaterialModel
    {
        public HandleViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Amount = builder.CreateComboBox(nameof(Amount), App.Config.Values, decimal.TryParse);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse);

            Fields = new List<IHasValue>
            {
                Amount, Quantity
            };
        }

        public CaptionModel<decimal> Amount { get; }

        public override string Name => "Handles";
        public CaptionModel<int> Quantity { get; }

        public override Material Type => Material.Handles;

        public override decimal GetTotal()
        {
            return (decimal) (Amount.Value * Quantity.Value);
        }
    }
}