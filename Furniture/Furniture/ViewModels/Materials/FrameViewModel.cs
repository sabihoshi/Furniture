using System.Collections.Generic;
using Furniture.Relationship;
using Furniture.ViewModels.Caption;

namespace Furniture.ViewModels.Materials
{
    public class FrameViewModel : MaterialModel
    {
        public FrameViewModel(IParent parent) : base(parent)
        {
            var builder = new CaptionBuilder(this);

            Labor = builder.CreateComboBox(nameof(Labor), App.Config.Values, decimal.TryParse);
            Frame = builder.CreateComboBox(nameof(Frame), App.Config.Values, decimal.TryParse);
            Quantity = builder.CreateTextBox<int>(nameof(Quantity), int.TryParse);

            Fields = new List<IHasValue>
            {
                Labor, Frame, Quantity
            };
        }

        public CaptionViewModel<decimal> Frame { get; }
        public CaptionViewModel<decimal> Labor { get; }
        public override string Name => "Metal Frame";
        public CaptionViewModel<int> Quantity { get; }
        public override Material Type => Material.Frame;

        public override decimal GetTotal()
        {
            return (decimal) (Labor.Value + Frame.Value * Quantity.Value);
        }
    }
}