using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public class HandleViewModel : MaterialBase
    {
        public HandleViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Amount = builder.CreateComboBox(nameof(Amount), App.Config.Values, decimal.TryParse);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse);

            Fields = new BindableCollection<IHasValue>
            {
                Amount, Quantity
            };
        }

        public CaptionViewModel<decimal> Amount { get; }

        public override string Name => "Handles";
        public CaptionViewModel<int> Quantity { get; }

        public override Material Type => Material.Handles;

        public override decimal GetTotal()
        {
            return (decimal) (Amount.Value * Quantity.Value);
        }
    }
}