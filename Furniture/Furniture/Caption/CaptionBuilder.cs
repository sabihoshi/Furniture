using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Furniture.Relationship;
using Furniture.ViewModels;

namespace Furniture.Caption
{
    public static class CaptionFactory
    {
        public static bool Convert<T>(this string input, out T result)
        {
            result = default(T);
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    try
                    {
                        result = (T) converter.ConvertFromString(input);
                        return true;
                    }
                    catch (Exception ex) when (ex.InnerException is FormatException)
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }

        public static CaptionViewModel<TOutput> WithCaption<TOutput>(this CaptionViewModel<TOutput> model,
                                                                     string caption)
        {
            model.Caption = caption;
            return model;
        }

        public static CaptionViewModel<TOutput> WithComboBox<TOutput>(this CaptionViewModel<TOutput> model,
                                                                             List<ComboBoxItem<TOutput>>
                                                                                 values, IParent parent = null)
        {
            model.Input = new ComboBoxViewModel<TOutput>(parent ?? model.Parent, values);
            return model;
        }

        public static CaptionViewModel<TOutput> WithTextBox<TOutput>(this CaptionViewModel<TOutput> model,
                                                                     IParent parent = null)
        {
            model.Input = new TextBoxViewModel<TOutput>(parent ?? model.Parent);
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

        public CaptionViewModel<TOutput> CreateComboBox<TOutput>(CaptionViewModel<TOutput> model, string caption,
                                                                        List<ComboBoxItem<TOutput>> values)
        {
            model = new CaptionViewModel<TOutput>(caption).WithComboBox<TOutput>(values, Parent);
            return model;
        }

        public CaptionViewModel<TOutput> CreateTextBox<TOutput>(CaptionViewModel<TOutput> model, string caption)
        {
            model = new CaptionViewModel<TOutput>(caption).WithTextBox(Parent);
            return model;
        }

        public CaptionViewModel<TOutput> CreateComboBox<TOutput>(CaptionViewModel<TOutput> model, string caption, List<TOutput> values)
        {
            var result = values.Select(value => new ComboBoxItem<TOutput>(value.ToString(), value)).ToList();
            return CreateComboBox<TOutput>(model, caption, result);
        }
    }
}