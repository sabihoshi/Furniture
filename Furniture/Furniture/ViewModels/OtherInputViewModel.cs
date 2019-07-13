using System;
using System.Linq;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class OtherInputViewModel<T> : Child where T : class, IConvertible
    {
        public OtherInputViewModel(ComboBoxViewModel<T> parent) : base(parent)
        {
            var builder = new CaptionBuilder(parent);
            Field = builder.CreateTextBox<T>(parent.Caption);
            Field.TValue = parent.TValue ?? parent.Values.First().Value;
            Field.Input.Output = parent.SelectedValue.Name;
        }

        public CaptionViewModel<T> Field { get; set; }
    }
}
