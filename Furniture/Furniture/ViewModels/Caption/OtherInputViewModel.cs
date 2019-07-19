using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Caliburn.Micro;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class OtherInputViewModel<T> : Child, IViewAware where T : struct
    {
        private UserControl _dialogWindow;

        public OtherInputViewModel(ComboBoxViewModel<T> parent, InputBox<T>.TryParse tryParse) : base(parent)
        {
            var builder = new CaptionBuilder(parent);
            Field = builder.CreateTextBox(parent.Caption, tryParse);
            Field.Input.Text = parent.SelectedValue.Name;
        }

        public CaptionViewModel<T> Field { get; set; }

        public void AttachView(object view, object context = null)
        {
            _dialogWindow = view as UserControl;
            ViewAttached?.Invoke(this,
                new ViewAttachedEventArgs { Context = context, View = view });
        }

        public object GetView(object context = null)
        {
            return _dialogWindow;
        }

        public event EventHandler<ViewAttachedEventArgs> ViewAttached;

        public void KeyDown(object source, KeyEventArgs args)
        {
            if (args != null && args.Key == Key.Enter)
            {
                _dialogWindow.Opacity = 0;
                ValueChanged?.Invoke(this, Field.Value);
            }
        }

        public void OnClosing()
        {
            ValueChanged?.Invoke(this, Field.Value);
        }

        public event EventHandler<T?> ValueChanged;
    }
}