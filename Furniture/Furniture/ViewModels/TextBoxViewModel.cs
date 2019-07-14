using System;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class TextBoxViewModel<T> : InputBox<T> where T : struct
    {
        public TextBoxViewModel(IParent parent, string caption, TryParse tryParse) : base(parent, caption, tryParse) { }
    }
}