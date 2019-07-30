using System.Collections.Generic;
using System.Linq;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public static class CaptionFactory
    {
        public static Caption<T> WithComboBox<T>(this Caption<T> model, IParent parent,
            List<ComboBoxItem<T>> values, string caption, string label,
            InputBox<T>.TryParse tryParse, ComboBoxItem<T> value) where T : struct
        {
            model.Input = new ComboBoxViewModel<T>(parent ?? model.Parent, values, caption, label, tryParse, value);
            return model;
        }

        public static Caption<T> WithTextBox<T>(this Caption<T> model, IParent parent, string caption, string label,
            InputBox<T>.TryParse tryParse, T value)
            where T : struct
        {
            model.Input = new TextBoxViewModel<T>(parent, caption ?? model.Name, label, tryParse, value);
            return model;
        }
    }

    public class CaptionBuilder
    {
        public CaptionBuilder(IParent parent)
        {
            Parent = parent;
        }

        public IParent Parent { get; set; }

        public Caption<T> CreateComboBox<T>(string caption, List<ComboBoxItem<T>> values,
            InputBox<T>.TryParse tryParse = null, string label = null, ComboBoxItem<T> value = null)
            where T : struct
        {
            return new Caption<T>(Parent, caption).WithComboBox(Parent, values, caption, label, tryParse, value);
        }

        public Caption<T> CreateComboBox<T>(string caption, List<T> values,
            InputBox<T>.TryParse tryParse = null,
            string label = null, T? value = null)
            where T : struct
        {
            var comboBoxItems = values.Select(v => new ComboBoxItem<T>(v)).ToList();

            if (value == null)
                return CreateComboBox(caption, comboBoxItems, tryParse, label);

            var index = values.IndexOf((T) value);

            if (index != -1)
                return CreateComboBox(caption, comboBoxItems, tryParse, label, comboBoxItems[index]);

            var defaultValue = new ComboBoxItem<T>((T) value);
            comboBoxItems.Add(defaultValue);
            return CreateComboBox(caption, comboBoxItems, tryParse, label, defaultValue);
        }

        public Caption<T> CreateTextBox<T>(string caption, InputBox<T>.TryParse tryParse, string label = null,
            T value = default)
            where T : struct
        {
            return new Caption<T>(Parent, caption).WithTextBox(Parent, caption, label, tryParse, value);
        }
    }
}