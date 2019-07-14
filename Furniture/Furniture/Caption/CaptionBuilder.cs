using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using Furniture.Relationship;
using Furniture.ViewModels;

namespace Furniture.Caption
{
    public static class CaptionFactory
    {
        public static CaptionViewModel<T> WithComboBox<T>(this CaptionViewModel<T> model, IParent parent,
                                                          List<ComboBoxItem<T>> values, string caption, bool other,
                                                          InputBox<T>.TryParse tryParse) where T : struct
        {
            model.Input = new ComboBoxViewModel<T>(parent ?? model.Parent, values, caption, other, tryParse);
            return model;
        }

        public static CaptionViewModel<T> WithTextBox<T>(this CaptionViewModel<T> model, IParent parent, string caption,
                                                         InputBox<T>.TryParse tryParse)
            where T : struct
        {
            model.Input = new TextBoxViewModel<T>(parent, caption ?? model.Caption, tryParse);
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
        public CaptionViewModel<T> CreateTextBox<T>(string caption, InputBox<T>.TryParse tryParse)
            where T : struct
        {
            return new CaptionViewModel<T>(Parent, caption).WithTextBox(Parent, caption, tryParse);
        }

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<ComboBoxItem<T>> values, bool other = false, InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            return new CaptionViewModel<T>(Parent, caption).WithComboBox(Parent, values, caption, other, tryParse);
        }

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<T> values, bool other = false, InputBox<T>.TryParse tryParse = null)
            where T : struct
        {
            var result = values.Select(value => new ComboBoxItem<T>(value)).ToList();
            return CreateComboBox(caption, result, other, tryParse);
        }
    }
}