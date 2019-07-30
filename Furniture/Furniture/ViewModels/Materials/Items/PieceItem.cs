using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Furniture.ViewModels.Materials.Models;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials.Items
{
    public class PieceItem : MaterialBase
    {
        private readonly Piece _material;

        public PieceItem(IParent parent, Piece material) : base(parent)
        {
            _material = material;

            var builder = new CaptionBuilder(this);

            Amount = builder.CreateComboBox(nameof(Amount), App.Config.PieceValues, decimal.TryParse, "PHP", _material.Value);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse, value: 1);

            Fields = new BindableCollection<IHasValue>
            {
                Amount, Quantity
            };
        }

        public override string Name => _material.Name;

        public Caption<decimal> Amount { get; }

        public Caption<int> Quantity { get; }

        public override Material Type => _material.Type;

        public override decimal GetTotal()
        {
            return (decimal) (Amount.Value * Quantity.Value);
        }
    }
}