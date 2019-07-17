using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public class ConcealedViewModel : MaterialModel
    {
        public ConcealedViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Amount = builder.CreateComboBox(nameof(Amount), App.Config.Values, decimal.TryParse);
            Pairs = builder.CreateTextBox<int>(nameof(Pairs), int.TryParse);

            Fields = new List<IHasValue>
            {
                Amount, Pairs
            };
        }

        public CaptionModel<decimal> Amount { get; }
        public override string Name => "Concealed";
        public CaptionModel<int> Pairs { get; }

        public override Material Type => Material.Concealed;

        public override decimal GetTotal()
        {
            return (decimal) (Amount.Value * Pairs.Value);
        }
    }
}