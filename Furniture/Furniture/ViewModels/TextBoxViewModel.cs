using System;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class TextBoxViewModel<T> : InputBox<T> where T : IConvertible
    {
        public T GetValue()
        {
            return TValue;
        }
        public TextBoxViewModel(IParent parent, string caption) : base(parent, caption) { }
    }
}