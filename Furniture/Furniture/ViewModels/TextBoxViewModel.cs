using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class TextBoxViewModel<TOutput> : Input<TOutput> 
    {
        public TOutput GetValue()
        {
            return Value;
        }
        public override InputType Type { get; } = InputType.TextBox;
        public TextBoxViewModel(IParent parent) : base(parent) { }
    }
}