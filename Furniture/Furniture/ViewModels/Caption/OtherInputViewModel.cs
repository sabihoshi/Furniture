using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class OtherInputViewModel<T> : Child where T : struct
    {
        public OtherInputViewModel(ComboBoxViewModel<T> parent, InputBox<T>.TryParse tryParse) : base(parent)
        {
            var builder = new CaptionBuilder(parent);
            Field = builder.CreateTextBox(parent.Caption, tryParse);
            Field.Input.Text = parent.SelectedValue.Name;
        }

        public CaptionModel<T> Field { get; set; }
    }
}