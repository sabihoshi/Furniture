using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public class ConcealedViewModel : MaterialBase
    {
        public ConcealedViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Amount = builder.CreateComboBox(nameof(Amount), App.Config.Values, decimal.TryParse);
            Pairs = builder.CreateTextBox<int>(nameof(Pairs), int.TryParse);

            Fields = new BindableCollection<IHasValue>
            {
                Amount, Pairs
            };
        }

        public Caption<decimal> Amount { get; }
        public override string Name => "Concealed";
        public Caption<int> Pairs { get; }

        public override Material Type => Material.Concealed;

        public override decimal GetTotal()
        {
            return (decimal) (Amount.Value * Pairs.Value);
        }
    }
}