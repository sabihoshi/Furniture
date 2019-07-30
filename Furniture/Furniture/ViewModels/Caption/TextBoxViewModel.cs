using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class TextBoxViewModel<T> : InputBox<T> where T : struct
    {
        public TextBoxViewModel(IParent parent, string caption, string label, TryParse tryParse, T value) : base(parent, caption, label,
            tryParse, value) { }
    }
}