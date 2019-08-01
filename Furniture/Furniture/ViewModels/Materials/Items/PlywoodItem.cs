using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using Newtonsoft.Json;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials.Items
{
    public sealed class PlywoodItem : MaterialBase
    {
        [JsonConstructor]
        public PlywoodItem(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Thickness = builder.CreateComboBox(nameof(Thickness), App.Config.Plywood);
            Quantity = builder.CreateTextBox(nameof(Quantity), int.TryParse, value: 1);

            Fields = new BindableCollection<IHasValue>
            {
                Thickness, Quantity
            };
        }

        public override string Name => "Plywood";

        [JsonIgnore] public Caption<int> Quantity { get; }

        [JsonIgnore] public Caption<decimal> Thickness { get; }

        [JsonIgnore] public override Material Type { get; } = Material.Wood;

        public override decimal GetTotal()
        {
            return (decimal) (Thickness.Value * Quantity.Value);
        }
    }
}