using System;
using System.Runtime.CompilerServices;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class CaptionViewModel<T> : Child, IParent where T : IConvertible
    {
        public enum CaptionType
        {
            ComboBox,
            TextBox
        }
        public CaptionViewModel(IParent parent = null, [CallerMemberName] string caption = null, InputBox<T> input = null)
        {
            Parent = parent;
            Caption = caption;
            Input = input;
        }

        public T TValue
        {
            get => Input.TValue;
            set => Input.TValue = value;
        }

        public string Caption { get; set; }
        public InputBox<T> Input { get; set; }
    }
}