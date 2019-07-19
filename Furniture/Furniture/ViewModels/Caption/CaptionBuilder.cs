using System.Collections.Generic;
using System.Linq;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public static class CaptionFactory
    {
        public static Caption<T> WithComboBox<T>(this Caption<T> model, IParent parent,
                                                          List<ComboBoxItem<T>> values, string caption,
                                                          InputBox<T>.TryParse tryParse = null) where T : struct
        {
            model.Input = new ComboBoxViewModel<T>(parent ?? model.Parent, values, caption, tryParse);
            return model;
        }

        public static Caption<T> WithTextBox<T>(this Caption<T> model, IParent parent, string caption,
                                                         InputBox<T>.TryParse tryParse, T value)
            where T : struct
        {
            model.Input = new TextBoxViewModel<T>(parent, caption ?? model.Name, tryParse, value);
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
                                                     InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            return new Caption<T>(Parent, caption).WithComboBox(Parent, values, caption, tryParse);
        }

        public Caption<T> CreateComboBox<T>(string caption, List<T> values,
                                                     InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            var result = values.Select(value => new ComboBoxItem<T>(value)).ToList();
            return CreateComboBox(caption, result, tryParse);
        }

        public Caption<T> CreateTextBox<T>(string caption, InputBox<T>.TryParse tryParse, T value = default)
            where T : struct
        {
            return new Caption<T>(Parent, caption).WithTextBox(Parent, caption, tryParse, value);
        }
    }
}