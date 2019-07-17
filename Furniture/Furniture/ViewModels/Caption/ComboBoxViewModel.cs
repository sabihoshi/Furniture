using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Caption
{
    public class ComboBoxViewModel<T> : InputBox<T>, IParent where T : struct
    {
        private ComboBoxItem<T> _selectedValue;
        private readonly WindowManager _windowManager = new WindowManager();

        public ComboBoxViewModel(IParent parent, List<ComboBoxItem<T>> values, string caption, TryParse tryParse) : base(parent, caption, tryParse)
        {
            Values = values;
            SelectedValue = Values?.First();

            if(tryParse != null)
            {
                OtherCaption = new OtherInputViewModel<T>(this, tryParse);
                Values?.Add(Other);
            }
        }

        public OtherInputViewModel<T> OtherCaption { get; }
        public ComboBoxItem<T> Other { get; } = new ComboBoxItem<T>("Other...", default);

        public ComboBoxItem<T> SelectedValue
        {
            get => _selectedValue;
            set
            {
                if(value == Other)
                    _windowManager.ShowPopup(OtherCaption);

                _selectedValue = value; 
            }
        }
        public override T? Value => SelectedValue.Value;
        public List<ComboBoxItem<T>> Values { get; set; }
    }
}