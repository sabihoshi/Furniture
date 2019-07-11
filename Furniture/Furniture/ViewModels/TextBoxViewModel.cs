using Furniture.Caption;

namespace Furniture.ViewModels
{
    public class TextBoxViewModel : Input
    {
        public TextBoxViewModel(IParent parent, string value) : base(parent)
        {
            Value = value;
        }
        public TextBoxViewModel(IParent parent) : base(parent) { }
    }
}