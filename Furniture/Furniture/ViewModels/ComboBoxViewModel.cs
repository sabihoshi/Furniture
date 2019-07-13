using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Furniture.Caption;
using Furniture.Views;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels
{
    public class ComboBoxViewModel<T> : InputBox<T>, IParent where T : IConvertible
    {
        private ComboBoxItem<T> _selectedValue;
        private readonly WindowManager _windowManager = new WindowManager();

        public ComboBoxViewModel(IParent parent, List<ComboBoxItem<T>> values, string caption, bool other) : base(parent, caption)
        {
            Values = values;
            SelectedValue = Values?.First();

            if(other)
            {
                OtherCaption = new OtherInputViewModel<T>(this);
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
        public override T TValue => SelectedValue.Value;
        public List<ComboBoxItem<T>> Values { get; set; }
    }
}