using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Caption;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public class FrameViewModel : MaterialBase
    {
        public FrameViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Labor = builder.CreateComboBox(nameof(Labor), App.Config.Values, decimal.TryParse);
            Frame = builder.CreateComboBox(nameof(Frame), App.Config.Values, decimal.TryParse);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse);

            Fields = new BindableCollection<IHasValue>
            {
                Labor, Frame, Quantity
            };
        }

        public Caption<decimal> Frame { get; }
        public Caption<decimal> Labor { get; }
        public override string Name => "Metal Frame";
        public Caption<int> Quantity { get; }
        public override Material Type => Material.Frame;

        public override decimal GetTotal()
        {
            return (decimal) (Labor.Value + Frame.Value * Quantity.Value);
        }
    }
}