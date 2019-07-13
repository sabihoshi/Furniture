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
        public static bool TryParse<T>(this string input, out T result) where T : IConvertible
        {
            result = default;
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    try
                    {
                        result = (T) converter.ConvertFromString(input);
                        return true;
                    }
                    catch { return false; }
                }

                return false;
            }
            catch (NotSupportedException) { return false; }
        }

        public static CaptionViewModel<T> WithCaption<T>(this CaptionViewModel<T> model, string caption)
            where T : IConvertible
        {
            model.Caption = caption;
            return model;
        }

        public static CaptionViewModel<T> WithComboBox<T>(this CaptionViewModel<T> model, List<ComboBoxItem<T>> values, string caption, bool other, IParent parent = null) where T : IConvertible
        {
            model.Input = new ComboBoxViewModel<T>(parent ?? model.Parent, values, caption, other);
            return model;
        }

        public static CaptionViewModel<T> WithTextBox<T>(this CaptionViewModel<T> model, string caption = null, IParent parent = null)
            where T : IConvertible
        {
            model.Input = new TextBoxViewModel<T>(parent ?? model.Parent, caption ?? model.Caption);
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
        public CaptionViewModel<T> CreateTextBox<T>(string caption)
            where T : IConvertible
        {
            return new CaptionViewModel<T>(Parent, caption).WithTextBox(caption, Parent);
        }

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<ComboBoxItem<T>> values, bool other = false)
            where T : IConvertible
        {
            return new CaptionViewModel<T>(Parent, caption).WithComboBox(values, caption, other, Parent);
        }

        public CaptionViewModel<T> CreateComboBox<T>(string caption, List<T> values, bool other = false)
            where T : IConvertible
        {
            var result = values.Select(value => new ComboBoxItem<T>(value)).ToList();
            return CreateComboBox(caption, result, other);
        }
    }
}