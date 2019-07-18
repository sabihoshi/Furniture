using System;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Caliburn.Micro;
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

        public CaptionViewModel<T> Field { get; set; }

        public event EventHandler<T?> ValueChanged;

        public void OnClosing()
        {
            ValueChanged?.Invoke(this, Field.Value);
        }

        public void KeyDown(KeyEventArgs args)
        {
            if(args != null && args.Key == Key.Enter)
                ValueChanged?.Invoke(this, Field.Value);
        }
    }
}