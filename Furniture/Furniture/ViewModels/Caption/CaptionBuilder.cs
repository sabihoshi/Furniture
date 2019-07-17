using System.Collections.Generic;
using System.Linq;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public static class CaptionFactory
    {
        public static CaptionViewModel<T> WithComboBox<T>(this CaptionViewModel<T> model, IParent parent,
                                                          List<ComboBoxItem<T>> values, string caption,
                                                          InputBox<T>.TryParse tryParse = null) where T : struct
        {
            model.Input = new ComboBoxViewModel<T>(parent ?? model.Parent, values, caption, tryParse);
            return model;
        }

        public static CaptionViewModel<T> WithTextBox<T>(this CaptionViewModel<T> model, IParent parent, string caption,
                                                         InputBox<T>.TryParse tryParse, T value)
            where T : struct
        {
            model.Input = new TextBoxViewModel<T>(parent, caption ?? model.Caption, tryParse, value);
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

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<ComboBoxItem<T>> values,
                                                     InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            return new CaptionViewModel<T>(Parent, caption).WithComboBox(Parent, values, caption, tryParse);
        }

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<T> values,
                                                     InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            var result = values.Select(value => new ComboBoxItem<T>(value)).ToList();
            return CreateComboBox(caption, result, tryParse);
        }

        public CaptionViewModel<T> CreateTextBox<T>(string caption, InputBox<T>.TryParse tryParse, T value = default)
            where T : struct
        {
            return new CaptionViewModel<T>(Parent, caption).WithTextBox(Parent, caption, tryParse, value);
        }
    }
}