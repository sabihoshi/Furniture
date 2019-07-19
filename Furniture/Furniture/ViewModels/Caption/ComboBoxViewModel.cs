using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Caption
{
    public class ComboBoxViewModel<T> : InputBox<T>, IParent where T : struct
    {
        private ComboBoxItem<T> _selectedValue;
        private readonly WindowManager _windowManager = new WindowManager();

        public ComboBoxViewModel(IParent parent, List<ComboBoxItem<T>> values, string caption, TryParse tryParse) :
            base(parent, caption, tryParse)
        {
            Values = new BindableCollection<ComboBoxItem<T>>(values);
            SelectedValue = Values?.First();

            if (tryParse != null)
            {
                OtherCaption = new OtherInputViewModel<T>(this, tryParse);

                OtherCaption.ValueChanged += (source, value) =>
                {
                    if (value is T result)
                    {
                        var newOption = new ComboBoxItem<T>(result);
                        Values.Add(newOption);
                        SelectedValue = newOption;
                    }
                };

                Values?.Add(Other);
            }
        }

        public ComboBoxItem<T> Other { get; } = new ComboBoxItem<T>("Other...", default);

        public OtherInputViewModel<T> OtherCaption { get; }

        public ComboBoxItem<T> SelectedValue
        {
            get => _selectedValue;
            set
            {
                if (value == Other)
                {
                    dynamic settings = new ExpandoObject();
                    settings.StaysOpen = false;
                    _windowManager.ShowPopup(OtherCaption, null, settings);
                }
                else
                    _selectedValue = value;
            }
        }

        public override T? Value => SelectedValue.Value;
        public BindableCollection<ComboBoxItem<T>> Values { get; set; }
    }
}