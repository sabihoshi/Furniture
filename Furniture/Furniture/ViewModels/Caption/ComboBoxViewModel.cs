using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Caption
{
    public class ComboBoxViewModel<T> : InputBox<T>, IParent where T : struct
    {
        private readonly TryParse _tryParse;
        private readonly WindowManager _windowManager = new WindowManager();
        private ComboBoxItem<T> _selectedValue;

        public ComboBoxViewModel(IParent parent, List<ComboBoxItem<T>> values, string caption, string label,
            TryParse tryParse, ComboBoxItem<T> value = null) :
            base(parent, caption, label, tryParse)
        {
            _tryParse = tryParse;
            Values = new BindableCollection<ComboBoxItem<T>>(values);

            SelectedValue = value ?? Values?.FirstOrDefault();

            if (tryParse != null)
            {
                Other = new ComboBoxItem<T>("Other...", SelectedValue.Value);
                Values?.Add(Other);
            }
        }

        public bool IsEditable => SelectedValue == Other;

        public ComboBoxItem<T> Other { get; }

        public ComboBoxItem<T> SelectedValue
        {
            get => _selectedValue;
            set
            {
                if (value == Other)
                    Text = _selectedValue.Name;

                _selectedValue = value;
            }
        }

        public override T? Value
        {
            get
            {
                if (IsEditable)
                {
                    if (_tryParse(Text, out var result))
                        return result;
                    return null;
                }

                return SelectedValue?.Value;
            }
        }

        public BindableCollection<ComboBoxItem<T>> Values { get; set; }
    }
}